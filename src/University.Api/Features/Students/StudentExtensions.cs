using System;
using University.Api.Models;

namespace University.Api.Features
{
    public static class StudentExtensions
    {
        public static StudentDto ToDto(this Student student)
        {
            return new()
            {
                StudentId = student.StudentId,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Age = student.Age,
                Sex = student.Sex,
                Book = student.Book?.ToDto(),
                Cellphone = student.Cellphone?.ToDto()
            };
        }
    }
}
