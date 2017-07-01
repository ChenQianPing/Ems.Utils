using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils.Helper
{
    public class ReformerEmsHelper
    {
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
    }

    public class OmrAnswer
    {
        public int SerialNo { get; set; }
        public string Answer { get; set; }
    }




}
