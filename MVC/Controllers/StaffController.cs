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
        // GET: Staff
        /// <summary>
        ///显示所有员工数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<Staff> s = bll.GetList();
            return View(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staff">根据员工id 员工姓名(模糊) 员工编号(模糊) 员工性别 员工年龄 员工电话 部门id 职位id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(Staff staff)
        {
            List<Staff> s = bll.GetList(staff);
            return View(s);
        }

        /// <summary>
        /// 添加员工页面调用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StaffAdd()
        {
            return View();
        }

        /// <summary>
        /// 添加员工调用方法 此方法将传入到数据库
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StaffAdd(Staff staff)
        {
            int s = bll.Add(staff);
            if (s > 0)
            {
                return Content("<script>alert('添加成功');</scipt>");
            }
            else
            {
                return Content("<script>alert('添加失败');</scipt>");
            }
        }

        /// <summary>
        /// 删除方法调用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult StaffDelete(int id)
        {
            int s = bll.Del(id);
            if (s > 0)
            {
                return Content("<script>alert('删除成功');</scipt>");
            }
            else
            {
                return Content("<script>alert('删除失败');</scipt>");
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
                return Content("<script>alert('修改成功');</scipt>");
            }
            else
            {
                return Content("<script>alert('修改失败');</scipt>");
            }
        }
    }
}