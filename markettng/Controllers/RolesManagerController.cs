using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;
using markettng.Controllers.Base;
using markettng.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace markettng.Controllers
{

    [Authorize(Roles = "admin")]
    public class RolesManagerController : BaseApiController
    {
            private readonly IMapper _mapper;

        public RolesManagerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //[HttpGet("GetAllRoles")]
        //[Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index()
        {
            CommonVm<RolesDto> vm = new CommonVm<RolesDto>();
            vm.obj=new RolesDto();
            var res = await RepositoryManager.RolesRepository.GetAll();
            if (res.Status.Succeeded)
            {
                vm.data = res.Data;
                return PartialView("Index",vm);
            }
            return BadRequest($"{res.Status.message}"+"  __ "+$" {res.Status.code}");

        }

        // GET api/<RolesManagerController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RolesManagerController>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add( RolesDto rolesDto)
        {
            if(rolesDto == null) return BadRequest("the data is null");
            var res=await RepositoryManager.RolesRepository.AddRoleAsync(rolesDto);
            if (res.Status.Succeeded)
            {
                
              
                return Ok(res.Status.message);
            }

            return BadRequest($"{res.Status.message}" + "  __ " + $" {res.Status.code}");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoleToUser(UserAndRolesDto userAndRolesDto)
        {
           // bool suceess=false;
            if (userAndRolesDto == null) return BadRequest("the data is null");
          
            var res = await RepositoryManager.RolesRepository.AddRoleToUserAsync(userAndRolesDto);
            if (res.Status.Succeeded)
            {
                var user = await RepositoryManager.UserRepository.FindByIdAsync(userAndRolesDto.UserId);
                user.Data.UserType = userAndRolesDto.RoleName;
              var update=  await RepositoryManager.UserRepository.ChangeUserType(user.Data);
                if (update.Status.Succeeded)
                {
                    return Ok(update.Status.message);
                }
                else
                {
                    return BadRequest(update.Status.message);
                }
               
               // return Ok(res.Status.message);

            }

            return BadRequest($"{res.Status.message}" + "  __ " + $" {res.Status.code}");

        }
        public async Task<IActionResult> RemoveRoleFromUser(string id)
        {
            bool suceess= false;
            string message = "";

            var user = await RepositoryManager.UserRepository.FindByIdAsync(id);
            if (user.Status.Succeeded)
            {
                message = user.Status.message;
                suceess = true;
                var roles = await RepositoryManager.RolesRepository.GetAll();
                if (roles.Status.Succeeded)
                {
                    message = roles.Status.message;
                    suceess = true;
                    var role = roles.Data.Select(a => a.Name).ToList();
                    foreach (var roleName in role)
                    {
                        var check = await RepositoryManager.RolesRepository.IsUserInRoleAsync(user.Data, roleName);
                        if (check.Status.Succeeded)
                        {
                            message = check.Status.message;
                            suceess = true;
                            var del = await RepositoryManager.RolesRepository.RemoveRoleFromUser(user.Data, roleName);
                            if (del.Status.Succeeded)
                            {
                                message = del.Status.message;
                                suceess =true;
                            }
                            else
                            {
                                message = del.Status.message;
                                suceess = false;
                            }
                        }
                        else
                        {
                            message = check.Status.message;
                            suceess = false;
                        }
                    }
                }
                else
                {
                    message = roles.Status.message;
                    suceess = false;
                }


            }
            else
            {
                message = user.Status.message;
                suceess = false;
            }
            if (suceess)
            {
                return Ok(message);
            }
            return BadRequest(message);

        }
    }
}
