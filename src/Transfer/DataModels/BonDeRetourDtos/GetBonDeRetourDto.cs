using Grs.BioRestock.Shared.Enums;
using Grs.BioRestock.Shared.Enums.BonDeRetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnomalyType = Grs.BioRestock.Shared.Enums.AnomalyType;

namespace Grs.BioRestock.Transfer.DataModels.BonDeRetourDtos
{
    public class GetBonDeRetourDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ClientName { get; set; }
        public string ArticleName { get; set; }
        public AnomalyType AnomalyType { get; set; } = AnomalyType.Produit_Introuvable;
        public string Reference { get; set; }
        public int Quantity { get; set; }
        public BonDeRetourStatus Status { get; set; } = BonDeRetourStatus.Nouveau;
        public BonDeRetourDepot Depot { get; set; } = 0;
    }
}
