
using Prateleira.Infrastruture.Data.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Prateleira.Infrastruture.Data.DataRegistration
{
    public static class DataRegistration
    {
        public static IServiceCollection AddDataRegistration(
            this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContextPool<DbContext, Context>(op =>
            {
                 op.UseSqlServer(configuration.GetConnectionString("StringConnection"));
            });
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return service;
        }
    }
}
