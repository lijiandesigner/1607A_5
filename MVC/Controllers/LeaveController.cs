using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace MVC.Controllers

{
    [Authorization]
    public class LeaveController : Controller
    {
        // GET: Leave
        StaffBLL staffBLL = new StaffBLL();
        LeaveBLL BLL = new LeaveBLL();
        public ActionResult Index()
        {
            List<Leave> list = BLL.GetList();
            if (Session["Job"].ToString().Contains("部长"))
            {
                string job = Session["Job"].ToString().Substring(0, 2);
                list = (from s in staffBLL.GetList()
                        join y in BLL.GetList() on s.StaffNo equals y.StaffNo
                        where s.JobId.Contains(job)
                        select y).ToList();
            }
            else if (Session["Job"].ToString().Contains("组长"))
            {
                string job = Session["Job"].ToString().Substring(0, 2);
                list = (from s in staffBLL.GetList()
                        join y in BLL.GetList()
                        on s.StaffNo equals y.StaffNo
                        where s.JobId.Contains("组员") && s.JobId.Contains(job)
                        select y).ToList();
            }else if(Session["Job"].ToString().Contains("组员"))
            {
                list = list.Where(s => s.StaffNo == Session["StaffNo"].ToString()).ToList();
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Leave leave)
        {
            leave.StaffNo = Session["StaffNo"].ToString();
            leave.StaffName = Session["UserName"].ToString();
            int state = 1;
            leave.LeaveState = state.ToString();
            int result = BLL.Add(leave);
            if (result > 0)
            {
                Response.Write("<script>alert('添加成功');location.href='/Leave/Index';</script>");
            }
            return View();
        }
        public void Delete(int id)
        {
            int result = BLL.Del(id);
            if (result > 0)
            {
                Response.Write("<script>alert('撤销成功');location.href='/Leave/Index';</script>");
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Leave leave = BLL.GetList().Where(s => s.LeaveId == id).FirstOrDefault();
            return View(leave);
        }
        [HttpPost]
        public ActionResult Edit(Leave leave,string radio1)
        {
            leave.LeaveState =Convert.ToInt32(radio1)==2 ? "2" : "3";
            leave.AuditName = Session["UserName"].ToString();
            int result = BLL.Upt(leave);
            if (result > 0)
            {
                Response.Write("<script>alert('审批成功');location.href='/Leave/Index'</script>");
            }
            return View();
        }
        public string Look(int id)
        {
            return BLL.GetList().Where(s => s.LeaveId == id).FirstOrDefault().RejectReason;
        }
    }
    public enum StateInfo
    {
        待审核 = 1,
        通过 = 2,
        驳回 = 3
    }
}