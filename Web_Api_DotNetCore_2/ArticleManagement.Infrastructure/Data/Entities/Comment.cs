using System;
using SharedKernel.CleverbitSoftware;

namespace ArticleManagement.Infrastructure.Data.Entities
{
    public class Comment : AggregateRoot
    {
        public string CommenterId { get; set; }
        public string Content { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
