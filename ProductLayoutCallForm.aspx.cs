using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPAR.Tools.Security;
using SPAR.Tools.MasterControls;
using SPAR.Tools.Utils;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI.HtmlControls;

public partial class ProductLayoutCallForm : System.Web.UI.Page
{
    protected string user_id, Email_Active_Flag, Str_Merch_no, Job_No, Wave_No, Task_No, Chain_No, Store_No,store_id, txt_EmailAdd, txt_Mobile_Email, POutOfStock_no, Error_Message, Error_Flag, HTMLHeader_info, Collect_Mobile_Email, AddressRule, NameRule, DateRule;
    protected int Error_Message_Flag, BusinessQuestion_Flag, OutOfStock_no, Back_Slash, Dot, Dash, ShowType, Lang_id;
    protected string Store_Chain_Desc, Store_Store_Name, Store_Street_Addr, Store_City, Store_State, Store_Zip, Data_Required, MeasurementValue, Decimal_Point, MeasurementDesc,Timeq_desc;
    protected string PMerch_no, CA_merch_no, Merch_First_Name, Merch_Last_Name, Merch_Street_Addr, Merch_Street_Addr2, EnterVisitDate, ProdAnsForNextPage, CallFormEnded;
    protected string Merch_City, Merch_State, Merch_Zip, Merch_Phone_No, Merch_Email_Addr, Task_Desc, Task_Addtl_Desc, CellPhoneNo, Str_Back_RTSAnswers, NewScreenPage;
    protected string Field_Start_Dt, Field_end_Dt, Key_Comp_Dt, DOA_Dt, Job_Type, Business_Type_id, Work_Type_id, Work_Type_Desc, Max_Mx_Per_Store, CFEnd_SelectedProduct, MoveToNextProdCheck;
    protected string Max_Visit_Per_Store_Mx, visit_no, Collect_iVR_Time, night_visits, Mileage_flag, Travel_flag, Data_Col_Method, StrRTSAnswers, AnswersAllFromGrid, AnswersForMenuColor, ProductElementAll, Array_Mandatory_products, DisplayAnswerForGridCF;
    protected string All_Data_Received, qdef_skippattern, Collect_Header, Collect_Call_Form, SS_Callform, Prod_Specific, overwritetime, Prod_UPC;
    protected string collect_time_only, Ask_Q_HH_Used, HH_Status_Flag, Collect_Store_Mgr_Name, Product_Check_Flag, Ask_EShelf_Question, Product_Type, Compare_Q_No, Compare_Q_ans_type, Compare_q_list, Compare_q_Hidden_var, Compare_q_status;
    protected string Call_Form_Type_No, Est_instore_minutes, Business_Rule_Eckerd, Eckerd_Job_Last_question, Bus_Rule22_Photo, ArrayEleSubmit;
    protected string Bus_Rule5_Question, Bus_Rule6_Question, Bus_Rule28_Question, Bus_Rule3_Question, Bus_Rule4_Question, Bus_Rule7_Question, Product_Required, Old_Visit_Date, Answers_Old_Prod_CF_Store_q;
    protected string JWTInfoText, UseTheCallForm, PhotoButton, Nextbutton, return_Message, Excute_SQL, Merch_Message, No_Question_avaliable, TotalProdCount;
    protected string Date_input, VarDay, Varmonth, StrYear, VarSelect_AM, VarSelect_PM, Strcmb_timein, TodayDate, YearDisplay, All_EleAns_Val, Mandatory_products;
    protected string txt_timein_hrsVal, txt_timein_minVal, txt_timeout_hrsVal, txt_timeout_minVal, Visit_Date, txt_Phone1, txt_Phone2, txt_Phone3, CellProvider, Hidden_PhoneStatus, NewGridCF_SaveAnsBack;
    protected string Q_No, Q_Text, Q_Text_Short, Q_Type, Ans_Type, Grid_No, skippattern_status, RTS_JWT, STR_RTS_JWT, Used_qty, ShortCallForm;
    protected string Uniq_Ques_Id, stores_specified, prod_upc, prod_activity_id, skip_flag, ElementName, All_ElementName, ArrayAllHtmlElement, ArrayAllQuestionsElement, RTS_Q_No, ArrayRTS_Q_no;
    protected string Prod_Id, Ans_Val, Ans_Text, Nxt_Q_No, Remark, Response_Text_Flag, Ans_Val_High, Ans_Val_Low, JWT, EleAns_Val, JWTInfoRTS, DisplayHeaderInfo, DisplayQuestLinkInfo, DisplayAnsTypeInfo, DisplayResponseInfo, DisplayControlInfo, DisplayJWTQuestionsInfo, DisplaySaveHiddenInfo, DisplayHighLowInfo;
    protected string Str_VisitMonth, Str_visitday, Str_visityear, Str_timein_hrs, Str_timein_min, Str_cmb_timein, Str_timeout_hrs, Str_timeout_min, Str_cmb_timeout, Mask_high_low_val;
    protected string Str_txt_mileage, Str_txt_drive, Str_rad_q_Past_Midnight, Str_rad_q_HH_Used, Str_rad_q_Ret_store_visit, Str_Manager_Title, Str_txt_Manager_name, Access_to_Grid_CF;
    protected string Str_Radio_EShelf, Str_Ask_EShelf_Question, Str_Bus_Rule3_Question, Str_rad_q_BR3, Str_Bus_Rule4_Question, Str_rad_q_BR4, Str_Bus_Rule5_Question;
    protected string Str_rad_q_BR5, Str_Bus_Rule6_Question, Str_rad_q_BR6, Str_Bus_Rule7_Question, Str_rad_q_BR7, Str_Bus_Rule28_Question, Str_rad_q_BR28, CheckErrorMessage;
    private string Str_Request_Method;
    protected string prod_id, prod_long_desc,   StrTableinfo, QuestionText,   Ele_name, Product_name, Question_name, Strprod_desc, Prod_id_list, FunOnchange,StrOnkeyNumber;
    protected string Strprod_upc, StrQ_no, StrItems, FunOnChange, FunOnfocus, FunOnclick, q_text_short, Question_Text, TDCellStyle, StrQ_text_status, StrArray, StrProd_Q_array,Prod_Q_Element_List,DisplayPQListInfo;
    protected string ResetOnclick, ResetItems, Old_Prod_id, TRowsStyle, StrProd_Q_AnsBack, DisplayansbackLinkInfo, Str_Sv_Panel_id;
    protected int Q_cnt; 
    public string[] vPrompts;
    public DateTime StrDate;
    protected string Star_time, InformationDisplay, DisplayJWTInfo, ShowJWTCheckboxText, STREleSubmitRTS, ArrayEleSubmitRTS, StrMTYPE, StrLogInMtype, StrPTYPE, StrPromptcheck;
    #region SPARUTILS
    SPARValues WebAppClass;
    PromptTranslation ptAppTranslation;

