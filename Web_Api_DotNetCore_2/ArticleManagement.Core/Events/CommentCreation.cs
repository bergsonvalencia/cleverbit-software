using ArticleManagement.Core.Domains;
using SharedKernel.CleverbitSoftware.Interfaces;

namespace ArticleManagement.Core.Events
{
    //This is a sample Domain Event, event will be handled in CommentCreationHandler
    public class CommentCreation : IDomainEvent
    {
        public readonly Comment Comment;

        public CommentCreation(Comment comment)
        {
            Comment = comment;
        }
    }
}
