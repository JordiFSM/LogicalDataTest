namespace LogicalData.Domain.Modelos.ModelosEntidades
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripcion: Modelo que define los atributos de una orden.
    /// </summary>
    public class MOrden
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public ICollection<MItem> Items { get; set; } = new List<MItem>();
    }
}
