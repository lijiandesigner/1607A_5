using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataHelp;
using Model;
using System.Data.Entity;

namespace DAL
{
    public class JobDAL : IDataHelp<Job>
    {
        MyContext Context = new MyContext();
        public int Add(Job t)
        {
            Context.Jobs.Add(t);
            return Context.SaveChanges();
        }

        public int Del(int id)
        {
            Context.Entry(Context.Jobs.Where(s => s.JobId == id).FirstOrDefault()).State = System.Data.Entity.EntityState.Deleted;
            return Context.SaveChanges();
        }

        public List<Job> GetList()
        {
            return Context.Jobs.ToList();
        }

        public List<Job> GetList(Job t)
        {
            return Context.Jobs.Where(s => s.JobName.Contains(t.JobName)).ToList();
        }

        public Job GetT(int id)
        {
            return Context.Jobs.Where(s => s.JobId == id).FirstOrDefault();
        }

        public int Upt(Job t)
        {
            Context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return Context.SaveChanges();
        }
    }
}
