using System.Collections.Generic;
using Grs.BioRestock.Application.Interfaces.Common;

namespace Grs.BioRestock.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
        public string SiteId { get; }

        public string Name { get; }

        public string Animateur { get; }

        public List<KeyValuePair<string, string>> Claims { get; set; }
    }
}