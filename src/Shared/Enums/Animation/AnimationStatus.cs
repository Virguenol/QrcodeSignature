using System.ComponentModel;

namespace Grs.BioRestock.Shared.Enums
{
    public enum AnomalyStatus
    {
        [Description("Nouveau")] Nouveau = 0,
        [Description("Clôturée")] Clôturée = 1,
        [Description("Rejeté")] Rejeté = 2,
        [Description("Annulée")] Annulée = 99
    }
}
