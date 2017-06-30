using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils.Dtos
{
    public class ParseFrameOutput
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        public string FrameID { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string FrameName { get; set; }

        /// <summary>
        /// 模块区域类型
        /// 1 定位器
        /// 4 考号
        /// 5 选择题
        /// 6 切割区
        /// 10 保密区
        /// </summary>
        public int FrameType { get; set; }

        /// <summary>
        /// 序号，默认为了，从 1 开始自增加 1；
        /// </summary>
        public int SerialNo { get; set; }

        /// <summary>
        /// 考试科目 ID，外键
        /// </summary>
        public string ExamCourseId { get; set; }

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
        /// OMR 区域设置
        /// </summary>
        public object Setting { get; set; }
    }

}
