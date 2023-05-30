using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Grs.BioRestock.Application.Interfaces.Repositories;
using Grs.BioRestock.Application.Interfaces.Services.Storage;
using Grs.BioRestock.Application.Interfaces.Services.Storage.Provider;
using Grs.BioRestock.Application.Interfaces.Serialization.Serializers;
using Grs.BioRestock.Application.Serialization.JsonConverters;
using Grs.BioRestock.Infrastructure.Repositories;
using Grs.BioRestock.Infrastructure.Services.Storage;
using Grs.BioRestock.Application.Serialization.Options;
using Grs.BioRestock.Infrastructure.Services.Storage.Provider;
using Grs.BioRestock.Application.Serialization.Serializers;

namespace Grs.BioRestock.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // TODO : Add Repositories
            return services
                .AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
                .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }

     

        public static IServiceCollection AddServerStorage(this IServiceCollection services)
            => AddServerStorage(services, null);

        public static IServiceCollection AddServerStorage(this IServiceCollection services, Action<SystemTextJsonOptions> configure)
        {
            return services
                .AddScoped<IJsonSerializer, SystemTextJsonSerializer>()
                .AddScoped<IStorageProvider, ServerStorageProvider>()
                .AddScoped<IServerStorageService, ServerStorageService>()
                .AddScoped<ISyncServerStorageService, ServerStorageService>()
                .Configure<SystemTextJsonOptions>(configureOptions =>
                {
                    configure?.Invoke(configureOptions);
                    if (!configureOptions.JsonSerializerOptions.Converters.Any(c => c.GetType() == typeof(TimespanJsonConverter)))
                        configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
                });
        }
    }
}