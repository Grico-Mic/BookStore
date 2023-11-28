using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Interfaces
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
        void Create(Book book);
        Book GetById(int id);
        void Delete(Book book);
        void Update(Book book);
        List<Book> GetWithFilters(string title, string author);
        Task<Book> GetByTitleAsync(string title);
    }
}
