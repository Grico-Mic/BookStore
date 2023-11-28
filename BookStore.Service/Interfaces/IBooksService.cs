using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IBooksService
    {
        List<Book> GetAll();
        Task<bool> CreateAsync(Book book);
        void Delete(int id);
        void Update(Book book);
        Book GetById(int id);
        List<Book> GetWithFilters(string title, string author);
    }
}
