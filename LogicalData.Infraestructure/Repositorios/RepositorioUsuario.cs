using AutoMapper;
using LogicalData.Data.Context;
using LogicalData.Domain.Interfaces.Repositorios;
using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace LogicalData.Infraestructure.Repositorios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Implementación de la interface del repositorio de usuario.
    /// </summary>
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly LogicalDataDbContext _context;

        private readonly IMapper _mapper;

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Constructor.
        /// </summary>
        /// <param name="mapper">Referencia al mapeador de entidades.</param>
        /// <param name="dbContext">Contexto de la base de datos.</param> 
        public RepositorioUsuario(LogicalDataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Calcula el hash de una contraseña utilizando el algoritmo SHA-256.
        /// </summary>
        /// <param name="password">Contraseña a hashear.</param>
        /// <returns>El hash de la contraseña.</returns>
        private byte[] HashearContrasenia(string contra)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contra));
            }
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Autentica un usuario.
        /// </summary>
        /// <param name="solicitud">Solicitud con las credenciales del usuario.</param>
        /// <returns>El usuario autenticado.</returns>
        public async Task<MUsuario> AutenticarUsuario(SIniciarSesion solicitud)
        {
            var hashedC = HashearContrasenia(solicitud.Contrasenia);
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Username == solicitud.Username && u.Contrasenia == hashedC);

            return _mapper.Map<MUsuario>(usuario);
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Agrega un usuario al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del usuario que se desea agregar.</param>
        /// <returns>El usuario agregado.</returns>
        public async Task<MUsuario> AgregarUsuario(SAgregarUsuario solicitud)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == solicitud.Username);

            if (usuarioExistente == null)
            {
                var usuarioNuevo = _mapper.Map<Usuario>(solicitud);
                usuarioNuevo.Contrasenia = HashearContrasenia(solicitud.Contrasenia);

                var usuarioRespuesta = _mapper.Map<MUsuario>(solicitud);
                //BitConverter.ToString(usuarioNuevo.Contrasenia).Equals(BitConverter.ToString(HashearContrasenia(solicitud.Contrasenia)))

                await _context.Usuarios.AddAsync(usuarioNuevo);
                await _context.SaveChangesAsync();

                usuarioRespuesta.Id = usuarioNuevo.Id;

                return usuarioRespuesta;
            }

            return null;
        }

    }
}
