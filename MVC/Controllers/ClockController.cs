﻿using System;
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
        public ActionResult Index(string FindBH, string FindName)
        {
            List<Clock> list = bll.GetList();
            var linq = from a in list select a;
            if (FindBH != "")
            {
                linq = from a in list where a.StaffNO.Contains(FindBH) select a;
            }
            if (FindName != "")
            {
                linq = from a in list where a.StaffName.Contains(FindName) select a;
            }
            if (FindBH != "" && FindName != "")
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="NO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult daka(string Name, string NO)
        {
            string jie = "";
            Clock clock = new Clock();
            StaffBLL staffBLL = new StaffBLL();
            ClockBll clockBll = new ClockBll();
            GoTimeBll go = new GoTimeBll();
            //获取当前登录人姓名
            var s = Session["UserName"];
            //当前打卡时间
            var time = DateTime.Now.ToString("HH:mm:ss");
            //上午上班时间
            string AmGoTime = go.GetList().FirstOrDefault().AMGoTime.ToString().Substring(9);
            //上午下班时间
            string AmComeTime = go.GetList().FirstOrDefault().AMComeTime.ToString().Substring(9);
            //下午上班时间
            string PmGoTime = go.GetList().FirstOrDefault().PMGoTime.ToString().Substring(9);
            //下午下班时间
            string PMGomeTime = go.GetList().FirstOrDefault().PMComeTime.ToString().Substring(9);
            //一天打卡次数
            int DaKaCiShu = bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString().Contains(DateTime.Now.ToString("yyyy/MM/dd"))).Count();
            //if (Name == s.ToString())
            //{
            var no = staffBLL.GetList().Where(m => m.StaffName.Equals(Name)).FirstOrDefault().StaffNo;
            if (no == NO)
            {
                clock.StaffNO = NO;
                clock.StaffName = Name;
                clock.HitTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + time);
                //当打卡时间不大于上午打卡时间 没错
                if (DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(AmGoTime)) <= 0)
                {
                    //上班或下班时间
                    clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + AmComeTime);
                    jie = $"{Name},上午上班打卡成功";
                    //打卡状态
                    clock.HitSate = jie;
                }
                //上午上班时间之后 上午下班时间之前
                else if (DateTime.Compare(Convert.ToDateTime(time),Convert.ToDateTime(AmGoTime))> 0 && DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(AmComeTime)) < 0)
                {
                    //根据名称和当前日期查询打卡几次 进行判断
                    if (DaKaCiShu == 0)
                    {
                        jie = $"{Name},上午上班打卡成功,已迟到";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                    else if (DaKaCiShu == 1)
                    {
                        jie = $"{Name},上午下班打卡成功,早退";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                }
                //上午下班时间之后 下午上班时间之前
                else if (DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(AmComeTime)) >= 0 || DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(PmGoTime)) <= 0)
                {
                    //根据名称和当前日期查询打卡几次 进行判断
                    if (DaKaCiShu == 1)
                    {
                        jie = $"{Name},上午下班打卡成功";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                    else if (DaKaCiShu == 2)
                    {
                        jie = $"{Name},下午上班打卡成功";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                    else if (DaKaCiShu == 0)
                    {
                        jie = $"{Name},下午上班打卡成功";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                }
                else if (DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(PmGoTime)) > 0 && DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(PMGomeTime))<0)
                {
                    if (DaKaCiShu == 2 || DaKaCiShu == 0)
                    {
                        jie = $"{Name},下午上班打卡成功,已迟到";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                    else if (DaKaCiShu == 3)
                    {
                        jie = $"{Name},下午下班打卡成功,早退";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                    else if (DaKaCiShu == 1)
                    {
                        //因为只打过一次不知道是上午下班卡还是下午上班卡
                        jie = $"{Name},下午上班打卡成功,迟到";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                }
                else if (DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(PMGomeTime)) >= 0)
                {
                    if (DaKaCiShu == 3)
                    {
                        jie = $"{Name},下午下班打卡成功";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                    else
                    {
                        jie = $"{Name},旷工一天";
                        //打卡状态
                        clock.HitSate = jie;
                    }
                }
            }
            else
            {
                jie = "打卡失败";
            }
            //}
            //else
            //{
            //    jie = "打卡失败";
            //}
            return View(jie);
        }


    }
}