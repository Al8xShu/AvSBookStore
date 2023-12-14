using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace AvSBookStore.Data.EF
{
    public class DbContextFactory
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public DbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public AvSBookStoreDbContext Create(Type repositoryType)
        {
            var services = httpContextAccessor.HttpContext.RequestServices;

            var dbContexts = services.GetService<Dictionary<Type, AvSBookStoreDbContext>>();

            if (!dbContexts.ContainsKey(repositoryType))
            { 
                dbContexts[repositoryType] = services.GetService<AvSBookStoreDbContext>();
            }

            return dbContexts[repositoryType];
        }
    }
}
