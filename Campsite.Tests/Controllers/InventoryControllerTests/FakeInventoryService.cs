using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Models.Inventory;

namespace Campsite.Tests
{
    public class FakeInventoryService : IInventoryService
    {
        public int CreateInventoryCallCount { get; private set; }
        public bool CreateInventoryReturnValue { private get; set; }

        public bool CreateInventory(InventoryCreate model)
        {
            CreateInventoryCallCount++;

            return CreateInventoryReturnValue;
        }

        public IEnumerable<InventoryListItem> GetInventories()
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

        public string GetFormspree(int inventoryId)
        {
            throw new NotImplementedException();
        }
    }
}
