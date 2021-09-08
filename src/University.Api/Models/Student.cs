using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Api.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        [ForeignKey("Book")]
        public Guid BookeId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("Cellphone")]
        public Guid PhoneId { get; set; }
        public Cellphone Cellphone { get; set; }

    }
}
