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


public partial class CFJWT_Input_Photo_Option : System.Web.UI.Page
{
    protected string StrGridDates, Str_Merch_no, user_id, Email_Active_Flag, Job_No, Wave_No, Task_No, Chain_No, Store_No, txt_EmailAdd, txt_Mobile_Email, POutOfStock_no, Error_Message, Error_Flag, HTMLHeader_info, Collect_Mobile_Email, AddressRule, NameRule, DateRule, Job_Visit_Date;
    protected int Error_Message_Flag, BusinessQuestion_Flag, Back_Slash, Dot, Dash, ShowType, Lang_id, URL_status;
    public string[] vPrompts;
    protected string Date_input, txt_Phone1, txt_Phone2, txt_Phone3, CellProvider, Hidden_PhoneStatus, CellPhoneNo, Photo_By_QuestionFlag, strJob_Visit_Date, Bus_rule22_MV_NewVisit, Bus_rule22_Photo_Required, NewScreenPage, StrNewCallFormPathLink, Display_Prod_Data_btn, Display_Assembly_btn;
    private string  Str_Request_Method, Str_Http_Referer;
    protected bool Type_Chrome;
    protected string Str_Http_URL, Str_HTTP_HOST, Current_URL, Str_SERVER_NAME, DCM_ServerName, DCM_PathName, ACM_ServerName, ACM_PathName, DCM_Url, ACM_Url, Bus_Rule_Url, Prod_Data_Url, Assembly_Url, Business_Type_id, WebConfig_ServerName, Return_CallFormPath, EnableVideo_OptionFlag, Str_Sv_Panel_id, GoLiteDate, Golite_status;
    protected string StrMTYPE, StrLogInMtype, StrPTYPE, StrPromptcheck, ACM_ServerNameTest, ACM_PathNameTest, Var_AssemblyQueryString, Var_DataCollectQueryString, DCM_ServerNameTest, DCM_PathNameTest, StrAccessToNewDataCollectApp_flag, StrAccessToNewAssemblyApp_flag, StrCall_Form_Reported, strCFreported;

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

            ptAppTranslation = new PromptTranslation("CFJWT_Input_Photo_Option.aspx", WebAppClass.PromptsLanguageId.ToString(), WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection, WebAppClass.MultiLanguageCount);
            AppMasterControls ap1 = new AppMasterControls(PageHeader, PageFooter, BiLingualBar, WebAppClass.LoggedUserName, WebAppClass.CurrentDBDateTime, WebAppClass.LanguageId, WebAppClass.PromptsLanguageId, WebAppClass.MultiLanguageCount, WebAppClass.PageTitle, WebAppClass.CurrentSQLDBConnection, this.Page, WebAppClass.SPARLogoFileURL);

