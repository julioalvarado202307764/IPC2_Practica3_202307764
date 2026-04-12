using System.Net.Http.Json;
using Practica3_Razor.Models;

namespace Practica3_Razor.Services
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;

        // Se inyecta el HttpClient configurado
        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Obtener todos
        public async Task<List<Producto>> GetProductosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Producto>>("api/productos") ?? new List<Producto>();
        }

        // GET: Obtener por Id
        public async Task<Producto?> GetProductoAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Producto>($"api/productos/{id}");
        }

        // POST: Crear
        public async Task CrearProductoAsync(Producto producto)
        {
            await _httpClient.PostAsJsonAsync("api/productos", producto);
        }

        // PUT: Actualizar
        public async Task ActualizarProductoAsync(int id, Producto producto)
        {
            await _httpClient.PutAsJsonAsync($"api/productos/{id}", producto);
        }

        // DELETE: Eliminar
        public async Task EliminarProductoAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/productos/{id}");
        }
    }
}