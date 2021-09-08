using System;
using University.Api.Models;

namespace University.Api.Features
{
    public static class BookExtensions
    {
        public static BookDto ToDto(this Book book)
        {
            return new()
            {
                BookId = book.BookId,
                BookName = book.BookName,
                PublishYear = book.PublishYear,
                Color = book.Color
            };
        }
    }
}
