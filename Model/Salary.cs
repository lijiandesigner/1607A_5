using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
   public  class Salary
    {
        [Key]
        [Display(Name ="工资Id")]
        public int MoneyId { get; set; }

        [Display(Name = "员工工号")]
        public string StaffNo { get; set; }
        [Display(Name ="员工姓名")]
        public string StaffName { get; set; }
        [Display(Name = "员工基本工资")]
        public float JobMoney { get; set; }
        [Display(Name = "处罚工资")]
        public float PunishMoney { get; set; }
        [Display(Name = "奖励工资")]
        public float AwardMoney { get; set; }
        [Display(Name = "请假应减工资")]
        public float LeaveMoney { get; set; }
        [Display(Name = "出差补资")]
        public float AllowMoney { get; set; }
        [Display(Name = "应发工资")]
        public float TrueMoney { get; set; }
        [Display(Name = "工资领取状态")]
        public string MoneySate { get; set; }
    }
}
