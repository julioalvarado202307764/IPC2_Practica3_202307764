using System.Text.Json;
using Practica3_API.Models;

namespace Practica3_API.Services
{
    public class InventarioService
    {
        // Ruta dinámica hacia tu carpeta Data
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "inventario.json");

        // Método para LEER el JSON
        public List<Producto> GetProductos()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Producto>(); // Si no existe, devolvemos una lista vacía
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();
        }

        // Método para GUARDAR en el JSON
        public void SaveProductos(List<Producto> productos)
        {
            // WriteIndented = true hace que el JSON se guarde con saltos de línea y se vea bonito, no en una sola línea
            var options = new JsonSerializerOptions {
                WriteIndented = true,
                //entender español
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping};
            var json = JsonSerializer.Serialize(productos, options);
            
            File.WriteAllText(_filePath, json);
        }
    }
}