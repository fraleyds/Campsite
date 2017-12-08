using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Renter
{
    public class RenterListItem
    {
        public int OwnerId { get; set; }
        public int RenterId { get; set; }
        public string Contact { get; set; }
        public int OwnerRating { get; set; }
        public int RenterRating { get; set; }
        public bool IsRenting { get; set; }
    }
}
