using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Inventory
{
    public class InventoryEdit
    {
        public int InventoryId { get; set; }
        public Guid UserId { get; set; }
        public string FormSpree { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Available?")]
        public bool IsAvailable { get; set; }
    }
}
