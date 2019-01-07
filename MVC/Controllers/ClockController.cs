using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
namespace MVC.Controllers
{
    public class ClockController : Controller
    {
        // GET: Clock
        ClockBll bll = new ClockBll();
        public ActionResult Index(string FindBH,string FindName)
        {
            List<Clock> list = bll.GetList();
            var linq = from a in list select a;
            if(FindBH!="")
            {
                linq = from a in list where a.StaffNO.Contains(FindBH) select a;
            }
            if(FindName!="")
            {
                linq = from a in list where a.StaffName.Contains(FindName) select a;
            }
            if(FindBH!=""&&FindName!="")
            {
                linq = from a in list where a.StaffName.Contains(FindName) && a.StaffNO.Contains(FindBH) select a;
            }
            return View(linq);
        } 
        [HttpGet]
        public ActionResult daka()
        {
            return View();
        }
        [HttpPost]
        public ActionResult daka(string userno,string password)
        {
            Clock clock = new Clock();
            StaffBLL staffBLL = new StaffBLL();
            ClockBll clockBll = new ClockBll();
            if (userno == "0916545" && password == "0916545")
            {
                clock.StaffNO = userno;
                clock.StaffName = Session["UserName"].ToString();
                //clock.StaffName = staffBLL.GetList().Where(m => m.StaffNo == userno).FirstOrDefault().StaffName;
                clock.HitTime = DateTime.Now;
                if (clock.HitTime.ToString().CompareTo(DateTime.Now.ToString("yyyy/MM/dd") + "19:00") == -1)
                {
                    clock.HitSate = "上午上班打卡成功";
                }
                if (clockBll.Add(clock) > 1)
                {
                    Response.Write("<script>alert('打卡成功');location.href='/Clock/Index'</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('打卡失败')</script>");
            }
            return View();
        }
        public ActionResult Del(int id)
        {
            if(bll.Del(id)>0)
            {
                Response.Write("<script>alert('删除成功');location.href='/Clock/Index'</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Upd(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upd(Clock c)
        {
            if(bll.Upt(c)>0)
            {
                Response.Write("<script>alert('修改成功');location.href='/Clock/Index'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
            return View();
        }
    }
}