using ECommerceAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCResponse
    {
    }
    public class LoginUserSuccessCResponse : LoginUserCResponse
    {
        public Token Token { get; set; }
    }
    public class LoginUserErrorCResponse : LoginUserCResponse
    {
        public string Message { get; set; }
    }
}
