using System.Collections.Generic;
// using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ApiVendaFacil.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(12)]
        // [JsonIgnore]
        public string Password { get; set; }

        [Required]
        [Range(1,3)]
        public int Type { get; set; }

        public int Status { get; set; }

        public List<Order> Orders { get; set; }
    }
}