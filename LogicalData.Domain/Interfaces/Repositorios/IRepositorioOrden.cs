using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;

namespace LogicalData.Domain.Interfaces.Repositorios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Interface del repositorio de ordenes.
    /// </summary>
    public interface IRepositorioOrden
    {
        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Agrega una orden al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con forma de la orden que se desea agregar.</param>
        /// <returns>La orden agregada.</returns>
        public Task<MOrden> AgregarOrden(SAgregarOrden solicitud);

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Lista las ordenes del sistema.
        /// </summary>
        /// <returns>Lista con las ordenes del sistema.</returns>
        public Task<IEnumerable<MOrden>> ListarOrdenes();
    }
}
