using System;
using System.Collections.Generic;
using System.Linq;
using FirstApi.Dtos;
using FirstApi.Entities;
using FirstApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    // GET /items
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemsRepository repository;
        public ItemController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            return repository.GetItems().Select(item => item.AsDto());
        }
        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
                return NotFound();

            return item.AsDto();
        }
        // POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedAt = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }
        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult Updatetem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            var updateItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
            };

            repository.UpdateItem(updateItem);

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItem(id);

            return NoContent();
        }
    }
}