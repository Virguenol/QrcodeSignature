using System.Collections.Generic;

namespace Grs.BioRestock.Transfer.Responses.Identity
{
    public class GetAllRolesResponse
    {
        public IEnumerable<RoleResponse> Roles { get; set; }
    }
}