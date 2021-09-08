using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using University.Api.Models;
using University.Api.Core;
using University.Api.Interfaces;

namespace University.Api.Features
{
    public class CreateBook
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Book).NotNull();
                RuleFor(request => request.Book).SetValidator(new BookValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public BookDto Book { get; set; }
        }

        public class Response: ResponseBase
        {
            public BookDto Book { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IUniversityDbContext _context;
        
            public Handler(IUniversityDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var book = new Book();
                
                _context.Books.Add(book);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Book = book.ToDto()
                };
            }
            
        }
    }
}
