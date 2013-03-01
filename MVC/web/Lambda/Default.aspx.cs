using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Lambda_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        list.Add("liu12");
        list.Add("liu123");
        list.Add("li12");
        list.Add("u12");

        var varLam = list.FindAll(s => s.IndexOf("liu") >= 0 && 1==1);
        var varDele = list.FindAll(delegate(string s) { return s.IndexOf("liu") >= 0; });

    }
}