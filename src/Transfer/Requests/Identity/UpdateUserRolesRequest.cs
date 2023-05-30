using System.Collections.Generic;
using Grs.BioRestock.Transfer.Responses.Identity;

namespace Grs.BioRestock.Transfer.Requests.Identity
{
    public class UpdateUserRolesRequest
    {
        public string UserId { get; set; }
        public IList<UserRoleModel> UserRoles { get; set; }
    }
}