using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project5_trangdocbao.Areas.Admin.Models;
using Model.DAO;
using Project5_trangdocbao.Common;


namespace Project5_trangdocbao.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/

        public ActionResult Index()
        {
            var sesA = (UserInfo)Session[CommonConstant.ADMIN_SESSION];
            var sesU = (UserInfo)Session[CommonConstant.USER_SESSION];
            if (sesA!=null)
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                if(sesU!=null)
                {
                    return RedirectToAction("Index", "HomeUser");
                }
            }
            return View();
        }








        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                var result = dao.loginAccount(model.TenTaiKhoan, (model.MatKhau));
                switch (result)
                {
                        //Đăng nhập quyền admin
                    case 1:
                        {
                            var user = dao.GetByID(model.TenTaiKhoan);
                            var userSession = new UserInfo();
                            userSession.Username = user.TenTaiKhoan;
                            userSession.UserID = user.IDTaiKhoan;
                            Session.Add(Common.CommonConstant.ADMIN_SESSION, userSession);
                            Session["USER_ID"] = userSession.UserID;
                            return RedirectToAction("Index", "HomeAdmin");
                            break;
                        }
                    //Đăng nhập quyền người đăng
                    case 2:
                        {
                            var userId = dao.GetByID(model.TenTaiKhoan);
                            var userSession = new UserInfo();
                            userSession.Username = userId.TenTaiKhoan;
                            userSession.UserID = userId.IDTaiKhoan;
                            Session.Add(Common.CommonConstant.USER_SESSION, userSession);
                            Session["USER_Name"] = userSession.Username;
                            Session["USER_ID"] = userSession.UserID;
                            return RedirectToAction("MyPost", "UserPostManager");
                            break;
                        }

                        //Đăng nhập trường hợp tài khoản bị khóa
                    case -1:
                        {
                            ModelState.AddModelError("", "Tài khoản này đã bị khóa!");
                            break;

                        }

                    //Đăng nhập trường hợp sai mật khẩu
                    case -2:
                        {
                            ModelState.AddModelError("", "Mật khẩu không đúng!");
                            break;
                        }

                    //Đăng nhập trường hợp sai tên tài khoản
                    case 0:
                        {
                            ModelState.AddModelError("", "Tài khoản không tồn tại.");
                            break;
                        }
                }

            }
            return View("Index");
        }

    }
}
