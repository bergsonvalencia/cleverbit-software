using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArticleManagement.Infrastructure.Data.Entities;


namespace ArticleManagement.Infrastructure.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasMany(p => p.Comments).WithOne(o => o.Article);
        }
    }
}
