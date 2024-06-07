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
    /// Descripción: Implementación de la interface del servicio de ordenes.
    /// </summary>
    public class ServicioOrden : IServicioOrden
    {
        private readonly ILogger<ServicioOrden> _logger;

        private readonly IRepositorioOrden _repositorioOrden;

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="logger">Referencia a la clase encargada de los Logs del sistema.</param>
        /// <param name="repositorioOrden"> Referencia al repositorio de ordenes. </param>
        public ServicioOrden(ILogger<ServicioOrden> logger, IRepositorioOrden repositorioOrden)
        {
            _logger = logger;
            _repositorioOrden = repositorioOrden;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Agrega una orden al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma de la orden y sus items que se desea agregar.</param>
        /// <returns>La orden agregada.</returns>
        public async Task<MRespuesta<MOrden>> AgregarOrden(SAgregarOrden solicitud)
        {
            var respuesta = new MRespuesta<MOrden>();

            try
            {
                var orden = await _repositorioOrden.AgregarOrden(solicitud);

                if(orden == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.Incorrect;
                    respuesta.Mensaje = Constantes.ERROR_AGREGANDO_ORDEN;

                    return respuesta;
                }
                
                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = orden;

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
        /// Descripción: Lista las ordenes del sistema.
        /// </summary>
        /// <returns>Arreglo con las ordenes del sistema.</returns>
        public async Task<MRespuesta<IEnumerable<MOrden>>> ListarOrdenes()
        {
            var respuesta = new MRespuesta<IEnumerable<MOrden>>();

            try
            {
                var ordenes = await _repositorioOrden.ListarOrdenes();

                if (ordenes == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuesta.NotFound;
                    respuesta.Mensaje = Constantes.ERROR_LISTAR_ORDENES;

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuesta.Success;
                respuesta.Dato = ordenes;

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
