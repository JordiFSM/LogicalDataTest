using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;

namespace LogicalData.Domain.Interfaces.Repositorios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Interface del repositorio de producto.
    /// </summary>
    public interface IRepositorioProducto
    {
        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Agrega un producto al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del producto que se desea agregar.</param>
        /// <returns>El producto agregado.</returns>
        public Task<MProducto> AgregarProducto(SAgregarProducto solicitud);

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Lista los productos del sistema.
        /// </summary>
        /// <returns>Lista con los productos del sistema.</returns>
        public Task<IEnumerable<MProducto>> ListarProductos();

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Actualiza un producto del sistema.
        /// </summary>
        /// <param name="solicitud">Informacion del producto para actualizarlo.</param>
        /// <returns>Booleano que inidica si la acción de actualizar fue exitosa o no.</returns>
        public Task<bool> ActualizarProducto(SActualizarProducto solicitud);

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Borra un producto del sistema.
        /// </summary>
        /// <param name="id">Id del producto que se desea borrar.</param>
        /// <returns>El producto borrado.</returns>
        public Task<MProducto> BorrarProducto(int id);
    }
}
