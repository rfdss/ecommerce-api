using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiVendaFacil.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Ref { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public string Image { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal CostPrice { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Range(0,1)]
        public int Status { get; set; }

        // public List<OrderItem> OrderItems { get; set; }
    }
}