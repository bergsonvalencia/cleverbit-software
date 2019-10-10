using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArticleManagement.Core.Interfaces;
using CleverbitSoftware.WebApi.Integration.Responses.ArticleManagementResponses;

namespace CleverbitSoftware.WebApi.Controllers
{
    public class ArticlesController : BaseController
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService,
            ILogger<ArticlesController> logger) : base(logger)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<ActionResult> GetArticles()
        {
            var response = new GetArticlesResponse();

            try
            {
                response = _articleService.GetArticles();

                if (response.ValidationResult.IsValid)
                {
                    return Ok(response);
                }
            }
            catch (Exception exception)
            {
                return LogError("Get Articles", response, exception);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> GetArticle(Guid id)
        {
            var response = new GetArticleResponse();

            try
            {
                response = _articleService.GetArticle(id);

                if (response.ValidationResult.IsValid)
                {
                    return Ok(response);
                }
            }
            catch (Exception exception)
            {
                return LogError("Get Article", response, exception);
            }

            return BadRequest(response);
        }
    }
}