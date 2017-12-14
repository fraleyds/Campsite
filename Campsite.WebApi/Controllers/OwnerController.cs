using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Campsite.Services;
using Microsoft.AspNet.Identity;

namespace Campsite.WebApi.Controllers
{
    [Authorize]
    public class OwnerController : ApiController
    {
        // GET /api/owner
        public IHttpActionResult Get()
        {
            OwnerService ownerService = CreateOwnerService();

            var owners = ownerService.GetOwners();

            return Ok(owners);
        }

        private OwnerService CreateOwnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ownerService = new OwnerService(userId);
            return ownerService;
        }
    }
}
