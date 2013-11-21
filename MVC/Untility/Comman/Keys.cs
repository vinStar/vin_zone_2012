using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public abstract class Keys
    {
        /// <summary>
        /// 获取请求的语言信息
        /// </summary>
        public static string REGIONAL_LANGUAGE = "zh-cn";

        /// <summary>
        /// 请求路径中包含的区域语言参数
        /// </summary>
        public static string LANG_CODE = "lang";

        /// <summary>
        /// 错误页错误信息内容
        /// </summary>
        public static string MSG = "msg";

        /// <summary>
        /// 错误页错误代码
        /// </summary>
        public static string MSG_CODE = "msg_code";

        /// <summary>
        /// 配置文件中设置的支持的图片格式
        /// </summary>
        public static string ALLOW_EXTENSION = "pictureExtension";

        /// <summary>
        /// 默认文件保存路径关键字
        /// </summary>
        public static string SAVEPATH = "savepath";

        /// <summary>
        /// 支持的语言(枚举内容内不能放特殊字符，故将"-"替换为"_")
        /// </summary>
        public enum SUPPORTED_LANGUAGES
        {
            zh_cn,
            zh_tw,
            en_us
        }

        /// <summary>
        /// Judge类中所支持的类型
        /// </summary>
        public enum SUPPORTED_TYPE
        {
            digit,
            chinese,
            html,
            email
        }

        /// <summary>
        ///fileupload中涉及到的关键字 
        /// </summary>
        public enum FILEUPLOAD_ALLOW_EXTENSION
        {
            jpg,
            jpeg,
            png,
            gif,
            bmp
        }


        /// <summary>
        /// 错误页所支持的错误代码
        /// </summary>
        public enum ERRORCODE
        {
            code_404,
            code_500
        }
    }
}
