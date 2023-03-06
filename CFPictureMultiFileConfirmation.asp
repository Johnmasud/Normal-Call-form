<%@ Language=VBScript %>
<!--#INCLUDE file="prompt_initialisation.asp"-->
<!--#include file="ASPError.asp"-->
<%
Response.ContentType = "text/html;CHARSET=utf-8" 

Response.Buffer=true
server.ScriptTimeout=16000000
'ILang_Id="2"
Dim v_prompt(47),v_sys_rule(4)
dim v_asp_name,v_sys_ubound
dim errArr(24),errStr,v_error_msg(6)

v_Prompt(0)= "Internet Call Form"
v_Prompt(1)= "Date:"
v_Prompt(2)= "Picture Upload"
v_Prompt(3)= "Job No."
v_Prompt(4)= "Wave No."
v_Prompt(5)= "Task No."
v_Prompt(6)= "Chain No."
v_Prompt(7)= "Store No."
v_Prompt(8)= "Comments"
v_Prompt(9)= "Picture:"
v_Prompt(10)= "Note: Picture has to be JPG file."
v_Prompt(11)= "2002 SPAR Group, Inc."
v_Prompt(12)= "All Rights Reserved."
v_Prompt(13)= "Upload A Picture"
v_Prompt(14)= "RESET/REMODEL EMAIL NOTIFICATION"
v_Prompt(15)= "EMAIL NOTIFICATION ON NEW PHOTO"
v_Prompt(16)= "SPAR GROUP - Internet Call Form Photo Upload"
v_Prompt(17)= "Job Information"  
v_Prompt(18)= "FST DT:"  
v_Prompt(19)= "FEnd DT:" 
v_Prompt(20)= "Chain Information"
v_Prompt(21)= "Store Information"
v_Prompt(22)= "Store Name:"
v_Prompt(23)= "Street:"
v_Prompt(24)= "City:"
v_Prompt(25)= "State:"
v_Prompt(26)= "Zip:"
v_Prompt(27)= "Merch Information"
v_Prompt(28)= "Merch No:"									
v_Prompt(29)= "Phone No:"
v_Prompt(30)= "Email Address:"
v_Prompt(31)= "A picture has been uploaded by a following merchandiser:"
v_Prompt(32)= "To view and approve the photo, use the spar system tools."
v_Prompt(33)= "Spar System Tools"
v_Prompt(34)= "ERROR: The picture you trying to upload doesn't exists. Please give the picture a correct path and upload it again."
v_Prompt(35)= "Note: The Photo has been uploaded to the system for approval, please continue with either photo upload or the Call Form."
v_Prompt(36)= "Note: The Photo has been uploaded to system for approval. Please go back because you don't have the access to the call form."
v_Prompt(37)="The photo can not be uploaded at this time." 
v_Prompt(38)="Please logout and log back in again after few minutes." 
v_Prompt(39)="If you are still having problems please call your DMM."
v_Prompt(40)="Photo Upload"
v_Prompt(41)="Call Form"
v_Prompt(42)="Back"
v_Prompt(43)="Spar System Tools"
v_Prompt(44)= "HELP"
v_Prompt(45)="Confirmation Number(s)"
v_Prompt(46)= "Note: No Photo has been uploaded to the system for approval, please continue with either photo upload or the Call Form."
v_Prompt(47)= "Note: No Photo has been uploaded to the system for approval. Please go back because you don't have the access to the call form."


v_error_msg(0)="You can not enter more than 255 charaters in the Comment box."
v_error_msg(1)="Please enter a Picture path to upload."
v_error_msg(2)="Picture has to be JPG file."
v_error_msg(3)="Picture has to be JPEG,JPG or GIF file."
v_error_msg(4)="Please enter a valid Visit Date"
v_error_msg(5)="The Visit date greater than Today`s date"
v_error_msg(6)="The Visit date entered is invalid for this Job,Wave and Task."

v_sys_rule(0) = "Name Format"
v_sys_rule(1) = "New Date Format"
v_sys_rule(2) = "Address Format"
v_sys_rule(3) = "SPAR Logo"
v_sys_rule(4) = "SPAR Copyright"

v_sys_ubound = UBound(v_sys_rule)
v_upperbound = UBound(v_prompt)
v_err_ubound = UBound(v_error_msg)

v_asp_name = "CFPictureGetFile.asp"

GetPromptTranslation  ILang_Id, v_Prompt,v_asp_name,v_upperbound
GetSystemRules ILang_Id, v_sys_rule, v_sys_ubound
GetErrorTranslation  ILang_Id, v_error_msg,v_asp_name,v_err_ubound

Html_SysRule = GetHtmlSystemRuleTable
Show_CopyRights=v_sys_rule(4)

				Back_Slash = InStr(1,v_sys_rule(1),"/")
				'response.write "Back_Slash=" & Back_Slash & "<BR>" 
				if (Back_Slash>0) then
					Date_input="/"
				end if 
				Dot = InStr(1,v_sys_rule(1),".")
				'response.write "Dot=" & Dot & "<BR>" 
				if (Dot>0) then
					Date_input="."
				end if 
				Dash = InStr(1,v_sys_rule(1),"-")
				'response.write "Dot=" & Dot & "<BR>" 
				if (Dash>0) then
					Date_input="-"
				end if 

