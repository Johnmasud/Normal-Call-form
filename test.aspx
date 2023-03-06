Output=240068,201117,1,4905299,99999,1,5/6/11,5/6/11 1:1 AM,5/6/11 1:34 AM,33,,0,,,W,N,1,Y,05/06/11 13:47:29,Assistant Manager,fdrdf,1,,jmasud,jmasud,172.16.8.122<BR>confirmation_no=1604775<BR>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>
	SPAR - Internet Call Form Input
</title><link href="App_Themes/LocalAppTheme/BIBar.css" type="text/css" rel="stylesheet" /><link href="App_Themes/LocalAppTheme/calender.css" type="text/css" rel="stylesheet" /><link href="App_Themes/LocalAppTheme/LocalAppTheme.css" type="text/css" rel="stylesheet" /></head>

<body onload="Load()">

    <form name="aspnetForm" method="post" action="CFConfirmation.aspx" id="aspnetForm">
<div>
<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUJNDA5MDgwOTgwD2QWAmYPZBYCAgMPZBYCAgUPZBYCAgUPDxYCHgRUZXh0BQcxNjA0Nzc1ZGRk" />
</div>

<script type="text/javascript">
//<![CDATA[
var theForm = document.forms['aspnetForm'];
if (!theForm) {
    theForm = document.aspnetForm;
}
function __doPostBack(eventTarget, eventArgument) {
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.__EVENTTARGET.value = eventTarget;
        theForm.__EVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
}
//]]>
</script>


<script language="JavaScript" type="text/javascript"> function swapbilingual(bicookiename,val) {Set_Cookie( bicookiename, val, '', '/', '', '' );}function Set_Cookie(name, value, expires, path, domain, secure) {var today = new Date();today.setTime(today.getTime());   if (expires) {expires = expires * 1 * 60 * 60 * 23;}var expires_date = new Date(today.getTime() + (expires));document.cookie = name + "=" + escape(value) +((expires) ? ";expires=" + expires_date.toGMTString() : "") +((path) ? ";path=" + path : "") +((domain) ? ";domain=" + domain : "") +((secure) ? ";secure" : "");}</script>
 <div>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%">
                        <table id="ctl00_SPARHeader1" class="headertable">
	<tr>
		<td class="headerlogo" rowspan="2"><img id="ctl00_SPARHeader1_SPARLogo" src="https://mi12.sparinc.com/includes/images/sparlogo/1/logoglobe.gif" style="height:70px;width:115px;border-width:0px;" /></td><td colspan="2" class="headeruserinfo"><table id="TableUserInfoDisplay" cellpadding="0" cellspacing="0" border="0" width="100%">
			<tr>
				<td align="right"><span id="ctl00_SPARHeader1_AppUserName_Label" class="labelmasterpage">User:</span><span id="ctl00_SPARHeader1_AppUserName" class="labelmasterpage">&nbsp;John Masud</span></td><td align="right" width="250"><span id="ctl00_SPARHeader1_AppDateTime_Label" class="labelmasterpage">Date:</span><span id="ctl00_SPARHeader1_AppDateTime" class="labelmasterpage">&nbsp;05/06/2011 01:47:38 PM</span></td>
			</tr>
		</table></td>
	</tr><tr>
		<td colspan="2" class="applicationnametd"><span id="ctl00_SPARHeader1_AppApplicationDisplay" class="labelapplicationnamemasterpage">Internet Call Form</span></td>
	</tr>
</table>
                    </td>
                </tr>
                <tr>
                    <td width="100%">
                        
                    </td>
                </tr>
                <tr>
                    <td width="100%"> 
<script type="text/javascript"  language="javascript">
function right(e) {
if (navigator.appName == 'Netscape' && (e.which == 3 || e.which == 2))
{
alert("Sorry, you do not have permission to right click.");
return false;
}
else if (navigator.appName == 'Microsoft Internet Explorer' && 
(event.button == 2 || event.button == 3)) {
alert("Sorry, you do not have permission to right click.");
return false;
}
return true;
}

