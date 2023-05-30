using System.Linq;
using Grs.BioRestock.Shared.Constants.Localization;
using Grs.BioRestock.Shared.Settings;

namespace Grs.BioRestock.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? LocalizationConstants.DefaultLanguageCode; 

        //TODO - add server preferences
    }
}