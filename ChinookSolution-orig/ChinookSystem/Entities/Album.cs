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
    [Table("Albums")]
    internal class Album
    {
        private string _ReleaseLabel;

        [Key] // PK in SSMS, Identity field is YES in SSMS
        public int AlbumId { get; set; }

        [Required(ErrorMessage ="Album title is required.")] //Required annotation. This is only handy for string
        [StringLength(160, ErrorMessage = "Album title is limited to 160 characters.")]
        public string Title { get; set; }

        //Foreign Key annotation is not needed here. If FK name is the same as the parent PK name, no need for annotation
        //Foreign Key annotation is ONLY required if FK name is different from the parent PK name 
        // public int?  --- this means that it is nullable
        public int ArtistId { get; set; }

        public int ReleaseYear { get; set; }

        [StringLength(50, ErrorMessage = "Album release label is limited to 50 characters.")]
        public string ReleaseLabel
        {
            get { return _ReleaseLabel; }
            set { _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value; } // fully implemented property
        }


        //[NotMapped] annotations are also allowed - use this annotation if data is not real data, meaning its not in db

        // navigational properties (not real data)
        //many to one direction (child to parent)
        public virtual Artist Artist { get; set; }

        // one to many direction (parent to child)
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
