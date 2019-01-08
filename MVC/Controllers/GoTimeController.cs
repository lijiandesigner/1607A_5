using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
namespace MVC.Controllers
{
    [Authorization]
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
        public ActionResult add(string amH,string amM,string comH,string comM,string pmH,string pmM,string comP,string comPP)
        {
            GoTime g = new GoTime();
            var p = DateTime.Now.ToString("yyyy/MM/dd");
            g.AMGoTime = Convert.ToDateTime(p +" "+ amH + ":" + amM);
            g.AMComeTime = Convert.ToDateTime(p + " " + comH + ":" + comM);
            g.PMGoTime = Convert.ToDateTime(p + " " + pmH + ":" + pmM);
            g.PMComeTime = Convert.ToDateTime(p + " " + comP + ":" + comPP);
            int q = bll.Add(g);
            if (q > 0)
            {
                Response.Write("<script>alert('添加成功');location.href='/GoTime/Index';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Upd(int id)
        {
            return View(bll.GetT(id));
        }
        [HttpPost]
        public ActionResult Upd(string amH, string amM, string comH, string comM, string pmH, string pmM, string comP, string comPP)
        {
            GoTime g = new GoTime();
            var p = DateTime.Now.ToString("yyyy/MM/dd");
            g.AMGoTime = Convert.ToDateTime(p + " " + amH + ":" + amM);
            g.AMComeTime = Convert.ToDateTime(p + " " + comH + ":" + comM);
            g.PMGoTime = Convert.ToDateTime(p + " " + pmH + ":" + pmM);
            g.PMComeTime = Convert.ToDateTime(p + " " + comP + ":" + comPP);
            if (bll.Upt(g)>0)
            {
                Response.Write("<script>alert('修改成功');location.href='/GoTime/Index';</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
            return View();
        }
    }
}