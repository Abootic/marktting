using Base.Models.Dto;

namespace markettng.ViewModel
{
    public class UserAndRoleVm
    {
        public IEnumerable<UserDto> data { get; set; }
        public UserDto obj { get; set; }
        public UserAndRolesDto userAndRolesDto { get; set; }
        
    }
}
