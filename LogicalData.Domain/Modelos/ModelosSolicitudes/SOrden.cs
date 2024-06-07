namespace LogicalData.Domain.Modelos.ModelosSolicitudes
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Clase que almacena la forma de solicitud de una orden.
    /// </summary>
    public class SOrden
    {
        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }
    }
}
