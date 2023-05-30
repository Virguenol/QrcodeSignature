using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Shared.Enums.DemandeSignature
{
    public enum DemandeStatut
    {
        [Description("Nouveau")] Nouveau = 0,
        [Description("Signé")] Signé = 1,
        [Description("Annulé")] Annulé = 2
    }
}
