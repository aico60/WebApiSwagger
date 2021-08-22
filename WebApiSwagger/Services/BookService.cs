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
            this._context.Books.Add(book);
            this._context.SaveChangesAsync();
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
            this._context.Update(bookToEdit);
            this._context.SaveChangesAsync();
        }

        public void DeleteBook(int? id)
        {
            var book = this._context.Books.FirstOrDefault(m => m.Id == id);
            this._context.Remove(book);
            this._context.SaveChangesAsync();
        }
    }
}
