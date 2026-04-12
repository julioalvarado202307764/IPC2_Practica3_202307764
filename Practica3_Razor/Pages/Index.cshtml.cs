using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica3_Razor.Models;
using Practica3_Razor.Services;

namespace Practica3_Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductoService _productoService;

        // Inyectamos nuestro puente hacia la API
        public IndexModel(ProductoService productoService)
        {
            _productoService = productoService;
        }

        // Esta lista guardará lo que nos responda la API
        public List<Producto> Productos { get; set; } = new List<Producto>();

        // Este método se ejecuta automáticamente cuando cargas la página
        public async Task OnGetAsync()
        {
            Productos = await _productoService.GetProductosAsync();
        }
    }
}