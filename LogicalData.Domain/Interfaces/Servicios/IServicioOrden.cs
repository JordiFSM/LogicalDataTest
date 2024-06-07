using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;

namespace LogicalData.Domain.Interfaces.Servicios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Interface del servicio de ordenes.
    /// </summary>
    public interface IServicioOrden
    {
        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Agrega una orden al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma de la orden y sus items que se desea agregar.</param>
        /// <returns>La orden agregada.</returns>
        public Task<MRespuesta<MOrden>> AgregarOrden(SAgregarOrden solicitud);

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Lista las ordenes del sistema.
        /// </summary>
        /// <returns>Arreglo con las ordenes del sistema.</returns>
        public Task<MRespuesta<IEnumerable<MOrden>>> ListarOrdenes();
    }
}
