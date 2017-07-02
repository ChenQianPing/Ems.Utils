using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Utils.Helper
{
    public class TxtToJson
    {
        public static T GetModel<T>(string strjson)
        {           
            try
            {
                T obj = (T)Newtonsoft.Json.JsonConvert.DeserializeObject(strjson, typeof(T));
                return obj;
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        public static List<T> GetListModel<T>(string strjson)
        {
            try
            {
                var plist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(strjson);
                 return plist;
            }
            catch (IOException e)
            {
                throw e;
            }
        }

    }
}
