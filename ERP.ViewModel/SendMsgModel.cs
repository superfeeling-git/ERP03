using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ViewModel
{
    public class SendMsgModel
    {
        public int UserID { get; set; }
        public string Title { get; set; }
        public string MsgContent { get; set; }
        public DateTime AddTime { get; set; }
    }
}
