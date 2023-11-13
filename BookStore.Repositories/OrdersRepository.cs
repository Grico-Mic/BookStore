using BookStore.Data.Interfaces;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public OrdersRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }
        public void Create(Order order)
        {
            _bookStoreDbContext.Orders.Add(order);
            _bookStoreDbContext.SaveChanges();

        }
    }
}
