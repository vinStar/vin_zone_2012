using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enyim.Caching;
using System.Configuration;
using Enyim.Caching.Memcached;

namespace Untility.Caching
{
    public class EnyimMemcached
    {
        #region 定义变量
        private static readonly MemcachedClient mc = null;
        public static string appPrefix = string.Empty;
        public static bool bResault;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        static EnyimMemcached()
        {
            mc = new MemcachedClient();
        }
        private EnyimMemcached()
        {

        }
        #endregion

        #region 方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
            return mc.Get(appPrefix + key);
        }

        public static void SetCache(string key, object obj)
        {
            appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
            if (obj != null)
            {
                mc.Store(StoreMode.Set, appPrefix + key, obj);
            }
        }
        public static void SetCache(string key, object obj, TimeSpan slidTime)
        {
            appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
            if (obj != null)
            {
                mc.Store(StoreMode.Set, appPrefix + key, obj, slidTime);
            }
        }
        public static bool KeyExists(string key)
        {
            bResault = true;
            appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
            if (mc.Get(appPrefix + key) == null)
            {
                bResault = false;
            }
            return bResault;
        }

        public static void Remove(string key)
        {
            appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
            mc.Remove(appPrefix + key);
        }
        #endregion
    }
}
