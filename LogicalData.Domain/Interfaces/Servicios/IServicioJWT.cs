using System.Security.Claims;

namespace LogicalData.Domain.Interfaces.Servicios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Interface del servicio de JWT.
    public interface IServicioJWT
    {
        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Genera un JWT.
        /// </summary>
        /// <returns>String con el token segun los parametros establecidos en la configuracion.</returns>
        public string CrearJWT(string nombre);

    }
}
