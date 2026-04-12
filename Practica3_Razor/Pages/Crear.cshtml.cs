using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica3_Razor.Models;
using Practica3_Razor.Services;

namespace Practica3_Razor.Pages
{
    public class CrearModel : PageModel
    {
        private readonly ProductoService _productoService;

        public CrearModel(ProductoService productoService)
        {
            _productoService = productoService;
        }

        // El [BindProperty] enlaza el formulario HTML directamente con este objeto
        [BindProperty]
        public Producto NuevoProducto { get; set; } = new Producto();

        public void OnGet()
        {
            // Este método solo carga la página vacía cuando el usuario entra por primera vez
        }

        // Este método se ejecuta cuando el usuario le da clic al botón "Guardar"
        public async Task<IActionResult> OnPostAsync()
        {
            // ¿Recuerdas los Data Annotations que pusimos? Aquí verificamos si pasaron la prueba
            if (!ModelState.IsValid)
            {
                return Page(); // Si hay un error (ej. precio negativo), recarga la página mostrando los errores
            }

            // Si todo está bien, llamamos a la API para guardarlo
            await _productoService.CrearProductoAsync(NuevoProducto);

            // Redirigimos al usuario a la tabla principal
            return RedirectToPage("/Index");
        }
    }
}