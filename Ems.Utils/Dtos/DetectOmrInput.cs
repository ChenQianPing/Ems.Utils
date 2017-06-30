using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils.Dtos
{
    public class DetectOmrInput
    {
        public string PageId { get; set; }

        public int GroupX { get; set; }
        public int GroupY { get; set; }
        public int GroupWidth { get; set; }
        public int GroupHeight { get; set; }

        /// <summary>
        /// 比如说有5列，Pos_Y，逗号分隔
        /// </summary>
        public string ColumnPosY { get; set; }
        /// <summary>
        /// 一行多少个，间隔，逗号分隔，Pos_X
        /// </summary>
        public string ColumnPosX { get; set; }

        public int ColumnWidth { get; set; }
        public int ColumnHeight { get; set; }

    }
}
