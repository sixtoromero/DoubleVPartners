using DoubleVPartners.Application.DTO;
using DoubleVPartners.Transversal.Common;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace DoubleVPartners.Services.WebAPIRest.Helpers
{
    public static class General
    {
        public static string BuildToken(UsuarioDTO model, AppSettings _appSettings)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.NombreUsuario!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                                claims: claims,
                                expires: DateTime.Now.AddMinutes(60),
                                signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
