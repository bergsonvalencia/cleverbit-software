using CleverbitSoftware.WebApi.Integration.Dtos;

namespace CleverbitSoftware.WebApi.Integration.Responses.ArticleManagementResponses
{
    public class GetArticleResponse : BaseResponse
    {
        public Article Article { get; set; }
    }
}
