using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Models.Item;

namespace Campsite.Services
{
    public class ItemService : IItemService
    {
        public bool CreateItem(ItemCreate model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemListItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public ItemDetail GetItemById(int itemId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(ItemEdit model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
