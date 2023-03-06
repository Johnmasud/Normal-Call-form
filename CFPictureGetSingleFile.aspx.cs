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
using System.Text;

public partial class CFPictureGetSingleFile : System.Web.UI.Page
{
    protected string Job_No, Wave_No, Task_No, Task_Desc, Task_Addtl_Desc, store_id, AddressRule, NameRule, DateRule,Date_input, VarDay, Varmonth, StrYear;
    protected string Chain_No, Store_Chain_Desc, Store_No, Store_Store_Name, Store_Street_Addr, Store_City, Store_State, Store_Zip, Photo_CF_Access;
    protected string CA_merch_no, Str_Merch_no, Merch_First_Name, Merch_Last_Name, Merch_Street_Addr, Merch_Street_Addr2, Merch_City, Merch_State, Merch_Zip, Merch_Phone_No, Merch_Email_Addr;
    protected string Field_Start_Dt, Field_end_Dt, Key_Comp_Dt, DOA_Dt, TodayDate, visit_no, Client_Access_Flag, Pre_Approved_Flag, NewScreenPage;
    protected string Collect_iVR_Time, night_visits, Mileage_flag, Travel_flag, StrFileSave, Job_Visit_Date, Old_Visit_Date, StrGridDates;
    protected string Job_Type, Business_Type_id, Work_Type_id, Work_Type_Desc, Str_Manager_Title, Str_txt_Manager_name, BusRule_CommentBoxFlag;
    protected string Data_Col_Method, overwritetime, All_Data_Received, collect_time_only, Ask_Q_HH_Used, HH_Status_Flag, StrMTYPE, StrLogInMtype, StrPTYPE, StrPromptcheck;
    protected string Collect_Header, Collect_Call_Form, SS_Callform, Prod_Specific, qdef_skippattern, Max_Mx_Per_Store, Max_Visit_Per_Store_Mx, Display_Job_Visit_Date;
    protected string Collect_Store_Mgr_Name, Product_Check_Flag, Ask_EShelf_Question, Call_Form_Type_No, Est_instore_minutes, Business_Rule_Eckerd, Eckerd_Job_Last_question;
    protected string user_id, PhotoButton, Bus_Rule5_Question, Bus_Rule6_Question, Bus_Rule28_Question, Bus_Rule3_Question, Bus_Rule4_Question, Bus_Rule7_Question;
    public string[] vPrompts;
    protected string Str_VisitMonth, Str_visitday, Str_visityear, Str_timein_hrs, Str_timein_min, Str_cmb_timein, Str_timeout_hrs, Str_timeout_min, Str_cmb_timeout, CloudSwitch;
    protected string Str_txt_mileage, Str_txt_drive, Str_rad_q_Past_Midnight, Str_rad_q_HH_Used, Str_rad_q_Ret_store_visit, StrFileUpdatePath, GoLiteDate, Visit_time, Drive_Time_HH, Drive_Time_MM;
    protected string Str_Radio_EShelf, Str_Ask_EShelf_Question, Str_Bus_Rule3_Question, Str_rad_q_BR3, Str_Bus_Rule4_Question, Str_rad_q_BR4, Str_Bus_Rule5_Question,Photo_Q_No, Photo_upc_desc, Photo_q_desc, Photo_Res_desc, Photo_Q_Enable, Photo_q_Res_Val, Photo_Prod_upc;
    protected string Str_rad_q_BR5, Str_Bus_Rule6_Question, Str_rad_q_BR6, Str_Bus_Rule7_Question, Str_rad_q_BR7, Str_Bus_Rule28_Question, Str_rad_q_BR28, Photo_Display_type, Photo_item_desc, Photo_Ans_type, Str_Start_time, Str_Sv_Panel_id, Client_id, PhotoFolderType;
    protected int Back_Slash, Dot, Dash, ShowType, Lang_id;
    public DateTime StrDate;
    private string Str_Request_Method;

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
            Response.Redirect("http://miweb22.sparinc.com/callformdotnet/CFLoginErrorMessage.aspx");
        }
        SPARHeader PageHeader;
        SPARFooter PageFooter;
        SPARBiLingualBar BiLingualBar;
        PageHeader = (SPARHeader)this.Master.FindControl("SPARHeader1");
        PageFooter = (SPARFooter)this.Master.FindControl("SPARFooter1");
        BiLingualBar = (SPARBiLingualBar)this.Master.FindControl("SPARBiLingualBar1");
        WebAppClass = new SPARValues();
        WebAppClass.PageTitle = "";

        ptAppTranslation = new PromptTranslation("CFPictureGetSingleFile.aspx", WebAppClass.PromptsLanguageId.ToString(), WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection, WebAppClass.MultiLanguageCount);
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

    protected void Page_Load(object sender, EventArgs e)
    {

        

                                           // pnl_Upload_Photo.Visible = true;
                                            WebAppClass.Set_MerchforForm(this.Merch_no, Convert.ToString(WebAppClass.MerchNo));
                                           
                                            //****** System Rules
                                            DataTable RuleTab = new DataTable();
                                            RuleTab = GetSystemRules();

                                            AddressRule = RuleTab.Rows[5][2].ToString();
                                            //Response.Write("AddressRule=" + AddressRule);

                                            DateRule = RuleTab.Rows[1][2].ToString();
                                            //Response.Write("DateRule=" + DateRule);

                                            NameRule = RuleTab.Rows[0][2].ToString();
                                            //Response.Write("NameRule=" + NameRule);
                                            
                                          
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
                                            //Response.Write("Date_input=" + Date_input + "<BR>");
                                            //****** Today's date 

                                        //********************* Date Function
                                            DateTime date = DateTime.Now;

                                            StrDate = date;
                                            ShowType = 0;
                                            try
                                            {
                                                StrYear = clsDateFormat.Date_Format(date, ShowType, DateRule, Date_input);
                                            }
                                            catch (Exception ex)
                                            {
                                                throw ex;
                                            }

                                            //Response.Write("StrYear=" + StrYear + "<BR>");

                                            if (!IsPostBack)
                                            {
                                                 DataTable dt10 = Get_Start_time();
                                                 Str_Start_time = dt10.Rows[0][0].ToString().Trim();
                                                //Response.Write("Str_Start_time=" + Str_Start_time);
                                                //Context.Items["UploadStartTime"] = Str_Start_time;
                                                 UploadStartTime.Value = Str_Start_time;
                                            }

                                        //***************************** hidden variables
                                       Lang_id = WebAppClass.LanguageId;
                                       StrMTYPE = WebAppClass.MTYPE;
                                       //Response.Write("StrMTYPE=" + StrMTYPE);

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
                                       if ((StrPTYPE == "E") && (Lang_id == 1))
                                       {
                                           StrPromptcheck = "Y";
                                           LabelJob_no.Text = "Job No .";
                                       }
                                      // Response.Write("StrPromptcheck=" + StrPromptcheck);
                                       //****** Prompts
                                       GetPromptTranslation();

                                       if (Lang_id == 1)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerUsa"];
                                         //  Response.Write("CloudSwitchServerUsa=" + CloudSwitch);
                                       }
                                       if (Lang_id == 2)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerJapan"];
                                          // Response.Write("CloudSwitchServerJapan=" + CloudSwitch);
                                       }
                                       if (Lang_id == 4)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerCanada"];
                                         //  Response.Write("CloudSwitchServerCanada=" + CloudSwitch);
                                       }
                                       if (Lang_id == 5)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerTurkey"];
                                         //  Response.Write("CloudSwitchServerTurkey=" + CloudSwitch);
                                       }
                                       if (Lang_id == 6)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerSouthAfrica"];
                                         //  Response.Write("CloudSwitchServerSouthAfrica=" + CloudSwitch);
                                       }
                                       if (Lang_id == 7)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerIndia"];
                                         //  Response.Write("CloudSwitchServerIndia=" + CloudSwitch);
                                       }
                                       if (Lang_id == 8)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerRomania"];
                                          // Response.Write("CloudSwitchServerRomania=" + CloudSwitch);
                                       }
                                       if (Lang_id == 9)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerUsa"];
                                          // Response.Write("CloudSwitchServerUsa9=" + CloudSwitch);
                                       }
                                       if (Lang_id == 10)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerChina"];
                                          // Response.Write("CloudSwitchServerChina=" + CloudSwitch);
                                       }
                                       if (Lang_id == 11)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerLithuania"];
                                           //Response.Write("CloudSwitchServerLithuania=" + CloudSwitch);
                                       }
                                       if (Lang_id == 12)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerAustralia"];
                                          // Response.Write("CloudSwitchServerAustralia=" + CloudSwitch);
                                       }
                                       if (Lang_id == 13)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerUsa"];
                                          // Response.Write("CloudSwitchServerUsa13=" + CloudSwitch);
                                       }
                                       if (Lang_id == 15)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerChina"];
                                          // Response.Write("CloudSwitchServerChina=" + CloudSwitch);
                                       }
                                       if (Lang_id == 16)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerMexico"];
                                          // Response.Write("CloudSwitchServerMexico=" + CloudSwitch);
                                       }
                                       if (Lang_id == 17)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerIndia"];
                                         //  Response.Write("CloudSwitchServerIndia=" + CloudSwitch);
                                       }
                                       if (Lang_id == 19)
                                       {
                                           CloudSwitch = ConfigurationManager.AppSettings["CloudSwitchServerBrazil"];
                                          // Response.Write("CloudSwitchServerBrazil=" + CloudSwitch);
                                       }
                                       //Response.Write("<BR> CloudSwitch=" + CloudSwitch + "<BR>");


                                       GoLiteDate = Request.Form["GoLiteDate"];
                                       NewScreenPage = Request.Form["NewScreenPage"];
                                       //Response.Write("NewMerchPage=" + NewMerchPage);

                                        Job_No = Request.Form["Job_No"];
                                        //Response.Write("Job_No=" + Job_No);
                                        Wave_No = Request.Form["Wave_No"];
                                        Task_No = Request.Form["Task_No"];
                                        Task_Desc = Request.Form["Task_Desc"];
                                        Task_Addtl_Desc = Request.Form["Task_Addtl_Desc"];

                                        store_id = Request.Form["store_id"];

                                        Chain_No = Request.Form["Chain_No"];
                                        Store_Chain_Desc = Request.Form["Store_Chain_Desc"];
                                        Store_No = Request.Form["Store_No"];
                                        Store_Store_Name = Request.Form["Store_Store_Name"];
                                        Store_Street_Addr = Request.Form["Store_Street_Addr"];
                                        Store_City = Request.Form["Store_City"];
                                        Store_State = Request.Form["Store_State"];
                                        Store_Zip = Request.Form["Store_Zip"];

                                        CA_merch_no = Request.Form["CA_merch_no"];
                                        Str_Merch_no = Request.Form["Str_Merch_no"];
                                        Merch_First_Name = Request.Form["Merch_First_Name"];
                                        Merch_Last_Name = Request.Form["Merch_Last_Name"];
                                        Merch_Street_Addr = Request.Form["Merch_Street_Addr"];
                                        Merch_Street_Addr2 = Request.Form["Merch_Street_Addr2"];
                                        Merch_City = Request.Form["Merch_City"];
                                        Merch_State = Request.Form["Merch_State"];
                                        Merch_Zip = Request.Form["Merch_Zip"];
                                        Merch_Phone_No = Request.Form["Merch_Phone_No"];
                                        Merch_Email_Addr = Request.Form["Merch_Email_Addr"];


                                        Field_Start_Dt = Request.Form["Field_Start_Dt"];
                                        Field_end_Dt = Request.Form["Field_end_Dt"];
                                        Key_Comp_Dt = Request.Form["Key_Comp_Dt"];
                                        DOA_Dt = Request.Form["DOA_Dt"];

                                        TodayDate = Request.Form["TodayDate"];

                                        visit_no = Request.Form["visit_no"];

                                        Collect_iVR_Time = Request.Form["Collect_iVR_Time"];
                                        night_visits = Request.Form["night_visits"];
                                        Mileage_flag = Request.Form["Mileage_flag"];
                                        Travel_flag = Request.Form["Travel_flag"];

                                        Job_Type = Request.Form["Job_Type"];
                                        Business_Type_id = Request.Form["Business_Type_id"];

                                        Work_Type_id = Request.Form["Work_Type_id"];
                                        Work_Type_Desc = Request.Form["Work_Type_Desc"];

                                        Data_Col_Method = Request.Form["Data_Col_Method"];
                                        overwritetime = Request.Form["overwritetime"];
                                        All_Data_Received = Request.Form["All_Data_Received"];
                                        collect_time_only = Request.Form["collect_time_only"];
                                        Ask_Q_HH_Used = Request.Form["Ask_Q_HH_Used"];
                                        HH_Status_Flag = Request.Form["HH_Status_Flag"];

                                        Collect_Header = Request.Form["Collect_Header"];
                                        Collect_Call_Form = Request.Form["Collect_Call_Form"];

                                        SS_Callform = Request.Form["SS_Callform"];
                                        Prod_Specific = Request.Form["Prod_Specific"];
                                        qdef_skippattern = Request.Form["qdef_skippattern"];

                                        Max_Mx_Per_Store = Request.Form["Max_Mx_Per_Store"];
                                        Max_Visit_Per_Store_Mx = Request.Form["Max_Visit_Per_Store_Mx"];

                                        Collect_Store_Mgr_Name = Request.Form["Collect_Store_Mgr_Name"];

                                        Product_Check_Flag = Request.Form["Product_Check_Flag"];

                                        Ask_EShelf_Question = Request.Form["Ask_EShelf_Question"];

                                        Call_Form_Type_No = Request.Form["Call_Form_Type_No"];

                                        Est_instore_minutes = Request.Form["Est_instore_minutes"];
                                        Business_Rule_Eckerd = Request.Form["Business_Rule_Eckerd"];
                                        Eckerd_Job_Last_question = Request.Form["Eckerd_Job_Last_question"];

                                        user_id = Request.Form["user_id"];
                                        PhotoButton = Request.Form["PhotoButton"];
                                        Bus_Rule5_Question = Request.Form["Bus_Rule5_Question"];
                                        Bus_Rule6_Question = Request.Form["Bus_Rule6_Question"];
                                        Bus_Rule28_Question = Request.Form["Bus_Rule28_Question"];
                                        Bus_Rule3_Question = Request.Form["Bus_Rule3_Question"];
                                        Bus_Rule4_Question = Request.Form["Bus_Rule4_Question"];
                                      //  Response.Write("Bus_Rule4_Question=" + Bus_Rule4_Question);
                                        Bus_Rule7_Question = Request.Form["Bus_Rule7_Question"];

                                        //************************ From the page CFJWTValidate.asp
                                        // visit date 
                                        Str_VisitMonth = Request.Form["Str_VisitMonth"];
                                        //Response.Write("Str_VisitMonth=" + Str_VisitMonth + "<BR>");

                                        Str_visitday = Request.Form["Str_visitday"];
                                       // Response.Write("Str_visitday=" + Str_visitday + "<BR>");

                                        Str_visityear = Request.Form["Str_visityear"];
                                        //Response.Write("Str_visityear=" + Str_visityear + "<BR>");

                                        //Time in and out     
                                        Str_timein_hrs = Request.Form["Str_timein_hrs"];
                                        //Response.Write("Str_timein_hrs=" + Str_timein_hrs + "<BR>");
                                        Str_timein_min = Request.Form["Str_timein_min"];
                                        //Response.Write("Str_timein_min=" + Str_timein_min + "<BR>");
                                        Str_cmb_timein = Request.Form["Str_cmb_timein"];
                                        //Response.Write("Str_cmb_timein=" + Str_cmb_timein + "<BR>");

                                        Str_timeout_hrs = Request.Form["Str_timeout_hrs"];
                                        //Response.Write("Str_timeout_hrs=" + Str_timeout_hrs + "<BR>");
                                        Str_timeout_min = Request.Form["Str_timeout_min"];
                                       // Response.Write("Str_timeout_min=" + Str_timeout_min + "<BR>");
                                        Str_cmb_timeout = Request.Form["Str_cmb_timeout"];
                                        //Response.Write("Str_cmb_timeout=" + Str_cmb_timeout + "<BR>");

                                        // mileage		

                                        Str_txt_mileage = Request.Form["Str_txt_mileage"];
                                       // Response.Write("Str_txt_mileage=" + Str_txt_mileage + "<BR>");

                                        //drive		
                                        Str_txt_drive = Request.Form["Str_txt_drive"];
                                       // Response.Write("Str_txt_drive=" + Str_txt_drive + "<BR>");

                                        //Time Question

                                        Str_rad_q_Past_Midnight = Request.Form["Str_rad_q_Past_Midnight"];
                                        //Response.Write("Str_rad_q_Past_Midnight=" + Str_rad_q_Past_Midnight + "<BR>");

                                        //Hand Held Question

                                        Str_rad_q_HH_Used = Request.Form["Str_rad_q_HH_Used"];
                                        //Response.Write("Str_rad_q_HH_Used=" + Str_rad_q_HH_Used + "<BR>");

                                        //Time Store Visit

                                        Str_rad_q_Ret_store_visit = Request.Form["Str_rad_q_Ret_store_visit"];
                                        //Response.Write("Str_rad_q_Ret_store_visit=" + Str_rad_q_Ret_store_visit + "<BR>");

                                        //For EShelf 	

                                        Str_Radio_EShelf = Request.Form["Str_Radio_EShelf"];
                                        //Response.Write("Str_Radio_EShelf=" + Str_Radio_EShelf + "<BR>");

                                        Str_Ask_EShelf_Question = Request.Form["Str_Ask_EShelf_Question"];
                                        //Response.Write("Str_Ask_EShelf_Question=" + Str_Ask_EShelf_Question + "<BR>");

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
                                       // Response.Write("Str_rad_q_BR5=" + Str_rad_q_BR5 + "<BR>");

                                        Str_Bus_Rule6_Question = Request.Form["Str_Bus_Rule6_Question"];
                                        //Response.Write("Str_Bus_Rule6_Question=" + Str_Bus_Rule6_Question + "<BR>");
                                        Str_rad_q_BR6 = Request.Form["Str_rad_q_BR6"];
                                       // Response.Write("Str_rad_q_BR6=" + Str_rad_q_BR6 + "<BR>");

                                        Str_Bus_Rule7_Question = Request.Form["Str_Bus_Rule7_Question"];
                                        //Response.Write("Str_Bus_Rule7_Question=" + Str_Bus_Rule7_Question + "<BR>");
                                        Str_rad_q_BR7 = Request.Form["Str_rad_q_BR7"];
                                       // Response.Write("Str_rad_q_BR7=" + Str_rad_q_BR7 + "<BR>");

                                        Str_Bus_Rule28_Question = Request.Form["Str_Bus_Rule28_Question"];
                                        //Response.Write("Str_Bus_Rule28_Question=" + Str_Bus_Rule28_Question + "<BR>");
                                        Str_rad_q_BR28 = Request.Form["Str_rad_q_BR28"];
                                       // Response.Write("Str_rad_q_BR28=" + Str_rad_q_BR28 + "<BR>");

                                        Str_Manager_Title = Request.Form["Str_Manager_Title"];
                                        //Response.Write("Str_Manager_Title=" + Str_Manager_Title + "<BR>");
                                        Str_txt_Manager_name = Request.Form["Str_txt_Manager_name"];
                                        //Response.Write("Str_txt_Manager_name=" + Str_txt_Manager_name + "<BR>");
                                        //Response.Write("Str_rad_q_BR28=" + Str_rad_q_BR28 + "<BR>");

                                        StrFileSave = Request.Form["StrFileSave"];
                                      //  Response.Write("StrFileSave=" + StrFileSave + "<BR>");

                                        Client_Access_Flag = Request.Form["Client_Access_Flag"];

                                        Pre_Approved_Flag = Request.Form["Pre_Approved_Flag"];

                                        Job_Visit_Date = Request.Form["Job_Visit_Date"];
                                        Photo_CF_Access = Request.Form["Photo_CF_Access"];
                                        if (Job_Visit_Date == "0")
                                        {
                                            Label10.Text = "";
                                            Display_Job_Visit_Date = "";
                                           // Response.Write("Job_Visit_Date=" + Job_Visit_Date + "<BR>");
                                        }
                                        else
                                        {
                                            Display_Job_Visit_Date = ":" + Job_Visit_Date;
                                        }
                                        Old_Visit_Date = Request.Form["Old_Visit_Date"];
                                        //Response.Write("Old_Visit_Date=" + Old_Visit_Date);
                                        StrGridDates = Request.Form["StrGridDates"];
                                        //Response.Write("StrGridDates=" + StrGridDates);
                                        Str_Sv_Panel_id = Request.Form["Str_Sv_Panel_id"];
                                        Client_id = Request.Form["Client_id"];
                                        PhotoFolderType = Request.Form["PhotoFolderType"];
                                        BusRule_CommentBoxFlag = Request.Form["BusRule_CommentBoxFlag"];
                                        Visit_time = Request.Form["Visit_time"];
                                        // Response.Write("Visit_time=" + Visit_time);
                                        Drive_Time_HH = Request.Form["Drive_Time_HH"];
                                        // Response.Write("Drive_Time_HH=" + Drive_Time_HH);
                                        Drive_Time_MM = Request.Form["Drive_Time_MM"];


                                    //****************************** Photo name for rotation ******************************

                                        int JsFileYear, JsFileMonth, JsFileDay, JsFileHour, JsFileMinute, JsFileSecond, JsFileMillisecond;
                                        string Picture_Name, JsSec, JsMin, JsHou, JsMillisec, JsYear, JsMonth, JsDay;

                                        JsFileYear = System.DateTime.Now.Year;
                                        JsFileMonth = System.DateTime.Now.Month;
                                        JsFileDay = System.DateTime.Now.Day;
                                        JsFileHour = System.DateTime.Now.Hour;
                                        JsFileMinute = System.DateTime.Now.Minute;
                                        JsFileSecond = System.DateTime.Now.Second;
                                        JsFileMillisecond = System.DateTime.Now.Millisecond;

                                        JsYear = Convert.ToString(JsFileYear);
                                        JsMonth = Convert.ToString(JsFileMonth);
                                        JsDay = Convert.ToString(JsFileDay);

                                        JsSec = Convert.ToString(JsFileSecond);
                                        JsMin = Convert.ToString(JsFileMinute);
                                        JsHou = Convert.ToString(JsFileHour);
                                        JsMillisec = Convert.ToString(JsFileMillisecond);



                                        if (Convert.ToString(JsFileSecond).Length == 1)
                                        {
                                            JsSec = "0" + JsSec + "";
                                        }
                                        if (Convert.ToString(JsFileMinute).Length == 1)
                                        {
                                            JsMin = "0" + JsMin + "";
                                        }
                                        if (Convert.ToString(JsFileHour).Length == 1)
                                        {
                                            JsHou = "0" + JsHou + "";
                                        }

                                        Picture_Name = "" + Job_No.Trim() + "" + Wave_No.Trim() + "" + Task_No.Trim() + "" + Str_Merch_no.Trim() + "" + store_id.Trim() + "" + JsYear.Trim() + "" + JsMonth.Trim() + "" + JsDay.Trim() + "" + JsHou.Trim() + "" + JsMin.Trim() + "" + JsSec.Trim() + "" + JsMillisec.Trim() + "JS";

                                        JavaFileRotate.Value = Picture_Name;

                                        //rad_q_Ret_store_visit.Attributes.Add("onClick", "CollectManagerInfo()");
                                        txt_visitmonth.Attributes.Add("onkeypress", "return DateNumberOnly(event)");
                                        txt_visitday.Attributes.Add("onkeypress", "return DateNumberOnly(event)");
                                        txt_visityear.Attributes.Add("onkeypress", "return DateNumberOnly(event)");

                                        //Execute the photo check by question procedure
                                        Photo_Q_No = Request.Form["Photo_Q_No"];
                                        Photo_q_Res_Val = Request.Form["Photo_q_Res_Val"];
                                        Photo_Prod_upc = Request.Form["Photo_Prod_upc"];
                                        Photo_upc_desc = Request.Form["Photo_upc_desc"];
                                        Photo_q_desc = Request.Form["Photo_q_desc"];
                                        Photo_Res_desc = Request.Form["Photo_Res_desc"];

                                        //******************Get the Display Text for photo by Q
                                        DataTable dt1 = Get_CFJWT_PhotoByQ_DisplayText(Lang_id, Job_No, Wave_No, Task_No, Str_Merch_no, Photo_Q_No, Photo_q_Res_Val, Photo_Prod_upc);
                                        if (string.IsNullOrEmpty(Photo_Q_No) == false)
                                        {
                                            if (Photo_Q_No != "NULL")
                                            {
                                                Photo_By_Q_Message.Text = vPrompts[11];
                                            }
                                        }
                                        StringBuilder HTMLText = new StringBuilder();
                                        string DisplayOnce;
                                        DisplayOnce = "";
                                        if (string.IsNullOrEmpty(Photo_Q_No) == false)
                                        {
                                            if (Photo_Q_No != "NULL")
                                            {

                                                foreach (DataRow PDRow in dt1.Rows)
                                                {
                                                    Photo_Display_type = Convert.ToString(PDRow["Display_type"]);

                                                    Photo_item_desc = Convert.ToString(PDRow["item_desc"]);
                                                    Photo_Ans_type = Convert.ToString(PDRow["Ans_type"]);
                                                    Response.Write("Photo_Display_type=" + Photo_Display_type);
                                                    Response.Write("Photo_item_desc=" + Photo_item_desc);
                                                    Response.Write("Photo_Ans_type=" + Photo_Ans_type);

                                                    // Display_QP_Info
                                                    HTMLText.Append("<Table id='Table5'  width='100%' style='width:100%;'>");
                                                    if (Photo_Display_type == "1")
                                                    {
                                                        HTMLText.Append("<tr>");
                                                        HTMLText.Append("<td width='10%' class='reportCriteriaHeader' >" + vPrompts[8] + "");
                                                        HTMLText.Append("</td>");
                                                        HTMLText.Append(" <td  width='90%' class='selectionCriteriaItem' >:" + Photo_item_desc + "");
                                                        HTMLText.Append("</td>");
                                                        HTMLText.Append("</tr>");
                                                        Photo_upc_desc = Photo_item_desc;

                                                    }
                                                    if (Photo_Display_type == "2")
                                                    {
                                                        HTMLText.Append("<tr>");
                                                        HTMLText.Append("<td width='10%' class='reportCriteriaHeader' >" + vPrompts[9] + "");
                                                        HTMLText.Append("</td>");
                                                        HTMLText.Append(" <td  width='90%' class='selectionCriteriaItem' >:" + Photo_item_desc + "");
                                                        HTMLText.Append("</td>");
                                                        HTMLText.Append("</tr>");
                                                        Photo_q_desc = Photo_item_desc;
                                                    }
                                                    if (Photo_Display_type == "3")
                                                    {

                                                        HTMLText.Append("<tr>");
                                                        if (DisplayOnce == "")
                                                        {
                                                            HTMLText.Append("<td width='10%' class='reportCriteriaHeader' >" + vPrompts[10] + "");
                                                            HTMLText.Append("</td>");
                                                            DisplayOnce = "1";
                                                        }
                                                        else
                                                        {
                                                            HTMLText.Append("<td width='10%' class='reportCriteriaHeader' >");
                                                            HTMLText.Append("</td>");
                                                        }
                                                        HTMLText.Append(" <td  width='90%' class='selectionCriteriaItem' >:" + Photo_item_desc + "");
                                                        HTMLText.Append("</td>");
                                                        HTMLText.Append("</tr>");
                                                        HTMLText.Append("</Table>");
                                                        Photo_Res_desc = Photo_Res_desc + Photo_item_desc + "|";

                                                    }
                                                    Display_QP_Info.Text = HTMLText.ToString();
                                                }//foreach
                                            }//Photo_Q_No != "NULL"
                                        }

                                        Photo_Q_Enable = Request.Form["Photo_Q_Enable"];
                                       //Response.Write("Photo_Q_Enable=" + Photo_Q_Enable + "<BR>");
                                        //Response.Write("Photo_q_Res_Val=" + Photo_q_Res_Val + "<BR>");
                                        //Response.Write("Photo_Prod_upc=" + Photo_Prod_upc + "<BR>");



}
#region SystemPromptandRule
    private void GetPromptTranslation()
    {
        vPrompts = new string[12];
        vPrompts[0] = "Please enter a valid visit date";
       
        if (StrPromptcheck == "Y")
        {
            vPrompts[1] = "The Visit date entered is invalid for this Job,Wave and Task .";
        }
        else
        {
            vPrompts[1] = "The Visit date entered is invalid for this Job,Wave and Task.";
        }
        vPrompts[2] = "The Visit date greater than Today`s date";
        vPrompts[3] = "You can not enter more than 255 charaters in the Comment box.";
        vPrompts[4] = "Please enter a Picture path to upload.";
        vPrompts[5] = "Picture has to be JPG file.";
        vPrompts[6] = "Picture has to be JPEG,JPG or GIF file.";
        vPrompts[7] = "Your file exceeds the maximum size limit.";
        vPrompts[8] = "Item";
        vPrompts[9] = "Question";
        vPrompts[10] = "Response";
        vPrompts[11] = "Please upload your photo for the following:";

        
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
private DataTable Get_Start_time()
{
    return AppData.Get_Start_timeClass(WebAppClass.CurrentSQLDBConnection);
}
private DataTable Get_CFJWT_PhotoByQ_DisplayText(Int32 Lang_id, String Job_No, String Wave_No, String Task_No, String Str_Merch_no, String Photo_Q_No, String Photo_q_Res_Val, String Photo_Prod_upc)
{
    Int32 iTempMerchNo = 0;
    Int32 iTempJob_No = 0;
    Int32 iTempWave_No = 0;
    Int32 iTempTask_No = 0;



    iTempMerchNo = AppUtils.ConvertToInteger32(Str_Merch_no, 0);
    iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
    iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
    iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);

    return AppData.App_CFJWT_ByQ_DisplayText(Lang_id, iTempJob_No, iTempWave_No, iTempTask_No, iTempMerchNo, Photo_Q_No, Photo_q_Res_Val, Photo_Prod_upc, WebAppClass.CurrentSQLDBConnection);

}
 #endregion


