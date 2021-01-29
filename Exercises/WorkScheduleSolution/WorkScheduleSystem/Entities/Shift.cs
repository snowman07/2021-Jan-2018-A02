using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WorkScheduleSystem.Entities
{
    internal partial class Shift
    {
        private string _Notes;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shift()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int ShiftID { get; set; }

        public int PlacementContractID { get; set; }

        public int DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public byte NumberOfEmployees { get; set; }

        public bool Active { get; set; }

        [StringLength(100, ErrorMessage = "Notes is limited to 100 characters.")]
        public string Notes 
        {
            get { return _Notes; }
            set { _Notes = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public virtual PlacementContract PlacementContract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
