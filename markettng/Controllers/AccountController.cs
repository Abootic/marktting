using AutoMapper;
using Base.Common.Interface;
using Base.Models.Dto;
using Base.Models.Entity;
using markettng.Controllers.Base;
using markettng.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using markettng.Filter;
using markettng.Services;
using Base.Identity;
using Microsoft.AspNetCore.Identity;
namespace markettng.Controllers
{

   [Authorize(Roles = "admin")]
    public class AccountController : BaseApiController
    {
        private readonly IHttpContextAccessor _contextAccessor;
      
        private readonly IMapper _mapper;
        private readonly ISigninManager _SignManager;
     

        public AccountController(IHttpContextAccessor contextAccessor, IMapper mapper, ISigninManager signManager)
        {
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            _SignManager = signManager;

        }

        public IActionResult AccessDenaid()
        {
            return View();
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            UserAndRoleVm userAndRoleVm=new UserAndRoleVm();
            userAndRoleVm.obj = new UserDto();
            userAndRoleVm.userAndRolesDto = new UserAndRolesDto();
            var res = await RepositoryManager.UserRepository.GetAll();
            if (res.Status.Succeeded)
            {
               
                userAndRoleVm.data = res.Data;
                return PartialView(nameof(Index), userAndRoleVm);
                //return Ok(res);
            }
            return BadRequest(res.Status.message);
        }




        [Authorize(Roles = "admin")]
        [HttpPost("ChangeActive")]
        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> ChangeActive(ChangeActiveVm changeActiveVm)
        {

            var res = await RepositoryManager.UserRepository.ChangeActive(changeActiveVm.UserId, changeActiveVm.state);
            if (res.Status.Succeeded)
            {
                return Ok(res);
            }
            return BadRequest(res);


        }
        [Authorize(Roles = "admin")]
        public IActionResult ChangePassword()
        {
            return PartialView();
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ChangePassword(ChangePasswordVm changePasswordVm)
        {

            var res = await RepositoryManager.UserRepository.FindByIdAsync(changePasswordVm.userId);
            if (res.Status.Succeeded)
            {
                var changePassResuilt = await RepositoryManager.UserRepository.RestPassword(res.Data, changePasswordVm.currentPassword, changePasswordVm.password);
                if (changePassResuilt.Status.Succeeded)
                {
                    return Ok(changePassResuilt);
                }
                return BadRequest(changePassResuilt);
            }
            return BadRequest(res);


        }
        // POST api/<AccountController>

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        [CurrentUserFiltterAttrubite()]
       
        public async Task<IActionResult> RegisterUser(UserDto userDto)
        {
            var UserName = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            userDto.CreatedBy=UserName;
            //userDto.UserType = "user";
            var res = await RepositoryManager.UserRepository.AddAsync(userDto);
            if (res.Status.Succeeded)
            {
              
                return Ok(res.Status.message);
            }

            else
            {
                return BadRequest(res.Status.message);
            }

        }
      
    }
}
