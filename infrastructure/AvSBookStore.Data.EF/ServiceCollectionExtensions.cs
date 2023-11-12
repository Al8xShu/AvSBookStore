using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvSBookStore.Data.EF
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AvsBookStoreDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                },
                ServiceLifetime.Transient
            );

            //services.AddScoped<Dictionary<Type, AvsBookStoreDbContext>>();
            //services.AddSingleton<DbContextFactory>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
