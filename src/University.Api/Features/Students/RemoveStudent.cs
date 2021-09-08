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
    public class RemoveStudent
    {
        public class Request: IRequest<Response>
        {
            public Guid StudentId { get; set; }
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
                var student = await _context.Students.SingleAsync(x => x.StudentId == request.StudentId);
                
                _context.Students.Remove(student);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Student = student.ToDto()
                };
            }
            
        }
    }
}
