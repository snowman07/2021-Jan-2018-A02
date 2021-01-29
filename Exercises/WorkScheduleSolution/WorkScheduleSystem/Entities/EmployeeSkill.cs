using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WorkScheduleSystem.Entities
{
    internal partial class EmployeeSkill
    {
        public int EmployeeSkillID { get; set; }

        public int EmployeeID { get; set; }

        public int SkillID { get; set; }

        public int Level { get; set; }

        public int? YearsOfExperience { get; set; }

        [Column(TypeName = "money")]
        public decimal HourlyWage { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
