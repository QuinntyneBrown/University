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
    public class RemoveCellphone
    {
        public class Request: IRequest<Response>
        {
            public Guid CellphoneId { get; set; }
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
                var cellphone = await _context.Cellphones.SingleAsync(x => x.PhoneId == request.CellphoneId);
                
                _context.Cellphones.Remove(cellphone);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Cellphone = cellphone.ToDto()
                };
            }
            
        }
    }
}
