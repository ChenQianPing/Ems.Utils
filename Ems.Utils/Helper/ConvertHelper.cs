using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils.Helper
{
    public class ConvertHelper
    {
        #region ListToString
        /// <summary>
        /// 迭代List的每个子项，将他们用“,”隔开
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ListToString(List<string> list)
        {
            if (list == null)
            {
                return null;
            }

            var result = new StringBuilder();
            var first = true;

            // 第一个前面不拼接","
            foreach (var str in list)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    result.Append(",");
                }
                result.Append(str);
            }

            return result.ToString();


        }
        #endregion

        #region StringToList
        public static List<string> StringToList(string strs)
        {
            var str = strs.Split(Convert.ToChar(","));
            return str.ToList();
        }
        #endregion

        #region ValueTypeToList
        /// <summary>
        /// ValueTypeToList
        /// </summary>
        /// <param name="valueType">值类型</param>
        /// <param name="optionCount">选项数量</param>
        /// <returns></returns>
        public static List<string> ValueTypeToList(int valueType,int optionCount)
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

            var lstValues =  ConvertHelper.StringToList(values);


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

            return ConvertHelper.StringToList(strs);
        }
        #endregion

    }
}
