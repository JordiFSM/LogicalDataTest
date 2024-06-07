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
    /// Descripción: Implementación de la interface del repositorio de ordenes.
    /// </summary>
    public class RepositorioOrden : IRepositorioOrden
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
        public RepositorioOrden(LogicalDataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Agrega una orden al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con forma de la orden que se desea agregar.</param>
        /// <returns>La orden agregada.</returns>
        public async Task<MOrden> AgregarOrden(SAgregarOrden solicitud)
        {

            if (!(solicitud.Orden is null || solicitud.Items is null))
            {
                var nuevaOrden = _mapper.Map<Orden>(solicitud.Orden);
                nuevaOrden.Total = solicitud.Orden.Total;

                await _context.Ordens.AddAsync(nuevaOrden);
                await _context.SaveChangesAsync();

                var ordenItems = _mapper.Map<Item[]>(solicitud.Items);
                ordenItems.Select(item =>
                {
                    item.OrdenId = nuevaOrden.Id;
                    item.Total = item.Precio * item.Cantidad;
                    return item;
                }).ToList();

                await _context.Items.AddRangeAsync(ordenItems);

                await _context.SaveChangesAsync();

                return _mapper.Map<MOrden>(nuevaOrden);
            }

            return null;
            
        }

        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Lista las ordenes del sistema.
        /// </summary>
        /// <returns>Lista con las ordenes del sistema.</returns>
        public async Task<IEnumerable<MOrden>> ListarOrdenes()
        {
            var ordenes = await _context.Ordens.AsNoTracking().Include(o => o.Items).ToListAsync();

            return _mapper.Map<MOrden[]>(ordenes);
        }
    }
}
