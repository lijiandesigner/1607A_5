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
            List<Staff> list = BLL.GetList().Where(s => s.StaffNo == password && s.StaffName == username).ToList();
            if (list.Count() > 0)
            {
                Session["Path"] = list[0].StaffPhoto;
                Session["UserName"] = list[0].StaffName;
                Session["StaffNo"] = list[0].StaffNo;
                Session["Job"] = list[0].JobId;
                Response.Write("<script>alert('登录成功!');location.href='/Login/Show'</script>");
            }
            else
            {
                if (BLL.GetList().Where(s => s.StaffName == username).Count() < 1)
                {
                    Response.Write("<script>alert('登录失败!本公司无此员工')</script>");
                }
                else
                {
                    Response.Write("<script>alert('登录失败!员工工号错误')</script>");
                }
            }
            return View();
        }
    }
}