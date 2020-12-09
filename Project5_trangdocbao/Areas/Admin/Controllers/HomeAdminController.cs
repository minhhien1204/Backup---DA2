using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project5_trangdocbao.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseAdminController
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
