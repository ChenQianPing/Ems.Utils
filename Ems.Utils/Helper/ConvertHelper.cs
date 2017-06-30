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
        public static List<string> ValueTypeToList(int valueType)
        {
            var value = "";

            switch (valueType)
            {
                case 0:
                    value = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                    break;
                case 1:
                    value = "0,1,2,3,4,5,6,8,9";
                    break;
                case 2:
                    value = "T,F";
                    break;
            }

            return ConvertHelper.StringToList(value);
        }
        #endregion

    }
}
