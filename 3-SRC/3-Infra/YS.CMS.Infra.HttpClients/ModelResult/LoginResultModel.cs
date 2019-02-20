using System.Net;

namespace YS.CMS.Infra.Clients.ModelResult
{
    public class LoginResultModel
    {
        public string Token { get; set; }
        public bool Succeeded { get; set; }

        public LoginResultModel(string token, HttpStatusCode statusCode)
        {
            Token = token;
            Succeeded = (statusCode == HttpStatusCode.OK);
        }
    }
}
