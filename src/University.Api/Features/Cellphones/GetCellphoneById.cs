using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using University.Api.Core;
using University.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace University.Api.Features
{
    public class GetCellphoneById
    {
        public class Request: IRequest<Response>
        {
            public int CellphoneId { get; set; }
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
                return new () {
                    Cellphone = (await _context.Cellphones.SingleOrDefaultAsync(x => x.PhoneId == request.CellphoneId)).ToDto()
                };
            }
            
        }
    }
}
