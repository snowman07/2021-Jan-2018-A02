using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WorkScheduleSystem.Entities
{
    internal partial class Location
    {
        private string _Contact;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            PlacementContracts = new HashSet<PlacementContract>();
        }

        public int LocationID { get; set; }

        [Required(ErrorMessage = "Location name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Location name is limited to 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Street is limited to 50 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "City is limited to 30 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(2, ErrorMessage = "Province is limited to 2 characters.")]
        public string Province { get; set; }

        [StringLength(50, ErrorMessage = "Contact is limited to 50 characters.")]
        public string Contact 
        {
            get { return _Contact; }
            set { _Contact = string.IsNullOrEmpty(value) ? null : value; } 
        }

        [Required(ErrorMessage = "Phone is required.")]
        [StringLength(12, ErrorMessage = "Phone is limited to 12 characters.")]
        public string Phone { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlacementContract> PlacementContracts { get; set; }
    }
}
