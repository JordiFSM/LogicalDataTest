namespace LogicalData.Domain.Modelos.ModelosEntidades
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripcion: Modelo que define los atributos de la posible autenticacion.
    /// </summary>
    public class MAutenticacion
    {
        public string Token { get; set; } = string.Empty;

        public MUsuario? Usuario { get; set; }
    }
}
