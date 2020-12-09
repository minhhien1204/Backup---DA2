using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project5_trangdocbao.Areas.Admin.Controllers
{
    public class HomeUserController : BaseUserController
    {
        //
        // GET: /Admin/HomeUser/

        public ActionResult Index()
        {
            return View();
        }

    }
}
