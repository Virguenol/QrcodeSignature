using Grs.BioRestock.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Domain.Entities
{
    public class Article : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public decimal Price { get; set; }
        public BonDeRetour BonDeRetour { get; set; }
    }
}
