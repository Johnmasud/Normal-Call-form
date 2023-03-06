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
using System.Text;


public partial class Test2 : System.Web.UI.Page
{


   
    protected void Page_Load(object sender, EventArgs e)
    {
        String Strtest;
        Strtest = "5";
        //string txt1, txt2;
        //txt1 = Request.Browser["IsMobileDevice"];

        //Response.Write("IsMobileDevice=" + txt1 + "<BR>");
        //txt2 = Request.Browser["BlackBerry"];

        //Response.Write("BlackBerry=" + txt2);

        //if (Request.Browser["IsMobileDevice"] != null && Request.Browser["IsMobileDevice"] == "true")
        //{
        //    Response.Redirect("https://mi12.sparinc.com/MXToolsLogin/MXSparmenu.asp");
        //}

        //if (Request.Browser["BlackBerry"] != null && Request.Browser["BlackBerry"] == "true")
        //{
        //    Response.Redirect("https://mi12.sparinc.com/MXToolsLogin/MXSparmenu.asp");
        //}
        //if (Request.UserAgent.ToLower().Contains("iphone"))
        //{
        //    Response.Redirect("https://mi12.sparinc.com/MXToolsLogin/MXSparmenu.asp");
        //}
        //if (Request.UserAgent.ToUpper().Contains("MIDP") || Request.UserAgent.ToUpper().Contains("CLDC"))
        //{
        //    Response.Redirect("https://mi12.sparinc.com/MXToolsLogin/MXSparmenu.asp");
        //}
       
    }
}
