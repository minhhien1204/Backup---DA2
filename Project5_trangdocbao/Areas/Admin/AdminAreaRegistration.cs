using System.Web.Mvc;

namespace Project5_trangdocbao.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
            "DangNhap",
            "Dang-Nhap",
            defaults: new { controller = "Login", action = "Index", area= "Admin"}
        );




            context.MapRoute(
            "Cap nhat",
            "Admin/PostManager/UpdatePost/{id}",
            defaults: new { controller = "PostManager", action = "UpdatePost", id = UrlParameter.Optional }
        );


            context.MapRoute(
            "Bỏ duyệt bài",
            "Admin/PostManager/UnAcept/{UrlRequire}-{id}",
            defaults: new { controller = "PostManager", action = "UnAcept", id = UrlParameter.Optional }
        );

            context.MapRoute(
            "Duyetbai",
            "Admin/PostManager/Preview/{UrlRequire}-{id}",
            defaults: new { controller = "PostManager", action = "Preview", id = UrlParameter.Optional }
        );


            context.MapRoute(
            "Khoa tai khoan",
            "Admin/Admin/AccountManager/AccountInfo/{id}",
            defaults: new { controller = "AccountManager", action = "AccountInfo", id = UrlParameter.Optional }
        );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );



        }
    }
}
