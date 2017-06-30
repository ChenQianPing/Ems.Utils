using System;

namespace Ems.Utils.Dtos
{
    public class ParseObjectQutOutput
    {
        /// <summary>
        /// 问题ID
        /// </summary>
        public string QuestionsID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string QuestionsName { get; set; }

        public string grpID { get; set; }

        /// <summary>
        /// 题号
        /// </summary>
        public int SerialNo { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageNo { get; set; }

        public int OptionCount { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
