using ArticleManagement.Infrastructure.Data.Entities;
using ArticleManagement.Infrastructure.Data.Interfaces;
using SharedKernel.Data;

namespace ArticleManagement.Infrastructure.Data
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ArticleManagementContext context) : base(context) { }

        public Comment CreateComment(Comment comment)
        {
            return Insert(comment);
        }
    }
}