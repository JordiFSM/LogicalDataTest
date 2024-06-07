using LogicalData.Domain.Interfaces.Servicios;
using LogicalData.Domain.Modelos.ModelosSolicitudes;
using LogicalData.Domain.Utilidades.Enumerados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 5/6/2024
    /// Descripción: Controlador encargado de gestionar los productos en el sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IServicioProducto _servicioProducto;

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="servicioProducto">Servicio de productos.</param>
        public ProductoController(IServicioProducto servicioProducto)
        {
            _servicioProducto = servicioProducto;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Agregar un producto.
        /// </summary>
        /// <param name="solicitud">Los datos del producto que se desea agregar.</param>
        /// <returns>El producto agregado.</returns>
        [HttpPost]
        [Route("AgregarProducto")]
        public async Task<IActionResult> AgregarProducto([FromBody] SAgregarProducto solicitud)
        {
            var response = await _servicioProducto.AgregarProducto(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Lista los productos.
        /// </summary>
        /// <returns>Arreglo de productos</returns>
        [HttpGet]
        [Route("ListarProductos")]
        public async Task<IActionResult> ListarProductos()
        {
            var response = await _servicioProducto.ListarProductos();

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {
                return Ok(response);
            }

            return BadRequest();
        }        

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Actualiza el producto con el código de producto indicado.
        /// </summary>
        /// <param name="solicitud">Los nuevos datos del producto a actualizar.</param>
        /// <returns>Booleano indicando si la acción fue exitosa o no</returns>
        [HttpPut]
        [Route("ActualizarProducto")]
        public async Task<IActionResult> ActualizarProducto([FromBody] SActualizarProducto solicitud)
        {
            var response = await _servicioProducto.ActualizarProducto(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Elimina un producto.
        /// </summary>
        /// <param name="id">El id del producto a eliminar.</param>
        /// <returns>Booleano indicando si la acción fue exitosa o no</returns>
        [HttpDelete]
        [Route("BorrarProducto")]
        public async Task<IActionResult> BorrarProducto([FromQuery] int id)
        {
            var response = await _servicioProducto.BorrarProducto(id);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {
                return Ok(response);
            }

            return NotFound(response);
        }
    }
}
