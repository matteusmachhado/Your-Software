using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Infra.CrossCutting.Clients.Internal.Http.Controllers
{
    public class PostClient : BearerToken
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _acessor;

        public PostClient(HttpClient client, IHttpContextAccessor accessor)
        {
            _httpClient = client;
            _acessor = accessor;
        }

        public async Task PostAsync(Post post)
        {
            GetBearerToken(_acessor, _httpClient);

            var strPost = JsonConvert.SerializeObject(post, Formatting.Indented);

            HttpContent content = new StringContent(strPost, Encoding.UTF8, "application/json");

            var resposta = await _httpClient.PostAsync("posts", content);

            resposta.EnsureSuccessStatusCode();
            if (resposta.StatusCode != System.Net.HttpStatusCode.Created)
            {
                throw new InvalidOperationException("Código de Status Http 201 esperado!");
            }
        }

    }
}
