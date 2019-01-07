using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace MVC.Controllers
{
    public class StaffController : Controller
    {
        StaffBLL bll = new StaffBLL();
        DepartBLL DepartBLL = new DepartBLL();
        JobBLL jobBLL = new JobBLL();
        SalaryBLL salaryBLL = new SalaryBLL();
        // GET: Staff
        /// <summary>
        ///显示所有员工数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            xiala();
            List<Staff> s = bll.GetList();
            return View(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staff">根据员工id 员工姓名(模糊) 员工编号(模糊) 员工性别 员工年龄 员工电话 部门id 职位id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(int staffid=0, string name="", string no="", int bumenid=0, int zhiid=0)
        {
            xiala();
            Staff st = new Staff();
            st.StaffId = staffid;
            st.StaffName = name;
            st.StaffNo = no;
            st.DepartId = bumenid;
            st.JobId = zhiid;
            List<Staff> s = bll.GetList(st);
            return View(s);
        }

        /// <summary>
        /// 添加员工页面调用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StaffAdd()
        {
            //部门下拉列表
            xiala();
            return View();
        }
        public ActionResult xiala()
        {
            var s = DepartBLL.GetList();
            ViewBag.list = new SelectList(s, "DepartName", "DepartName");
            var p = jobBLL.GetList();
            ViewBag.jobList = new SelectList(p, "JobName", "JobName");
            return View();
        }
        /// <summary>
        /// 添加员工调用方法 此方法将传入到数据库
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StaffAdd(Staff staff)
        {
           
            //员工工号是身份证后六位
            staff.StaffNo = staff.StaffCard.Substring(staff.StaffCard.Length - 6);
            //入职时间
            staff.StartTime = DateTime.Now;
            int s = bll.Add(staff);
            if (s > 0)
            {
                Response.Write ("<script>alert('添加成功');location.href ='/Staff/Index'</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>");
            }
            xiala();
            Salary salary = new Salary();
            salary.StaffNo = staff.StaffNo;
            salary.StaffName = staff.StaffName;
            salary.JobMoney = jobBLL.GetList().Where(ss => ss.JobId == staff.JobId).FirstOrDefault().JobMoney;
            salary.TrueMoney = salary.JobMoney;
            salary.MoneySate = "0";
            salaryBLL.Add(salary);
            return View();
        }

        /// <summary>
        /// 删除方法调用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void StaffDelete(int id)
        {
            int s = bll.Del(id);
            if (s > 0)
            {
                Response.Write("<script>alert('删除成功');location.href ='/Staff/Index'</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
           
        }
        
        /// <summary>
        /// 修改反填使用 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StaffGetById(int id)
        {
            xiala();
            return View(bll.GetT(id));
        }

        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StaffUpdate(Staff staff)
        {
            int s = bll.Upt(staff);
            if (s > 0)
            {
                Response.Write("<script>alert('修改成功');location.href ='/Staff/Index'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
            return View();
        }
    }
    public class job
    {
        public string name { get; set; }
    }
}