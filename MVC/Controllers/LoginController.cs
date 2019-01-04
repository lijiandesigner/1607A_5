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
            List<Staff> list = BLL.GetList().Where(s => s.StaffNo == username).ToList();
            if (list.Count() > 0 && username == password)
            {
                Session["Path"] = list[0].StaffPhoto;
                Session["UserName"] = list[0].StaffName;
                Response.Write("<script>alert('登录成功!');location.href='/Staff/Index'</script>");
            }
            else
            {
                Response.Write("<script>alert('登录失败!员工号或密码失败')</script>");
            }
            return View();
        }
    }
}