using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.DTOs.Facebook;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ECommerceAPI.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCHandler : IRequestHandler<FacebookLoginCRequest, FacebookLoginCResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly HttpClient _httpClient;

        public FacebookLoginCHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, ITokenHandler tokenHandler, HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _httpClient = httpClientFactory.CreateClient();

        }

        public async Task<FacebookLoginCResponse> Handle(FacebookLoginCRequest request, CancellationToken cancellationToken)
        {
            string accessTokenResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token_id=1740624603088547&client_secret=0a114d448317ed37076207e4f0edfcce&grant_type=client_credentials");

            FacebookAccessTokenResponse facebookAccessTokenResponse =
                JsonSerializer.Deserialize<FacebookAccessTokenResponse>(accessTokenResponse);
            string userAccessTokenValidaation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={facebookAccessTokenResponse.AccessToken}");

            FacebookUserAccessTokenValidation validation =
                JsonSerializer.Deserialize<FacebookUserAccessTokenValidation>(userAccessTokenValidaation);

            if (validation.Date.IsValid)
            {
                string userInfoResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?/fields=email,name&access_token={request.AuthToken}");
                FacebookUserInfoResponse userInfo = JsonSerializer.Deserialize<FacebookUserInfoResponse>(userInfoResponse);

                var info = new UserLoginInfo("FACEBOOK", validation.Date.UserId, "FACEBOOK");
                Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

                bool result = user != null; //user, null değilse result'a True ver.
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(userInfo.Email); //Eğer bu Emaile Karşılık bir user varsa onu getir.

                    if (user == null) //Eğer ki yine null ise bu Kullanıcı Veritabanında yok
                    {
                        //Bu kullanıcı için VT da yeni bir user oluştur;
                        user = new()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Email = userInfo.Email,
                            UserName = userInfo.Email,
                            NameSurname = userInfo.Name
                        };
                        var identityResult = await _userManager.CreateAsync(user);
                        result = identityResult.Succeeded;
                    }
                }
                if (result)
                {
                    await _userManager.AddLoginAsync(user, info);
                    Token token = _tokenHandler.CreateAccessToken(5);
                    return new()
                    {
                        Token = token,
                    };
                }
            }
            throw new Exception("Invalid external authentication");
        }
    }
}
