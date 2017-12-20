using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Models.Inventory;

namespace Campsite.Contracts
{
    public interface IInventoryService
    {
        bool CreateInventory(InventoryCreate model);
        IEnumerable<InventoryListItem> GetInventories();
        InventoryDetail GetInventoryById(int invId);
        bool UpdateInventory(InventoryEdit model);
        bool DeleteInventory(int invId);
        string GetFormspree(int inventoryId);
    }
}
