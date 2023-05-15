using Base.Common.Interface;

namespace markettng.Services
{
    public class CurrentUserServices : ICurrentUserServices
    {
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
