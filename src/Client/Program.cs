using Grs.BioRestock.Client.Extensions;
using Grs.BioRestock.Client.Infrastructure.Managers.Preferences;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Grs.BioRestock.Client.Infrastructure.Settings;
using Grs.BioRestock.Shared.Constants.Localization;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace Grs.BioRestock.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder
                .CreateDefault(args)
                .AddRootComponents()
                .AddClientServices();
            builder.Services.AddPWAUpdater();
            var host = builder.Build();
            var storageService = host.Services.GetRequiredService<ClientPreferenceManager>();
            if (storageService != null)
            {
                CultureInfo culture;
                var preference = await storageService.GetPreference() as ClientPreference;
                if (preference != null)
                    culture = new CultureInfo(preference.LanguageCode);
                else
                    culture = new CultureInfo(LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? LocalizationConstants.DefaultLanguageCode);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }

            await builder.Build().RunAsync();
        }
    }
}