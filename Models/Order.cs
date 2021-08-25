using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public decimal Value { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }

        [Range(1,3)]
        public int Status { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
