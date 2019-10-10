using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SharedKernel.CleverbitSoftware;

namespace SharedKernel.Data
{
    public class GenericRepository<TEntity> where TEntity : AggregateRoot
    {
        internal DbContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> AllInclude
        (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public IEnumerable<TEntity> FindByInclude
          (Expression<Func<TEntity, bool>> predicate,
          params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(predicate).ToList();
            return results;
        }

        private IQueryable<TEntity> GetAllIncluding
        (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = DbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {

            IEnumerable<TEntity> results = DbSet.AsNoTracking()
              .Where(predicate).ToList();
            return results;
        }

        public TEntity FindByKey(Guid id)
        {
            Expression<Func<TEntity, bool>> lambda = Utilities.BuildLambdaForFindByKey<TEntity>(id);
            return DbSet.AsNoTracking().SingleOrDefault(lambda);
        }

        public TEntity Insert(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(Guid id)
        {
            var entity = FindByKey(id);

            if (entity == null) return null;

            DbSet.Remove(entity);
            Context.SaveChanges();

            return entity;
        }
    }
}