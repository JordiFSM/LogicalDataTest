namespace LogicalData.Domain.Modelos.ModelosSolicitudes
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Clase que almacena la forma de solicitud de agregar un producto.
    /// </summary>
    public class SAgregarProducto
    {
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public bool IVA { get; set; }
    }
}
