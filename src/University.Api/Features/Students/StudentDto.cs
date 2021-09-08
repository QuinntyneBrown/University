using System;

namespace University.Api.Features
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        public BookDto Book { get; set; }
        public CellphoneDto Cellphone { get; set; }
    }
}