    protected void Page_PreInit()
    {
        Str_Request_Method = Request.ServerVariables.Get("REQUEST_METHOD").ToString();
        //Response.Write("Str_Request_Method=" + Str_Request_Method + "<BR>");

        if (Str_Request_Method == "GETT")
        {
            Response.Redirect("http://mi21.sparinc.com/callformdotnet/CFLoginErrorMessage.aspx");
        }

        SPARHeader PageHeader;
        SPARFooter PageFooter;
        SPARBiLingualBar BiLingualBar;
        PageHeader = (SPARHeader)this.Master.FindControl("SPARHeader1");
        PageFooter = (SPARFooter)this.Master.FindControl("SPARFooter1");
        BiLingualBar = (SPARBiLingualBar)this.Master.FindControl("SPARBiLingualBar1");

        WebAppClass = new SPARValues();


        ptAppTranslation = new PromptTranslation("ProductLayoutCallForm.aspx", WebAppClass.PromptsLanguageId.ToString(), WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection, WebAppClass.MultiLanguageCount);
        // AppMasterControls ap1 = new AppMasterControls(PageHeader, PageFooter, WebAppClass.LoggedUserName, WebAppClass.CurrentDBDateTime, WebAppClass.LanguageId, WebAppClass.PromptsLanguageId, WebAppClass.PageTitle, WebAppClass.CurrentSQLDBConnection, this.Page, WebAppClass.SPARLogoFileURL);
        AppMasterControls ap1 = new AppMasterControls(PageHeader, PageFooter, BiLingualBar, WebAppClass.LoggedUserName, WebAppClass.CurrentDBDateTime, WebAppClass.LanguageId, WebAppClass.PromptsLanguageId, WebAppClass.MultiLanguageCount, WebAppClass.PageTitle, WebAppClass.CurrentSQLDBConnection, this.Page, WebAppClass.SPARLogoFileURL);
        if (WebAppClass.MerchNo > 0)
        {
            PageFooter.ShowSPARToolsURL = false;
            PageFooter.ShowMainPageUrl = false;
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
        
        //((HtmlControl)this.Master.FindControl("form")).Attributes.Add("name", "form22");
        this.Form.Attributes.Add("name", "aspnetForm");

        int QACount,PQCount;
        WebAppClass.Set_MerchforForm(this.Merch_no, Convert.ToString(WebAppClass.MerchNo));

        Lang_id = WebAppClass.LanguageId;

        //****** System Rules
        DataTable RuleTab = new DataTable();
        RuleTab = GetSystemRules();

        AddressRule = RuleTab.Rows[5][2].ToString();
        //Response.Write("AddressRule=" + AddressRule);

        DateRule = RuleTab.Rows[1][2].ToString();
        //Response.Write("DateRule=" + DateRule);

        NameRule = RuleTab.Rows[0][2].ToString();
        // Response.Write("NameRule=" + NameRule);

        MeasurementValue = RuleTab.Rows[6][2].ToString();
        // Response.Write("MeasurementValue=" + MeasurementValue);

        Decimal_Point = RuleTab.Rows[8][2].ToString();
        // Response.Write("Decimal_Point=" + Decimal_Point);
        MeasurementDesc = RuleTab.Rows[7][2].ToString();
       // Response.Write("MeasurementDesc=" + MeasurementDesc);

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
        //Response.Write("Date_input=" + Date_input + "<BR>");


        //************** JWT Display

        // InformationDisplay = Request.Form["InformationDisplay"];
        //Response.Write("InformationDisplay=" + InformationDisplay + "<BR>");
        // JWTInfoRTS = InformationDisplay;
        //if (showCheck=="on")
        //{
        //    ShowChecked = "Checked";
        //}
        //else
        //{
        //    ShowChecked="";
        //}
        //****** Today's date 
        Star_time = Request.Form["Saved_Start_time"];
        //Response.Write("Star_time=" + Star_time);
        if (string.IsNullOrEmpty(Star_time) == true)
        {
            DataTable dt10 = Get_Start_time();
            Star_time = dt10.Rows[0][0].ToString().Trim();
        }
        NewScreenPage = Request.Form["NewScreenPage"];
        //Response.Write("NewMerchPage=" + NewMerchPage);
        StrMTYPE = WebAppClass.MTYPE;
        //Response.Write("StrMTYPE=" + StrMTYPE);

        StrPTYPE = WebAppClass.PTYPE;
        //Response.Write("StrPTYPE=" + StrPTYPE);

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

        Job_No = Request.Form["Job_No"]; 
        Wave_No = Request.Form["Wave_No"];
        Task_No = Request.Form["Task_No"];
        store_id = Request.Form["store_id"];
        Lang_id = WebAppClass.LanguageId;
        //Response.Write(Lang_id);
        Job_No = Request.Form["Job_No"];
        //Response.Write("Job_No=" + Job_No);
        Wave_No = Request.Form["Wave_No"];
        Task_No = Request.Form["Task_No"];
        Task_Desc = Request.Form["Task_Desc"];
        Task_Addtl_Desc = Request.Form["Task_Addtl_Desc"];
        STR_RTS_JWT = "" + Job_No.Trim() + "_" + Wave_No.Trim() + "_" + Task_No.Trim() + "";
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
        //Response.Write("Bus_Rule4_Question=" + Bus_Rule4_Question);
        Bus_Rule7_Question = Request.Form["Bus_Rule7_Question"];



        //************************ From the page CFJWTValidate.asp
        // visit date 
        Str_VisitMonth = Request.Form["ctl00$ContentPlaceHolder1$txt_visitmonth"];
        if (string.IsNullOrEmpty(Str_VisitMonth) == true)
        {
            Str_VisitMonth = Request.Form["Str_VisitMonth"];
        }
        //Response.Write("Str_VisitMonth=" + Str_VisitMonth + "<BR>");

        Str_visitday = Request.Form["ctl00$ContentPlaceHolder1$txt_visitday"];
        if (string.IsNullOrEmpty(Str_visitday) == true)
        {
            Str_visitday = Request.Form["Str_visitday"];
        }
        //Response.Write("Str_visitday=" + Str_visitday + "<BR>");

        Str_visityear = Request.Form["ctl00$ContentPlaceHolder1$txt_visityear"];
        if (string.IsNullOrEmpty(Str_visityear) == true)
        {
            Str_visityear = Request.Form["Str_visityear"];
        }
        // Response.Write("Str_visityear=" + Str_visityear + "<BR>");


        //Time in and out     
        Str_timein_hrs = Request.Form["ctl00$ContentPlaceHolder1$txt_timein_hrs"];
        if (string.IsNullOrEmpty(Str_timein_hrs) == true)
        {
            Str_timein_hrs = Request.Form["Str_timein_hrs"];
        }
        //Response.Write("Str_timein_hrs=" + Str_timein_hrs + "<BR>");
        Str_timein_min = Request.Form["ctl00$ContentPlaceHolder1$txt_timein_min"];
        if (string.IsNullOrEmpty(Str_timein_min) == true)
        {
            Str_timein_min = Request.Form["Str_timein_min"];
        }
        //Response.Write("Str_timein_min=" + Str_timein_min + "<BR>");
        Str_cmb_timein = Request.Form["ctl00$ContentPlaceHolder1$cmb_timein"];
        if (string.IsNullOrEmpty(Str_cmb_timein) == true)
        {
            Str_cmb_timein = Request.Form["Str_cmb_timein"];
        }
        //Response.Write("Str_cmb_timein=" + Str_cmb_timein + "<BR>");

        Str_timeout_hrs = Request.Form["ctl00$ContentPlaceHolder1$txt_timeout_hrs"];
        if (string.IsNullOrEmpty(Str_timeout_hrs) == true)
        {
            Str_timeout_hrs = Request.Form["Str_timeout_hrs"];
        }
        // Response.Write("Str_timeout_hrs=" + Str_timeout_hrs + "<BR>");
        Str_timeout_min = Request.Form["ctl00$ContentPlaceHolder1$txt_timeout_min"];
        if (string.IsNullOrEmpty(Str_timeout_min) == true)
        {
            Str_timeout_min = Request.Form["Str_timeout_min"];
        }
        // Response.Write("Str_timeout_min=" + Str_timeout_min + "<BR>");
        Str_cmb_timeout = Request.Form["ctl00$ContentPlaceHolder1$cmb_timeout"];
        if (string.IsNullOrEmpty(Str_cmb_timeout) == true)
        {
            Str_cmb_timeout = Request.Form["Str_cmb_timeout"];
        }
        // Response.Write("Str_cmb_timeout=" + Str_cmb_timeout + "<BR>");




        // mileage		

        Str_txt_mileage = Request.Form["ctl00$ContentPlaceHolder1$txt_mileage"];
        if (string.IsNullOrEmpty(Str_txt_mileage) == true)
        {
            Str_txt_mileage = Request.Form["Str_txt_mileage"];
        }
        // Response.Write("Str_txt_mileage=" + Str_txt_mileage + "<BR>");

        //drive		
        Str_txt_drive = Request.Form["ctl00$ContentPlaceHolder1$txt_drive"];
        if (string.IsNullOrEmpty(Str_txt_drive) == true)
        {
            Str_txt_drive = Request.Form["Str_txt_drive"];
        }
        //Response.Write("Str_txt_drive=" + Str_txt_drive + "<BR>");

        //Time Question

        Str_rad_q_Past_Midnight = Request.Form["ctl00$ContentPlaceHolder1$rad_q_Past_Midnight"];
        if (string.IsNullOrEmpty(Str_rad_q_Past_Midnight) == true)
        {
            Str_rad_q_Past_Midnight = Request.Form["Str_rad_q_Past_Midnight"];
        }
        //Response.Write("Str_rad_q_Past_Midnight=" + Str_rad_q_Past_Midnight + "<BR>");

        //Hand Held Question

        Str_rad_q_HH_Used = Request.Form["ctl00$ContentPlaceHolder1$rad_q_HH_Used"];
        if (string.IsNullOrEmpty(Str_rad_q_HH_Used) == true)
        {
            Str_rad_q_HH_Used = Request.Form["Str_rad_q_HH_Used"];
        }
        // Response.Write("Str_rad_q_HH_Used=" + Str_rad_q_HH_Used + "<BR>");

        //Time Store Visit

        Str_rad_q_Ret_store_visit = Request.Form["ctl00$ContentPlaceHolder1$rad_q_Ret_store_visit"];
        if (string.IsNullOrEmpty(Str_rad_q_Ret_store_visit) == true)
        {
            Str_rad_q_Ret_store_visit = Request.Form["Str_rad_q_Ret_store_visit"];
        }
        //Response.Write("Str_rad_q_Ret_store_visit=" + Str_rad_q_Ret_store_visit + "<BR>");

        //For EShelf 	

        Str_Radio_EShelf = Request.Form["ctl00$ContentPlaceHolder1$Radio_EShelf"];
        if (string.IsNullOrEmpty(Str_Radio_EShelf) == true)
        {
            Str_Radio_EShelf = Request.Form["Str_Radio_EShelf"];
        }
        // Response.Write("Str_Radio_EShelf=" + Str_Radio_EShelf + "<BR>");

        Str_Ask_EShelf_Question = Request.Form["ctl00$ContentPlaceHolder1$Ask_EShelf_Question"];

        if (string.IsNullOrEmpty(Str_Ask_EShelf_Question) == true)
        {
            Str_Ask_EShelf_Question = Request.Form["Str_Ask_EShelf_Question"];
        }
        // Response.Write("Str_Ask_EShelf_Question=" + Str_Ask_EShelf_Question + "<BR>");

        //business rules

        // Response.Write("Str_Bus_Rule3_Question=" + Str_Bus_Rule3_Question + "<BR>");

        Str_rad_q_BR3 = Request.Form["ctl00$ContentPlaceHolder1$rad_q_BR3"];
        if (string.IsNullOrEmpty(Str_rad_q_BR3) == true)
        {
            Str_rad_q_BR3 = Request.Form["Str_rad_q_BR3"];
        }
        // Response.Write("Str_rad_q_BR3=" + Str_rad_q_BR3 + "<BR>");


        //Response.Write("Str_Bus_Rule4_Question=" + Str_Bus_Rule4_Question + "<BR>");

        Str_rad_q_BR4 = Request.Form["ctl00$ContentPlaceHolder1$rad_q_BR4"];
        if (string.IsNullOrEmpty(Str_rad_q_BR4) == true)
        {
            Str_rad_q_BR4 = Request.Form["Str_rad_q_BR4"];
        }
        // Response.Write("Str_rad_q_BR4=" + Str_rad_q_BR4 + "<BR>");


        Str_rad_q_BR5 = Request.Form["ctl00$ContentPlaceHolder1$rad_q_BR5"];
        //  Response.Write("Str_rad_q_BR5=" + Str_rad_q_BR5 + "<BR>");

        if (string.IsNullOrEmpty(Str_rad_q_BR5) == true)
        {
            Str_rad_q_BR5 = Request.Form["Str_rad_q_BR5"];
        }
        // Response.Write("Str_Bus_Rule6_Question=" + Str_Bus_Rule6_Question + "<BR>");
        Str_rad_q_BR6 = Request.Form["ctl00$ContentPlaceHolder1$rad_q_BR6"];
        if (string.IsNullOrEmpty(Str_rad_q_BR6) == true)
        {
            Str_rad_q_BR6 = Request.Form["Str_rad_q_BR6"];
        }
        //Response.Write("Str_rad_q_BR6=" + Str_rad_q_BR6 + "<BR>");


        //Response.Write("Str_Bus_Rule7_Question=" + Str_Bus_Rule7_Question + "<BR>");
        Str_rad_q_BR7 = Request.Form["ctl00$ContentPlaceHolder1$rad_q_BR7"];
        if (string.IsNullOrEmpty(Str_rad_q_BR7) == true)
        {
            Str_rad_q_BR7 = Request.Form["Str_rad_q_BR7"];
        }
        // Response.Write("Str_rad_q_BR7=" + Str_rad_q_BR7 + "<BR>");


        // Response.Write("Str_Bus_Rule28_Question=" + Str_Bus_Rule28_Question + "<BR>");
        Str_rad_q_BR28 = Request.Form["ctl00$ContentPlaceHolder1$rad_q_BR28"];
        if (string.IsNullOrEmpty(Str_rad_q_BR28) == true)
        {
            Str_rad_q_BR28 = Request.Form["Str_rad_q_BR28"];
        }

        Str_Manager_Title = Request.Form["Str_Manager_Title"];
        // Response.Write("Str_Manager_Title=" + Str_Manager_Title + "<BR>");
        Str_txt_Manager_name = Request.Form["Str_txt_Manager_name"];
        // Response.Write("Str_txt_Manager_name=" + Str_txt_Manager_name + "<BR>");
        //Response.Write("Str_rad_q_BR28=" + Str_rad_q_BR28 + "<BR>");
        DisplayAnswerForGridCF = Request.Form["DisplayAnswerForGridCF"];
        //Response.Write("ProdAnsForNextPage=" + ProdAnsForNextPage + "<BR>");

        ProdAnsForNextPage = Request.Form["ProdAnsForNextPage"];
       //  Response.Write("ProdAnsForNextPage=" + ProdAnsForNextPage + "<BR>");

        AnswersAllFromGrid = Request.Form["AnswersAllFromGrid"];
       // Response.Write("AnswersAllFromGrid=" + AnswersAllFromGrid + "<BR>");
        Answers_Old_Prod_CF_Store_q = Request.Form["Answers_Old_Prod_CF_Store_q"];
       // Response.Write("Answers_Old_Prod_CF_Store_q=" + Answers_Old_Prod_CF_Store_q + "<BR>");

         NewGridCF_SaveAnsBack = Request.Form["NewGridCF_SaveAnsBack"];
          //Response.Write("NewGridCF_SaveAnsBack=" + NewGridCF_SaveAnsBack + "<BR>");

        AnswersForMenuColor = Request.Form["AnswersForMenuColor"];
       // Response.Write("AnswersForMenuColor=" + AnswersForMenuColor + "<BR>");


        CallFormEnded = Request.Form["CallFormEnded"];
        //Response.Write("CallFormEnded=" + CallFormEnded + "<BR>");

        CFEnd_SelectedProduct = Request.Form["CFEnd_SelectedProduct"];
        //Response.Write("CFEnd_SelectedProduct=" + CFEnd_SelectedProduct + "<BR>");
        Old_Visit_Date = Request.Form["Old_Visit_Date"];
        // Response.Write("Old_Visit_Date=" + Old_Visit_Date);
        Str_Sv_Panel_id = Request.Form["Str_Sv_Panel_id"];

        //****************************** Visit date 
        string Visit_Time1, Visit_time, Time_IN_date, Time_Out_date, Visit_Time2, StrVisit_date, DisplayTimeIn, DisplayTimeout, VisitDateDisplay, CalTimeIn, CalTimeOut;

        DateTime Visit_Date2, Visit_Date1;

        Visit_Date = clsDateFormat.FunDate_Format(Convert.ToInt32(Str_VisitMonth), Convert.ToInt32(Str_visitday), Str_visityear, ShowType, DateRule, Date_input);
        VisitDateDisplay = Visit_Date;
        //Response.Write("VisitDateDisplay=" + VisitDateDisplay + "<BR>");


        //************ Date Check
        try
        {
            DataTable dt11 = Get_JWT_VisitDate_Check(Job_No, Wave_No, Task_No, store_id, Visit_Date, Str_Merch_no);
            CheckErrorMessage = dt11.Rows[0][0].ToString();
            // Response.Write("CheckErrorMessage=" + CheckErrorMessage + "<BR>");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        if (Collect_iVR_Time == "Y")
        {
            CalTimeIn = Str_timein_hrs + ":" + Str_timein_min + " " + Str_cmb_timein;
            CalTimeOut = Str_timeout_hrs + ":" + Str_timeout_min + " " + Str_cmb_timeout;
            // Response.Write("CalTimeIn=" + CalTimeIn + "<BR>");
            // Response.Write("CalTimeOut=" + CalTimeOut + "<BR>");
            //******************* Calculate the visit time
            try
            {
                Visit_time = clsDateFormat.CalVisit_Time(Convert.ToInt32(Str_VisitMonth), Convert.ToInt32(Str_visitday), Convert.ToInt32(Str_visityear), CalTimeIn, CalTimeOut, Str_rad_q_Past_Midnight);
                // Response.Write("Visit_time=" + Visit_time + "<BR>");

                Time_IN_date = Visit_Date + " " + Str_timein_hrs + ":" + Str_timein_min + " " + Str_cmb_timein;
                Time_Out_date = Visit_Date + " " + Str_timeout_hrs + ":" + Str_timeout_min + " " + Str_cmb_timeout;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            Time_IN_date = null;
            Time_Out_date = null;
            Visit_time = "Null";
        }

        //Production --test all the questions
         //Job_No = "101449";
        // Wave_No = "201338";
        // Task_No = "53";
        // store_id = "3294214";

       // Job_No = "350075";
       // Wave_No = "201414";
      //  Task_No = "25";
       // store_id = "632525";

       // 350075,201414,25,632525
         //350075,201414,31,27302
    //Test job 
   // Job_No = "350075";
 //  Wave_No = "201414";
 //   Task_No = "31";
 //   store_id = "27302";

        Strprod_upc = "";
        TDCellStyle = "";
        StrQ_text_status = "";
        Prod_Q_Element_List = "";
        Prod_id_list="";
        Q_cnt = 0;
        PQCount = 0;
        QACount =0;

        StringBuilder HTMLText = new StringBuilder();
        StringBuilder HTMLHeader= new StringBuilder();
        StringBuilder HTMLTextHidden = new StringBuilder();
        StringBuilder HTMLText1 = new StringBuilder();
        StringBuilder HTMLText2 = new StringBuilder();
        StringBuilder HTMLText3 = new StringBuilder();
        StringBuilder HTMLText4 = new StringBuilder();
        StringBuilder HTMLText5 = new StringBuilder();
        StringBuilder HTMLText6 = new StringBuilder();
        StringBuilder HTMLText7 = new StringBuilder();
        StringBuilder HTMLText8 = new StringBuilder();
        StringBuilder HTMLText9 = new StringBuilder();
        StringBuilder HTMLText10 = new StringBuilder();

        StringBuilder HTMLTextSubmit = new StringBuilder();

       // HTMLText.Append("<div>");
        //HTMLText.Append("<table border='1' >"); 

        //*********************************************************
        string JWT_Q_No, JWT_Q_Text, JWT_Ans_Type, JWT_Ans_Val, JWT_Ans_Text, JWT_Nxt_Q_No, JWT_Ans_Val_High, JWT_Ans_Val_Low, StrQuestionText, StrJWT_Q_No, StartPoint, StrResponseText, StrResponseText2, StrHighLowVal, StrOnkeyText;
        DataTable JWTData = new DataTable();
        int counter;

        JWTData = Get_JWTQuestionResponse(Job_No, Wave_No, Task_No);
        StrJWT_Q_No = "";
        JWT_Q_No = "";
        JWT_Q_Text = "";
        JWT_Ans_Type = "";
        StartPoint = "Y";
        JWT_Ans_Text = "";
        JWT_Nxt_Q_No = "";
        JWT_Ans_Val = "";
        Product_Required = "";
        StrArray = "";
        Old_Prod_id = "";
        Array_Mandatory_products = "";
        if (JWTData.Rows.Count > 0)
        {
            //No_Question_avaliable = "1";

            foreach (DataRow EachRow in JWTData.Rows)
            {
                if (EachRow["Q_No"] != System.DBNull.Value)
                {
                    JWT_Q_No = Convert.ToString(EachRow["Q_No"]);
                   // Response.Write("prod_upc=" + prod_upc + "<BR>");
                }
                if (EachRow["Q_Text"] != System.DBNull.Value)
                {
                    JWT_Q_Text = Convert.ToString(EachRow["Q_Text"]);
                   // Response.Write("prod_upc=" + prod_upc + "<BR>");
                }
                if (EachRow["Ans_Type"] != System.DBNull.Value)
                {
                    JWT_Ans_Type = Convert.ToString(EachRow["Ans_Type"]);
                    //Response.Write("prod_upc=" + prod_upc + "<BR>");
                }
                if (EachRow["Ans_Val"] != System.DBNull.Value)
                {
                    JWT_Ans_Val = Convert.ToString(EachRow["Ans_Val"]);
                    //Response.Write("prod_upc=" + prod_upc + "<BR>");
                }
                if (EachRow["Ans_Text"] != System.DBNull.Value)
                {
                    JWT_Ans_Text = Convert.ToString(EachRow["Ans_Text"]);
                    //Response.Write("prod_upc=" + prod_upc + "<BR>");
                }
                if (EachRow["Nxt_Q_No"] != System.DBNull.Value)
                {
                    JWT_Nxt_Q_No = Convert.ToString(EachRow["Nxt_Q_No"]);
                    //Response.Write("prod_upc=" + prod_upc + "<BR>");
                }
                if (EachRow["Ans_Val_High"] != System.DBNull.Value)
                {
                    JWT_Ans_Val_High = Convert.ToString(EachRow["Ans_Val_High"]);
                    //Response.Write("prod_upc=" + prod_upc + "<BR>");
                }
                if (EachRow["Ans_Val_Low"] != System.DBNull.Value)
                {
                    JWT_Ans_Val_Low = Convert.ToString(EachRow["Ans_Val_Low"]);
                    //Response.Write("prod_upc=" + prod_upc + "<BR>");
                }

                if (StrJWT_Q_No != JWT_Q_No)
                {
                    JWT_Q_Text = JWT_Q_Text.Replace("'", "`");
                    StrQuestionText = "<input type='hidden' id='Q" + JWT_Q_No.Trim() + "' value='" + JWT_Ans_Type + "_" + JWT_Q_Text + "'>";
                    HTMLText1.Append("" + StrQuestionText + "");
                    //Response.Write("Q_No=" + Q_No + "<BR>");
                    if (StartPoint == "N")
                    {
                        HTMLText4.Append("'>");
                    }
                    StrResponseText = "<input type='hidden' id='R" + JWT_Q_No.Trim() + "' value='";
                    HTMLText4.Append("" + StrResponseText + "");

                    //HTMLText4.Append("|");
                    StrJWT_Q_No = JWT_Q_No;
                }
                JWT_Ans_Text = JWT_Ans_Text.Replace("'", "`");
                StrResponseText2 = "" + JWT_Ans_Val.Trim() + "_" + JWT_Ans_Text.Trim() + "_" + JWT_Nxt_Q_No.Trim() + "|";
                HTMLText4.Append("" + StrResponseText2 + "");
                StartPoint = "N";
            }
        }
        HTMLText4.Append("'>");

        //********************************************************** Call Form 

        DataTable QData = new DataTable();

        QData = Get_JWT_Questions(Job_No, Wave_No, Task_No, store_id);
       // Strprod_upc = QData.Rows[0]["prod_upc"].ToString();
      //  Response.Write("Strprod_upc=" + Strprod_upc + "<BR>");
        counter = 2;
        if (QData.Rows.Count > 0)
        {
            // Response.Write("here1");
            foreach (DataRow myRow in QData.Rows)
            {

                Ans_Val_High = "NULL";
                Ans_Val_Low = "NULL";
                 
                if (myRow["Product_Type"] != System.DBNull.Value)
                {
                    Product_Type = Convert.ToString(myRow["Product_Type"]);
                    // Response.Write("prod_upc=" + prod_upc + "<BR>");
                }
                if (myRow["Product_Required"] != System.DBNull.Value)
                {
                    Product_Required = Convert.ToString(myRow["Product_Required"]);
                   // Response.Write("Product_Required=" + Product_Required + "<BR>");
                }

                if (myRow["prod_upc"] != System.DBNull.Value)
                {
                    prod_upc = Convert.ToString(myRow["prod_upc"]);
                    //Response.Write("prod_upc=" + prod_upc + "<BR>");
                }
                if (myRow["prod_id"] != System.DBNull.Value)
                {
                    prod_id = Convert.ToString(myRow["prod_id"]);
                    // Response.Write("prod_id=" + prod_id + "<BR>");
                }
                if (myRow["prod_long_desc"] != System.DBNull.Value)
                {
                    prod_long_desc = Convert.ToString(myRow["prod_long_desc"]);
                   // Response.Write("prod_long_desc=" + prod_long_desc + "<BR>");   
                }
                if (myRow["Q_No"] != System.DBNull.Value)
                {
                    Q_No = Convert.ToString(myRow["Q_No"]);
                    Q_No = Q_No.Trim();
                    //Response.Write("Q_No=" + Q_No + "<BR>");
                }
                if (myRow["Q_Text"] != System.DBNull.Value)
                {
                    Q_Text = Convert.ToString(myRow["Q_Text"]);
                     // Response.Write("Q_No=" + Q_No + "<BR>");
                      Q_Text = Q_Text.Replace("'", "`");
                }
                if (myRow["Ans_Type"] != System.DBNull.Value)
                {
                    Ans_Type = Convert.ToString(myRow["Ans_Type"]);
                   // Response.Write("Ans_Type=" + Ans_Type + "<BR>");
                }
                if (myRow["QACount"] != System.DBNull.Value)
                {
                    QACount = Convert.ToInt32(myRow["QACount"]);
                    //Response.Write("QACount=" + QACount + "<BR>");
                    //JWT_Q_Text = JWT_Q_Text.Replace("'", "`");
                }
                if (myRow["Ans_Text"] != System.DBNull.Value)
                {
                    Ans_Text = Convert.ToString(myRow["Ans_Text"]);
                    Ans_Text = Ans_Text.Replace("'", "`");
                    // Response.Write("Ans_Text=" + Ans_Text + "<BR>");
                }

                if (myRow["Data_Required"] != System.DBNull.Value)
                {
                    Data_Required = Convert.ToString(myRow["Data_Required"]);
                    //Response.Write("Ans_Text=" + Ans_Text + "<BR>");
                }
                if (myRow["Ans_Val_High"] != System.DBNull.Value)
                {
                    Ans_Val_High = Convert.ToString(myRow["Ans_Val_High"]);
                   // Response.Write("Ans_Val_High=" + Ans_Val_High + "<BR>");

                }
                if (myRow["Ans_Val_Low"] != System.DBNull.Value)
                {
                    Ans_Val_Low = Convert.ToString(myRow["Ans_Val_Low"]);
                   // Response.Write("Ans_Val_Low=" + Ans_Val_Low + "<BR>");
                }
                if (myRow["Ans_Val"] != System.DBNull.Value)
                {
                    Ans_Val = Convert.ToString(myRow["Ans_Val"]);
                    //Response.Write("Ans_Text=" + Ans_Text + "<BR>");
                }
                if (myRow["Nxt_Q_No"] != System.DBNull.Value)
                {
                    Nxt_Q_No = Convert.ToString(myRow["Nxt_Q_No"]);
                    Nxt_Q_No = Nxt_Q_No.Trim();
                    //Response.Write("Ans_Text=" + Ans_Text + "<BR>");
                }
                 if (myRow["PQCount"] != System.DBNull.Value)
                {
                    PQCount = Convert.ToInt32(myRow["PQCount"]);
                   
                    //Response.Write("PQCount=" + PQCount + "<BR>");
                }
                if (myRow["Mask_high_low_val"] != System.DBNull.Value)
                {
                    Mask_high_low_val = Convert.ToString(myRow["Mask_high_low_val"]);
                    //Response.Write("Ans_Text=" + Ans_Text + "<BR>");
                }
                if (myRow["Mandatory_products"] != System.DBNull.Value)
                {
                    Mandatory_products = Convert.ToString(myRow["Mandatory_products"]);
                    Mandatory_products = Mandatory_products.Trim();
                }
                else
                {
                    Mandatory_products = "";
                }
                if (myRow["q_text_short"] != System.DBNull.Value)
                {
                    q_text_short = Convert.ToString(myRow["q_text_short"]);

                    //Response.Write("q_text_short=" + q_text_short + "<BR>");
                }
               // Response.Write("Mandatory_products=" + Mandatory_products + "<BR>");

               // Response.Write("PQCount=" + PQCount + "<BR>");
                // if (PQCount == 1)
               //  {
                //    StrQ_no = ""; 
                // }
                if (Mandatory_products == "Y")
                {
                    TRowsStyle = "style='background-color:Yellow'";
                }
                else
                {
                    TRowsStyle = "";
                }
                Question_Text = "" + Q_No + "-" + q_text_short + "";
               // Response.Write("Question_Text=" + Question_Text + "<BR>");
              //  Response.Write("Q_cnt=" + Q_cnt + "<BR>");
              //  Response.Write("PQCount=" + PQCount + "<BR>");
              //  Response.Write("StrQ_no=" + StrQ_no + "<BR>");
             //   Response.Write("Q_No=" + Q_No + "<BR>");

                if (Q_cnt != PQCount)
                {
                 
                    if (StrQ_no != Q_No)
                    {
                       
                        if (Strprod_upc != prod_upc)
                        {
                            StrHighLowVal = "<input type='hidden' id='HLV" + prod_id.Trim() + "' value='";
                            HTMLText10.Append("" + StrHighLowVal + "");

                            Prod_Q_Element_List="<input type='hidden' id='PQList" + prod_id.Trim() + "' value='";
                            HTMLText9.Append("" + Prod_Q_Element_List + "");

                            StrProd_Q_array = "<input type='hidden' id='SavedList" + prod_id.Trim() + "' value='";
                            HTMLText2.Append("" + StrProd_Q_array + "");

                            StrProd_Q_AnsBack = "<input type='hidden' id='SavedAnsBackList" + prod_id.Trim() + "' value='";
                            HTMLText5.Append("" + StrProd_Q_AnsBack + "");

                            HTMLHeader.Append("<TR>");
                            //HTMLHeader.Append("<TD style='background-color:#336699;' Class='reportTableHeader' BorderColor='dodgerblue'>");
                            HTMLHeader.Append("<TD Class='GridBGC'>");
                            HTMLHeader.Append("<span>Item Description</span>");
                            HTMLHeader.Append("</TD>");

                        }
                       // HTMLHeader.Append("<TD style='background-color:#336699;' Class='reportTableHeader' BorderColor='dodgerblue'>");
                        HTMLHeader.Append("<TD Class='GridBGC'>");
                        HTMLHeader.Append("<span >" + Question_Text + "</span>");
                        HTMLHeader.Append("</TD>");
                        Q_cnt = Q_cnt + 1;
                    }
                }
                if (StrQ_text_status == "")
                {
                    if (Q_cnt == PQCount)
                    {
                        
                       // HTMLHeader.Append("<TD style='background-color:#336699;' Class='reportTableHeader' BorderColor='dodgerblue'>");
                        HTMLHeader.Append("<TD Class='GridBGC'>");
                        HTMLHeader.Append("</TD>");
                        HTMLHeader.Append("</TR>");
                        StrQ_text_status = "N";
                       //Response.Write("test <BR>");
                    }
                }
                //***************************** UPC Number
                if (Strprod_upc != prod_upc)
                {
                    if (Strprod_upc != "")
                    {
                        ResetItems = "'PQList" + Old_Prod_id + "'";
                        ResetOnclick = String.Concat("onclick=", '"', "return ResetProduct(" + ResetItems + ",'" + Old_Prod_id + "');", '"');

                        HTMLText.Append("<TD>");
                        HTMLText.Append("<input type='submit' name='Resetbtn" + Old_Prod_id.Trim() + "' value='Reset'  " + ResetOnclick + "  id='Resetbtn_id" + Old_Prod_id.Trim() + "' class='Button'  /></td>");
                        HTMLText.Append("</TD>");
                        HTMLText.Append("</TR>");
                        counter = counter + 1;
                    }
                    HTMLText.Append("<TR id='TR" + prod_id.Trim() + "'>");
                    HTMLText.Append("<TD id='Cell1_" + prod_id.Trim() + "' " + TRowsStyle + ">");
                    //HTMLText.Append("<span class='selectionCriteriaItem'> " + prod_id.Trim() + " - " + prod_long_desc + "-" + prod_upc + "</span>");
                    HTMLText.Append("<span class='selectionCriteriaItem'> " + prod_long_desc + "</span>");
                    HTMLText.Append("</TD>");

                    Prod_id_list = Prod_id_list + "" + prod_id.Trim() + "|";
                    if (Mandatory_products == "Y")
                    {

                        Array_Mandatory_products = Array_Mandatory_products.Trim() + prod_id.Trim() + "|";
                        Mandatory_products = "";
                        // Response.Write("sdasdasdasdasd=" + Array_Mandatory_products + "<BR>");
                    }

                    if (StrArray == "Y")
                    {
                       // HTMLText2.Append("|");
                        HTMLText2.Append("'/>");
                        StrProd_Q_array = "<input type='hidden' id='SavedList" + prod_id.Trim() + "' value='";
                        HTMLText2.Append("" + StrProd_Q_array + "");

                        HTMLText5.Append("'/>");
                        StrProd_Q_AnsBack = "<input type='hidden' id='SavedAnsBackList" + prod_id.Trim() + "' value='";
                        HTMLText5.Append("" + StrProd_Q_AnsBack + "");


                        HTMLText9.Append("'/>");
                        Prod_Q_Element_List = "<input type='hidden' id='PQList" + prod_id.Trim() + "' value='";
                        HTMLText9.Append("" + Prod_Q_Element_List + "");

                        HTMLText10.Append("'/>");
                        StrHighLowVal = "<input type='hidden' id='HLV" + prod_id.Trim() + "' value='";
                        HTMLText10.Append("" + StrHighLowVal + "");

                    }

                   Strprod_upc = prod_upc;
                   StrQ_no = ""; //new change 7/11/2017
                }
                if (StrQ_no != Q_No)
                {
                    Old_Prod_id = prod_id;
                    StrItems = "'" + Nxt_Q_No + "','" + Q_No + "','QList" + prod_id + "'";
                    
                      //contenteditable="true" onfocus=""
                   // FunOnfocus = String.Concat("onfocus=", '"', "SkipPattern(" + StrItems + ");", '"');
                    FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + prod_id + "','Read the question carefully.');", '"');
                    FunOnclick = String.Concat("onclick=", '"', "SkipPattern(" + StrItems + ");", '"');
                    FunOnclick = String.Concat("onfocus=", '"', "DisplayCallForm(" + prod_id + ");", '"');


                    

                    Ele_name = "";
                    if (Ans_Type == "Z")
                    {
                        TDCellStyle = "bgcolor='#AAAAAA' width='30px'";
                    }
                    else
                    {
                        TDCellStyle = "";
                    }
                   // Response.Write("Ans_Type=" + Ans_Type + "<BR>");
                    HTMLText.Append("<TD " + TDCellStyle + " id='TD"+ prod_id + "_" + Q_No + "'>");

                    if (Ans_Type == "C")
                    {
                        //ForSkipPattern = "'" + Nxt_Q_No + "','" + Q_No + "','QList" + prod_id + "'";
                        Ele_name = "Prod_C" + Q_No + "0" + prod_id + "";
                        Product_name = "" + prod_id + "";
                        Question_name = "" + Q_No + "";
                        FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Nxt_Q_No + "','0','" + Ans_Val_High + "','" + Ans_Val_Low + "');", '"');
                        StrOnkeyNumber = "";
                        //HTMLText.Append("<INPUT type='text' name='Prod_C" + Q_No + "0" + prod_id + "'  size=10 maxlength=12 id='Prod_C" + Q_No + "0" + prod_id + "' " + FunOnfocus + " readonly style='background-color:mintcream;border:none;'/>");
                        HTMLText.Append("<textarea  rows='15' cols='80'  name='Prod_C" + Q_No + "0" + prod_id + "'    id='Prod_C" + Q_No + "0" + prod_id + "' " + FunOnfocus + " readonly  Class='GridTxtA' ></textarea>");
                    }
                    if (Ans_Type == "L")
                    {
                        Ele_name = "Prod_L" + Q_No + "0" + prod_id + "";
                        Product_name = "" + prod_id + "";
                        Question_name = "" + Q_No + "";
                        FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Nxt_Q_No + "','0','" + Ans_Val_High + "','" + Ans_Val_Low + "');", '"');
                        StrOnkeyNumber = "";
                        //HTMLText.Append("<INPUT type='text' name='Prod_L" + Q_No + "0" + prod_id + "'  size=10 maxlength=12 id='Prod_L" + Q_No + "0" + prod_id + "' " + FunOnfocus + " readonly style='background-color:mintcream;border:none;'/>");
                        HTMLText.Append("<textarea  rows='8' cols='40'  name='Prod_L" + Q_No + "0" + prod_id + "'    id='Prod_L" + Q_No + "0" + prod_id + "' " + FunOnfocus + " readonly Class='GridTxtA'></textarea>");
                        
                    }
                    if (Ans_Type == "R")
                    {
                        Ele_name = "Prod_R" + Q_No + "0" + prod_id + "";
                        Product_name = "" + prod_id + "";
                        Question_name = "" + Q_No + "";
                        FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Nxt_Q_No + "','0','" + Ans_Val_High + "','" + Ans_Val_Low + "');", '"');
                        StrOnkeyNumber = "";
                        HTMLText.Append("<INPUT type='text' name='Prod_R" + Q_No + "0" + prod_id + "'  size=10 maxlength=12 id='Prod_R" + Q_No + "0" + prod_id + "' " + FunOnfocus + " readonly Class='GridTxtA'/>");
                    }
                    if (Ans_Type == "T")
                    {
                        Ele_name = "Prod_T" + Q_No + "0" + prod_id + "";
                        Product_name = "" + prod_id + "";
                        Question_name = "" + Q_No + "";
                        FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Nxt_Q_No + "','0','" + Ans_Val_High + "','" + Ans_Val_Low + "');", '"');
                        //StrOnkeyText='onkeypress="return TextCheckOnly(' + StrItemKey + ')"';
                        StrOnkeyText = String.Concat("onkeypress=", '"', "return TextCheckOnly(event);", '"');


                        HTMLText.Append("<textarea  rows='8' cols='40'  name='Prod_T" + Q_No + "0" + prod_id + "'   id='Prod_T" + Q_No + "0" + prod_id + "' " + FunOnfocus + " " + StrOnkeyText + "  Class='GridTxtA'/></textarea>");
                   
                    }
                    if (Ans_Type == "N")
                    {
                        Ele_name = "Prod_N" + Q_No + "0" + prod_id + "";
                        Product_name = "" + prod_id + "";
                        Question_name = "" + Q_No + "";
                        FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Nxt_Q_No + "','1','" + Ans_Val_High + "','" + Ans_Val_Low + "');", '"');
                        FunOnchange = String.Concat("onchange=", '"', "QV_NDPHM('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Ans_Val_High + "','" + Ans_Val_Low + "','" + Ans_Type + "');", '"');
                        StrOnkeyNumber = String.Concat("onkeypress=", '"', "return NumberOnly(event);", '"');
                        MoveToNextProdCheck = String.Concat("onkeydown=", '"', "return MoveToNextProdCheck(event.keyCode);", '"');

                        HTMLText.Append("<INPUT type='text' name='Prod_N" + Q_No + "0" + prod_id + "' size=10 maxlength=12  id='Prod_N" + Q_No + "0" + prod_id + "' " + FunOnfocus + "  " + FunOnchange + "  " + StrOnkeyNumber + " " + MoveToNextProdCheck + "/>");
                    }
                    if (Ans_Type == "D")
                    {
                        Ele_name = "Prod_D" + Q_No + "0" + prod_id + "";
                        Product_name = "" + prod_id + "";
                        Question_name = "" + Q_No + "";
                        
                        FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Nxt_Q_No + "','1','" + Ans_Val_High + "','" + Ans_Val_Low + "');", '"');
                        FunOnchange = String.Concat("onchange=", '"', "QV_NDPHM('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Ans_Val_High + "','" + Ans_Val_Low + "','" + Ans_Type + "');", '"');
                        StrOnkeyNumber = String.Concat("onkeypress=", '"', "return DateNumberOnly(event);", '"');
                        MoveToNextProdCheck = String.Concat("onkeydown=", '"', "return MoveToNextProdCheck(event.keyCode);", '"');

                        HTMLText.Append("<INPUT type='text' name='Prod_D" + Q_No + "0" + prod_id + "'  size=10 maxlength=12 id='Prod_D" + Q_No + "0" + prod_id + "' " + FunOnfocus + " " + FunOnchange + " " + StrOnkeyNumber + " " + MoveToNextProdCheck + "/>");
                    }
                    if (Ans_Type == "P")
                    {

                        Ele_name = "Prod_P" + Q_No + "0" + prod_id + ""; 
                        Product_name = "" + prod_id + "";
                        Question_name = "" + Q_No + "";
                        FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Nxt_Q_No + "','1','" + Ans_Val_High + "','" + Ans_Val_Low + "');", '"');
                        FunOnchange = String.Concat("onchange=", '"', "QV_NDPHM('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Ans_Val_High + "','" + Ans_Val_Low + "','" + Ans_Type + "');", '"');
                        StrOnkeyNumber = String.Concat("onkeypress=", '"', "return NumberOnlyPrice(event);", '"');
                        MoveToNextProdCheck = String.Concat("onkeydown=", '"', "return MoveToNextProdCheck(event.keyCode);", '"');

                        HTMLText.Append("<INPUT type='text' name='Prod_P" + Q_No + "0" + prod_id + "'  size=10 maxlength=12 id='Prod_P" + Q_No + "0" + prod_id + "' " + FunOnfocus + " " + FunOnchange + " " + StrOnkeyNumber + " " + MoveToNextProdCheck + "/>");
                    }
                    if (Ans_Type == "M")
                    {
                        Ele_name = "Prod_M" + Q_No + "0" + prod_id + "";
                        Product_name = "" + prod_id + "";
                        Question_name = "" + Q_No + "";
                        FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Nxt_Q_No + "','0','" + Ans_Val_High + "','" + Ans_Val_Low + "');", '"');
                        FunOnchange = String.Concat("onchange=", '"', "QV_NDPHM('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Ans_Val_High + "','" + Ans_Val_Low + "','" + Ans_Type + "');", '"');
                        StrOnkeyNumber = "";
                        HTMLText.Append("<INPUT type='text' name='Prod_M" + Q_No + "0" + prod_id + "'  size=10 maxlength=12 id='Prod_M" + Q_No + "0" + prod_id + "' " + FunOnfocus + " " + FunOnchange + "/>");
                    }
                    if (Ans_Type == "H")
                    {
                        Ele_name = "Prod_H" + Q_No + "0" + prod_id + "";
                        Product_name = "" + prod_id + "";
                        Question_name = "" + Q_No + "";

                        FunOnfocus = String.Concat("onfocus=", '"', "DisplayCallForm('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Nxt_Q_No + "','0','" + Ans_Val_High + "','" + Ans_Val_Low + "');", '"');
                        FunOnchange = String.Concat("onchange=", '"', "QV_NDPHM('" + Ele_name + "','" + Product_name + "','" + Question_name + "','" + Ans_Val_High + "','" + Ans_Val_Low + "','" + Ans_Type + "');", '"');
                        StrOnkeyNumber = "";

                        HTMLText.Append("<INPUT type='text' name='Prod_H" + Q_No + "0" + prod_id + "'  size=10 maxlength=12 id='Prod_H" + Q_No + "0" + prod_id + "' " + FunOnfocus + " " + FunOnchange + "/>");
                    }
                    //if (Ans_Type == "Z")
                   // {
                      // HTMLText.Append("<div name='divadasdas'  size=10 maxlength=12 id='dfdfsfd'   readonly style='background-color:Gray;border:none;width:50px;'></div>");
                   // }
                    HTMLText.Append("</TD>");
                    if (Ans_Type != "Z")
                    {
                        QuestionText = Q_No + "_" + Ans_Val_High + "_" + Ans_Val_Low + "";
                        HTMLText10.Append("" + QuestionText.Trim() + "|");
                    }
                    HTMLText3.Append("" + Ans_Type + "_" + QACount + "|");

                    if (string.IsNullOrEmpty(Ele_name) == false)
                    {
                        HTMLText9.Append("" + Ele_name.Trim() + "|");
                    }
                    

                    StrQ_no = Q_No;
                }

                StrArray = "Y";
               // counter = counter + 1;
            }//foreach (DataRow myRow in QData.Rows)
        }//
       // HTMLText.Append("</div>");
        //Response.Write("prod_id=" + prod_id + "<BR>");
        ResetItems = "'PQList" + prod_id + "'";
        ResetOnclick = String.Concat("onclick=", '"', "return ResetProduct(" + ResetItems + ",'" + Old_Prod_id + "');", '"');

