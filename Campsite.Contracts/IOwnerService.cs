using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Models.Owner;

namespace Campsite.Contracts
{
    public interface IOwnerService
    {
        bool CreateOwner(OwnerCreate model);
        IEnumerable<OwnerListItem> GetOwners();
        OwnerDetail GetOwnerById(int ownerId);
        bool UpdateOwner(OwnerEdit model);
        bool DeleteOwner(int ownerId);
    }
}
