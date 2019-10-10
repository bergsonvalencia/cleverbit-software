using System;
using Microsoft.EntityFrameworkCore;
using ArticleManagement.Infrastructure.Data.Entities;

namespace ArticleManagement.Infrastructure.Data
{
    public class ArticleManagementContext : DbContext
    {
        public ArticleManagementContext(DbContextOptions<ArticleManagementContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleManagementContext).Assembly);
            PopulateSeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void PopulateSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article { Id = Guid.NewGuid(), Name = "Article 1", Content = "This is the content of Article 1", Year = 2015 },
                new Article { Id = Guid.NewGuid(), Name = "Article 2", Content = "This is the content of Article 2", Year = 2016 },
                new Article { Id = Guid.NewGuid(), Name = "Article 3", Content = "This is the content of Article 3", Year = 2017 },
                new Article { Id = Guid.NewGuid(), Name = "Article 4", Content = "This is the content of Article 4", Year = 2018 },
                new Article { Id = Guid.NewGuid(), Name = "Article 5", Content = "This is the content of Article 5", Year = 2019 });
        }
    }
}