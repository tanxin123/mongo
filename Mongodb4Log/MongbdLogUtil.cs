using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb4Log
{
    public static class MongbdLogUtil
    {
        public static string GetByKey(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception err)
            {
                return string.Empty;
            }
        }
    }
}
