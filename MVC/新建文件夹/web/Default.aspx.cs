using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Threading;
using System.Net;
using System.IO;



public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Thread.Sleep(2000);
        this.TextBox1.Text = GetStringSpell.GetChineseSpell(this.TextBox1.Text);

    }

    public static class GetStringSpell
    {
        public delegate void aa();
        /// <summary>
        /// 提取汉字首字母
        /// </summary>
        /// <param name="strText">需要转换的字</param>
        /// <returns>转换结果</returns>
        public static string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }
        /// <summary>
        /// 把提取的字母变成大写
        /// </summary>
        /// <param name="strText">需要转换的字符串</param>
        /// <returns>转换结果</returns>
        public static string GetLowerChineseSpell(string strText)
        {
            return GetChineseSpell(strText).ToLower();
        }
        /// <summary>
        /// 把提取的字母变成大写
        /// </summary>
        /// <param name="myChar">需要转换的字符串</param>
        /// <returns>转换结果</returns>
        public static string GetUpperChineseSpell(string strText)
        {
            return GetChineseSpell(strText).ToUpper();
        }
        /// <summary>
        /// 获取单个汉字的首拼音
        /// </summary>
        /// <param name="myChar">需要转换的字符</param>
        /// <returns>转换结果</returns>
        public static string getSpell(string myChar)
        {
            byte[] arrCN = System.Text.Encoding.Default.GetBytes(myChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return System.Text.Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "_";
            }
            else return myChar;
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string htmlPath = Server.MapPath("html");
       //this.form1.Name;
        GetHtml(this.Request.Url.ToString(), htmlPath+@"\"+this.form1.Name+".html");
    }

    public static void GetHtml(string url, string savepath)//url参数为将要生成的那个动态页面的地址，savepath为要存放地址  
    {
        string Result;
        WebResponse MyResponse;
        WebRequest MyRequest = System.Net.HttpWebRequest.Create(url);
        MyResponse = MyRequest.GetResponse();
        using (StreamReader MyReader = new StreamReader(MyResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")))//这里根据网站的编码格式而定  
        {
            Result = MyReader.ReadToEnd();
            MyReader.Close();
        }
        FileStream fs = new FileStream(savepath, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-8"));
        sw.WriteLine(Result);
        sw.Close();
        fs.Close();
    }
}
