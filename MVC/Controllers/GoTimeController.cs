using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
namespace MVC.Controllers
{
    public class GoTimeController : Controller
    {
        // GET: GoTime
        GoTimeBll bll = new GoTimeBll();
        public ActionResult Index()
        {
            List<GoTime> list = bll.GetList();
            return View(list);
        }
        [HttpGet]
        public ActionResult add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add(GoTime g)
        {
            int q = bll.Add(g);
            if(q>0)
            {
                Response.Write("<script>alert('打卡成功');location.href='/GoTime/Index';</script>");
            }
            else
            {
                return Content("失败");
            }
            return View();
        }
        
    }
}