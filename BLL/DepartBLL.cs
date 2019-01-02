using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using IDataHelp;

namespace BLL
{
    public class DepartBLL
    {
        IDataHelp<Depart> Help = new DepartDAL();
        public int Add(Depart t)
        {
            return Help.Add(t);
        }

        public int Del(int id)
        {
            return Help.Del(id);
        }

        public List<Depart> GetList()
        {
            return Help.GetList();
        }

        public List<Depart> GetList(Depart t)
        {
            return Help.GetList(t);
        }

        public Depart GetT(int id)
        {
            return Help.GetT(id);
        }

        public int Upt(Depart t)
        {
            return Help.Upt(t);
        }
    }
}
