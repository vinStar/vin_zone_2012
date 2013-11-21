using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// 判断类
    /// </summary>
    public abstract class JudgeHelper
    {
        #region 正则表达式区域

        private const string reg_chinese = @"^([\u2E80-\u9FFF]+)";
        private const string reg_digit = @"\D";
        private const string reg_html = @"^(<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>))";
        private const string reg_email = @"^([a-z\d]+(\.[a-z\d]+)*@([\da-z](-[\da-z])?)+(\.{1,2}[a-z]+)+)";

        #endregion

        /// <summary>
        /// 验证是否符合类型
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static bool Judge(string _input, Keys.SUPPORTED_TYPE _type)
        {
            bool _result = false;
            Regex regex = null;
            try
            {
                switch (_type)
                {
                    case Keys.SUPPORTED_TYPE.chinese:
                        regex = new Regex(reg_chinese);
                        break;
                    case Keys.SUPPORTED_TYPE.digit:
                        regex = new Regex(reg_digit);
                        break;
                    case Keys.SUPPORTED_TYPE.html:
                        regex = new Regex(reg_html);
                        break;
                    case Keys.SUPPORTED_TYPE.email:
                        regex = new Regex(reg_email);
                        break;
                }
                _result = !regex.IsMatch(_input.ToLower());
            }
            catch (Exception)
            {
                _result = false;
            }
            return _result;
        }
    }
}
