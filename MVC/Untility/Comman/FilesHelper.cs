using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Common
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public abstract class FilesHelper
    {
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Exists(string path)
        {
            bool _result = true;
            if (string.IsNullOrEmpty(path) || File.Exists(path))
            {
                _result = false;
            }
            return _result;
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFile(string path)
        {
            try
            {
                if (Exists(path))
                    File.Create(path);
                else
                    throw new Exception("文件创建失败，因为没有指定保存路径。");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool DeleteFile(string path)
        {
            try
            {
                bool _result = true;
                if (Exists(path)) File.Delete(path);
                else _result = false;
                return _result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
    }
}
