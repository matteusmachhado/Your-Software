﻿using System.Net.Http;
using System.Threading.Tasks;
using YS.CMS.Infra.CrossCutting.Clients.Internal.Http.Models;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Infra.CrossCutting.Clients.Internal.Http.Controllers
{
    public class AuthCliente
    {
        private readonly HttpClient _httpClient;

        public AuthCliente(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResultModel> PostLoginAsync(LoginModel model)
        {
            var result = await _httpClient.PostAsJsonAsync<LoginModel>("login", model);
            return new LoginResultModel(await result.Content.ReadAsStringAsync(), result.StatusCode);
        }

        public async Task PostRegisterAsync(RegisterModel model)
        {
            var result = await _httpClient.PostAsJsonAsync<RegisterModel>("register", model);
            result.EnsureSuccessStatusCode();
        }
    }
}
