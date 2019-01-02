using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataHelp;
using Model;
namespace DAL
{
    public class GoTimeDal : IDataHelp<GoTime>
    {
        MyContext my = new MyContext();
        //打卡时间表添加
        public int Add(GoTime t)
        {
            my.GoTimes.Add(t);
            return my.SaveChanges();
        }
        //删除打卡时间表中信息
        public int Del(int id)
        {
            var qq = my.GoTimes.Where(s => s.GoTimeId == id).FirstOrDefault();
            my.Entry(qq).State = System.Data.Entity.EntityState.Deleted;
            return my.SaveChanges();
        }
        //显示打卡时间表
        public List<GoTime> GetList()
        {
            return my.GoTimes.ToList();
        }
        //根据条件查询表中数据
        public List<GoTime> GetList(GoTime t)
        {
            return my.GoTimes.Where(s => s.GoTimeId== t.GoTimeId).ToList();
        }
        //反填
        public GoTime GetT(int id)
        {
            return my.GoTimes.Where(s => s.GoTimeId == id).FirstOrDefault();
        }
        //修改打卡表中信息
        public int Upt(GoTime t)
        {
            my.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return my.SaveChanges();
        }
    }
}
