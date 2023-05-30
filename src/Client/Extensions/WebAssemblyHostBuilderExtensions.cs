using Blazored.LocalStorage;
using Grs.BioRestock.Client.Infrastructure.Authentication;
using Grs.BioRestock.Client.Infrastructure.Managers;
using Grs.BioRestock.Client.Infrastructure.Managers.Preferences;
using Grs.BioRestock.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using BlazorDB;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Grs.BioRestock.Client.Infrastructure.ApiClients;
using Grs.BioRestock.Client.Infrastructure.Settings;
using Grs.BioRestock.Shared.Constants.Application;

namespace Grs.BioRestock.Client.Extensions
{
    public static class WebAssemblyHostBuilderExtensions
    {
        public static WebAssemblyHostBuilder AddRootComponents(this WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");

            return builder;
        }

        public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder)
        {
            builder
                .Services
                .AddLocalization(options => { options.ResourcesPath = "Resources"; })
                .AddAuthorizationCore(options => { RegisterPermissionClaims(options); })
                .AddBlazoredLocalStorage()
                .AddMudServices(configuration =>
                {
                    configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                    configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                    configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                    configuration.SnackbarConfiguration.VisibleStateDuration = 5000;
                    configuration.SnackbarConfiguration.ShowCloseIcon = true;
                })
                //.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped<ClientPreferenceManager>()
                .AddScoped<UniStateProvider>()
                .AddScoped<AuthenticationStateProvider, UniStateProvider>()
                .AutoRegisterInterfaces<IApiClient>()
                .AutoRegisterInterfaces<IManager>()
                .AddSingleton<GlobalVariables>()
                .AddLocalDB(ApplicationConstants.AppName, 1)
                .AddTransient<AuthenticationHeaderHandler>()
                .AddScoped(sp => sp
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient(ApplicationConstants.AppName).EnableIntercept(sp))
                .AddHttpClient(ApplicationConstants.AppName, client =>
                {
                    client.DefaultRequestHeaders.AcceptLanguage.Clear();
                    client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture
                        ?.TwoLetterISOLanguageName);
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                })
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();
            builder.Services.AddHttpClientInterceptor();


            return builder;
        }


        public static IServiceCollection AutoRegisterInterfaces<T>(this IServiceCollection services)
        {
            var @interface = typeof(T);

            var types = @interface
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (@interface.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
            }

            return services;
        }

        private static void RegisterPermissionClaims(AuthorizationOptions options)
        {
            foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c =>
                         c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
            {
                var propertyValue = prop.GetValue(null);
                if (propertyValue is not null)
                {
                    options.AddPolicy(propertyValue.ToString() ?? string.Empty,
                        policy => policy.RequireClaim(Permissions.ClaimType, propertyValue.ToString()));
                }
            }
        }

        public static IServiceCollection AddLocalDB(this IServiceCollection services, string name, int version)
        {
            return services.AddBlazorDB(options =>
            {
                options.Name = name;
                options.Version = version;
                options.StoreSchemas = new List<StoreSchema>()
                {
                    //todo ajouter les stores 

                    //new StoreSchema()
                    //{
                    //    Name = nameof(InventoryTaskDTO),
                    //    PrimaryKey = "objectID"
                    //},
                    //new StoreSchema()
                    //{
                    //    Name = nameof(StockAnomalyDTO),
                    //    PrimaryKey = "objectID"
                    //},
                    //new StoreSchema()
                    //{
                    //    Name = nameof(LogisticTaskDTO2),
                    //    PrimaryKey = "objectID"
                    //}
                };
            });
        }
    }
}