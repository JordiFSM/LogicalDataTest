using LogicalData.Domain.Interfaces.Servicios;
using LogicalData.Domain.Modelos.ModelosSolicitudes;
using LogicalData.Domain.Utilidades.Enumerados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace API.Controllers
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 5/6/2024
    /// Descripción: Controlador encargado de gestionar las ordenes en el sistema.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IServicioOrden _servicioOrden;
        private readonly IServicioJWT _serviciojwt;

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="servicioOrden">Servicio de ordenes.</param>
        public OrdenController(IServicioOrden servicioOrden, IServicioJWT servicioJwt)
        {
            _servicioOrden = servicioOrden;
            _serviciojwt = servicioJwt;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Agregar una orden.
        /// </summary>
        /// <param name="solicitud">Los datos de la orden a agregar.</param>
        /// <returns>El objeto orden agregado.</returns>
        [HttpPost]
        [Route("AgregarOrden")]
        public async Task<IActionResult> AgregarOrden([FromBody] SAgregarOrden solicitud)
        {
            var response = await _servicioOrden.AgregarOrden(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {

                return Ok(response);
            }

            return BadRequest("Hubo un problema al procesar la orden.");
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Lista las ordenes.
        /// </summary>
        /// <returns>Arreglo de ordenes</returns>
        [HttpGet]
        [Route("ListarOrdenes")]       
        public async Task<IActionResult> ListarOrdenes()
        {            

            var response = await _servicioOrden.ListarOrdenes();

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {

                return Ok(response);
            }

            return BadRequest();
        }
    }
}
