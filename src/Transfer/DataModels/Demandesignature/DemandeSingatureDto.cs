﻿using Grs.BioRestock.Shared.Enums.DemandeSignature;
using Grs.BioRestock.Transfer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Transfer.DataModels.Demandesignature
{
    public class DemandeSingatureDto
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public string NomClient { get; set; }
        public string FileName { get; set; }
        public string CodeSignature { get; set; }
        public string FileUrl { get; set; }
        public UploadRequest UploadRequest { get; set; }
        public string FileUrlsSigne { get; set; }
        public DateTime DateSignature { get; set; }
        public DateTime DateAnnulation { get; set; }
        public DateTime DateEtablissement { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public DemandeStatut demandeStatut { get; set; } = DemandeStatut.Nouveau;

        /// <summary>
        /// The file data
        /// </summary>
        public byte[] FileData { get; set; }
    }
}
