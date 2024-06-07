using LogicalData.Data.Context;
using LogicalData.Domain.Interfaces.Repositorios;
using LogicalData.Domain.Interfaces.Servicios;
using LogicalData.Infraestructure.Mapping;
using LogicalData.Infraestructure.Repositorios;
using LogicalData.Infraestructure.Servicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogicalData.Infraestructure
{
    /// <summary>
    /// Autor: Jordi Segura Madrigal
    /// Fecha: 5/6/2024
    /// Descripción: Configura las dependencias del proyecto.
    /// </summary>
    public static class ConfigurarDependencias
    {
        /// <summary>
        /// Autor: Jordi Segura Madrigal
        /// Fecha: 5/6/2024
        /// Descripción: Configura las dependencias.
        /// </summary>
        /// <param name="services">Referencia a la colección de servicios usada en el proyecto.</param>
        /// <param name="configuration">Referencia a la configuración usada en el proyecto.</param>
        /// <returns>Los servicios con las implementaciones ya configuradas</returns>
        public static IServiceCollection ConfigurarProyecto(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<LogicalDataDbContext>(optionsLifetime: ServiceLifetime.Transient);
            services.AddAutoMapper(typeof(AutoMapperProfiles));

            services.AddScoped<IServicioJWT, ServicioJWT>();
            services.AddScoped<IServicioUsuario, ServicioUsuario>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IServicioProducto, ServicioProducto>();
            services.AddScoped<IRepositorioProducto, RepositorioProducto>();
            services.AddScoped<IServicioOrden, ServicioOrden>();
            services.AddScoped<IRepositorioOrden, RepositorioOrden>();


            return services;
        }
    }
}
