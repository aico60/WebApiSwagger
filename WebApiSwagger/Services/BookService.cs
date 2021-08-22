using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSwagger.Data;
using WebApiSwagger.Models;

namespace WebApiSwagger.Services
{
    public class BookService : IBookService
    {
        private ApplicationDbContext _context { get; set; }
        public BookService(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public void CreateBook(Book book)
        {
            var bookToAdd = new Book
            {
                Name = book.Name,
                Description = book.Description,
                Price = book.Price,
                Year = book.Year
            };
            this._context.Books.Add(bookToAdd);
            this._context.SaveChanges();
        }

        public ICollection<Book> GetAllBooks()
        {
            return this._context.Books.ToList();
        }

        public Book GetBookById(int? id)
        {
            return this._context.Books
                .FirstOrDefault(m => m.Id == id);
        }

        public void EditBook(Book book)
        {
            var bookToEdit = this._context.Books.FirstOrDefault(m => m.Id == book.Id);
            bookToEdit.Name = book.Name;
            bookToEdit.Description = book.Description;
            bookToEdit.Year = book.Year;
            bookToEdit.Price = book.Price;

            //this._context.Update(bookToEdit);
            this._context.SaveChanges();
        }

        public void DeleteBook(int? id)
        {
            var bookToDelete = this._context.Books.FirstOrDefault(m => m.Id == id);
            this._context.Remove(bookToDelete);
            this._context.SaveChanges();
        }
    }
}
