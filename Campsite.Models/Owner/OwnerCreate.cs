using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Owner
{
    public class OwnerCreate
    {
        [Required]
        public string Contact { get; set; }
        public int OwnerRating { get; set; }
    }
}
