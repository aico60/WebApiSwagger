using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSwagger.Models;

namespace WebApiSwagger.Services
{
    public interface IBookService
    {
        void CreateBook(Book book);

        ICollection<Book> GetAllBooks();

        Book GetBookById(int? Id);

        void EditBook(Book book);

        void DeleteBook(int? Id);
    }
}
