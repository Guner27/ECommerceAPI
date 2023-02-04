using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCRequest : IRequest<LoginUserCResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
