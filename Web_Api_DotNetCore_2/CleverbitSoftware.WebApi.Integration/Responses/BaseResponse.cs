using FluentValidation.Results;

namespace CleverbitSoftware.WebApi.Integration.Responses
{
    public abstract class BaseResponse
    {
        protected BaseResponse()
        {
            ValidationResult = new ValidationResult();
        }

        public ValidationResult ValidationResult { get; set; }
    }
}
