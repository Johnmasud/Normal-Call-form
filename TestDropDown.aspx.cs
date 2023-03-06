using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SPAR.Tools.Security;
using SPAR.Tools.MasterControls;
using SPAR.Tools.Utils;
using System.IO;
using CuteWebUI;

public partial class TestDropDown : System.Web.UI.Page
{
     

    protected void Page_Load(object sender, EventArgs e)
    {
        Test_DDMenu.Attributes.Add("onchange", "javascript:return DisplayColor2();");
        foreach (ListItem myItem in Test_DDMenu.Items)
        {
            myItem.Attributes.Add("style", "background-color:yellow");
        }
    }
}
