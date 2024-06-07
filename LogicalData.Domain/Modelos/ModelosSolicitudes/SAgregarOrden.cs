namespace LogicalData.Domain.Modelos.ModelosSolicitudes
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Clase que almacena la forma de solicitud de agregar una orden.
    /// </summary>
    public class SAgregarOrden
    {
        public SOrden? Orden { get; set; }

        public ICollection<SItem>? Items { get; set; }
    }
}
