using AutoMapper;
using Base.Data.DbContext;
using Base.Models.Dto;
using Base.Models.Entity;
using Base.Repositories.Interfaces;
using Base.Wrapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Base.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserRepository(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        

        public async Task<IResult<UserDto>> AddAsync(UserDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<UserDto>.FailAsync("AddUser : Null Value ");
            try
            {
                string pass = entity.Password;
                entity.Password = null;
         
                
                var usermap = new User
                {
                    UserName = entity.UserName,
                    FullName = entity.FullName,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNamber,
                    //Image = entity.Image,
                    UserType = entity.UserType,
                    State = entity.State,
                    CreatedBy = entity.CreatedBy,
                    

                };
               
                var newEntity = await _userManager.CreateAsync(usermap, pass);
                if (!newEntity.Succeeded)
                {
                    string error = string.Empty;
                    foreach (var er in newEntity.Errors)
                    {
                      
                        error = er.Description;
                     
                        
                    }
                    return await Result<UserDto>.FailAsync($"something went erro !!!\n\n\n{error}  ");
                }
                else
                {

                    //var user = await _userManager.FindByNameAsync(entity.Email);


                    //var Entitymap = new UserDto
                    //{
                    //    Id = user.Id,
                    //    UserName = user.UserName,
                    //    Email = user.Email,

                    //    FullName = user.FullName,
                    //    PhoneNamber = user.PhoneNumber,
                    //};

                    return await Result<UserDto>.SucessAsync(entity, "user  added succssfully");



                }

            }catch (Exception ex)
            {
                return await Result<UserDto>.FailAsync($"catch addAsync in user {ex.Message}");
            }



        }
     

        //public async Task<Boolean> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        //{


            
        //    var user = await _userManager.FindByEmailAsync(email);

        //    if (user != null)
        //    {
        //        return true;
        //        Console.WriteLine($"the user FindByEmailAsync has data {user.UserName} and {user.Email}");
        //    }
        //    else
        //    {

        //        return false;
        //    }





        //}

        public async Task<IResult<User>> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(id)) return await Result<User>.FailAsync(" null");
            var user = await _userManager.FindByIdAsync(id);
            
            if (user == null) return await Result<User>.FailAsync(" user not exsit");
            return await Result<User>.SucessAsync(user, "user exsit");
        }

        public async Task<IResult<UserDto>> ChangeActive(string userId,int state, CancellationToken cancellationToken = default)
        {
            try
            {

               // var user = _mapper.Map<User>(entity);
               var user= await _userManager.FindByIdAsync(userId);
                user.State = state;

                var res = await _userManager.UpdateAsync(user);
                if (res.Succeeded)
                {
                    var userDto = new UserDto
                    {
                        State = state,
                        Email = user.Email,
                        FullName = user.FullName,
                        Id = user.Id,
                       // Image = user.Image,
                        PhoneNamber = user.PhoneNumber,
                        UserName = user.UserName,
                        UserType = user.UserType,
                    };
                    //var userMap = _mapper.Map<UserDto>(res);
                    return await Result<UserDto>.SucessAsync(userDto, "ChangeActive SuccessFully");
                }
                return await Result<UserDto>.FailAsync($"Sorry!!  not  ChangeActive ");

            }
            catch (Exception ex)
            {
                return await Result<UserDto>.FailAsync($"something error in ChangeActive {ex.Message}");
            }
        }


        public async Task<IResult<UserDto>> ChangeUserType(User user, CancellationToken cancellationToken = default)
        {
            try
            {

                // var user = _mapper.Map<User>(entity);
             

                var res = await _userManager.UpdateAsync(user);
                if (res.Succeeded)
                {
                   
                    return await Result<UserDto>.SucessAsync("ChangeActive SuccessFully");
                }
                return await Result<UserDto>.FailAsync($"Sorry!!  not  ChangeActive ");

            }
            catch (Exception ex)
            {
                return await Result<UserDto>.FailAsync($"something error in ChangeActive {ex.Message}");
            }
        }

        public async Task<IResult<IEnumerable<UserDto>>> GetAll()
        {
            try
            {
                var res = await _userManager.Users.ToListAsync();
                if (res != null)
                {
                    var users = new List<UserDto>();

                    foreach (var item in res)
                    {
                        var itemMap = new UserDto       
                        {
                            Id = item.Id,
                            Email = item.Email,
                            FullName = item.FullName,
                        //    Image = item.Image,
                                
                          //   PhoneNamber = item.PhoneNamber,
                            State = item.State.Value,
                            UserName = item.UserName,
                            UserType = item.UserType,

                        };
                        users.Add(itemMap);
                    }
                    return await Result<IEnumerable<UserDto>>.SucessAsync(users, "user record");
                }
                return await Result<IEnumerable<UserDto>>.FailAsync($"user record null ");
            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<UserDto>>.FailAsync($"catch error {ex.Message}");
            }

            // return await Result<IEnumerable<UserDto>>.SucessAsync(q, "user record");
        }

        public async Task<IResult<UserDto>> RestPassword(User entity, string currentPassword,string Password, CancellationToken cancellationToken = default)
        {
            try
            {

                if (entity == null) return await Result<UserDto>.FailAsync($"Sorry!! can't change password  ",300);

                var checkPassword = await _userManager.CheckPasswordAsync(entity, currentPassword);
                if (checkPassword) { 
                var user = await _userManager.ChangePasswordAsync(entity,currentPassword, Password );
                    if (user.Succeeded)
                    {
                        return await Result<UserDto>.SucessAsync($"password rest successFully ");
                    }
                    
                }
                return await Result<UserDto>.FailAsync($"Sorry!! oldPassword incorrect ");
            }
            catch (Exception ex)
            {
                return await Result<UserDto>.FailAsync($"Sorry!! incorrect password",500);
            }
        }

        public async Task<IResult<UserDto>> RestForgttenPassword(User entity, string Password, CancellationToken cancellationToken = default)
        {
            try
            {

                if (entity == null) return await Result<UserDto>.FailAsync($"Sorry!! can't change password  ", 300);
               
                
                    var token = await _userManager.GeneratePasswordResetTokenAsync(entity);
                    var user = await _userManager.ResetPasswordAsync(entity, token, Password);
                    if (user.Succeeded)
                    {
                        return await Result<UserDto>.SucessAsync($"password rest successFully ");
                    }
                    return await Result<UserDto>.FailAsync($"Sorry!! incorrect password", 711);
            
            }
            catch (Exception ex)
            {
                return await Result<UserDto>.FailAsync($"Sorry!! incorrect password", 500);
            }
        }
    }
}