'====================================================================

				Job_No=Request.Form("Job_No")
				Wave_No=Request.Form("Wave_No")
				Task_No=Request.Form("Task_No")
				Task_Desc=Request.Form("Task_Desc")
				Task_Addtl_Desc=Request.Form("Task_Addtl_Desc")

				store_id=Request.Form("store_id")

				Chain_No=Request.Form("Chain_No")
				Store_Chain_Desc=Request.Form("Store_Chain_Desc")
				Store_No=Request.Form("Store_No")
				Store_Store_Name=Request.Form("Store_Store_Name")
				Store_Street_Addr=Request.Form("Store_Street_Addr")
				Store_City=Request.Form("Store_City")
				Store_State=Request.Form("Store_State")
				Store_Zip=Request.Form("Store_Zip")
				
				merch_no=Request.Form("merch_no")
				CA_merch_no=Request.Form("CA_merch_no")
				Merch_First_Name=Request.Form("Merch_First_Name")
				Merch_Last_Name=Request.Form("Merch_Last_Name")
				Merch_Street_Addr=Request.Form("Merch_Street_Addr")
				Merch_Street_Addr2=Request.Form("Merch_Street_Addr2")
				Merch_City=Request.Form("Merch_City")
				Merch_State=Request.Form("Merch_State")
				Merch_Zip=Request.Form("Merch_Zip")
				Merch_Phone_No=Request.Form("Merch_Phone_No")
				Merch_Email_Addr=Request.Form("Merch_Email_Addr")


				Field_Start_Dt=Request.Form("Field_Start_Dt")
				Field_end_Dt=Request.Form("Field_end_Dt")
								
				visit_no=Request.Form("visit_no")

				Collect_IVR_Time=Request.Form("Collect_IVR_Time")
				nightvisit=Request.Form("nightvisit")
				Mileage_flag=Request.Form("Mileage_flag")
				Travel_flag=Request.Form("Travel_flag")

				Job_Type=Request.Form("Job_Type")
				Business_Type_Id=Request.Form("Business_Type_Id")

				Work_Type_Id=Request.Form("Work_Type_Id")
				Work_Type_Desc=Request.Form("Work_Type_Desc")

				Data_Col_Method=Request.Form("Data_Col_Method")
				overwritetime=Request.Form("overwritetime")
				All_Data_Received=Request.Form("All_Data_Received")
				collect_time_only=Request.Form("collect_time_only")
				Ask_Q_HH_Used=Request.Form("Ask_Q_HH_Used")
				HH_Status_Flag=Request.Form("HH_Status_Flag")

				Collect_Header=Request.Form("Collect_Header")
				Collect_Call_Form=Request.Form("Collect_Call_Form")

				SS_Callform=Request.Form("SS_Callform")
				Prod_Specific=Request.Form("Prod_Specific")
				qdef_skippattern=Request.Form("qdef_skippattern")

				Max_Mx_Per_Store=Request.Form("Max_Mx_Per_Store")
				Max_Visit_Per_Store_Mx=Request.Form("Max_Visit_Per_Store_Mx")
				Collect_Store_Mgr_Name=Request.Form("Collect_Store_Mgr_Name")
				Product_Check_Flag=Request.Form("Product_Check_Flag")
				
				'It's flag to see if they have the access to the Call Form 
				UseTheCallForm=Request.Form("UseTheCallForm")
				
			'For Call Type
				Call_Form_Type_No=Request.Form("Call_Form_Type_No")
			'For Last question validation for Eckerd
				Est_instore_minutes=Request.Form("Est_instore_minutes")	
				Business_Rule_Eckerd=Request.Form("Business_Rule_Eckerd")		
				Eckerd_Job_Last_question=Request.Form("Eckerd_Job_Last_question")
					
				LastQuestionDisable=Request.Form("LastQuestionDisable")					
				'Response.Write "LastQuestionDisable=" & LastQuestionDisable & "<BR>"
	
		'For Photo Upload Button
				PhotoButton=Request.Form("PhotoButton")
				'Response.Write "PhotoButton=" & PhotoButton & "<BR>"
				XUPLOADREPLY=Request.Form("XUPLOADREPLY")
				'Response.Write "XUPLOADREPLY=" & XUPLOADREPLY & "=<BR>"	
				StrFiles=Request.Form("StrFiles")
					'Response.Write "StrFiles=" & StrFiles & "=<BR>"		
					
					UploadFiles=Request.Form("UploadFiles")
					'Response.Write "UploadFiles=" & UploadFiles & "=<BR>"		
						
		'For Visit Date

					Visit_Date=Request.Form("Visit_Date")
					'Response.Write "Visit_Date=" & Visit_Date & "<BR>"
							if Visit_Date<>"" then
									dim SDataArray
									SDataArray = split(v_sys_rule(1),"" & Date_input & "")
									Visit_Date_Array=split(Visit_Date,"" & Date_input & "")
									for i = 0 to UBound(SDataArray)			
											if UCase(trim(SDataArray(i))) = UCase("mm") then	
													Varmonth=Visit_Date_Array(i)
											end if 
											if UCase(trim(SDataArray(i))) = UCase("dd") then	
												VarDay=Visit_Date_Array(i)
											end if 
											if (UCase(trim(SDataArray(i))) = UCase("yyyy") or UCase(trim(SDataArray(i))) = UCase("yy")) then
												VarYear=Visit_Date_Array(i)
											end if 	
									next 
							end if 'Ending of Visit_Date
							
					
						'************************ From the CFJWTValidate.asp
					
		'Time in		
						txt_timein_hrs=Request.Form("txt_timein_hrs")
						'Response.Write "txt_timein_hrs=" & txt_timein_hrs & "<BR>"		

						txt_timein_min=Request.Form("txt_timein_min")
						'Response.Write "txt_timein_min=" & txt_timein_min & "<BR>"		
				
						cmb_timein=Request.Form("cmb_timein")
						'Response.Write "cmb_timein=" & cmb_timein & "<BR>"		
		'time out
						txt_timeout_hrs=Request.Form("txt_timeout_hrs")
						'Response.Write "txt_timeout_hrs=" & txt_timeout_hrs & "<BR>"	

						txt_timeout_min=Request.Form("txt_timeout_min")
						'Response.Write "txt_timeout_min=" & txt_timeout_min & "<BR>"	
				
						cmb_timeout=Request.Form("cmb_timeout")
						'Response.Write "cmb_timeout=" & cmb_timeout & "<BR>"				
						
		'mileage		
						txt_mileage=Request.Form("txt_mileage")
						'Response.Write "txt_mileage=" & txt_mileage & "<BR>"	
		'drive		
						txt_drive=Request.Form("txt_drive")
						'Response.Write "txt_drive=" & txt_drive & "<BR>"	

		'Time Question
							rad_q_Past_Midnight=Request.Form("rad_q_Past_Midnight")
							'Response.Write "rad_q_Past_Midnight=" & rad_q_Past_Midnight & "<BR>"
		'Hand Held Question
							rad_q_HH_Used=Request.Form("rad_q_HH_Used")
							'Response.Write "rad_q_HH_Used=" & rad_q_HH_Used & "<BR>"
							
		'Time Store Visit
							rad_q_Ret_store_visit=Request.Form("rad_q_Ret_store_visit")
							'Response.Write "rad_q_Ret_store_visit=" & rad_q_Ret_store_visit & "<BR>"
		'For Call Type
							Call_Form_Type_No=Request.Form("Call_Form_Type_No")							
		'For Eckerd	
						Est_instore_minutes=Request.Form("Est_instore_minutes")	
						Business_Rule_Eckerd=Request.Form("Business_Rule_Eckerd")		
						Eckerd_Job_Last_question=Request.Form("Eckerd_Job_Last_question")

			'For EShelf 	
						Ask_EShelf_Question=Request.Form("Ask_EShelf_Question")	
						'Response.Write "Ask_EShelf_Question=" & Ask_EShelf_Question & "<BR>"
						
						Radio_EShelf=Request.Form("Radio_EShelf")
						'Response.Write "Radio_EShelf=" & Radio_EShelf & "<BR>"
						user_id=Request.Form("user_id")
			'business rules				
						Bus_Rule5_Question=Request.Form("Bus_Rule5_Question")
						rad_q_BR5=Request.Form("rad_q_BR5")
						Bus_Rule6_Question=Request.Form("Bus_Rule6_Question")
						rad_q_BR6=Request.Form("rad_q_BR6")
						Bus_Rule28_Question=Request.Form("Bus_Rule28_Question")
						rad_q_BR28=Request.Form("rad_q_BR28")	
						
						UploadFiles=Request.Form("UploadFiles")
						'Response.Write "UploadFiles=" & UploadFiles & "<BR>"
						NewRotateFiles=Request.Form("NewRotateFiles")
						'Response.Write "NewRotateFiles=" & NewRotateFiles & "<BR>"

						SelectUploadFiles=Request.Form("SelectUploadFiles")
						'Response.Write "SelectUploadFiles=" & SelectUploadFiles & "<BR>"
						Visit_Dates=Request.Form("Visit_Dates")
						'Response.Write "Visit_Dates=" & Visit_Dates & "<BR>"
						PhotoCounter=Request.Form("PhotoCounter")
						if (PhotoCounter<>"") then
								PhotoCounter=left(PhotoCounter,len(PhotoCounter)-1) 
						end if 
						'Response.Write "PhotoCounter=" & PhotoCounter & "<BR>"
						SingleFileUploadFlag=Request.Form("SingleFileUploadFlag")
						'Response.Write "SingleFileUploadFlag=" & SingleFileUploadFlag & "<BR>"	
						'Response.Write "Host_Webserver=" & Host_Webserver & "<BR>"
							
								
Public DBCTextvalue 
Public DBCSPvalue 
Public DBCTABLEvalue

DBCTextvalue  = 1
DBCSPvalue    = 4
DBCTABLEvalue = 2
on error resume next
Sub DBconnect() 
   set DBconn = server.CreateObject ("adodb.connection")
   set DBrs	  = server.CreateObject ("adodb.recordset")
   set DBcmd  = server.CreateObject ("adodb.command")
		
   DBconn.Open DBconnectString 
		
   set DBcmd.Activeconnection = DBconn 
End Sub 

Sub DBdisconnect()
   set DBrs			= nothing 
   set DBcmd         = nothing 
   DBconn.Close 
   set DBconn      = nothing 