document.onmousedown=right;
document.onmouseup=right;
if (document.layers) window.captureEvents(Event.MOUSEDOWN);
if (document.layers) window.captureEvents(Event.MOUSEUP);
window.onmousedown=right;
window.onmouseup=right;

function CheckGoBack(e) 
{
  var evt = e || window.event; 
 var keyCode = evt.charCode || evt.keyCode; 
//alert("keyCode=" + keyCode);
  if (keyCode==8)
    {
        return false;
    }

}

document.onkeydown = CheckGoBack;

function Load()
	{
	        //alert("Check=" + document.aspnetForm.JWTCheckBoxStatus.value) 
		    JWTCheckBoxStatus=document.aspnetForm.JWTCheckBoxStatus.value;
		    if (JWTCheckBoxStatus!="")
		        {
		          document.aspnetForm.showCheck.checked=true;  
		        }

		    
	            if (document.aspnetForm.showCheck.checked==false)
            			
			            {
				            document.aspnetForm.InformationDisplay.value=ShowDetail.innerHTML
				            ShowDetail.innerHTML=""
			            } 
	            else
			            {
				            document.aspnetForm.InformationDisplay.value=ShowDetail.innerHTML

			            } 			
	}
function GetDetail()
	{
	
	if (document.aspnetForm.showCheck.checked)
		{
		  //alert("StartArray1=" +   document.getElementById('ShowDetail').innerHTML)		 
		ShowDetail.innerHTML=document.aspnetForm.InformationDisplay.value
		//document.aspnetForm.InformationDisplay.value=ShowDetail.innerHTML
		}
		
	else
		{
		      //alert("StartArray1=" + ShowDetail.innerHTML)
		     //alert("StartArray2=" + document.aspnetForm.InformationDisplay.value)
			 document.aspnetForm.InformationDisplay.value=ShowDetail.innerHTML;
		
			ShowDetail.innerHTML="";
		} 
	}
function DisableButtons()
	{
	        //******* Disabled the buttons
		    
		    //*********** Button2 is NEXT
		     var ExistNext=document.getElementById("ctl00$ContentPlaceHolder1$Button1");
            if (ExistNext!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$Button1.disabled=true;
            }
            //*********** Update is NEXT
	        var ExistRTS=document.getElementById("ctl00$ContentPlaceHolder1$Update");
            if (ExistRTS!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$Update.disabled=true;  
            }
              //*********** Button2 is print
	        var ExistsPrint=document.getElementById("ctl00$ContentPlaceHolder1$Button2");
            if (ExistsPrint!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$Button2.disabled=true;  
            }
            
	}
function AbleButtons()
	{
	     
		    //*********** Button2 is NEXT
		     var ExistNext=document.getElementById("ctl00$ContentPlaceHolder1$Button1");
            if (ExistNext!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$Button1.disabled=false;
            }
            //*********** Update is NEXT
	        var ExistRTS=document.getElementById("ctl00$ContentPlaceHolder1$Update");
            if (ExistRTS!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$Update.disabled=false;  
            }
              //*********** Button2 is print
	        var ExistsPrint=document.getElementById("ctl00$ContentPlaceHolder1$Button2");
            if (ExistsPrint!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$Button2.disabled=false;  
            }
            
	}
		
function NextPage()
	{
	    DisableButtons()
	    document.aspnetForm.action = "CFJWTInputs.aspx";
	    document.aspnetForm.submit();
	    return true;	
	}
 
function GoToRTS()
	 {
	    DisableButtons()
		document.aspnetForm.action  = "http://mi23.sparinc.com/its/RTS_Merch_Inputs.asp";
		//document.frm_last.action  = "CFJWTInputs.asp";
		//document.TimeValidation.action  = "http://mitest.sparinc.com/its/RTS_Merch_Inputs.asp";
		document.aspnetForm.submit()
		return true
	 }	
