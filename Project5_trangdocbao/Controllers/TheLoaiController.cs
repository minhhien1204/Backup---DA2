using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace Project5_trangdocbao.Controllers
{
    public class TheLoaiController : Controller
    {
        //
        // GET: /TheLoai/

        public ActionResult Index(string UrlRequire, int page = 1, int pageSize = 10)
        {
            var dao = new PostDao();
            var model = dao.ListAllPostForType(UrlRequire, page, pageSize);
            //top 10 xem nhieu
            ViewBag._k_relative = new PostDao().top10VIew();
            
            //Lay ten the loai
            ViewBag.vbtentheloai = dao.theloaibaidangtentheloai(UrlRequire);
            return View(model);
        }

    }
}
