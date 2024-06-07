using LogicalData.Domain.Interfaces.Repositorios;
using LogicalData.Domain.Interfaces.Servicios;
using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;
using LogicalData.Domain.Utilidades.Constantes;
using LogicalData.Domain.Utilidades.Enumerados;
using Microsoft.Extensions.Logging;

namespace LogicalData.Infraestructure.Servicios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 5/6/2024
    /// Descripción: Implementación de la interface del servicio de usuarios.
    /// </summary>
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly IServicioJWT _servicioJWT;

        private readonly ILogger<ServicioUsuario> _logger;
        
        private readonly IRepositorioUsuario _repositorioUsuario;

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="logger">Referencia a la clase encargada de los Logs del sistema.</param>
        /// <param name="repositorioUsuario"> Referencia al repositorio de usuarios. </param>
        /// <param name="servicioJWT">Referencia al servicio encargado de generar el JWT.</param>
        public ServicioUsuario(ILogger<ServicioUsuario> logger, IRepositorioUsuario repositorioUsuario, IServicioJWT servicioJWT)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
            _servicioJWT = servicioJWT;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Agrega un usuario al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del usuario que se desea agregar</param>
        /// <returns>El usuario agregado.</returns>
        public async Task<MRespuesta<MUsuario>> AgregarUsuario(SAgregarUsuario solicitud)
        {
            var respuesta = new MRespuesta<MUsuario>();

            try
            {
                var usuario = await _repositorioUsuario.AgregarUsuario(solicitud);

                if (usuario != null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                    respuesta.Dato = usuario;
                }
                else
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Incorrect;
                    respuesta.Mensaje = Constantes.ERROR_NOMBRE_CONTRASENIA_USUARIO;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _logger.LogError(ex, Constantes.ERROR_AGREGANDO_USUARIO);
                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = Constantes.ERROR_AGREGANDO_USUARIO;
            }

            return respuesta;
        }


        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Autentica un usuario.
        /// </summary>
        /// <param name="solicitud">Solicitud con las credenciales del usuario.</param>
        /// <returns>Retorna un token de autenticación y el usuario.</returns>
        public async Task<MRespuesta<MAutenticacion>> AutenticarUsuario(SIniciarSesion solicitud)
        {
            var respuesta = new MRespuesta<MAutenticacion>();

            try
            {
                var usuarioAutenticado = await _repositorioUsuario.AutenticarUsuario(solicitud);

                if(usuarioAutenticado != null)
                {
                    var token = _servicioJWT.CrearJWT(solicitud.Username);
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                    respuesta.Dato = new MAutenticacion { Token = token, Usuario = usuarioAutenticado};
                }
                else
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Incorrect;
                    respuesta.Mensaje = Constantes.ERROR_NOMBRE_CONTRASENIA_USUARIO;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Constantes.ERROR_AUTENTICANDO_USUARIO);
                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = Constantes.ERROR_AUTENTICANDO_USUARIO;
            }

            return respuesta;
        }
    }
}
