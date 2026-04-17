using System;
using System.ComponentModel.DataAnnotations; 

namespace Practica3_API.Models
{
    public class Producto
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public string Categoria { get; set; } = string.Empty;

        // descropcon opcional
        public string? Descripcion { get; set; } 

        [Range(0.01, 100000, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en stock no puede ser negativa.")]
        public int CantidadEnStock { get; set; }
        
        public DateTime? FechaVencimiento { get; set; } 
    }
}