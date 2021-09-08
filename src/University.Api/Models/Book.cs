using System;

namespace University.Api.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public int PublishYear { get; set; }
        public string Color { get; set; }
    }
}