#region methods
    private string Date_Format(DateTime StrDate, int ShowType, string DateRule, string Date_input)
    {


        string[] ArrayDateRuleF;
        int f, StrMonth, StrDay;
        string StrTodayDate, StrTodayDate2;
        StrTodayDate = "";
        StrTodayDate2 = "";
        ArrayDateRuleF = new string[3];
        ArrayDateRuleF = DateRule.Split(Date_input.ToCharArray());
        //DateRule
        for (f = 0; f < ArrayDateRuleF.Length; f++)
        {

            if (ArrayDateRuleF[f].ToUpper() == ("mm").ToUpper())
            {
                StrMonth = StrDate.Month;
                StrTodayDate = StrTodayDate + "" + StrMonth;
            }
            if (ArrayDateRuleF[f].ToUpper() == ("dd").ToUpper())
            {
                StrDay = StrDate.Day;
                StrTodayDate = StrTodayDate + "" + StrDay;
            }
            if (ArrayDateRuleF[f].ToUpper() == ("yyyy").ToUpper())
            {
                StrYear = StrDate.Year.ToString();

                StrTodayDate = StrTodayDate + "" + StrYear;
            }
            if (ArrayDateRuleF[f].ToUpper() == ("yy").ToUpper())
            {
                StrYear = StrDate.Year.ToString();
                StrYear = StrYear.Substring(2, 2);
                StrTodayDate = StrTodayDate + "" + StrYear;
            }

            if (f != 2)
            {
                StrTodayDate = StrTodayDate + "" + "" + Date_input + "";
            }
        }
        //Strtime="";
        if (ShowType == 0)
        {
            StrTodayDate2 = StrYear;
        }
        //if (ShowType==1) 
        //{
        //    Strtime = StrDate.FormatDateTime(StrDate, 3);
        //        StrTodayDate2 =StrTodayDate + " " + Strtime;
        //        //Response.Write "StrTodayDate2=" & StrTodayDate2 & "<BR>"
        //}
        if (ShowType == 2)
        {
            StrTodayDate2 = StrTodayDate;
        }

        //'Response.Write "StrTodayDate2=" & StrTodayDate2 & "<BR>"		
        return StrTodayDate2;
        //return (int)returnVal;
    }
    


