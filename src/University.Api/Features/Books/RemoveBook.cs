using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using University.Api.Models;
using University.Api.Core;
using University.Api.Interfaces;

namespace University.Api.Features
{
    public class RemoveBook
    {
        public class Request: IRequest<Response>
        {
            public Guid BookId { get; set; }
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
                var book = await _context.Books.SingleAsync(x => x.BookId == request.BookId);
                
                _context.Books.Remove(book);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Book = book.ToDto()
                };
            }
            
        }
    }
}
