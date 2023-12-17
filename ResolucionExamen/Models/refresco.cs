using ResolucionExamen.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ResolucionExamen.Models
{
    public class refresco
    {
        [Key]
        public int idRefresco { get; set; }
        [Required]
        public string? Marca { get; set; }
        [Required]
        public string? Producto { get; set; }
        [Required]
        public int Cantidad { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        [Required]
        public decimal Precio{ get; set; }
       
        [Required]
        public DisponibilidadEnum Disponibilidad { get; set; }
    }
}
