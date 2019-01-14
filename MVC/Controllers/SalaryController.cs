using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace MVC.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        StaffBLL staffBLL = new StaffBLL();
        JobBLL jobBLL = new JobBLL();
        ClockBll clockBll = new ClockBll();
        SalaryBLL salaryBLL = new SalaryBLL();
        [HttpGet]
        public ActionResult Index()
        {
            List<Salary> list = new List<Salary>();
            List<Staff> staff = staffBLL.GetList();
            foreach (var item in staff)
            {
                list.Add(salaryBLL.GetList().Where(s=>s.StaffNo==item.StaffNo).FirstOrDefault());
            }
            List<Job> jobs = jobBLL.GetList();
            for (int i = 0; i < list.Count(); i++ )
            {
                List<Clock> clocks = clockBll.GetList().Where(s => s.StaffNO == list[i].StaffNo).ToList();
                list[i].PunishMoney = clocks.Where(s => s.HitSate.Contains("迟到") || s.HitSate.Contains("早退")).Count() * float.Parse(50.0.ToString()) + clocks.Where(s => s.HitSate.Contains("没有上班")).Count() * float.Parse(100.0.ToString()) + clocks.Where(s => s.HitSate.Contains("旷工")).Count() * float.Parse(300.0.ToString());
                list[i].AwardMoney = 0;
                list[i].LeaveMoney = 0;
                list[i].AllowMoney = 0;
                list[i].TrueMoney = list[i].JobMoney - list[i].PunishMoney + list[i].AwardMoney - list[i].LeaveMoney + list[i].AllowMoney;
            }
            if(Session["Job"].ToString().Contains("部长"))
            {
                string job = Session["Job"].ToString().Substring(0,2);
                list = (from s in staffBLL.GetList()
                        join y in salaryBLL.GetList() on s.StaffNo equals y.StaffNo
                        where s.JobId.Contains(job)
                        select y).ToList();
            }else if(Session["Job"].ToString().Contains("组长"))
            {
                string job = Session["Job"].ToString().Substring(0,2);
                list = (from s in staffBLL.GetList()
                        join y in salaryBLL.GetList() on s.StaffNo equals y.StaffNo
                        where s.JobId.Contains("组员") && s.JobId.Contains(job)
                        select y).ToList();
            }else if(Session["Job"].ToString().Contains("组员"))
            {
                list = list.Where(s => s.StaffNo == Session["StaffNo"].ToString()).ToList();
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Salary salary = salaryBLL.GetList().Where(s => s.MoneyId == id).FirstOrDefault();
            Staff staff = staffBLL.GetList().Where(s => s.StaffNo == salary.StaffNo).FirstOrDefault();
            if (salary.StaffNo != Session["StaffNo"].ToString())
            {
                Response.Write("<script>alert('这不是你的工资!请不要乱领!');location.href='/Salary/Index';</script>");

            }
            else if (DateTime.Compare(staff.StartTime, DateTime.Now) < 30)
            {
                Response.Write("<script>alert('不到领取工资日期!');location.href='/Salary/Index';</script>");
            }
            return View(salary);
        }
        [HttpPost]
        public ActionResult Edit(Salary salary)
        {
            salary.MoneySate = "1";
            int result = salaryBLL.Upt(salary);
            if (result > 0)
            {
                Response.Write("<script>alert('领取成功!');location.href='/Salary/Index';</script>");
            }
            return View();
        }
        public string Look(string id)
        {
            List<Clock> list = clockBll.GetList().Where(s => s.HitSate.Contains("早退")||s.HitSate.Contains("旷工")||s.HitSate.Contains("迟到")||s.HitSate.Contains("没有上班")).ToList();
            string result = "罚款原因:\n";
            foreach (var item in list.Where(s=>s.StaffNO==id))
            {
                result += $"{item.HitTime}:{item.HitSate}\n";
            }
            return result;
        }
    }
    public enum SalaryState
    {
        待领取 = 0,
        已领取 = 1
    }
}