using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils.Dtos
{
    public class ParseOptionOutput
    {
        public string OptionID { get; set; }
        public string OptionName { get; set; }
        public string QuestionsID { get; set; }
        public string colID { get; set; }
        public int SerialNo { get; set; }

        /// <summary>
        /// 考试科目 ID，外键
        /// </summary>
        public string grpID { get; set; }

        /// <summary>
        /// 试卷页码
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// WIDTH
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// HEIGHT
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// isFirst
        /// </summary>
        public int isFirst { get; set; }
    }
}
