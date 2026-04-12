using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica3_Razor.Models;
using Practica3_Razor.Services;

namespace Practica3_Razor.Pages
{
    public class EditarModel : PageModel
    {
        private readonly ProductoService _productoService;

        public EditarModel(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [BindProperty]
        public Producto ProductoEditar { get; set; } = new Producto();

        // OnGetAsync recibe el ID que mandamos desde el botón amarillo de la tabla
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var producto = await _productoService.GetProductoAsync(id);
            
            if (producto == null)
            {
                // Si alguien intenta editar un ID que no existe, lo pateamos al Index
                return RedirectToPage("/Index"); 
            }

            // Llenamos la propiedad para que el HTML la pinte en pantalla
            ProductoEditar = producto;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Llamamos a la API para hacer el PUT
            await _productoService.ActualizarProductoAsync(ProductoEditar.Id, ProductoEditar);

            return RedirectToPage("/Index");
        }
    }
}