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

public partial class CFCallFormValidate : System.Web.UI.Page
{
    protected string user_id, Email_Active_Flag, Str_Merch_no, Job_No, Wave_No, Task_No, Chain_No, Store_No, txt_EmailAdd, txt_Mobile_Email, POutOfStock_no, Error_Message, Error_Flag, HTMLHeader_info, Collect_Mobile_Email, AddressRule, NameRule, DateRule;
    protected int Error_Message_Flag, BusinessQuestion_Flag, OutOfStock_no, Back_Slash, Dot, Dash, ShowType, Lang_id;
    protected string store_id, Store_Chain_Desc, Store_Store_Name, Store_Street_Addr, Store_City, Store_State, Store_Zip, Data_Required, MeasurementValue, Decimal_Point;
    protected string PMerch_no, CA_merch_no, Merch_First_Name, Merch_Last_Name, Merch_Street_Addr, Merch_Street_Addr2, NewScreenPage;
    protected string Merch_City, Merch_State, Merch_Zip, Merch_Phone_No, Merch_Email_Addr, Task_Desc, Task_Addtl_Desc, CellPhoneNo;
    protected string Field_Start_Dt, Field_end_Dt, Key_Comp_Dt, DOA_Dt, Job_Type, Business_Type_id, Work_Type_id, Work_Type_Desc, Max_Mx_Per_Store;
    protected string Max_Visit_Per_Store_Mx, visit_no, Collect_iVR_Time, night_visits, Mileage_flag, Travel_flag, Data_Col_Method;
    protected string All_Data_Received, qdef_skippattern, Collect_Header, Collect_Call_Form, SS_Callform, Prod_Specific, overwritetime, Prod_UPC;
    protected string collect_time_only, Ask_Q_HH_Used, HH_Status_Flag, Collect_Store_Mgr_Name, Product_Check_Flag, Ask_EShelf_Question;
    protected string Call_Form_Type_No, Est_instore_minutes, Business_Rule_Eckerd, Eckerd_Job_Last_question, Bus_Rule22_Photo, ArrayEleSubmit, Photo_q_Matched_Status_flag, Job_Visit_Date, HC_Visit_Date;
    protected string Bus_Rule5_Question, Bus_Rule6_Question, Bus_Rule28_Question, Bus_Rule3_Question, Bus_Rule4_Question, Bus_Rule7_Question;
    protected string JWTInfoText, UseTheCallForm, PhotoButton, Nextbutton, return_Message, Excute_SQL, Merch_Message, No_Question_avaliable, Old_Visit_Date;
    protected string Date_input, VarDay, Varmonth, StrYear, VarSelect_AM, VarSelect_PM, Strcmb_timein, TodayDate, YearDisplay, StrMTYPE, StrLogInMtype, StrPTYPE, StrPromptcheck;
    protected string txt_timein_hrsVal, txt_timein_minVal, txt_timeout_hrsVal, txt_timeout_minVal, Visit_Date, txt_Phone1, txt_Phone2, txt_Phone3, CellProvider, Hidden_PhoneStatus;
    protected string Q_No, Q_Text, Q_Text_Short, Q_Type, Ans_Type, Grid_No, skippattern_status, RTS_JWT, STR_RTS_JWT, Used_qty, ShortCallForm;
    protected string Uniq_Ques_Id, stores_specified, prod_upc, prod_activity_id, skip_flag, ElementName, All_ElementName, ArrayAllHtmlElement, ArrayAllQuestionsElement, RTS_Q_No, ArrayRTS_Q_no;
    protected string Prod_Id, Ans_Val, Ans_Text, Nxt_Q_No, Remark, Response_Text_Flag, Ans_Val_High, Ans_Val_Low, JWT, Str_Manager_Title, Str_txt_Manager_name;
    protected string Str_VisitMonth, Str_visitday, Str_visityear, Str_timein_hrs, Str_timein_min, Str_cmb_timein, Str_timeout_hrs, Str_timeout_min, Str_cmb_timeout;
    protected string Str_txt_mileage, Str_txt_drive, Str_rad_q_Past_Midnight, Str_rad_q_HH_Used, Str_rad_q_Ret_store_visit;
    protected string Str_Radio_EShelf, Str_Ask_EShelf_Question, Str_Bus_Rule3_Question, Str_rad_q_BR3, Str_Bus_Rule4_Question, Str_rad_q_BR4, Str_Bus_Rule5_Question, Str_Sv_Panel_id;
    protected string Str_rad_q_BR5, Str_Bus_Rule6_Question, Str_rad_q_BR6, Str_Bus_Rule7_Question, Str_rad_q_BR7, Str_Bus_Rule28_Question, Str_rad_q_BR28, Count_Message;
    public string[] vPrompts;
    public DateTime StrDate;
    protected string Star_time, HPStrArray, DisplayJWTInfo, ShowJWTCheckboxText, showCheckStatus, ShowChecked,HiddenInsertQuestion;
    private string Str_Request_Method, Str_Response_val;

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
            Response.Redirect("http://mi21.sparinc.com/callformdotnet/CFLoginErrorMessage.aspx");
        }

        SPARHeader PageHeader;
        SPARFooter PageFooter;
        SPARBiLingualBar BiLingualBar;
        PageHeader = (SPARHeader)this.Master.FindControl("SPARHeader1");
        PageFooter = (SPARFooter)this.Master.FindControl("SPARFooter1");
        BiLingualBar = (SPARBiLingualBar)this.Master.FindControl("SPARBiLingualBar1");

        WebAppClass = new SPARValues();
        WebAppClass.PageTitle = "";

        ptAppTranslation = new PromptTranslation("CFCallFormValidate.aspx", WebAppClass.PromptsLanguageId.ToString(), WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection, WebAppClass.MultiLanguageCount);
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
    protected void Page_Load(object sender, EventArgs e)
    {
            
        WebAppClass.Set_MerchforForm(this.Merch_no, Convert.ToString(WebAppClass.MerchNo));

        //Str_Merch_no = Convert.ToString(WebAppClass.MerchNo);
        //Response.Write("Merch_noBefore=" + Str_Merch_no + "<BR>");

        //****** System Rules
        DataTable RuleTab = new DataTable();
        RuleTab = GetSystemRules();

        AddressRule = RuleTab.Rows[5][2].ToString();
        //Response.Write("AddressRule=" + AddressRule);

        DateRule = RuleTab.Rows[1][2].ToString();
        //Response.Write("DateRule=" + DateRule);

        NameRule = RuleTab.Rows[0][2].ToString();
        //Response.Write("NameRule=" + NameRule);

        MeasurementValue = RuleTab.Rows[6][2].ToString();
        //Response.Write("MeasurementValue=" + MeasurementValue);

        Decimal_Point = RuleTab.Rows[8][2].ToString();
        //Response.Write("Decimal_Point=" + Decimal_Point);

       
        //****** Prompts
        GetPromptTranslation();

        //Display JWT INfo
        //ShowJWTCheckboxText = vPrompts[7];
        DisplayJWTInfo = Request.Form["DisplayJWTInfo"];
        //checkbox
        showCheckStatus = Request.Form["showCheck"];
        //Response.Write("showCheckStatus=" + showCheckStatus);


         if (showCheckStatus=="on")
         {
            ShowChecked = "Checked";
         }
        else
        {
            ShowChecked="";
        }
        //********************************* hidden variables *****************************
        Star_time = Request.Form["Star_time"];
        //Response.Write("Star_time=" + Star_time);
        Lang_id = WebAppClass.LanguageId;
        //Response.Write(Lang_id);

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
            ShowJWTCheckboxText = "Show Job Information ";
        }
        else
        {
            ShowJWTCheckboxText = vPrompts[7];
        }



        NewScreenPage = Request.Form["NewScreenPage"];
        //Response.Write("NewMerchPage=" + NewMerchPage);

        // Response.Write("good job <BR>");
        Job_No = Request.Form["Job_No"];
        // Response.Write("Job_No=" + Job_No);
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
        // Response.Write("Bus_Rule4_Question=" + Bus_Rule4_Question);
        Bus_Rule7_Question = Request.Form["Bus_Rule7_Question"];

        //************************ From the page CFJWTValidate.asp
        //***** visit date 
        Str_VisitMonth = Request.Form["Str_VisitMonth"];
        // Response.Write("Str_VisitMonth=" + Str_VisitMonth + "<BR>");

        Str_visitday = Request.Form["Str_visitday"];
        //Response.Write("Str_visitday=" + Str_visitday + "<BR>");

        Str_visityear = Request.Form["Str_visityear"];
        //Response.Write("Str_visityear=" + Str_visityear + "<BR>");

        //*******Time in and out     
        Str_timein_hrs = Request.Form["Str_timein_hrs"];
        // Response.Write("Str_timein_hrs=" + Str_timein_hrs + "<BR>");
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

        //******** mileage		

        Str_txt_mileage = Request.Form["Str_txt_mileage"];
        //Response.Write("Str_txt_mileage=" + Str_txt_mileage + "<BR>");

        //******** drive		
        Str_txt_drive = Request.Form["Str_txt_drive"];
        // Response.Write("Str_txt_drive=" + Str_txt_drive + "<BR>");

        //******** Time Question

        Str_rad_q_Past_Midnight = Request.Form["Str_rad_q_Past_Midnight"];
        //Response.Write("Str_rad_q_Past_Midnight=" + Str_rad_q_Past_Midnight + "<BR>");

        //******** Hand Held Question

        Str_rad_q_HH_Used = Request.Form["Str_rad_q_HH_Used"];
        //Response.Write("Str_rad_q_HH_Used=" + Str_rad_q_HH_Used + "<BR>");

        //******** Time Store Visit

        Str_rad_q_Ret_store_visit = Request.Form["Str_rad_q_Ret_store_visit"];
        //Response.Write("Str_rad_q_Ret_store_visit=" + Str_rad_q_Ret_store_visit + "<BR>");

        //******** For EShelf 	

        Str_Radio_EShelf = Request.Form["Str_Radio_EShelf"];
        //Response.Write("Str_Radio_EShelf=" + Str_Radio_EShelf + "<BR>");

        Str_Ask_EShelf_Question = Request.Form["Str_Ask_EShelf_Question"];
        //Response.Write("Str_Ask_EShelf_Question=" + Str_Ask_EShelf_Question + "<BR>");

        //******** business rules
        Str_Bus_Rule3_Question = Request.Form["Str_Bus_Rule3_Question"];
        //Response.Write("Str_Bus_Rule3_Question=" + Str_Bus_Rule3_Question + "<BR>");

        Str_rad_q_BR3 = Request.Form["Str_rad_q_BR3"];
        //Response.Write("Str_rad_q_BR3=" + Str_rad_q_BR3 + "<BR>");

        Str_Bus_Rule4_Question = Request.Form["Str_Bus_Rule4_Question"];
        //Response.Write("Str_Bus_Rule4_Question=" + Str_Bus_Rule4_Question + "<BR>");

        Str_rad_q_BR4 = Request.Form["Str_rad_q_BR4"];
        //Response.Write("Str_rad_q_BR4=" + Str_rad_q_BR4 + "<BR>");

        Str_Bus_Rule5_Question = Request.Form["Str_Bus_Rule5_Question"];
        //Response.Write("Str_Bus_Rule5_Question=" + Str_Bus_Rule5_Question + "<BR>");
        Str_rad_q_BR5 = Request.Form["Str_rad_q_BR5"];
        //Response.Write("Str_rad_q_BR5=" + Str_rad_q_BR5 + "<BR>");

        Str_Bus_Rule6_Question = Request.Form["Str_Bus_Rule6_Question"];
        //Response.Write("Str_Bus_Rule6_Question=" + Str_Bus_Rule6_Question + "<BR>");
        Str_rad_q_BR6 = Request.Form["Str_rad_q_BR6"];
        // Response.Write("Str_rad_q_BR6=" + Str_rad_q_BR6 + "<BR>");

        Str_Bus_Rule7_Question = Request.Form["Str_Bus_Rule7_Question"];
        // Response.Write("Str_Bus_Rule7_Question=" + Str_Bus_Rule7_Question + "<BR>");
        Str_rad_q_BR7 = Request.Form["Str_rad_q_BR7"];
        //Response.Write("Str_rad_q_BR7=" + Str_rad_q_BR7 + "<BR>");

        Str_Bus_Rule28_Question = Request.Form["Str_Bus_Rule28_Question"];
        // Response.Write("Str_Bus_Rule28_Question=" + Str_Bus_Rule28_Question + "<BR>");
        Str_rad_q_BR28 = Request.Form["Str_rad_q_BR28"];
        // Response.Write("Str_rad_q_BR28=" + Str_rad_q_BR28 + "<BR>");

        Str_Manager_Title = Request.Form["Str_Manager_Title"];
        //Response.Write("Str_Manager_Title=" + Str_Manager_Title + "<BR>");
        Str_txt_Manager_name = Request.Form["Str_txt_Manager_name"];
        //Response.Write("Str_txt_Manager_name=" + Str_txt_Manager_name + "<BR>");
        Old_Visit_Date = Request.Form["Old_Visit_Date"];
        // Response.Write("Old_Visit_Date=" + Old_Visit_Date);
        Str_Sv_Panel_id = Request.Form["Str_Sv_Panel_id"];
        //**************** Delete Data into temp table
        Get_CallFormDataDelete(Job_No, Wave_No, Task_No, store_id, Str_Merch_no);
                       
        //************** All the questions and types are in the array
 
        //ArrayAllQuestions = new string[100];

        ArrayAllQuestionsElement = Request.Form["ArrayAllQuestionsElement"];
        //Response.Write("ArrayAllQuestionsElement=" + ArrayAllQuestionsElement + "<BR>");
 
        string[] ArrayQuestions;
        string[] ArrayEle;
        //int i;
        //ArrayAddress = new string[3];
        ArrayQuestions = ArrayAllQuestionsElement.Split("|".ToCharArray());

        string EachElement, Q_no, Ans_type, ElementAnswer, StrElement, DollarVal, CentVal, FeetVal, IncheVal, HourVal, MinuteVal, StrAnswers, DataReady;
        int Arraylen, StrLen, Var_Max_Val, StrResult;

        decimal CalMeasurement, CalNum, CalMinute;
        string Strdata8, Strdata7, Strdata6, Strdata5, Strdata4, Strdata3, Strdata2, Strdata1, Ans_Value, ID_Name, StrAnswer, StrCount, Strflag1, Strflag2, Strflag3, Strflag4, Strflag5, Strflag6, Strflag7, Strflag8;
   
        Strflag1 = "";
        Strflag2 = "";
        Strflag3 = "";
        Strflag4 = "";
        Strflag5 = "";
        Strflag6 = "";
        Strflag7 = "";
        Strflag8 = "";
        Strdata1 = "";
        Strdata2 = "";
        Strdata3 = "";
        Strdata4 = "";
        Strdata5 = "";
        Strdata6 = "";
        Strdata7 = "";
        Strdata8 = "";

        HiddenInsertQuestion = "";
        StrAnswers = "";
        ElementAnswer = "";
        Str_Response_val = "";
        Arraylen = ArrayQuestions.Length;
        Arraylen = Arraylen - 1;
        Var_Max_Val = 4000;
        DataReady = "No";
        
        //Response.Write("Arraylen=" + Arraylen + "<BR>");
        for (int i = 0; i < Arraylen; i++)
        {
           // StrAnswers = StrAnswers.Trim() + "AAL001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|BB";
             
                     
             
                    EachElement = ArrayQuestions[i];
                     //Response.Write("EachElementStart=" + EachElement + "<BR>");
                    ArrayEle = EachElement.Split("-".ToCharArray());
                    Q_no=ArrayEle[0];
                    Ans_type = ArrayEle[1];
                     // Response.Write("Q_no=" + Q_no + "<BR>");
                     // Response.Write("Ans_type=" + Ans_type + "<BR>");
                   
                    //***** Radio Buttons
               
                    if (Ans_type == "R" || Ans_type == "L")
                    {                  
                        StrElement = "ctl00$ContentPlaceHolder1$rad_qno" + Q_no + "";
                        ElementAnswer = Request.Form["" + StrElement + ""];
                       // Response.Write("ElementAnswerR=" + ElementAnswer + "<BR>");
                         //Response.Write("R=" + Ans_type + "<BR>");

                        //ElementAnswer = "wewqe3eq";
                    }
                    //***** Textboxes
                    if (Ans_type == "N")
                    {
                        StrElement = "ctl00$ContentPlaceHolder1$txt_num" + Q_no + "";
                        ElementAnswer = Request.Form["" + StrElement + ""];
                         //Response.Write("ElementAnswerN=" + ElementAnswer + "<BR>");

                    }
                    if (Ans_type == "T")
                    {
                        StrElement = "ctl00$ContentPlaceHolder1$txt_txt" + Q_no + "";
                        ElementAnswer = Request.Form["" + StrElement + ""];
                       //Response.Write("ElementAnswerT=" + ElementAnswer + "<BR>");
                        if (string.IsNullOrEmpty(ElementAnswer) == false)
                        {
                            ElementAnswer = ElementAnswer.Replace("|", " ");
                            //ElementAnswer = ElementAnswer.Replace("\n", " ");  
 
                        }
                    }
                    if (Ans_type == "D")
                    {
                        StrElement = "ctl00$ContentPlaceHolder1$txt_dat" + Q_no + "";
                        ElementAnswer = Request.Form["" + StrElement + ""];
                         //Response.Write("ElementAnswerD=" + ElementAnswer + "<BR>");
                        //ElementAnswer = "wewqe3eq";
                    }
            
                    if (Ans_type == "P")
                    {
                        //Dollar
                        StrElement = "ctl00$ContentPlaceHolder1$txt_Dol" + Q_no + "";
                        DollarVal = Request.Form["" + StrElement + ""];
                       
                         //Response.Write("ElementAnswerP=" + ElementAnswer + "<BR>");
                        //Cent
                        StrElement = "ctl00$ContentPlaceHolder1$txt_Cen" + Q_no + "";
                         CentVal = Request.Form["" + StrElement + ""];
                         
                         //Response.Write("ElementAnswerP=" + ElementAnswer + "<BR>");

                        if ((string.IsNullOrEmpty(DollarVal) == false) && (string.IsNullOrEmpty(CentVal) == false))
                        {
                            DollarVal = DollarVal.Trim();
                            CentVal = CentVal.Trim();
                            ElementAnswer = "" + DollarVal + "." + CentVal + "";
                            ElementAnswer = ElementAnswer.Trim();
                        }
                        else
                        {
                            ElementAnswer = "";
                        }
                        //Response.Write("P=" + Ans_type + "<BR>");
                    }
                    if (Ans_type == "H")
                    {
                        //Hour
                        StrElement = "ctl00$ContentPlaceHolder1$txt_Hou" + Q_no + "";
                         HourVal = Request.Form["" + StrElement + ""];
                         
                          //Response.Write("HourVal=" + HourVal + "<BR>");
                        //Minute
                        StrElement = "ctl00$ContentPlaceHolder1$txt_Min" + Q_no + "";
                        MinuteVal = Request.Form["" + StrElement + ""];
                       
                         //Response.Write("MinuteVal=" + MinuteVal + "<BR>");
                         if ((string.IsNullOrEmpty(HourVal) == false) && (string.IsNullOrEmpty(MinuteVal) == false))
                         {
                             HourVal = HourVal.Trim();
                             MinuteVal = MinuteVal.Trim();
                             //Response.Write("H=" + Ans_type + "<BR>");
                             CalMinute = ((Convert.ToDecimal(MinuteVal) / 60) * 100);
                             //Response.Write("CalMinute=" + CalMinute + "<BR>");
                             CalNum = Math.Round(CalMinute, 0);

                             ElementAnswer = "" + HourVal + "." + CalNum + "";
                             ElementAnswer = ElementAnswer.Trim();
                         }
                         else
                         {
                             ElementAnswer = "";   
                         }
                            //Response.Write("HourValElementAnswer=" + ElementAnswer + "<BR>");
                       
                    }
                    if (Ans_type == "M")
                    {
                        //feet
                        StrElement = "ctl00$ContentPlaceHolder1$txt_Fee" + Q_no + "";
                        FeetVal = Request.Form["" + StrElement + ""];
                         //Response.Write("FeetVal=" + FeetVal + "<BR>");
                        
                        //Inche
                        StrElement = "ctl00$ContentPlaceHolder1$txt_Inc" + Q_no + "";
                        IncheVal  = Request.Form["" + StrElement + ""];
                         //Response.Write("IncheVal=" + IncheVal + "<BR>");
                        //Response.Write("MeasurementValued=" + Convert.ToInt32(MeasurementValue) + "<BR>");
                        
                        //Response.Write("IncheVald=" + Convert.ToInt32(IncheVal) + "<BR>");
                         if ((string.IsNullOrEmpty(FeetVal) == false) && (string.IsNullOrEmpty(IncheVal) == false))
                         {
                             FeetVal = FeetVal.Trim();
                             IncheVal = IncheVal.Trim();
                             CalMeasurement = ((Convert.ToDecimal(IncheVal) / Convert.ToDecimal(MeasurementValue)) * 100);
                             CalNum = Math.Round(CalMeasurement, 0);

                             ElementAnswer = "" + FeetVal + "." + CalNum + "";
                            // ElementAnswer = ElementAnswer.Trim();
                         }
                         else
                         {
                             ElementAnswer = "";   
                         }
                         //Response.Write("MeasureElementAnswer=" + ElementAnswer + "<BR>");
                    }
                    //***** Checkboxes
                    if (Ans_type == "C")
                    {
                        
                         StrElement = "ctl00$ContentPlaceHolder1$chk_qno" + Q_no + "";
                         ElementAnswer = Request.Form["" + StrElement + ""];
                         
                         // Response.Write("ElementAnswerC=" + ElementAnswer + "<BR>");
                         
                         //Response.Write("C=" + ElementAnswer + "<BR>");

                          string[] ArrayCheckBox;
                          int w;

                          if (string.IsNullOrEmpty(ElementAnswer) == false)
                          {
                                      ArrayCheckBox = ElementAnswer.Split(",".ToCharArray());
                                      //Response.Write("Alen=" + ArrayCheckBox.Length + "<BR>");
                                      
                                      for (w = 0; w < ArrayCheckBox.Length; w++)
                                      {
                                          
                                          ElementAnswer = ArrayCheckBox[w];
                                          //ElementAnswer=ElementAnswer.Substring(0, 1);
                                          ElementAnswer = ElementAnswer.Trim();
                                         //StrAnswers = "Q_no=" + Q_no + ",Ans_type=" + Ans_type + ",ElementAnswer=" + ElementAnswer + "|||";
                                          Str_Response_val = "" + Ans_type + "" + Q_no + "_null," + ElementAnswer + "";
                                          StrAnswers = StrAnswers.Trim() + Str_Response_val.Trim() + "|";

                                         // Response.Write("StrAnswers=" + StrAnswers + "<BR>");
                                          //if (Lang_id == 1)
                                          //{
                                             // DataTable dt23 = Get_CallFormTempDataInsert(Job_No, Wave_No, Task_No, store_id, Str_Merch_no, Q_no, Ans_type, ElementAnswer);
                                             // Count_Message = dt23.Rows[0][0].ToString();
                                             // return_Message = dt23.Rows[0][1].ToString();
                                             //// Response.Write("Count_Message=" + Count_Message + "<BR>");
                                             //// Response.Write("return_Message=" + return_Message + "<BR>");
                                             // if (Count_Message != "9999999")
                                             // {

                                             //     Update.Visible = false;
                                             //     Label11.Visible = false;
                                             //     Label1.Visible = false;
                                             //     Label2.Visible = false;
                                             //     BackBnt.Visible = true;
                                             //     MessageLab1.Visible = true;

                                             //     break;
                                             // }
                                          //}
                                          //else
                                          //{
                                          //    Get_CallFormTempDataInsert(Job_No, Wave_No, Task_No, store_id, Str_Merch_no, Q_no, Ans_type, ElementAnswer);
                                          //}
                                      }
                          }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(ElementAnswer) == false)
                        {
                            //**************** Insert Data into temp table
                            ElementAnswer = ElementAnswer.Trim();
                         // StrAnswers = "Q_no=" + Q_no + ",Ans_type=" + Ans_type + ",ElementAnswer=" + ElementAnswer + "|||";
                          // Response.Write("StrAnswers=" + StrAnswers + "<BR>");
                           // Get_CallFormTempDataInsert(Job_No, Wave_No, Task_No, store_id, Str_Merch_no, Q_no, Ans_type, ElementAnswer);
                            //Response.Write("StrAnswers=" + StrAnswers + "<BR>");
                            //if (Lang_id == 1)
                            //{
                                Str_Response_val = "" + Ans_type + "" + Q_no + "_null," + ElementAnswer + "";
                                StrAnswers = StrAnswers.Trim() + Str_Response_val.Trim() + "|";
                               
                                //DataTable dt22 = Get_CallFormTempDataInsert(Job_No, Wave_No, Task_No, store_id, Str_Merch_no, Q_no, Ans_type, ElementAnswer);

                                //Count_Message = dt22.Rows[0][0].ToString();
                                //return_Message = dt22.Rows[0][1].ToString();
                                // //Response.Write("Count_Message=" + Count_Message + "<BR>");
                                // //Response.Write("return_Message=" + return_Message + "<BR>");
                                //if (Count_Message != "9999999")
                                //{
                                //    //Response.Write("ssdasda=" + return_Message + "<BR>");
                                //    Update.Visible = false;
                                //    Label11.Visible = false;
                                //    Label1.Visible = false;
                                //    Label2.Visible = false;
                                //    BackBnt.Visible = true;
                                //    MessageLab1.Visible = true;

                                //    break;
                                //}
                            //}
                            //else
                            //{
                            //    Get_CallFormTempDataInsert(Job_No, Wave_No, Task_No, store_id, Str_Merch_no, Q_no, Ans_type, ElementAnswer);
                            //}
                        }

                        //StrAnswers = StrAnswers.Trim() + "DDL001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|L001_null,1|N002_null,2|R003_null,1|C004_null,1|C004_null,2|C004_null,3|L005_null,0|EE";
             
                    }
                    StrLen = StrAnswers.Length;

                    StrResult = Var_Max_Val - StrLen;
                    //Response.Write("Var_Max_Val=" + Var_Max_Val + "<BR>");
                    //Response.Write("StrLen=" + StrLen + "<BR>");
                    //Response.Write("StrResult=" + StrResult + "<BR>");
                    if (StrResult < 200)
                    {
                        DataReady = "YES";
                        Var_Max_Val = 4000;
                    }
                    //Response.Write("StrResult=" + StrResult + "<BR>");
                    //Response.Write("DataReady=" + DataReady + "<BR>");
                   //Response.Write("StrAnswers=" + StrAnswers + "<BR>");
                    if (string.IsNullOrEmpty(StrAnswers) == false)
                    {
                        HiddenInsertQuestion = HiddenInsertQuestion + StrAnswers;
                    }
                    if (DataReady == "YES")
                    {
                        if (Strflag1 == "")
                        {
                           // Strdata1 = "A" + StrAnswers;
                            Strdata1 =StrAnswers;
                             //Response.Write("Strdata11=" + Strdata1 + "<BR>");
                            Strflag1 = "Done";
                            DataReady = "No";

                        }
                        if (Strflag2 == "" && DataReady == "YES" && Strflag1 == "Done")
                        {
                            Strdata2 =StrAnswers;
                             //Response.Write("Strdata21=" + Strdata2 + "<BR>");
                            Strflag2 = "Done";
                            DataReady = "No";
                        }
                        if (Strflag3 == "" && DataReady == "YES" && Strflag2 == "Done" && Strflag1 == "Done")
                        {
                            Strdata3 = StrAnswers;
                            //Response.Write("Strdata31=" + Strdata3 + "<BR>");
                            Strflag3 = "Done";
                            DataReady = "No";
                        }
                        if (Strflag4 == "" && DataReady == "YES" && Strflag3 == "Done" && Strflag2 == "Done" && Strflag1 == "Done")
                        {
                            Strdata4 = StrAnswers;
                            Strflag4 = "Done";
                            DataReady = "No";
                        }
                        if (Strflag5 == "" && DataReady == "YES" && Strflag4 == "Done" && Strflag3 == "Done" && Strflag2 == "Done" && Strflag1 == "Done")
                        {
                            Strdata5 = StrAnswers;
                            Strflag5 = "Done";
                            DataReady = "No";
                        }
                        if (Strflag6 == "" && DataReady == "YES" && Strflag5 == "Done" && Strflag4 == "Done" && Strflag3 == "Done" && Strflag2 == "Done" && Strflag1 == "Done")
                        {
                            Strdata6 = StrAnswers;
                            Strflag6 = "Done";
                            DataReady = "No";
                        }
                        if (Strflag7 == "" && DataReady == "YES" && Strflag6 == "Done" && Strflag5 == "Done" && Strflag4 == "Done" && Strflag3 == "Done" && Strflag2 == "Done" && Strflag1 == "Done")
                        {
                            Strdata7 = StrAnswers;
                            Strflag7 = "Done";
                            DataReady = "No";
                        }
                        if (Strflag8 == "" && DataReady == "YES" && Strflag7 == "Done" && Strflag6 == "Done" && Strflag5 == "Done" && Strflag4 == "Done" && Strflag3 == "Done" && Strflag2 == "Done" && Strflag1 == "Done")
                        {
                            Strdata8 = StrAnswers;
                            Strflag8 = "Done";
                            DataReady = "No";
                        }
                        StrAnswers = "";
                    }  
        }
        if (Strflag1 == "")
        {
            Strdata1 = StrAnswers;
            StrAnswers = "";
        }
        if (Strflag2 == "")
        {
            Strdata2 = StrAnswers;
            StrAnswers = "";
        }
        if (Strflag3 == "")
        {
            Strdata3 = StrAnswers;
            StrAnswers = "";
        }
        if (Strflag4 == "")
        {
            Strdata4 = StrAnswers;
            StrAnswers = "";
        }
        if (Strflag5 == "")
        {
            Strdata5 = StrAnswers;
            StrAnswers = "";
        }
        if (Strflag6 == "")
        {
            Strdata6 = StrAnswers;
            StrAnswers = "";
        }
        if (Strflag7 == "")
        {
            Strdata7 = StrAnswers;
            StrAnswers = "";
        }
        if (Strflag8 == "")
        {
            Strdata8 = StrAnswers;
            StrAnswers = "";
        }
        //Response.Write("Strdata1=" + Strdata1 + "<BR>");
        //Response.Write("Strdata2=" + Strdata2 + "<BR>");
        //Response.Write("Strdata3=" + Strdata3 + "<BR>");
        //Response.Write("Strdata4=" + Strdata4 + "<BR>");
        //Response.Write("Strdata5=" + Strdata5 + "<BR>");
        //Response.Write("Strdata6=" + Strdata6 + "<BR>");
        //Response.Write("Strdata7=" + Strdata7 + "<BR>");
        //Response.Write("Strdata8=" + Strdata8 + "<BR>");

        DataTable dt30  = Get_JWT_CallForm_TempData(Lang_id, Job_No, Wave_No, Task_No, store_id, Str_Merch_no, Strdata1, Strdata2, Strdata3, Strdata4, Strdata5, Strdata6, Strdata7, Strdata8);

        Count_Message = dt30.Rows[0][0].ToString();
        return_Message = dt30.Rows[0][1].ToString();
         //Response.Write("Count_Message=" + Count_Message + "<BR>");
         //Response.Write("return_Message=" + return_Message + "<BR>");
         if (Count_Message != "9999999")
         {
             Update.Visible = false;
             Label11.Visible = false;
             Label1.Visible = false;
             Label2.Visible = false;
             BackBnt.Visible = true;
             MessageLab1.Visible = true;
 
         }

         Photo_q_Matched_Status_flag = "";
         HC_Visit_Date = "0";
         DataTable dt23 = Get_Photo_q_Temp_dataCheck(Lang_id, Job_No, Wave_No, Task_No, Chain_No, Store_No, Str_Merch_no, HC_Visit_Date);
         // ds.Tables[0].Rows.Count
         Photo_q_Matched_Status_flag = dt23.Rows[0]["Photo_q_Matched_Status_flag"].ToString();
        // Response.Write("Photo_q_Matched_Status_flag=" + Photo_q_Matched_Status_flag + "<BR>");
    }
    #region SystemPromptandRule

    private void GetPromptTranslation()
    {
        vPrompts = new string[69];
        vPrompts[0] = "Internet Call Form";
        vPrompts[1] = "Date:";
        vPrompts[2] = "Job No.";
        vPrompts[3] = "Wave No.";
        vPrompts[4] = "Task No.";
        vPrompts[5] = "Chain No.";
        vPrompts[6] = "Store No.";
        vPrompts[7] = "Show Job Information";
        vPrompts[8]="Page Number";
        vPrompts[9]="Product";
        vPrompts[10]="Questions successfully Uploaded!";
        vPrompts[11]="Page Number";
        vPrompts[12]="Product List";
        vPrompts[13]="Next Product";
        vPrompts[14]="Click next to receive your confirmation number.";
        vPrompts[15]="Next";
        vPrompts[16]="(If you are done with a Call Form then please click NEXT)";
        vPrompts[17]="The Information for Next Product for this Job, Wave, task, store, and Chain can not be access at this time.";
        vPrompts[18]= "Please try after an hour.!";
        vPrompts[19]= "2001 SPAR Group, Inc.";
        vPrompts[20]= "All Rights Reserved.";
        vPrompts[21]="The Information for this Job, Wave, and task cannot be access at this time.";
        vPrompts[22]="Please logout and log back in again after an hour.";
        vPrompts[23] = "If you are still having problems please call your DMM.!";
        vPrompts[24] = "2001 SPAR Group, Inc. ";
        vPrompts[25] = "All Rights Reserved.";
        vPrompts[26] = "The Information for this Job, Wave, and task cannot be access at this time.";
        vPrompts[27] = "Please logout and log back in again after an hour.";
        vPrompts[28] = "If you are still having problems please call your DMM.!";
        vPrompts[29] = "Ans";
        vPrompts[30] = "Back";
        vPrompts[31] = "Dollar(s)";
        vPrompts[32] = "Cent(s)";
        vPrompts[33] = "Feet(s)";
        vPrompts[34] = "Inche(s)";
        vPrompts[35] = "Hour(s)";
        vPrompts[36] = "Minute(s)";
        vPrompts[37] = "Save";
        vPrompts[38] = "Print";

        vPrompts[39] = "The question";//0
        vPrompts[40] = "has to be numeric.";//1
        vPrompts[41] = "value has to be bigger or equal to";//2
        vPrompts[42] = "value has to be less or equal to";//3
        vPrompts[43] = "Please answer";//4
        vPrompts[44] = "Please enter a valid date for question";//5
        vPrompts[45] = "Please enter a valid Visit Date";//6
        vPrompts[46] = "You must enter both values for question";//7
        vPrompts[47] = "Dollar(s) value has to be numeric";//8
        vPrompts[48] = "Dollar(s) value can not have a period";//9
        vPrompts[49] = "Cent(s) value can not be bigger than 99 cent";//10
        vPrompts[50] = "Cent(s) value has to be numeric";//11
        vPrompts[51] = "Cent(s) value can not have a period";//12
        vPrompts[52] = "Feet(s) value has to be numeric";//13
        vPrompts[53] = "Feet(s) value can not have a period";//14
        vPrompts[54] = "Inche(s) value can not be bigger than 11";//15
        vPrompts[55] = "Inche(s) value can not be less than 0";//16
        vPrompts[56] = "Inche(s) value has to be numeric";//17
        vPrompts[57] = "Inche(s) value can not have a period";//18
        vPrompts[58] = "Hour(s) value has to be numeric";//19
        vPrompts[59] = "Hour(s) value can not have a period";//20
        vPrompts[60] = "Minute(s) value can not be bigger than 59";//21
        vPrompts[61] = "Minute(s) value can not be less than 0";//22
        vPrompts[62] = "Minute(s) value has to be numeric";//23
        vPrompts[63] = "Minute(s) value can not have a period";//24
        vPrompts[64] = "This is an incorrect response to this question.";//25
        vPrompts[65] = "Cent(s) value can not be less than zero.";//26
        vPrompts[66] = "must be a whole number.";//27
        vPrompts[67] = "Invalid value entered for question";//28
        vPrompts[68] = "value can not be less than 0";//29


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
#region Procedures
    private DataTable Get_JWT_CallForm_TempData(int Lang_id, String Job_No, String Wave_No, String Task_No, String Store_id, String Str_Merch_no, String Strdata1, String Strdata2, String Strdata3, String Strdata4, String Strdata5, String Strdata6, String Strdata7, String Strdata8)
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

        return AppData.Get_JWT_CallForm_TempDataClass(Lang_id, iTempJob_No, iTempWave_No, iTempTask_No, iTempStore_id, iTempMerch_no, Strdata1, Strdata2, Strdata3, Strdata4, Strdata5, Strdata6, Strdata7, Strdata8, WebAppClass.CurrentSQLDBConnection);
    }

    private DataTable Get_CallFormDataDelete(String Job_No, String Wave_No, String Task_No, String Store_id, String Str_Merch_no)
    {
        Int32 iTempMerchNo = 0;
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempStore_id = 0;


        iTempMerchNo = AppUtils.ConvertToInteger32(Str_Merch_no, 0);
        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempStore_id = AppUtils.ConvertToInteger32(Store_id, 0);
    

        return AppData.Get_CallFormDataDeleteTemp(iTempJob_No, iTempWave_No, iTempTask_No, iTempStore_id, iTempMerchNo, WebAppClass.CurrentSQLDBConnection);
    }
    //************* Function to insert the data
    private DataTable Get_CallFormTempDataInsert(String Job_No, String Wave_No, String Task_No, String Store_id, String Str_Merch_no, String Q_No, String Ans_type, String QuestionResponse)
    {
        Int32 iTempMerchNo = 0;
        Int32 iTempJob_No = 0;
        Int32 iTempWave_No = 0;
        Int32 iTempTask_No = 0;
        Int32 iTempStore_id = 0;


        iTempMerchNo = AppUtils.ConvertToInteger32(Str_Merch_no, 0);
        iTempJob_No = AppUtils.ConvertToInteger32(Job_No, 0);
        iTempWave_No = AppUtils.ConvertToInteger32(Wave_No, 0);
        iTempTask_No = AppUtils.ConvertToInteger32(Task_No, 0);
        iTempStore_id = AppUtils.ConvertToInteger32(Store_id, 0);
  
        return AppData.Get_CallFormTempDataInsertProcedure(iTempJob_No, iTempWave_No, iTempTask_No, iTempStore_id, iTempMerchNo, Q_No, Ans_type, QuestionResponse, WebAppClass.CurrentSQLDBConnection);

    }
    private DataTable Get_Photo_q_Temp_dataCheck(Int32 Lang_id, String Job_No, String Wave_No, String Task_No, String Chain_No, String Store_No, String Str_Merch_no, String Job_Visit_Date)
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

        return AppData.Get_USP_Photo_BYQ_Temp_dataCheck(Lang_id, iTempJob_No, iTempWave_No, iTempTask_No, iTempChain_No, iTempStore_No, iTempMerchNo, Job_Visit_Date, WebAppClass.CurrentSQLDBConnection);
    }
#endregion
}
