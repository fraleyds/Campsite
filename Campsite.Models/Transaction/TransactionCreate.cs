using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Transaction
{
    public class TransactionCreate
    {
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? FinalPrice { get; set; }
        public int RenterId { get; set; }
    }
}
