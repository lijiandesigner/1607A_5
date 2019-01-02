using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataHelp;
using Model;

namespace DAL
{
    public class SalaryDAL : IDataHelp<Salary>
    {
        /// <summary>
        /// 实例化上下文对象
        /// </summary>
        MyContext myc = new MyContext();

        /// <summary>
        /// 添加员工工资记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Salary t)
        {
            myc.Salaries.Add(t);
            return myc.SaveChanges();
        }
        /// <summary>
        /// 财务不要实现删除功能
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
            return myc.Salaries.ToList();
        }
        /// <summary>
        /// 根据员工编号和工资发放时间查询
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<Salary> GetList(Salary t)
        {
            
            return myc.Salaries.Where(s=>s.StaffNo==t.StaffNo && s.StaffName==t.StaffName).ToList();
        }
        /// <summary>
        /// 财务不需要实现根据id查询功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Salary GetT(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 财务部不需要实现修改功能
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upt(Salary t)
        {
            throw new NotImplementedException();
        }
    }
}
