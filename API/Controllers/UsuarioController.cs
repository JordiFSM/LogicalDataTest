using LogicalData.Domain.Interfaces.Servicios;
using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;
using LogicalData.Domain.Utilidades.Enumerados;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 5/6/2024
    /// Descripción: Controlador encargado de gestionar los usuarios en el sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicioUsuario _servicioUsuario;

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="servicioUsuario">Servicio de usuarios.</param>
        public UsuarioController(IServicioUsuario servicioUsuario, IConfiguration configuration)
        {
            _servicioUsuario = servicioUsuario;
            _configuration = configuration;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Autentica un usuario.
        /// </summary>
        /// <param name="solicitud">Los datos del a autenticar.</param>
        /// <returns>El usuario y un token JWT.</returns>
        [HttpPost]
        [Route("AutenticarUsuario")]
        public async Task<IActionResult> AutenticarUsuario([FromBody] SIniciarSesion solicitud)
        {
            
            var response = await _servicioUsuario.AutenticarUsuario(solicitud);
            
            if(response.EstadoRespuesta.Equals(EEstadoRespuesta.Success)) 
            {

                return Ok(response);
            }
            
            return Unauthorized(response);
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Agrega un usuario.
        /// </summary>
        /// <param name="solicitud">Los datos del usuario que se desea agregar.</param>
        /// <returns>El usuario agregado.</returns>
        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<IActionResult> AgregarUsuario([FromBody] SAgregarUsuario solicitud)
        {
            var response = await _servicioUsuario.AgregarUsuario(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuesta.Success))
            {

                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
