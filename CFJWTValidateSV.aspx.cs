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

public partial class CFJWTValidateSV : System.Web.UI.Page
{
    protected string Str_Merch_no,user_id, Email_Active_Flag, Job_No, Wave_No, Task_No, Chain_No, Store_No, txt_EmailAdd, txt_Mobile_Email, POutOfStock_no, Error_Message, Error_Flag, HTMLHeader_info, Collect_Mobile_Email, AddressRule, NameRule, DateRule;
    protected int Error_Message_Flag, Error_Video_Flag, BusinessQuestion_Flag, Back_Slash, Dot, Dash, ShowType, Lang_id, URL_status;
    protected string store_id, Store_Chain_Desc, Store_Store_Name, Store_Street_Addr, Store_City, Store_State, Store_Zip,Store_Phone_No, StrInformationDisplay;
    protected string PMerch_no, CA_merch_no, Merch_First_Name, Merch_Last_Name, Merch_Street_Addr, Merch_Street_Addr2, Coming_JWT_Input_Page, Photo_CF_Access, GridAddNewVisit, Str_User_id, Merch_User;
    protected string Merch_City, Merch_State, Merch_Zip, Merch_Phone_No, Merch_Email_Addr, Task_Desc, Task_Addtl_Desc, CellPhoneNo, OutOfStock_no, StrGridDates;
    protected string Field_Start_Dt, Field_end_Dt, Key_Comp_Dt, DOA_Dt, Job_Type, Business_Type_id, Work_Type_id, Work_Type_Desc, Max_Mx_Per_Store, Furn_Assembly_Visit_dt;
    protected string Max_Visit_Per_Store_Mx, visit_no, Collect_iVR_Time, night_visits, Mileage_flag, Travel_flag, Data_Col_Method, Display_Assembly_btn, Display_Prod_Data_btn, Return_CallFormPath, WebConfig_ServerName;             
    protected string All_Data_Received,qdef_skippattern,Collect_Header,Collect_Call_Form,SS_Callform,Prod_Specific,overwritetime,Assembly_Url,Prod_Data_Url;
    protected string collect_time_only, Ask_Q_HH_Used, HH_Status_Flag, Collect_Store_Mgr_Name, Product_Check_Flag, Ask_EShelf_Question, Bus_rule22_MV_NewVisit, StrVisit_time, StrDrive_Time_HH, StrDrive_Time_MM;
    protected string Call_Form_Type_No, Est_instore_minutes, Business_Rule_Eckerd, Eckerd_Job_Last_question, Bus_Rule22_Photo, Photo_By_QuestionFlag, Bus_rule22_MV_Remain, Bus_rule22_MV_Flag;
    protected string Bus_Rule5_Question, Bus_Rule6_Question, Bus_Rule28_Question, Bus_Rule3_Question, Bus_Rule4_Question, Bus_Rule7_Question, NewScreenPage, StrNewCallFormPathLink;
    protected string JWTInfoText,JWTLinkInfoText,JWTLinkDivText, UseTheCallForm, PhotoButton, Nextbutton, return_Message, Excute_SQL, Merch_Message, Star_time, DataCollectionStatusFlag, Business_rule_link, Prod_Spec_Store_q_Status, Goto_Call_Form_New_Grid;
    protected string Date_input, VarDay, Varmonth, StrYear, VarSelect_AM, VarSelect_PM, Strcmb_timein, TodayDate, YearDisplay, Disable_photo_upload,DisplayVideoBtn;
    protected string txt_timein_hrsVal, txt_timein_minVal, txt_timeout_hrsVal, txt_timeout_minVal, PVisit_Date, txt_Phone1, txt_Phone2, txt_Phone3, CellProvider, Hidden_PhoneStatus, EnableVideo_OptionFlag;
    protected string Str_VisitMonth, Str_visitday, Str_visityear, Str_timein_hrs, Str_timein_min, Str_cmb_timein, Str_timeout_hrs, Str_timeout_min, Str_cmb_timeout, Str_Manager_Title, Str_txt_Manager_name, Merch_California_Status, CalforTimeCap, CalforniaMileage_flag;
    protected string Str_rad_q_Ret_store_visit, Job_Visit_Date, Visit_dt_access, Old_Visit_Date, Str_Http_URL, Str_HTTP_HOST, Current_URL, Str_SERVER_NAME, DCM_ServerName, DCM_PathName, ACM_ServerName, ACM_PathName, DCM_Url, ACM_Url, Bus_Rule_Url;
    protected string Str_txt_mileage, Str_txt_drive, Str_rad_q_Past_Midnight, Str_rad_q_HH_Used, Str_Radio_EShelf, Str_Ask_EShelf_Question, Str_Bus_Rule3_Question, Valid_Cal_Merch, StrMTYPE, StrLogInMtype, StrPTYPE, StrPromptcheck;
    protected string Str_rad_q_BR3, Str_Bus_Rule4_Question, Str_rad_q_BR4, Str_Bus_Rule5_Question, Str_rad_q_BR5, Str_Bus_Rule6_Question, Str_Recordset_type, HourRule, GoLiteDate, Proposed_Visit_Dt, Var_AssemblyQueryString, Var_DataCollectQueryString, DCM_ServerNameTest, DCM_PathNameTest,StrAccessToNewAssemblyApp_flag, StrAccessToNewDataCollectApp_flag;
    protected string Str_rad_q_BR6, Str_Bus_Rule7_Question, Str_rad_q_BR7, Str_Bus_Rule28_Question, Str_rad_q_BR28, ShowPhotoBtn, Work_cap_percent_Min, Str_Sv_Panel_id, Str_msg_id, Str_msg_dt, Str_msg_text, Str_msg_title, Str_Link_Status, Str_Link_url_Type, ACM_ServerNameTest, ACM_PathNameTest, Assembly_status_Flag, DataCollect_status_Flag, gobackDate_list, Goback_visit_dt_flag;
    private string  Str_Request_Method;
    public string[] vPrompts;
    public DateTime StrDate; 

    #region SPARUTILS
    //code block for masterpage app, dont remove
    SPARValues WebAppClass;
    PromptTranslation ptAppTranslation;
    
    
    protected void Page_PreInit()
    {
        Str_Request_Method = Request.ServerVariables.Get("REQUEST_METHOD").ToString();
        //Response.Write("Str_Request_Method=" + Str_Request_Method + "<BR>");

        if (Str_Request_Method == "GET")
        {
            Response.Redirect("https://mi12.sparinc.com/MXToolsLogin/MXSparmenu.asp");
        }

        SPARHeader PageHeader;
        SPARFooter PageFooter;
        SPARBiLingualBar BiLingualBar;
        PageHeader = (SPARHeader)this.Master.FindControl("SPARHeader1");
        PageFooter = (SPARFooter)this.Master.FindControl("SPARFooter1");
        BiLingualBar = (SPARBiLingualBar)this.Master.FindControl("SPARBiLingualBar1");

        WebAppClass = new SPARValues();
        
       
        ptAppTranslation = new PromptTranslation("CFJWTValidateSV.aspx", WebAppClass.PromptsLanguageId.ToString(), WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection, WebAppClass.MultiLanguageCount);
       // AppMasterControls ap1 = new AppMasterControls(PageHeader, PageFooter, WebAppClass.LoggedUserName, WebAppClass.CurrentDBDateTime, WebAppClass.LanguageId, WebAppClass.PromptsLanguageId, WebAppClass.PageTitle, WebAppClass.CurrentSQLDBConnection, this.Page, WebAppClass.SPARLogoFileURL);
        AppMasterControls ap1 = new AppMasterControls(PageHeader, PageFooter, BiLingualBar, WebAppClass.LoggedUserName, WebAppClass.CurrentDBDateTime, WebAppClass.LanguageId, WebAppClass.PromptsLanguageId, WebAppClass.MultiLanguageCount, WebAppClass.PageTitle, WebAppClass.CurrentSQLDBConnection, this.Page, WebAppClass.SPARLogoFileURL);
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
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ptAppTranslation.DoPagePromptTranslation(this.Page);
    }

    #endregion
    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
          StrNewCallFormPathLink = ConfigurationManager.AppSettings["NewCallFormPathLink"];
       // Response.Write("StrNewCallFormPathLink=" + StrNewCallFormPathLink);

        string StrFileUpdatePath = ConfigurationManager.AppSettings["FileUpdatePath"];
        //Response.Write("StrFileUpdatePath=" + StrFileUpdatePath);
        string StrFileWorkPath = ConfigurationManager.AppSettings["FileWorkPath"];
        //Response.Write("StrFileWorkPath=" + StrFileWorkPath);
        string StrFileApprovedPath = ConfigurationManager.AppSettings["FileApprovedPath"];
       // Response.Write("StrFileApprovedPath=" + StrFileApprovedPath);
         Valid_Cal_Merch = ConfigurationManager.AppSettings["Validationcalifornia_Merch"];
         //Response.Write("Valid_Cal_Merch=" + Valid_Cal_Merch);
        

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
        // Response.Write("DCM_PathName=" + DCM_PathName);

        DCM_ServerNameTest = ConfigurationManager.AppSettings["DataCollectionServerTest"];
        //  Response.Write("DCM_ServerNameTest=" + DCM_ServerNameTest + "<BR>");
        DCM_PathNameTest = ConfigurationManager.AppSettings["DataCollectionPathTest"];
        // Response.Write("DCM_PathNameTest=" + DCM_PathNameTest + "<BR>");

        ACM_ServerName = ConfigurationManager.AppSettings["AssemblyCollectionServer"];
        // Response.Write("ACM_ServerName=" + DCM_ServerName);
        ACM_PathName = ConfigurationManager.AppSettings["AssemblyCollectionPath"];
       //Response.Write("ACM_PathName=" + ACM_PathName);
        ACM_ServerNameTest = ConfigurationManager.AppSettings["AssemblyCollectionServerTest"];
        //  Response.Write("ACM_ServerName=" + DCM_ServerName);
        ACM_PathNameTest = ConfigurationManager.AppSettings["AssemblyCollectionPathTest"];

      
        //****** System Rules
        DataTable RuleTab = new DataTable();
        RuleTab = GetSystemRules();

        AddressRule = RuleTab.Rows[5][2].ToString();
        // Response.Write("AddressRule=" + AddressRule);

        DateRule = RuleTab.Rows[1][2].ToString();
        // Response.Write("DateRule=" + DateRule);

        NameRule = RuleTab.Rows[0][2].ToString();
         //Response.Write("NameRule=" + NameRule);
        HourRule = RuleTab.Rows[6][2].ToString();
         //HourRule = "24";
       // Response.Write("HourRule=" + HourRule);
        Str_User_id = WebAppClass.LoggedUserId;
 
        //******************************* Date format
        Back_Slash = DateRule.IndexOf("/");
		//response.write "Back_Slash=" & Back_Slash & "<BR>" 
		if (Back_Slash>0)
        {
			Date_input="/";
		}
        Dot = DateRule.IndexOf(".");
		//response.write "Dot=" & Dot & "<BR>" 
		if (Dot>0) 
        {
			Date_input=".";
		}
        Dash = DateRule.IndexOf("-");
		//response.write "Dot=" & Dot & "<BR>" 
		if (Dash>0)
        {
			Date_input="-";
		}
        //Response.Write("Date_input=" + Date_input + "<BR>");
        //****** Today's date 

      //  int TodayMonth = System.DateTime.Now.Month;
       // Response.Write("TodayDate =" + TodayDate + "<BR>");

        //****** Today's date 
        DataTable dt10 = Get_Start_time();
        Star_time = dt10.Rows[0][0].ToString();

          Lang_id = WebAppClass.LanguageId;
               //Response.Write(Lang_id);

        //Star_time = Convert.ToString(Get_Start_time());
        //Response.Write("Star_time=" + Star_time);
        GoLiteDate = Request.Form["GoLiteDate"];
       // Response.Write("GoLiteDate=" + GoLiteDate);
        StrMTYPE = WebAppClass.MTYPE;
       // Response.Write("StrMTYPE=" + StrMTYPE);

        StrPTYPE = WebAppClass.PTYPE;
         // Response.Write("StrPTYPE=" + StrPTYPE);

