using Grs.BioRestock.Shared.Constants.Application;
using Grs.BioRestock.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Grs.BioRestock.Server.Controllers.Utilities
{
    [ApiController]
    public class VersionController : BaseApiController<VersionController>
    {
        [HttpGet(nameof(AppVersion))]
        public async Task<IResult<string>> AppVersion()
        {
            return await Result<string>.SuccessAsync(data: ApplicationConstants.AppVersion);
        }
    }
}