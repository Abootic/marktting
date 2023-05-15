using Base.Common.Classes;
using Base.Models.Dto;
using Base.Models.Entity;
using Base.Wrapper;

namespace Base.Repositories.Interfaces
{
    public interface IUserRepository
    {

        Task<IResult<UserDto>> ChangeActive(string userId, int state, CancellationToken cancellationToken = default);
        Task<IResult<UserDto>> ChangeUserType(User user, CancellationToken cancellationToken = default);


        Task<IResult<UserDto>> AddAsync(UserDto entity, CancellationToken cancellationToken = default);
        Task<IResult<UserDto>> RestPassword(User entity,string currentPassword, string Password, CancellationToken cancellationToken = default);
        Task<IResult<UserDto>> RestForgttenPassword(User entity,string Password, CancellationToken cancellationToken = default);
        
       // Task<IResult<IEnumerable<UserDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<UserDto>>> GetAll();
        Task<IResult<User>> FindByIdAsync(string id, CancellationToken cancellationToken = default);
      
      //  Task<Boolean> FindByEmailAsync(string email, CancellationToken cancellationToken = default);

    }
}