function Goto_NewMarkInventory()
	{
	//for Report Your Newmark Inventory 
	//window.open("http://mi10.sparinc.com/NSBO_Manuals/NewDailyActivityResponseForm/DailyActivityResponseForm/DailyActivityResponseForm.htm","openwindow","width=700,height=350,left=0,top=0,toolbar=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes");
	window.open("http://newmark.vtcus.com","openwindow","width=700,height=350,left=0,top=0,toolbar=yes,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes");
	
	} 
function PrintPage(text)
{
    
	text=document
	print(text)
	//AbleButtons()
	return false;
}
</script>


<hr color="dodgerblue">

<table id="ctl00_ContentPlaceHolder1_Table2" border="0" style="border-color:DodgerBlue;border-width:0px;width:100%;">
	<tr>
		<td align="left"><table id="ctl00_ContentPlaceHolder1_Table3" border="0" style="border-color:DodgerBlue;border-width:0px;width:100%;">
			<tr>
				<td class="reportCriteriaHeader" style="width:10%;"><span id="ctl00_ContentPlaceHolder1_Label7" class="reportCriteriaHeader">Job No.</span></td><td class="selectionCriteriaItem" style="width:90%;">
                        :240068</td>
			</tr><tr>
				<td class="reportCriteriaHeader" style="width:10%;"><span id="ctl00_ContentPlaceHolder1_Label6" class="reportCriteriaHeader">Wave No.</span></td><td class="selectionCriteriaItem" style="width:90%;">
                        :201117</td>
			</tr><tr>
				<td class="reportCriteriaHeader" style="width:10%;"><span id="ctl00_ContentPlaceHolder1_Label3" class="reportCriteriaHeader">Task No.</span></td><td class="selectionCriteriaItem" style="width:90%;">
                       :1</td>
			</tr><tr>
				<td class="reportCriteriaHeader" style="width:10%;"><span id="ctl00_ContentPlaceHolder1_Label4" class="reportCriteriaHeader">Chain No.</span></td><td class="selectionCriteriaItem" style="width:90%;">
                        :2797</td>
			</tr><tr>
				<td class="reportCriteriaHeader" style="width:10%;"><span id="ctl00_ContentPlaceHolder1_Label5" class="reportCriteriaHeader">Store No.</span></td><td class="selectionCriteriaItem" style="width:90%;">
                       :108135</td>
			</tr>
		</table></td>
	</tr>
</table>

<hr color="dodgerblue">
<SPAN id="ShowDetail">
    <table border='1' id='TABLE1' borderColor='dodgerblue' bgcolor='mintcream' align='center' width='100%'> <tr><td  align='left' class='applicationnametd'><span class='reportTableHeader'>Job Information</span></td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align='left'>Job No.</td><td class='selectionCriteriaItem' width='85%' align=left>:240068  DBA - Palmer Installations</td></tr></table>	</td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Wave No.</td><td class='selectionCriteriaItem' width='85%' align=left>:201117  (FST DT:5/4/11- FEnd DT:5/18/11)</td></tr></table>	</td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Task No.</td><td class='selectionCriteriaItem' width='85%' align=left>:1  General Merchandising - DBA - Palmer Installations</td></tr></table>	</td></tr><tr><td  align='left' class='applicationnametd'> <span class='reportTableHeader'>Chain Information</span> </td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Chain No.</td><td class='selectionCriteriaItem' width='85%' align=left>:2797  </td></tr></table>	</td></tr></tr><tr><td  align='left' class='applicationnametd'> <span class='reportTableHeader'>Store Information</span> </td></tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Store No.</td><td class='selectionCriteriaItem' width='85%' align=left>:108135</td></tr></table>	</td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Store Name</td><td class='selectionCriteriaItem' width='85%' align=left>:JTS CHECK CASHI</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Address</td><td class='selectionCriteriaItem' width='85%' align=left>:21701 MERRICK BLVD</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>City</td><td class='selectionCriteriaItem' width='85%' align=left>:SPRINGFIELD GARDENS</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>State</td><td class='selectionCriteriaItem' width='85%' align=left>:NY</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Zip</td><td class='selectionCriteriaItem' width='85%' align=left>:114131900</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Phone No.</td><td class='selectionCriteriaItem' width='85%' align=left>:7185282855</td></tr></table></td></tr><tr>
