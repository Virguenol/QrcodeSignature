using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Shared.Enums.BonDeRetour
{
    public enum BonDeRetourDepot
    {
        [Description("Casablanca")] Casablanca = 1,
        [Description("Fès")] Fès = 2,
        [Description("Marraech")] Marraech = 3
    }
}
