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
    public class CateManagerController : BaseAdminController
    {
        //
        // GET: /Admin/Cate/

        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new CateDao();
            var model = dao.ListAll(page, pageSize);
            return View(model);
        }


        [HttpGet]
        public ActionResult AddCate()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddCate(CHUYENMUC cm)
        {
            if (ModelState.IsValid)
            {
                var DAO = new CateDao();
                long id = DAO.addCate(cm);
                if (id > 0)
                {
                    return RedirectToAction("Index", "CateManager");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thể loại thất bại");
                }

            }
            return View("Index");
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CateDao().Delete(id);
            return RedirectToAction("Index");
        }


    }
}
