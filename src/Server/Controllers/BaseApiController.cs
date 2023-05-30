using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Grs.BioRestock.Shared.Localizers;

namespace Grs.BioRestock.Server.Controllers
{
    /// <summary>
    /// Abstract BaseApi Controller Class
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase
    {
        private IStringLocalizer<FrontEndLocalizer> _localizer;

        protected IStringLocalizer<FrontEndLocalizer> Localizer => _localizer ??=
            HttpContext.RequestServices.GetService<IStringLocalizer<FrontEndLocalizer>>();
    }
}