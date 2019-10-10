using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ArticleManagement.Infrastructure.Data.Entities;

namespace ArticleManagement.Infrastructure.Data.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();
        IEnumerable<Article> GetArticlesInclude(params Expression<Func<Article, object>>[] includeProperties);
        Article GetArticle(Guid id);
        IEnumerable<Article> GetArticlesFindByInclude(Expression<Func<Article, bool>> predicate, params Expression<Func<Article, object>>[] includeProperties);
        Article CreateArticle(Article article);
        Article UpdateArticle(Article article);
    }
}