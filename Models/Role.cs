using System.ComponentModel.DataAnnotations;

namespace ApiVendaFacil.Models
{
    public class Role
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Status { get; set; }
    }
}