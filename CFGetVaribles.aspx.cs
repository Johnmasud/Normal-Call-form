using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SPAR.Tools.Security;
using SPAR.Tools.Utils;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class CFGetVaribles : System.Web.UI.Page
{
    SPARValues WebAppClass;
    PromptTranslation ptAppTranslation;
    protected string Str_Merch_no, SubmitPageName, RqData, Job_no, Wave_no, Task_no, Store_no, Chain_no, ProdData, AssemData, return_Error_Flag, Multi_visit_job_Flag, Old_Day, Old_Month, Old_Year, BrowserType;
    protected string Str_Http_URL, Str_HTTP_HOST, Current_URL, Str_SERVER_NAME, DCM_ServerName, DCM_PathName, ACM_ServerName, ACM_PathName, DCM_Url, ACM_Url, Bus_Rule_Url, Business_rule_link, Business_Type_id, DCM_ServerNameTest, DCM_PathNameTest, Var_DataCollectQueryString, Var_AssemblyQueryString, AccessToNewAssemblyApp_flag, AccessToNewDataCollectApp_flag;
    protected string uparm_Job_no, uparm_Wave_no, uparm_Task_no, uparm_Store_no, uparm_Chain_no, BusTypeid, Str_User_id, Merch_User, Spar_User, StrNewCallFormPathLink, Return_CallFormPath, DoneGoToCallForm, GoLiteVDt, ACM_ServerNameTest, ACM_PathNameTest;
    protected int Lang_id, Error_Message_Flag, URL_status;
    
    protected void Page_PreInit()
    {
        WebAppClass = new SPARValues();
        ptAppTranslation = new PromptTranslation("CFJWTInputs.aspx", WebAppClass.PromptsLanguageId.ToString(), WebAppClass.LanguageId, WebAppClass.CurrentSQLDBConnection, WebAppClass.MultiLanguageCount);
    }
        
    protected void Page_Load(object sender, EventArgs e)
    {

       // Response.End();
        WebAppClass.Set_MerchforForm(this.Merch_no, Convert.ToString(WebAppClass.MerchNo));
        Str_Merch_no = Convert.ToString(WebAppClass.MerchNo);
       //Response.Write("<BR>Str_Merch_no=" + Str_Merch_no + "<BR>");
        if ((Str_Merch_no == "0") || (Str_Merch_no == "") || (string.IsNullOrEmpty(Str_Merch_no) == true))
        {
            Str_Merch_no = "95057";
        }



        Lang_id = WebAppClass.LanguageId;
       // Response.Write("<BR>Lang_id=" + Lang_id + "<BR>");
       // Lang_id = 1;
        Str_User_id = WebAppClass.LoggedUserId;
        Merch_User = "";
        Spar_User = "";

        BrowserType = Request.Browser.Browser.ToString();

      //  Response.Write("<BR>BrowserType=" + BrowserType + "<BR>");

        RqData = Request.QueryString.ToString();
        //RqData = "Job_no = 101449 & Wave_no = 101449 & Task_no = 101449 & Store_no = 11 & Chain_no = 2821 & ProdData = Y & AssemData ="; 
        //Response.Write("RqData=" + RqData);

        Job_no = Request.QueryString["Job_no"];
        // Response.Write("Job_no=" + Job_no);
        Wave_no = Request.QueryString["Wave_no"];
        Task_no = Request.QueryString["Task_no"];
        Store_no = Request.QueryString["Store_no"];
        Chain_no = Request.QueryString["Chain_no"];
        ProdData = Request.QueryString["ProdData"];
        AssemData = Request.QueryString["AssemData"];
        BusTypeid = Request.QueryString["BusTypeid"];
        GoLiteVDt = Request.QueryString["GoLiteVDt"];
        //Response.Write("<BR>BusTypeid=" + BusTypeid + "<BR>");
        if (Job_no == "240005")
        {
             AssemData = "Y"; 
        }

        Str_Http_URL = Request.ServerVariables["URL"];
       // Response.Write("<BR>Str_Http_URL=" + Str_Http_URL + "<BR>");

        Str_HTTP_HOST = Request.ServerVariables["HTTP_HOST"];
        // Response.Write("<BR>Str_HTTP_HOST=" + Str_HTTP_HOST + "<BR>");


        Current_URL = "http://" + Str_HTTP_HOST.Trim() + "" + Str_Http_URL.Trim() + "";
        //Response.Write("<BR>Current_URL=" + Current_URL + "<BR>");

        Str_SERVER_NAME = Request.ServerVariables["SERVER_NAME"];
        // Response.Write("<BR>Str_SERVER_NAME=" + Str_SERVER_NAME + "<BR>");

        DCM_ServerName = ConfigurationManager.AppSettings["DataCollectionServer"];
       // Response.Write("DCM_ServerName=" + DCM_ServerName);
        DCM_PathName = ConfigurationManager.AppSettings["DataCollectionPath"];
        // Response.Write("DCM_PathName=" + DCM_PathName);

        DCM_ServerNameTest = ConfigurationManager.AppSettings["DataCollectionServerTest"];
      //  Response.Write("DCM_ServerNameTest=" + DCM_ServerNameTest + "<BR>");
        DCM_PathNameTest = ConfigurationManager.AppSettings["DataCollectionPathTest"];
        //Response.Write("DCM_PathNameTest=" + DCM_PathNameTest + "<BR>");

        ACM_ServerName = ConfigurationManager.AppSettings["AssemblyCollectionServer"];
       //  Response.Write("ACM_ServerName=" + DCM_ServerName);
        ACM_PathName = ConfigurationManager.AppSettings["AssemblyCollectionPath"];
        //Response.Write("ACM_PathName=" + ACM_PathName);
        StrNewCallFormPathLink = ConfigurationManager.AppSettings["NewCallFormPathLink"];
        //Response.Write("StrNewCallFormPathLink=" + StrNewCallFormPathLink);

        ACM_ServerNameTest = ConfigurationManager.AppSettings["AssemblyCollectionServerTest"];
        //  Response.Write("ACM_ServerName=" + DCM_ServerName);
        ACM_PathNameTest = ConfigurationManager.AppSettings["AssemblyCollectionPathTest"];

        DoneGoToCallForm = "http://" + Str_SERVER_NAME.Trim() + "" + Str_Http_URL.Trim() + "";
        DoneGoToCallForm = DoneGoToCallForm.Replace("CFGetVaribles", "CFJWTValidateSV");


        //**********************************************submit*****************************************

        SubmitPageName = "";

        DataTable dt = Get_CFJWTMultiVisit_validation(Lang_id, Str_Merch_no, Job_no, Wave_no, Task_no, Chain_no, Store_no);
        //Error_Message = dt.Rows[0][0].ToString();

        Error_Message_Flag = dt.Columns.Count;
       // Response.Write("Error_Message_Flag=" + Error_Message_Flag);

        if (Error_Message_Flag == 1)
        {

            SubmitPageName = "CFJWTValidateSV.aspx";
        }
        else
        {
            Multi_visit_job_Flag = dt.Rows[0]["Multi_visit_job"].ToString();
            return_Error_Flag = dt.Rows[0]["return_Error"].ToString();
            Old_Day = dt.Rows[0]["Old_Day"].ToString();
            Old_Month = dt.Rows[0]["Old_Month"].ToString();
            Old_Year = dt.Rows[0]["Old_Year"].ToString();
            AccessToNewAssemblyApp_flag = dt.Rows[0]["AccessToNewAssemblyApp"].ToString();
            AccessToNewDataCollectApp_flag = dt.Rows[0]["AccessToNewDataCollectApp"].ToString();
          // Response.Write("AccessToNewAssemblyApp_flag=" + AccessToNewAssemblyApp_flag + "<BR>");
           // Response.Write("AccessToNewDataCollectApp_flag=" + AccessToNewDataCollectApp_flag + "<BR>");
            //Response.Write("Multi_visit_job=" + Multi_visit_job_Flag + "<BR>");
            // Response.Write("return_Error_Flag=" + return_Error_Flag + "<BR>");
            //   Response.Write("Old_Day=" + Old_Day + "<BR>");
            //    Response.Write("Old_Month=" + Old_Month + "<BR>");
            //  Response.Write("Old_Year=" + Old_Year + "<BR>");
            if (BrowserType == "InternetExplorer")
            {
                AccessToNewAssemblyApp_flag = "N";
            }
          //  Response.Write("AccessToNewAssemblyApp_flagAfter=" + AccessToNewAssemblyApp_flag + "<BR>");
            //Response.Write("BusTypeidBefore=" + BusTypeid + "<BR>");
              if (Lang_id == 1)
              {
                  if (string.IsNullOrEmpty(BusTypeid) == true)
                  {
                      BusTypeid = dt.Rows[0]["Business_Type_id"].ToString();
                  }
              }
              if (Lang_id == 13)
              {
                  if (string.IsNullOrEmpty(BusTypeid) == true)
                  {
                      BusTypeid = dt.Rows[0]["Business_Type_id"].ToString();
                  }
              }

             //Response.Write("BusTypeid=" + BusTypeid + "<BR>");
             //Response.End();
            //Context.Items["Old_Day"] = Old_Day;
            // Context.Items["Old_Month"] = Old_Month;
            //  Context.Items["Old_Year"] = Old_Year;

            StrOld_Day.Value = Old_Day;
            StrOld_Month.Value = Old_Month;
            StrOld_Year.Value = Old_Year;

            if (Multi_visit_job_Flag == "Y" && return_Error_Flag == "0")
            {

                SubmitPageName = "CFJWT_Input_Photo_Option.aspx";
            }
            else
            {

                SubmitPageName = "CFJWTValidateSV.aspx";
            }

        }
        SubmitToNextPage.Value = SubmitPageName;

        //For business rules
        Boolean StrServerhas;
        string Domain1, Domain2, Domain3;
        string[] ArraySERVER_NAME;
        //Str_SERVER_NAME="dev2k3.sparinc.com";
        Bus_Rule_Url = "";
        StrServerhas = Str_SERVER_NAME.Contains("com");
 
        if (StrServerhas == false)
        {
            Bus_Rule_Url = "http://mi11.sparinc.com/pdcs/index.asp";
        }
        else
        {
            ArraySERVER_NAME = Str_SERVER_NAME.Split(".".ToCharArray());

            Domain1 = ArraySERVER_NAME[0];
            Domain2 = ArraySERVER_NAME[1];
            Domain3 = ArraySERVER_NAME[2];
           //  Response.Write("Domain1=" + Domain1);
       // Response.Write("Domain2=" + Domain2);
    //   Response.Write("Domain3=" + Domain3 + "<BR>");
            // Response.Write("Business_rule_link222=" + Business_rule_link);
            //RTS_Url = "http://mi23.sparinc.com/itsnet/its_IssueAddNext.aspx";

            Return_CallFormPath = StrNewCallFormPathLink;

            if (ProdData == "Y")
            {

                //old
                Bus_Rule_Url = "http://" + DCM_ServerName.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "" + DCM_PathName + "";
                // Response.Write("Bus_Rule_Url1=" + Bus_Rule_Url);
                //new
                if (AccessToNewDataCollectApp_flag == "Y")
                {

                    Bus_Rule_Url = "http://" + DCM_ServerNameTest.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "" + DCM_PathNameTest + "";
                    // Response.Write("Bus_Rule_Url5555=" + Bus_Rule_Url + "<BR>");
                    Var_DataCollectQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_no + "&Store_no=" + Store_no + "&Job_no=" + Job_no + "&Wave_no=" + Wave_no + "&Task_no=" + Task_no + "&DoneGoToCallForm='" + DoneGoToCallForm + "'&NewScreenPage=Y";
                    // Var_AssemblyQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_no + "&Store_no=" + Store_no + "&Job_no=" + Job_no + "&Wave_no=" + Wave_no + "&Task_no=" + Task_no + "&BusTypeid=" + Business_Type_id + "&DoneGoToCallForm='" + Return_CallFormPath + "'&NewScreenPage=Y";
                    Bus_Rule_Url = Bus_Rule_Url + "" + Var_DataCollectQueryString;
                }


            }
            if (AssemData == "Y")
            {
                Bus_Rule_Url = "http://" + ACM_ServerName.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "" + ACM_PathName + "";
               // Response.Write("Bus_Rule_Url2=" + Bus_Rule_Url);
                if (AccessToNewAssemblyApp_flag == "Y")
                {
                    Bus_Rule_Url = "http://" + ACM_ServerNameTest.Trim() + "." + Domain2.Trim() + "." + Domain3.Trim() + "" + ACM_PathNameTest + "";
                    Var_AssemblyQueryString = "?Merch_no=" + Str_Merch_no + "&Chain_no=" + Chain_no + "&Store_no=" + Store_no + "&Job_no=" + Job_no + "&Wave_no=" + Wave_no + "&Task_no=" + Task_no + "&BusTypeid=" + BusTypeid + "&DoneGoToCallForm='" + DoneGoToCallForm + "'&NewScreenPage=Y";
                    Bus_Rule_Url = Bus_Rule_Url + "" + Var_AssemblyQueryString;
                }

            }
        }
       // Response.Write("Bus_Rule_Url1=" + Bus_Rule_Url);
        //CFJWTValidateSV.aspx
        //if (Lang_id == 4)
        //{
            Bus_Rule_Url = Bus_Rule_Url.Replace("http", "https");
            Return_CallFormPath = Return_CallFormPath.Replace("http", "https");
            DoneGoToCallForm = DoneGoToCallForm.Replace("http", "https");
            Current_URL = Current_URL.Replace("http", "https");
      //  }

        if (Lang_id != 1)
        {
            if (Lang_id != 13)
            {
                Return_CallFormPath = StrNewCallFormPathLink.Replace("webreportms", "sparinc");
                //ElementAnswer = ElementAnswer.Replace("\n", " "); 
            }
        }

        URL_status = Str_HTTP_HOST.IndexOf("sparinc");
       // Response.Write("<BR>URL_status=" + URL_status + "<BR>");
        if (URL_status > 0)
        {
            Return_CallFormPath = Return_CallFormPath.Replace("webreportms", "sparinc");
        }

       //Response.Write("Bus_Rule_Url=" + Bus_Rule_Url);
        Data_Collection_Path.Value = Bus_Rule_Url;
       

       // Job_no = "101449";
        // Response.Write("Job_no=" + Job_no);
       // Wave_no = "201338";
      //  Task_no = "53";
      //  Store_no = "10";
      //  Chain_no = "2821";
     //   ProdData = "";
      //  AssemData = "";
        AssemDataFlag.Value = AssemData;
        ProdDataFlag.Value = ProdData;
        GoLiteDate.Value = GoLiteVDt;
        Merch_no.Value = Str_Merch_no;
        Txt_merch_no.Value = Str_Merch_no;
        txt_jobno.Value = Job_no;
        txt_waveno.Value = Wave_no;
        txt_taskno.Value = Task_no;
        txt_chainno.Value = Chain_no;
        txt_storeno.Value = Store_no;

       
        Job_No.Value = Job_no;
        Wave_No.Value = Wave_no;
        Task_No.Value = Task_no;
        Chain_No.Value = Chain_no;
        Store_No.Value = Store_no;


        //For Prod data  
        fvar_msno.Value = Str_Merch_no;
        fvar_jobno.Value = Job_no;
        fvar_waveno.Value = Wave_no;
        fvar_taskno.Value = Task_no;
        fvar_chainno.Value = Chain_no;
        fvar_storeno.Value = Store_no;
        uparm_Job_no = Job_no;
        uparm_Wave_no = Wave_no;
        uparm_Task_no = Task_no;
        uparm_Store_no = Chain_no;
        uparm_Chain_no = Store_no;
        //For Assembly Data Collection
       // uparm_merch_no.Value = Str_Merch_no;
        //uparm_job_no.Value = Job_no;
       // uparm_wave_no.Value = Wave_no;
      //  uparm_task_no.Value = Task_no;
       // uparm_chain_no.Value = Chain_no;
       // uparm_store_no.Value = Store_no;
        //uparm_business_type_id.Value = "1";  
        Business_Type_id = BusTypeid;


       
    }

    #region Procedures
   
    private DataTable Get_CFJWTMultiVisit_validation(Int32 Lang_id, String Str_Merch_no, String Job_No, String Wave_No, String Task_No, String Chain_No, String Store_No)
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

        return AppData.Get_USP_JWT_MultiVisit_Validate(Lang_id, iTempStr_Merch_no, iTempJob_No, iTempWave_No, iTempTask_No, iTempChain_No, iTempStore_No, WebAppClass.CurrentSQLDBConnection);
    }
    #endregion
}
