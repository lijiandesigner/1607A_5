using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Depart
    {
        [Display(Name = "部门Id")]
        public int DepartId { get; set; }
        [Display(Name = "部门名称")]
        public string DepartName { get; set; }
        [Display(Name = "部门描述")]
        public string DepartDesc { get; set; }
    }
}
