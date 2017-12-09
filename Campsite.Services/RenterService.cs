using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Models.Renter;

namespace Campsite.Services
{
    public class RenterService : IRenterService
    {
        public bool CreateRenter(RenterCreate model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RenterListItem> GetRenters()
        {
            throw new NotImplementedException();
        }

        public RenterDetail GetRenterById(int renterId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRenter(RenterEdit model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRenter(int renterId)
        {
            throw new NotImplementedException();
        }
    }
}
