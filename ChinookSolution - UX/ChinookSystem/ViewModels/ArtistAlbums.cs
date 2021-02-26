using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    public class ArtistAlbums
    {
        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public string ArtistName { get; set; }

        public int ArtistId { get; set; } // -----------Added on Jan 15, 2021 Friday Week02(result page is SearchByDDL)
    }
}
