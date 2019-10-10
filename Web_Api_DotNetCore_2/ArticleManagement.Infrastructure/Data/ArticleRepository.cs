using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ArticleManagement.Infrastructure.Data.Entities;
using ArticleManagement.Infrastructure.Data.Interfaces;
using SharedKernel.Data;

namespace ArticleManagement.Infrastructure.Data
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ArticleManagementContext context) : base(context) { }

        public IEnumerable<Article> GetArticles()
        {
            return All();
        }

        public IEnumerable<Article> GetArticlesInclude(params Expression<Func<Article, object>>[] includeProperties)
        {
            return AllInclude(includeProperties);
        }

        public Article GetArticle(Guid id)
        {
            return FindByKey(id);
        }

        public IEnumerable<Article> GetArticlesFindByInclude(Expression<Func<Article, bool>> predicate, params Expression<Func<Article, object>>[] includeProperties)
        {
            return FindByInclude(predicate, includeProperties);
        }

        public Article CreateArticle(Article article)
        {
            return Insert(article);
        }

        public Article UpdateArticle(Article article)
        {
            return Update(article);
        }
    }
}