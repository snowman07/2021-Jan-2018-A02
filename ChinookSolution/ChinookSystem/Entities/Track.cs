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
    [Table("Tracks")]
    internal class Track
    {
        private string _Composer;

        [Key]
        public int TrackId { get; set; }

        [Required(ErrorMessage = "Track name is required.")]
        [StringLength(120, ErrorMessage = "Track name is limited to 120 characters.")]
        public string Name { get; set; }

        public int? AlbumId { get;  set; } // nullable int

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; } // nullable int

        [StringLength(120, ErrorMessage = "Track composer is limited to 120 characters.")]
        public string Composer 
        {
            get { return _Composer; }
            set { _Composer = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; } // nullable int

        public int UnitPrice { get; set; }


        //navigational property
        //child to parent (many to one)
        public virtual Album Album { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual MediaType MediaType { get; set; }
    }
}
