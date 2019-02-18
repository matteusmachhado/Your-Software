using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Infra.Security.Handler
{
    public class TokenJWTHandler
    {
        private readonly string securityKey = "ys-cms-wabapi-authentication-provider-valid";

        public string GeneratorToken(LoginModel model)
        {
            var direitos = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, model.Login),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YS.CMS.Apps.WebApp",
                audience: "Postman",
                claims: direitos,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddMinutes(30)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
