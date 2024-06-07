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
    /// Descripción: Implementación de la interface del servicio de producto.
    /// </summary>
    public class ServicioProducto : IServicioProducto
    {
        private readonly ILogger<ServicioProducto> _logger;

        private readonly IRepositorioProducto _repositorioProducto;

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="logger">Referencia a la clase encargada de los Logs del sistema.</param>
        /// <param name="repositorioProducto"> Referencia al repositorio de productos. </param>
        public ServicioProducto(ILogger<ServicioProducto> logger, IRepositorioProducto repositorioProducto)
        {
            _logger = logger;
            _repositorioProducto = repositorioProducto;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Agrega un producto al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del producto que se desea agregar.</param>
        /// <returns>El producto agregado.</returns>
        public async Task<MRespuesta<MProducto>> AgregarProducto(SAgregarProducto solicitud)
        {
            var respuesta = new MRespuesta<MProducto>();

            try
            {
                var producto = await _repositorioProducto.AgregarProducto(solicitud);

                if (producto.Codigo == "")
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Incorrect;
                    respuesta.Mensaje = Constantes.ERROR_PRODUCTO_YA_EXISTE;

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = producto;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Constantes.ERROR_INTERNO_SERVIDOR);

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = Constantes.ERROR_INTERNO_SERVIDOR;
            }

            return respuesta;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Lista los productos del sistema.
        /// </summary>
        /// <returns>Arreglo con los productos del sistema.</returns>
        public async Task<MRespuesta<IEnumerable<MProducto>>> ListarProductos()
        {
            var respuesta = new MRespuesta<IEnumerable<MProducto>>();

            try
            {
                var productos = await _repositorioProducto.ListarProductos();

                if (productos == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.NotFound;
                    respuesta.Mensaje = Constantes.ERROR_LISTAR_PRODUCTOS;

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = productos;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Constantes.ERROR_INTERNO_SERVIDOR);

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = Constantes.ERROR_INTERNO_SERVIDOR;
            }

            return respuesta;
        }


        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Actualiza un producto del sistema.
        /// </summary>
        /// <param name="solicitud">Informacion del producto para actualizarlo.</param>
        /// <returns>Booleano que indica si la acción de actualizar fue exitosa o no.</returns>
        public async Task<MRespuesta<bool>> ActualizarProducto(SActualizarProducto solicitud)
        {
            var respuesta = new MRespuesta<bool>();

            try
            {
                var productoActualizado = await _repositorioProducto.ActualizarProducto(solicitud);

                if(!productoActualizado)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.NotFound;
                    respuesta.Mensaje = Constantes.ERROR_MODIFICANDO_PRODUCTO_NO_EXISTE;
                    respuesta.Dato = false;

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Constantes.ERROR_INTERNO_SERVIDOR);

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = Constantes.ERROR_INTERNO_SERVIDOR;
            }

            return respuesta;

        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Borra un producto del sistema.
        /// </summary>
        /// <param name="id">Id del producto que se desea borrar.</param>
        /// <returns>El producto borrado.</returns>
        public async Task<MRespuesta<MProducto>> BorrarProducto(int id)
        {
            var respuesta = new MRespuesta<MProducto>();

            try
            {
                var producto = await _repositorioProducto.BorrarProducto(id);

                if (producto == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.NotFound;
                    respuesta.Mensaje = Constantes.ERROR_BORRANDO_PRODUCTO_NO_EXISTE;

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = producto;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Constantes.ERROR_INTERNO_SERVIDOR);

                respuesta.EstadoRespuesta = EEstadoRespuesta.Error;
                respuesta.Mensaje = Constantes.ERROR_INTERNO_SERVIDOR;
            }

            return respuesta;
        }
        
    }
}
