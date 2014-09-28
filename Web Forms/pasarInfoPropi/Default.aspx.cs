using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page, Iwebforms 
{
    public string valor { get; set; }
    protected void Button1_Click(object sender, EventArgs e)
    {
        valor = txt_Info.Text;
    }
}
