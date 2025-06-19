using FirebirdSql.Data.FirebirdClient;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Services;
using Sanura.Core.Services;
using System.Data;
using System.Data.Common;

namespace Sanura.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IDbConnection>(z =>  new FbConnection(Configuration.GetConnectionString("SanuraFB")));
            services.AddTransient<IDbContext, DbContext>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISyncService, SyncService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            return services;
        }
    }
}