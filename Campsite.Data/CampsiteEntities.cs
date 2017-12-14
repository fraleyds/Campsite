using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Data
{
    public class InventoryEntity
    {
        [Key]
        public int InventoryId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(500)]
        public string Condition { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }

    public class ItemEntity
    {
        [Key]
        [Required]
        public int ItemId { get; set; }

        // Foreign key to establish relationship with inventory
        public int InventoryId { get; set; }

        public InventoryEntity InventoryEntity { get; set; }

        // Foreign key for relationship with transaction
        public int? TransactionId { get; set; }

        public TransactionEntity TransactionEntity { get; set; }
    }

    public class TransactionEntity
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal? FinalPrice { get; set; }
    }
}
