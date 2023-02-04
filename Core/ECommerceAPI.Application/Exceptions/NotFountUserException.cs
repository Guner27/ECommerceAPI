using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Exceptions
{
    public class NotFountUserException : Exception
    {
        public NotFountUserException() : base("Kullanıcı adı veya şifre hatalı!")
        {
        }

        public NotFountUserException(string? message) : base(message)
        {
        }

        public NotFountUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
