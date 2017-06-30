﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils
{
    public static class DetectOmrHelper
    {
        [DllImport("re.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DetectOMR(string f, int x, int y, int width, int height, string rows, string cols, int rwidth, int rheight);

        [DllImport("re.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DetectOMR2(string f, int x, int y, int width, int height, string rows, string cols, int rwidth, int rheight);

        #region Omr识别调用Delphi动态链接库
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
        public static string DetectOmr(string f, int x, int y, int width, int height, string rows, string cols, int rwidth, int rheigh)
        {

            /*
             * ;分隔；
             * ;;;;，没有识别出来是空  char(0)；
             * 
             * DetectOMR2 会弹出识别结果窗口；
             * DetectOMR 不会弹出识别结果窗口；
             */

            var result = Marshal.PtrToStringAuto(
                DetectOMR(f, x, y, width, height, rows, cols, rwidth, rheigh)
            );
            return result;
        }
        #endregion
    }
}