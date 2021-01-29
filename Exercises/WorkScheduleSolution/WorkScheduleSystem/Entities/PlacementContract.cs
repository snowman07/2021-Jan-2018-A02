using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WorkScheduleSystem.Entities
{
    internal partial class PlacementContract
    {
        private string _Requirements;
        private string _Reason;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlacementContract()
        {
            ContractSkills = new HashSet<ContractSkill>();
            Shifts = new HashSet<Shift>();
        }

        public int PlacementContractID { get; set; }

        public int LocationID { get; set; }

        [Required(ErrorMessage = "_Placement contract title is required.")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "Placement contract title is limited to 64 characters.")]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [StringLength(256, ErrorMessage = "Requirements is limited to 256 characters.")]
        public string Requirements 
        {
            get { return _Requirements; }
            set { _Requirements = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public DateTime? Cancellation { get; set; }

        [StringLength(200, ErrorMessage = "Reason is limited to 200 characters.")]
        public string Reason 
        {
            get { return _Reason; }
            set { _Reason = string.IsNullOrEmpty(value) ? null : value; } 
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractSkill> ContractSkills { get; set; }

        public virtual Location Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
