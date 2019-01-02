using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    
    public class ClockBll
    {
        ClockDal dal = new ClockDal();
        public int Add(Clock t)
        {
            return dal.Add(t);
        }

        public int Del(int id)
        {
            return dal.Del(id);
        }

        public List<Clock> GetList()
        {
            return dal.GetList();
        }

        public List<Clock> GetList(Clock t)
        {
            return dal.GetList(t);
        }

        public Clock GetT(int id)
        {
            return dal.GetT(id);
        }

        public int Upt(Clock t)
        {
            return dal.Upt(t);
        }
    }
}
