using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{

    // This is a REUSABLE CODE for DDL(dropdown list) that has value field and display field
    public class SelectionList
    {
        //value field of the instance
        public int ValueField { get; set; }

        //display field of the instance
        public string DisplayField { get; set; }
    }
}
