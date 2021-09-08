using System;
using University.Api.Models;

namespace University.Api.Features
{
    public static class StudentExtensions
    {
        public static StudentDto ToDto(this Student student)
        {
            return new ()
            {
                StudentId = student.StudentId
            };
        }
        
    }
}
