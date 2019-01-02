using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace DAL
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MContext")
        {

        }
        public virtual DbSet<Clock> Clocks { get; set; }
        public virtual DbSet<Depart> Departs { get; set; }
        public virtual DbSet<GoTime> GoTimes { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
    }
}
