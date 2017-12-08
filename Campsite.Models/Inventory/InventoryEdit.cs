﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Inventory
{
    public class InventoryEdit
    {
        public int InventoryId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
