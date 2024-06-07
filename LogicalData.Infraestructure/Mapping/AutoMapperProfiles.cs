using AutoMapper;
using LogicalData.Data.Context;
using LogicalData.Domain.Modelos.ModelosEntidades;
using LogicalData.Domain.Modelos.ModelosSolicitudes;
using System.Security.Cryptography;
using System.Text;

namespace LogicalData.Infraestructure.Mapping
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 4/6/2024
    /// Descripción: Clase encargada de manejar el mapping de las entidades.
    /// </summary>
    public class AutoMapperProfiles : Profile
    {
        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 4/6/2024
        /// Descripción: Constructor del AutoMapper y sus mappings.
        /// </summary>
        public AutoMapperProfiles()
        {
            

            CreateMap<Usuario, MUsuario>().ReverseMap();
            CreateMap<SOrden, Orden>().ReverseMap();
            CreateMap<SItem, Item>().ReverseMap();
            CreateMap<MOrden, Orden>().ReverseMap();
            CreateMap<MItem, Item>().ReverseMap();
            CreateMap<MProducto, Producto>().ReverseMap();
            CreateMap<SAgregarProducto, Producto>().ReverseMap();
            CreateMap<SAgregarProducto, MProducto>().ReverseMap();
            CreateMap<SAgregarUsuario, MUsuario>().ReverseMap();

            CreateMap<Usuario, SAgregarUsuario>()
               .ForMember(dest => dest.Contrasenia, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.Contrasenia)))
               .ReverseMap()
               .ForMember(dest => dest.Contrasenia, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.Contrasenia)));
        }
    }
}
