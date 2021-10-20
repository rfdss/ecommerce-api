using System.ComponentModel.DataAnnotations;

namespace ApiVendaFacil.Models
{
    public class InventoryItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long InventoryOrderId { get; set; }
        public InventoryOrder InventoryOrder { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}