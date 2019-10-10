using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArticleManagement.Core.Interfaces;
using CleverbitSoftware.WebApi.Integration.Requests.ArticleManagementRequests;
using CleverbitSoftware.WebApi.Integration.Responses.ArticleManagementResponses;
using Microsoft.AspNetCore.Authorization;

namespace CleverbitSoftware.WebApi.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService,
            ILogger<CommentsController> logger) : base(logger)
        {
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateComment([FromBody]CreateCommentRequest request)
        {
            var response = new CreateCommentResponse();

            try
            {
                response = _commentService.CreateComment(request);

                if (response.ValidationResult.IsValid)
                {
                    return Ok(response);
                }
            }
            catch (Exception exception)
            {
                return LogError("Create Comment", response, exception);
            }

            return BadRequest(response);
        }
    }
}