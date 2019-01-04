using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace MVC.Controllers
{
    public class JobController : Controller
    {
        JobBLL bll = new JobBLL();
        // GET: Job
        /// <summary>
        /// 显示所有职位数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<Job> list = bll.GetList();
            return View(list);
        }
        /// <summary>
        /// 添加职位页面调用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult JobAdd()
        {
            return View();
        }
        /// <summary>
        /// 添加职位调用方法 此方法将传入到数据库
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult JobAdd(Job job)
        {
            int i = bll.Add(job);
            if (i > 0)
            {
                return Content("<script>alert('添加成功');location.href='/Job/Index';</script>");
                //return Redirect("/Job/Index");
            }
            else
            {
                return Content("<script>alert('添加失败')</script>");
            }
        }
        /// <summary>
        /// 删除方法调用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult JobDelete(int id)
        {
            int i = bll.Del(id);
            if (i > 0)
            {
                return Content("<script>alert('删除成功');location.href='/Job/Index';</script>");
               // return Redirect("/Job/Index");
            }
            else
            {
                return Content("<script>alert('删除失败');</script>");
            }
        }
        /// <summary>
        /// 修改返填使用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult JobGetById(int id)
        {
            return View(bll.GetT(id));
        }
        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult JobUpdate(Job job)
        {
            int i = bll.Upt(job);
            if (i > 0)
            {
                return Content("<script>alert('修改成功');location.href = '/Job/Index';</script>");
            }
            else
            {
                return Content("<script>alert('修改失败')</script>");
                
            }
        }

    }
}