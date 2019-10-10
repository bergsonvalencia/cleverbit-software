using System;
using System.Collections.Generic;
using System.Linq;
using CleverbitSoftware.WebApi.Integration.Responses.ArticleManagementResponses;
using ArticleManagement.Core.Interfaces;
using ArticleManagement.Infrastructure.Data.Interfaces;
using Dto = CleverbitSoftware.WebApi.Integration.Dtos;

namespace ArticleManagement.Core.Services
{
    public class ArticleService : BaseService, IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IMapperService mapper,
            IArticleRepository articleRepository) : base(mapper)
        {
            _articleRepository = articleRepository;
        }

        #region Public Methods
        public GetArticlesResponse GetArticles()
        {
            var response = new GetArticlesResponse();

            var entities = _articleRepository.GetArticlesInclude(x => x.Comments);

            response.Articles = Mapper.Map<IEnumerable<Dto.Article>>(entities);

            return response;
        }

        public GetArticleResponse GetArticle(Guid id)
        {
            var response = new GetArticleResponse();

            var entity = _articleRepository.GetArticlesFindByInclude(x => x.Id == id, x => x.Comments).SingleOrDefault();

            response.Article = Mapper.Map<Dto.Article>(entity);

            return response;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}