       //StrMTYPE = "E";
        StrPromptcheck = "";
        StrLogInMtype = "";
        //Employee Menu.... Ptype is E 
      // StrPTYPE = "E";
        if (StrMTYPE == "E" || StrMTYPE == "B")
        {
            StrLogInMtype = "Y";
        }
        if ((StrPTYPE == "E") && (Lang_id==1))
        {
            StrPromptcheck = "Y";
        }


        if (IsNumber(Str_User_id) == true)
        {
            Merch_User = "Y";         
        }
        else
        {
            StrPTYPE = "S";
        }
       // StrPTYPE = "S";
        // Response.Write("Str_User_id=" + Str_User_id);
      //  Response.Write("StrPTYPE=" + StrPTYPE);
        //****** Prompts
        GetPromptTranslation();

        //********************* Variables from the CFPictureGetFileOption
              
                if (Lang_id != 1)
                {
                    if (Lang_id != 13)
                    {
                        StrNewCallFormPathLink = StrNewCallFormPathLink.Replace("webreportms", "sparinc");
                        //ElementAnswer = ElementAnswer.Replace("\n", " ");  
                    }
                }
               // Response.Write("StrNewCallFormPathLink=" + StrNewCallFormPathLink);

                URL_status = Str_HTTP_HOST.IndexOf("sparinc");
                // Response.Write("<BR>URL_status=" + URL_status + "<BR>");

                if (URL_status > 0)
                {
                    StrNewCallFormPathLink = StrNewCallFormPathLink.Replace("webreportms", "sparinc");
                }
               // Response.Write("StrNewCallFormPathLink=" + StrNewCallFormPathLink);

               // if (Lang_id == 4)
                //{
                    StrNewCallFormPathLink = StrNewCallFormPathLink.Replace("http", "https");
                //}
               // Response.Write("StrNewCallFormPathLink=" + StrNewCallFormPathLink + "<BR>");


                user_id = Request.Form["user_id"];
                //Response.Write("user_id=" + user_id);
                NewScreenPage = Request.Form["NewScreenPage"];
                //Response.Write("NewMerchPage=" + NewMerchPage);


                Job_No = Request.Form["ctl00$ContentPlaceHolder1$txt_jobno"];
               // Response.Write("Job_No=" + Job_No);

                Email_Active_Flag = Request.Form["Email_Active_Flag"];
                //Response.Write("Email_Active_Flag=" + Email_Active_Flag);
                //***** visit date 
                //***** visit Date coming from CFJWT_Input_Photo_Option 
                Job_Visit_Date = Request.Form["Job_Visit_Date"];
                // Response.Write("Job_Visit_Date=" + Job_Visit_Date + "<BR>");
              
               
                //Response.Write("Job_Visit_Date=" + Job_Visit_Date + "<BR>");
                Str_VisitMonth = Request.Form["Str_VisitMonth"];
                Str_visitday = Request.Form["Str_visitday"];
                Str_visityear = Request.Form["Str_visityear"];
                Str_VisitMonth = Request.Form["Str_VisitMonth"];
                Coming_JWT_Input_Page = Request.Form["JWT_Input_Page"];
                Photo_CF_Access = Request.Form["Photo_CF_Access"];
                //Response.Write("Str_VisitMonth=" + Str_VisitMonth + "<BR>");
                //Response.Write("Photo_CF_Access=" + Photo_CF_Access);
                // Response.Write("Coming_JWT_Input_Page=" + Coming_JWT_Input_Page);
                Bus_rule22_MV_Remain = Request.Form["Bus_rule22_MV_Remain"];
                Bus_rule22_MV_Flag = Request.Form["Bus_rule22_MV_Flag"];
                Bus_rule22_MV_NewVisit = Request.Form["Bus_rule22_MV_NewVisit"];
                //Response.Write("Bus_rule22_MV_Remain=" + Bus_rule22_MV_Remain + "<BR>");
                //Response.Write("Bus_rule22_MV_Flag=" + Bus_rule22_MV_Flag + "<BR>");
                //Response.Write("Bus_rule22_MV_NewVisit_Before=" + Bus_rule22_MV_NewVisit + "<BR>");
                StrAccessToNewAssemblyApp_flag = Request.Form["AccessToNewAssemblyApp_flag"];
                StrAccessToNewDataCollectApp_flag = Request.Form["AccessToNewDataCollectApp_flag"];
               // Response.Write("StrAccessToNewAssemblyApp_flag=" + StrAccessToNewAssemblyApp_flag + "<BR>");
                //Response.Write("StrAccessToNewDataCollectApp_flag=" + StrAccessToNewDataCollectApp_flag + "<BR>");

                GridAddNewVisit = Request.Form["GridAddNewVisit"];
              //  Response.Write("GridAddNewVisit=" + GridAddNewVisit + "<BR>");
                if ((Str_VisitMonth == "") || (Str_VisitMonth == null))
                {
                    if (string.IsNullOrEmpty(Str_VisitMonth) == true)
                    {
                        if (string.IsNullOrEmpty(Coming_JWT_Input_Page) == false)
                        {
                            if (Coming_JWT_Input_Page == "Y")
                            {

                                if (Context.Items["Old_Month"] != null)
                                {
                                    // Response.Write("<BR> testinsedddd");
                                    Str_VisitMonth = Context.Items["Old_Month"].ToString();
                                    Str_visitday = Context.Items["Old_Day"].ToString();
                                    Str_visityear = Context.Items["Old_Year"].ToString();
                                    StrAccessToNewAssemblyApp_flag = Context.Items["AccessToNewAssemblyApp_flag"].ToString();
                                    StrAccessToNewDataCollectApp_flag = Context.Items["AccessToNewDataCollectApp_flag"].ToString();

                                    if (string.IsNullOrEmpty(Str_VisitMonth) == false)
                                    {
                                        Job_Visit_Date = clsDateFormat.FunDate_Format(Convert.ToInt32(Str_VisitMonth), Convert.ToInt32(Str_visitday), Str_visityear, ShowType, DateRule, Date_input);
                                    }
                                }
                                else
                                {
                                    // Response.Write("<BR> testinsedddd");
                                    Str_VisitMonth = Request.Form["StrOld_Month"];
                                    Str_visitday = Request.Form["StrOld_Day"];
                                    Str_visityear = Request.Form["StrOld_Year"];
                                    if (string.IsNullOrEmpty(Str_VisitMonth) == false)
                                    {
                                        Job_Visit_Date = clsDateFormat.FunDate_Format(Convert.ToInt32(Str_VisitMonth), Convert.ToInt32(Str_visitday), Str_visityear, ShowType, DateRule, Date_input);
                                    }
                                }
                            }
                        }

                    }
                }
              //  Response.Write("Job_Visit_Date2=" + Job_Visit_Date + "<BR>");
                if (string.IsNullOrEmpty(Job_Visit_Date) == true)
                {
                    Job_Visit_Date = "0";
                }
                Old_Visit_Date = Job_Visit_Date.Trim();
                 // Response.Write("Str_VisitMonth=" + Str_VisitMonth + "<BR>");
                txt_visitmonth.Text = Str_VisitMonth;
                //Response.Write("Str_visitday=" + Str_visitday + "<BR>");
                txt_visitday.Text = Str_visitday;
                
                // Response.Write("Str_visityear=" + Str_visityear + "<BR>");

                 if (GridAddNewVisit != "Yes")
                 {
                     if (string.IsNullOrEmpty(Str_VisitMonth) == false)
                     {
                         txt_visitmonth.ReadOnly = true;
                     }
                     if (string.IsNullOrEmpty(Str_visitday) == false)
                     {
                         txt_visitday.ReadOnly = true;
                     }
                     if (string.IsNullOrEmpty(Str_visityear) == false)
                     {
                         txt_visityear.ReadOnly = true;
                     }
                 }

               
                 if (GridAddNewVisit == "Yes")
                 {
                     txt_visitday.Text = "";
                     txt_visitmonth.Text = "";
                     Job_Visit_Date = "0";
                 }
                    //*******Time in and out     
                    Str_timein_hrs = Request.Form["Str_timein_hrs"];
                    //Response.Write("Str_timein_hrs=" + Str_timein_hrs + "<BR>");
                    //txt_timein_hrs.Text = Str_timein_hrs;
                    Str_timein_min = Request.Form["Str_timein_min"];
                    //Response.Write("Str_timein_min=" + Str_timein_min + "<BR>");
                    //txt_timein_min.Text = Str_timein_min;
                    Str_cmb_timein = Request.Form["Str_cmb_timein"];
                    //Response.Write("Str_cmb_timein=" + Str_cmb_timein + "<BR>");
                    //cmb_timein.SelectedValue = Str_cmb_timein;

                    Str_timeout_hrs = Request.Form["Str_timeout_hrs"];
                    //Response.Write("Str_timeout_hrs=" + Str_timeout_hrs + "<BR>");
                    //txt_timeout_hrs.Text = Str_timeout_hrs;

                    Str_timeout_min = Request.Form["Str_timeout_min"];
                    //Response.Write("Str_timeout_min=" + Str_timeout_min + "<BR>");
                   // txt_timeout_min.Text = Str_timeout_min;

                    Str_cmb_timeout = Request.Form["Str_cmb_timeout"];
                    //Response.Write("Str_cmb_timeout=" + Str_cmb_timeout + "<BR>");
                   // cmb_timeout.Text = Str_cmb_timeout;

                    Str_Manager_Title = Request.Form["Str_Manager_Title"];
                    //Response.Write("Str_Manager_Title=" + Str_Manager_Title + "<BR>");
                    Str_txt_Manager_name = Request.Form["Str_txt_Manager_name"];
                    //Response.Write("Str_txt_Manager_name=" + Str_txt_Manager_name + "<BR>");
                    //Response.Write("Str_rad_q_BR28=" + Str_rad_q_BR28 + "<BR>");
            
                    Str_rad_q_Ret_store_visit = Request.Form["Str_rad_q_Ret_store_visit"];
                    //Response.Write("Str_rad_q_Ret_store_visit=" + Str_rad_q_Ret_store_visit + "<BR>");
                    OutOfStock_no = Request.Form["OutOfStock_no"];
                    //Response.Write("OutOfStock_no=" + OutOfStock_no + "<BR>");
					//Response.Write "OutOfStock_no=" & OutOfStock_no & "<BR>"
                    // mileage		

                    Str_txt_mileage = Request.Form["Str_txt_mileage"];
                    // Response.Write("Str_txt_mileage=" + Str_txt_mileage + "<BR>");

                    //drive		
                    Str_txt_drive = Request.Form["Str_txt_drive"];
                    //Response.Write("Str_txt_drive=" + Str_txt_drive + "<BR>");

                    //Time Question

                    Str_rad_q_Past_Midnight = Request.Form["Str_rad_q_Past_Midnight"];
                    // Response.Write("Str_rad_q_Past_Midnight=" + Str_rad_q_Past_Midnight + "<BR>");

                    //Hand Held Question

                    Str_rad_q_HH_Used = Request.Form["Str_rad_q_HH_Used"];
                    // Response.Write("Str_rad_q_HH_Used=" + Str_rad_q_HH_Used + "<BR>");

                    //Time Store Visit
 
                    //For EShelf 	

                    Str_Radio_EShelf = Request.Form["Str_Radio_EShelf"];
                    // Response.Write("Str_Radio_EShelf=" + Str_Radio_EShelf + "<BR>");

                    Str_Ask_EShelf_Question = Request.Form["Str_Ask_EShelf_Question"];
                    // Response.Write("Str_Ask_EShelf_Question=" + Str_Ask_EShelf_Question + "<BR>");

                    //business rules
                    Str_Bus_Rule3_Question = Request.Form["Str_Bus_Rule3_Question"];
                    // Response.Write("Str_Bus_Rule3_Question=" + Str_Bus_Rule3_Question + "<BR>");

                    Str_rad_q_BR3 = Request.Form["Str_rad_q_BR3"];
                    // Response.Write("Str_rad_q_BR3=" + Str_rad_q_BR3 + "<BR>");

                    Str_Bus_Rule4_Question = Request.Form["Str_Bus_Rule4_Question"];
                    //Response.Write("Str_Bus_Rule4_Question=" + Str_Bus_Rule4_Question + "<BR>");

