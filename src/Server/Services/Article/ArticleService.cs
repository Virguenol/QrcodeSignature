using Grs.BioRestock.Application.Interfaces.Services;
using Grs.BioRestock.Domain.Entities;
using Grs.BioRestock.Infrastructure.Contexts;
using Grs.BioRestock.Shared.Wrapper;
using Grs.BioRestock.Transfer.DataModels.Article;
using Grs.BioRestock.Transfer.DataModels.BonDeRetourDtos;
using Grs.BioRestock.Transfer.DataModels.Client;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grs.BioRestock.Server.Services.Article
{
    public interface IArticleService
    {
        Task<Result<List<GetArticleDto>>> GetArticles();
    }
    public class ArticleService : IArticleService
    {
        private readonly IStringLocalizer<ArticleService> _localizer;
        private readonly ICurrentUserService _currentUserService;
        private readonly UniContext _context;

        public ArticleService(IStringLocalizer<ArticleService> localizer,
            ICurrentUserService currentUserService,
            UniContext context)
        {
            _localizer = localizer;
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<Result<List<GetArticleDto>>> GetArticles()
        {
            var bonderetour = await _context.Articles.ToListAsync();
            var bonderetourResponse = bonderetour.Adapt<List<GetArticleDto>>();
            return await Result<List<GetArticleDto>>.SuccessAsync(bonderetourResponse);
        }
    }
}
