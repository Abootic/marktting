using System.ComponentModel.DataAnnotations;
namespace markettng.ViewModel
{
    public class LoginVm
    {
        [Required(ErrorMessage ="يجب ادخال اسم المستخدم")]
        public string? userName { get; set; }
        [Required(ErrorMessage = "يجب ادخال كلمة السر ")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        //   public string? Email { get; set; }
    }
}
