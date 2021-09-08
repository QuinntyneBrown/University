using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using University.Api.Core;
using University.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace University.Api.Features
{
    public class GetStudentById
    {
        public class Request: IRequest<Response>
        {
            public int StudentId { get; set; }
        }

        public class Response: ResponseBase
        {
            public StudentDto Student { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IUniversityDbContext _context;
        
            public Handler(IUniversityDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Student = (await _context.Students
                    .Include(x => x.Book)
                    .Include(x => x.Cellphone)
                    .SingleOrDefaultAsync(x => x.StudentId == request.StudentId)).ToDto()
                };
            }
            
        }
    }
}
