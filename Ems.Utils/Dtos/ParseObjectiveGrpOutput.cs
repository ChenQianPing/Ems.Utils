using System;
using System.Drawing;

namespace Ems.Utils.Dtos
{
    public class ParseObjectiveGrpOutput
    {
        public string grpID { get; set; }
        public string grpName { get; set; }
        public int SerialNo { get; set; }

        /// <summary>
        /// 考试科目 ID，外键
        /// </summary>
        public string ExamCourseId { get; set; }

        /// <summary>
        /// 试卷页码
        /// </summary>
        public int PageNo { get; set; }
        public object Questions { get; set; }

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
        public int OptionCount { get; set; }
    }
}
