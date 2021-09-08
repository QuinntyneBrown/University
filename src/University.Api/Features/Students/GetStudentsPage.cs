using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using University.Api.Core;
using University.Api.Extensions;
using University.Api.Interfaces;

namespace University.Api.Features
{
    public class GetStudentsPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<StudentDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IUniversityDbContext _context;

            public Handler(IUniversityDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from student in _context.Students
                            .Include(x => x.Book)
                            .Include(x => x.Cellphone)
                            select student;

                var length = await _context.Students.CountAsync();

                var students = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = students
                };
            }

        }
    }
}
