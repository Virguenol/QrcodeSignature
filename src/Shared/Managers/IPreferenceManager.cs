﻿using Grs.BioRestock.Shared.Settings;
using System.Threading.Tasks;
using Grs.BioRestock.Shared.Wrapper;

namespace Grs.BioRestock.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}