using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EntityFramework;
using Model.DAO;
using PagedList;
using Project5_trangdocbao.Common;

namespace Project5_trangdocbao.Areas.Admin.Controllers
{
    public class UserManagerController : Controller
    {
        //
        // GET: /Admin/UserManager/

        DocBaoDataContext db = new DocBaoDataContext();


        int sesidtk = 0;
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {

            //Lấy id của tài khoản hiện tại
            sesidtk = int.Parse(Session["USER_ID"].ToString());
            var dao = new AccountDao();
            var model = dao.ListAll(searchString, page, pageSize, sesidtk);
            ViewBag.searchstring = searchString;
            return View(model);
        }



        public ActionResult AccountInfo()
        {
            var dao = new AccountDao();
            var id = int.Parse(Session["USER_ID"].ToString());
            var user = dao.ViewDetail(id);
            ViewBag._k_news = dao.ViewDetail1(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            var dao = new AccountDao();
            var id = int.Parse(Session["USER_ID"].ToString());
            var user = dao.ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult ChangePasswordPost(TAIKHOAN taikhoan)
        {
            taikhoan.IDTaiKhoan = int.Parse(Session["USER_ID"].ToString()); //id taikhoan
            bool result = new AccountDao().changePassword(taikhoan);
            if (result == true)
                TempData["AlertMessage"] = "abc";
            return RedirectToAction("ChangePassword");
        }
        public ActionResult LogoutUser()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
