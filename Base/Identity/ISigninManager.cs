
using Base.Models.Dto;
using Base.Models.Entity;
using Base.Wrapper;


namespace Base.Identity
{
    public interface ISigninManager
    {
        public Task<int> Authrity(string username);
        public Task<IResult<UserTokenRequst>> PasswordSiginAsync(string username, string password, bool isPerisistent, bool LockOutoNFauilar);
        public Task<IResult<UserTokenRequst>> PasswordSiginByEmailAsync(string username, string password, bool isPerisistent, bool LockOutoNFauilar);
        public void Logout();
    }
}
