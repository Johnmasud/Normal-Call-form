using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using SPAR.Tools.Security;
using SPAR.Tools.Utils;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.IO;
using System.Configuration;

/// <summary>
/// Summary description for WebService_Validation
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WebService_Validation : System.Web.Services.WebService {

    public WebService_Validation () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string CheckDataBaseFromJavascript(int Lang_id, int Job_No, int Wave_No, int Task_No, int Chain_No, int Store_No, int Merch_no, string Visit_Date, string TimeinDate, string TimeOutDate,string txt_driveTime)
    {
        int Classmerch_no, Classlang_id;
        String DBConnectionString;

        List<ClsCFJWTSData> clsCFJWTSDataList = new List<ClsCFJWTSData>();

        CLSdbData clsdbData = new CLSdbData();
        //clsCFJWTSDataList = clsdbData.GetCFJWTSDataList(1,101449,201521,1,2821,1,95057,"01/11/16","001","");

        clsCFJWTSDataList = clsdbData.GetCFJWTSDataList(Lang_id, Job_No, Wave_No, Task_No, Chain_No, Store_No, Merch_no, Visit_Date, TimeinDate, TimeOutDate,txt_driveTime);

        return new JavaScriptSerializer().Serialize(clsCFJWTSDataList);
        //return clsCFJWTSDataList.ToString();
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string CheckRTSTimeCapFromJavascript(int Lang_id, int prompt_lang_id, string Struser_id, int Job_No, int Wave_No, int Task_No, int Chain_No, int Store_No, int Merch_no, string issue_text)
    {
        int Classmerch_no, Classlang_id;
        String DBConnectionString;

        List<ClsCFJWTSDataRTS> clsCFJWTSRTSList = new List<ClsCFJWTSDataRTS>();

        CLSdbData clsdbData = new CLSdbData();
        //clsCFJWTSDataList = clsdbData.GetCFJWTSDataList(1,101449,201521,1,2821,1,95057,"01/11/16","001","");

        clsCFJWTSRTSList = clsdbData.GetCFJWTS_TimeCapList(Lang_id, prompt_lang_id, Struser_id, Job_No, Wave_No, Task_No, Chain_No, Store_No, Merch_no, issue_text);

        return new JavaScriptSerializer().Serialize(clsCFJWTSRTSList);
        //return clsCFJWTSDataList.ToString();
    }

}

