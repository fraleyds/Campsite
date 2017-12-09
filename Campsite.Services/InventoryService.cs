using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Models.Inventory;

namespace Campsite.Services
{
    public class InventoryService : IInventoryService
    {
        public bool CreateInventory(InventoryCreate model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryListItem> GetInventory()
        {
            throw new NotImplementedException();
        }

        public InventoryDetail GetInventoryById(int invId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteInventory(int invId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInventory(InventoryEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
