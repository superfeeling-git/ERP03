using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ViewModel
{
    public class ProductClassModel
    {

        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassIntro { get; set; }
        public int Depth { get; set; }
        public int ParentID { get; set; }
        public string ParentPath { get; set; }
    }
}
