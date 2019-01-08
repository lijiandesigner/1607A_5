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
            List<Salary> list = salaryBLL.GetList();
            List<Staff> staff = staffBLL.GetList();
            List<Job> jobs = jobBLL.GetList();
            for (int i = 0; i < list.Count(); i++)
            {
                list[i].PunishMoney = clockBll.GetList().Where(s => s.StaffNO == staff[i].StaffNo && s.HitSate.Contains("迟到")).Count() * float.Parse(50.0.ToString());
                list[i].AwardMoney = 0;
                list[i].LeaveMoney = 0;
                list[i].AllowMoney = 0;
                list[i].TrueMoney = list[i].JobMoney - list[i].PunishMoney + list[i].AwardMoney - list[i].LeaveMoney + list[i].AllowMoney;
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Salary salary = salaryBLL.GetList().Where(s => s.MoneyId == id).FirstOrDefault();
            if (salary.StaffNo != Session["StaffNo"].ToString())
            {
                Response.Write("<script>alert('这不是你的工资!请不要乱领!')</script>");
                return Redirect("/Salary/Index");
            }
            else
            {
                return View(salary);
            }

        }
        [HttpPost]
        public ActionResult Edit(Salary salary)
        {
            salary.MoneySate = "1";
            int result = salaryBLL.Upt(salary);
            if (result > 0)
            {
                Response.Write("<script>alert('领取成功!')</script>");
                return Redirect("/Salary/Index");
            }
            else
            {
                return View();
            }

        }
    }
    public enum SalaryState
    {
        待领取 = 0,
        已领取 = 1
    }
}