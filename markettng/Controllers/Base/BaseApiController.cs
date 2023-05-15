using Base.Common.Interface;
using Base.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace markettng.Controllers.Base
{
    
    public class BaseApiController : Controller
    {
        private IRepositoryManager _RepositoryManager { get; set; }
        private IServiceManager _ServiceManager { get; set; }
        protected IRepositoryManager RepositoryManager => _RepositoryManager ??= HttpContext.RequestServices.GetService<IRepositoryManager>();
        public IServiceManager ServiceManager => _ServiceManager ??= HttpContext.RequestServices.GetService<IServiceManager>();
    }
}
