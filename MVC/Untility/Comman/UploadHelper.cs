using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;

namespace Common
{
    /// <summary>
    /// 文件上传类
    /// </summary>
    public abstract class UploadHelper
    {
        HttpRequest HttpRequest = null;
        HttpResponse HttpResponse = null;
        /// <summary>
        /// 上传文件错误时的提示信息（msg）:string
        /// </summary>
        static string msg_error = "{{\"error\":\"true\",\"msg\":\" {0} \"}}";
        /// <summary>
        /// 保存路径（savepath）:string
        /// 原始文件名称（originalname）:string
        /// </summary>
        static string msg_success = "{{\"error\":\"false\",\"msg\":\"文件上传成功\",\"savepath\":\"{0}\",\"originalname\":\"{1}\"}}";
        /// <summary>
        /// 初始化变量
        /// </summary>
        public UploadHelper()
        {
            HttpRequest = HttpContext.Current.Request;
            HttpResponse = HttpContext.Current.Response;
        }

        /// <summary>
        /// 文件上传方法一
        /// </summary>
        /// <param name="_controls">上传控件</param>
        /// <param name="_config">
        /// 配置内容(
        ///    允许上传的文件格式(allowextension):string
        ///    文件保存路径(savepath):string
        ///    是否以时间创建文件夹(accordingtime):true|false
        ///    是否打水印(needwatermark):true|false
        ///    水印内容(watermark):string
        ///    
        /// )</param>
        /// <returns></returns>
        public static string Init(FileUpload _controls, Dictionary<string, string> _config)
        {
            #region 基本配置信息

            HttpPostedFile postFile = _controls.PostedFile;
            if (postFile.ContentLength == 0) return string.Format(msg_error, "请选择文件");
            //文件保存路径
            string savePath = string.Empty;
            //允许的文件类型
            string allow_extension = string.Empty;
            //上传的文件名称
            string postFile_name = Path.GetFileName(postFile.FileName);
            //上传的文件类型
            string postFile_extension = Path.GetExtension(postFile_name);
            //是否以时间创建文件夹
            bool accordingtime = true;

            #endregion

            #region 所支持的上传的文件格式配置

            if (_config.ContainsKey(Keys.ALLOW_EXTENSION)) allow_extension = _config[Keys.ALLOW_EXTENSION].ToLower();

            try
            {
                if (string.IsNullOrEmpty(allow_extension)) allow_extension = ConfigurationManager.AppSettings[Keys.ALLOW_EXTENSION].ToString().ToLower();
            }
            catch (Exception)
            {
                allow_extension = string.Empty;
            }

            if (string.IsNullOrEmpty(allow_extension)) allow_extension = ".jpg .png .gif .jpeg .bmp";

            #endregion

            #region 文件上传

            if (postFile_extension == null ||
                !allow_extension.Contains(postFile_extension.ToLower()))
            {
                return string.Format(msg_error, "文件类型不被支持(仅限于" + allow_extension + "格式)");
            }
            else
            {
                #region 保存路径配置

                if (_config.ContainsKey(Keys.SAVEPATH)) savePath = _config[Keys.SAVEPATH];
                try
                {
                    if (string.IsNullOrEmpty(savePath)) savePath = ConfigurationManager.AppSettings[Keys.SAVEPATH].ToString();
                }
                catch (Exception)
                {
                    savePath = string.Empty;
                }
                if (string.IsNullOrEmpty(savePath)) savePath = "/upload/";

                #endregion

                #region 配置文件夹创建规则
                try
                {
                    if (_config.ContainsKey("accordingtime")) accordingtime = Convert.ToBoolean(_config["accordingtime"]);
                    else accordingtime = Convert.ToBoolean(ConfigurationManager.AppSettings["accordingtime"]);
                }
                catch (Exception) { }
                #endregion

                #region 保存文件

                if (string.IsNullOrEmpty(postFile_name)) return string.Format(msg_error, "请选择文件");
                else
                {
                    try
                    {
                        #region 保存
                        //保存文件夹
                        string _file_save_dir = DateTime.Now.ToString("yyyy-MM-dd");
                        //设置文件的名称
                        string _file_save_name = Guid.NewGuid() + postFile_extension;
                        //保存的文件路径
                        //string _file_save_basic_info = savePath;
                        string _file_save_basic_info = accordingtime ? savePath + _file_save_dir + "/" : savePath;
                        //if (accordingtime) _file_save_basic_info = savePath + _file_save_dir + "/";
                        //保存的完整web路径信息(向用户展示)
                        string _file_save_web_path = _file_save_basic_info + _file_save_name;
                        //获取保存文件夹相对于服务器的位置
                        string _file_save_path = HttpContext.Current.Server.MapPath("~" + _file_save_basic_info);
                        //保存的物理路径(不可像用户展示)
                        string _file_save_physical_path = _file_save_path + "/" + _file_save_name;

                        DirectoryInfo dirInfo = new DirectoryInfo(_file_save_path);
                        if (!dirInfo.Exists) dirInfo.Create();
                        _controls.SaveAs(_file_save_physical_path);

                        return string.Format(msg_success, _file_save_web_path, postFile_name);

                        #endregion
                    }
                    catch (Exception)
                    {
                        return string.Format(msg_error, "文件保存时发生错误，文件上传失败");
                    }
                }

                #endregion
            }

            #endregion
        }

