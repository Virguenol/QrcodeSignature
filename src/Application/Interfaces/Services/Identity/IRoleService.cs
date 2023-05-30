using Grs.BioRestock.Application.Interfaces.Common;
using Grs.BioRestock.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grs.BioRestock.Transfer.Requests.Identity;
using Grs.BioRestock.Transfer.Responses.Identity;

namespace Grs.BioRestock.Application.Interfaces.Services.Identity
{
    public interface IRoleService : IService
    {
        Task<Result<List<RoleResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleResponse>> GetByIdAsync(string id);

        Task<Result<string>> SaveAsync(RoleRequest request);

        Task<Result<string>> DeleteAsync(string id);

        Task<Result<PermissionResponse>> GetAllPermissionsAsync(string roleId);

        Task<Result<string>> UpdatePermissionsAsync(PermissionRequest request);
    }
}