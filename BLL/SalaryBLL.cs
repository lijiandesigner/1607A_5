using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class SalaryBLL
    {
        SalaryDAL dal = new SalaryDAL();
        /// <summary>
        /// 添加员工工资记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Salary t)
        {
            return dal.Add(t);
        }
        /// <summary>
        /// 删除员工工资记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Del(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询所有工资记录
        /// </summary>
        /// <returns></returns>
        public List<Salary> GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 根据员工编号和工资发放时间查询
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<Salary> GetList(Salary t)
        {
            return dal.GetList(t);
        }
        /// <summary>
        /// 根据id查询工资记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Salary GetT(int id)
        {
            return dal.GetT(id);
        }

        public int Upt(Salary t)
        {
            throw new NotImplementedException();
        }
    }
}