            //Response.Write("Merch_PreInit=" + WebAppClass.MerchNo + "<BR>");
            if (WebAppClass.MerchNo > 0)
            {
                PageFooter.ShowSPARToolsURL = false;
                PageFooter.ShowMainPageUrl = false;
                PageFooter.CopyRightText = string.Empty;
                PageFooter.AllRightsReservedText = string.Empty;
            }
            if (WebAppClass.LanguageId.Equals(18))
            {
                PageFooter.CopyRightText = "";
                PageFooter.AllRightsReservedText = "";
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
        WebAppClass.Set_MerchforForm(this.Merch_no, Convert.ToString(WebAppClass.MerchNo));

        //Str_Merch_no = Convert.ToString(WebAppClass.MerchNo);
        //Response.Write("Merch_noBefore=" + Str_Merch_no + "<BR>");
        Str_Http_URL = Request.ServerVariables["URL"];
        //Response.Write("<BR>Str_Http_URL=" + Str_Http_URL + "<BR>");

        Str_HTTP_HOST = Request.ServerVariables["HTTP_HOST"];
        // Response.Write("<BR>Str_HTTP_HOST=" + Str_HTTP_HOST + "<BR>");


        Current_URL = "http://" + Str_HTTP_HOST.Trim() + "" + Str_Http_URL.Trim() + "";
        //Response.Write("<BR>Current_URL=" + Current_URL + "<BR>");

        Str_SERVER_NAME = Request.ServerVariables["SERVER_NAME"];
        //Response.Write("<BR>Str_SERVER_NAME=" + Str_SERVER_NAME + "<BR>");

        WebConfig_ServerName = ConfigurationManager.AppSettings["ServerName"];
        // Response.Write("WebConfig_ServerName=" + WebConfig_ServerName);

        DCM_ServerName = ConfigurationManager.AppSettings["DataCollectionServer"];
        // Response.Write("DCM_ServerName=" + DCM_ServerName);
        DCM_PathName = ConfigurationManager.AppSettings["DataCollectionPath"];
       //  Response.Write("DCM_PathName=" + DCM_PathName);

        DCM_ServerNameTest = ConfigurationManager.AppSettings["DataCollectionServerTest"];
       // Response.Write("DCM_ServerNameTest=" + DCM_ServerNameTest + "<BR>");
        DCM_PathNameTest = ConfigurationManager.AppSettings["DataCollectionPathTest"];
         //Response.Write("DCM_PathNameTest=" + DCM_PathNameTest + "<BR>");

        ACM_ServerName = ConfigurationManager.AppSettings["AssemblyCollectionServer"];
         //Response.Write("ACM_ServerName=" + DCM_ServerName);
        ACM_PathName = ConfigurationManager.AppSettings["AssemblyCollectionPath"];
       //  Response.Write("ACM_PathName=" + ACM_PathName);
        ACM_ServerNameTest = ConfigurationManager.AppSettings["AssemblyCollectionServerTest"];
        //  Response.Write("ACM_ServerName=" + DCM_ServerName);
        ACM_PathNameTest = ConfigurationManager.AppSettings["AssemblyCollectionPathTest"];
        //****** System Rules
        DataTable RuleTab = new DataTable();
        RuleTab = GetSystemRules();

        AddressRule = RuleTab.Rows[5][2].ToString();
        // Response.Write("AddressRule=" + AddressRule);

        DateRule = RuleTab.Rows[1][2].ToString();
          //Response.Write("DateRule=" + DateRule);

        NameRule = RuleTab.Rows[0][2].ToString();
        //Response.Write("NameRule=" + NameRule);

        //****** Prompts
        GetPromptTranslation();

        //******************************* Date format
        Back_Slash = DateRule.IndexOf("/");
        //response.write "Back_Slash=" & Back_Slash & "<BR>" 
        if (Back_Slash > 0)
        {
            Date_input = "/";
        }
        Dot = DateRule.IndexOf(".");
        //response.write "Dot=" & Dot & "<BR>" 
        if (Dot > 0)
        {
            Date_input = ".";
        }
        Dash = DateRule.IndexOf("-");
        //response.write "Dot=" & Dot & "<BR>" 
        if (Dash > 0)
        {
            Date_input = "-";
        }

        //********************* Variables from the CFPictureGetFileOption

        StrAccessToNewAssemblyApp_flag = Request.Form["AccessToNewAssemblyApp_flag"];
        StrAccessToNewDataCollectApp_flag = Request.Form["AccessToNewDataCollectApp_flag"];


        StrNewCallFormPathLink = ConfigurationManager.AppSettings["NewCallFormPathLink"];
        // Response.Write("StrNewCallFormPathLink=" + StrNewCallFormPathLink);
        NewScreenPage = Request.Form["NewScreenPage"];
      //  Response.Write("NewScreenPage=" + NewScreenPage);
        GoLiteDate = Request.Form["GoLiteDate"];
      //  Response.Write("GoLiteDate=" + GoLiteDate);
        Lang_id = WebAppClass.LanguageId;
        //Response.Write(Lang_id);
        if (Lang_id != 1)
        {
            if (Lang_id != 13)
            {
                StrNewCallFormPathLink = StrNewCallFormPathLink.Replace("webreportms", "sparinc");
                //ElementAnswer = ElementAnswer.Replace("\n", " ");  
            }
        }
        URL_status = Str_HTTP_HOST.IndexOf("sparinc");
       // Response.Write("<BR>URL_status=" + URL_status + "<BR>");

        if (URL_status > 0)
        {
            StrNewCallFormPathLink = StrNewCallFormPathLink.Replace("webreportms", "sparinc");
        }

       // if (Lang_id == 4)
        //{
            StrNewCallFormPathLink = StrNewCallFormPathLink.Replace("http", "https");
        //}
        StrMTYPE = WebAppClass.MTYPE;
        //Response.Write("StrMTYPE=" + StrMTYPE);

        StrPTYPE = WebAppClass.PTYPE;
        //Response.Write("StrPTYPE=" + StrPTYPE);

        //StrMTYPE = "E";
        StrPromptcheck = "";
        StrLogInMtype = "";
        //Employee Menu.... Ptype is E 
         //StrPTYPE = "E";
        if (StrMTYPE == "E" || StrMTYPE == "B")
        {
            StrLogInMtype = "Y";
        }
        if ((StrPTYPE == "E") && (Lang_id == 1))
        {
            StrPromptcheck = "Y";
            LabelJob_no.Text = "Job No .";
        }

        user_id = Request.Form["user_id"];
        //Response.Write("user_id=" + user_id);

        Job_No = Request.Form["ctl00$ContentPlaceHolder1$txt_jobno"];
        // Response.Write("Job_No=" + Job_No);
         
        if (string.IsNullOrEmpty(Job_No) == true)
        {

            //Response.Write("Email_Active_Flag=" + Email_Active_Flag);
            Str_Merch_no = Request.Form["Str_Merch_no"];
            //Response.Write("Merch_no=" + Str_Merch_no + "<BR>");
            Job_No = Request.Form["Job_No"];
            // Response.Write("Job_No=" + Job_No);
            Wave_No = Request.Form["Wave_No"];
            //Response.Write("Wave_No=" + Wave_No);
            Task_No = Request.Form["Task_No"];
            //Response.Write("Task_No=" + Task_No);
            Chain_No = Request.Form["Chain_No"];
            //Response.Write("txt_chainno=" + Chain_No);
            Store_No = Request.Form["Store_No"];
            //Response.Write("txt_storeno=" + Store_No);
            txt_EmailAdd = Request.Form["txt_EmailAdd"];
            //Response.Write("txt_EmailAdd=" + txt_EmailAdd);
            txt_Mobile_Email = Request.Form["txt_Mobile_Email"];
            if (string.IsNullOrEmpty(Job_No) == true)
            {
                Str_Merch_no = Request.Form["merch_no"];
                Job_No = Request.Form["txt_jobno"];
                Wave_No = Request.Form["txt_waveno"];
                Task_No = Request.Form["txt_taskno"];
                Chain_No = Request.Form["txt_chainno"];
                Store_No = Request.Form["txt_storeno"];
                user_id = Request.Form["user_id"];
            }

        }
        else
        {
            Email_Active_Flag = Request.Form["Email_Active_Flag"];
            //Response.Write("Email_Active_Flag=" + Email_Active_Flag);


            Str_Merch_no = Request.Form["ctl00$ContentPlaceHolder1$Txt_merch_no"];
            //Response.Write("Str_Merch_no=" + Str_Merch_no + "<BR>");
            //Merch_no.Value = Str_Merch_no;
            Job_No = Request.Form["ctl00$ContentPlaceHolder1$txt_jobno"];
            // Response.Write("Job_No=" + Job_No);
            Wave_No = Request.Form["ctl00$ContentPlaceHolder1$txt_waveno"];
            //Response.Write("Wave_No=" + Wave_No);
            Task_No = Request.Form["ctl00$ContentPlaceHolder1$txt_taskno"];
            //Response.Write("Task_No=" + Task_No);
            Chain_No = Request.Form["ctl00$ContentPlaceHolder1$txt_chainno"];
            //Response.Write("txt_chainno=" + Chain_No);
            Store_No = Request.Form["ctl00$ContentPlaceHolder1$txt_storeno"];
            //Response.Write("txt_storeno=" + Store_No);
            txt_EmailAdd = Request.Form["ctl00$ContentPlaceHolder1$txt_EmailAdd"];
            //Response.Write("txt_EmailAdd=" + txt_EmailAdd);
            txt_Mobile_Email = Request.Form["ctl00$ContentPlaceHolder1$txt_Mobile_Email"];
            //Response.Write("txt_Mobile_Email=" + txt_Mobile_Email);

            //**** cell phone 
            txt_Phone1 = Request.Form["ctl00$ContentPlaceHolder1$txt_Phone1"];
            // Response.Write("txt_Phone1=" + txt_Phone1);

            txt_Phone2 = Request.Form["ctl00$ContentPlaceHolder1$txt_Phone2"];
            // Response.Write("txt_Phone2=" + txt_Phone2);

            txt_Phone3 = Request.Form["ctl00$ContentPlaceHolder1$txt_Phone3"];
            // Response.Write("txt_Phone3=" + txt_Phone3);

            CellProvider = Request.Form["ctl00$ContentPlaceHolder1$DDCellProvider"];
            //Response.Write("CellProvider=" + CellProvider);
            

            Hidden_PhoneStatus = Request.Form["Hidden_PhoneStatus"];

            CellPhoneNo = "" + txt_Phone1 + "" + txt_Phone2 + "" + txt_Phone3 + "";
            // Response.Write("CellPhoneNo=" + CellPhoneNo);
                  

            Get_CFJWTInsertMerchInfo(Str_Merch_no, txt_EmailAdd, CellPhoneNo, CellProvider, Hidden_PhoneStatus);
        }
        // Response.Write("Hidden_PhoneStatus=" + Hidden_PhoneStatus);
        int RecordCount = 0;

        DataSet dt = Get_CFJWTMultiVisit_Report_CallForm(Lang_id, Str_Merch_no, Job_No, Wave_No, Task_No, Chain_No, Store_No);
        StrGridDates = "";
        string str = ""; 
        if (dt.Tables.Count > 0)
        {

            RecordCount = dt.Tables[0].Rows.Count;
            //Response.Write("RecordCount2=" + RecordCount2);
            if (RecordCount > 0)
            {
                StoreInfo.DataSource = dt;

                StoreInfo.DataBind();

                GridViewRow row = StoreInfo.HeaderRow;

                StrCall_Form_Reported = dt.Tables[0].Rows[0]["Call_Form_Reported"].ToString();
               // Response.Write("StrCall_Form_Reported=" + StrCall_Form_Reported + "<BR>");

                //StoreInfo.HeaderRow.Cells[3].Visible = false;
                Bus_rule22_MV_NewVisit = dt.Tables[0].Rows[0]["Bus_rule22_status"].ToString();
                //Response.Write("Bus_rule22_MV_NewVisit=" + Bus_rule22_MV_NewVisit  +"<BR>");

                Bus_rule22_Photo_Required = dt.Tables[0].Rows[0]["Bus_rule22_Photo_Required"].ToString();
               // Response.Write("Bus_rule22_Photo_Required=" + Bus_rule22_Photo_Required + "<BR>");

                Display_Prod_Data_btn = dt.Tables[0].Rows[0]["Display_Prod_Data_btn"].ToString();
               //Response.Write("Display_Prod_Data_btn=" + Display_Prod_Data_btn  +"<BR>");

                Display_Assembly_btn = dt.Tables[0].Rows[0]["Display_Assembly_btn"].ToString();
                // Response.Write("Display_Assembly_btn=" + Display_Assembly_btn  +"<BR>");
                 Business_Type_id = dt.Tables[0].Rows[0]["Business_Type_id"].ToString();
               //  Response.Write("Business_Type_id=" + Business_Type_id + "<BR>"); 
                 EnableVideo_OptionFlag = dt.Tables[0].Rows[0]["EnableVideo_Option"].ToString();
                // Response.Write("EnableVideo_OptionFlag=" + EnableVideo_OptionFlag + "<BR>"); 

                 Str_Sv_Panel_id = dt.Tables[0].Rows[0]["Str_Sv_Panel_id"].ToString();
                // Response.Write("Str_Sv_Panel_id=" + Str_Sv_Panel_id);
                 Golite_status = dt.Tables[0].Rows[0]["Golite_status"].ToString();
                 // Response.Write("Golite_status=" + Golite_status);

                row.Cells[0].Text = vPrompts[0];
                row.Cells[1].Text = vPrompts[1];
                if (Bus_rule22_Photo_Required== "0")
                {
                    row.Cells[2].Text = vPrompts[2];
                 
                }
                else
                {
                    row.Cells[2].Text = vPrompts[3];
                    row.Cells[3].Text = vPrompts[2];
                }

                
              

                foreach (GridViewRow gvr in StoreInfo.Rows)
                 {
                     str = gvr.Cells[0].Text;
                    // Response.Write("str=" + str);
                     StrGridDates = StrGridDates.Trim() + str.Trim() + "|";
                     if (Bus_rule22_Photo_Required == "0")
                     {
                         gvr.Cells[2].Visible = false;

                     }
                     strCFreported = gvr.Cells[1].Text;
                   //  Response.Write("strCFreported=" + strCFreported);
                    //***********C stands for multi-visit job with no business rule 10
                     if (strCFreported == "C")
                     {
                         gvr.Cells[1].Text = "No";

                     }
                    
                 }
                
                 //Response.Write("StrArrayDates=" + StrArrayDates);
                 
            }
            else
            {
                ShowJWTInfo.InnerHtml = "<span class='reportCriteriaHeader' >No error data avaiable for this Summary Report.</span>";
            }
        }

        Boolean StrServerhas2;
        string StrDomain1, StrDomain2, StrDomain3;
        string[] ArraySER_nameSplit1;
        //Str_SERVER_NAME="dev2k3.sparinc.com";

        StrServerhas2 = Str_SERVER_NAME.Contains("com");
      // Response.Write("Str_Merch_no=" + Str_Merch_no);
        // StrServerhas = true;
        // Response.Write("Str_SERVER_NAME=" + Str_SERVER_NAME);

        if (StrServerhas2 == false)
        {
            Prod_Data_Url = "http://mi11.sparinc.com/pdcs/index.asp";
            Assembly_Url = "http://mi11.sparinc.com/papdcs/index.aspx";
            Return_CallFormPath = "http://" + WebConfig_ServerName.Trim() + "/internetCallForm/CFJWTInputs.aspx";
        }
        else
        {
            ArraySER_nameSplit1 = Str_SERVER_NAME.Split(".".ToCharArray());

            StrDomain1 = ArraySER_nameSplit1[0];
            StrDomain2 = ArraySER_nameSplit1[1];
            StrDomain3 = ArraySER_nameSplit1[2];
            //Response.Write("Domain1=" + Domain1);
            //Response.Write("Domain2=" + Domain2);
            //Response.Write("Domain3=" + Domain3);
            // Response.Write("Business_rule_link222=" + Business_rule_link);
            //RTS_Url = "http://mi23.sparinc.com/itsnet/its_IssueAddNext.aspx";
            Return_CallFormPath = "http://" + StrDomain1.Trim() + "." + StrDomain2.Trim() + "." + StrDomain3.Trim() + "/internetCallForm/CFJWT_Input_Photo_Option.aspx";

            if (Display_Prod_Data_btn == "Y")
            {
                Prod_Data_Url = "http://" + DCM_ServerName.Trim() + "." + StrDomain2.Trim() + "." + StrDomain3.Trim() + "" + DCM_PathName + "";

                //new
                if (StrAccessToNewDataCollectApp_flag == "Y")
                {
                    Prod_Data_Url = "http://" + DCM_ServerNameTest.Trim() + "." + StrDomain2.Trim() + "." + StrDomain3.Trim() + "" + DCM_PathNameTest + "";
                    Var_DataCollectQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_No + "&Store_no=" + Store_No + "&Job_no=" + Job_No + "&Wave_no=" + Wave_No + "&Task_no=" + Task_No + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                    // Var_AssemblyQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_no + "&Store_no=" + Store_no + "&Job_no=" + Job_no + "&Wave_no=" + Wave_no + "&Task_no=" + Task_no + "&BusTypeid=" + Business_Type_id + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                    Prod_Data_Url = Prod_Data_Url + "" + Var_DataCollectQueryString;
                }

                if (Lang_id == 4)
                {
                    Prod_Data_Url = Prod_Data_Url.Replace("http", "https");
                }
            }
            if (Display_Assembly_btn == "Y")
            {
                Assembly_Url = "http://" + ACM_ServerName.Trim() + "." + StrDomain2.Trim() + "." + StrDomain3.Trim() + "" + ACM_PathName + "";
                // if ((Str_Merch_no == "116597") || (Str_Merch_no == "122751") || (Str_Merch_no == "116794"))
                if (StrAccessToNewAssemblyApp_flag == "Y")
                {
                    Assembly_Url = "http://" + ACM_ServerNameTest.Trim() + "." + StrDomain2.Trim() + "." + StrDomain3.Trim() + "" + ACM_PathNameTest + "";
                    Var_AssemblyQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_No + "&Store_no=" + Store_No + "&Job_no=" + Job_No + "&Wave_no=" + Wave_No + "&Task_no=" + Task_No + "&BusTypeid=" + Business_Type_id + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                    // Var_AssemblyQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_no + "&Store_no=" + Store_no + "&Job_no=" + Job_no + "&Wave_no=" + Wave_no + "&Task_no=" + Task_no + "&BusTypeid=" + Business_Type_id + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                    Assembly_Url = Assembly_Url + "" + Var_AssemblyQueryString;
                }
            }
        }
      //  if (Lang_id == 4)
        //{
            if (string.IsNullOrEmpty(Assembly_Url) == false)
            {
                Assembly_Url = Assembly_Url.Replace("http", "https");
            }
            if (string.IsNullOrEmpty(Prod_Data_Url) == false)
            {
                Prod_Data_Url = Prod_Data_Url.Replace("http", "https");
            }

            Return_CallFormPath = Return_CallFormPath.Replace("http", "https");
        //}
       // Response.Write("Prod_Data_Url=" + Prod_Data_Url);
      //  Response.Write("Assembly_Url=" + Assembly_Url);

        //Execute the photo check by question procedure

        Photo_By_QuestionFlag = "";
        strJob_Visit_Date = "";
        DataSet dt25 = Get_Photo_QuestionCheck(Lang_id, Job_No, Wave_No, Task_No, Chain_No, Store_No, Str_Merch_no, strJob_Visit_Date,Str_Sv_Panel_id);
        // ds.Tables[0].Rows.Count
        if (dt25.Tables[0].Rows.Count > 0)
        {
            Photo_By_QuestionFlag = "Y";
        }
        else
        {
            Photo_By_QuestionFlag = "N";
        }
        
        

    }
    #region SystemPromptandRule

