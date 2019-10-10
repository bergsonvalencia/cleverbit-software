using ArticleManagement.Infrastructure.Data.Entities;

namespace ArticleManagement.Infrastructure.Data.Interfaces
{
    public interface ICommentRepository
    {
        Comment CreateComment(Comment comment);
    }
}