End Sub 
DBconnect

'******** Test
'FilePath="z:\Fieldapps\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "" 
'FileSave="z:\Fieldapps\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "\update"
'FileCheckPath="z:\Fieldapps\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "\working\"


'******** Production

'FilePath="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "" 
'FileSave="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "\update"
'FileCheckPath="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "\working\"
if (ILang_Id="13") then
    FilePathdb="e:\web applications\callforminput\sparEyesPic\sparEyesPic1" 

    LangID="1"
else
    FilePathdb="e:\web applications\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "" 

    LangID=ILang_Id
end if 
ErrorOn_ASP_page="CFPictureUpload.asp"


TodayDate =Month(Now) & "/" & Day(now) & "/" & Year(now) 

dim TodayDateArray
		TodayDateShow=""
		TodayDateArray = split(v_sys_rule(1),"" & Date_input & "")
		for i = 0 to UBound(TodayDateArray)			
				if UCase(trim(TodayDateArray(i))) = UCase("mm") then	
					StrMonth=Month(itoday)
					'Response.Write Visit_Month
					TodayDateShow=TodayDateShow & "" & StrMonth
				end if 
				if UCase(trim(TodayDateArray(i))) = UCase("dd") then	
					StrDay=Day(itoday)
					TodayDateShow=TodayDateShow & "" & StrDay
				end if 
				if (UCase(trim(TodayDateArray(i))) = UCase("yyyy"))  then	
					StrYear=Year(itoday)
					TodayDateShow=TodayDateShow & "" & StrYear
				end if 
				if (UCase(trim(TodayDateArray(i))) = UCase("yy")) then
					StrYear=Year(itoday)
					StrYear=Mid(StrYear,3,4)
					TodayDateShow=TodayDateShow & "" & StrYear
				end if 
				if i<>"2" then
					TodayDateShow=TodayDateShow & "" & "" & Date_input & ""
				end if 
		next 
		
	Strtime=FormatDateTime(Star_time,3)
	TodayDateShow =TodayDateShow & " " & Strtime	
	TodayDateShow=itoday	
	Str_Month=month(TodayDateShow)
	Str_Day=day(TodayDateShow)
	Str_Year=year(TodayDateShow)
	TodayDate="" & Str_Month & "/" & Str_Day & "/" & Str_Year & ""
%>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<TITLE></TITLE>
<link href="spar.css" rel="stylesheet" type="text/css">
</HEAD>
<BODY bgcolor=mintcream>
<FORM name=PhotoConfirmation method=post  action="" ID="Form2">

<script language=javascript>

function DoSubmit()
	{
		ApplicationType=document.PhotoConfirmation.ApplicationType.value
		
		if (ApplicationType=="Test")
			{
				document.PhotoConfirmation.action = "CFJWTValidateSV.asp";
			}
		else
			{			
				document.PhotoConfirmation.action = "http://mi21.sparinc.com/CallForm/CFJWTValidateSV.asp";
			}
		document.PhotoConfirmation.submit();
		return true;	
	}
	
	
function DoSubmitBack(Page_direction)
	{
	   document.PhotoConfirmation.action = Page_direction;
	   document.PhotoConfirmation.submit();
	   return true;	
	}
function gotolink()
	{
	
	//window.open("http://mi10.sparinc.com/NSBO_Manuals/NewDailyActivityResponseForm/DailyActivityResponseForm/DailyActivityResponseForm.htm","openwindow","width=700,height=350,left=0,top=0,toolbar=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes");
	window.open("http://mi10.sparinc.com/CallFormSA/InternetCallFormManual.doc","openwindow","width=700,height=350,left=0,top=0,toolbar=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes");
	
	}
</SCRIPT>
<CENTER>
<FONT SIZE=2 FACE='Verdana, Arial, Helvetica'>	
<table borderColor="dodgerblue" width="100%" border="1" height=60 ID="Table3">
  <tr> 
  <TD rowSpan="3"><IMG height="70" src="<%=v_sys_rule(3)%>" width="115"></TD>
	
    <td  height="30" colspan="2" align="middle" bordercolor="dodgerblue" bgcolor="dodgerblue"> 
      <table width="100%" border="0" cellpadding="0" cellspacing="0" ID="Table4">
        <tr> 
          <td width="50%" align="left" class="headerUserDate"></td>
            <td width="50%" align="right" class="headerUserDate"><%=v_Prompt(1)%><%=TodayDateShow%>
          </td>
        </tr>
      </table></td>
  </tr>
  <tr> 
    <td width="82%" height="30" align="center" bordercolor=dodgerblue  bgcolor=#336699 class="reportTableHeader"> <%=v_Prompt(0)%></td>
    <td width="18%" height="30"  align="center" bordercolor=dodgerblue  bgcolor=#336699 class="reportTableHeader"> 
     <a HREF="" onclick="gotolink();return false;"><span class="reportTableHeader"> <%=v_Prompt(44)%></span></a>
    </td>  
  </tr>
</table>


<table width="100%" border=1 bordercolor=dodgerblue ID="Table5">
	<TR>
		<TD bgcolor=mintcream align="middle" bordercolor=dodgerblue>
			<center>
				<table width="100%" border="0" ID="Table6">
					<TR>
						<TD width="100%" align="center" class="selectionCriteriaItem">
							<%=v_Prompt(2)%>
						</TD>
									
					</TR>  
				</table>
			</center>
		</TD>
	 </TR>
</table> 

<hr color="dodgerblue">

<table width="100%" border=0 bordercolor=dodgerblue ID="Table7">
	<TR>
		<TD bgcolor=mintcream align="middle" bordercolor=dodgerblue>
				<center>
				<table width="100%" border="0" ID="Table8">
					<TR>
						<TD class="reportCriteriaHeader"  width="10%" align=left><%=v_Prompt(3)%>
						</TD>
						<TD class="selectionCriteriaItem" width="85%" align=left>:<%=Job_No%>
						</TD>
						</TD>
					</TR>
					<TR>
						<TD class="reportCriteriaHeader"  width="10%" align=left><%=v_Prompt(4)%>
						</TD>
						<TD class="selectionCriteriaItem" width="85%" align=left>:<%=Wave_No%>
						</TD>
					</TR>
					<TR>
						<TD class="reportCriteriaHeader"  width="10%" align=left><%=v_Prompt(5)%>
						</TD>
						<TD class="selectionCriteriaItem" width="85%" align=left>:<%=Task_No%>
						</TD>
					</TR>
					<TR>
						<TD class="reportCriteriaHeader"  width="10%" align=left><%=v_Prompt(6)%>
						</TD>
						<TD class="selectionCriteriaItem" width="85%" align=left>:<%=Chain_No%>
						</TD>
					</TR>
					<TR>
						<TD class="reportCriteriaHeader"  width="10%" align=left><%=v_Prompt(7)%>
						</TD>
						</TD>
						<TD class="selectionCriteriaItem" width="85%" align=left>:<%=Store_No%>
						</TD>  
					</TR>  
				</table>
			</center>
		</TD>
	 </TR>
</table>
<hr color="dodgerblue">
<BR>
<span class="reportCriteriaHeader"><U><%=v_Prompt(45)%></U></span>
<BR>
	<%		





'******Copy file 

Dim objFSO, objDrive
'Create a FileSystemObject instance
Set objFSO = Server.CreateObject("Scripting.FileSystemObject")


 

TypeOf_error="" & Err.Description & ""

ErrorMsg = v_Prompt(37) &" " & v_Prompt(38) & " " &  v_Prompt(39) &"<br />" & vbCrLf

checkerror(ErrorMsg)

SQLStoreId="select distinct Store_id from store_mst where store_no= " & Store_No & " and chain_no= " & Chain_No & ""

