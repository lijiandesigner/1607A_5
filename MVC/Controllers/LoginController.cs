﻿using System;
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
            List<Staff> list = BLL.GetList().Where(s => s.StaffNo == password&&s.StaffName==username).ToList();
            if (list.Count() > 0 )
            {
                Session["Path"] = password;
                Session["UserName"] = username;
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