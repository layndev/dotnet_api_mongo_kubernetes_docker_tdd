using System;
using System.Collections.Generic;
using System.Linq;
using FirstApi.Entities;

namespace FirstApi.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "MacBook air 2017", Price = 52000, CreatedAt = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Mouse Gamer XSTZ23G", Price = 1200, CreatedAt = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Mac Mini", Price = 102000, CreatedAt = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Monitor Dell XD2", Price = 32355, CreatedAt = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return this.items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(i => i.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(item => item.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(item => item.Id == id);

            items.RemoveAt(index);
        }
    }
}