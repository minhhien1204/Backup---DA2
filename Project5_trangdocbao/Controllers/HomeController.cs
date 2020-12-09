using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EntityFramework;
using Project5_trangdocbao.Common;
using PagedList;



namespace Project5_trangdocbao.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            //Lấy ra bài đăng mới nhất đưa lên trang chủ
            ViewBag._KLastestNews = new PostDao().LastestNews();
            ViewBag._K_LastestNews25 = new PostDao().SecondToFourthNews();



            //Lấy các bài đăng thể loại the thao
            ViewBag.thethao = new PostDao().postTheThao();

            //Lấy các bài đăng thể loại công nghệ
            ViewBag.congnghe = new PostDao().postCongNghe();
            //Lấy các bài đăng thể loại giải trí
            ViewBag.giaitri = new PostDao().postGiaiTri();
            //top 10 xem nhieu
            ViewBag._k_relative = new PostDao().top10VIew();


            return View();

        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        //Gửi thông tin về sever và chờ sử ý
        [HttpPost]
        public ActionResult Register(TAIKHOAN tk)
        {
            if (ModelState.IsValid)
            {
                var DAO = new AccountDao();
                var passmd5 = (tk.MatKhau);
                tk.MatKhau = passmd5;
                tk.QuyenHan = "U";
                tk.TrangThaiNguoiDung = "bình thường";
                long id = DAO.addAccount(tk);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo tài khoản thất bại");
                }

            }
            return RedirectToAction("Index");
        }

        //Xử lý menu
        [ChildActionOnly]
        public ActionResult MainMenu()
        {

            var model = new CateDao().ListCate();
            return PartialView(model);
        }
        public JsonResult DanhSachTenBaiViet(string term)
        {
            var danhsachtenbaiviet = new PostDao().LayDanhSachTenBaiViet(term);
            return Json(new
            {
                data = danhsachtenbaiviet,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TimKiemBaiViet(string KeyWord)
        {
            
            var model = new PostDao().TimKiemBaiViet(KeyWord);
            ViewBag.KeyWord = KeyWord;
            //top 10 xem nhieu
            ViewBag._k_relative = new PostDao().top10VIew();
            return View(model);
        }

    }
}
