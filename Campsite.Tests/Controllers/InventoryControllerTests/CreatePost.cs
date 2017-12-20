using System.Linq;
using System.Web.Mvc;
using Campsite.Models.Inventory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Campsite.Tests.Controllers.InventoryControllerTests
{
    [TestClass]
    public class CreatePost : InventoryControllerTestsBase
    {
        private InventoryCreate _model;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            InventoryService.CreateInventoryReturnValue = true;
            _model = new InventoryCreate();
        }

        private ActionResult Act()
        {
            return Controller.Create(_model);
        }

        [TestMethod]
        public void ShouldReturnRedirectToRouteResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldCallCreateInventory()
        {
            Act();

            Assert.AreEqual(1, InventoryService.CreateInventoryCallCount);
        }

        [TestMethod]
        public void ShouldSetSaveResult()
        {
            Act();

            Assert.AreEqual("Item data created.", Controller.TempData["SaveResult"]);
        }

        [TestMethod]
        public void ShouldRedirectToIndex()
        {
            var result = (RedirectToRouteResult)Act();

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void ShouldReturnViewResultWithOriginalModel_GivenInvalidModelState()
        {
            Controller.ModelState.AddModelError("", "test error");

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(_model, ((ViewResult)result).Model);
        }

        [TestMethod]
        public void ShouldSetErrorMessage_GivenCreateInventoryFails()
        {
            InventoryService.CreateInventoryReturnValue = false;

            Act();

            Assert.IsTrue(Controller.ModelState.Values.Any(v => v.Errors.Any(e => e.ErrorMessage == "Item could not be created")));
        }

        [TestMethod]
        public void ShouldReturnViewResultWithOriginalModel_GivenCreateInventoryFails()
        {
            InventoryService.CreateInventoryReturnValue = false;

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(_model, ((ViewResult)result).Model);
        }
    }
}
