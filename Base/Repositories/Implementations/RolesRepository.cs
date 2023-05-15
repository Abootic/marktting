
using Microsoft.AspNetCore.Identity;
using Base.Models.Dto;
using Base.Repositories.Interfaces;
using Base.Models.Entity;
using Base.Wrapper;
using Microsoft.EntityFrameworkCore;
using Base.Data.DbContext;
using System.Data;

namespace Base.Repositories.Implementations
{
    public class RolesRepository :IRolesRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RolesRepository(RoleManager<IdentityRole> roleManager, UserManager<User> userManager) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        //public RolesRepository(RoleManager<IdentityRole> roleManager, UserManager<User> userManager) 
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}

        public async Task<IResult<RolesDto>> AddRoleAsync(RolesDto entity, CancellationToken cancellationToken = default)
        {
            try
            {
                
                if (entity == null) return await Result<RolesDto>.FailAsync("role entity is null");
                var roleEntity = new IdentityRole
                {
                   // Id = entity.Id,
                    Name = entity.Name,
                };
                var res = await _roleManager.CreateAsync(roleEntity);
                if (!res.Succeeded)
                {
                    string error = string.Empty;
                    foreach (var er in res.Errors)
                    {

                        error = er.Description;


                    }
                    return await Result<RolesDto>.FailAsync($"Roles something went erro !!!\n\n\n{error}  ");

                }
                else
                {
                  
                    var item = await _roleManager.FindByNameAsync(entity.Name);
                    var itemMap = new RolesDto
                    {
                        
                        Name = entity.Name,
                    };

                    return await Result<RolesDto>.SucessAsync(itemMap, "Role Created succssfully");
                }
                return await Result<RolesDto>.FailAsync("Sorry Role Not add",711);
            }   
            catch (Exception ex)
            {
                return await Result<RolesDto>.FailAsync($"catch AddRoleAsync something Error {ex.InnerException.Message} ");
            }
        }

        public async Task<IResult<UserAndRolesDto>> AddRoleToUserAsync(UserAndRolesDto entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(entity.UserId);

               
                if (user!=null)
                {
                    var roles=await _roleManager.RoleExistsAsync(entity.RoleName);
                  
                    if (roles)
                    {
                        var userRes = await _userManager.AddToRoleAsync(user, entity.RoleName);
                        if (!userRes.Succeeded)
                        {
                            string error = string.Empty;
                            foreach (var er in userRes.Errors)
                            {

                                error = er.Description;


                            }
                            return await Result<UserAndRolesDto>.FailAsync($"UserAndRoles something went erro !!!\n\n\n{error}  ");
                        }
                        else
                        {
                            // var itemMap=await _userManager.get

                            return await Result<UserAndRolesDto>.SucessAsync("UserAndRoles Created succssfully");
                        }
                    }
                    return await Result<UserAndRolesDto>.FailAsync($"Sorry! --> this RoleName {entity.RoleName} Not Exsit  ",800);
                }
                return await Result<UserAndRolesDto>.FailAsync($"Sorry! --> this User Not Exsit  ", 801);
            }
            catch (Exception ex)
            {
                return await Result<UserAndRolesDto>.FailAsync($"catch UserAndRoles something Error {ex.Message}");
            }
        }

        

        public async Task<IResult<IEnumerable<RolesDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            try{
                var res =await _roleManager.Roles.AsNoTracking().ToListAsync();
                if (res != null)
                {
                    var roles = new List<RolesDto>();
                    foreach (var role in res)
                    {
                        var itemMap = new RolesDto
                        {
                            Id = role.Id,
                            Name = role.Name,

                        };
                        roles.Add(itemMap);
                    }
                    return await Result<IEnumerable<RolesDto>>.SucessAsync(roles, "roles record");
                }
                return await Result<IEnumerable<RolesDto>>.FailAsync($"roles record null ",710);
            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<RolesDto>>.FailAsync($"catch error {ex.Message}",712);
            }
        }

        public Task<IResult<RolesDto>> GetRoleByUserAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<IEnumerable<UserAndRolesDto>>> GetUserInRole(string roleName, CancellationToken cancellationToken = default)
        {
            try
            {
                
                List<UserAndRolesDto>userAndRoles=new List<UserAndRolesDto>();
                var checkRole = await _roleManager.RoleExistsAsync(roleName);
                if (checkRole)
                {
                    
                    var res = await _userManager.GetUsersInRoleAsync(roleName);
                   
                    
                    if (res!=null) {
                      

                        var roles = res.ToList();
                        foreach (var role in roles)
                        {
                            
                            userAndRoles.Add(new UserAndRolesDto
                            {
                                UserId = role.Id,
                                fullName = role.FullName,
                            });
                        }
                        return await Result<IEnumerable<UserAndRolesDto>>.SucessAsync(userAndRoles, "UserAndRoles retrive");
                    }
                  
                    return await Result<IEnumerable<UserAndRolesDto>>.FailAsync("user not exsit in role");
                }
                return await Result<IEnumerable<UserAndRolesDto>>.FailAsync("role not exsit");

            }
            catch (Exception ex)
            {
               
                return await Result<IEnumerable<UserAndRolesDto>>.FailAsync($"catch error {ex.Message}", 500);
            }
        }


        public async Task<IResult<RolesDto>> IsUserInRoleAsync(User user,string roleName)
        {
            try
            {

                var check =  await _userManager.IsInRoleAsync(user, roleName);
                if (check)
                {
                    return await Result<RolesDto>.SucessAsync("yes user exsity in role");
                }
                return await Result<RolesDto>.FailAsync($"user not exsit in role", 500);
            }
            catch (Exception ex)
            {
                return await Result<RolesDto>.FailAsync($"catch error {ex.Message}", 500);
            }
        } 
       public async Task<IResult<RolesDto>> RemoveRoleFromUser(User user,string roleName)
        {
            try
            {
                var del = await _userManager.RemoveFromRoleAsync(user, roleName);
                if(del.Succeeded)
                {
                    return await Result<RolesDto>.SucessAsync("yes delete role from user successfully");
                }
                return await Result<RolesDto>.FailAsync($"Sorry could not delete role from user", 500);
            }
            catch (Exception ex)
            {
                return await Result<RolesDto>.FailAsync($"catch error {ex.Message}", 500);
            }
        }
        public Task<IResult<RolesDto>> RemoveRoleAsync(RolesDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<RolesDto>> UpdateRoleAsync(RolesDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
