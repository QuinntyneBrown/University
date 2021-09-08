using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using University.Api.Core;
using University.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace University.Api.Features
{
    public class GetCellphones
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<CellphoneDto> Cellphones { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IUniversityDbContext _context;

            public Handler(IUniversityDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    Cellphones = await _context.Cellphones.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
