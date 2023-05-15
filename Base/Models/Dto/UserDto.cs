using System;
using System.ComponentModel.DataAnnotations;

namespace Base.Models.Dto
{
    public class UserDto
    {
        public string? Id { get; set; }
        [Display(Name = "الاسم")]
        public string FullName { get; set; }
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; } = null!;
        [Display(Name = "رقم الهاتف")]
        public string PhoneNamber { get; set; }
        //public string? Image { get; set; }
        [Display(Name = "كلمة السر")]
        public string Password { get; set; }
        [Display(Name = " تأكيد كلمة السر ")]
        public string? ConfirmPassword { get; set; }
        [Display(Name = "نوع المستخدم")]
        public string UserType { get; set; }
        public int State { get; set; } = 1;
        public string? CreatedBy { get; set; }
        public string? LastModfiedBy { get; set; }
      
        public string? DeletedBy { get; set; }

    }
}
