using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class GoTime
    {
        [Key]
        [Display(Name = "打卡时间编号")]
        public int GoTimeId { get; set; }
        [Display(Name = "上午上班时间")]
        public DateTime AMGoTime { get; set; }
        [Display(Name = "上午下班时间")]
        public DateTime AMComeTime { get; set; }
        [Display(Name = "下午上班时间")]
        public DateTime PMGoTime { get; set; }
        [Display(Name = "下午下班时间")]
        public DateTime PMComeTime { get; set; }

    }
}
