using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Shared.Enums.BonDeRetour
{
    public enum BonDeRetourStatus
    {
        [Description("Nouveau")] Nouveau = 0,
        [Description("Validé")] Validé = 1,
        [Description("Clôturée")] Cloturee = 2
    }
}
