using System;

namespace Practica3_API.Models
{
    public class Producto
    {
        //id unico
        public int Id { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int CantidadEnStock { get; set; }
        
        // Nullable (?) porque el enunciado dice "si aplica"
        public DateTime? FechaVencimiento { get; set; } 
    }
}