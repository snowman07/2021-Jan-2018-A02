using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using WorkScheduleSystem.DAL;
using WorkScheduleSystem.Entities;
using WorkScheduleSystem.ViewModels;
using System.ComponentModel; // to expose ODS wizard
#endregion

namespace WorkScheduleSystem.BLL
{
    [DataObject]
    public class SkillController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> Skills_DDLLists()
        {
            using (var context = new WorkScheduleContext())
            {
                IEnumerable<SelectionList> results = from x in context.Skills
                                                     select new SelectionList
                                                     {
                                                         ValueField = x.SkillID,
                                                         DisplayField = x.Description
                                                     };
                return results.ToList();
            }
        }
    }
}
