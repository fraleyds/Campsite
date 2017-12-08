using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Models.Transaction
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? FinalPrice { get; set; }
        public int RenterId { get; set; }
    }
}
