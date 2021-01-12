﻿using System;
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
    [Table("Artists")] // table annotation
    internal class Artist
    {
        private string _Name;
        
        [Key] // Identity field in SSMS
        public int ArtistId { get; set; }

        [StringLength(120, ErrorMessage = "Artist name is limited to 120 characters.")]
        public string Name 
        {
            get { return _Name; } 
            set{ _Name = string.IsNullOrEmpty(value) ? null : value; } // fully implemented property
        }

        // navigational property
        // one to many direction (parent to child)
        public virtual ICollection<Album> Albums { get; set; }
    
    }
}