        /// <summary>
        /// 文件上传方法二
        /// </summary>
        /// <param name="_controls">上传控件</param>
        /// <returns></returns>
        public static string Init(FileUpload _controls)
        {
            HttpPostedFile postFile = _controls.PostedFile;
            if (postFile.ContentLength == 0) return string.Format(msg_error, "请选择文件");
            //文件保存路径
            string savePath = string.Empty;
            //允许的文件类型
            string allow_extension = string.Empty;
            //上传的文件名称
            string postFile_name = Path.GetFileName(postFile.FileName);
            //上传的文件类型
            string postFile_extension = Path.GetExtension(postFile_name);

            #region 配置允许上传的文件类型信息

            try
            {
                allow_extension = ConfigurationManager.AppSettings[Keys.ALLOW_EXTENSION].ToString().ToLower();
            }
            catch (Exception)
            {
                allow_extension = ".jpg .png .gif .jpeg .bmp .flv .swf";
            }

            #endregion

            #region 文件上传

            if (postFile_extension == null ||
    !allow_extension.Contains(postFile_extension.ToLower()))
            {
                return string.Format(msg_error, "文件类型不被支持(仅限于" + allow_extension + "格式)");
            }
            else
            {
                try
                {
                    #region 保存路径配置

                    try
                    {
                        savePath = ConfigurationManager.AppSettings[Keys.SAVEPATH].ToString();
                    }
                    catch (Exception)
                    {
                        savePath = "/upload/";
                    }

                    #endregion
                    return savePostedFile(_controls, postFile_name, postFile_extension, savePath);
                }
                catch (Exception)
                {
                    //return string.Format(msg_error, e.Message);
                    return string.Format(msg_error, "文件保存时发生错误，文件上传失败");
                }
            }
            #endregion
        }

        /// <summary>
        /// 保存上传的文件
        /// </summary>
        /// <param name="_controls">上传控件名称</param>
        /// <param name="postFile_name">上传的文件名</param>
        /// <param name="postFile_extension">上传文件的后缀名</param>
        /// <param name="savePath">用户设定的保存路径</param>
        /// <returns></returns>
        private static string savePostedFile(FileUpload _controls, string postFile_name, string postFile_extension, string savePath)
        {
            //保存文件夹
            string _file_save_dir = DateTime.Now.ToString("yyyy-MM-dd");
            //设置文件的名称
            string _file_save_name = Guid.NewGuid() + postFile_extension;
            //保存的文件路径
            string _file_save_basic_info = savePath + _file_save_dir + "/";
            //保存的完整web路径信息(向用户展示)
            string _file_save_web_path = _file_save_basic_info + _file_save_name;
            //获取保存文件夹相对于服务器的位置
            string _file_save_path = HttpContext.Current.Server.MapPath("~" + _file_save_basic_info);
            //保存的物理路径(不可像用户展示)
            string _file_save_physical_path = _file_save_path + "/" + _file_save_name;

            DirectoryInfo dirInfo = new DirectoryInfo(_file_save_path);
            if (!dirInfo.Exists) dirInfo.Create();
            _controls.SaveAs(_file_save_physical_path);
            return string.Format(msg_success, _file_save_web_path, postFile_name);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="imgpath">缩略图绝对路径</param>
        /// <param name="smallWidth">缩略图宽</param>
        /// <param name="smallHeight">缩略图高</param>
        /// <returns>只返回生成的文件名，路径就是传进来的参数的相对路径</returns>
        public string scaleimg(string imgpath, int smallWidth, int smallHeight)
        {
            //读取大图
            System.Drawing.Image image = System.Drawing.Image.FromFile(imgpath);
            //按比例缩小 长高设定一个值
            if (image.Width < smallWidth) return Path.GetFileName(imgpath);
            if (image.Width > image.Height)
            {
                smallHeight = smallWidth * image.Height / image.Width;
            }
            else
            {
                smallWidth = smallHeight * image.Width / image.Height;
            }
            //缩略图
            Bitmap bitmap = new Bitmap(smallWidth, smallHeight);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(image, 0, 0, smallWidth, smallHeight);
            //保存图片 第二个参数根据自己的图片格式选择
            var savename = Path.GetFileNameWithoutExtension(imgpath);
            var savedir = Path.GetDirectoryName(imgpath);
            var savepath = savedir + "\\" + savename + "_scale" + Path.GetExtension(imgpath);
            bitmap.Save(savepath, System.Drawing.Imaging.ImageFormat.Jpeg);
            g.Dispose();
            bitmap.Dispose();
            image.Dispose();
            return Path.GetFileName(savepath);
        }

    }
}