</SPAN>
<table border="0" cellPadding="1" cellSpacing="1" width="100%">
	<TR>		
		<TD align="left" class="selectionCriteriaItem">	
			<input type="checkbox" name="showCheck"   onclick="GetDetail()"/>Show Job Information
																					   
		</TD>	
	</TR>
</table>

<input name="JWTCheckBoxStatus" type="hidden" value="Checked" />
<input name="InformationDisplay" type="hidden" value="" />	
<input name="DisplayJWTInfo" type="hidden" value="<table border='1' id='TABLE1' borderColor='dodgerblue' bgcolor='mintcream' align='center' width='100%'> <tr><td  align='left' class='applicationnametd'><span class='reportTableHeader'>Job Information</span></td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Job No.</td><td class='selectionCriteriaItem' width='85%' align=left>:240068  DBA - Palmer Installations</td></tr></table>	</td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Wave No.</td><td class='selectionCriteriaItem' width='85%' align=left>:201117  (FST DT:5/4/11- FEnd DT:5/18/11)</td></tr></table>	</td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Task No.</td><td class='selectionCriteriaItem' width='85%' align=left>:1  General Merchandising - DBA - Palmer Installations</td></tr></table>	</td></tr><tr><td  align='left' class='applicationnametd'> <span class='reportTableHeader'>Chain Information</span> </td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Chain No.</td><td class='selectionCriteriaItem' width='85%' align=left>:2797  </td></tr></table>	</td></tr></tr><tr><td  align='left' class='applicationnametd'> <span class='reportTableHeader'>Store Information</span> </td></tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Store No.</td><td class='selectionCriteriaItem' width='85%' align=left>:108135</td></tr></table>	</td></tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Store Name</td><td class='selectionCriteriaItem' width='85%' align=left>:JTS CHECK CASHI</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Address</td><td class='selectionCriteriaItem' width='85%' align=left>:21701 MERRICK BLVD</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>City</td><td class='selectionCriteriaItem' width='85%' align=left>:SPRINGFIELD GARDENS</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>State</td><td class='selectionCriteriaItem' width='85%' align=left>:NY</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Zip</td><td class='selectionCriteriaItem' width='85%' align=left>:114131900</td></tr></table>	</td></tr><tr><tr><td align=left  width='100%'><table border='0'  width='100%'><tr><td class='reportCriteriaHeader'  width='10%' align=left>Phone No.</td><td class='selectionCriteriaItem' width='85%' align=left>:7185282855</td></tr></table></td></tr><tr>" />
<input name="Hidden_date" type="hidden" value="" />	
<input name="Visit_Date" type="hidden" value="5/6/11" />	
<input name="txt_midnight" type="hidden" value="" />
<input name="Job_No" type="hidden" value="240068" />
<input name="Wave_No" type="hidden" value="201117" />
<input name="Task_No" type="hidden" value="1" />
<input name="Task_Desc" type="hidden" value="General Merchandising - DBA - Palmer Installations" />
<input name="Task_Addtl_Desc" type="hidden" value="DBA - Palmer Installations" />


<input name="store_id" type="hidden" value="4905299" />

<input name="Chain_No" type="hidden" value="2797" />
<input name="Store_Chain_Desc" type="hidden" value="" />
<input name="Store_No" type="hidden" value="108135" />
<input name="Store_Store_Name" type="hidden" value="JTS CHECK CASHI" />
<input name="Store_Street_Addr" type="hidden" value="21701 MERRICK BLVD" />
<input name="Store_City" type="hidden" value="SPRINGFIELD GARDENS" />
<input name="Store_State" type="hidden" value="NY" />
<input name="Store_Zip" type="hidden" value="114131900" />

<input name="CA_merch_no"  type="hidden" value="116645" />
 <input name="ctl00$ContentPlaceHolder1$Merch_no" type="hidden" id="ctl00_ContentPlaceHolder1_Merch_no" value="0" />
 
  <input name="Str_Merch_no" type="hidden" value="99999" />
  