                    Str_rad_q_BR4 = Request.Form["Str_rad_q_BR4"];
                    // Response.Write("Str_rad_q_BR4=" + Str_rad_q_BR4 + "<BR>");

                    Str_Bus_Rule5_Question = Request.Form["Str_Bus_Rule5_Question"];
                    // Response.Write("Str_Bus_Rule5_Question=" + Str_Bus_Rule5_Question + "<BR>");
                    Str_rad_q_BR5 = Request.Form["Str_rad_q_BR5"];
                    //  Response.Write("Str_rad_q_BR5=" + Str_rad_q_BR5 + "<BR>");

                    Str_Bus_Rule6_Question = Request.Form["Str_Bus_Rule6_Question"];
                    // Response.Write("Str_Bus_Rule6_Question=" + Str_Bus_Rule6_Question + "<BR>");
                    Str_rad_q_BR6 = Request.Form["Str_rad_q_BR6"];
                    //Response.Write("Str_rad_q_BR6=" + Str_rad_q_BR6 + "<BR>");

                    Str_Bus_Rule7_Question = Request.Form["Str_Bus_Rule7_Question"];
                    //Response.Write("Str_Bus_Rule7_Question=" + Str_Bus_Rule7_Question + "<BR>");
                    Str_rad_q_BR7 = Request.Form["Str_rad_q_BR7"];
                    // Response.Write("Str_rad_q_BR7=" + Str_rad_q_BR7 + "<BR>");

                    Str_Bus_Rule28_Question = Request.Form["Str_Bus_Rule28_Question"];
                    // Response.Write("Str_Bus_Rule28_Question=" + Str_Bus_Rule28_Question + "<BR>");
                    Str_rad_q_BR28 = Request.Form["Str_rad_q_BR28"];
                    //Response.Write("Str_rad_q_BR28=" + Str_rad_q_BR28 + "<BR>");

