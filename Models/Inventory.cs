using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiVendaFacil.Models
{
    public class InventoryOrder
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public int Type { get; set; }

        public List<InventoryItem> Items { get; set; }

        [Required]
        public int Status { get; set; }
    }
}