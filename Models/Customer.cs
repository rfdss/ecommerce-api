using System.ComponentModel.DataAnnotations;

namespace ApiVendaFacil.Models
{
    public class Customer
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(11)]
        public string Cpf { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int Status { get; set; }
    }
}