DBcmd.CommandType = 1
DBcmd.CommandText = SQLStoreId
DBcmd.CommandTimeout = 600
set DBrs2= DBcmd.Execute
	
if not DBrs2.EOF then
		Store_Id = trim(DBrs2("Store_Id"))
else
	Store_Id=0
end if 




	'UploadFiles=Request.Form("UploadFiles")
'Response.Write "UploadFiles=" & UploadFiles & "<BR>"
	'					NewRotateFiles=Request.Form("NewRotateFiles")
	 					'Response.Write "NewRotateFiles=" & NewRotateFiles & "<BR>"

ArrayAllFiles= Split(UploadFiles,"|")
DeleteFilesFlag=""
if (NewRotateFiles="") then
	DeleteFilesFlag="N"
else
	ArrayNewRotateFiles= Split(NewRotateFiles,"|")
	DeleteFilesFlag="Y"
end if 



'Response.Write "SelectUploadFiles=" & SelectUploadFiles & "<BR>"	
'Response.Write "SelectUploadFiles=" & SelectUploadFiles & "<BR>"
	'Response.Write "Visit_Dates=" & Visit_Dates & "<BR>"
	'Response.Write "PhotoCounter=" & PhotoCounter & "<BR>"					 
ArrayUploadFiles= Split(SelectUploadFiles,"|")
ArrayVisitDates=Split(Visit_Dates,"|") 
ArrayPhotoCounter=Split(PhotoCounter,"|") 

'response.End 

