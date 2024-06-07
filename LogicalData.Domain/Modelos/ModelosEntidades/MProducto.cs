namespace LogicalData.Domain.Modelos.ModelosEntidades
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripcion: Modelo que define los atributos de un producto.
    /// </summary>
    public class MProducto
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public double Precio { get; set; }

        public bool IVA { get; set; }
    }
}