        HTMLText.Append("<TD>");
        HTMLText.Append("<input type='submit' name='Resetbtn" + Old_Prod_id + "' value='Reset'  " + ResetOnclick + "  id='Resetbtn_id" + Old_Prod_id + "' class='Button' /></td>");
        HTMLText.Append("</TD>");

        HTMLText.Append("</TR>"); 
        HTMLText.Append("</table>");
        StrTableinfo = "<table border='1'>" + HTMLHeader.ToString() + "" + HTMLText.ToString();

        HTMLText2.Append("'/>");
        HTMLText5.Append("'/>");
        HTMLText9.Append("'/>");
        HTMLText10.Append("'/>"); 

       // Dispaly_GridCallform.Text = HTMLText.ToString();
        Dispaly_GridCallform.Text = StrTableinfo;
        //Label1.text = HTMLHeader.ToString();
        //All the questions text
        DisplayJWTQuestionsInfo = HTMLText1.ToString();
        //Question response
        DisplayResponseInfo = HTMLText4.ToString();
        //Save each product list for next page
        DisplayQuestLinkInfo = HTMLText2.ToString();
        //Save each product list the way it is display
        DisplayansbackLinkInfo = HTMLText5.ToString();

        //Each prod questions list
        DisplayPQListInfo = HTMLText9.ToString();

