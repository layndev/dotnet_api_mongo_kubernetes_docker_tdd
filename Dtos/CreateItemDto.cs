using System.ComponentModel.DataAnnotations;

namespace FirstApi.Dtos
{
    public class CreateItemDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 1000000000000000000)]
        public decimal Price { get; init; }
    }
}