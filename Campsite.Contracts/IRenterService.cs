using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Models.Renter;

namespace Campsite.Contracts
{
    public interface IRenterService
    {
        bool CreateRenter(RenterCreate model);
        IEnumerable<RenterListItem> GetRenters();
        RenterDetail GetRenterById(int renterId);
        bool UpdateRenter(RenterEdit model);
        bool DeleteRenter(int renterId);
    }
}
