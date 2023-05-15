

using Base.Models.Dto;
using Base.Models.Entity;
using Base.Wrapper;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace Base.Repositories.Interfaces
{
    public interface IRolesRepository
    {
        Task<IResult<RolesDto>> AddRoleAsync(RolesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<UserAndRolesDto>> AddRoleToUserAsync(UserAndRolesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<RolesDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<UserAndRolesDto>>> GetUserInRole(string roleName,CancellationToken cancellationToken = default);
        Task<IResult<RolesDto>> IsUserInRoleAsync(User user, string roleName);
        Task<IResult<RolesDto>> UpdateRoleAsync(RolesDto entity);
        Task<IResult<RolesDto>> RemoveRoleAsync(RolesDto entity);
        Task<IResult<RolesDto>> RemoveRoleFromUser(User user, string roleName);
        Task<IResult<RolesDto>> GetRoleByUserAsync(int Id);
      
    }
}
