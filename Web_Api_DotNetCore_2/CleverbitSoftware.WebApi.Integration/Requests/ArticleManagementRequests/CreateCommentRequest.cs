using System;

namespace CleverbitSoftware.WebApi.Integration.Requests.ArticleManagementRequests
{
    public class CreateCommentRequest
    {
        public string CommenterId { get; set; }
        public string Content { get; set; }
        public Guid ArticleId { get; set; }
    }
}
