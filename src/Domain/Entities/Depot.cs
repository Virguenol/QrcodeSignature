using Grs.BioRestock.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Domain.Entities
{
    public class Depot : AuditableEntity<int>
    {
        public int  Id { get; set; }
        public string DepotName { get; set; }
        public string libele { get; set;}
    }
}