        //high low for each product  
        DisplayHighLowInfo = HTMLText10.ToString();
        Timeq_desc = "" + vPrompts[119] + "," + vPrompts[120] + "";
       // Response.Write("Prod_id_list=" + Prod_id_list + "<BR>");
        //*******************Compare questions

        Compare_q_status = "N";
        DataTable dt2 = Get_JWT_Compare_Questions_Check(Lang_id, Job_No, Wave_No, Task_No);

        foreach (DataRow CPRow in dt2.Rows)
        {
            Compare_Q_No = Convert.ToString(CPRow["q_no"]);
            //ArrayRTS_Q_no = ArrayRTS_Q_no + "" + RTS_Q_No + ",";
            Compare_Q_ans_type = Convert.ToString(CPRow["Q_ans_type"]);
            Compare_q_list = Convert.ToString(CPRow["Compare_q_list"]);
            //Response.Write("Compare_Q_No=" + Compare_Q_No + "<BR>");
            //Response.Write("Compare_Q_ans_type=" + Compare_Q_ans_type + "<BR>");
            //Response.Write("Compare_q_list=" + Compare_q_list + "<BR>");
            HTMLText8.Append("<INPUT TYPE='hidden' name='Com_q_" + Compare_Q_No + "' id='Com_q_id_" + Compare_Q_No + "' value='" + Compare_q_list + "'><br /><INPUT TYPE='hidden' name='Com_q_Select_Type" + Compare_Q_No + "'  value='" + Compare_Q_ans_type + "'>  ");
            //<input name="Com_q_007" id="Com_q_id_007" type="hidden" value="B_005_N" />
            Compare_q_status = "Y";
        }
        Compare_q_Hidden_var = HTMLText8.ToString();
        
    }

    #region Procedures
    //************* Function to get the JWT info
    private DataTable Get_JWT_Questions(String Job_No, String Wave_No, String Task_No, String Store_id)
    {
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempStore_id = 0;


        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempStore_id = AppUtils.ConvertToInteger32(Store_id, 0);

        return AppData.Get_JWT_GridQuestionsData(iTempJob_No, iTempWave_No, iTempTask_No, iTempStore_id, WebAppClass.CurrentSQLDBConnection);
    }
    private DataTable Get_JWTQuestionResponse(String Job_No, String Wave_No, String Task_No)
    {
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;

        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);

        return AppData.Get_JWTQuestionResponseData(iTempJob_No, iTempWave_No, iTempTask_No, WebAppClass.CurrentSQLDBConnection);
    }
    private DataTable Get_CFRTS_Issue(String Job_No, String Wave_No, String Task_No, String Store_id)
    {
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempStore_id = 0;


        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempStore_id = AppUtils.ConvertToInteger32(Store_id, 0);

        //iTempCellProvider = AppUtils.ConvertToInteger32(CellProvider, 0);
        // iTempHidden_PhoneStatus = AppUtils.ConvertToInteger32(Hidden_PhoneStatus, 0);

        return AppData.Get_USP_Call_Form_RTS_Issues(iTempJob_No, iTempWave_No, iTempTask_No, iTempStore_id, WebAppClass.CurrentSQLDBConnection);
    }
    private DataTable Get_JWT_VisitDate_Check(String Job_No, String Wave_No, String Task_No, String Store_id, String Visit_Date, String Str_Merch_no)
    {
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempStore_id = 0;
        Int32 iTempMerch_no = 0;

        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempStore_id = AppUtils.ConvertToInteger32(Store_id, 0);
        iTempMerch_no = AppUtils.ConvertToInteger32(Str_Merch_no, 0);

        return AppData.Get_JWT_VisitDate_CheckClass(iTempJob_No, iTempWave_No, iTempTask_No, iTempStore_id, Visit_Date, iTempMerch_no, WebAppClass.CurrentSQLDBConnection);
    }
    private DataTable Get_Start_time()
    {

        return AppData.Get_Start_timeClass(WebAppClass.CurrentSQLDBConnection);
    }
    private DataTable Get_JWT_Compare_Questions_Check(Int32 Lang_id, String Job_No, String Wave_No, String Task_No)
    {
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;

        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);

        return AppData.Get_JWT_Compare_QuestionsClass(Lang_id, iTempJob_No, iTempWave_No, iTempTask_No, WebAppClass.CurrentSQLDBConnection);
    }
    #endregion
    #region SystemPromptandRule

    private void GetPromptTranslation()
    {
        vPrompts = new string[121];
        vPrompts[0] = "Product number has to be numeric.";
        vPrompts[1] = "Product number";
        vPrompts[2] = "does not exist.";
        vPrompts[3] = "Please select Product from the menu or enter a product number.";
        vPrompts[4] = "This is the last product in the list.";
        vPrompts[5] = "This is the first product on the list.";
        vPrompts[6] = "Minimum product requirements are not met for this store. Please review paperwork and call form data to ensure all products found in store are entered before you can proceed.";
        vPrompts[7] = "Please continue with the Internet Call Form.";
        vPrompts[8] = "Not all items have been recorded, please provide data for all items";
        vPrompts[9] = "Please answer";
        vPrompts[10] = "cannot have Single quotes.";
        vPrompts[11] = "Please enter a valid date for question";
        vPrompts[12] = "cannot have Single quotes.";
        vPrompts[13] = "cannot have Comma.";
        vPrompts[14] = "Please enter a valid date for question";
        vPrompts[15] = "has to be numeric.";
        vPrompts[16] = "must be a whole number.";
        vPrompts[17] = "must be a whole number.";
        vPrompts[18] = "value has to be less or equal to";
        vPrompts[19] = "Dollar(s) value has to be numeric.";
        vPrompts[20] = "Dollar(s) value can not have a period.";
        vPrompts[21] = "Cent(s) value can not be bigger than 99 cent.";
        vPrompts[22] = "Cent(s) value has to be numeric.";
        vPrompts[23] = "Cent(s) value can not have a period.";
        vPrompts[24] = "You must enter a value for dollar(s).";
        vPrompts[25] = "You must enter a value for cent(s).";
        vPrompts[26] = "The value has to be greater than or equal to ";
        vPrompts[27] = "The value has to be less or equal to ";
        vPrompts[28] = "Feet(s) value has to be numeric.";
        vPrompts[29] = "Feet(s) value can not have a period.";
        vPrompts[30] = "Inch/Inches value can not be bigger than";
        vPrompts[31] = "Inch/Inches value can not be less than 0.";
        vPrompts[32] = "Inch/Inches value has to be numeric.";
        vPrompts[33] = "Inch/Inches value can not have a period.";
        vPrompts[34] = "You must enter a value for feet(s).";
        vPrompts[35] = "You must enter a value for Inch/Inches.";
        vPrompts[36] = "The value has to be greater than or equal to ";
        vPrompts[37] = "The value has to be less or equal to ";
        vPrompts[38] = "Hour(s) value has to be numeric.";
        vPrompts[39] = "Hour(s) value can not have a period.";
        vPrompts[40] = "Minute(s) value can not be bigger than 59.";
        vPrompts[41] = "Minute(s) value can not be less than 0.";
        vPrompts[42] = "Minute(s) value has to be numeric.";
        vPrompts[43] = "Minute(s) value can not have a period.";
        vPrompts[44] = "You must enter a value for Hour(s).";
        vPrompts[45] = "You must enter a value for Minute(s).";
        vPrompts[46] = "The value has to be greater than or equal to ";
        vPrompts[47] = "The value has to be less or equal to ";
        vPrompts[48] = "Month must be between 1 and 12.";
        vPrompts[49] = "Day must be between 1 and 31.";
        vPrompts[50] = "Month";
        vPrompts[51] = "does not have 31 days!";
        vPrompts[52] = "February";
        vPrompts[53] = "does not have ";
        vPrompts[54] = "days!";
        vPrompts[55] = "The Product ";
        vPrompts[56] = "is a Mandatory for this Job, wave, and task.";
        vPrompts[57] = "Question";
        vPrompts[58] = "You can not use the NEXT button any more.";
        vPrompts[59] = "You can not use the BACK button any more.";
        vPrompts[60] = "If there is only value for cent(s) then enter 0 for dollar(s).";
        vPrompts[61] = "If there is only value for dollar(s) then enter 0 for cent(s).";
        vPrompts[62] = "If there is only value for Inch/Inches then enter 0 for feet(s).";
        vPrompts[63] = "If there is only value for feet(s) then enter 0 for Inch/Inches.";
        vPrompts[64] = "If there is only value for Minute(s) then enter 0 for Hour(s).";
        vPrompts[65] = "If there is only value for Hour(s) then enter 0 for Minute(s).";
        vPrompts[66] = "Date is not in a valid format.";
        vPrompts[67] = "Are you sure you answered all the questions on this call form?";
        vPrompts[68] = "If NO then please click Cancel.";
        vPrompts[69] = "If YES then please click OK to submit your answers.";
        vPrompts[70] = "The value can not be less than zero.";
        vPrompts[71] = "Invalid value entered for question";
        vPrompts[72] = "No Product available for J/W/T.";
        vPrompts[73] = "Date:";
        vPrompts[74] = "Internet Call Form";
        vPrompts[75] = "Job No.";
        vPrompts[76] = "Wave No.";
        vPrompts[77] = "Task No.";
        vPrompts[78] = "Chain No.";
        vPrompts[79] = "Store No.";
        vPrompts[80] = "Please wait till the page is finished loading.";
        vPrompts[81] = "Enter Product No.";
        vPrompts[82] = "Select a Product";
        vPrompts[83] = "No Product available for J/W/T.";
        vPrompts[84] = "Product Number:";
        vPrompts[85] = "(Multiple answers allowed)";
        vPrompts[86] = "(Only one answer allowed)";
        vPrompts[87] = "(Enter a numeric value)";
        vPrompts[88] = "(Enter a valid text)";
        vPrompts[89] = "(Enter a date in mm/dd/yy format)";
        vPrompts[90] = "(Enter a numeric value)";
        vPrompts[91] = "QNo.";
        vPrompts[92] = "Ans";
        vPrompts[93] = "(mm/dd/yyyy)";
        vPrompts[94] = "Dollar(s)";
        vPrompts[95] = "Cent(s)";
        vPrompts[96] = "Feet(s)";
        vPrompts[97] = "Inch/Inches";
        vPrompts[98] = "Hour(s)";
        vPrompts[99] = "Minute(s)";
        vPrompts[100] = "SPAR Group, Inc.";
        vPrompts[101] = "All Rights Reserved.";
        vPrompts[102] = "HELP";
        vPrompts[103] = "Next";
        vPrompts[104] = "Back";
        vPrompts[105] = "Reset";
        vPrompts[106] = "Call Form Completed";
        vPrompts[107] = "You are indicating that you were not able to complete your store visit.  You will not be able to report data for any products.";
        vPrompts[108] = "You are indicating that you were not able to complete your store visit.  All data you have already reported for this store will be deleted.";
        vPrompts[109] = "Please answer all mandatory products highlighted in yellow.";
        vPrompts[110] = "Please enter data in order to complete the call form.";
        vPrompts[111] = "Your response must be equal to question";//2
        vPrompts[112] = "Your response must be less than or equal to question";//2
        vPrompts[113] = "Your response must be greater than or equal to question";//2
        vPrompts[114] = "Your response must be bigger than question";//2
        vPrompts[115] = "Your response must be less than question";//3
        vPrompts[116] = "Invalid response for question";//3
        vPrompts[117] = "the value you entered is outside the acceptable range.";
        vPrompts[118] = "You must enter both values for question";
        vPrompts[119] = "hrs";
        vPrompts[120] = "min";

        



        ptAppTranslation.DoArrayPromptTranslation(vPrompts);


    }
    private DataTable GetSystemRules()
    {
        DataTable appDT = new DataTable();

        string[] VRule;
        VRule = new string[9];
        VRule[0] = "Name Format";
        VRule[1] = "New Date Format";
        VRule[2] = "Collect Mobile Email";
        VRule[3] = "SPAR Logo";
        VRule[4] = "SPAR Copyright";
        VRule[5] = "Address Format";
        VRule[6] = "Measurement_Val";
        VRule[7] = "Measurement";
        VRule[8] = "Decimal Points";
        appDT = AppSysRules.Get_RuleValue_ByDescAsDataTable(VRule, WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection);
        return appDT;
    }

    #endregion
   
}