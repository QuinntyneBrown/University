using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using University.Api.Extensions;
using University.Api.Core;
using University.Api.Interfaces;
using University.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace University.Api.Features
{
    public class GetCellphonesPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<CellphoneDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IUniversityDbContext _context;
        
            public Handler(IUniversityDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from cellphone in _context.Cellphones
                    select cellphone;
                
                var length = await _context.Cellphones.CountAsync();
                
                var cellphones = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = cellphones
                };
            }
            
        }
    }
}
