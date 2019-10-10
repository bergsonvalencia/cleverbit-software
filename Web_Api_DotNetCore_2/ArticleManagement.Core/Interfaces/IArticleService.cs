using System;
using CleverbitSoftware.WebApi.Integration.Responses.ArticleManagementResponses;

namespace ArticleManagement.Core.Interfaces
{
    public interface IArticleService
    {
        GetArticlesResponse GetArticles();
        GetArticleResponse GetArticle(Guid id);
    }
}
