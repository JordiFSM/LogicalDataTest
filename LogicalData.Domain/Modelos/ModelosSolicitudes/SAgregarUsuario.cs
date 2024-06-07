namespace LogicalData.Domain.Modelos.ModelosSolicitudes
{
    /// <summary>
    /// Autor: Jordi Segura
    /// Fecha: 4/6/2024
    /// Descripción: Clase que almacena la forma de la solicitud para agregar un usuario.
    /// </summary>
    public class SAgregarUsuario
    {
        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Contrasenia { get; set; } = string.Empty;
    }
}
