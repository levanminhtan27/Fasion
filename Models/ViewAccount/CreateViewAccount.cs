using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Models.ViewAccount
{
    public class CreateViewAccount
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Họ và Tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [RegularExpression(@"^\+?[0-9]{3}-?([0-9]{7}|[0-9]-[0-9]{2}-[0-9]{2}-[0-9]{2}|[0-9]{3}-[0-9]{2}-[0-9]-[0-9])$",
        ErrorMessage = "Nhập đúng số điện thoại")]
        [Display(Name = "Số điện thoại")]
        public string NumberPhone { get; set; }


        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [EmailAddress(ErrorMessage = "Nhập đúng Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng")]
        [Display(Name = "Nhập lại Mật khẩu")]
        public string ConfimnPassWord { get; set; }
    }
}
