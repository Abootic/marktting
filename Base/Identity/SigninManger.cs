using Base.Models.Dto;
using Base.Models.Entity;
using Base.Wrapper;
using Microsoft.AspNetCore.Identity;

namespace Base.Identity
{
    public class SigninManger : ISigninManager
    {
        private readonly SignInManager<User> _signinManger;
        public SigninManger(SignInManager<User> signinManger)
        {
            _signinManger = signinManger;
        }
        public async Task<int> Authrity(string username)
        {
            try
            {
                int rolestate = 0;
                var us=await _signinManger.UserManager.FindByNameAsync(username);
                //var res = await _signinManger.UserManager.IsInRoleAsync(us, "admin");
                var res = await _signinManger.UserManager.GetRolesAsync(us);
                if (res!=null)
                {
                    foreach (var role in res)
                    {
                        if (role == "admin")
                        {
                            rolestate = 1;
                        }
                        else if (role == "manager")
                        {
                            rolestate = 2;
                        }
                        else if(role=="user") {
                            rolestate = 3;
                        }
                        else
                        {
                            rolestate = 3;
                        }
                    }
                  
                }
                return rolestate;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public async void Logout()
        {
          
            await _signinManger.SignOutAsync();

        }

        public async Task<IResult<UserTokenRequst>> PasswordSiginAsync(string username, string password, bool isPerisistent, bool LockOutoNFauilar)
        {
            //try
            //{

            var user = await _signinManger.UserManager.FindByNameAsync(username);
            if (user == null)
            {
                
                return await Result<UserTokenRequst>.FailAsync($"the user that has this username {username} not Exsit ");

            }
             var res = await _signinManger.PasswordSignInAsync(username, password, isPerisistent, LockOutoNFauilar);
           // var res = await _signinManger.CheckPasswordSignInAsync(user, password, LockOutoNFauilar,isPerisistent);
            if (res.IsLockedOut)
            {
                return await Result<UserTokenRequst>.FailAsync("acount lock too many atmate");
            }

            if (res.Succeeded)
            {
                return Result<UserTokenRequst>.Sucess(new UserTokenRequst
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = password,
                    UserName = user.UserName,
                   Fullname = user.FullName,

                });
            }
            else
            {
                return Result<UserTokenRequst>.Fail("invalid Login ", 401);
            }
            //}catch (Exception ex)
            //{
            //    return await Result<UserTokenRequst>.FailAsync($"catch sgin by username Login {ex.Message} ");

            //}
        }

        public async Task<IResult<UserTokenRequst>> PasswordSiginByEmailAsync(string Email, string password, bool isPerisistent, bool LockOutoNFauilar)
        {
            try
            {
                var user = await _signinManger.UserManager.FindByEmailAsync(Email);

                Console.WriteLine("the eamil from PasswordSiginByEmailAsync is " + Email);

                if (user == null)
                {
                    Console.WriteLine($"the user that has this Email {Email} not Exsit ");
                    return await Result<UserTokenRequst>.FailAsync($"the user that has this Email {Email} not Exsit ");

                }
                var res = await _signinManger.CheckPasswordSignInAsync(user, password, LockOutoNFauilar);
                if (res.IsLockedOut)
                {
                    return await Result<UserTokenRequst>.FailAsync("Acoount locked to many atmpate ");

                }
                return res.Succeeded ? Result<UserTokenRequst>.Sucess(new UserTokenRequst
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = password,
                    UserName = user.UserName,

                }) : Result<UserTokenRequst>.Fail("invalid Login ", 401);
            }
            catch (Exception ex)
            {
                return await Result<UserTokenRequst>.FailAsync($"catch sgin by email Login {ex.Message} ");
            }
        }


    }
}
