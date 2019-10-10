using System;

namespace CleverbitSoftware.WebApi.Integration.Dtos
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommenterId { get; set; }
        public string Content { get; set; }
        public Guid ArticleId { get; set; }
    }
}
