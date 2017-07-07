using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RcgOmrConsole
{
    class Program
    {
        // 静态调用，DllImport声明
        [DllImport("re.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DetectOMR(string f, int x, int y, int width, int height, string rows, string cols, int rwidth, int rheight);


        static void Main(string[] args)
        {
            if (args.Length != 9)
            {
                Console.WriteLine("识别方法需要传入9个参数！");
                return;
            }

            var f = args[0];
            var x = Convert.ToInt32(args[1]);
            var y = Convert.ToInt32(args[2]);
            var width = Convert.ToInt32(args[3]);
            var height = Convert.ToInt32(args[4]);
            var rows = args[5];
            var cols = args[6];
            var rwidth = Convert.ToInt32(args[7]);
            var rheigh = Convert.ToInt32(args[8]);

            try
            {
                var omrs = DetectOmrByStatic(f, x, y, width, height, rows, cols, rwidth, rheigh);
                Console.WriteLine(omrs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region Omr识别静态调用Delphi动态链接库
        /// <summary>
        /// Omr识别
        /// </summary>
        /// <param name="f">图片物理路径</param>
        /// <param name="x">分组框x</param>
        /// <param name="y">分组框y</param>
        /// <param name="width">分组框width</param>
        /// <param name="height">分组框height</param>
        /// <param name="rows">分组框y坐标集边的点，逗号分隔，如题目数 5个，Pos_Y 5题</param>
        /// <param name="cols">分组框选项数Pos_X，逗号分隔，如3列</param>
        /// <param name="rwidth">选择题里面那个小框的width</param>
        /// <param name="rheigh">选择题里面那个小框的heigh</param>
        /// <returns></returns>
        public static string DetectOmrByStatic(string f, int x, int y, int width, int height, string rows, string cols, int rwidth, int rheigh)
        {
            var result = Marshal.PtrToStringAuto(
                DetectOMR(f, x, y, width, height, rows, cols, rwidth, rheigh)
            );
            return result;
        }
        #endregion
    }
}


/* 
 * 调用示例：需要传入9个参数；
 * RcgOmrConsole "0.jpg" "175" "825" "218" "166" "20,49,76,104,131" "58,108,158" "30" "17"
 * 命名为多个exe，如：RcgOmrConsole01、RcgOmrConsole02；
 */
