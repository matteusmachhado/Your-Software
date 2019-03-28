﻿using System.Net.Http;
using System.Threading.Tasks;
using YS.CMS.Infra.CrossCutting.Clients.Core.Http.Models;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Infra.CrossCutting.Clients.Core.Http.Controllers
{
    public class AuthProviderClient
    {
        private readonly HttpClient _httpClient;

        public AuthProviderClient(HttpClient httpClient)
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