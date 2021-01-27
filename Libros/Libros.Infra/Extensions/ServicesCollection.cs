using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Libros.Core.CustomEntities;
using Libros.Core.Interfaces;
using Libros.Core.Interfaces.Services;
using Libros.Core.Services;
using Libros.Infra.Repository;
using Libros.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Libros.Infra.Extensions
{
    public static class ServicesCollection
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            string ConnectionStreings = configuration.GetConnectionString("DBLIBROS");
            services.AddTransient<IDbConnection>(options => new SqlConnection(ConnectionStreings));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            //Services
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IAutorService, AutorService>();

            services.AddTransient<ICategoriaRrepository, CategoriaRepository>();
            services.AddTransient<ICategoriaService, CategoriaService>();

            services.AddTransient<ILibroRepository, LibroRepository>();
            services.AddTransient<ILibroService, LibroService>();

            return services;
        }
    }
}
