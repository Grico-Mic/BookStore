using BookStore.DtoModels;
using BookStore.Models;
using System.Linq;

namespace BookStore.Mappings
{
    public static class DtoMappings
    {
        public static BookDto ToDtoModels (this Book entity)
        {
            return new BookDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Author = entity.Author,
                Ganre = entity.Ganre,
                Price = entity.Price,
                Quantity = entity.Quantity
            };
        }

        public static Book ToDomainModel(this BookDto entity)
        {
            return new Book()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Author = entity.Author,
                Ganre = entity.Ganre,
                Price = entity.Price,
                Quantity = entity.Quantity
            };
        }

        public static Order ToDomainModel(this CreateOrderDto entity)
        {
            return new Order()
            {

                FullName = entity.FullName,
                Email = entity.Email,
                Address = entity.Address,
                Phone = entity.Phone,
                BookOrders = entity.BookIds.Select(x => new BookOrder() { BookId = x}).ToList()
              
               
            };
        }
    }
}