#endregion
  
    protected void Button2_Click(object sender, EventArgs e)
    {

        int FileLimitSize;
        FileLimitSize = 4718592;
        if (Lang_id == 1)
        {
            FileLimitSize = 3145728;
        }
        else
        {
            FileLimitSize = 4718592;
        }


          int FileLen = SingleUpload.FileBytes.Length;
          // Response.Write("FileLen=" + FileLen);

        // if (SingleUpload.FileBytes.Length > 4718592)
          if (SingleUpload.FileBytes.Length > FileLimitSize)
         {


             //string javaScript = "<script language=JavaScript>\n" +
             //                    "alert('" + vPrompts[7] + "');\n" +
             //                    "</script>";

            // ClientScript.RegisterStartupScript(GetType(), "Button1_ClickScript", javaScript);

                         this.LblMessage.Text = vPrompts[7];
                          modalMessage.Show();

             return;
         }
         else
         {
                    //Button b = (Button)sender;
                    //b.Enabled = false;
                     //UploadSinglePhoto.Enabled = false;
                    //UploadSinglePhoto.Enabled = true;

                     //Button2. = false;
                     //pnl_Upload_Photo.Visible = false;
                   string OrigioalFile;
                   int StrFileYear, StrFileMonth, StrFileDay, StrFileHour, StrFileMinute, StrFileSecond, StrFileMillisecond;
                   string Picture_Name, StrSec, StrMin, StrHou, StrMillisec, StrYear, StrMonth, StrDay;
                   string strPath, StrFileNames, StrNewPhotoName, TestJob_No;

                   //TestJob_No = Request.Form["Job_No"];
                   //Response.Write("TestJob_No=" + TestJob_No);
                   if (CloudSwitch == "Y")
                   {
                       StrFileUpdatePath = ConfigurationManager.AppSettings["FileUpdatePathfsx"];
                   }
                   else
                   {

                       StrFileUpdatePath = ConfigurationManager.AppSettings["FileUpdatePath"];
                       //Response.Write("StrFileUpdatePath=" + StrFileUpdatePath);
                   }
                   StrFileUpdatePath = StrFileUpdatePath + "sparEyesPic" + Convert.ToString(Lang_id) + "\\\\update\\\\";
                   //Response.Write("StrFileUpdatePath=" + StrFileUpdatePath + "<BR>");

                   StrFileYear = System.DateTime.Now.Year;
                   StrFileMonth = System.DateTime.Now.Month;
                   StrFileDay = System.DateTime.Now.Day;
                   StrFileHour = System.DateTime.Now.Hour;
                   StrFileMinute = System.DateTime.Now.Minute;
                   StrFileSecond = System.DateTime.Now.Second;
                   StrFileMillisecond = System.DateTime.Now.Millisecond;

                   StrYear = Convert.ToString(StrFileYear);
                   StrMonth = Convert.ToString(StrFileMonth);
                   StrDay = Convert.ToString(StrFileDay);

                   StrSec = Convert.ToString(StrFileSecond);
                   StrMin = Convert.ToString(StrFileMinute);
                   StrHou = Convert.ToString(StrFileHour);
                   StrMillisec = Convert.ToString(StrFileMillisecond);



                   if (Convert.ToString(StrFileSecond).Length == 1)
                   {
                       StrSec = "0" + StrSec + "";
                   }
                   if (Convert.ToString(StrFileMinute).Length == 1)
                   {
                       StrMin = "0" + StrMin + "";
                   }
                   if (Convert.ToString(StrFileHour).Length == 1)
                   {
                       StrHou = "0" + StrHou + "";
                   }

                   Picture_Name = "" + Job_No.Trim() + "" + Wave_No.Trim() + "" + Task_No.Trim() + "" + store_id.Trim() + "" + Str_Merch_no.Trim() + "" + StrYear.Trim() + "" + StrMonth.Trim() + "" + StrDay.Trim() + "" + StrHou.Trim() + "" + StrMin.Trim() + "" + StrSec.Trim() + "" + StrMillisec.Trim() + "";
                   //Picture_Name = "999920103213294724999992011109091027234";
                    //Response.Write("test111111111111111111111111<BR>");
                    if (SingleUpload.HasFile)
                    {
                        //DataTable dt10 = Get_Start_time();
                       // Str_Start_time = dt10.Rows[0][0].ToString().Trim();
                        //Response.Write("Str_Start_time=" + Str_Start_time);
                        //Context.Items["UploadStartTime"] = Str_Start_time;

                        string fileName = Server.HtmlEncode(SingleUpload.FileName);
                        //fileName = "gfghfghfgh.jpg";
                       //Response.Write("fileName=" + fileName);
                       // fileName = "7543984793847583475" + ".jpg";
                        //OrigioalFile = "C:\\Photo\\Update\\" + Picture_Name + ".jpg";
                     
                        OrigioalFile = "" + StrFileUpdatePath + "" + Picture_Name + ".jpg";

                     
                            //Response.Write("OrigioalFile=" + OrigioalFile);
                            SingleUpload.SaveAs(OrigioalFile);
                            //Response.Write(Strhidden);
                            savePath.Value = OrigioalFile;
                            //StrFileSave.Value = OrigioalFile;
                            //HtmlInputHidden hiddentest = (HtmlInputHidden)Page.FindControl("ctl00$ContentPlaceHolder1$hiddentest");
                            //***** photo start time
                          


                            Context.Items["OriginalFile"] = OrigioalFile;
                            Context.Items["UserUploadFile"] = fileName;
                         Server.Transfer("CFPictureFileDisplay.aspx", true);
                     
                      
                    }
           }//end of file size
    }
}
