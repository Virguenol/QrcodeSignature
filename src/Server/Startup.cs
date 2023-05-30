using Grs.BioRestock.Application.Extensions;
using Grs.BioRestock.Infrastructure.Extensions;
using Grs.BioRestock.Server.Extensions;
using Grs.BioRestock.Server.Middlewares;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Grs.BioRestock.Server.Filters;
using Grs.BioRestock.Server.Managers.Preferences;
using Microsoft.Extensions.Localization;
using Grs.BioRestock.Shared.Constants.Permission;
using System.Configuration;
using Grs.BioRestock.Shared.Configurations;
using Grs.BioRestock.Server.Services.BonDeRetourService;

namespace Grs.BioRestock.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder
            //            .AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader();
            //        });
            //});
            services.AddCors();
            services.AddSignalR();
            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
            services.AddCurrentUserService();
            services.AddSerialization();
            services.AddDatabase(_configuration);
            services.AddServerStorage(); //TODO - should implement ServerStorageProvider to work correctly!
            services.AddScoped<ServerPreferenceManager>();
            services.AddServerLocalization();
            services.AddIdentity();
            services.AddJwtAuthentication(services.GetApplicationSettings(_configuration));
            services.AddApplicationLayer();
            services.AddApplicationServices();
            services.AddSageServices(_configuration);
            services.AddRepositories();
            services.AddSharedInfrastructure(_configuration);
            services.RegisterSwagger();
            services.AddInfrastructureMappings();

            services.Configure<BydesignConfiguration>(
                _configuration.GetSection(nameof(BydesignConfiguration))); // to incorporate in AddBydesignServices


            services.AddHangfire(x => x.UseSqlServerStorage(_configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services.AddControllers().AddValidators();
            services.AddRazorPages();
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddLazyCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStringLocalizer<Startup> localizer)
        {
            app.UseCors();
            app.UseExceptionHandling(env);
            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
                RequestPath = new PathString("/Files")
            });
            app.UseRequestLocalizationByCulture();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHangfireDashboard("/jobs", new DashboardOptions
            {
                DashboardTitle = localizer["GRS Jobs"],
                AppPath = null,
                Authorization = new[] { new HangfireAuthorizationFilter(), }
            });
            ;
            app.UseEndpoints();
            app.ConfigureSwagger();
            app.Initialize(_configuration);
        }
    }
}