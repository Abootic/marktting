using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models.Dto.Auth
{
    public class AuthResult
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime  ExpiresIn { get; set; }
        public DateTime RefreshTokenExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public UserDto user { get; set; }
        public DateTime CreationTime { get; set; }
       // public string username { get; set; }
    }
}
