using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace YS.CMS.Infra.HttpClients.Model
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
