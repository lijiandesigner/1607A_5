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
    public class ClockDal : IDataHelp<Clock>
    {
        MyContext my = new MyContext();
        public int Add(Clock t)
        {
            my.Clocks.Add(t);
            return my.SaveChanges();
        }

        public int Del(int id)
        {
            var ss = my.Clocks.Where(q => q.WorkId == id).FirstOrDefault();
            my.Entry(ss).State = EntityState.Deleted;
            return my.SaveChanges();
        }

        public List<Clock> GetList()
        {
            return my.Clocks.ToList();
        }

        public List<Clock> GetList(Clock t)
        {
            return my.Clocks.Where(s => s.StaffNO == t.StaffNO).ToList();
        }

        public Clock GetT(int id)
        {
            return my.Clocks.Where(s => s.WorkId == id).FirstOrDefault();
        }

        public int Upt(Clock t)
        {
            my.Entry(t).State = EntityState.Modified;
            return my.SaveChanges();
        }
    }
}
