using LogicalData.Domain.Utilidades.Enumerados;

namespace LogicalData.Domain.Modelos.ModelosEntidades
{
    /// <summary>
    /// Autor: Jordi Segura
    /// Fecha: 4/6/2024
    /// Descripcion: Define los datos de la respuesta a un request, desde el estado, el mensaje y el posible dato.
    /// </summary>
    /// <typeparam name="T">El tipo de dato de la respuesta.</typeparam>
    public class MRespuesta<T>
    {
        public EEstadoRespuesta EstadoRespuesta { get; set; }

        public string Mensaje { get; set; } = string.Empty;

        public T? Dato { get; set; }
    }
}
