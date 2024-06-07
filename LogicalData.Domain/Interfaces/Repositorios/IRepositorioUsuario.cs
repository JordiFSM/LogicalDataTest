using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;

namespace LogicalData.Domain.Interfaces.Repositorios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Interface del repositorio de usuario.
    /// </summary>
    public interface IRepositorioUsuario
    {
        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Autentica un usuario.
        /// </summary>
        /// <param name="solicitud">Solicitud con las credenciales del usuario.</param>
        /// <returns>El usuario autenticado.</returns>
        public Task<MUsuario> AutenticarUsuario(SIniciarSesion solicitud);

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Agrega un usuario al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del usuario que se desea agregar.</param>
        /// <returns>El usuario agregado.</returns>
        public Task<MUsuario> AgregarUsuario(SAgregarUsuario solicitud);
    }
}
