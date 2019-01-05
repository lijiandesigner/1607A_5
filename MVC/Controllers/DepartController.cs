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
    public class DepartController : Controller
    {
        // GET: Depart
        DepartBLL BLL = new DepartBLL();
        public ActionResult Index()
        {
            List<Depart> list = BLL.GetList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Depart depart)
        {
            depart.CreateTime = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分 dddd");
            int result = BLL.Add(depart);
            if(result>0)
            {
                Response.Write("<script>alert('添加部门成功')</script>");
            }
            return Redirect("/Depart/Index");
        }
        public ActionResult Delete(int id)
        {
            int result = BLL.Del(id);
            if(result>0)
            {
                Response.Write("<script>alert('删除部门成功')</script>");
            }
            return Redirect("/Depart/Index");
        }
        public ActionResult Edit(int id)
        {
            Depart depart = BLL.GetT(id);
            return View(depart);
        }
        [HttpPost]
        public ActionResult Edit(Depart depart)
        {
            depart.CreateTime = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分 dddd");
            int result = BLL.Upt(depart);
            if (result > 0)
            {
                Response.Write("<script>alert('修改部门成功')</script>");
            }
            return Redirect("/Depart/Index");
        }
    }
}