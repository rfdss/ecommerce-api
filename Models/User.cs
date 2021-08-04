using System.Text.Json.Serialization;
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
        [MinLength(8)]
        [MaxLength(18)]
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        [JsonIgnore]
        public long RoleId { get; set; }
        public Role Role { get; set; }

        public int Status { get; set; }
    }
}