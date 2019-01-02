using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class GoTimeBll
    {
        GoTimeDal dal = new GoTimeDal();
        public int Add(GoTime t)
        {
            return dal.Add(t);
        }

        public int Del(int id)
        {
            return dal.Del(id);
        }

        public List<GoTime> GetList()
        {
            return dal.GetList();
        }

        public List<GoTime> GetList(GoTime t)
        {
            return dal.GetList(t);
        }

        public GoTime GetT(int id)
        {
            return dal.GetT(id);
        }

        public int Upt(GoTime t)
        {
            return dal.Upt(t);
        }
    }
}
