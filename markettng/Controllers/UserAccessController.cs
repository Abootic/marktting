using Base.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using markettng.Controllers.Base;
using markettng.ViewModel;
using markettng.Services;

namespace markettng.Controllers
{
    
    public class UserAccessController : BaseApiController
    {
        private readonly ISigninManager _SignManager;
        private readonly IMapper _mapper;

        public UserAccessController( ISigninManager signManager, IMapper mapper)
        {
        
            _SignManager = signManager;
            _mapper = mapper;

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (ModelState.IsValid)
            {
                Console.Write("remmmmmmmmmmmmmmmmmm " + loginVm.RememberMe);

                var res = await _SignManager.PasswordSiginAsync(loginVm.userName, loginVm.Password, loginVm.RememberMe, false);
                if (res.Status.Succeeded)
                {
                    int authrity = await _SignManager.Authrity(res.Data.UserName);
                    TempData.SetTemp<int>("role", authrity);
               
                    TempData.SetTemp<string>("userId", res.Data.Id);
                    TempData.SetTemp<string>("fullname", res.Data.Fullname);

                    return RedirectToAction("Index", "Home");

                }
                TempData["error"] = res.Status.message;
                return View(loginVm);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "يجب ادخال البيانات");
                return View(loginVm);
                
            }

       }
        public IActionResult Logout()
        {
            _SignManager.Logout();
            return RedirectToAction("Login", "UserAccess");
        }
    
    }
}
