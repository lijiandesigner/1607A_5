using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDataHelp;
using System.Data.Entity;

namespace DAL
{
    public class LeaveDAL : IDataHelp<Leave>
    {
        MyContext myc = new MyContext();
        /// <summary>
        /// 添加请假记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Leave t)
        {
            myc.Leaves.Add(t);
            return myc.SaveChanges();
        }
        /// <summary>
        /// 财务不需要实现删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Del(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 显示所有请假记录
        /// </summary>
        /// <returns></returns>
        public List<Leave> GetList()
        {
            return myc.Leaves.ToList();
        }
        /// <summary>
        /// 根据员工编号和开始请假时间查询
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<Leave> GetList(Leave t)
        {
            return myc.Leaves.Where(l=>l.StaffNo==t.StaffNo&&l.StartLeaveTime.CompareTo(t.StartLeaveTime)==1).ToList();
        }
        /// <summary>
        /// 财务不需要实现根据id查询功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Leave GetT(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 财务不需要实现修改功能
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upt(Leave t)
        {
            throw new NotImplementedException();
        }
    }
}
