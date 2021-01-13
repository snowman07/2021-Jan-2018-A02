using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.Entities
{
    [Table("Artists")] // table annotation - ("Name of SQL table")
    internal class Artist
    {
        private string _Name; //fully implemented property (in ERD, "Allow Nulls" is checked thats why it needs to be fully implemented)
        
        [Key] // PK in SSMS, Identity field is YES in SSMS
        public int ArtistId { get; set; }

        [StringLength(120, ErrorMessage = "Artist name is limited to 120 characters.")] //Annotation of validation
        public string Name //this property is nullable field, it means "Allow Nulls" is checked in ERD, so it needs to be fully implemented
        {
            get { return _Name; } 
            set{ _Name = string.IsNullOrEmpty(value) ? null : value; } // fully implemented property
        }

        // navigational property
        // one to many direction (parent to child)
        public virtual ICollection<Album> Albums { get; set; }
    
    }
}
