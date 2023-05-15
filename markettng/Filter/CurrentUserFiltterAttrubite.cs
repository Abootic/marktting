using Base.Common.Interface;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;


namespace markettng.Filter
{
    public class CurrentUserFiltterAttrubite : ActionFilterAttribute
    {




        public override void OnActionExecuting(ActionExecutingContext FilterContext)
        {
            try
            {
               var IsAuthenticated = FilterContext.HttpContext?.User.Identity.IsAuthenticated;
                if (IsAuthenticated.Value)
                {
                    var httpContextAccessor = FilterContext.HttpContext?.RequestServices.GetService<ICurrentUserServices>();
                    var UserName = FilterContext.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
                    //   var UserId = FilterContext.HttpContext?.User?.FindFirst(x => x.Value == ClaimTypes.NameIdentifier);
                    httpContextAccessor.UserName = UserName;
                    httpContextAccessor.IsAuthenticated = IsAuthenticated.Value;
                }

            }
            catch (Exception ex)
            {
                

                throw UnauthorizedAccessException(ex);
            }

            base.OnActionExecuting(FilterContext);

        }

        private Exception UnauthorizedAccessException(Exception ex)
        {
            throw new NotImplementedException("not authorized 401 ");
        }


    }
}
