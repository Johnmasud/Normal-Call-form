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

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strvisitdate, Visit_Time2, Visit_Time1, Visit_time;
        DateTime Visit_Date2, Visit_Date1;

        strvisitdate = "24.2.2010";
        

        //************** Usa      mm/dd/yyyy
        Visit_Time1 = "2/24/2010 11:11 AM";
        Visit_Time2 = "2/24/2010 11:44 AM";
        //************** Lit      yyyy.mm.dd
        Visit_Time1 = "2/24/2010 11:11 AM";
        Visit_Time2 = "2/24/2010 11:44 AM";

        //************** Japan    yyyy/mm/dd
        //************** China    yyyy-mm-dd
        //************** india    dd/mm/yyyy
        //************** Canada   mm/dd/yyyy
        //************** Au       dd/mm/yyyy
        //************** Ro       dd.mm.yyyy
        //************** South af dd/mm/yyyy
        //************** Turkey   dd.mm.yyyy

        Response.Write("Visit_Time1=" + Visit_Time1 + "<BR>");
        Response.Write("Visit_Time2=" + Visit_Time2 + "<BR>");
 
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        //dateInfo.ShortDatePattern = "dd/MM/yyyy";
        //dateInfo.LongDatePattern = "dd.mm.yyyy";
        //**** USA
            dateInfo.ShortDatePattern = "MM/dd/yyyy";
        //**** USA
            dateInfo.ShortDatePattern = "MM/dd/yyyy";

        Visit_Date1 = Convert.ToDateTime(Visit_Time1, dateInfo);
        Visit_Date2 = Convert.ToDateTime(Visit_Time2, dateInfo);
        Visit_Date2 = Visit_Date2.AddDays(1);
         //Visit_Date2 = Convert.ToDateTime(Visit_Time2);
        Response.Write("Visit_Date1=" + Visit_Date1 + "<BR>");
        Response.Write("Visit_Date2=" + Visit_Date2 + "<BR>");

        TimeSpan diffDate = Visit_Date2.Subtract(Visit_Date1);
        Visit_time = diffDate.TotalMinutes.ToString();
         Response.Write("Visit_time=" + Visit_time + "<BR>");

        
    }
   
}
