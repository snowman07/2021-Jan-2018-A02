using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.DAL;
using ChinookSystem.Entities; // for SQL and are internal
using ChinookSystem.ViewModels; // for data class to transfer data from BLL to webapp
using System.ComponentModel; //for ODS wizard
#endregion

namespace ChinookSystem.BLL
{
    // -----------------Coded on Jan 15, 2021 Friday Week02(result page is SearchByDDL)
    [DataObject]
    public class ArtistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> Artists_DDLList()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<SelectionList> results = from x in context.Artists
                                                     select new SelectionList
                                                     {
                                                         ValueField = x.ArtistId,
                                                         DisplayField = x.Name
                                                     };
                return results.ToList();
            }
        }
    }
}
