﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Item
{
    public class ItemListItem
    {
        public int ItemId { get; set; }
        public int InventoryId { get; set; }
        public int? TransactionId { get; set; }
    }
}
