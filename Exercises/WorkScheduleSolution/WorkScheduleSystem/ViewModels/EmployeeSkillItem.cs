using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkScheduleSystem.ViewModels
{
    public class EmployeeSkillItem
    {
        public int EmployeeSkillID { get; set; }
        public int EmployeeID { get; set; }
        public string Employee {get; set;} // for navigational property
        public int SkillID { get; set; }
        public string Skill { get; set; } // for navigational property
        public int Level { get; set; }
        public int? YearsOfService { get; set; }
        public decimal HourlyWage { get; set; }

    }
}
