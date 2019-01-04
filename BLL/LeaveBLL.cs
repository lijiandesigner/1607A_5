using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
   public  class LeaveBLL
    {
        LeaveDAL dal = new LeaveDAL();
        /// <summary>
        /// 添加请假记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Leave t)
        {
            return dal.Add(t);
        }
        /// <summary>
        /// 请假不需要实现删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Del(int id)
        {
            return dal.Del(id);
        }
        /// <summary>
        /// 显示所有请假记录
        /// </summary>
        /// <returns></returns>
        public List<Leave> GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 根据员工编号和开始请假时间查询
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<Leave> GetList(Leave t)
        {
            return dal.GetList(t);
        }
        /// <summary>
        /// 请假不需要实现根据id查询功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Leave GetT(int id)
        {
            return dal.GetT(id);
        }
        /// <summary>
        /// 请假不需要实现修改功能
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upt(Leave t)
        {
            return dal.Upt(t);
        }
    }
}
