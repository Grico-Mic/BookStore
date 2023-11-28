using BookStore.Data.Interfaces;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public BooksRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Create(Book book)
        {
            _bookStoreDbContext.Books.Add(book);
            _bookStoreDbContext.SaveChanges();
        }

        public void Delete(Book book)
        {
             _bookStoreDbContext.Books.Remove(book);
            _bookStoreDbContext.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return _bookStoreDbContext.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _bookStoreDbContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Book> GetByTitleAsync(string title)
        {
            return await _bookStoreDbContext.Books.FirstOrDefaultAsync(x => x.Title.ToLower() == title.ToLower());
        }

        public List<Book> GetWithFilters(string title, string author)
        {
            {
                var books = _bookStoreDbContext.Books.AsQueryable();

                if (title != null)
                {
                    books = books.Where(x => x.Title.ToLower().Contains(title.ToLower()));
                }

                if (author != null)
                {
                    books = books.Where(x => x.Author.ToLower().Contains(author.ToLower()));
                }

                return books.ToList();
            }
        }

        public void Update(Book book)
        {
            _bookStoreDbContext.Books.Update(book);
            _bookStoreDbContext.SaveChanges();
        }
    }
}
