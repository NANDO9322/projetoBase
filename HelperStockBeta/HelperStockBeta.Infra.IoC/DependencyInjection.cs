﻿using HelperStockBeta.Domain.Interface;
using HelperStockBeta.Infra.Data.Context;
using HelperStockBeta.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelperStockBeta.Infra.IoC
{
    public static class  DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;

        }
    }
}
