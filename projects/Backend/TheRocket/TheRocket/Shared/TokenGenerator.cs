using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TheRocket.Shared
{
    public static class JwtTokenGenerator
    {
        public static string Generate(IList<string>? roles,string UserId,int AccountId,string Emial,string UserName)
        {
            List<Claim> claims = new();
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim(ClaimTypes.Email,Emial));
            claims.Add(new Claim("UserId",UserId));
            claims.Add(new Claim("UserName",UserName));
            claims.Add(new Claim("AccountId",AccountId.ToString()));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_123456"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                            claims: claims,
                            // expires: DateTime.Now.AddMinutes(1),
                            signingCredentials: credentials

                        );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


    }
}