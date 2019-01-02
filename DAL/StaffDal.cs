﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataHelp;
using Model;

namespace DAL
{
    public class StaffDal : IDataHelp<Staff>
    {
        MyContext context = new MyContext();
        /// <summary>
        /// 添加员工方法
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Staff t)
        {
            context.Staffs.Add(t);
            return context.SaveChanges();
        }

        /// <summary>
        /// 删除员工方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Del(int id)
        {
            var s = context.Staffs.Where(u => u.StaffId == id);
            context.Entry(s.FirstOrDefault()).State = EntityState.Deleted;
            return context.SaveChanges();
        }

        /// <summary>
        /// 显示使用
        /// </summary>
        /// <returns></returns>
        public List<Staff> GetList()
        {
            return context.Staffs.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<Staff> GetList(Staff t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 反填方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Staff GetT(int id)
        {
           return  context.Staffs.Where(u => u.StaffId == id).FirstOrDefault();
        }

        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upt(Staff t)
        {
            context.Entry(t).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}