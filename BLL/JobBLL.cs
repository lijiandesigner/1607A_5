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
    public class JobBLL
    {
        IDataHelp<Job> Help = new JobDAL();
        public int Add(Job t)
        {
            return Help.Add(t);
        }

        public int Del(int id)
        {
            return Help.Del(id);
        }

        public List<Job> GetList()
        {
            return Help.GetList();
        }

        public List<Job> GetList(Job t)
        {
            return Help.GetList(t);
        }

        public Job GetT(int id)
        {
            return Help.GetT(id);
        }

        public int Upt(Job t)
        {
            return Help.Upt(t);
        }
    }
}
