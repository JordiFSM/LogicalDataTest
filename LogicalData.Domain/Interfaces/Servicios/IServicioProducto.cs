using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;

namespace LogicalData.Domain.Interfaces.Servicios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Interface del servicio de producto.
    /// </summary>
    public interface IServicioProducto
    {
        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Agrega un producto al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del producto que se desea agregar.</param>
        /// <returns>El producto agregado.</returns>
        public Task<MRespuesta<MProducto>> AgregarProducto(SAgregarProducto solicitud);

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Lista los productos del sistema.
        /// </summary>
        /// <returns>Arreglo con los productos del sistema.</returns>
        public Task<MRespuesta<IEnumerable<MProducto>>> ListarProductos();

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Actualiza un producto del sistema.
        /// </summary>
        /// <param name="solicitud">Informacion del producto para actualizarlo.</param>
        /// <returns>Booleano que indica si la acción de actualizar fue exitosa o no.</returns>
        public Task<MRespuesta<bool>> ActualizarProducto(SActualizarProducto solicitud);

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Borra un producto del sistema.
        /// </summary>
        /// <param name="id">Id del producto que se desea borrar.</param>
        /// <returns>El producto borrado.</returns>
        public Task<MRespuesta<MProducto>> BorrarProducto(int id);
    }
}
