using Microsoft.AspNetCore.Mvc;
using Practica3_API.Models;
using Practica3_API.Services;

namespace Practica3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly InventarioService _inventarioService;

        // Inyección de dependencias del servicio creado
        public ProductosController(InventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        // GET: api/productos
        [HttpGet]
        public ActionResult<List<Producto>> GetProductos()
        {
            var productos = _inventarioService.GetProductos();
            return Ok(productos); // Retorna 200 OK con la lista
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            var productos = _inventarioService.GetProductos();
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                return NotFound(new { mensaje = $"El producto con ID {id} no existe." }); // 404
            }

            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        public ActionResult<Producto> CrearProducto([FromBody] Producto nuevoProducto)
        {
            if (nuevoProducto.Id != 0)
            {
                return BadRequest(new { mensaje = "No debes incluir un Id al crear un producto. El sistema lo asignará automáticamente." });
            }
            var productos = _inventarioService.GetProductos();

            // Auto-incrementar el ID simulando una base de datos
            nuevoProducto.Id = productos.Count > 0 ? productos.Max(p => p.Id) + 1 : 1;

            productos.Add(nuevoProducto);
            _inventarioService.SaveProductos(productos);

            // Retorna 201 Created y la ruta para consultar el nuevo recurso
            return CreatedAtAction(nameof(GetProducto), new { id = nuevoProducto.Id }, nuevoProducto);
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, [FromBody] Producto productoActualizado)
        {
            var productos = _inventarioService.GetProductos();
            var index = productos.FindIndex(p => p.Id == id);

            if (index == -1)
            {
                return NotFound(new { mensaje = "Producto no encontrado." });
            }

            // Mantenemos el ID original para evitar que lo sobreescriban por error
            productoActualizado.Id = id;
            productos[index] = productoActualizado;

            _inventarioService.SaveProductos(productos);

            return NoContent(); // 204 No Content es el estándar para un PUT exitoso
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            var productos = _inventarioService.GetProductos();
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                return NotFound(new { mensaje = "Producto no encontrado." });
            }

            productos.Remove(producto);
            _inventarioService.SaveProductos(productos);

            return Ok(new { mensaje = "Producto eliminado correctamente." });
        }
    }
}