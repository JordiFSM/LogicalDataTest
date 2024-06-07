namespace LogicalData.Domain.Modelos.ModelosSolicitudes
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Clase que almacena la forma de solicitud de un item.
    /// </summary>
    public class SItem
    {
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
