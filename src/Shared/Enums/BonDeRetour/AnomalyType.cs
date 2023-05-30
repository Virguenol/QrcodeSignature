using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Shared.Enums.BonDeRetour
{
    public enum AnomalyType
    {
        [Description("Produit Introuvable")] Produit_Introuvable,
        [Description("Lot et Quantité Erronée")] Lot_Quantite_Erronee,
        [Description("Lot  Erronée")] Lot_Erronee,
        [Description("Quantité Erronée")] Quantite_Erronee,
        [Description("Produit Trouvé")] Produit_Trouve
    }
}
