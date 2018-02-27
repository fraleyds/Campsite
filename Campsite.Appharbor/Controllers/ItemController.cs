using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Campsite.Data;
using Campsite.Models.Inventory;
using Campsite.Models.Item;
using Campsite.Services;
using Microsoft.AspNet.Identity;

namespace Campsite.Appharbor.Controllers
{
    public class ItemController : ApiController
    {
        // GET /api/item
        public IHttpActionResult GetAll(int inventoryId)
        {
            var service = CreateItemService(inventoryId);

            var items = service.GetItems();

            return Ok(items);
        }

        // GET /api/item/5
        public IHttpActionResult Get(int id, int inventoryId)
        {
            var service = CreateItemService(inventoryId);

            var item = service.GetItemById(id);

            return Ok(item);
        }

        // POST /api/item
        public IHttpActionResult Post(ItemCreate item, int inventoryId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateItemService(inventoryId);

            if (!service.CreateItem(item))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ItemEdit item, int inventoryId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateItemService(inventoryId);

            if (!service.UpdateItem(item))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id, int inventoryId)
        {
            var service = CreateItemService(inventoryId);

            if (!service.DeleteItem(id))
                return InternalServerError();

            return Ok();
        }

        private ItemService CreateItemService(int inventoryId)
        {
            var itemService = new ItemService(inventoryId);
            return itemService;
        }
    }
}
