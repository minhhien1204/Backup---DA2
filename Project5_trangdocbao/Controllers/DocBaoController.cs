using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace Project5_trangdocbao.Controllers
{
    public class DocBaoController : Controller
    {
        //
        // GET: /DocBao/

        public ActionResult Index(long id)
        {
            var dao = new PostDao();

            ViewBag._k_news = dao.NewsFindByID(id);


            //Lấy 10 bài đăng cùng thể loại
            ViewBag._k_relative = dao.top10Relative(id);


            //Lấy 10 bài đăng cùng người đăng
            ViewBag._k_poster = dao.top10CungNguoiDang(id);

            //Lấy tên thể loại để hiển thị ra trang đọc báo
            ViewBag.vbtentheloai = dao.theloaibaidang(id);

            //Lấy thông tin người đăng
            ViewBag.getinfoposter = dao.GetInfoPoster(id);

            //var dao1 = new ViewsDao();
            //dao1.AddViews(id);
            return View();
        }


        //Bài báo theo thể loại
        public ActionResult DocBaoTheoNguoiDang(int id, int page=1, int pageSize=10)
        {
            var dao = new PostDao();
            var model = dao.ListAllPostForPoster(id, page, pageSize);
            //top 10 xem nhieu
            ViewBag._k_relative = new PostDao().top10VIew();
            return View(model);
        }
    }
}
