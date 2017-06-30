using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils.Dtos
{
    public class ParseColOutput
    {
        public string colID { get; set; }
        public string QuestionsID { get; set; }
        public string grpID { get; set; }
        public int SerialNo { get; set; }
        public int PageNo { get; set; }
        public int isFirst { get; set; }
        public int X { get; set; }
    }
}
