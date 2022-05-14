using OAuthTokenAPI.Business.Entities;
using OAuthTokenAPI.Data.Interfaces;
using OAuthTokenAPI.Data.Constants;
using System.Threading.Tasks;
using System.Collections.Generic;
using JWT.Algorithms;
using JWT.Serializers;
using JWT;
using JWT.Builder;
using System;

namespace OAuthTokenAPI.Data.Services
{
    public class TokenService : ITokenService
    {
        public TokenDetails Create(Payload payload)
        {
            var accessTokenPayload = new Dictionary<string, dynamic>()
            {
                { "username", payload.Username },
                { "password", payload.Password },
                { "exp", DateTime.Now.AddSeconds(TokenConstant.AccessExpiry) }
            };

            var refreshTokenPayload = new Dictionary<string, dynamic>()
            {
                { "username", payload.Username },
                { "password", payload.Username },
                { "exp", DateTime.Now.AddSeconds(TokenConstant.RefreshExpiry) }
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var accessToken = encoder.Encode(accessTokenPayload, TokenConstant.AccessSecret);
            var refreshToken = encoder.Encode(refreshTokenPayload, TokenConstant.RefreshSecret);

            return new TokenDetails()
            {
                AccessToken = accessToken,
                ExpiresIn = TokenConstant.AccessExpiry,
                RefreshToken = refreshToken
            };
        }
    }
}
