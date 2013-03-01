using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Untility.Caching
{
    /// <summary>
    /// Represents a FkrCache
    /// </summary>
    //public class FkrCache
    //{
    //    #region Fields
    //    private static readonly Cache _cache;
    //    public static string appPrefix = string.Empty;
    //    #endregion

    //    #region Constructor
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Creates a new instance of the FkrCache class
    //    /// </summary>
    //    static FkrCache()
    //    {
    //        HttpContext current = HttpContext.Current;
    //        if (current != null)
    //        {
    //            _cache = current.Cache;
    //        }
    //        else
    //        {
    //            _cache = HttpRuntime.Cache;
    //        }
    //    }
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Creates a new instance of the FkrCache class
    //    /// </summary>
    //    private FkrCache()
    //    {

    //    }
    //    #endregion

    //    #region Methods
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Removes all keys and values from the cache
    //    /// </summary>
    //    public static void Clear()
    //    {
    //        IDictionaryEnumerator enumerator = _cache.GetEnumerator();
    //        while (enumerator.MoveNext())
    //        {
    //            _cache.Remove(enumerator.Key.ToString());
    //        }
    //    }
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Gets or sets the value associated with the specified key.
    //    /// </summary>
    //    /// <param name="key">The key of the value to get.</param>
    //    /// <returns>The value associated with the specified key.</returns>
    //    public static object Get(string key)
    //    {
    //        appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
    //        return _cache[appPrefix + key];
    //    }
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Adds the specified key and object to the cache.
    //    /// </summary>
    //    /// <param name="key">key</param>
    //    /// <param name="obj">object</param>
    //    public static void Max(string key, object obj)
    //    {
    //        appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
    //        Max(appPrefix + key, obj, null);
    //    }
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Adds the specified key and object to the cache.
    //    /// </summary>
    //    /// <param name="key">key</param>
    //    /// <param name="obj">object</param>
    //    /// <param name="dep">cache dependency</param>
    //    public static void Max(string key, object obj, CacheDependency dep)
    //    {
    //        appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
    //        if (IsEnabled && (obj != null))
    //        {
    //            _cache.Insert(appPrefix + key, obj, dep, DateTime.MaxValue, TimeSpan.Zero,
    //                CacheItemPriority.AboveNormal, null);
    //        }
    //    }
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Adds the specified key and object to the cache.
    //    /// </summary>
    //    /// <param name="key">key</param>
    //    /// <param name="obj">object</param>
    //    /// <param name="dep">cache dependency</param>
    //    public static void SetCache(string key, object obj, CacheDependency dep, TimeSpan slidTime)
    //    {
    //        appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
    //        if (IsEnabled && (obj != null))
    //        {
    //            //_cache.Insert(key, obj, dep, Cache.NoAbsoluteExpiration, slidTime,
    //            //    CacheItemPriority.AboveNormal, null);
    //            _cache.Insert(appPrefix + key, obj, dep, DateTime.MaxValue, slidTime,
    //                CacheItemPriority.AboveNormal, null);
    //        }
    //    }

    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Adds the specified key and object to the cache.
    //    /// </summary>
    //    /// <param name="key">key</param>
    //    /// <param name="obj">object</param>
    //    /// <param name="dep">cache dependency</param>
    //    public static void SetCache(string key, object obj)
    //    {
    //        appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
    //        if (IsEnabled && (obj != null))
    //        {
    //            //_cache.Insert(key, obj, dep, Cache.NoAbsoluteExpiration, slidTime,
    //            //    CacheItemPriority.AboveNormal, null);
    //            _cache.Insert(appPrefix + key, obj);
    //        }
    //    }
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Removes the value with the specified key from the cache
    //    /// </summary>
    //    /// <param name="key"></param>
    //    public static void Remove(string key)
    //    {
    //        appPrefix = ConfigurationManager.AppSettings["CacheAppPrefix"].ToString();
    //        _cache.Remove(appPrefix + key);
    //    }
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Removes items by pattern
    //    /// </summary>
    //    /// <param name="pattern">pattern</param>
    //    public static void RemoveByPattern(string pattern)
    //    {
    //        IDictionaryEnumerator enumerator = _cache.GetEnumerator();
    //        Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
    //        while (enumerator.MoveNext())
    //        {
    //            if (regex.IsMatch(enumerator.Key.ToString()))
    //            {
    //                _cache.Remove(enumerator.Key.ToString());
    //            }
    //        }
    //    }
    //    #endregion

    //    #region Properties
    //    //-----------------------------------------------------------
    //    /// <summary>
    //    /// Gets or sets a value indicating whether the cache is enabled
    //    /// </summary>
    //    public static bool IsEnabled
    //    {
    //        get
    //        {
    //            return FkrConfig.CacheEnabled;
    //        }
    //    }
    //    #endregion
    //}     
}
