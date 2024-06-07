namespace LogicalData.Domain.Modelos.ModelosEntidades
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripcion: Modelo que define los atributos de un usuario.
    /// </summary>
    public class MUsuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Contrasenia { get; set; } = string.Empty;        
    }
}
