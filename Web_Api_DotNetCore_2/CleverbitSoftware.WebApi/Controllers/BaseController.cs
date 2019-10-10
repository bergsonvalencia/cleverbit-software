using System;
using CleverbitSoftware.WebApi.Integration.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleverbitSoftware.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger Logger;

        public BaseController(ILogger logger)
        {
            Logger = logger;
        }

        protected StatusCodeResult LogError(string action, BaseResponse response, Exception exception)
        {
            Logger.Log(LogLevel.Error, $"{action} unhandled error. Response: {response}. Exception: {exception}.");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}