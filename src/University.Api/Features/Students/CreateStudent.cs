using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using University.Api.Models;
using University.Api.Core;
using University.Api.Interfaces;

namespace University.Api.Features
{
    public class CreateStudent
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Student).NotNull();
                RuleFor(request => request.Student).SetValidator(new StudentValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public StudentDto Student { get; set; }
        }

        public class Response : ResponseBase
        {
            public StudentDto Student { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IUniversityDbContext _context;

            public Handler(IUniversityDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var student = new Student();

                _context.Students.Add(student);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Student = student.ToDto()
                };
            }

        }
    }
}
