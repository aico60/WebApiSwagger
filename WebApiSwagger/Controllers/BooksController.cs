using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApiSwagger.Data;
using WebApiSwagger.Models;
using WebApiSwagger.Services;

namespace WebApiSwagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("api/[controller]/GetAllBooks")]
        public IActionResult GetBooks()
        {
            return Ok(this.bookService.GetAllBooks());
        }

        [HttpGet]
        [Route("api/[controller]/GetBookById")]
        public IActionResult GetBook(int? id)
        {
            if (this.bookService.GetBookById(id) != null)
            {
                return Ok(this.bookService.GetBookById(id));
            }

            return NotFound($"Couldn't find book with Id: {id}");
        }

        [HttpPost]
        [Route("api/[controller]/Create")]
        public IActionResult Create(Book book)
        {
            this.bookService.CreateBook(book);
            return Ok();
        }

        [HttpPost]
        [Route("api/[controller]/Edit")]
        public IActionResult Edit(Book book)
        {
            if (this.bookService.GetBookById(book.Id) != null)
            {
                this.bookService.EditBook(book);
                return Ok();
            }

            return NotFound($"Couldn't find book with Id: {book.Id}");
        }

        [HttpDelete]
        [Route("api/[controller]/Delete")]
        public IActionResult Delete(int? id)
        {
            if (this.bookService.GetBookById(id) != null)
            {
                this.bookService.DeleteBook(id);
                return Ok();
            }

            return NotFound($"Couldn't find book with Id:  {id}");
        }

    }
}
