using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCRequest : IRequest<FacebookLoginCResponse>
    {
        public string AuthToken { get; set; }

    }
}
