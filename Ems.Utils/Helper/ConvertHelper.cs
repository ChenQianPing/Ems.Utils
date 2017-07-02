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
        /// <param name="separator">分隔符，如：逗号,分号;</param>
        /// <returns></returns>
        public static string ListToString(List<string> list, string separator)
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
                    result.Append(separator);
                }
                result.Append(str);
            }

            return result.ToString();
        }


        #endregion

        #region StringToList

        public static List<string> StringToList(string strs, string separator)
        {
            var str = strs.Split(Convert.ToChar(separator));
            return str.ToList();
        }

        #endregion

    }
}
