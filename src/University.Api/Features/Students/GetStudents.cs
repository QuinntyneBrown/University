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
    public class GetStudents
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<StudentDto> Students { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IUniversityDbContext _context;
        
            public Handler(IUniversityDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Students = await _context.Students
                    .Include(x => x.Book)
                    .Include(x => x.Cellphone)
                    .Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
