using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Models.Item;

namespace Campsite.Contracts
{
    public interface IItemService
    {
        bool CreateItem(ItemCreate model);
        IEnumerable<ItemListItem> GetItems();
        ItemDetail GetItemById(int itemId);
        bool UpdateItem(ItemEdit model);
        bool DeleteItem(int itemId);
    }
}
