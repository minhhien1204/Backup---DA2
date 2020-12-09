using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project5_trangdocbao.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nhập tên tài khoản!")]
        public string TenTaiKhoan { set; get; }
        [Required(ErrorMessage = "Nhập mật khẩu!")]
        public string MatKhau { set; get; }
        public bool remember { set; get; }
    }
}