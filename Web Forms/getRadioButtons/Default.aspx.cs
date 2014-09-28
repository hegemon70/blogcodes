using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{    
    protected void Button1_Click(object sender, EventArgs e)
    {
        IEnumerable<RadioButton> allRadios = Page.Form.Controls.OfType<RadioButton>();

        IEnumerable<RadioButton> byGroupname = getByGroupName(allRadios, "Grupo1");

        IEnumerable<RadioButton> radioCheked = getAllCheckeds(byGroupname, true);      
    }

    private IEnumerable<RadioButton> getByGroupName(IEnumerable<RadioButton> allRadios, string groupName)
    {
        return from radios in allRadios
               where radios.GroupName == groupName
               select radios;
    }
    private IEnumerable<RadioButton> getAllCheckeds(IEnumerable<RadioButton> byGroupname, bool check)
    {
        return from radios in byGroupname
               where radios.Checked == check
               select radios;
    }

    
}