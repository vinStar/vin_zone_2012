using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Demo.Controllers
{
    public class UserController : Controller
    {
        ////
        //// GET: /User/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]// 只接受post请求 登录
        public ActionResult Login(Models.UserModel model)
        {
            if (model.UserName == "test" && model.Password == "test")
            {
                Response.Write("正确！");
            }
            else
            {
                Response.Write("不正确！");
            }

            //            model.Password
            return View();
        }

        public ActionResult LayoutDemo_01()
        {
            return View();
        }


        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(FormCollection from)
        {
            Response.Write(from["txtUserName"]);
            Response.Write("<br/>");
            Response.Write(from["txtPassword"]);
            return View();
        }




    }
}
