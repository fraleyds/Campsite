using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Inventory
{
    public class InventoryCreate
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
