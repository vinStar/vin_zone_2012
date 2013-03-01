using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Base : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "test", "<script>alert('请输入姓名');</script>");
            return;
        }
        else
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "test", "<script>alert('成功');</script>");
        }
    }
}
