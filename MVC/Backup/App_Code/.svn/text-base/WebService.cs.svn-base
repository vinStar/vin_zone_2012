using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public AjaxClass CheckUid(string uid)
    {
        //return uid == "testuid" ? true : false;
        AjaxClass ajaxClass = new AjaxClass();
        try
        {
            if (uid == "testuid")
            {
                ajaxClass.Msg = "用户名已存在,请重新输入!";
                ajaxClass.Result = 0;
            }
            if (uid.IndexOf("test") == -1)
            {
                ajaxClass.Msg = "用户名格式不正确,用户名必须包含test,请重新输入!";
                ajaxClass.Result = 0;
            }
            else
            {
                ajaxClass.Msg = "格式正确!";
                ajaxClass.Result = 1;
            }
        }
        catch
        {
            ajaxClass.Msg = "程序出现异常,请联系管理员!";
            ajaxClass.Result = 0;
        }
        return ajaxClass;
    }
}

