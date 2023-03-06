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

public partial class TestDropDownMenu : System.Web.UI.Page
{
    protected string Email_Act_Flag, Str_internet_Access, Ele_Flag, Str_Merch_no, Str_User_id, ClientAccessType, Email_Status_Flag, EmailAddress, Collect_Mobile_Email, Mobile_Email, Merch_User, Spar_User, Cellphone_No, AreaCode, ThreeCode, FourCode, Str_carrier_id, ShowButton;
    protected int ClientAccessCode, Lang_id, Version_Browser, Check_MerchApp;
    public string[] vPrompts;
    protected string Wave_No, Task_No, Chain_No, Store_No, Str_txt_EmailAdd, Str_txt_Mobile_Email, RBSTORE, Type_Browser, LinkPath, Check_SparApp, Search_Merch_no, Merch_no_check, butStatus;
    private string Job_No, Str_Request_Method, Str_Http_Referer, SparLink_Text;
    protected bool Type_Chrome;
    #region SPARUTILS
    //code block for masterpage app, dont remove
    SPARValues WebAppClass;
    PromptTranslation ptAppTranslation;

    protected void Page_PreInit()
    {

        HttpCookie appcookies = null;
        appcookies = HttpContext.Current.Request.Cookies["spartoolsnew"];
        //Response.Write("appcookies=" + appcookies.Value);

        Str_Http_Referer = Request.ServerVariables["HTTP_REFERER"];
        //Response.Write("<BR>Str_Http_Referer=" + Str_Http_Referer + "<BR>");
        Str_Request_Method = Request.ServerVariables.Get("REQUEST_METHOD").ToString();


        //System.GC.Collect()
        string fullpath = Request.ServerVariables.Get("SERVER_NAME");
        //Response.Write("fullpath=" + fullpath + "<BR>");
        fullpath = "http://" + fullpath;
        //if (Request.Cookies["spartoolsnew"] != null)
        //{
        //    Response.Write("GooD");
        //}
        if (appcookies != null)
        {
            Str_Request_Method = "NoMessage";
        }
        //Response.Write("fullpath=" + fullpath + "<BR>");
        // Response.Write("Str_Request_Method=" + Str_Request_Method + "<BR>");
        //Response.End();
        if ((Str_Request_Method == "GETT") && String.IsNullOrEmpty(Str_Http_Referer))
        {
            //Response.Redirect("https://mi12.sparinc.com/MXToolsLogin/MXSparmenu.asp"); 
            Response.Redirect("" + fullpath + "/callformdotnet/CFLoginErrorMessage.aspx");
            //Response.Redirect("http://localhost:1406/SMP_callform/CFLoginErrorMessage.aspx"); 

        }
        else
        {
            SPARHeader PageHeader;
            SPARFooter PageFooter;
            SPARBiLingualBar BiLingualBar;
            PageHeader = (SPARHeader)this.Master.FindControl("SPARHeader1");
            PageFooter = (SPARFooter)this.Master.FindControl("SPARFooter1");
            BiLingualBar = (SPARBiLingualBar)this.Master.FindControl("SPARBiLingualBar1");
            WebAppClass = new SPARValues();
            WebAppClass.PageTitle = "";

            ptAppTranslation = new PromptTranslation("CFJWTInputs.aspx", WebAppClass.PromptsLanguageId.ToString(), WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection, WebAppClass.MultiLanguageCount);
            AppMasterControls ap1 = new AppMasterControls(PageHeader, PageFooter, BiLingualBar, WebAppClass.LoggedUserName, WebAppClass.CurrentDBDateTime, WebAppClass.LanguageId, WebAppClass.PromptsLanguageId, WebAppClass.MultiLanguageCount, WebAppClass.PageTitle, WebAppClass.CurrentSQLDBConnection, this.Page, WebAppClass.SPARLogoFileURL);

            //Response.Write("Merch_PreInit=" + WebAppClass.MerchNo + "<BR>");
            if (WebAppClass.MerchNo > 0)
            {
                PageFooter.ShowSPARToolsURL = false;
                PageFooter.ShowMainPageUrl = false;
            }
        }

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ptAppTranslation.DoPagePromptTranslation(this.Page);
        //if (WebAppClass.CurrentSQLDBConnection.State == ConnectionState.Open)
        //{
        //    WebAppClass.CurrentSQLDBConnection.Close();
        //    WebAppClass.CurrentSQLDBConnection.Close();
        //}
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
