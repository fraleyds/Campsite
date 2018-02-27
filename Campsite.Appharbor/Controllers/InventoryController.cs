using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Campsite.Models.Inventory;
using Campsite.Services;
using Microsoft.AspNet.Identity;

namespace Campsite.Appharbor.Controllers
{
    [Authorize]
    public class InventoryController : ApiController
    {
        // GET /api/inventory
        public IHttpActionResult GetAll()
        {
            var service = CreateInventoryService();

            var inventories = service.GetInventories();

            return Ok(inventories);
        }

        // GET /api/inventory/5
        public IHttpActionResult Get(int id)
        {
            var service = CreateInventoryService();

            var inventory = service.GetInventoryById(id);

            return Ok(inventory);
        }

        // POST /api/inventory
        public IHttpActionResult Post(InventoryCreate inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInventoryService();

            if (!service.CreateInventory(inventory))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(InventoryEdit inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInventoryService();

            if (!service.UpdateInventory(inventory))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateInventoryService();

            if (!service.DeleteInventory(id))
                return InternalServerError();

            return Ok();
        }

        private InventoryService CreateInventoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var inventoryService = new InventoryService(userId);
            return inventoryService;
        }
    }
}
