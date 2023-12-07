﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AvSBookStore.Data.EF
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AvSBookStoreDbContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    },
                    ServiceLifetime.Transient);

            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
