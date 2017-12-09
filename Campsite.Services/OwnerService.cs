using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Models.Owner;

namespace Campsite.Services
{
    public class OwnerService : IOwnerService
    {
        public bool CreateOwner(OwnerCreate model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OwnerListItem> GetOwners()
        {
            throw new NotImplementedException();
        }

        public OwnerDetail GetOwnerById(int ownerId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOwner(OwnerEdit model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOwner(int ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
