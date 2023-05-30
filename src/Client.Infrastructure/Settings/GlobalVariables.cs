using MudBlazor;
using System;
using System.Globalization;

namespace Grs.BioRestock.Client.Infrastructure.Settings
{
    public class GlobalVariables
    {
        public string IndexDbName = "Grs";

        public String CurrentTitle { get; set; }
        public bool IsMobileView { get; set; }
        public bool IsLoading { get; set; }
        public bool AllowInventoryAddItem { get; set; } = true;
        public string QteFormat { get; set; } = "N3";
        public Variant TestFiledVariant { get; set; } = Variant.Text;


        private CultureInfo _customCulture;

        public CultureInfo CustomCulture
        {
            get
            {
                if (_customCulture == null)
                {
                    _customCulture = (CultureInfo)CultureInfo.GetCultureInfo("en-US").Clone();
                    _customCulture.NumberFormat.NumberGroupSeparator = " ";
                }

                return _customCulture;
            }
        }

        public bool ShowScanButton { get; set; } = false;
    }
}