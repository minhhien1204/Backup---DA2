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
    public class TypeManagerController : BaseAdminController
    {
        //
        // GET: /Admin/TypeManager/

        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new TypeDao();
            var model = dao.ListAll(page, pageSize);
            return View(model);
        }




        [HttpGet]
        public ActionResult AddType()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddType(THELOAI tk)
        {
            if (ModelState.IsValid)
            {
                var DAO = new TypeDao();
                //tk.UrlRequire = RewriteURL.RewriteUrl(tk.UrlRequire);
                long id = DAO.addType(tk);
                if (id > 0)
                {
                    return RedirectToAction("Index", "TypeManager");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thể loại thất bại");
                }

            }
            return View("Index");
        }


        [HttpPost]
        public ActionResult UpdateType(THELOAI tk)
        {
            if (ModelState.IsValid)
            {
                var DAO = new TypeDao();
                //var passmd5 = Encryptor.MD5Hash(tk.MatKhau);
                //tk.MatKhau = passmd5;
                var result = DAO.updateType(tk);
                if (result)
                {
                    return RedirectToAction("Index", "TypeManager");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }

            }
            return View("Index");
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new TypeDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}
