using System.Collections.Generic;
using CleverbitSoftware.WebApi.Integration.Dtos;

namespace CleverbitSoftware.WebApi.Integration.Responses.ArticleManagementResponses
{
    public class GetArticlesResponse : BaseResponse
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}
