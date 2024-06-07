using System.ComponentModel.DataAnnotations;

namespace LogicalData.Domain.Modelos.ModelosSolicitudes
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripcion: Modelo que almacena la forma de solicitud de inicio de sesión.
    /// </summary>
    public class SIniciarSesion
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Contrasenia { get; set; } = string.Empty;
    }
}