                    StrGridDates = Request.Form["StrGridDates"];
                    //Response.Write("StrGridDates=" + StrGridDates);
                    StrVisit_time = Request.Form["Visit_time"];
                    //Response.Write("StrVisit_time=" + StrVisit_time);
                    StrDrive_Time_HH = Request.Form["Drive_Time_HH"];
                   // Response.Write("StrDrive_Time_HH=" + StrDrive_Time_HH);
                    StrDrive_Time_MM = Request.Form["Drive_Time_MM"];
                   // Response.Write("StrDrive_Time_MM=" + StrDrive_Time_MM);

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
                    //Response.Write("txt_Mobile_Email=" + txt_Mobile_Email);
                    if (string.IsNullOrEmpty(Job_No) == true)
                    {
                        Str_Merch_no = Request.Form["merch_no"];	
					    Job_No=Request.Form["txt_jobno"];
					    Wave_No=Request.Form["txt_waveno"];
					    Task_No=Request.Form["txt_taskno"];
					    Chain_No=Request.Form["txt_chainno"];
					    Store_No=Request.Form["txt_storeno"];
					    user_id=Request.Form["user_id"];
                    }
                }
                else
                {

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
                    //Response.Write("Hidden_PhoneStatus=" + Hidden_PhoneStatus);

                    CellPhoneNo = "" + txt_Phone1 + "" + txt_Phone2 + "" + txt_Phone3 + "";
                    // Response.Write("CellPhoneNo=" + CellPhoneNo);
                  
                    //************** insert merch info

                    Get_CFJWTInsertMerchInfo(Str_Merch_no, txt_EmailAdd, CellPhoneNo, CellProvider, Hidden_PhoneStatus);
                }
                DisplayVideoBtn = "N";
                DataTable dt25 = Get_CFJWT_Visit_Date_status(Lang_id, Job_No, Wave_No, Task_No, Chain_No, Store_No, Str_Merch_no, Job_Visit_Date);
                Visit_dt_access = dt25.Rows[0]["Visit_dt_access"].ToString();
                // Response.Write("Visit_dt_access=" + Visit_dt_access + "<BR>");
                EnableVideo_OptionFlag = dt25.Rows[0]["EnableVideo_Option"].ToString();
                Business_Type_id = dt25.Rows[0]["Business_Type_id"].ToString();
                Prod_Spec_Store_q_Status = dt25.Rows[0]["Prod_Spec_Store_q_Status"].ToString();
                Goto_Call_Form_New_Grid = dt25.Rows[0]["Goto_Call_Form_New_Grid"].ToString();
                //Response.Write("Prod_Spec_Store_q_Status=" + Prod_Spec_Store_q_Status + "<BR>");
                // Response.Write("Photo_By_QuestionFlag=" + Photo_By_QuestionFlag + "<BR>");
                //  Response.Write("Disable_photo_upload=" + Disable_photo_upload + "<BR>");
                //  Response.Write("Business_rule_link=" + Business_rule_link + "<BR>");
                //Response.Write("EnableVideo_OptionFlag=" + EnableVideo_OptionFlag + "<BR>");
                //POutOfStock_no = "0";
                gobackDate_list = "";
                Goback_visit_dt_flag = "N";
                if (Lang_id == 1)
                {
                    if (string.IsNullOrEmpty(StrGridDates) == true)
                    {
                        gobackDate_list = dt25.Rows[0]["gobackDate_list"].ToString();
                        if (gobackDate_list != "")
                        {
                            Goback_visit_dt_flag = "Y";
                        }
                    }
                }
                Error_Flag = "N";
                Error_Message_Flag = 0;
                UseTheCallForm = "";
                PhotoButton = "YES";
                Nextbutton = "";
                Excute_SQL = "";
                Collect_iVR_Time = "N";
                ShowPhotoBtn = "N";
                Return_CallFormPath="";
                Business_rule_link = "";
                CalforniaMileage_flag ="";

                CalforTimeCap ="";
                DataTable dt;
        //**************** Validation procedure
                if (Lang_id == 1)
                {
                     dt = Get_CFJWTValidate_Universal();
                }
                else
                {
                     dt = Get_CFJWTValidate();
                }
                Error_Message = dt.Rows[0][0].ToString();
                Error_Message_Flag = dt.Columns.Count;
               //  Response.Write("Error_Message_Flag=" + Error_Message_Flag + "<BR>");
                // Response.Write("Error_Message=" + Error_Message + "<BR>");
                //if (Error_Message_Flag < 4)
                //{
                //    Error_Flag = "Y";   
                //}
                Error_Video_Flag = Error_Message_Flag;
                if (Error_Message_Flag == 2)
                {
                    Business_rule_link = dt.Rows[0][1].ToString();
                   // Response.Write("Business_rule_link=" + Business_rule_link + "<BR>");
                    if (Business_rule_link == "")
                    {
                        ShowPhotoBtn = "Y";
                    }
                }
                if (Business_rule_link == "DCM")
                {
                    DataCollectionStatusFlag = "Y";
                    ProdDataColl_Btn.Text = vPrompts[82];
                }
                if (Business_rule_link == "ACM")
                {
                    DataCollectionStatusFlag = "Y";
                    ProdDataColl_Btn.Text = vPrompts[83];
                }
               // Response.Write("DataCollectionStatusFlag=" + DataCollectionStatusFlag);
                //Call Form reported but showing link to the product or assembly button with photo button
                if (Business_rule_link == "PDC")
                {
                    //if (NewScreenPage == "Y")
                    //{
                        DataCollectionStatusFlag = "Y";
                  //  }
                    ProdDataColl_Btn.Text = vPrompts[82];
                    ShowPhotoBtn = "Y";
                }

                if (Business_rule_link == "PAC")
                {
                  //  if (NewScreenPage == "Y")
                   // {
                        DataCollectionStatusFlag = "Y";
                  //  }
                    ProdDataColl_Btn.Text = vPrompts[83];
                    ShowPhotoBtn = "Y";
                }
        //yes to photo flag
                if (Business_rule_link == "YES")
                { 
                    ShowPhotoBtn = "Y";
                }
                BusinessQuestion_Flag=0;	
			    if (Error_Message_Flag==3)
                {
                    Error_Message_Flag = 1;
                    Error_Flag = "Y";
				    BusinessQuestion_Flag=1;
				    return_Message=Error_Message;
				    PhotoButton="NO";
				    Nextbutton="false";
			    }	
				
			if (Error_Message_Flag==2)
                {
                    Error_Message_Flag = 1;
                    Error_Flag = "Y";
				    PhotoButton="NO";
				    Nextbutton="false";
                    if (ShowPhotoBtn == "Y")
                    {
                        PhotoButton = "YES";
                    }
			    }
               //BusinessQuestion_Flag = 1;
            if (Error_Message_Flag==1)
                {
				    return_Message=Error_Message;
                    Error_Flag = "Y";
                }
			else 
                {
				    Error_Flag = "N";
                    Nextbutton = "true";
			    }
                if (Lang_id != 1)
                {
                    Bus_Rule5_Question="N";
                    Bus_Rule6_Question="N";
                    Bus_Rule28_Question="N";
                    Bus_Rule3_Question="N";
                    Bus_Rule4_Question="N";
                    Bus_Rule7_Question="N";
                }

                if (Bus_Rule22_Photo=="")
                {
                    Bus_Rule22_Photo="N";
                }
              
              
			if (Error_Flag == "Y")
                {
                    if (StrPromptcheck == "")
                    {
                        string[] ErrorPrompt;
                        ErrorPrompt = new string[2];

                        ErrorPrompt[0] = "";
                        ErrorPrompt[1] = Error_Message;
                        ptAppTranslation.DoArrayPromptTranslation(ErrorPrompt);
                        return_Message = ErrorPrompt[1];
                        //return_Message=Error_Message;
                        //Response.Write("return_Message=" + return_Message + "<BR>");
                    }
                }
			 else
                {
                    Error_Flag = "N";
				    //PhotoButton="NO"; 
				    Nextbutton="true";
			    }

                //For business rules
                Boolean StrServerhas;
                string Domain1, Domain2, Domain3;
                string[] ArraySERVER_NAME;
                Assembly_status_Flag = "";
                DataCollect_status_Flag = "";
                // Str_SERVER_NAME="dev2k3.sparinc.com";
              //  Response.Write("Str_Merch_no=" + Str_Merch_no);
                StrServerhas = Str_SERVER_NAME.Contains("com");
                // Response.Write("StrServerhas=" + StrServerhas);
               // StrServerhas = true;
                // Response.Write("Str_SERVER_NAME=" + Str_SERVER_NAME);

                if (StrServerhas == false)
                {
                    Bus_Rule_Url = "http://mi11.sparinc.com/pdcs/index.asp";
                    Return_CallFormPath = "http://" + WebConfig_ServerName.Trim() + "/internetCallForm/CFJWTInputs.aspx";
                }
                else
                {
                    ArraySERVER_NAME = Str_SERVER_NAME.Split(".".ToCharArray());

                    Domain1 = ArraySERVER_NAME[0];
                    Domain2 = ArraySERVER_NAME[1];
                    Domain3 = ArraySERVER_NAME[2];
                    //Response.Write("Domain1=" + Domain1);
                    //Response.Write("Domain2=" + Domain2);
                    //Response.Write("Domain3=" + Domain3);
                   // Response.Write("Business_rule_link222=" + Business_rule_link);
                    //RTS_Url = "http://mi23.sparinc.com/itsnet/its_IssueAddNext.aspx";
                    if (GridAddNewVisit == "Yes")
                    {
                        Return_CallFormPath = "http://" + Domain1.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "/internetCallForm/CFJWT_Input_Photo_Option.aspx";    
                    }
                    else
                    {
                        Return_CallFormPath = "http://" + Domain1.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "/internetCallForm/CFJWTValidateSV.aspx";
                    }
                   // Response.Write("Business_rule_link=" + Business_rule_link);
                    if ((Business_rule_link == "DCM") || (Business_rule_link == "PDC"))
                    {
                        Bus_Rule_Url = "http://" + DCM_ServerName.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "" + DCM_PathName + "";
                                //New
                                if (StrAccessToNewDataCollectApp_flag == "Y")
                                {
                                    Bus_Rule_Url = "http://" + DCM_ServerNameTest.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "" + DCM_PathNameTest + "";
                                    // Response.Write("Bus_Rule_Url5555=" + Bus_Rule_Url + "<BR>");
                                    Var_DataCollectQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_No + "&Store_no=" + Store_No + "&Job_no=" + Job_No + "&Wave_no=" + Wave_No + "&Task_no=" + Task_No + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                                    // Var_AssemblyQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_no + "&Store_no=" + Store_no + "&Job_no=" + Job_no + "&Wave_no=" + Wave_no + "&Task_no=" + Task_no + "&BusTypeid=" + Business_Type_id + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                                    Bus_Rule_Url = Bus_Rule_Url + "" + Var_DataCollectQueryString;
                                }

                        DataCollect_status_Flag = "Y";

                    }
                    else
                    {
                            Bus_Rule_Url = "http://" + ACM_ServerName.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "" + ACM_PathName + "";
                                // if ((Str_Merch_no == "116597") || (Str_Merch_no == "122751") || (Str_Merch_no == "116794"))
                                if (StrAccessToNewAssemblyApp_flag == "Y")
                                {
                                    Bus_Rule_Url = "http://" + ACM_ServerNameTest.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "" + ACM_PathNameTest + "";
                                    Var_AssemblyQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_No + "&Store_no=" + Store_No + "&Job_no=" + Job_No + "&Wave_no=" + Wave_No + "&Task_no=" + Task_No + "&BusTypeid=" + Business_Type_id + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                                    // Var_AssemblyQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_no + "&Store_no=" + Store_no + "&Job_no=" + Job_no + "&Wave_no=" + Wave_no + "&Task_no=" + Task_no + "&BusTypeid=" + Business_Type_id + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                                    Bus_Rule_Url = Bus_Rule_Url + "" + Var_AssemblyQueryString;

                                }
                        Assembly_status_Flag = "Y";
                    }
                }
               // if (Lang_id == 4)
                //{
                    Bus_Rule_Url = Bus_Rule_Url.Replace("http", "https");
                    Return_CallFormPath = Return_CallFormPath.Replace("http", "https");
                    Current_URL = Current_URL.Replace("http", "https");
        
                //}
             // Response.Write("Bus_Rule_Url=" + Bus_Rule_Url + "<br>");
                if (Error_Flag !="Y")
                {
                   

                    //********************* Date Function
                    DateTime date = DateTime.Now;

                    StrDate=date;
			        ShowType=0;
                    YearDisplay = clsDateFormat.Date_Format(date, ShowType, DateRule, Date_input);
                    //Response.Write("YearDisplay=" + YearDisplay + "<BR>");
                    //Response.Write("date=" + date + "<BR>");
                    //********************* End Date Function
                   
                    store_id = dt.Rows[0]["store_id"].ToString();
                    //Response.Write("store_id=" + store_id + "<BR>");

                    Store_Chain_Desc = dt.Rows[0]["Store_Chain_Desc"].ToString();
                    //Response.Write("Store_Chain_Desc=" + Store_Chain_Desc + "<BR>");
                    Store_Store_Name = dt.Rows[0]["Store_Store_Name"].ToString();
                    Store_Street_Addr = dt.Rows[0]["Store_Street_Addr"].ToString();
                    Store_City = dt.Rows[0]["Store_City"].ToString();
                    Store_State = dt.Rows[0]["Store_State"].ToString();
                    Store_Zip = dt.Rows[0]["Store_Zip"].ToString();
                    Store_Phone_No = dt.Rows[0]["Store_Phone_No"].ToString();

                    
                    CA_merch_no = dt.Rows[0]["CA_merch_no"].ToString();
                    Merch_First_Name = dt.Rows[0]["Merch_First_Name"].ToString();
                    Merch_Last_Name = dt.Rows[0]["Merch_Last_Name"].ToString();
                    Merch_Street_Addr = dt.Rows[0]["Merch_Street_Addr"].ToString();
                    Merch_Street_Addr2 = dt.Rows[0]["Merch_Street_Addr2"].ToString();
                    Merch_City = dt.Rows[0]["Merch_City"].ToString();
                    Merch_State = dt.Rows[0]["Merch_State"].ToString();
                    Merch_Zip = dt.Rows[0]["Merch_Zip"].ToString();
                    Merch_Phone_No = dt.Rows[0]["Merch_Phone_No"].ToString();
                    Merch_Email_Addr = dt.Rows[0]["Merch_Email_Addr"].ToString();
                    Task_Desc = dt.Rows[0]["Task_Desc"].ToString();
                    Task_Addtl_Desc = dt.Rows[0]["Task_Addtl_Desc"].ToString();

                    Field_Start_Dt = dt.Rows[0]["Field_Start_Dt"].ToString();
                    //Response.Write ("Field_Start_Dt1=" + Field_Start_Dt + "<BR>");
                    TodayDate = dt.Rows[0]["TodayDate"].ToString();
                    //Response.Write("TodayDate=" + TodayDate + "<BR>");
                    DateTime Start_Dt = Convert.ToDateTime(Field_Start_Dt);
                    Field_Start_Dt = clsDateFormat.Date_Format(Start_Dt, 2, DateRule, Date_input);
                    //Response.Write("Field_Start_Dt2=" + Field_Start_Dt + "<BR>");		

                    Field_end_Dt = dt.Rows[0]["Field_end_Dt"].ToString();
                   // Response.Write("Field_end_DtBBB=" + Field_end_Dt + "<BR>");	
                    DateTime end_Dt = Convert.ToDateTime(Field_end_Dt);
                    Field_end_Dt = clsDateFormat.Date_Format(end_Dt, 2, DateRule, Date_input);
                    //Response.Write("Field_end_DtAAA=" + Field_end_Dt + "<BR>");	

                    Key_Comp_Dt = dt.Rows[0]["Key_Comp_Dt"].ToString();
                    DateTime KeyComp_Dt = Convert.ToDateTime(Key_Comp_Dt);
                    Key_Comp_Dt = clsDateFormat.Date_Format(KeyComp_Dt, 2, DateRule, Date_input);

                    DOA_Dt = dt.Rows[0]["DOA_Dt"].ToString();
                    DateTime StrDOA_Dt = Convert.ToDateTime(DOA_Dt);
                    DOA_Dt = clsDateFormat.Date_Format(StrDOA_Dt, 2, DateRule, Date_input);
                    //Response.Write("DOA_Dt=" + DOA_Dt + "<BR>");

                    //Response.Write("Key_Comp_Dt=" + Key_Comp_Dt + "<BR>");	


                    Job_Type = dt.Rows[0]["Job_Type"].ToString();
                    Business_Type_id = dt.Rows[0]["Business_Type_id"].ToString();
                 
                    Work_Type_id = dt.Rows[0]["Work_Type_id"].ToString();
                    Work_Type_Desc = dt.Rows[0]["Work_Type_Desc"].ToString();
                    Max_Mx_Per_Store = dt.Rows[0]["Max_Mx_Per_Store"].ToString();
                    Max_Visit_Per_Store_Mx = dt.Rows[0]["Max_Visit_Per_Store_Mx"].ToString();
                    visit_no = dt.Rows[0]["visit_no"].ToString();

                    Collect_iVR_Time = dt.Rows[0]["Collect_iVR_Time"].ToString();
                    //Response.Write("Collect_iVR_Time=" + Collect_iVR_Time + "<BR>");

                    night_visits = dt.Rows[0]["night_visits"].ToString();
                    Mileage_flag = dt.Rows[0]["Mileage_flag"].ToString();
                    Travel_flag = dt.Rows[0]["Travel_flag"].ToString();

                    Data_Col_Method = dt.Rows[0]["Data_Col_Method"].ToString();
                    All_Data_Received = dt.Rows[0]["All_Data_Received"].ToString();

                    qdef_skippattern = dt.Rows[0]["qdef_skippattern"].ToString();
                    Collect_Header = dt.Rows[0]["Collect_Header"].ToString();
                    Collect_Call_Form = dt.Rows[0]["Collect_Call_Form"].ToString();
                    SS_Callform = dt.Rows[0]["SS_Callform"].ToString();
                    Prod_Specific = dt.Rows[0]["Prod_Specific"].ToString();
                    overwritetime = dt.Rows[0]["overwritetime"].ToString();
                    collect_time_only = dt.Rows[0]["collect_time_only"].ToString();
                    Ask_Q_HH_Used = dt.Rows[0]["Ask_Q_HH_Used"].ToString();
                    HH_Status_Flag = dt.Rows[0]["HH_Status_Flag"].ToString();
                    Collect_Store_Mgr_Name = dt.Rows[0]["Collect_Store_Mgr_Name"].ToString();
                    Product_Check_Flag = dt.Rows[0]["Product_Check_Flag"].ToString();
                    Ask_EShelf_Question = dt.Rows[0]["Ask_EShelf_Question"].ToString();
                    Call_Form_Type_No = dt.Rows[0]["Call_Form_Type_No"].ToString();
                    Est_instore_minutes = dt.Rows[0]["Est_instore_minutes"].ToString();
                    Business_Rule_Eckerd = dt.Rows[0]["Business_Rule_Eckerd"].ToString();
                    Eckerd_Job_Last_question = dt.Rows[0]["Eckerd_Job_Last_question"].ToString();
                    Bus_Rule22_Photo = dt.Rows[0]["Bus_Rule22_Photo"].ToString();
                    Bus_Rule5_Question = dt.Rows[0]["Bus_Rule5_Question"].ToString();
                    Bus_Rule6_Question = dt.Rows[0]["Bus_Rule6_Question"].ToString();
                    Bus_Rule28_Question = dt.Rows[0]["Bus_Rule28_Question"].ToString();
                    Bus_Rule3_Question = dt.Rows[0]["Bus_Rule3_Question"].ToString();
                    Bus_Rule4_Question = dt.Rows[0]["Bus_Rule4_Question"].ToString();
                    Bus_Rule7_Question = dt.Rows[0]["Bus_Rule7_Question"].ToString();
                    Furn_Assembly_Visit_dt = dt.Rows[0]["Furn_Assembly_Visit_dt"].ToString();
                    Disable_photo_upload = dt.Rows[0]["Disable_photo_upload"].ToString();

                    Display_Assembly_btn = dt.Rows[0]["Display_Assembly_btn"].ToString();
                    Display_Prod_Data_btn = dt.Rows[0]["Display_Prod_Data_btn"].ToString();
                    Str_Sv_Panel_id = dt.Rows[0]["Str_Sv_Panel_id"].ToString();
                    //Response.Write("Str_Sv_Panel_id=" + Str_Sv_Panel_id);
                   
                    Work_cap_percent_Min = dt.Rows[0]["Work_cap_percent_Min"].ToString();
                   //Response.Write("Work_cap_percent_Min=" + Work_cap_percent_Min + "<BR>");
                   // Response.Write("Bus_Rule22_Photo=" + Bus_Rule22_Photo + "<BR>");
                    Proposed_Visit_Dt = dt.Rows[0]["Proposed_Visit_Dt"].ToString();


                    if (Lang_id == 1)
                    {
                        CalforniaMileage_flag = dt.Rows[0]["CalforniaMileage_flag"].ToString();

                        CalforTimeCap = dt.Rows[0]["CalforTimeCap"].ToString();
                        Merch_California_Status = dt.Rows[0]["StrMerch_California_Status"].ToString();
                        // Response.Write("CalforniaMileage_flag=" + CalforniaMileage_flag + "<BR>");
                        // Response.Write("CalforTimeCap=" + CalforTimeCap + "<BR>");

                    }
                    if (string.IsNullOrEmpty(GoLiteDate) == true)
                    {
                        //Response.Write("Proposed_Visit_Dt=" + Proposed_Visit_Dt + "<BR>"); 
                        if (string.IsNullOrEmpty(Proposed_Visit_Dt) == false)
                        {
                            GoLiteDate = Proposed_Visit_Dt;    
                        }
                    }
                 Boolean StrServerhas2;
                 string StrDomain1, StrDomain2, StrDomain3;
                string[] ArraySER_nameSplit1; 
                //Str_SERVER_NAME="dev2k3.sparinc.com";

                StrServerhas2 = Str_SERVER_NAME.Contains("com");
                // Response.Write("StrServerhas=" + StrServerhas);
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
                    if (GridAddNewVisit == "Yes")
                    {
                        Return_CallFormPath = "http://" + StrDomain1.Trim() + "." + StrDomain2.Trim() + "." + StrDomain3.Trim() + "/internetCallForm/CFJWT_Input_Photo_Option.aspx";
                    }
                    else
                    {
                        Return_CallFormPath = "http://" + StrDomain1.Trim() + "." + StrDomain2.Trim() + "." + StrDomain3.Trim() + "/internetCallForm/CFJWTValidateSV.aspx";
                    }
                    //Response.Write("Return_CallFormPath=" + Return_CallFormPath);
                    if (Display_Prod_Data_btn == "Y")
                    {
                        Prod_Data_Url = "http://" + DCM_ServerName.Trim() + "." + StrDomain2.Trim() + "." + StrDomain3.Trim() + "" + DCM_PathName + "";

                        if (StrAccessToNewDataCollectApp_flag == "Y")
                        {
                            Prod_Data_Url = "http://" + DCM_ServerNameTest.Trim() + "." + StrDomain2.Trim() + "." + StrDomain3.Trim() + "" + DCM_PathNameTest + "";

                            Var_DataCollectQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_No + "&Store_no=" + Store_No + "&Job_no=" + Job_No + "&Wave_no=" + Wave_No + "&Task_no=" + Task_No + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                            // Var_AssemblyQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_no + "&Store_no=" + Store_no + "&Job_no=" + Job_no + "&Wave_no=" + Wave_no + "&Task_no=" + Task_no + "&BusTypeid=" + Business_Type_id + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                            Prod_Data_Url = Prod_Data_Url + "" + Var_DataCollectQueryString;
                        }

                        
                            Prod_Data_Url = Prod_Data_Url.Replace("http", "https");
                         
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
               // {
                    if (string.IsNullOrEmpty(Assembly_Url) == false)
                    {
                        Assembly_Url = Assembly_Url.Replace("http", "https");
                    }
                    Return_CallFormPath = Return_CallFormPath.Replace("http", "https");
                //}
                   // Response.Write("Prod_Data_Url=" + Prod_Data_Url + "<BR>");

              // Response.Write("Assembly_Url=" + Assembly_Url + "<BR>");
                    if (string.IsNullOrEmpty(Furn_Assembly_Visit_dt) == false)
                    {
                        DateTime Furn_Start_Dt = Convert.ToDateTime(Furn_Assembly_Visit_dt);
                        Furn_Assembly_Visit_dt = clsDateFormat.Date_Format(Furn_Start_Dt, 2, DateRule, Date_input);
                    }
                     //Response.Write("Bus_Rule22_PhotoP=" + Bus_Rule22_Photo + "<BR>");
                     //Response.Write("Disable_photo_uploadP=" + Disable_photo_upload + "<BR>");
                    if (Bus_Rule22_Photo == "N")
                    {

                        txt_visitmonth.Attributes.Add("onkeypress", "return DateNumberOnly(event)");
                        txt_visitday.Attributes.Add("onkeypress", "return DateNumberOnly(event)");
                        txt_visityear.Attributes.Add("onkeypress", "return DateNumberOnly(event)");
                    }
                    //Test Variables
                    //Ask_Q_HH_Used = "Y";
                    //Bus_Rule5_Question = "Y";
                    //Bus_Rule6_Question = "Y";
                   //Bus_Rule28_Question = "Y";
                    //Bus_Rule3_Question = "Y";
                   // Bus_Rule4_Question = "Y";
                    //Bus_Rule7_Question = "Y";
                    //Ask_EShelf_Question = "Y";
                    if (Collect_iVR_Time == "Y")
                    {
                        cmb_timein.Items[0].Text = vPrompts[75];
                        cmb_timein.Items[1].Text = vPrompts[76];

                        cmb_timeout.Items[0].Text = vPrompts[75];
                        cmb_timeout.Items[1].Text = vPrompts[76];
                    }
                    if (qdef_skippattern == "NO")
                    {
                        if (Max_Visit_Per_Store_Mx.Trim() == visit_no.Trim())
                        {
                            if (Collect_Store_Mgr_Name == "Y")
                            {
                                rad_q_Ret_store_visit.Attributes.Add("onClick", "CollectManagerInfo()");
                            }
                        }
                    }
                    //Response.Write("StrLogInMtype=" + StrLogInMtype + "<BR>");
                  //  Response.Write("Valid_Cal_Merch=" + Valid_Cal_Merch + "<BR>");
                   // Response.Write("CalforniaMileage_flag=" + CalforniaMileage_flag + "<BR>");
                    //******************Calfornia Merch
                    if (StrLogInMtype == "Y")
                    {
                        if (Valid_Cal_Merch == "Y")
                        {
                            if (CalforniaMileage_flag == "CA")
                            {
                                Merch_California_Status = "Y";
                                //Mileage_flag="Y";
                                //Travel_flag = "Y";
                            }
                        }
                    }

                    //************** drop menu for manager title
                     if (Collect_Store_Mgr_Name == "Y")
                        {
                            Manager_Title.DataSource = Get_ManagerMenu();
                            Manager_Title.DataValueField = "Ttile";
                            Manager_Title.DataBind();
                           
                        }
                        if (Collect_iVR_Time == "Y")
                        {
                            if (Str_cmb_timein != "")
                            {
                                if (string.IsNullOrEmpty(Str_cmb_timein) == false)
                                {
                                    cmb_timein.SelectedValue = Str_cmb_timein;
                                }
                            }
                            if (Str_cmb_timeout != "")
                            {
                                if (string.IsNullOrEmpty(Str_cmb_timeout) == false)
                                {
                                    cmb_timeout.SelectedValue = Str_cmb_timeout;
                                }
                            }
                        }
                        if (Collect_Store_Mgr_Name == "Y")
                        {
                            if (Str_Manager_Title != "")
                            {
                                if (string.IsNullOrEmpty(Str_Manager_Title) == false)
                                {
                                    Manager_Title.SelectedValue = Str_Manager_Title;
                                }
                            }
                        }
                        if (night_visits == "Y")
                        {
                            if (Str_rad_q_Past_Midnight != "")
                            {
                                if (string.IsNullOrEmpty(Str_rad_q_Past_Midnight) == false)
                                {
                                    rad_q_Past_Midnight.SelectedValue = Str_rad_q_Past_Midnight;
                                }
                            }
                        }
                        if (Ask_Q_HH_Used == "Y")
                        {
                            if (Str_rad_q_HH_Used != "")
                            {
                                if (string.IsNullOrEmpty(Str_rad_q_HH_Used) == false)
                                {
                                    rad_q_HH_Used.SelectedValue = Str_rad_q_HH_Used;
                                }
                            }
                        }
                        if (Convert.ToInt32(Max_Visit_Per_Store_Mx.Trim()) > Convert.ToInt32(visit_no.Trim()))
                        {
                            if (Str_rad_q_Ret_store_visit != "")
                            {
                                if (string.IsNullOrEmpty(Str_rad_q_Ret_store_visit) == false)
                                {
                                    rad_q_Ret_store_visit.SelectedValue = Str_rad_q_Ret_store_visit;
                                }
                            }
                        }

                        if (Bus_Rule3_Question == "Y")
                        {
                            if (Str_rad_q_BR3 != "")
                            {
                                if (string.IsNullOrEmpty(Str_rad_q_BR3) == false)
                                {
                                    rad_q_BR3.SelectedValue = Str_rad_q_BR3;
                                }
                            }
                        }
                        if (Bus_Rule4_Question == "Y")
                        {
                            if (Str_rad_q_BR4 != "")
                            {
                                if (string.IsNullOrEmpty(Str_rad_q_BR4) == false)
                                {
                                    rad_q_BR4.SelectedValue = Str_rad_q_BR4; 
                                }
                            }
                        }
                        if (Bus_Rule5_Question  == "Y")
                        {
                            if (Str_rad_q_BR5 != "")
                            {
                                if (string.IsNullOrEmpty(Str_rad_q_BR5) == false)
                                {
                                    rad_q_BR5.SelectedValue = Str_rad_q_BR5; 
                                }
                            }
                        }
                        if (Bus_Rule6_Question == "Y")
                        {
                            if (Str_rad_q_BR6 != "")
                            {
                                if (string.IsNullOrEmpty(Str_rad_q_BR6) == false)
                                {
                                    rad_q_BR6.SelectedValue = Str_rad_q_BR6; 
                                }
                            }
                        }
                        if (Bus_Rule7_Question == "Y")
                        {
                            if (Str_rad_q_BR7 != "")
                            {
                                if (string.IsNullOrEmpty(Str_rad_q_BR7) == false)
                                {
                                    rad_q_BR7.SelectedValue = Str_rad_q_BR7; 
                                }
                            }
                        }
                        if (Bus_Rule28_Question == "Y")
                        {
                            if (Str_rad_q_BR28 != "")
                            {
                                if (string.IsNullOrEmpty(Str_rad_q_BR28) == false)
                                {
                                    rad_q_BR28.SelectedValue = Str_rad_q_BR28; 
                                }
                            }
                        }
                    //Response.Write("Field_Start_Dttt=" +   Field_Start_Dt + "<BR>");

                   if (CA_merch_no.Trim() != Str_Merch_no.Trim()) 
                    {
									if (string.IsNullOrEmpty(CA_merch_no)==true)
                                        {
                                            CA_merch_no = "";
                                        }
									        Merch_Message =   "" + vPrompts[74] + "" + vPrompts[1] + "&nbsp" + (CA_merch_no) + ". &nbsp" + vPrompts[72] + "";
                    }
					else
                    {
                        Merch_Message = "" + vPrompts[72] + "";
					}   

                }

               // System.Text.StringBuilder JWTInfoText = new System.Text.StringBuilder();
            StringBuilder HTMLText = new StringBuilder();
            StringBuilder HTMLTextSpanDisplay = new StringBuilder();
          // System.Text.StringBuilder HTMLText = new System.Text.StringBuilder();
           
                    //HTMLText = "";
                HTMLText.Append("<table border='1' id='TABLE1' borderColor='dodgerblue' bgcolor='mintcream' align='center' width='100%'> ");
                HTMLText.Append("<tr>");
                        HTMLText.Append("<td  align='left' class='applicationHeader'>");
                        HTMLText.Append("<span class='reportTableHeader' >" + vPrompts[4] + "</span>");  
                        HTMLText.Append("</td>");
               HTMLText.Append("</tr>");
               HTMLText.Append("<tr>");
                        HTMLText.Append("<td align=left  width='100%'>");
                            // Job Information
                                        HTMLText.Append("<table border='0'  width='100%'>");
                                        HTMLText.Append("<tr>");
                                                HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>"  + vPrompts[5] + "");
                                                HTMLText.Append("</td>");
                                                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Job_No + "");
                                                if (Error_Flag != "Y")
                                                {
                                                    HTMLText.Append("  " + Task_Addtl_Desc + "");    
                                                }
                                                HTMLText.Append("</td>");
                                        HTMLText.Append("</tr>");
                                        HTMLText.Append("</table>	");
                        HTMLText.Append("</td>");
                HTMLText.Append("</tr>");	
                HTMLText.Append("<tr>");
                        HTMLText.Append("<td align=left  width='100%'>");
                            // wave Information
                                        HTMLText.Append("<table border='0'  width='100%'>");
                                        HTMLText.Append("<tr>");
                                                HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>"  + vPrompts[6] + "");
                                                HTMLText.Append("</td>");
                                                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Wave_No + "");
                                                if (Error_Flag != "Y")
                                                {
                                                    HTMLText.Append("  " +  vPrompts[7] + "" + Field_Start_Dt + "" +  vPrompts[8] + "" + Field_end_Dt + ")");    
                                                }
                                                HTMLText.Append("</td>");
                                        HTMLText.Append("</tr>");
                                        HTMLText.Append("</table>	");
                        HTMLText.Append("</td>");
                HTMLText.Append("</tr>");
	             HTMLText.Append("<tr>");
                        HTMLText.Append("<td align=left  width='100%'>");
                            // Task Information
                                        HTMLText.Append("<table border='0'  width='100%'>");
                                        HTMLText.Append("<tr>");
                                                HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>"  + vPrompts[9] + "");
                                                HTMLText.Append("</td>");
                                                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Task_No + "");
                                                if (Error_Flag != "Y")
                                                {
                                                    HTMLText.Append("  " +  Task_Desc + "");    
                                                }
                                                HTMLText.Append("</td>");
                                        HTMLText.Append("</tr>");
                                        HTMLText.Append("</table>	");
                        HTMLText.Append("</td>");
                HTMLText.Append("</tr>");
                // Chain Information
                HTMLText.Append("<tr>");
                HTMLText.Append("<td  align='left' class='applicationHeader'>");
                HTMLText.Append(" <span class='reportTableHeader' align=left>" + vPrompts[10] + "</span> ");
                HTMLText.Append("</td>");
                HTMLText.Append("</tr>");
                HTMLText.Append("<tr>");
                HTMLText.Append("<td align=left  width='100%'>");
               
                HTMLText.Append("<table border='0'  width='100%'>");
                HTMLText.Append("<tr>");
                HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[11] + "");
                HTMLText.Append("</td>");
                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Chain_No + "");
                if (Error_Flag != "Y")
                {
                    HTMLText.Append("  " + Store_Chain_Desc + "");
                }
                HTMLText.Append("</td>");
                HTMLText.Append("</tr>");
                HTMLText.Append("</table>	");
                HTMLText.Append("</td>");
                HTMLText.Append("</tr>");
                // store Information
                HTMLText.Append("</tr>");
                HTMLText.Append("<tr>");
                HTMLText.Append("<td  align='left' class='applicationHeader' >");
                HTMLText.Append(" <span class='reportTableHeader' align=left>" + vPrompts[12] + "</span> ");
                HTMLText.Append("</td>");
                HTMLText.Append("</tr>");
                //Store no
                HTMLText.Append("<td align=left  width='100%'>");

                HTMLText.Append("<table border='0'  width='100%'>");
                HTMLText.Append("<tr>");
                HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[13] + "");
                HTMLText.Append("</td>");
                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Store_No + "");

                HTMLText.Append("</td>");
                HTMLText.Append("</tr>");
                HTMLText.Append("</table>	");
                HTMLText.Append("</td>");
                HTMLText.Append("</tr>");

                if (Error_Flag != "Y")
                {
                            // Store name
                                    HTMLText.Append("<tr>");
                                    HTMLText.Append("<td align=left  width='100%'>");
                                    HTMLText.Append("<table border='0'  width='100%'>");
                                    HTMLText.Append("<tr>");
                                    HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[14] + "");
                                    HTMLText.Append("</td>");
                                    HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Store_Store_Name + "");
                                    HTMLText.Append("</td>");
                                    HTMLText.Append("</tr>");
                                    HTMLText.Append("</table>	");
                                    HTMLText.Append("</td>");
                                    HTMLText.Append("</tr>");
                                    HTMLText.Append("<tr>");
                      string[] ArrayAddress;
                      int i;
                      ArrayAddress = new string[3];
                      ArrayAddress = AddressRule.Split(",".ToCharArray());
                      
                      for (i = 0; i < ArrayAddress.Length; i++)
                      {
                                       

                                     if (ArrayAddress[i].ToUpper() == ("Street").ToUpper())
                                      {
                                              // Store Street_Addr
                                              HTMLText.Append("<tr>");
                                              HTMLText.Append("<td align=left  width='100%'>");
                                              HTMLText.Append("<table border='0'  width='100%'>");
                                              HTMLText.Append("<tr>");
                                              HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[15] + "");
                                              HTMLText.Append("</td>");
                                              HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Store_Street_Addr + "");
                                              HTMLText.Append("</td>");
                                              HTMLText.Append("</tr>");
                                              HTMLText.Append("</table>	");
                                              HTMLText.Append("</td>");
                                              HTMLText.Append("</tr>");
                                              HTMLText.Append("<tr>");
                                      }
                                      if (ArrayAddress[i].ToUpper() == ("City").ToUpper())
                                      {
                                                // Store city
                                                HTMLText.Append("<tr>");
                                                HTMLText.Append("<td align=left  width='100%'>");
                                                HTMLText.Append("<table border='0'  width='100%'>");
                                                HTMLText.Append("<tr>");
                                                HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[16] + "");
                                                HTMLText.Append("</td>");
                                                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Store_City + "");
                                                HTMLText.Append("</td>");
                                                HTMLText.Append("</tr>");
                                                HTMLText.Append("</table>	");
                                                HTMLText.Append("</td>");
                                                HTMLText.Append("</tr>");
                                                HTMLText.Append("<tr>");
                                      }
                                      if (ArrayAddress[i].ToUpper() == ("State").ToUpper())
                                      {
                                                // Store state
                                                HTMLText.Append("<tr>");
                                                HTMLText.Append("<td align=left  width='100%'>");
                                                HTMLText.Append("<table border='0'  width='100%'>");
                                                HTMLText.Append("<tr>");
                                                HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[17] + "");
                                                HTMLText.Append("</td>");
                                                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Store_State + "");
                                                HTMLText.Append("</td>");
                                                HTMLText.Append("</tr>");
                                                HTMLText.Append("</table>	");
                                                HTMLText.Append("</td>");
                                                HTMLText.Append("</tr>");
                                                HTMLText.Append("<tr>");

                                      }
                                      if (ArrayAddress[i].ToUpper() == ("Zip").ToUpper())
                                      {

                                                  // Store zip
                                                  HTMLText.Append("<tr>");
                                                  HTMLText.Append("<td align=left  width='100%'>");
                                                  HTMLText.Append("<table border='0'  width='100%'>");
                                                  HTMLText.Append("<tr>");
                                                  HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[18] + "");
                                                  HTMLText.Append("</td>");
                                                  HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Store_Zip + "");
                                                  HTMLText.Append("</td>");
                                                  HTMLText.Append("</tr>");
                                                  HTMLText.Append("</table>	");
                                                  HTMLText.Append("</td>");
                                                  HTMLText.Append("</tr>");
                                                  HTMLText.Append("<tr>");
                                      }

                    }//End of for loop
                     //string 
                    //SAddressArray = (v_sys_rule(2),",")
                    //for i = 0 to UBound(SAddressArray)
                    //Store_Phone_No
                                HTMLText.Append("<tr>");
                                HTMLText.Append("<td align=left  width='100%'>");
                                HTMLText.Append("<table border='0'  width='100%'>");
                                HTMLText.Append("<tr>");
                                HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[26] + "");
                                HTMLText.Append("</td>");
                                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Store_Phone_No + "");
                                HTMLText.Append("</td>");
                                HTMLText.Append("</tr>");
                                HTMLText.Append("</table>");
                                HTMLText.Append("</td>");
                                HTMLText.Append("</tr>");
                                HTMLText.Append("<tr>");
                }
                HTMLTextSpanDisplay.Append(HTMLText.ToString());
                //HTMLTextSpanDisplay.Append("</table>");
                //ShowDetail.InnerHtml = HTMLTextSpanDisplay.ToString();
                StrInformationDisplay = HTMLTextSpanDisplay.ToString();

                // merch Information
                HTMLText.Append("</tr>");
                HTMLText.Append("<tr>");
                HTMLText.Append("<td  align='left' class='applicationHeader'>");
                HTMLText.Append(" <span class='reportTableHeader' align=left>" + vPrompts[19] + "</span> ");
                HTMLText.Append("</td>");
                HTMLText.Append("</tr>");
                
                //Merch no
                HTMLText.Append("<td align=left  width='100%'>");

                HTMLText.Append("<table border='0'  width='100%'>");
                HTMLText.Append("<tr>");
                HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[20] + "");
                HTMLText.Append("</td>");
                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Str_Merch_no + "");

                HTMLText.Append("</td>");
                HTMLText.Append("</tr>");
                HTMLText.Append("</table>	");
                HTMLText.Append("</td>");
                HTMLText.Append("</tr>");

                if (Error_Flag != "Y")
                {
                    string[] ArrayName;
                    int j;
                    ArrayName = new string[2];
                    ArrayName = NameRule.Split(",".ToCharArray());


                    // Merch name
                    HTMLText.Append("<tr>");
                    HTMLText.Append("<td align=left  width='100%'>");
                    HTMLText.Append("<table border='0'  width='100%'>");
                    HTMLText.Append("<tr>");
                    HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[21] + "");
                    HTMLText.Append("</td>");
                    string MerchName;
                    MerchName = "";
                    for (j = 0; j < ArrayName.Length; j++)
                    {
                        if (ArrayName[j].ToUpper() == ("First").ToUpper())
                        {
                            MerchName = MerchName + " " + Merch_First_Name;
                        }
                        if (ArrayName[j].ToUpper() == ("Last").ToUpper())
                        {
                            MerchName = MerchName + " " + Merch_Last_Name;
                        }
                    }

                    HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + MerchName + "  ");

                    HTMLText.Append("</td>");
                    HTMLText.Append("</tr>");
                    HTMLText.Append("</table>");
                    HTMLText.Append("</td>");
                    HTMLText.Append("</tr>");
                    HTMLText.Append("<tr>");
                    int x;
                    string[] ArrayAddress2;

                    ArrayAddress2 = new string[3];
                    ArrayAddress2 = AddressRule.Split(",".ToCharArray());

                    for (x = 0; x < ArrayAddress2.Length; x++)
                    {


                        if (ArrayAddress2[x].ToUpper() == ("Street").ToUpper())
                        {
                            // Merch Street_Addr
                            HTMLText.Append("<tr>");
                            HTMLText.Append("<td align=left  width='100%'>");
                            HTMLText.Append("<table border='0'  width='100%'>");
                            HTMLText.Append("<tr>");
                            HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[15] + "");
                            HTMLText.Append("</td>");

                            if (Merch_Street_Addr != "" || Merch_Street_Addr != null)
                            {
                                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Merch_Street_Addr + "");
                            }
                            else
                            {
                                HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Merch_Street_Addr2 + "");
                            }
                            HTMLText.Append("</td>");
                            HTMLText.Append("</tr>");
                            HTMLText.Append("</table>	");
                            HTMLText.Append("</td>");
                            HTMLText.Append("</tr>");
                            HTMLText.Append("<tr>");
                        }
                        if (ArrayAddress2[x].ToUpper() == ("City").ToUpper())
                        {
                            // Merch city
                            HTMLText.Append("<tr>");
                            HTMLText.Append("<td align=left  width='100%'>");
                            HTMLText.Append("<table border='0'  width='100%'>");
                            HTMLText.Append("<tr>");
                            HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[23] + "");
                            HTMLText.Append("</td>");
                            HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Merch_City + "");
                            HTMLText.Append("</td>");
                            HTMLText.Append("</tr>");
                            HTMLText.Append("</table>	");
                            HTMLText.Append("</td>");
                            HTMLText.Append("</tr>");
                            HTMLText.Append("<tr>");
                        }
                        if (ArrayAddress2[x].ToUpper() == ("State").ToUpper())
                        {
                            // Merch state
                            HTMLText.Append("<tr>");
                            HTMLText.Append("<td align=left  width='100%'>");
                            HTMLText.Append("<table border='0'  width='100%'>");
                            HTMLText.Append("<tr>");
                            HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[24] + "");
                            HTMLText.Append("</td>");
                            HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Merch_State + "");
                            HTMLText.Append("</td>");
                            HTMLText.Append("</tr>");
                            HTMLText.Append("</table>	");
                            HTMLText.Append("</td>");
                            HTMLText.Append("</tr>");
                            HTMLText.Append("<tr>");
                        }
                        if (ArrayAddress2[x].ToUpper() == ("Zip").ToUpper())
                        {
                            // Merch zip
                            HTMLText.Append("<tr>");
                            HTMLText.Append("<td align=left  width='100%'>");
                            HTMLText.Append("<table border='0'  width='100%'>");
                            HTMLText.Append("<tr>");
                            HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[25] + "");
                            HTMLText.Append("</td>");
                            HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Merch_Zip + "");
                            HTMLText.Append("</td>");
                            HTMLText.Append("</tr>");
                            HTMLText.Append("</table>	");
                            HTMLText.Append("</td>");
                            HTMLText.Append("</tr>");
                            HTMLText.Append("<tr>");
                        }
                    }
                    // Merch Phone No. 
                    HTMLText.Append("<tr>");
                    HTMLText.Append("<td align=left  width='100%'>");
                    HTMLText.Append("<table border='0'  width='100%'>");
                    HTMLText.Append("<tr>");
                    HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[26] + "");
                    HTMLText.Append("</td>");
                    HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Merch_Phone_No + "");
                    HTMLText.Append("</td>");
                    HTMLText.Append("</tr>");
                    HTMLText.Append("</table>	");
                    HTMLText.Append("</td>");
                    HTMLText.Append("</tr>");
                    HTMLText.Append("<tr>");
                    // Merch Email
                    HTMLText.Append("<tr>");
                    HTMLText.Append("<td align=left  width='100%'>");
                    HTMLText.Append("<table border='0'  width='100%'>");
                    HTMLText.Append("<tr>");
                    HTMLText.Append("<td class='reportCriteriaHeader'  width='10%' align=left>" + vPrompts[27] + "");
                    HTMLText.Append("</td>");
                    HTMLText.Append("<td class='selectionCriteriaItem' width='85%' align=left>:" + Merch_Email_Addr + "");
                    HTMLText.Append("</td>");
                    HTMLText.Append("</tr>");
                    HTMLText.Append("</table>	");
                    HTMLText.Append("</td>");
                    HTMLText.Append("</tr>");
                    HTMLText.Append("<tr>");
                    //string 
                    //SAddressArray = (v_sys_rule(2),",")
                    //for i = 0 to UBound(SAddressArray)

                }
                //Response.Write("Str_visityear=" + Str_visityear + "<BR>");
                if (string.IsNullOrEmpty(Str_visityear) == true)
                {
                    txt_visityear.Text = YearDisplay;
                    //Response.Write("YearDisplay=" + YearDisplay + "<BR>");
                }
                else
                {
                    if (Lang_id == 1)
                    {
                        Str_visityear = Str_visityear.Trim();
                        if (Str_visityear.Length > 3)
                        {
                            Str_visityear = Str_visityear.Substring(2, 2);
                        }
                    }
                    if (Lang_id == 13)
                    {
                        Str_visityear = Str_visityear.Trim();
                        if (Str_visityear.Length > 3)
                        {
                            Str_visityear = Str_visityear.Substring(2, 2);
                        }
                    }
                    txt_visityear.Text = Str_visityear;
                    //Response.Write("Str_visityear=" + Str_visityear + "<BR>");
                }

               // Response.Write("Disable_photo_upload=" + Disable_photo_upload + "<BR>");
                HTMLText.Append("</table>");
               //Response.Write("HTMLText=" + HTMLText + "<BR>");
                JWTInfoText = HTMLText.ToString();
                //Response.Write("Bus_rule22_MV_Flag=" + Bus_rule22_MV_Flag + "<BR>");
              //  Response.Write("PhotoButton1=" + PhotoButton + "<BR>");
              //  Response.Write("Bus_rule22_MV_Flag=" + Bus_rule22_MV_Flag + "<BR>");
                //multi visit call form business rule 22 new visits
                if (Bus_rule22_MV_Flag == "N")
                {
                    Bus_rule22_MV_NewVisit = "";
                   // Bus_Rule22_Photo = "N";
                }
                // check the responses for photo by question
                if (Disable_photo_upload == "Y")
                {
                    //do not show the photo button
                    PhotoButton = "NO";
                }
                // photo by question new visit will be N
                if (Bus_rule22_MV_NewVisit == "N")
                {
                    //photo button
                   // PhotoButton = "NO";
                    //next button
                   // Bus_Rule22_Photo = "N"; 
                }
                //for no photo by question and business rule 22
                if (Bus_rule22_MV_NewVisit == "Y")
                {
                    //photo button
                    PhotoButton = "YES";
                    //next button
                    Bus_Rule22_Photo = "Y";
                }
               // Response.Write("Bus_Rule22_PhotoAfter=" + Bus_Rule22_Photo + "<BR>");
               // Response.Write("PhotoButton2=" + PhotoButton + "<BR>");
            //   Response.Write("Bus_rule22_MV_NewVisit=" + Bus_rule22_MV_NewVisit + "<BR>");
              // Response.Write("Disable_photo_upload=" + Disable_photo_upload + "<BR>");
              //  Response.Write("PhotoButton2=" + PhotoButton + "<BR>");
                Photo_By_QuestionFlag = "";

                DataSet dt24 = Get_Photo_QuestionCheck(Lang_id, Job_No, Wave_No, Task_No, Chain_No, Store_No, Str_Merch_no, Job_Visit_Date, Str_Sv_Panel_id);
                // ds.Tables[0].Rows.Count
                if (dt24.Tables[0].Rows.Count > 0)
                {
                    Photo_By_QuestionFlag = "Y";
                }
                else
                {
                    Photo_By_QuestionFlag = "N";
                }
               // Response.Write("Job_Visit_Date=" + Job_Visit_Date + "<BR>");
               // Response.Write("Str_Sv_Panel_id=" + Str_Sv_Panel_id + "<BR>");
                // visit Date Status
                //if (GridAddNewVisit == "Yes")
                //{
                //    Job_Visit_Date = "0";
                //}
               
                //Response.Write("PhotoButton=" + PhotoButton + "<BR>");
                // if (Visit_dt_access == "Y")
                // {
                         txt_visitmonth.ReadOnly = false;
                         txt_visitday.ReadOnly = false;
                         txt_visityear.ReadOnly = false;
               //  }
                
                 if (Lang_id == 18)
                 {
                     PhotoButton = "NO";    
                 }
                 if (PhotoButton == "YES")
                 {
                     if (EnableVideo_OptionFlag == "Y")
                     {
                         Submit.Text = "" + vPrompts[80] + "";
                         Submit2.Text = "" + vPrompts[85] + "";
                         Label15.Text = "" + vPrompts[81] + "";
                     }
                 }
                 // photo by question new visit will be N
                 if (Bus_rule22_MV_NewVisit == "N")
                 {
                     if (EnableVideo_OptionFlag == "Y")
                     {
                         DisplayVideoBtn = "Y";    
                     }
                 }

                 //if the question by photo and business 35 is setup then show video upload button 
                 if ((Disable_photo_upload=="Y")&&(EnableVideo_OptionFlag == "Y"))
                 {
                     DisplayVideoBtn = "Y";
                 }
                 if (Business_rule_link != "")
                 {
                     if ((Business_rule_link == "YES") && (Photo_By_QuestionFlag == "Y"))
                     {
                         if (EnableVideo_OptionFlag == "Y")
                         {
                             DisplayVideoBtn = "Y";
                         }
                     }
                     if ((Business_rule_link == "NO") && (Photo_By_QuestionFlag == "N"))
                     {
                         if (EnableVideo_OptionFlag == "Y")
                         {
                             DisplayVideoBtn = "Y";
                         }
                     }
                     if ((Business_rule_link == "YES") && (Photo_By_QuestionFlag == "N"))
                     {
                         if (EnableVideo_OptionFlag == "Y")
                         {
                             //DisplayVideoBtn = "Y";
                             Submit2.Text = "" + vPrompts[80] + "";
                         }
                     }
                 }
                 //The Call Form has been answered
                //Response.Write("ShowPhotoBtn=" + ShowPhotoBtn);
                //Response.Write("Business_rule_link=" + Business_rule_link);
                //Boolean StrhasText;

              //  StrhasText = Error_Message.Contains("com");
                //*********************** Go lite 
                 //if (string.IsNullOrEmpty(GoLiteDate) == false)
                // {
                 //    txt_visitmonth.ReadOnly = true;
                //     txt_visitday.ReadOnly = true;
                //     txt_visityear.ReadOnly = true;
              //   }

                 if (Error_Video_Flag == 2)
                {
                    if (!Error_Message.Contains("The Call Form has been answered"))
                    {
                        DisplayVideoBtn = "N";
                    }
                    if (Error_Message.Contains("The Call Form has been answered for this Job/Wave/Task by Merch No"))
                    {
                        DisplayVideoBtn = "N";
                    }
                     
                }

                StringBuilder HTMLTextLink= new StringBuilder();
                StringBuilder HTMLTextLinkPopUpDiv = new StringBuilder();
                // System.Text.StringBuilder HTMLText = new System.Text.StringBuilder();
               

                string Htmltext = ""; 
                string ColAdd = "";
                string Old_Str_msg_id = "";
                string StrResponseText = "";
                string StrResponseText2 = "";
                string StartPoint = "";
                //HTMLText = "";
                HTMLTextLink.Append("<table border='1' id='TABLE1' borderColor='dodgerblue' bgcolor='mintcream' align='center' width='100%'> ");
                HTMLTextLink.Append("<tr>");
                HTMLTextLink.Append("<td  align='center' class='applicationLinkHeader' width='10%'>");
                HTMLTextLink.Append("<span class='reportTableHeader' >" + vPrompts[87] + "</span>");
                HTMLTextLink.Append("</td>");
                HTMLTextLink.Append("<td  align='center' class='applicationLinkHeader' width='50%'>");
                HTMLTextLink.Append("<span class='reportTableHeader' >" + vPrompts[88] + "</span>");
                HTMLTextLink.Append("</td>");
                HTMLTextLink.Append("<td  align='center' class='applicationLinkHeader' width='30%'>");
                HTMLTextLink.Append("<span class='reportTableHeader' >" + vPrompts[89] + "</span>");
                HTMLTextLink.Append("</td>");
                HTMLTextLink.Append("<td  align='center' class='applicationLinkHeader'width='10%'>");
                HTMLTextLink.Append("<span class='reportTableHeader' >" + vPrompts[90] + "</span>");
                HTMLTextLink.Append("</td>");
                HTMLTextLink.Append("</tr>");
                HTMLTextLink.Append("<tr>");

                //************************ Photo link pop up -- msg_id,msg_dt,msg_text,msg_title,Link_Status,Link_url_Type 
                DataTable dt2 = Get_CFJWT_MeassgeLinkPhotoCall(Lang_id, Job_No, Wave_No, Task_No, Chain_No, Store_No, Str_Merch_no);
                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow myRow in dt2.Rows)
                    {
                        

                        Str_Recordset_type = Convert.ToString(myRow["Recordset_type"]);
                        //Response.Write("Str_Recordset_type=" + Str_Recordset_type + "<BR>");

                        Str_msg_id = Convert.ToString(myRow["msg_id"]);
                        //Response.Write("Str_msg_id=" + Str_msg_id + "<BR>");

                        Str_msg_dt = Convert.ToString(myRow["msg_dt"]);
                        //Response.Write("Str_msg_dt=" + Str_msg_dt + "<BR>");

                        Str_msg_text = Convert.ToString(myRow["msg_text"]);
                        //Response.Write("Str_msg_text=" + Str_msg_text + "<BR>");

                        Str_msg_title = Convert.ToString(myRow["msg_title"]);
                        //Response.Write("Str_msg_title=" + Str_msg_title + "<BR>");

                        Str_Link_Status = Convert.ToString(myRow["Link_Status"]);
                       // Response.Write("Str_Link_Status=" + Str_Link_Status + "<BR>");

                        Str_Link_url_Type = Convert.ToString(myRow["Link_url_Type"]);
                        //Response.Write("Str_Link_url_Type=" + Str_Link_url_Type + "<BR>"); 
                       

                        ColAdd = String.Concat("onclick=", '"', "return LinkPopUPwin('", Str_Link_Status, "','", Str_msg_id, "');", '"');
                        //Htmltext = "<input id='" + ColID + "' type='checkbox' name='" + ColName + "' " + ColAdd + "/>";
                        if (Str_Recordset_type == "1")
                        {
                            HTMLTextLink.Append("<tr>");
                            HTMLTextLink.Append("<td class='selectionCriteriaItem' width='10%' align=left>" + Str_msg_dt + "");
                            HTMLTextLink.Append("</td>");
                            HTMLTextLink.Append("<td class='selectionCriteriaItem' width='50%' align=left>" + Str_msg_title + "");
                            HTMLTextLink.Append("</td>");
                            HTMLTextLink.Append("<td class='selectionCriteriaItem' width='30%' align=left>" + Str_msg_text + "");
                            HTMLTextLink.Append("</td>");
                            if (Str_Link_Status == "Y")
                            {
                                HTMLTextLink.Append("<td class='selectionCriteriaItem' width='10%' align=left><input type='submit' name='popupbutton' value='" + vPrompts[92] + "' " + ColAdd + " id='popupbutton' class='Button'/>");
                                HTMLTextLink.Append("</td>");
                            }
                            else
                            {
                                HTMLTextLink.Append("<td class='selectionCriteriaItem' width='10%' align=left>");
                                HTMLTextLink.Append("</td>");
                            }
                            HTMLTextLink.Append("</tr>");
                        }
                        if (Str_Recordset_type == "2")
                        {
                            if (Str_msg_id != Old_Str_msg_id)
                            {
                               // Response.Write("Str_Link_url_Typein=" + Str_Link_url_Type + "<BR>");
                                if (StartPoint == "N")
                                {
                                    HTMLTextLinkPopUpDiv.Append("'>");
                                }
                                StrResponseText = "<input type='hidden' name='MSG_id" + Str_msg_id.Trim() + "' value='";
                                HTMLTextLinkPopUpDiv.Append("" + StrResponseText + "");

                                Old_Str_msg_id = Str_msg_id;
                            }
                        }
                        if (Str_Link_url_Type != "")
                        {
                            StrResponseText2 = "" + Str_Link_url_Type + "|";
                            HTMLTextLinkPopUpDiv.Append("" + StrResponseText2 + "");
                            StartPoint = "N";
                        }
                    }
                    HTMLTextLink.Append("</table>");
                    //Response.Write("HTMLText=" + HTMLText + "<BR>");
                    HTMLTextLinkPopUpDiv.Append("'>");
                    JWTLinkDivText = HTMLTextLinkPopUpDiv.ToString();
                    JWTLinkInfoText = HTMLTextLink.ToString();
                }
            
            }
