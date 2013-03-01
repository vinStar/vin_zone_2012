using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class High : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox2.Text = this.TextBox1.Text;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
      
        this.PnlAddEducationMask.Visible = true;  
        this.PnlAddEducationCntr.Visible = true;
        
    }
    protected void imgCloseInboxWindow_Click(object sender, ImageClickEventArgs e)
    {
        PnlAddEducationCntr.Visible = false;
        PnlAddEducationMask.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = false;
        this.Panel2.Visible = true;
    }
}
