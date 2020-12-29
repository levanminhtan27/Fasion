using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Models.ViewAccount
{
    public class LoginViewAccount
    {
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [EmailAddress(ErrorMessage = "Nhập đúng Email")]
        public string Email { get; set; }


        [Display(Name = "Mật Khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Ghi nhớ mật khẩu")]
        public bool RememberMe { get; set; }
    }
}
