using Grs.BioRestock.Domain.Contracts;
using Grs.BioRestock.Shared.Enums.DemandeSignature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Domain.Entities
{
    public class DemandeSignature : AuditableEntity<int>
    {
        public string Designation { get; set; }
        public string NomClient { get; set; }
        public string CodeSignature { get; set; }
        public string FileUrl { get; set; }
        public string FileUrlsSigne { get; set; }
        public DateTime DateSignature { get; set; }
        public DateTime DateAnnulation { get; set; }
        public DateTime DateEtablissement { get; set; }
        public DemandeStatut demandeStatut { get; set; } = DemandeStatut.Nouveau;
    }
}
