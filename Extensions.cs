using FirstApi.Dtos;
using FirstApi.Entities;

namespace FirstApi
{
    public static class ItemExtensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedAt = item.CreatedAt
            };
        }
    }
}