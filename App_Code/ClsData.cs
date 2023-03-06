using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;


/// <summary>
/// Summary description for ClsData
/// </summary>
public class ClsData
{
	public ClsData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

}
public class ClsCFJWTSData
{
    string StrMessage;

    public string ErrorMessage
    {
        get
        {
            return StrMessage;
        }
        set
        {
            StrMessage = value;
        }

    }
}
public class ClsCFJWTSDataRTS
{
    string StrMessage;

    public string ErrorMessage
    {
        get
        {
            return StrMessage;
        }
        set
        {
            StrMessage = value;
        }

    }
}