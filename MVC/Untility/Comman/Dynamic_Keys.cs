using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

namespace Common
{
    /// <summary>
    /// 公共参数类
    /// </summary>
    public class Dynamic_Keys
    {
        /// <summary>
        /// 链接字符串
        /// </summary>
        private string connconnectionString;

        public string ConnconnectionString
        {
            get
            {
                string app_conn_key = Keys.REGIONAL_LANGUAGE.Replace("-", "_") + "_DbPath";
                return
                    ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString
                    + HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[app_conn_key]) + ";";
            }
            set { connconnectionString = value; }
        }
    }
}
