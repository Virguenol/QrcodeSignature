using System.Collections.Generic;
using System.Linq;
using Grs.BioRestock.Shared.Constants.Localization;
using Grs.BioRestock.Shared.Settings;

namespace Grs.BioRestock.Client.Infrastructure.Settings
{
    public record ClientPreference : IPreference
    {
        public bool IsDarkMode { get; set; }
        public bool IsRtl => LanguageCode.StartsWith("ar-");
        public bool IsDrawerOpen { get; set; }
        public string PrimaryColor { get; set; }
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ??  LocalizationConstants.DefaultLanguageCode;
        public List<string> MyTasklist { get; set; }

    }
}