using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataHelp;
using Model;

namespace DAL
{
    public class DepartDAL : IDataHelp<Depart>
    {
        MyContext Context = new MyContext();
        public int Add(Depart t)
        {
            Context.Departs.Add(t);
            return Context.SaveChanges();
        }

        public int Del(int id)
        {
            Context.Entry(Context.Departs.Where(s => s.DepartId == id).FirstOrDefault()).State = System.Data.Entity.EntityState.Deleted;
            return Context.SaveChanges();
        }

        public List<Depart> GetList()
        {
            return Context.Departs.ToList();
        }

        public List<Depart> GetList(Depart t)
        {
            return Context.Departs.Where(s => s.DepartName.Contains(t.DepartName)).ToList();
        }

        public Depart GetT(int id)
        {
            return Context.Departs.Where(s => s.DepartId == id).FirstOrDefault();
        }

        public int Upt(Depart t)
        {
            Context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return Context.SaveChanges();
        }
    }
}
