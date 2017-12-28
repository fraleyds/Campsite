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
        private readonly Lazy<IInventoryService> _inventoryService;
        private IInventoryService InventoryService => _inventoryService.Value;

        public InventoryController()
        {
            _inventoryService = new Lazy<IInventoryService>(() => new InventoryService(Guid.Parse(User.Identity.GetUserId())));
        }

        public InventoryController(Lazy<IInventoryService> inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: Inventories
        public ActionResult Index()
        {
            var model = InventoryService.GetInventories();

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

            if (InventoryService.CreateInventory(model))
            {
                TempData["SaveResult"] = "Item data created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Item could not be created");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = InventoryService.GetInventoryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = InventoryService.GetInventoryById(id);
            var model =
                new InventoryEdit
                {
                    InventoryId = detail.InventoryId,
                    UserId = detail.UserId,
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

            if (InventoryService.UpdateInventory(model))
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
                var detail = InventoryService.GetInventoryById(id);

                var formspree = InventoryService.GetFormspree(id);

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
            var model = InventoryService.GetInventoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInventory(int id)
        {
            InventoryService.DeleteInventory(id);

            TempData["SaveResult"] = "Inventory deleted";

            return RedirectToAction("Index");
        }
    }
}