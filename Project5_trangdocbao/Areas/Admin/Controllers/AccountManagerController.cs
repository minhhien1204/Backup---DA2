using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EntityFramework;
using Project5_trangdocbao.Common;
using PagedList;

namespace Project5_trangdocbao.Areas.Admin.Controllers
{
    public class AccountManagerController : BaseAdminController
    {
        //
        // GET: /Admin/AccountManager/
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




        //Lấy ra danh sách các tài khoản quyền ADMIN
        public ActionResult ListAdmin(string searchString, int page = 1, int pageSize = 5)
        {
            sesidtk = int.Parse(Session["USER_ID"].ToString());
            var dao = new AccountDao();
            var model = dao.ListAllAdmin(searchString, page, pageSize, sesidtk);
            return View(model);
        }


        //Lấy ra danh sách người đăng
        public ActionResult ListPoster(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new AccountDao();
            var model = dao.ListAllPoster(searchString, page, pageSize);
            return View(model);
        }
    


        //Cập nhật thông tin tài khoản
        
        public ActionResult UpdateAccount(int id)
        {
            var dao = new AccountDao();
            var user=dao.ViewDetail(id);
            ViewBag.AnhDaiDien = user.AnhDaiDien;
            return View(user);
        }




        [HttpPost]
        public ActionResult UpdateAccount(TAIKHOAN tk)
        {
            if (tk != null) //Nếu tk co du lieu cap nhat thi xu li tiep
            {
                var DAO = new AccountDao();
                //var passmd5 = Encryptor.MD5Hash(tk.MatKhau);
                //tk.MatKhau = passmd5;
                var result = DAO.updateAccount(tk);
                if (result)
                {
                    return RedirectToAction("Index", "AccountManager");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }

            }
            return View("Index");
        }

        public ActionResult AccountInfo(int id)
        {
            var dao = new AccountDao();
            var user = dao.ViewDetail(id);
            ViewBag._k_news = dao.ViewDetail1(id);
            return View(user);
        }

        //KHOA TAI KHOAN

        public ActionResult BlockAccount(int id)
        {
            var dao = new AccountDao();    
            dao.BlockAccount(id);
            SetAlert("Khóa tài khoản thành công", "canhbao");
            return RedirectToAction("Index", "AccountManager");
        }




        //HIển thị form thêm
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }


        //Gửi thông tin về sever và chờ sử ý
        [HttpPost]
        public ActionResult CreateAccount(TAIKHOAN tk)
        {
            if (ModelState.IsValid)
            {
                var DAO = new AccountDao();
                var passmd5 = tk.MatKhau;
                tk.MatKhau = passmd5;
                tk.QuyenHan = "U";
                tk.TrangThaiNguoiDung = "bình thường";
                long id = DAO.addAccount(tk);
                if (id > 0)
                {
                    return RedirectToAction("Index", "AccountManager");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tài khoản thất bại");
                }

            }
            return View("Index");
        }










        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AccountDao().Delete(id);
            return RedirectToAction("Index");
        }


        public ActionResult LogoutAdmin()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
