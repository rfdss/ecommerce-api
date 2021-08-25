using System.ComponentModel.DataAnnotations;

namespace ApiVendaFacil.Models
{
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}