using System;
using System.Collections.Generic;
using FirstApi.Entities;

namespace FirstApi.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        public void CreateItem(Item item);
        public void UpdateItem(Item item);
        public void DeleteItem(Guid id);
    }
}