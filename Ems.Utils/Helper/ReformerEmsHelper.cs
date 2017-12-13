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
                    values = "0,1,2,3,4,5,6,7,8,9";
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
        public static string ParseOmrs(List<Queue> lstQueue1, List<Queue> lstQueue2)
        {
            /*
             * 更新选择题答案，传入更新的序号列表；
            rcgOmr =
                $@"B,C,A,A,B,B,C,C,C,A,#,B,#,#,B,#,#,#,#,#,D,D,B,C,A,C,A,B,B,C,#,#,#,A,D,#,#,E,D,F,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#,#";
            */

            var leftJoinSql =
                from leftQueue in lstQueue1
                join rightQueue in lstQueue2 on leftQueue.SerialNo equals rightQueue.SerialNo into temp
                from temp01 in temp.DefaultIfEmpty()
                select temp01 == null ? leftQueue.Value : temp01.Value;

            return string.Join(",", leftJoinSql.ToList());

        }
        #endregion

        #region 解析识别结果，竖的情况
        /// <summary>
        /// 解析识别结果，竖的情况
        /// </summary>
        /// <param name="detectResult"></param>
        /// <param name="valueType">值类型：0 字母，1 数字，2 TF，默认为0</param>
        /// <param name="items">题目数</param>
        /// <returns></returns>
        public static string ParseDetectResult2(string detectResult, int valueType, int items)
        {
            var lstDetectResult = ConvertHelper.StringToList(detectResult, ";");
            var dict = new Dictionary<string, string>();
            var lstTemp = new List<string>();

            for (var i = 1; i <= items; i++)
            {
                lstTemp.Add(i.ToString());
            }

            for (var li = 0; li < lstDetectResult.Count; li++)
            {
                if (string.IsNullOrEmpty(lstDetectResult[li]))
                {
                    continue;
                }

                var lstTemp2 = lstDetectResult[li].Split(',').ToList<string>();

                for (var lj = 0; lj < lstTemp2.Count; lj++)
                {
                    if (string.IsNullOrEmpty(lstTemp2[lj]))
                    {
                        continue;
                    }

                    var qutsindex = int.Parse(lstTemp2[lj].ToString());

                    dict[lstTemp[qutsindex]] = "";

                    if (valueType.Equals(1))
                    {
                        dict[lstTemp[qutsindex]] += li.ToString();
                    }
                    else if (valueType.Equals(2))
                    {
                        if (li >= 0 && li <= 1)
                        {
                            switch (li)
                            {
                                case 0:
                                    dict[lstTemp[qutsindex]] += "T";
                                    break;
                                case 1:
                                    dict[lstTemp[qutsindex]] += "F";
                                    break;
                                default:
                                    dict[lstTemp[qutsindex]] += "#";
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (li >= 0 && li <= 26)
                        {
                            var array = new byte[1];
                            array[0] = (byte) (Convert.ToInt32(li + 'A')); // ASCII码强制转换二进制
                            dict[lstTemp[qutsindex]] += Convert.ToString(Encoding.ASCII.GetString(array));
                        }
                    }
                }
            }

            var lstQueue1 = new List<Queue>();
            var lstQueue2 = new List<Queue>();

            foreach (var result in dict)
            {
                var queue = new Queue
                {
                    SerialNo = int.Parse(result.Key),
                    Value = result.Value
                };
                lstQueue1.Add(queue);
            }

            for (var i = 1; i <= items; i++)
            {
                var queue = new Queue
                {
                    SerialNo = i,
                    Value = "#"
                };
                lstQueue2.Add(queue);
            }

            // 结果处理
            var finalResult = ParseOmrs(lstQueue2, lstQueue1);
            return finalResult;
        }
        #endregion

        #region 识别结果转成选择题答案
        public static string ParseDetectResult(string detectResult, int valueType)
        {
            /*
            detectResult = @"0; 0; 1,2; 2; 2";
            ";;2;;;;;;;;;;;;"
            "0;1;1;0;1;1;2;1;2;;1;1;2;0;2"
            valueType = 0;
            */

            var values = "";

            switch (valueType)
            {
                case 0:
                    values = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                    break;
                case 1:
                    values = "0,1,2,3,4,5,6,7,8,9";
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

                    if (string.IsNullOrEmpty(tempValue))
                    {
                        tempAnswer = "#";
                    }
                    else
                    {
                        var index = Convert.ToInt32(tempValue);
                        tempAnswer = lstValues[index];
                    }
                   

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

    #region 解析队列辅助类
    public class Queue
    {
        public int SerialNo { get; set; }
        public string Value { get; set; }
    }
    #endregion




}