T=1
for x = 0 to ubound(ArrayUploadFiles)
	'Response.Write "x=" & x & "<BR>"	 
		
		FileName=ArrayUploadFiles(x)
		LoopVisit_Date=ArrayVisitDates(x)
		EleValue=ArrayPhotoCounter(x)
		'Response.Write "FileName=" & FileName & "<BR>"									
									'***************Confirmation Number                    
									'getting day                                   
										Curday=DatePart("d", now)                  
										Curday=Curday+10                    
										Tempday=(Curday)*(100000)                    
									'getting hours                    
										Hours=DatePart("h", now)                  
									'getting mins                    
										Min=DatePart("n", now)              
									'getting seconds                    
										Sec=DatePart("s", now)                                   
										TempMin=Min*100                   
										TempHours=50-Hours                    
									               


										confirmation_no=Tempday+TempMin+TempHours+Sec+x   
										'Response.Write "confirmation_no=" & confirmation_no & "<BR>"	 
									'\\mi10\Edrive$\Web Applications\CallFormInput\sparEyesPic\sparEyesPic1\update\99992008461999993294203200916133750.jpg
											'FileName="\\mi10.sparinc.com\CallFormInput\sparEyesPic\sparEyesPic1\update\99992008461999993294203200916133750.jpg"		 
									'Get a file object
									Dim objFile
									Set objFile = objFSO.GetFile(FileName)

									'Get the file size
									Dim iFileSize
									iFileSize = objFile.Size
									'response.write "iFileSize=" & iFileSize & "<BR>"
									FileError="NO" 
									if (iFileSize=0) then
										FileError="YES" 
									end if 	 
									If (objFSO.FileExists(FileName))=true Then
										FileError="NO" 
									Else
										FileError="YES" 
									End If
									
									'response.write "FileError=" & FileError & "<BR>"
									'response.End 
									
									if FileError="NO" then
																	'***********  name of the file
																		StrYear=year(Date)
																		Strmonth=month(Date) 
																		Strday= day(Date) 
																		StrHour= Hour(time)
																		StrMinute= minute(time) 
																		StrSecond= second(time) +x

																		if (len(StrSecond))=1 then		
																				StrSecond=0 & "" & StrSecond & ""
																		end if 	
																		if (len(StrMinute))=1 then
																				StrMinute=0 & "" & StrMinute & ""
																		end if 
																		if (len(StrHour))=1 then
																				StrHour=0 & "" & StrHour & ""
																		end if 


																		Picture_Name="" & Job_No & "" & Wave_No & "" & Task_No & "" & store_id & "" & Merch_no & "_" & StrYear & "" & Strmonth & "" & Strday & "" & StrHour & "" & StrMinute & "" & StrSecond & ""
																		 
																		'response.write "Picture_Name=" & Picture_Name & "<BR>"
																		
																		objFSO.CopyFile "" & FileName & "", "" & FilePath & "\working\" & Picture_Name & ".jpg" 
																		'Upload.CopyFile "z:\Fieldapps\aspFiles\sparEyesMulti\sparEyesPic1\update\Pic.jpg", "z:\Fieldapps\aspFiles\sparEyesMulti\sparEyesPic1\working\" & Picture_Name & ".jpg" 
																		'File1.Copy "" & FilePath & "\working\" & Picture_Name & ".jpg"
																		'objFSO.DeleteFile("" & FileName & "")
																		PhotoFileName=Picture_Name & ".jpg"
																		'PhotoFileName=Picture_Name 
																		'PhotoFilePath="" & FilePath & "\Working\" & PhotoFileName & ""
																		PhotoFilePath="" & FilePathdb & "\Working\" & PhotoFileName & "" 												
																		Comments=request.Form("Comments" & EleValue & "") 
																		'response.write "<BR>Comments=" & Comments & "<BR>"
																		Comments=Replace(Comments, "'", "''")

																		'Code for India
																		if ILang_Id="7" then
												
																					'Approving the Photos		
																							SQLJob_Check="select 	distinct A.client_id, " & _
																													"Count_Client_Num=(select count(distinct client_id) from Jwt_Client_Mst B " & _
																																		"where B.Job_No	=A.Job_No 	and " & _
																																			"B.wave_No	=A.wave_No 	and  " & _
																																			"B.Task_No	=A.Task_No 	and  " & _
																																			"B.client_id not in (100)) " & _
																										"from Jwt_Client_Mst A " & _
																										"where Job_No=" & Job_No & " and " & _
																											"wave_No=" & Wave_No & " and " & _
																											"Task_No=" & Task_No & "	and A.client_id not in (100)"
																			
																							DBcmd.CommandType = 1
																							DBcmd.CommandText = SQLJob_Check
																							DBcmd.CommandTimeout = 600
																							set DBrs3= DBcmd.Execute
																							'Response.Write "SQLJob_Check=" & SQLJob_Check & "<BR>"
																							 
																							DoApproval="NO"
																							 
																							if not DBrs3.EOF then
																								Count_Client_Num = trim(DBrs3("Count_Client_Num"))
																								Approval_client_id= trim(DBrs3("client_id"))
																								'Count_Client_Num=3
																								if (Count_Client_Num=1) then
																										DoApproval="YES"
																								end if 
																							end if 
																							'Response.Write "DoApproval=" & DoApproval & "<BR>"
																							
																							if (DoApproval="YES") then
																			
																										SQL_Photo_no="select COUNT(photo_no) + 1 AS photo_no from Photo " & _
																													"where Job_No=" & Job_No & " and " & _
																														"wave_No=" & Wave_No & " and " & _
																														"Task_No=" & Task_No & "	and " & _
																														"store_id =" & Store_Id & ""
																			
																										DBcmd.CommandType = 1
																										DBcmd.CommandText = SQL_Photo_no
																										DBcmd.CommandTimeout = 600
																										set DBrs4= DBcmd.Execute
																										photo_no=1
																										if not DBrs4.EOF then
																											photo_no=trim(DBrs4("photo_no"))
																										end if 	
																											
																										
																										objFSO.CopyFile "" & FilePath & "\working\" & Picture_Name & ".jpg", "" & FilePath & "\approved\" & Picture_Name & ".jpg" 
																										objFSO.DeleteFile("" & FilePath & "\working\" & Picture_Name & ".jpg")
																										Response.Write "FilePath=" & FilePath & "<BR>"
																										Response.Write "Picture_Name=" & Picture_Name & "<BR>"
																										
																										PhotoLink="<A href=""" & "http://mi10.sparinc.com/callforminput/sparEyesPic/sparEyesPic7/approved/" & PhotoFileName & " """ & "><center>Click Here&nbsp;</center></A>"
																										'response.write "PhotoLink=" & PhotoLink & "<BR>"
																																
																																SQLPhoto_Insert="insert into Photo(store_id,photo_no,photo_name,photo_location,photo_dt,photo_comment,job_no,client_id,wave_no,task_no,modify_usrid,modify_dt) " & _
																																				"values (" & Store_Id & "," & photo_no & ",'" & Picture_Name & "','" & PhotoLink & "',getdate(),'This Photo was approved by the Call Form.'," & Job_No & "," & Approval_client_id & "," & Wave_No & "," & Task_No & " ,'Call_Form',getdate())"
																																'response.write "SQLPhoto_Insert=" & SQLPhoto_Insert & "<BR>"
																																DBcmd.CommandType = 1
																																DBcmd.CommandText = SQLPhoto_Insert
																																DBcmd.CommandTimeout = 600
																																DBcmd.Execute
																																 
																																SQLApproval_Insert="insert into call_visit_photos (p_id,job_no,wave_no,task_no,store_id,merch_no,visit_dt,photo_comment,approval_flag,modify_usrid,modify_dt,photo_file_name,photo_file_path,upload_user,upload_dt,Confirmation_No) " & _
																																				"values('" & Picture_Name & "'," & Job_No & "," & Wave_No & "," & Task_No & " ," & Store_Id & " ," & Merch_no  & ",'" & LoopVisit_Date  & "','" & Comments & "','A'," & Merch_no  & ",getdate(),'" & PhotoFileName & "','" & PhotoFilePath & "'," & Merch_no  & ",getdate()," & confirmation_no & ")"
																																          
																																DBcmd.CommandType = 1
																																DBcmd.CommandText = SQLApproval_Insert
																																DBcmd.CommandTimeout = 600
																																DBcmd.Execute
																														
																												
																							end if
																		end if 'ending of India Code
												
																		
																		'Check for existing file
																		'Check for existing file
																				'PhotoFileName=Picture_Name & ".jpg"
												
																			set myfileobject=server.Createobject("scripting.Filesystemobject")
																				StrFileCheckPath="" & FileCheckPath & "" & PhotoFileName & ""
																				'response.write "FileCheckPath=" & FileCheckPath & "<BR>"
																				
																				if myfileobject.FileExists(StrFileCheckPath) then
																					'response.write "GOOD"

																							'Insert information for photo
																								PhotoFileName=Picture_Name & ".jpg"
																								'PhotoFileName=Picture_Name 
																								'PhotoFilePath="" & FilePath & "\Working\" & PhotoFileName & ""
																								PhotoFilePath="" & FilePathdb & "\Working\" & PhotoFileName & "" 
																								
																									Comments=request.Form("Comments" & EleValue & "") 

																									Comments=Replace(Comments, "'", "''")
																								
																								SQLInsert="insert into call_visit_photos (p_id,job_no,wave_no,task_no,store_id,merch_no,visit_dt,photo_comment,approval_flag,modify_usrid,modify_dt,photo_file_name,photo_file_path,upload_user,upload_dt,Confirmation_No) " & _
																										"values('" & Picture_Name & "'," & Job_No & "," & Wave_No & "," & Task_No & " ," & Store_Id & " ," & Merch_no  & ",'" & LoopVisit_Date  & "','" & Comments & "','N'," & Merch_no  & ",getdate(),'" & PhotoFileName & "','" & PhotoFilePath & "'," & Merch_no  & ",getdate()," & confirmation_no & ")"
																				
																								'response.write "SQLInsert=" & SQLInsert & "<BR>"
																								'response.end 
																								DBcmd.CommandType = 1
																								DBcmd.CommandText = SQLInsert
																								DBcmd.CommandTimeout = 600
																								DBcmd.Execute
																								 
																						SendPhotoEmail="YES"
																				else
																						
																						SendPhotoEmail="NO"
																					'response.write "Not"
																				end if 
										 
																		'Getting e-mail and merchandiser name from the procedure
																			 
																if (Job_No<>"100175") then	
										
																				if SendPhotoEmail="YES"	then
																				
																											SQLInfo="exec USP_CallForm_Photo_SenEmail " & Job_No & "," & Wave_No & "," & Task_No & " ," & Chain_No & "," & Store_No & "," & Store_Id & " ," & Merch_no  & ""
																			
																											'response.write "SQLInfo=" & SQLInfo & "<BR>"
																													
																												DBcmd.CommandType = 1
																												DBcmd.CommandText = SQLInfo
																												DBcmd.CommandTimeout = 600
																												set DBrs = DBcmd.Execute
																			
																													'TypeOf_error="" & Err.Description & ""
																													
																													'ErrorMsg = v_Prompt(37) &" " & v_Prompt(38) & " " &  v_Prompt(39) &"<br />" & vbCrLf  
																													'checkerror(ErrorMsg)
																			
																											
																												Emails=DBrs("Email_String")
																												MerchName=DBrs("Merch_Full_Name")
																												JobDesc=DBrs("Task_Addtl_Desc") 
																												FieldStartDt=DBrs("Field_Start_Dt")                      
																												FieldendDt=DBrs("Field_end_Dt") 
																												TaskDesc=DBrs("Task_Desc")
																												StoreChainDesc=DBrs("Store_Chain_Desc")                      
																												StoreStoreName=DBrs("Store_Store_Name")                      
																												StoreStreetAddr=DBrs("Store_Street_Addr")                      
																												StoreCity=DBrs("Store_City")                      
																												StoreState=DBrs("Store_State")                      
																												StoreZip=DBrs("Store_Zip")   
																												MerchPhoneNo=DBrs("Merch_Phone_No")                      
																												MerchEmailAddr=DBrs("Merch_Email_Addr")
																												ClientServPersonNo=DBrs("ClientServ_PersonNo")
																	
																												'response.write "ClientServPersonNo=" & ClientServPersonNo & "<BR>"
																												'response.end 
																														if (ClientServPersonNo="") or (isnull(ClientServPersonNo)) then
																																if ILang_Id="2" then
																																	ClientServPersonNo=49
																																else
																																	ClientServPersonNo=130
																																end if
																														end if 
																														Htmlmailtext=""
																														Htmlmailtext = Htmlmailtext + "<!DOCTYPE HTML PUBLIC ""-//IETF//DTD HTML//EN"">"
																														Htmlmailtext = Htmlmailtext + "<HTML>"
																														Htmlmailtext = Htmlmailtext + "<TITLE align=center><FONT color=Green>" + v_Prompt(14) + "</FONT></TITLE>" 
																														Htmlmailtext = Htmlmailtext + "<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"">"
																														'Htmlmailtext = Htmlmailtext + "<META content='MSHTML 5.00.2919.6307' name=GENERATOR>"
																																
																														Htmlmailtext = Htmlmailtext + "<BODY bgColor=#ffffff>"
																														Htmlmailtext = Htmlmailtext + "<DIV align=center>"
																														Htmlmailtext = Htmlmailtext + "<U><EM><FONT color=#ff0000>"
																														Htmlmailtext = Htmlmailtext + "<STRONG> " + v_Prompt(15) + " </STRONG>" 
																														'Htmlmailtext = Htmlmailtext + "<BR><META content='MSHTML 5.00.2919.6307' name=GENERATOR></FONT></EM></U></DIV>"

																														Htmlmailtext = Htmlmailtext + "<DIV>"
																														Htmlmailtext = Htmlmailtext + "<Table class=grid align=Center border=1 width=100% cellpadding=1 cellspacing=1>"
																	
																														Htmlmailtext = Htmlmailtext + "<TR bgcolor='DarkGray'>"
																														Htmlmailtext = Htmlmailtext + "<TD align=Center>"
																														Htmlmailtext = Htmlmailtext + "<STRONG><FONT color=white> " + v_Prompt(16) + "</FONT></STRONG>" 
																														Htmlmailtext = Htmlmailtext + "</TD>"
																														Htmlmailtext = Htmlmailtext + "</TR>"
																	
																														Htmlmailtext = Htmlmailtext + "<TR bgcolor='DarkGray'><TD class=fieldtitle align=left>"
																														Htmlmailtext = Htmlmailtext + "<STRONG><FONT color=White>" + v_Prompt(17) + "</FONT></STRONG>" 
																														Htmlmailtext = Htmlmailtext + "</TD></TR>"
																																
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM> " + v_Prompt(3) + "</EM></STRONG>" + Trim(Job_No) + " " + Trim((TaskAddtlDesc)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
										
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(4) + "</EM></STRONG>" + Trim(Wave_No) + " ( " + v_Prompt(18) + " " + Trim(FieldStartDt) + " - " + v_Prompt(19) + " " + Trim(FieldendDt)  + ")"
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																	
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(5) + "</EM></STRONG>" + Trim(Task_No) + " " + Trim((TaskDesc)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																														'*********** Chain Information		
																														Htmlmailtext = Htmlmailtext + "<TR bgcolor='DarkGray'><TD class=fieldtitle align=left>"
																														Htmlmailtext = Htmlmailtext + "<STRONG><FONT color=White>" + v_Prompt(20) + "</FONT></STRONG>" 
																														Htmlmailtext = Htmlmailtext + "</TD></TR>"		
																															
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(6) + "</EM></STRONG>" + Trim(Chain_No) + " " + Trim((StoreChainDesc)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																																
																														'************Store Information
																	
																														Htmlmailtext = Htmlmailtext + "<TR bgcolor='DarkGray'><TD class=fieldtitle align=left>"
																														Htmlmailtext = Htmlmailtext + "<STRONG><FONT color=White>" + v_Prompt(21) + "</FONT></STRONG>" 
																														Htmlmailtext = Htmlmailtext + "</TD></TR>"	
																	
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(7) + "</EM></STRONG>" + Trim(Store_No) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"	
																																
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(22) + "</EM></STRONG>" + Trim((StoreStoreName)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																																
																												dim SAddressArray
																												SAddressArray = split(v_sys_rule(2),",")
																												for i = 0 to UBound(SAddressArray)
																														if UCase(trim(SAddressArray(i))) = UCase("Street") then	
																															
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(23) + "</EM></STRONG>" + Trim((StoreStreetAddr)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																														end if 
																														if UCase(trim(SAddressArray(i))) = UCase("City") then
																																
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(24) +"</EM></STRONG>" + Trim((StoreCity)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																														end if 
																														if UCase(trim(SAddressArray(i))) = UCase("State") then		
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(25) + "</EM></STRONG>" + Trim((StoreState)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																														end if 
																														if UCase(trim(SAddressArray(i))) = UCase("Zip") then		
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(26) + "</EM></STRONG>" + Trim((StoreZip)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																														end if 
																												next 
																														'*********** Merch Information
																														Htmlmailtext = Htmlmailtext + "<TR bgcolor='DarkGray'><TD class=fieldtitle align=left>"
																														Htmlmailtext = Htmlmailtext + "<STRONG><FONT color=White>" + v_Prompt(27) + "</FONT></STRONG>" 
																														Htmlmailtext = Htmlmailtext + "</TD></TR>"	
																	
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(28) + "</EM></STRONG>" + Trim(CStr(merch_no)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																																
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(29) + " </EM></STRONG>" + Trim(CStr(MerchPhoneNo)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																																
																																Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD class=fieldtitle align=left>"
																																Htmlmailtext = Htmlmailtext +"<STRONG><EM>" + v_Prompt(30) + "</EM></STRONG>" + Trim(CStr(MerchEmailAddr)) 
																																Htmlmailtext = Htmlmailtext + "</TD></TR>"
																																	
																														Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD align=center>"
																														Htmlmailtext = Htmlmailtext + "<STRONG><FONT color=balck><EM>" + v_Prompt(31) + "</EM></FONT></STRONG>" + Trim(CStr(MerchName))
																														Htmlmailtext = Htmlmailtext + "</TD></TR>"
																	
																														Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD align=center>"
																														Htmlmailtext = Htmlmailtext + "<STRONG><FONT color=balck><EM>" + v_Prompt(32) + "</EM></FONT></STRONG>"
																														Htmlmailtext = Htmlmailtext + "</TD></TR>"
																	
																														Htmlmailtext = Htmlmailtext + "<TR bgcolor='white'><TD align=center>"
																														
																														'Response.Write "john=" & Cstr(ClientServPersonNo) & "<BR>"
																														'Htmlmailtexttest ="LID=" + Trim(CStr(LangID)) + "&PID=" + Trim(CStr(Picture_Name)) + "&UID=" + Trim(Cstr(ClientServPersonNo)) + ""
																														
																														'Response.Write "Htmlmailtexttest=" & Htmlmailtexttest & "<BR>"
																														
																														'Htmlmailtext = Htmlmailtext + "<A href='http://mitest.sparinc.com/callforminput/sparEyesPic/sparEye_callform.asp?" + Htmlmailtexttest +"  '>" & v_Prompt(43) & "</A></font>     "
																														
																														'Htmlmailtext = Htmlmailtext + "<A href='http://mitest.sparinc.com/callforminput/sparEyesPic/sparEye_callform.asp?LID=" + Trim(CStr(LangID)) + "&PID=" + Trim(CStr(Picture_Name)) + "&UID=" + Trim(Cstr(ClientServPersonNo)) + "'>" & v_Prompt(43) & "</A></font>"
																														'Htmlmailtext = Htmlmailtext + "<A href=http://mi2.sparinc.com/sparEyesMulti/sparEye_callform.asp?LID=" + Trim(CStr(LangID)) + "&PID=" + Trim(CStr(Picture_Name)) + "&UID=" + Trim(CStr(ClientServPersonNo)) + ">" & v_Prompt(43) & "</A></font>"
																														Htmlmailtext = Htmlmailtext + "<A href='http://mi10.sparinc.com/callforminput/sparEyesPic/sparEye_callform.asp?LID=" + Trim(CStr(LangID)) + "&PID=" + Trim(CStr(Picture_Name)) + "&UID=" + Trim(CStr(ClientServPersonNo)) + "'>" & v_Prompt(43) & "</A></font>"
																														Htmlmailtext = Htmlmailtext + "</TD></TR>"
																	
																														Htmlmailtext = Htmlmailtext + "</Table>"
																														Htmlmailtext = Htmlmailtext + "</Body></Html>"
																														Htmlmailtext = Trim(Htmlmailtext)
																	
																														'response.write Htmlmailtext
																	
																														Dim MailObject
																														Set MailObject = Server.CreateObject("CDONTS.NewMail")
																														MailObject.SetLocaleIDs(ICodePage) 		
																														'Make the bodyformat to HTML compatiable
																														MailObject.BodyFormat=0
																														MailObject.MailFormat = 0
																																
																														'Make this mail as high priority one
																														'MailObject.Importance = 1
																	
																														'From		
																														'MailObject.From=dtamodusr		
																														'MailObject.From="Internet" & space(2) & "Call" & space(2) & "Form-Photo"
																														'MailObject.From = "mi8@sparinc.net"
																														MailObject.From = "CallFormPhotoNotification@sparinc.com"
																														if ILang_Id="2" then
																																if (Emails="") or (isnull(Emails)) then
																																	Emails=""
																																else
																																	Emails=";" & Emails 
																																end if 
																														else
																																if (Emails="") or (isnull(Emails)) then
																																	Emails=";jmasud@sparinc.com"
																																else
																																	Emails=";" & Emails 
																																end if 	
																																'response.write "Emails=" & Emails & "<BR>"
																														end if 
																														'Emails=""
																														
																														'MailObject.To="jmasud@sparinc.com"
																														if ILang_Id="7" then
																															MailObject.To="jmasud@sparinc.com"
																														else
																															MailObject.To="jmasud@sparinc.com " & emails & ""
																															'MailObject.To="jmasud@sparinc.com; hmufti@sparinc.com" & emails & ""
																															'MailObject.To="jmasud@sparinc.com" '& emails & ""
																															'MailObject.To="jmasud@sparinc.com" 
																														end if 
																														'MailObject.To="jmasud@sparinc.com;Mwang@SPARINC.COM;irakovich@SPARINC.COM;Ihernandez@sparinc.com"				
																														'********************************************************************
																	
																														'************ Sending the E-mail
										
																														'**********************************************************************
																															
																														'TypeOf_error="" & Err.Description & ""
																														'ErrorMsg = v_Prompt(37) &" " & v_Prompt(38) & " " &  v_Prompt(39) &"<br />" & vbCrLf  
																														   
																														'checkerror(ErrorMsg)
																												
																																
																														MailObject.Subject="Photo Approval Notification"
																																
																														'Assign the text to Mailobject body
																														MailObject.Body=Htmlmailtext
										
																														'Send the mail
																														MailObject.Send	
																														
																						end if 
																end if 	
									end if ' For FileError condition
									%>
									<br>
									<span class="reportCriteriaHeader">Photo <%=T%>:</span><B><%=confirmation_no%></B>
									<%	
		T=T+1														
next 
'Delete all the upload files and rotated files.

for P=0 to ubound(ArrayAllFiles)
		UploadFiles=ArrayAllFiles(P)
		if (DeleteFilesFlag="Y") then
			RotateFiles=ArrayNewRotateFiles(P)
			objFSO.DeleteFile("" & RotateFiles & "")
		end if 
		'Response.Write "UploadFiles=" & UploadFiles & "<BR>"
		'Response.Write "RotateFiles=" & RotateFiles & "<BR>"
		
		objFSO.DeleteFile("" & UploadFiles & "")
next 


if UseTheCallForm="YES" then
				
				%>

							<BR>
							<%
							if (SelectUploadFiles="") then
							%>
							<span class="reportCriteriaHeader"><%=v_Prompt(46)%></span>
							<%
							else
							%>						 
							<span class="reportCriteriaHeader"><%=v_Prompt(35)%></span>
							<%
							end if 
							%>
							<BR>
							<BR>
							<%
							if (SingleFileUploadFlag="") then
							%>	
							<INPUT name=btnSubStore class="button" type=button value="<%=v_Prompt(40)%>" onclick="DoSubmitBack('http://<%=Host_Webserver%>/CallForm/CFPictureGetMultiFile.asp')" ID="Button6">
							&nbsp&nbsp
							<%
							else
							%>
							<INPUT name=btnSubStore class="button" type=button value="<%=v_Prompt(40)%>" onclick="DoSubmitBack('http://<%=Host_Webserver%>/CallForm/CFPictureGetSingleFile.asp')" ID="Button1">
							&nbsp&nbsp
							<%
							end if 
							%>
							<INPUT name=btnSubStore class="button" type=button value="<%=v_Prompt(41)%>" onclick="DoSubmit()" ID="Button7">
							&nbsp&nbsp
							<INPUT name=btnSubStore class="button" type=button value="&lt;&lt;<%=v_Prompt(42)%>" onclick="DoSubmitBack('http://<%=Host_Webserver%>/CallForm/CFJWTInputsSV.asp')" title="Back to Job,Wave and Task Screen" ID="Button8">
							
				<%
			
else
			
			
				%>

					<BR>
					<%
					if (SelectUploadFiles="") then
					%>
					<span class="reportCriteriaHeader"><%=v_Prompt(47)%></span>
					<%
					else
					%>						 
					<span class="reportCriteriaHeader"><%=v_Prompt(36)%></span>
					<%
					end if 
					%>
					<BR>
					<BR>
					<%
					if (SingleFileUploadFlag="") then
					%>		
								
					<INPUT name=btnSubStore class="button" type=button value="<%=v_Prompt(40)%>" onclick="DoSubmitBack('http://<%=Host_Webserver%>/CallForm/CFPictureGetMultiFile.asp')" ID="Button11">
					&nbsp&nbsp
					<%
					else
					%>
					<INPUT name=btnSubStore class="button" type=button value="<%=v_Prompt(40)%>" onclick="DoSubmitBack('http://<%=Host_Webserver%>/CallForm/CFPictureGetSingleFile.asp')" ID="Button2">
					&nbsp&nbsp
					<%
					end if 
					%>
					<INPUT name=btnSubStore class="button" type=button value="&lt;&lt;<%=v_Prompt(42)%>" onclick="DoSubmitBack('http://<%=Host_Webserver%>/CallForm/CFJWTInputsSV.asp')" title="Back to Job,Wave and Task Screen" ID="Button12">
				<%
		
end if 
			
			
			
			%>

		
		
		

<INPUT name="Job_No" type="hidden" value="<%=Job_No%>" ID="Hidden3">
<INPUT name="Wave_No" type="hidden" value="<%=Wave_No%>" ID="Hidden4">
<INPUT name="Task_No" type="hidden" value="<%=Task_No%>" ID="Hidden5">
<INPUT name="Task_Desc" type="hidden" value="<%=Task_Desc%>" ID="Hidden6">
<INPUT name="Task_Addtl_Desc" type="hidden" value="<%=Task_Addtl_Desc%>" ID="Hidden7">

<INPUT name="store_id" type="hidden" value="<%=store_id%>" ID="Hidden8">

<INPUT name="Chain_No" type="hidden" value="<%=Chain_No%>" ID="Hidden9">
<INPUT name="Store_Chain_Desc" type="hidden" value="<%=Store_Chain_Desc%>" ID="Hidden10">
<INPUT name="Store_No" type="hidden" value="<%=Store_No%>" ID="Hidden11">
<INPUT name="Store_Store_Name" type="hidden" value="<%=Store_Store_Name%>" ID="Hidden12">
<INPUT name="Store_Street_Addr" type="hidden" value="<%=Store_Street_Addr%>" ID="Hidden13">
<INPUT name="Store_City" type="hidden" value="<%=Store_City%>" ID="Hidden14">
<INPUT name="Store_State" type="hidden" value="<%=Store_State%>" ID="Hidden15">
<INPUT name="Store_Zip" type="hidden" value="<%=Store_Zip%>" ID="Hidden16">

<INPUT name="CA_merch_no"  type="hidden" value="<%=CA_merch_no%>" ID="Hidden17">
<INPUT name="merch_no" type="hidden" value="<%=merch_no%>" ID="Hidden18">
<INPUT name="Merch_First_Name" type="hidden" value="<%=Merch_First_Name%>" ID="Hidden19">
<INPUT name="Merch_Last_Name" type="hidden" value="<%=Merch_Last_Name%>" ID="Hidden20">
<INPUT name="Merch_Street_Addr" type="hidden" value="<%=Merch_Street_Addr%>" ID="Hidden21">
<INPUT name="Merch_Street_Addr2" type="hidden" value="<%=Merch_Street_Addr2%>" ID="Hidden22">
<INPUT name="Merch_City" type="hidden" value="<%=Merch_City%>" ID="Hidden23">
<INPUT name="Merch_State" type="hidden" value="<%=Merch_State%>" ID="Hidden24">
<INPUT name="Merch_Zip" type="hidden" value="<%=Merch_Zip%>" ID="Hidden25">
<INPUT name="Merch_Phone_No" type="hidden" value="<%=Merch_Phone_No%>" ID="Hidden26">
<INPUT name="Merch_Email_Addr" type="hidden" value="<%=Merch_Email_Addr%>" ID="Hidden27">


<INPUT name="Field_Start_Dt" type="hidden" value="<%=Field_Start_Dt%>" ID="Hidden28">
<INPUT name="Field_end_Dt" type="hidden" value="<%=Field_end_Dt%>" ID="Hidden29">
<INPUT name="Key_Comp_Dt" type="hidden" value="<%=Key_Comp_Dt%>" ID="Hidden30">
<INPUT name="DOA_Dt" type="hidden" value="<%=DOA_Dt%>" ID="Hidden31">			
<INPUT name="TodayDate" type="hidden" value="<%=TodayDate%>" ID="Hidden32">

<INPUT name="visit_no" type="hidden" value="<%=visit_no%>" ID="Hidden33">

<INPUT name="Collect_IVR_Time" type="hidden" value="<%=Collect_IVR_Time%>" ID="Hidden34">
<INPUT name="nightvisit" type="hidden" value="<%=nightvisit%>" ID="Hidden35">
<INPUT name="Mileage_flag" type="hidden" value="<%=Mileage_flag%>" ID="Hidden36">
<INPUT name="Travel_flag" type="hidden" value="<%=Travel_flag%>" ID="Hidden37">

<INPUT name="Job_Type" type="hidden" value="<%=Job_Type%>" ID="Hidden38">
<INPUT name="Business_Type_Id" type="hidden" value="<%=Business_Type_Id%>" ID="Hidden39">

<INPUT name="Work_Type_Id" type="hidden" value="<%=Work_Type_Id%>" ID="Hidden40">
<INPUT name="Work_Type_Desc" type="hidden" value="<%=Work_Type_Desc%>" ID="Hidden41">	

<INPUT name="Data_Col_Method" type="hidden" value="<%=Data_Col_Method%>" ID="Hidden42">
<INPUT name="overwritetime" type="hidden" value="<%=overwritetime%>" ID="Hidden43">
<INPUT name="All_Data_Received" type="hidden" value="<%=All_Data_Received%>" ID="Hidden44">
<INPUT name="collect_time_only" type="hidden" value="<%=collect_time_only%>" ID="Hidden45">
<INPUT name="Ask_Q_HH_Used" type="hidden" value="<%=Ask_Q_HH_Used%>" ID="Hidden46">
<INPUT name="HH_Status_Flag" type="hidden" value="<%=HH_Status_Flag%>" ID="Hidden47">	

<INPUT name="Collect_Header" type="hidden" value="<%=Collect_Header%>" ID="Hidden48">
<INPUT name="Collect_Call_Form" type="hidden" value="<%=Collect_Call_Form%>" ID="Hidden49">

<INPUT name="SS_Callform" type="hidden" value="<%=SS_Callform%>" ID="Hidden50">
<INPUT name="Prod_Specific" type="hidden" value="<%=Prod_Specific%>" ID="Hidden51">
<INPUT name="qdef_skippattern" type="hidden" value="<%=qdef_skippattern%>" ID="Hidden52">

<INPUT name="Max_Mx_Per_Store" type="hidden" value="<%=Max_Mx_Per_Store%>" ID="Hidden53">
<INPUT name="Max_Visit_Per_Store_Mx" type="hidden" value="<%=Max_Visit_Per_Store_Mx%>" ID="Hidden54">

<INPUT name="Collect_Store_Mgr_Name" type="hidden" value="<%=Collect_Store_Mgr_Name%>" ID="Hidden55">

<INPUT name="Product_Check_Flag" type="hidden" value="<%=Product_Check_Flag%>" ID="Hidden56">


<INPUT name="UseTheCallForm" type="hidden" value="<%=UseTheCallForm%>" ID="Hidden57">

<INPUT name="Call_Form_Type_No" type="hidden" value="<%=Call_Form_Type_No%>" ID="Hidden58">

<INPUT name="ILang_Id" type="hidden" value="<%=ILang_Id%>" ID="Hidden59">

<INPUT name="Est_instore_minutes" type="hidden" value="<%=Est_instore_minutes%>" ID="Hidden60">

<INPUT name="Business_Rule_Eckerd" type="hidden" value="<%=Business_Rule_Eckerd%>" ID="Hidden61">
<INPUT name="Eckerd_Job_Last_question" type="hidden" value="<%=Eckerd_Job_Last_question%>" ID="Hidden62">
<INPUT name="LastQuestionDisable" type="hidden" value="<%=LastQuestionDisable%>" ID="Hidden63">
<INPUT name="Ask_EShelf_Question" type="hidden" value="<%=Ask_EShelf_Question%>" ID="Hidden64">

<INPUT name="PhotoButton" type="hidden" value="<%=PhotoButton%>" ID="Hidden65">

<%
'from CFJWTValidate
%>


<INPUT name="rad_q_Past_Midnight" type="hidden" value="<%=rad_q_Past_Midnight%>" ID="Hidden66">
<INPUT name="rad_q_Ret_store_visit" type="hidden" value="<%=rad_q_Ret_store_visit%>" ID="Hidden67">
<INPUT name="rad_q_HH_Used" type="hidden" value="<%=rad_q_HH_Used%>" ID="Hidden68">
<INPUT name="txt_mileage" type="hidden" value="<%=txt_mileage%>" ID="Hidden69">
<INPUT name="txt_drive" type="hidden" value="<%=txt_drive%>" ID="Hidden70">

<INPUT name="txt_timein_hrs" type="hidden" value="<%=txt_timein_hrs%>" ID="Hidden71">
<INPUT name="txt_timein_min" type="hidden" value="<%=txt_timein_min%>" ID="Hidden72">
<INPUT name="cmb_timein" type="hidden" value="<%=cmb_timein%>" ID="Hidden73">
<INPUT name="txt_timeout_hrs" type="hidden" value="<%=txt_timeout_hrs%>" ID="Hidden74">
<INPUT name="txt_timeout_min" type="hidden" value="<%=txt_timeout_min%>" ID="Hidden75">
<INPUT name="cmb_timeout" type="hidden" value="<%=cmb_timeout%>" ID="Hidden76">
<INPUT name="Radio_EShelf" type="hidden" value="<%=Radio_EShelf%>" ID="Hidden77">
<INPUT name="user_id" type="hidden" value="<%=user_id%>" ID="Hidden78">
<INPUT name="UploadFiles" type="hidden" value="" ID="Hidden79">
<INPUT name="Bus_Rule5_Question" type="hidden" value="<%=Bus_Rule5_Question%>" ID="Hidden80">
<INPUT name="rad_q_BR5" type="hidden" value="<%=rad_q_BR5%>" ID="Hidden81">
<INPUT name="Bus_Rule6_Question" type="hidden" value="<%=Bus_Rule6_Question%>" ID="Hidden82">
<INPUT name="rad_q_BR6" type="hidden" value="<%=rad_q_BR6%>" ID="Hidden83">
<INPUT name="Bus_Rule28_Question" type="hidden" value="<%=Bus_Rule28_Question%>" ID="Hidden84">
<INPUT name="rad_q_BR28" type="hidden" value="<%=rad_q_BR28%>" ID="Hidden85">
	<INPUT name="Visit_Date" type="hidden" value="<%=Visit_Date%>" ID="Hidden88">								
	<INPUT name="ApplicationType" type="hidden" value="<%=ApplicationType%>" ID="Hidden97">								
</form> 
<BR>
<BR>
<Center>
<%
if (UCase(Show_CopyRights)="YES") then
%>
	<span class="copyRight" > &copy; <%=year(now)%> SPAR Group, Inc. <BR>All Rights Reserved. </span>  
<%
end if 
%>		
</center>
</font>				
</BODY>
</HTML>
