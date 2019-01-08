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
        // GET: Login
        StaffBLL BLL = new StaffBLL();
        JobBLL jobBLL = new JobBLL();
        public ActionResult Show()
        {
            return View();
        }
        public ActionResult Index()
        {
            Session["UserName"] = null;
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
                Session["StaffNo"] = list[0].StaffNo;
                Response.Write("<script>alert('登录成功!');location.href='/Login/Show'</script>");
            }
            else
            {
                Response.Write("<script>alert('登录失败!员工号或密码失败')</script>");
            }
            return View();
        }
    }
}