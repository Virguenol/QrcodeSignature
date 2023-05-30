using System.Collections.Generic;

namespace Grs.BioRestock.Transfer.Responses.Identity
{
    public class GetAllUsersResponse
    {
        public IEnumerable<UserResponse> Users { get; set; }
    }
}