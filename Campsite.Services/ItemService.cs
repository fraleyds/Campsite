using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Data;
using Campsite.Models.Item;

namespace Campsite.Services
{
    public class ItemService : IItemService
    {
        private readonly int _inventoryId;

        public ItemService(int inventoryId)
        {
            _inventoryId = inventoryId;
        }

        private readonly int? _transactionId;

        public ItemService(int transactionId, int inventoryId)
        {
            _transactionId = transactionId;
            _inventoryId = inventoryId;
        }

        public bool CreateItem(ItemCreate model)
        {
            ItemEntity entity;

            if (_transactionId == null)
            {
                entity =
                    new ItemEntity()
                    {
                        InventoryId = _inventoryId,
                    };
            }
            else
            {
                entity =
                    new ItemEntity()
                    {
                        InventoryId = _inventoryId,
                        TransactionId = _transactionId
                    };
            }

            using (var ctx = new CampsiteDbContext())
            {
                ctx.Item.Add(entity);
                return ctx.SaveChanges() == 1;
            }
            
        }

        public IEnumerable<ItemListItem> GetItems()
        {
            using (var ctx = new CampsiteDbContext())
            {
                var query =
                    ctx
                        .Item
                        .Where(e => e.InventoryId == _inventoryId)
                        .Select(
                            e =>
                                new ItemListItem
                                {
                                    ItemId = e.ItemId,
                                    InventoryId = e.InventoryId,
                                    TransactionId = e.TransactionId
                                }
                        );
                return query.ToArray();
            }
        }

        public ItemDetail GetItemById(int itemId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Item
                        .Single(e => e.ItemId == itemId && e.InventoryId == _inventoryId);

                return
                    new ItemDetail
                    {
                        ItemId = entity.ItemId,
                        InventoryId = entity.InventoryId,
                        TransactionId = entity.TransactionId
                    };
            }
        }

        public bool UpdateItem(ItemEdit model)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Item
                        .Single(e => e.ItemId == model.ItemId && e.InventoryId == _inventoryId);

                entity.TransactionId = model.TransactionId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteItem(int itemId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Item
                        .Single(e => e.ItemId == itemId && e.InventoryId == _inventoryId);

                ctx.Item.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
