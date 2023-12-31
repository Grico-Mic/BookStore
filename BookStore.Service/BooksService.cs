﻿using BookStore.Data.Interfaces;
using BookStore.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<bool> CreateAsync(Book book)
        {
            var dbBook = await _booksRepository.GetByTitleAsync(book.Title);

            if (dbBook == null)
            {
                _booksRepository.Create(book);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            var book = _booksRepository.GetById(id);

            if (book != null)
            {
                _booksRepository.Delete(book);
            }
            
        }

        public List<Book> GetAll()
        {
            return _booksRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _booksRepository.GetById(id);
        }

        public List<Book> GetWithFilters(string title, string author)
        {
            return _booksRepository.GetWithFilters(title, author);
        }

        public void Update(Book book)
        {
            var dbBook = _booksRepository.GetById(book.Id);

            if (dbBook != null)
            {
               
                dbBook.Title = book.Title;
                dbBook.Description = book.Description;
                dbBook.Author = book.Author;
                dbBook.Ganre = book.Ganre;
                dbBook.Price = book.Price;
                dbBook.Quantity = book.Quantity;

                _booksRepository.Update(dbBook);
            }
        }
    }
}
