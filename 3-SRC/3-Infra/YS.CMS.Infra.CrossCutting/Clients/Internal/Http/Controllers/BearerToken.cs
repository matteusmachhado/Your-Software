using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;

namespace YS.CMS.Infra.CrossCutting.Clients.Internal.Http.Controllers
{
    public abstract class BearerToken
    {
        public void GetBearerToken(IHttpContextAccessor accessor, HttpClient client)
        {
            //var token = accessor.HttpContext.User.Claims.First(c => c.Type == "Token").Value;
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImp0aSI6ImVlNjFmMDg1LTA1YTAtNGNmZi04MWUzLWI1NTFlZmZhZDAyMSIsImV4cCI6MTU1NTUyMTY3MSwiaXNzIjoiWVMuQ01TLkFwcHMuV2ViQXBwIiwiYXVkIjoiUG9zdG1hbiJ9.gVKMMjfe3F9_Xq4j0Qri5EO0D0Koxfa3q77CfklQeWU";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
