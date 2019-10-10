using System;

namespace ArticleManagement.Core.Domains
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommenterId { get; set; }
        public string Content { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
