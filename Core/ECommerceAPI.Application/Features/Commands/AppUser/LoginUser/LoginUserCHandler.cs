using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P = ECommerceAPI.Domain.Entities.Identity;

namespace ECommerceAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCHandler : IRequestHandler<LoginUserCRequest, LoginUserCResponse>
    {
        readonly UserManager<P.AppUser> _userManager;
        readonly SignInManager<P.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCHandler(
            UserManager<P.AppUser> userManager,
            SignInManager<P.AppUser> signInManager,
            ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCResponse> Handle(LoginUserCRequest request, CancellationToken cancellationToken)
        {
            P.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail); //ilk önce kullanıcı adı içerisinde ara!

            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);    //KullanıcıAdı olarak yoksa Email içerisinde ara!
            if (user == null)
                throw new NotFountUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)   //Authentication başarılı!
            {
                Token token = _tokenHandler.CreateAccessToken(10);
                return new LoginUserSuccessCResponse()
                {
                    Token = token,
                };
            }
            //return new LoginUserErrorCResponse()
            //{
            //    Message = "Kullanıcı adı veya şifre hatalı.."
            //};
            throw new AuthenticationErrorException();
        }
    }
}
