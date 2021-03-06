﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace MVC.Controllers
{
    [Authorization]
    public class ClockController : Controller
    {
        // GET: Clock
        ClockBll bll = new ClockBll();
        public ActionResult Index(string FindBH = "", string FindName = "", string time = "", int pageindex = 1, int pagesize = 3)
        {
            ViewBag.pindex = pageindex;
            ViewBag.pagesize = pagesize;
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
            if (time != "")
            {
                linq = from a in list where a.HitTime.Equals(time) select a;
            }
            ViewBag.count = Math.Ceiling(linq.Count() * 1.0 / pagesize);
            var fen = linq.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            return View(fen);
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
        public string daka(string Name, string NO)
        {
            Name = Session["UserName"].ToString();
            NO = Session["StaffNo"].ToString();
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
            int DaKaCiShu = 0;
            var t = DateTime.Now.ToString("yyyy/MM/dd");
            DaKaCiShu = bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t).Count();

            var no = staffBLL.GetList().Where(m => m.StaffName.Equals(Name)).FirstOrDefault().StaffNo;

            clock.StaffNO = NO;
            clock.StaffName = Name;
            clock.HitTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + time);
            //上班之前
            if (DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(AmGoTime)) <= 0)
            {
                //上班或下班时间
                clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + AmGoTime);
                jie = $"{Name},上午上班打卡成功";
                //打卡状态
                if (DaKaCiShu >= 1)
                {
                    jie = $"{Name},已打卡成功,不必再来";
                }
            }
            //上午上班期间
            else if (DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(AmGoTime)) > 0 && DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(AmComeTime)) < 0)
            {
                //根据名称和当前日期查询打卡几次 进行判断
                if (DaKaCiShu == 0)
                {
                    clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + AmGoTime);
                    jie = $"{Name},上午上班打卡成功,已迟到";
                    //打卡状态
                }
                else if (DaKaCiShu == 1)
                {

                    clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + AmComeTime);
                    jie = $"{Name},上午下班打卡成功,早退";
                    //打卡状态
                }
                else
                {
                    jie = $"{Name},已打卡成功,不必再来";
                }
            }
            //午休期间
            else if (DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(AmComeTime)) >= 0 && DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(PmGoTime)) <= 0)
            {
                //根据名称和当前日期查询打卡几次 进行判断
                if (DaKaCiShu == 1)
                {
                    clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + AmComeTime);
                    jie = $"{Name},上午下班打卡成功";
                    //打卡状态
                }
                else if (DaKaCiShu == 2)
                {
                    if (bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t && m.HitSate.Contains("没有上班")).Count() == 1)
                    {
                        jie = $"{Name},已打卡成功,不必再来";
                    }
                    else
                    {
                        clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + PmGoTime);
                        jie = $"{Name},下午上班打卡成功";
                        //打卡状态
                    }
                }
                else if (DaKaCiShu == 0)
                {
                    clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + PmGoTime);
                    jie = $"{Name},上午没有上班";
                    bll.Add(clock);
                    jie = $"{Name},下午上班打卡成功";
                    //打卡状态
                }
                else
                {
                    jie = $"{Name},已打卡成功,不必再来";
                }
            }
            //下午上班期间
            else if (DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(PmGoTime)) > 0 && DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(PMGomeTime)) < 0)
            {
                if (DaKaCiShu == 2 || DaKaCiShu == 0)
                {
                    clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + PmGoTime);
                    if (DaKaCiShu == 0)
                    {
                        jie = $"{Name},上午没有上班";
                        clock.HitSate = jie;
                        bll.Add(clock);
                    }
                    if (bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t && m.HitSate.Contains("没有上班")).Count() == 1)
                    {
                        if (DaKaCiShu == 2)
                        {
                            jie = $"{Name},下午下班打卡成功,早退";
                        }
                        else
                        {
                            jie = $"{Name},已打卡成功,不必再来";
                        }
                    }
                    else
                    {
                        if (DaKaCiShu == 2)
                        {
                            jie = $"{Name},下午上班班打卡成功,已迟到";
                        }
                        else if (DaKaCiShu == 3)
                        {
                            jie = $"{Name},下午上班班打卡成功,已早退";
                        }
                        else
                        {
                            jie = $"{Name},已打卡成功,不必再来";
                        }
                    }
                }
                else if (DaKaCiShu == 3)
                {
                    clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + PMGomeTime);
                    if (bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t && m.HitSate.Contains("没有上班")).Count() == 1)
                    {
                        jie = $"{Name},已打卡成功,不必再来";
                    }
                    else
                    {
                        jie = $"{Name},下午下班打卡成功,早退";
                    }
                    //打卡状态
                }
                else if (DaKaCiShu == 1)
                {
                    clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + PMGomeTime);
                    jie = $"{Name},上午下班打卡成功";
                    clock.HitSate = jie;
                    bll.Add(clock);
                    //因为只打过一次不知道是上午下班卡还是下午上班卡
                    jie = $"{Name},下午上班打卡成功,迟到";
                    //打卡状态
                }
                else if(DaKaCiShu==4)
                {
                    jie = $"{Name},已打卡成功,不必再来";
                }
            }
            //下午下班期间
            else if (DateTime.Compare(Convert.ToDateTime(time), Convert.ToDateTime(PMGomeTime)) >= 0)
            {
                clock.Hours = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " " + PMGomeTime);
                if (bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t && m.HitSate.Contains("旷工一天")).Count() == 1)
                {
                    jie = $"{Name},已打卡成功,不必再来";
                }
                else
                {
                    if (bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t && m.HitSate.Contains("旷工半天天")).Count() == 1)
                    {
                        jie = $"{Name},已打卡成功,不必再来";
                    }
                    else
                    {
                        if (DaKaCiShu == 3)
                        {
                            if (bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t && m.HitSate.Contains("上午没有下班")).Count() == 1)
                            {
                                jie = $"{Name},已打卡成功,不必再来";
                            }
                            else if (bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t && m.HitSate.Contains("下午没有下班")).Count() == 1)
                            {
                                jie = $"{Name},已打卡成功,不必再来";
                            }
                            else
                            {
                                jie = $"{Name},下午下班打卡成功";
                            }
                        }
                        else if (DaKaCiShu == 0)
                        {
                            jie = $"{Name},旷工一天";
                        }
                        else if (DaKaCiShu == 2)
                        {
                            if (bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t && m.HitSate.Contains("上午没有上班")).Count() == 1)
                            {
                                jie = $"{Name},下午下班打卡成功";
                            }
                            else if (bll.GetList().Where(m => m.StaffName.Equals(Name) && m.HitTime.ToString("yyyy/MM/dd") == t && m.HitSate.Contains("旷工半天")).Count() == 1)
                            {
                                jie = $"{Name},已打卡成功,不必再来";
                            }
                            else
                            {
                                jie = $"{Name},下午没有上班";
                            }
                        }
                        else if (DaKaCiShu >= 4)
                        {
                            jie = $"{Name},已打卡成功,不必再来";
                        }
                        else if (DaKaCiShu == 1)
                        {
                            jie = $"{Name},旷工半天";
                        }
                    }


                }
            }
            clock.HitSate = jie;
            //如果多次打卡不计入数据库 
            if (!(jie == $"{Name},已打卡成功,不必再来"))
            {
                bll.Add(clock);
            }
            return "<script>alert('" + jie + "');location.href = '/Login/Show';</script>";
        }
    }
}