#endregion
#region methods


static bool IsNumber(string value)
{
    // Return true if this is a number.
    int number1;
    return int.TryParse(value, out number1);
}
#endregion

#region SystemPromptandRule

   private void GetPromptTranslation()
    {
        
        vPrompts = new string[98];
        vPrompts[0] = "Internet Call Form";
        vPrompts[1] = "The assigned Merchandiser is";
        vPrompts[2] = "Are you sure you want to continue? If so, click Call Form. If not, click Back.";
        vPrompts[3] = "Date:";
       
        if (StrPromptcheck == "Y")
        {
            vPrompts[4] = "Job  Information";
            vPrompts[5] = "Job No ."; 
        }
        else
        {
            vPrompts[4] = "Job Information";
            vPrompts[5] = "Job No.";
        }
        vPrompts[6] = "Wave No.";
        vPrompts[7] = "(FST DT:";
        vPrompts[8] = "- FEnd DT:";
        vPrompts[9] = "Task No.";
        vPrompts[10] = "Chain Information";
        vPrompts[11] = "Chain No.";
        vPrompts[12] = "Store Information";
        vPrompts[13] = "Store No.";
        vPrompts[14] = "Store Name";
        vPrompts[15] = "Address";
        vPrompts[16] = "City";
        vPrompts[17] = "State";
        vPrompts[18] = "Zip";
        vPrompts[19] = "MS Information";
        vPrompts[20] = "MS No.";
        vPrompts[21] = "MS Name";
        vPrompts[22] = "Street";
        vPrompts[23] = "City";
        vPrompts[24] = "State";
        vPrompts[25] = "Zip";
        vPrompts[26] = "Phone No.";
        vPrompts[27] = "Email Address";
        vPrompts[28] = "Visit Date:";
        vPrompts[29] = "Back";
        vPrompts[30]="Please enter a valid Time In";
		vPrompts[31]="For Time In: Hour must be numeric";
		vPrompts[32]="For Time In: Hour must be between 1 and 12.";
		vPrompts[33]="For Time In: Minute must be numeric";
		vPrompts[34]="For Time In: Minutes must be between 0 and 59.";
		vPrompts[35]="Please enter a valid Time out";
		vPrompts[36]="For Time Out: Hour must be numeric";
		vPrompts[37]="For Time Out: Hour must be between 1 and 12.";
		vPrompts[38]="For Time Out: Minute must be numeric";
		vPrompts[39]="For Time Out: Minutes must be between 0 and 59.";
		vPrompts[40]="Night visits not allowed for this Job. Timeout`s Hours has to be bigger than Timein";
		vPrompts[41]="Night visits not allowed for this Job. Timeout`s Hours has to be bigger than Timein";
		vPrompts[42]="Timeout`s Hours has to be bigger than Timein";
		vPrompts[43]="Please answer the question:  Did your visit extend past midnight?";
		vPrompts[44]="Timeout`s Hours has to be bigger than Timein";
		vPrompts[45]="Timeout`s Minutes has to be bigger than Timein";
		vPrompts[46]="Timeout can not be the same as Timein";
		vPrompts[47]="Your visit time has extended past midnight. Please answer the question as YES or change your time in and out.";
		vPrompts[48]="This is not a over night visit.";
		vPrompts[49]="Timeout`s Minute has to be bigger than Timein";
		vPrompts[50]="Timeout can not be the same as Timein";
		vPrompts[51]="Please enter valid mileage";
		vPrompts[52]="Please enter a valid drive time";
		vPrompts[53]="Please answer the question: Did you use your HandHeld Unit?";
		vPrompts[54]="Please answer the question: Do you have to return to the store to complete the Store Visit?";
		vPrompts[55]="Time In hours can not have a period.";
		vPrompts[56]="Time In minutes can not have a period.";
		vPrompts[57]="Time Out hours can not have a period.";
		vPrompts[58]="Time Out minutes can not have a period.";
        vPrompts[59]="Please enter a valid Visit Date";
		vPrompts[60]="Please answer the question: Have you reported your EShelf information?";
		vPrompts[61]="Please answer the question: Do you have OOS to report for this job/wave/task?";
		vPrompts[62]="You must report OOS for this Job, Wave, Task using the Product Data Collection System.";
		vPrompts[63]="Please answer the question: Do you have OOS to report?.";
		vPrompts[64]="Please answer the question: Do you have credits to report?.";
		vPrompts[65]="Please answer the question: Do you have overstocks to report?.";
		vPrompts[66]="Please answer the question: Do you have Inventory data to report?";
	    vPrompts[67]="Please answer the question: Do you have Product Count data to report?";
        vPrompts[68]="Please answer the question: Do you have Mandatory Returns to report?";
        if (StrPromptcheck == "Y")
        {
            vPrompts[69] = "The Visit date entered is invalid for this Job,Wave and Task .";
        }
        else
        {
            vPrompts[69] = "The Visit date entered is invalid for this Job,Wave and Task.";
        }
        vPrompts[70]="The Visit date greater than Today`s date";
        vPrompts[71]="Please enter Manager`s last name.";
        vPrompts[72]= "Please confirm the above information before moving on.";
        vPrompts[73]= "You must report your product data into the Product Data Collection system.";
        vPrompts[74]= "Note:";
        vPrompts[75]= "AM";
        vPrompts[76]= "PM";
        vPrompts[77]="You can not enter zero visit miles if your drive time is greater than zero.";
        vPrompts[78] = "You can not enter zero drive time if your visit miles are greater than zero.";
        vPrompts[79] = "The Visit date you entered was already used. Please go back and verify your visit date.";
        vPrompts[80] = @"Photo\Video Upload";
        vPrompts[81] = @"To submit digital photos please continue on to Photo\Video Upload.";
        vPrompts[82] = "Product Data Collection";
        vPrompts[83] = "Assembly Data Collection";
        vPrompts[84] = "Video Upload";
        vPrompts[85] = "Photo Upload";
        vPrompts[86] = "Are you sure the time entered is valid? Click Ok to continue, Cancel to adjust the Time In or Time Out.";
        vPrompts[87] = "Message Date";
        vPrompts[88] = "Message Title";
        vPrompts[89] = "Message Text";
        vPrompts[90] = "File";
        vPrompts[91] = "Click to download a file";
        vPrompts[92] = "View";
        vPrompts[93] = "For Time In: Hour must be between 0 and 23.";
        vPrompts[94] = "For Time Out: Hour must be between 0 and 23.";
        vPrompts[95] = "The entered in-store Time is overlapping with the time reported for a job:";
        vPrompts[96] = "Are you sure you want to continue?";
        vPrompts[97] = "Ok to save/Cancel to change the time.";
       
       ptAppTranslation.DoArrayPromptTranslation(vPrompts);
   

    }
    private DataTable GetSystemRules()
    {
        DataTable appDT = new DataTable();
        string[] VRule;
        VRule = new string[7];
        VRule[0] = "Name Format";
        VRule[1] = "New Date Format";
        VRule[2] = "Collect Mobile Email";
        VRule[3] = "SPAR Logo";
        VRule[4] = "SPAR Copyright";
        VRule[5] = "Address Format";
        VRule[6] = "Hour Format";
        appDT = AppSysRules.Get_RuleValue_ByDescAsDataTable(VRule, WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection);
        return appDT;
    }

