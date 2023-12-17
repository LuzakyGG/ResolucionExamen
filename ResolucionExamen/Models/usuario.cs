using ResolucionExamen.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ResolucionExamen.Models
{
    public class usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        [Required]
        public RolEnum Rol { get; set; }
    }
}
