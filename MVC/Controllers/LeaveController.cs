using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace MVC.Controllers
{
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
            leave.LeaveState = "已提交,未审核";
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
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Leave leave)
        {
            int result = BLL.Upt(leave);
            if (result > 0)
            {
                Response.Write("<script>alert('修改成功');location.href='/Leave/Index'</script>");
            }
            return View();
        }
    }
    public enum StateInfo
    {
        待审核 = 1,
        通过 = 2,
        驳回 = 3
    }
}