using ArticleManagement.Core.Events;
using SharedKernel.CleverbitSoftware.Interfaces;

namespace ArticleManagement.Core.Handlers
{
    public class CommentCreationHandler : IHandler<CommentCreation>
    {
        public void Handle(CommentCreation args)
        {
            //TODO: Perform actions based on business logic when a comment is created. E.g. email admin about article and comment details.
        }
    }
}