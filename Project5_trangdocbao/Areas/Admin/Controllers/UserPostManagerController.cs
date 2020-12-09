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
    public class UserPostManagerController : BaseUserController
    {
        //
        // GET: /Admin/UserPostManager/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public ActionResult Create()
        {
            GetTypeForPost();
            return View();
        }




        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(BAIDANG bd)
        {
            if (bd.TenBaiDang == null || bd.AnhDaiDien == null || bd.NoiDung == null)
            {
                GetTypeForPost();
                return View("Create");
            }
               
            if (ModelState.IsValid)
            {
                var DAO = new PostDao();
                bd.UrlRequire = RewriteURL.RewriteUrl(bd.TenBaiDang);
                bd.TrangThaiBaiDang = "chờ duyệt";

                int idtk = int.Parse(Session["USER_ID"].ToString());
                bd.IDTaiKhoan = idtk;
                bd.NgayDang = DateTime.Now;
                bd.IDBaiDang = 0;
                long idpost = DAO.CreatePost(bd);
            }
            return Redirect("MyPost");
        }

        //lấy ra danh sách thể loại cho bài đăng
        public void GetTypeForPost(long? selectedid = null)
        {
            var dao = new TypeDao();
            ViewBag.IDTheLoai = new SelectList(dao.ListTypeForCreatePost(), "IDTheLoai", "TenTheLoai", selectedid);
        }

        //Lấy ra danh sách tất cả bài đăng
        public ActionResult MyPost(string searchString, int page = 1, int pageSize = 5)
        {
            var postdao = new PostDao();
            var userSession = new UserInfo();
            int idtk = int.Parse(Session["USER_ID"].ToString());
            var model = postdao.MyPost(searchString, page, pageSize, idtk);
            ViewBag.searchstring = searchString;
            return View(model);
        }


        //Xóa bài đăng
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new PostDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdatePost(int id)
        {
            var dao = new PostDao();
            GetTypeForPost();
            var user = dao.ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdatePost(BAIDANG tk)
        {
            if (ModelState.IsValid)//f9 de debug. thu di. f10 se debug tung buoc
            {
                var DAO = new PostDao(); //f12 hoac contine se nhay toi buoc debug ke tiep. 
                //neu ke tiep k co debug thi se chạy xog luon.ok
                //gio contine se chay xog luon vi da het debug
                //var passmd5 = Encryptor.MD5Hash(tk.MatKhau);
                //tk.MatKhau = passmd5;
                var result = DAO.updatePost(tk);
                if (result)
                {
                    return Redirect("/Admin/UserPostManager/MyPost");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }

            }
            return Redirect("/Admin/UserPostManager/MyPost");
        }

    }
}
