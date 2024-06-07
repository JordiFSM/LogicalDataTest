using LogicalData.Domain.Interfaces.Servicios;
using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Utilidades.Constantes;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogicalData.Infraestructure.Servicios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 5/6/2024
    /// Descripción: Clase que se encarga de la creación del JWT.
    /// </summary>
    public class ServicioJWT : IServicioJWT
    {
        private IConfiguration _config;
        public ServicioJWT(IConfiguration config) {
            _config = config;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Genera un JWT.
        /// </summary>
        /// <returns>String con el token segun los parametros establecidos en la configuracion.</returns>
        public string CrearJWT(string username)
        {
            var jwt = _config.GetSection("Jwt").Get<MJwt>();
            
            var iat = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, iat.ToString(), ClaimValueTypes.Integer64),
                new Claim("Username", username)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(480),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
