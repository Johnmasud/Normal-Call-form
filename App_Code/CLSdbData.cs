using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SPAR.Tools.Security;
using SPAR.Tools.Utils;
/// <summary>
/// Summary description for CLSdbData
/// </summary>
public class CLSdbData
{
    SPARValues WebAppClass;
	public CLSdbData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<ClsCFJWTSData> GetCFJWTSDataList(Int32 Lang_id, Int32 Job_No, Int32 Wave_No, Int32 Task_No, Int32 Chain_No, Int32 Store_No, Int32 merch_no, String Job_Visit_Date, String TimeinDate, String TimeOutDate,String txt_driveTime)
    {
        // String DBConnStringCurrent;
        WebAppClass = new SPARValues();
        //WebAppClass.CurrentSQLDBConnection;

        List<ClsCFJWTSData> clsCFJWTSDataList2 = new List<ClsCFJWTSData>();


        //clsMerch_no = 95057;
        DataTable dt = new DataTable();
        //  DataTable dt1 = new DataTable();

        int i = 0;

        dt = AppData.Get_CFJWT_TimeVisitDateValidation(Lang_id, Job_No, Wave_No, Task_No, Chain_No, Store_No, merch_no, Job_Visit_Date,TimeinDate,TimeOutDate,txt_driveTime, WebAppClass.CurrentSQLDBConnection);

        foreach (DataRow myRow in dt.Rows)
        {
            ClsCFJWTSData info2 = new ClsCFJWTSData();
            info2.ErrorMessage = Convert.ToString(myRow["ErrorMessage"]);
            clsCFJWTSDataList2.Add(info2);
        }
        return clsCFJWTSDataList2;
    }
    public List<ClsCFJWTSDataRTS> GetCFJWTS_TimeCapList(Int32 Lang_id, Int32 prompt_lang_id, String Struser_id, Int32 Job_No, Int32 Wave_No, Int32 Task_No, Int32 Chain_No, Int32 Store_No, Int32 merch_no, String issue_text)
    {
        // String DBConnStringCurrent;
        WebAppClass = new SPARValues();
        //WebAppClass.CurrentSQLDBConnection;

        List<ClsCFJWTSDataRTS> clsCFJWTSDataList3 = new List<ClsCFJWTSDataRTS>();


        //clsMerch_no = 95057;
        DataTable dt1 = new DataTable();
        //  DataTable dt1 = new DataTable();

        int i = 0;

        dt1 = AppData.Get_CFJWT_RTSTiemCapValidation(Lang_id, prompt_lang_id, Struser_id, Job_No, Wave_No, Task_No, Chain_No, Store_No, merch_no, issue_text, WebAppClass.CurrentSQLDBConnection);

        foreach (DataRow myRow in dt1.Rows)
        {
            ClsCFJWTSDataRTS info2 = new ClsCFJWTSDataRTS();
            info2.ErrorMessage = Convert.ToString(myRow["ErrorMessage"]);
            clsCFJWTSDataList3.Add(info2);
        }
        return clsCFJWTSDataList3;
    }


}
