using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ApiVendaFacil.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }
        public User User { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OrderItem> Items { get; set; }

        public decimal TotalValue { get; set; }

        // public int Discount { get; set; }

        // public decimal FinalValue { get; set; }

        public int Status { get; set; }
    }
}
