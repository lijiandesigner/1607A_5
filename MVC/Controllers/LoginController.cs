using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Lohin
        StaffBLL BLL = new StaffBLL();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            List<Staff> list = BLL.GetList().Where(s => s.StaffName == username && s.StaffCard.Substring(s.StaffCard.Length - 7) == password).ToList();
            if (username=="卫宇航"&&password=="327614")
            {
                Response.Write("<script>alert('成功!')</script>");
            }
            return View();
        }
    }
}