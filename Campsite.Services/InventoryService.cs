using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Data;
using Campsite.Models.Inventory;

namespace Campsite.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Guid _userId;

        public InventoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateInventory(InventoryCreate model)
        {
            var entity =
                new InventoryEntity()
                {
                    UserId = _userId,
                    Type = model.Type,
                    Description = model.Description,
                    Price = model.Price,
                    Condition = model.Condition,
                    IsAvailable = model.IsAvailable
                };
            using (var ctx = new CampsiteDbContext())
            {
                ctx.Inventory.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InventoryListItem> GetInventories()
        {
            using (var ctx = new CampsiteDbContext())
            {
                var query =
                    ctx
                        .Inventory
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new InventoryListItem
                                {
                                    InventoryId = e.InventoryId,
                                    Type = e.Type,
                                    Description = e.Description,
                                    Price = e.Price,
                                    Condition = e.Condition,
                                    IsAvailable = e.IsAvailable
                                }
                        );
                return query.ToArray();
            }
        }

        public InventoryDetail GetInventoryById(int inventoryId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Inventory
                        .Single(e => e.InventoryId == inventoryId && e.UserId == _userId);

                return
                    new InventoryDetail
                    {
                        InventoryId = entity.InventoryId,
                        Type = entity.Type,
                        Description = entity.Description,
                        Price = entity.Price,
                        Condition = entity.Condition,
                        IsAvailable = entity.IsAvailable
                    };
            }
        }

        public bool UpdateInventory(InventoryEdit model)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Inventory
                        .Single(e => e.InventoryId == model.InventoryId && e.UserId == _userId);

                entity.Type = model.Type;
                entity.Description = model.Description;
                entity.Price = model.Price;
                entity.Condition = model.Condition;
                entity.IsAvailable = model.IsAvailable;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInventory(int inventoryId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Inventory
                        .Single(e => e.InventoryId == inventoryId && e.UserId == _userId);

                ctx.Inventory.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
