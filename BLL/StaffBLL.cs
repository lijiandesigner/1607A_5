using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDataHelp;
using DAL;

namespace BLL
{
    public class StaffBLL
    {
        StaffDal Help = new StaffDal();
        public int Add(Staff t)
        {
            return Help.Add(t);
        }

        public int Del(int id)
        {
            return Help.Del(id);
        }

        public List<Staff> GetList()
        {
            return Help.GetList();
        }

        public List<Staff> GetList(Staff t)
        {
            return Help.GetList(t);
        }

        public Staff GetT(int id)
        {
            return Help.GetT(id);
        }

        public int Upt(Staff t)
        {
            return Help.Upt(t);
        }
    }
}
