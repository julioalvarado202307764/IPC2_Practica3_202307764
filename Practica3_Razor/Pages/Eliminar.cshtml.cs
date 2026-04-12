using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica3_Razor.Models;
using Practica3_Razor.Services;

namespace Practica3_Razor.Pages
{
    public class EliminarModel : PageModel
    {
        private readonly ProductoService _productoService;

        public EliminarModel(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [BindProperty]
        public Producto ProductoEliminar { get; set; } = new Producto();

        // Traemos el producto para mostrarlo en la pantalla de confirmación
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var producto = await _productoService.GetProductoAsync(id);

            if (producto == null)
            {
                return RedirectToPage("/Index");
            }

            ProductoEliminar = producto;
            return Page();
        }

        // Se ejecuta cuando el usuario le da clic al botón rojo de confirmación
        public async Task<IActionResult> OnPostAsync()
        {
            // Llamamos a la API para hacer el DELETE
            await _productoService.EliminarProductoAsync(ProductoEliminar.Id);

            return RedirectToPage("/Index");
        }
    }
}