namespace CleverbitSoftware.WebApi.Integration.Requests
{
    public class AuthenticateGoogle : BaseRequest
    {
        public string IdToken { get; set; }
    }
}