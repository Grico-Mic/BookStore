using BookStore.DtoModels;
using BookStore.Mappings;
using BookStore.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        /// <summary>
        /// Return all books for given paramethers,if any
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string title, string author)
        {
            var books = _booksService.GetWithFilters(title, author);

            return Ok (books.Select(x => x.ToDtoModels()));
        }
        /// <summary>
        /// Return Books by given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetbyId(int id)
        {
            var book = _booksService.GetById(id);

            return Ok(book.ToDtoModels());
        }
        /// <summary>
        /// Create new books by given data.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(BookDto book)

        {
            if (ModelState.IsValid)
            {
                var status = _booksService.Create(book.ToDomainModel());
                if (status)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("", "Book with the same title alredy exist.");
                }
            }
                return BadRequest(ModelState);
            
        }
        /// <summary>
        /// Delete book by given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}") ]
        public IActionResult Delete(int id)
        {
            _booksService.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Check if exist,then update book by given data.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <response code="200">No data</response>
        /// <response code="400">If request data is invalid</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(BookDto book )
        {
            if (ModelState.IsValid)
            {
                _booksService.Update(book.ToDomainModel());
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }


    }
}
