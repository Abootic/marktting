


namespace Base.Models.Dto.Auth
{
    public class RefreashToken
    {
        public string  Token { get; set; }
        public DateTime Created { get; set; }= DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
