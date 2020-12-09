using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project5_trangdocbao.Common;
using System.Web.Routing;

namespace Project5_trangdocbao.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        //
        // GET: /KIỂM TRA QUYỀN ADMIN/

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ses = (UserInfo)Session[CommonConstant.ADMIN_SESSION];
            if (ses == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index"}));
            }
            base.OnActionExecuting(filterContext);
        }

        protected void SetAlert(string thongbao, string loai)
        {
            TempData["thongbao"] = thongbao;
            if (loai == "thanhcong")
            {
                TempData["loaithongbao"] = "alert-success";
            }
            else if (loai == "thatbai")
            { TempData["loaithongbao"] = "alert-warning"; }

            else
                if (loai == "canhbao")
                {
                    TempData["loaithongbao"] = "alert-danger";
                }
        }
    }
}
