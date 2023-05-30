using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Transfer.DataModels.Article
{
    public class GetArticleDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public decimal Price { get; set; }
    }
}
