using BookStore.Data.Interfaces;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Book GetByTitle(string title)
        {
            return _bookStoreDbContext.Books.FirstOrDefault(x => x.Title.ToLower() == title.ToLower());
        }

        public void Update(Book book)
        {
            _bookStoreDbContext.Books.Update(book);
            _bookStoreDbContext.SaveChanges();
        }
    }
}
