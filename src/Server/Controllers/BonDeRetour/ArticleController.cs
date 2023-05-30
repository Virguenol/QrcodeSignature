using Grs.BioRestock.Server.Services.Article;
using Grs.BioRestock.Shared.Wrapper;
using Grs.BioRestock.Transfer.DataModels.Article;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grs.BioRestock.Server.Controllers.BonDeRetour
{
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet(nameof(GetAllArticle))]
        public async Task<Result<List<GetArticleDto>>> GetAllArticle()
        {
            return await _articleService.GetArticles();
        }
    }
}
