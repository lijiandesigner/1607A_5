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
        public string StaffNo { get; set; }
        [Display(Name ="员工姓名")]
        public string StaffName { get; set; }
        [Display(Name = "开始请假时间")]
        public string StartLeaveTime { get; set; }
        [Display(Name = "结束请假时间")]
        public string EndLeaveTime { get; set; }
        [Display(Name = "请假原因")]
        public string LeaveReason { get; set; }
        [Display(Name = "审核人")]
        public string AuditName { get; set; }
        [Display(Name = "请假状态")]
        public string LeaveState { get; set; }
        [Display(Name ="驳回原因")]
        public string RejectReason { get; set; }
    }
}
