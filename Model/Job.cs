using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Job
    {
        [Key]
        [Display(Name ="职位编号")]
        public int JobId { get; set; }
        [Display(Name ="职位名称")]
        public string JobName { get; set; }
        [Display(Name ="职位描述")]
        public string JobDesc { get; set; }
        [Display(Name ="职位基本工资")]
        public float JobMoney { get; set; }
    }
}
