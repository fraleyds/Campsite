using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campsite.Data
{
    public class OwnerEntity
    {
        [Key]
        [Required]
        public int OwnerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Contact { get; set; }

        [Range(1, 5)]
        public int OwnerRating { get; set; }
    }

    public class RenterEntity
    {
        [Key]
        public int RenterId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Contact { get; set; }

        [Range(1, 5)]
        public int RenterRating { get; set; }

        [Required]
        public bool IsRenting { get; set; }
    }

    public class InventoryEntity
    {
        [Key]
        public int InventoryId { get; set; }

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

        // Owner foreign key
        [Required]
        public int OwnerId { get; set; }

        public OwnerEntity OwnerEntity { get; set; }
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
        [Required]
        public int TransactionId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal? FinalPrice { get; set; }

        // Foreign key to establish relationship with renter
        [Required]
        public int RenterId { get; set; }

        public RenterEntity RenterEntity { get; set; }
    }
}
