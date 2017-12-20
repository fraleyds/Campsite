using System;
using Campsite.Contracts;
using Campsite.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Campsite.Tests.Controllers.InventoryControllerTests
{
    /// <summary>
    /// Summary description for InventoryControllerTestsBase
    /// </summary>
    [TestClass]
    public abstract class InventoryControllerTestsBase
    {
        protected InventoryController Controller;
        protected FakeInventoryService InventoryService;

        [TestInitialize]
        public virtual void Arrange()
        {
            InventoryService = new FakeInventoryService();

            Controller = new InventoryController(
                new Lazy<IInventoryService>(() => InventoryService));
        }
    }
}
