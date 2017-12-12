using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Owner
{
    public class OwnerEdit
    {
        public int OwnerId { get; set; }
        public string Contact { get; set; }
        public int? OwnerRating { get; set; }
    }
}
