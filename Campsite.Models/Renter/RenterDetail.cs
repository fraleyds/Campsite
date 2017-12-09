using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Renter
{
    public class RenterDetail
    {
        public int RenterId { get; set; }
        public string Contact { get; set; }
        public int RenterRating { get; set; }
        public bool IsRenting { get; set; }
    }
}
