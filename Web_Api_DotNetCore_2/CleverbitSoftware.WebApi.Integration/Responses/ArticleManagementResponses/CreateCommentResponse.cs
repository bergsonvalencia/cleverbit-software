using CleverbitSoftware.WebApi.Integration.Dtos;

namespace CleverbitSoftware.WebApi.Integration.Responses.ArticleManagementResponses
{
    public class CreateCommentResponse : BaseResponse
    {
        public Comment Comment { get; set; }
    }
}