<input name="Merch_First_Name" type="hidden" value="HANDHELD MX" />
<input name="Merch_Last_Name" type="hidden" value="CURRENT WEEK" />
<input name="Merch_Street_Addr" type="hidden" value="XXXXX" />
<input name="Merch_Street_Addr2" type="hidden" value="" />
<input name="Merch_City" type="hidden" value="XXXXX" />
<input name="Merch_State" type="hidden" value="NY" />
<input name="Merch_Zip" type="hidden" value="000000   " />
<input name="Merch_Phone_No" type="hidden" value="8453230625" />
<input name="Merch_Email_Addr" type="hidden" value="test@test.com" />


<input name="Field_Start_Dt" type="hidden" value="5/4/11" />
<input name="Field_end_Dt" type="hidden" value="5/18/11" />
<input name="Key_Comp_Dt" type="hidden" value="5/21/11" />
<input name="DOA_Dt" type="hidden" value="5/18/11" />		
	
<input name="TodayDate" type="hidden" value="5/6/2011" />		
			
<input name="visit_no" type="hidden" value="1" />

<input name="Collect_iVR_Time" type="hidden" value="Y" />
<input name="night_visits" type="hidden" value="N" />
<input name="Mileage_flag" type="hidden" value="N" />
<input name="Travel_flag" type="hidden" value="N" />

<input name="Job_Type" type="hidden" value="1" />
<input name="Business_Type_id" type="hidden" value="1" />

<input name="Work_Type_id" type="hidden" value="1" />
<input name="Work_Type_Desc" type="hidden" value="General Merchandising" />

<input name="Data_Col_Method" type="hidden" value="W" />
<input name="overwritetime" type="hidden" value="N" />
<input name="All_Data_Received" type="hidden" value="" />
<input name="collect_time_only" type="hidden" value="N" />
<input name="Ask_Q_HH_Used" type="hidden" value="N" />
<input name="HH_Status_Flag" type="hidden" value="" />

<input name="Collect_Header" type="hidden" value="NO" />
<input name="Collect_Call_Form" type="hidden" value="NO" />

<input name="SS_Callform" type="hidden" value="Y" />
<input name="Prod_Specific" type="hidden" value="N" />
<input name="qdef_skippattern" type="hidden" value="NO" />

<input name="Max_Mx_Per_Store" type="hidden" value="1" />
<input name="Max_Visit_Per_Store_Mx" type="hidden" value="1" />

<input name="Collect_Store_Mgr_Name" type="hidden" value="Y" />

<input name="Product_Check_Flag" type="hidden" value="N" />

<input name="Ask_EShelf_Question" type="hidden" value="N" />

<input name="Call_Form_Type_No" type="hidden" value="1" />

<input name="Est_instore_minutes" type="hidden" value="0" />
<input name="Business_Rule_Eckerd" type="hidden" value="0" />
<input name="Eckerd_Job_Last_question" type="hidden" value="NO" />

<input name="user_id" type="hidden" value="" />
<input name="PhotoButton" type="hidden" value="YES" />
<input name="Bus_Rule5_Question" type="hidden" value="N" />
<input name="Bus_Rule6_Question" type="hidden" value="N" />
<input name="Bus_Rule28_Question" type="hidden" value="N" />
<input name="Bus_Rule3_Question" type="hidden" value="N" />
<input name="Bus_Rule4_Question" type="hidden" value="N"  />
<input name="Bus_Rule7_Question" type="hidden" value="N"  />



