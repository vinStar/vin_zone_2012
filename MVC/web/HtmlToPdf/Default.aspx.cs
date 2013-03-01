using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Untility.Comman;


public partial class HtmlToPdf_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnToPDF_Click(object sender, EventArgs e)
    {
        HtmlToPdf pdf = new HtmlToPdf();
        pdf.PrintToPDF("demo");
    }
}