    private void GetPromptTranslation()
    {
        vPrompts = new string[5];
        vPrompts[0] = "Visit Date";
        vPrompts[1] = "Call Form Reported";
        vPrompts[2] = "No. of Photos Uploaded";
        vPrompts[3] = "No. of Photos Required";
        vPrompts[4] = @"Photo\Video Upload";

        ptAppTranslation.DoArrayPromptTranslation(vPrompts);


    }
    private DataTable GetSystemRules()
    {
        DataTable appDT = new DataTable();
        string[] VRule;
        VRule = new string[6];
        VRule[0] = "Name Format";
        VRule[1] = "New Date Format";
        VRule[2] = "Collect Mobile Email";
        VRule[3] = "SPAR Logo";
        VRule[4] = "SPAR Copyright";
        VRule[5] = "Address Format";
        appDT = AppSysRules.Get_RuleValue_ByDescAsDataTable(VRule, WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection);
        return appDT;
    }

    #endregion
    #region Procedures
     
    private DataSet Get_CFJWTMultiVisit_Report_CallForm(Int32 Lang_id, String Str_Merch_no, String Job_No, String Wave_No, String Task_No, String Chain_No, String Store_No)
    {
        Int32 iTempLang_id = 0;
        Int32 iTempStr_Merch_no = 0;
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempChain_No = 0;
        Int32 iTempStore_No = 0;

        //iTempLang_id = AppUtils.ConvertToInteger32(Lang_id, 0);
        iTempStr_Merch_no = AppUtils.ConvertToInteger32(Str_Merch_no, 0);
        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempChain_No = AppUtils.ConvertToInteger32(Chain_No, 0);
        iTempStore_No = AppUtils.ConvertToInteger32(Store_No, 0);
        //iTempCellProvider = AppUtils.ConvertToInteger32(CellProvider, 0);
        // iTempHidden_PhoneStatus = AppUtils.ConvertToInteger32(Hidden_PhoneStatus, 0);

        return AppData.Get_USP_JWT_MultiVisit_Report_CallForm(Lang_id, iTempStr_Merch_no, iTempJob_No, iTempWave_No, iTempTask_No, iTempChain_No, iTempStore_No, WebAppClass.CurrentSQLDBConnection);
    }
    private DataTable Get_CFJWTInsertMerchInfo(String Str_Merch_no, String txt_EmailAdd, String CellPhoneNo, String CellProvider, String Hidden_PhoneStatus)
    {
        Int32 iTempMerchNo = 0;

        Int32 iTempCellProvider = 0;
        Int32 iTempHidden_PhoneStatus = 0;


        iTempMerchNo = AppUtils.ConvertToInteger32(Str_Merch_no, 0);
        iTempCellProvider = AppUtils.ConvertToInteger32(CellProvider, 0);
        iTempHidden_PhoneStatus = AppUtils.ConvertToInteger32(Hidden_PhoneStatus, 0);

        return AppData.Get_CFMerchCellPhoneInsert(iTempMerchNo, txt_EmailAdd, CellPhoneNo, iTempCellProvider, iTempHidden_PhoneStatus, WebAppClass.CurrentSQLDBConnection);
    }
    private DataSet Get_Photo_QuestionCheck(Int32 Lang_id, String Job_No, String Wave_No, String Task_No, String Chain_No, String Store_No, String Str_Merch_no, String Job_Visit_Date, String Str_Sv_Panel_id)
    {
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempChain_No = 0;
        Int32 iTempStore_No = 0;
        Int32 iTempMerchNo = 0;


        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempMerchNo = AppUtils.ConvertToInteger32(Str_Merch_no, 0);
        iTempChain_No = AppUtils.ConvertToInteger32(Chain_No, 0);
        iTempStore_No = AppUtils.ConvertToInteger32(Store_No, 0);

        //iTempCellProvider = AppUtils.ConvertToInteger32(CellProvider, 0);
        // iTempHidden_PhoneStatus = AppUtils.ConvertToInteger32(Hidden_PhoneStatus, 0);

        return AppData.Get_USP_Photo_QuestionCheck(Lang_id, iTempJob_No, iTempWave_No, iTempTask_No, iTempChain_No, iTempStore_No, iTempMerchNo, Job_Visit_Date, Str_Sv_Panel_id, WebAppClass.CurrentSQLDBConnection);
    }
    private DataTable Get_CFJWT_Visit_Date_status(Int32 Lang_id, String Job_No, String Wave_No, String Task_No, String Chain_No, String Store_No, String Str_Merch_no, String Job_Visit_Date)
    {
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempChain_No = 0;
        Int32 iTempStore_No = 0;
        Int32 iTempMerchNo = 0;


        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempMerchNo = AppUtils.ConvertToInteger32(Str_Merch_no, 0);
        iTempChain_No = AppUtils.ConvertToInteger32(Chain_No, 0);
        iTempStore_No = AppUtils.ConvertToInteger32(Store_No, 0);


        return AppData.Get_AppData_Visit_Date_status(Lang_id, iTempJob_No, iTempWave_No, iTempTask_No, iTempChain_No, iTempStore_No, iTempMerchNo, Job_Visit_Date, WebAppClass.CurrentSQLDBConnection);

    }
    #endregion
    protected void CreateButtonLink(object sender, GridViewRowEventArgs e)
    {
        string P_visit_dt, Call_Form_Access, Photo_Access, P_visit_dt2, ArraySaveDates, Report_New_Visit, PhotoBy_Question_status, Bus_rule22_status, Bus_rule22_Photo_Remain, Bus_rule22_Multi_visit_Flag, Bus_rule22_MV_Remain, Bus_rule22_MV_Flag, Bus_rule22_Disable_CF_Access, EnableVideo_Flag;
        DateTime dt ;
        Report_New_Visit = "";
        Bus_rule22_Disable_CF_Access = "";
        Bus_rule22_MV_Flag = "N";
        Bus_rule22_MV_Remain = "";

        

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            P_visit_dt = Convert.ToString(StoreInfo.DataKeys[e.Row.RowIndex].Values[0]);
            Call_Form_Access = Convert.ToString(StoreInfo.DataKeys[e.Row.RowIndex].Values[1]);
            Photo_Access = Convert.ToString(StoreInfo.DataKeys[e.Row.RowIndex].Values[2]);
            Report_New_Visit = Convert.ToString(StoreInfo.DataKeys[e.Row.RowIndex].Values[3]);
            PhotoBy_Question_status = Convert.ToString(StoreInfo.DataKeys[e.Row.RowIndex].Values[4]);
            Bus_rule22_status= Convert.ToString(StoreInfo.DataKeys[e.Row.RowIndex].Values[5]);
            Bus_rule22_Photo_Remain = Convert.ToString(StoreInfo.DataKeys[e.Row.RowIndex].Values[6]);
            EnableVideo_Flag = Convert.ToString(StoreInfo.DataKeys[e.Row.RowIndex].Values[7]);

           // Response.Write("Call_Form_Access=" + Call_Form_Access);
            //Response.Write("PhotoBy_Question_status=" + PhotoBy_Question_status);
             //Response.Write("vPrompts=" + vPrompts[4]);
            
            //Response.Write("Photo_Access=" + Photo_Access);
            //Response.Write("Call_Form_Access=" + Call_Form_Access);
            //Response.Write("Bus_rule22_status=" + Bus_rule22_status);
            //Response.Write("Bus_rule22_Photo_Remain=" + Bus_rule22_Photo_Remain + "<BR>");

          Button btnButton = (Button)e.Row.FindControl("CFBttton_Status");
          if (Bus_rule22_status == "Y")
          {
              if (Bus_rule22_Photo_Remain != "0")
              {
                  Bus_rule22_Disable_CF_Access = "Yes";
                  Bus_rule22_MV_Flag = "Y";
                  Bus_rule22_MV_Remain = Bus_rule22_Photo_Remain;
              }
              else
              {
                  Bus_rule22_MV_Flag = "N";
                  Bus_rule22_MV_Remain = Bus_rule22_Photo_Remain;
              }   
          }
          //***********C stands for multi-visit job with no business rule 10
          if (Call_Form_Access == "C")
          {
              btnButton.Enabled = false;
          }
          if (Call_Form_Access == "Yes")
          {
              btnButton.Enabled = false;
          }
          if (Bus_rule22_Disable_CF_Access == "Yes")
          {
              btnButton.Enabled = false;
          }
         // Response.Write("P_visit_dt=" + P_visit_dt);   
         // dt = Convert.ToDateTime(P_visit_dt);
         // Response.Write("dt=" + dt);  
         // P_visit_dt2 = String.Format("{0:d}", dt);

        
         
          //Response.Write("P_visit_dt=" + P_visit_dt2);
          btnButton.Attributes.Add("onclick", "return GetAccess_Call_Form('" + P_visit_dt + "','" + Call_Form_Access + "','" + Bus_rule22_MV_Flag + "','" + Bus_rule22_MV_Remain + "')");
         
          Button btnButton2 = (Button)e.Row.FindControl("PhotoBttton_Status");

          btnButton2.Attributes.Add("onclick", "return GetAccess_Photo('" + P_visit_dt + "','" + Call_Form_Access + "','N','" + Bus_rule22_MV_Flag + "','" + Bus_rule22_MV_Remain + "')");

          Button btnVideo = (Button)e.Row.FindControl("VideoBttton_Status");

          btnVideo.Attributes.Add("onclick", "return GetAccess_Video('" + P_visit_dt + "','" + Call_Form_Access + "','" + PhotoBy_Question_status + "','" + Bus_rule22_MV_Flag + "','" + Bus_rule22_MV_Remain + "')");

          Button btnButton3 = (Button)e.Row.FindControl("PhotoBttton_Question");

          btnButton3.Attributes.Add("onclick", "return GetAccess_Photo('" + P_visit_dt + "','" + Call_Form_Access + "','Y','" + Bus_rule22_MV_Flag + "','" + Bus_rule22_MV_Remain + "')");

          if (Report_New_Visit == "Yes")
          {
              Add_New_Visit_Dt.Enabled = false;
          }
          if (PhotoBy_Question_status == "D")
          {
              btnButton3.Visible = false;
              //btnButton3.Enabled = false;
          }
          if (PhotoBy_Question_status == "N")
          {
              btnButton3.Visible = false;
             // btnButton3.Enabled = false;
          }
          if (PhotoBy_Question_status == "N")
          {
              btnVideo.Visible = false;
          }
          if (EnableVideo_Flag == "N")
          {
              btnVideo.Visible = false;
          }
          if ((PhotoBy_Question_status == "N") && (EnableVideo_Flag == "Y"))
          {
              btnButton2.Text = vPrompts[4];
          }  
          if (Lang_id == 18)
          {
              btnButton2.Visible=false;
          }
       }
       //Context.Items["MV_Bus_rule22_Flag"] = Bus_rule22_MV_Flag;
       //Context.Items["MV_Photo_Remain"] = Bus_rule22_MV_Remain;
       //Response.Write("Report_New_Visitout=" + Report_New_Visit);
       //Button btnButton3 = (Button)e.Row.FindControl("Add_New_Visit_Dt");
       //if (Report_New_Visit == "Yes")
       //{
       //    btnButton3.Enabled = false;
       //}

    }
}