#endregion
#region Procedures
    //************* Function to get the JWT info
    private DataTable Get_CFJWTValidate_Universal()
    {
        Int32 iTempMerchNo = 0;
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempChain_No = 0;
        Int32 iTempStore_No = 0;
        Int32 iTempPOutOfStock_no = 0;


        iTempMerchNo = AppUtils.ConvertToInteger32(Str_Merch_no, 0);
        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempChain_No = AppUtils.ConvertToInteger32(Chain_No, 0);
        iTempStore_No = AppUtils.ConvertToInteger32(Store_No, 0);
        iTempPOutOfStock_no = AppUtils.ConvertToInteger32(OutOfStock_no, 0);

        return AppData.Get_CFJWTValidate_Universal(Lang_id, iTempJob_No, iTempWave_No, iTempTask_No, iTempChain_No, iTempStore_No, PVisit_Date, iTempMerchNo, iTempPOutOfStock_no, StrPTYPE, WebAppClass.CurrentSQLDBConnection);
    }

    //************* Function to get the JWT info
    private DataTable Get_CFJWTValidate()
    {
        Int32 iTempMerchNo = 0;
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempChain_No = 0;
        Int32 iTempStore_No = 0;
        Int32 iTempPOutOfStock_no = 0;

        iTempMerchNo = AppUtils.ConvertToInteger32(Str_Merch_no, 0);
        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempChain_No = AppUtils.ConvertToInteger32(Chain_No, 0);
        iTempStore_No = AppUtils.ConvertToInteger32(Store_No, 0);
        iTempPOutOfStock_no = AppUtils.ConvertToInteger32(OutOfStock_no, 0);

        return AppData.Get_CFJWTValidate(Lang_id, iTempJob_No, iTempWave_No, iTempTask_No, iTempChain_No, iTempStore_No, PVisit_Date, iTempMerchNo, iTempPOutOfStock_no, WebAppClass.CurrentSQLDBConnection);
    }

    private DataTable Get_ManagerMenu()
    {
             return AppData.Get_ManagerTitle(WebAppClass.CurrentSQLDBConnection);
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
    private DataTable Get_Start_time()
    {
        return AppData.Get_Start_timeClass(WebAppClass.CurrentSQLDBConnection);
    }
    //Get_CFMerchCellPhoneInsert
    //Get_CFMerchCellPhoneInsert
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

        return AppData.Get_USP_Photo_QuestionCheck(Lang_id,iTempJob_No, iTempWave_No, iTempTask_No, iTempChain_No, iTempStore_No, iTempMerchNo,Job_Visit_Date,Str_Sv_Panel_id, WebAppClass.CurrentSQLDBConnection);
    }
    
    //CFJWT_Visit_Date_status_MultiVisit
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
    private DataTable Get_CFJWT_MeassgeLinkPhotoCall(Int32 Lang_id, String Job_No, String Wave_No, String Task_No, String Chain_No, String Store_No, String Str_Merch_no)
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

        return AppData.Get_CFJWT_MeassgeLinkPhoto(Lang_id, iTempJob_No, iTempWave_No, iTempTask_No, iTempChain_No, iTempStore_No, iTempMerchNo, WebAppClass.CurrentSQLDBConnection);
    }
#endregion
 


   }
