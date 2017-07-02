using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils.Helper
{
    public class ReformerEmsHelper
    {

        #region ValueTypeToList
        /// <summary>
        /// ValueTypeToList
        /// </summary>
        /// <param name="valueType">值类型</param>
        /// <param name="optionCount">选项数量</param>
        /// <returns></returns>
        public static List<string> ValueTypeToList(int valueType, int optionCount)
        {
            var values = "";

            switch (valueType)
            {
                case 0:
                    values = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                    break;
                case 1:
                    values = "0,1,2,3,4,5,6,8,9";
                    break;
                case 2:
                    values = "T,F";
                    break;
            }

            var lstValues = ConvertHelper.StringToList(values, ",");


            var strs = "";

            for (var i = 0; i < optionCount; i++)
            {
                var temp = lstValues[i];

                if (i == optionCount)
                {
                    strs = strs + temp;
                }
                else
                {
                    if (string.IsNullOrEmpty(strs))
                    {
                        strs = temp;
                    }
                    else
                    {
                        strs = strs + "," + temp;
                    }
                }
            }

            return ConvertHelper.StringToList(strs, ",");
        }
        #endregion

        #region ParseOmrs
        public static string ParseOmrs(string rcgOmr, List<OmrAnswer> lstAnswers)
        {
            /*
             * 更新选择题答案，传入更新的序号列表；
            rcgOmr =
                $@"B,C,A,A,B,B,C,C,C,A,#,B,#,#,B,#,#,#,#,#,D,D,B,C,A,C,A,B,B,C,#,#,#,A,D,#,#,E,D,F,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#";
            */

            var lstOmr = ConvertHelper.StringToList(rcgOmr, ",");

            var lastOmrs = "";
            for (var i = 0; i < lstOmr.Count; i++)
            {
                var tempAnswer = "#";

                // Tips：数据库中从1开始编号，这里要加1；
                if (lstAnswers.Exists(p => p.SerialNo == i + 1))
                {
                    var omrAnswer = lstAnswers.FirstOrDefault(p => p.SerialNo == i + 1);
                    if (omrAnswer != null)
                        tempAnswer = omrAnswer.Answer;

                }
                else
                {
                    tempAnswer = lstOmr[i];
                }

                if (string.IsNullOrEmpty(lastOmrs))
                {
                    lastOmrs = tempAnswer;
                }
                else
                {
                    lastOmrs = lastOmrs + "," + tempAnswer;
                }

            }

            return lastOmrs;
        }
        #endregion

        #region 识别结果转成选择题答案
        public static string ParseDetectResult(string detectResult, int valueType)
        {
            /*
            detectResult = @"0; 0; 1,2; 2; 2";
            valueType = 0;
            */

            var values = "";

            switch (valueType)
            {
                case 0:
                    values = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                    break;
                case 1:
                    values = "0,1,2,3,4,5,6,8,9";
                    break;
                case 2:
                    values = "T,F";
                    break;
            }

            var lstValues = ConvertHelper.StringToList(values, ",");
            var lstdetectResult = ConvertHelper.StringToList(detectResult, ";");

            var lastAnswers = "";
            
            foreach (var detectResult1 in lstdetectResult)
            {
                var lstDetectResult1 = ConvertHelper.StringToList(detectResult1, ",");

                var innerAnswers = "";

                for (var i = 0; i < lstDetectResult1.Count; i++)
                {
                    
                    var tempAnswer = "#";

                    // 这里以取到的值做为列表序号；
                    var tempValue = lstDetectResult1[i];
                    var index = Convert.ToInt32(tempValue);

                    tempAnswer = lstValues[index];

                    // Console.WriteLine("tempAnswer:" + tempAnswer);

                    if (string.IsNullOrEmpty(innerAnswers))
                    {
                        innerAnswers = tempAnswer;
                    }
                    else
                    {
                        innerAnswers = innerAnswers + tempAnswer;
                    }

                    // Console.WriteLine("innerAnswers:" + innerAnswers);
                }

                if (string.IsNullOrEmpty(lastAnswers))
                {
                    lastAnswers = innerAnswers;
                }
                else
                {
                    lastAnswers = lastAnswers + "," + innerAnswers;
                }
            }

            return lastAnswers;
        }
        #endregion
    }

    #region 解析OMR辅助类
    public class OmrAnswer
    {
        public int SerialNo { get; set; }
        public string Answer { get; set; }
    }
    #endregion




}
