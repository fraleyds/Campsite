using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Campsite.Contracts;
using Campsite.Data;
using Campsite.Models.Inventory;
using Campsite.Services;
using Microsoft.AspNet.Identity;

namespace Campsite.Web.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        //private InventoryService _inventoryService;

        //public InventoryController()
        //{
        //    _inventoryService = new InventoryService(Guid.Parse(User.Identity.GetUserId()));
        //}

        //public InventoryController(InventoryService inventoryService)
        //{
        //    _inventoryService = inventoryService;
        //}

        private InventoryService CreateInventoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InventoryService(userId);
            return service;
        }

        // GET: Inventories
        public ActionResult Index()
        {
            var model = CreateInventoryService().GetInventories();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new InventoryCreate();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateInventoryService().CreateInventory(model))
            {
                TempData["SaveResult"] = "Item data created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Item could not be created");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = CreateInventoryService().GetInventoryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = CreateInventoryService().GetInventoryById(id);
            var model =
                new InventoryEdit
                {
                    Type = detail.Type,
                    Description = detail.Description,
                    Condition = detail.Condition,
                    Price = detail.Price,
                    IsAvailable = detail.IsAvailable
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InventoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InventoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (CreateInventoryService().UpdateInventory(model))
            {
                TempData["SaveResult"] = "Inventory updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Inventory couldn't be updated");
            return View(model);
        }

        public ActionResult ItemRequest(int id)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var service = CreateInventoryService();

                var detail = service.GetInventoryById(id);

                var formspree = service.GetFormspree(id);

                var model =
                    new InventoryEdit
                    {
                        FormSpree = formspree,
                        Type = detail.Type,
                        Description = detail.Description,
                        Condition = detail.Condition,
                        Price = detail.Price,
                        IsAvailable = detail.IsAvailable
                    };

                return View(model);
            }
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = CreateInventoryService().GetInventoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInventory(int id)
        {
            CreateInventoryService().DeleteInventory(id);

            TempData["SaveResult"] = "Inventory deleted";

            return RedirectToAction("Index");
        }
    }
}