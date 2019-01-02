﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Staff
    {
        [Key]
        [Display(Name ="员工Id")]
        public int StaffId { get; set; }
        [Display(Name ="员工编号")]
        public string StaffNo { get; set; }
        [Display(Name ="员工姓名")]
        public string StaffName { get; set; }
        [Display(Name ="员工身份证")]
        public string StaffCard { get; set; }
        [Display(Name ="员工性别")]
        public string StaffSex { get; set; }
        [Display(Name ="员工年龄")]
        public int StaffAge { get; set; }
        [Display(Name ="员工手机号码")]
        public string StaffPhone { get; set; }
        [Display(Name ="员工头像")]
        public string StaffPhoto { get; set; }
        [Display(Name ="所属部门")]
        public int DepartId { get; set; }
        [Display(Name ="所属职位")]
        public int JobId { get; set; }
        [Display(Name ="入职时间")]
        public DateTime StartTime { get; set; }
    }
}