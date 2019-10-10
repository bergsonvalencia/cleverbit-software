using CleverbitSoftware.WebApi.Integration.Requests.ArticleManagementRequests;
using CleverbitSoftware.WebApi.Integration.Responses.ArticleManagementResponses;

namespace ArticleManagement.Core.Interfaces
{
    public interface ICommentService
    {
        CreateCommentResponse CreateComment(CreateCommentRequest request);
    }
}
