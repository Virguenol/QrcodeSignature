using System.ComponentModel;

namespace Grs.BioRestock.Shared.Enums
{
    public enum AnimationStatus
    {
        [Description("Brouillon")] Brouillon = 0,
        [Description("Active")] Active = 1,
        [Description("Clôturée")] Cloturee = 2
    }
}