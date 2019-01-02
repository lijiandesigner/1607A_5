using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
   public  class Leave
    {
        [Key]
        [Display(Name = "请假Id")]
        public int LeaveId { get; set; }
        [Display(Name = "员工工号")]
        public int StaffNo { get; set; }
        [Display(Name ="员工姓名")]
        public int StaffName { get; set; }
        [Display(Name = "开始请假时间")]
        public int StartLeaveTime { get; set; }
        [Display(Name = "结束请假时间")]
        public int EndLeaveTime { get; set; }
        [Display(Name = "请假原因")]
        public int LeaveReason { get; set; }
        [Display(Name = "审核人")]
        public int StaffId { get; set; }
        [Display(Name = "请假情况")]
        public int LeaveSate { get; set; }
    }
}
