using CleverbitSoftware.WebApi.Integration.Requests.ArticleManagementRequests;
using FluentValidation;

namespace ArticleManagement.Core.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentValidator()
        {
            RuleFor(_ => _.ArticleId).NotEmpty();
            RuleFor(_ => _.CommenterId).NotEmpty();
            RuleFor(_ => _.Content).NotEmpty();
        }
    }
}