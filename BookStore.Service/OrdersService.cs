using BookStore.Data.Interfaces;
using BookStore.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public void Create(Order order)
        {
            order.DateCreated = DateTime.Now;
            _ordersRepository.Create(order);
        }
    }
}
