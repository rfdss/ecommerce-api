using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiVendaFacil.Models
{
    public class Category
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int Status { get; set; }

        // public List<Product> Products { get; set; }
    }
}