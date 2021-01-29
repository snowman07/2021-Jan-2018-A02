using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkScheduleSystem.ViewModels
{
    public class EmployeeSkillVM
    {
        public string FullName { get; set; }
        //public string FirstName { get; set; } //this is for the meantime because NotMapped FullName does not work in query
        public string HomePhone { get; set; }
        public bool Active { get; set; }
        public int Level { get; set; }
        public int? YearsOfExperience { get; set; }
        public int SkillID { get; set; }
    }
}
