using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
   public class Clock
    {
        [Key]
        [Display(Name ="考勤ID")]
        public int WorkId { get; set; }
        [Display(Name = "员工编号")]
        public string StaffNO { get; set; }
        [Display(Name = "员工姓名")]
        public string StaffName { get; set; }
        [Display(Name = "打卡时间")]
        public DateTime HitTime { get; set; }

        [Display(Name ="上班或下班时间")]
        public DateTime Hours { get; set; }
        [Display(Name = "打卡状态")]
        public string HitSate { get; set; }
    }
}
