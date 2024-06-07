using AutoMapper;
using LogicalData.Data.Context;
using LogicalData.Domain.Interfaces.Repositorios;
using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;
using Microsoft.EntityFrameworkCore;

namespace LogicalData.Infraestructure.Repositorios
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Implementación de la interface del repositorio de producto.
    /// </summary>
    public class RepositorioProducto : IRepositorioProducto
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
        public RepositorioProducto(LogicalDataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Agrega un producto al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del producto que se desea agregar.</param>
        /// <returns>El producto agregado.</returns>
        public async Task<MProducto> AgregarProducto(SAgregarProducto solicitud)
        {
            var productoNuevo = _mapper.Map<Producto>(solicitud);
            var codigoCreado = "Art-" + Guid.NewGuid().ToString().Substring(0, 10);
            var producto = _mapper.Map<MProducto>(solicitud);

            if (await _context.Productos.AnyAsync(p => p.Codigo == productoNuevo.Codigo || p.Nombre.ToLower() == solicitud.Nombre.ToLower()))
            {
                productoNuevo.Codigo = "";
            }
            else
            {
                productoNuevo.Codigo = codigoCreado;

                await _context.Productos.AddAsync(productoNuevo);
                await _context.SaveChangesAsync();

                producto.Id = productoNuevo.Id;
                producto.Codigo = productoNuevo.Codigo;
            }

            return producto; 
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Lista los productos del sistema.
        /// </summary>
        /// <returns>Lista con los productos del sistema.</returns>
        public async Task<IEnumerable<MProducto>> ListarProductos()
        {
            var productos = await _context.Productos.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<MProducto>>(productos);
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Actualiza un producto del sistema.
        /// </summary>
        /// <param name="solicitud">Informacion del producto para actualizarlo.</param>
        /// <returns>Booleano que inidica si la acción de actualizar fue exitosa o no.</returns>
        public async Task<bool> ActualizarProducto(SActualizarProducto solicitud)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Codigo == solicitud.Codigo);

            if (producto != null)
            {
                producto.Descripcion = solicitud.Descripcion;
                producto.Nombre = solicitud.Nombre;
                producto.Precio = solicitud.Precio;
                producto.Iva = solicitud.IVA;

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }        

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Borra un producto del sistema.
        /// </summary>
        /// <param name="id">Id del producto que se desea borrar.</param>
        /// <returns>El producto borrado.</returns>
        public async Task<MProducto> BorrarProducto(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);

            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();

                return _mapper.Map<MProducto>(producto);
            }

            return null;
        }

    }
}