<input name="Str_VisitMonth" type="hidden" value="5" />
<input name="Str_visitday" type="hidden" value="6" />
<input name="Str_visityear" type="hidden" value="11" />
<input name="Str_timein_hrs" type="hidden" value="1" />
<input name="Str_timein_min" type="hidden" value="1" />
<input name="Str_cmb_timein" type="hidden" value="AM" />
<input name="Str_timeout_hrs" type="hidden" value="1" />
<input name="Str_timeout_min" type="hidden" value="34" />
<input name="Str_cmb_timeout" type="hidden" value="AM" />
<input name="Str_txt_mileage" type="hidden" value="" />
<input name="Str_txt_drive" type="hidden" value="" />
<input name="Str_rad_q_Past_Midnight" type="hidden" value="" />
<input name="Str_rad_q_HH_Used" type="hidden" value="0" />
<input name="Str_rad_q_Ret_store_visit" type="hidden" value="" />
<input name="Str_Radio_EShelf" type="hidden" value="" />
<input name="Str_Ask_EShelf_Question" type="hidden" value="" />
<input name="Str_Bus_Rule3_Question" type="hidden" value="" />
<input name="Str_rad_q_BR3" type="hidden" value="" />
<input name="Str_Bus_Rule4_Question" type="hidden" value="" />
<input name="Str_rad_q_BR4" type="hidden" value="" />
<input name="Str_Bus_Rule5_Question" type="hidden" value="" />
<input name="Str_rad_q_BR5" type="hidden" value="" />
<input name="Str_Bus_Rule6_Question" type="hidden" value="" />
<input name="Str_rad_q_BR6" type="hidden" value="" />
<input name="Str_Bus_Rule7_Question" type="hidden" value="" />
<input name="Str_rad_q_BR7" type="hidden" value="" />
<input name="Str_Bus_Rule28_Question" type="hidden" value="" /> 
<input name="Str_rad_q_BR28" type="hidden" value="" />
<input name="Str_Manager_Title" type="hidden" value="Assistant Manager" />
<input name="Str_txt_Manager_name" type="hidden" value="fdrdf" />
<input name="ILang_Id" type="hidden" value="1"/>
<input name="Star_time" type="hidden" value="05/06/11 13:47:29"/>
<center>
<br />
  <br />
<span id="ctl00_ContentPlaceHolder1_Label11" class="LabelBlack" style="color:Red;font-weight:bold;">Answers are successfully Uploaded!</span>
 <br />
  <br />
 <span id="ctl00_ContentPlaceHolder1_Label1" class="LabelBlack" style="color:Red;font-weight:bold;">Thank You!!</span>
 <br />
   <br />
 
 <span id="ctl00_ContentPlaceHolder1_Label2" class="LabelBlack" style="color:Red;font-weight:bold;">Your Confirmation Number Is:</span>
 <span id="ctl00_ContentPlaceHolder1_confirm_Number" class="LabelBlack" style="color:Black;font-weight:bold;">1604775</span>
 <br />
   <br />
 
 <input type="submit" name="ctl00$ContentPlaceHolder1$Button1" value="Next >>" onclick="return NextPage();" id="ctl00_ContentPlaceHolder1_Button1" class="Button" class="Button" />

 
&nbsp &nbsp <input type="submit" name="ctl00$ContentPlaceHolder1$Update" value="Retail Issue Tracking System >>" onclick="return GoToRTS();" id="ctl00_ContentPlaceHolder1_Update" class="Button" class="Button" />
 
 
&nbsp &nbsp <input type="submit" name="ctl00$ContentPlaceHolder1$Button2" value="Print" onclick="return PrintPage();" id="ctl00_ContentPlaceHolder1_Button2" class="Button" class="Button" />
 
 <br />
   <br />

</center>




                    </td>
                </tr>
                <tr>
                    <td width="100%">
                        <div id="ctl00_SPARFooter1">
	<table cellpadding="0" cellspacing="5" border="0" width="100%" align="center">
		<tr>
			<td width="100%" colspan="2" valign="middle" align="center"><span id="ctl00_SPARFooter1_labelspace">&nbsp;&nbsp;&nbsp;</span></td>
		</tr><tr>
			<td width="100%" colspan="2" valign="middle" align="center"><span id="ctl00_SPARFooter1_Copyright" class="labelmasterpagefooter">© 2008 SPAR Group, Inc.</span></td>
		</tr><tr>
			<td width="100%" colspan="2" valign="middle" align="center"><span id="ctl00_SPARFooter1_AllRightsReserved" class="labelmasterpagefooter">All Rights Reserved.</span></td>
		</tr>
	</table>
</div>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    </form>
</body>
</html>