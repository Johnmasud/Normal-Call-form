<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false"  CodeFile="survey.aspx.cs" Inherits="survey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="App_Themes/LocalAppTheme/BIBar.css" type="text/css" rel="stylesheet" /><link href="App_Themes/LocalAppTheme/calender.css" type="text/css" rel="stylesheet" /><link href="App_Themes/LocalAppTheme/LocalAppTheme.css" type="text/css" rel="stylesheet" /></head>

</head>
<body >
    <form id="form1" runat="server">
    <script type="text/javascript"  language="javascript">
    function NextPage()
	{
	   window.open('','_parent','');
        window.close();
	   return true;	
	}
    </script>
    <div>
               <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%">
                        <input id="ctl00_SPARHeader1" type="hidden" name="ctl00$SPARHeader1$sparframeworkver" id="ctl00_SPARHeader1_sparframeworkver" value="100.0.0.1" /><table class="headertable">
	<tr>
		<td class="headerlogo" rowspan="2"><img id="ctl00_SPARHeader1_SPARLogo" src="https://app1.sparinc.com/includes/images/sparlogo/1/logoglobe.gif" style="height:70px;width:115px;border-width:0px;" /></td><td colspan="2" class="headeruserinfo"><table id="TableUserInfoDisplay" cellpadding="0" cellspacing="0" border="0" width="100%">
			<tr>
				<td align="right"><span id="ctl00_SPARHeader1_AppUserName_Label" class="labelmasterpage"></span><span id="ctl00_SPARHeader1_AppUserName" class="labelmasterpage">&nbsp; </span></td><td align="right" width="250"><span id="ctl00_SPARHeader1_AppDateTime_Label" class="labelmasterpage"></span><span id="ctl00_SPARHeader1_AppDateTime" class="labelmasterpage">&nbsp;</span></td>
			</tr>
		</table></td>
	</tr><tr>
		<td colspan="2" class="applicationnametd"><span id="ctl00_SPARHeader1_AppApplicationDisplay" class="labelapplicationnamemasterpage">Survey</span></td>
	</tr>
</table>
    </div>
    <center>
                
                <br />
                <br />
                 
                <br />
                <br />
                <input type="submit" name="ctl00$ContentPlaceHolder1$Update" value="Done" onclick="return NextPage();" id="ctl00_ContentPlaceHolder1_Update" class="Button" class="Button" />
                <br />
                <br />
                    
  </center>         
    </form>
</body>
</html>
