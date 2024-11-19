using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Clinica.Domain.Entities;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;

namespace Clinica.Infrastructure.Identity
{
    public interface ITokenGenerator
    {
        string GetAudienceAddress();

        Task<string> GetRefreshToken(ApplicationUser user);

        string GetToken(ApplicationUser userInfo, IList<string> roles);

        Task<string> GetResetPasswordToken(ApplicationUser user);

    }

        public class TokenGenerator : ITokenGenerator
    {
        #region Private Fields

        private readonly JwtSettings jwtSettings;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly ITokenService tokenService;

        #endregion Private Fields

        #region Public Constructors

        public TokenGenerator(JwtSettings jwtSettings, ITokenService tokenService, UserManager<User> userManager)
        {
            this.jwtSettings = jwtSettings;
            this.tokenService = tokenService;
            this.userManager = userManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public string GetAudienceAddress()
        {
            return this.jwtSettings.Audience;
        }

        public async Task<string> GetRefreshToken(ApplicationUser user)
        {
            var tokenString = this.GenerateRefreshToken();
            await tokenService.Add(user, tokenString, TokenType.RefreshToken);

            return tokenString;
        }

        public async Task<string> GetResetPasswordToken(ApplicationUser user)
        {
            var token = await this.userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            return validToken;
        }

        public string GetToken(ApplicationUser userInfo, IList<string> userRoles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("user", userInfo.UserName),
                new Claim("firstName", userInfo.FirstName),
                new Claim("lastName", userInfo.LastName),
                new Claim("userId", userInfo.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(userRoles.Select(role => new Claim("role", role)));

            var token = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion Public Methods

        #region Private Methods

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        #endregion Private Methods
    }
}