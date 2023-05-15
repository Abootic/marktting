using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models.Dto.Auth
{
    public class UserClaim
    {
        public List<Claim> ClaimList { get; set; }
        public UserDto userData { get; set; }
        
    }
}
