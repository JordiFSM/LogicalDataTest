using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;

namespace LogicalData.Domain.Interfaces.Servicios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Interface del servicio de usuario.
    /// </summary>
    public interface IServicioUsuario
    {
        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Agrega un usuario al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del usuario que se desea agregar</param>
        /// <returns>El usuario agregado.</returns>
        public Task<MRespuesta<MUsuario>> AgregarUsuario(SAgregarUsuario solicitud);

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Autentica un usuario.
        /// </summary>
        /// <param name="solicitud">Solicitud con las credenciales del usuario.</param>
        /// <returns>Retorna un token de autenticación y el usuario.</returns>
        public Task<MRespuesta<MAutenticacion>> AutenticarUsuario(SIniciarSesion solicitud);

    }
}
