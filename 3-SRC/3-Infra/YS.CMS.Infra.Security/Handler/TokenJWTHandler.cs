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
        public string GeneratorToken(LoginModel model, string securityKey, string issuer, string audience, double expiresMinutes)
        {
            var direitos = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, model.Login),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: direitos,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddMinutes(expiresMinutes)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
