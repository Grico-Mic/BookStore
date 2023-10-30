using BookStore.DtoModels;
using BookStore.Models;

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
    }
}
