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
        LeaveBLL BLL = new LeaveBLL();
        public ActionResult Index()
        {
            List<Leave> list = BLL.GetList();
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
            int state = 1;
            leave.LeaveState = state.ToString();
            int result = BLL.Add(leave);
            if (result > 0)
            {
                Response.Write("<script>alert('添加成功');location.href='/Leave/Index'</script>");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            int result = BLL.Del(id);
            if (result > 0)
            {
                Response.Write("<script>alert('撤销成功');location.href='/Leave/Index'</script>");
            }
            return View();
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