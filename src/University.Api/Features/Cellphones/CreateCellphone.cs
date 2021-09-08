using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using University.Api.Models;
using University.Api.Core;
using University.Api.Interfaces;

namespace University.Api.Features
{
    public class CreateCellphone
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Cellphone).NotNull();
                RuleFor(request => request.Cellphone).SetValidator(new CellphoneValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public CellphoneDto Cellphone { get; set; }
        }

        public class Response: ResponseBase
        {
            public CellphoneDto Cellphone { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IUniversityDbContext _context;
        
            public Handler(IUniversityDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var cellphone = new Cellphone();
                
                _context.Cellphones.Add(cellphone);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Cellphone = cellphone.ToDto()
                };
            }
            
        }
    }
}
