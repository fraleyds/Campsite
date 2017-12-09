using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Item
{
    public class ItemCreate
    {
        [Required]
        public int InventoryId { get; set; }
        public int? TransactionId { get; set; }
    }
}
