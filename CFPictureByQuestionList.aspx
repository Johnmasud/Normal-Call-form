<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableViewStateMac="false" CodeFile="CFPictureByQuestionList.aspx.cs" Inherits="CFPictureByQuestionList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript"  language="javascript">
function Load()
	{
	   // alert("test");
	}
function DoSubmitBack()
	{
	     DisableButtons()
	     
	      Max_Visit_Per_Store_Mx=document.aspnetForm.Max_Visit_Per_Store_Mx.value;
	      //alert("Max_Visit_Per_Store_Mx=" + Max_Visit_Per_Store_Mx);
	        
	     Photo_q_complete=document.aspnetForm.Photo_q_complete.value
	      // alert("Photo_q_complete=" + Photo_q_complete);
	     NewScreenPage=document.aspnetForm.NewScreenPage.value
         StrNewCallFormPathLink=document.aspnetForm.StrNewCallFormPathLink.value
	      
	     if (Photo_q_complete=="N")
	     {
	            var ok=confirm('<%=vPrompts[10]%>' + " \n " + '<%=vPrompts[11]%>' + " \n " + '<%=vPrompts[12]%>') 
				if (ok)
					{
						     if (Max_Visit_Per_Store_Mx>1)
	                            {
	                                     if (NewScreenPage=="Y")
                                             {
                                                 document.aspnetForm.action=StrNewCallFormPathLink   
                                             }
                                         else
                                             {
	                                            document.aspnetForm.action = "CFJWT_Input_Photo_Option.aspx";
	                                         }
	                                    document.aspnetForm.submit();
	                                    return false;
	                            }
	                            else
	                            {
	                                     if (NewScreenPage=="Y")
                                             {
                                                 document.aspnetForm.action=StrNewCallFormPathLink   
                                             }
                                         else
                                             {
    	                                        document.aspnetForm.action = "CFJWTInputs.aspx";
    	                                     }
	                                    document.aspnetForm.submit();
	                                    return false;
	                            }	
					}
				else
					{
						//alert("Please continue with the Internet Call Form.")
						//alert('<%=vPrompts[7]%>')
						 
						AbleButtons()
						return false
					}	
	    }
	    else
	    {
	       
	        if (Max_Visit_Per_Store_Mx>1)
	        {
	                 if (NewScreenPage=="Y")
                         {
                             document.aspnetForm.action=StrNewCallFormPathLink   
                         }
                     else
                         {
	                        document.aspnetForm.action = "CFJWT_Input_Photo_Option.aspx";
	                     }
	                document.aspnetForm.submit();
	                return false;
	        }
	        else
	        {
	                 if (NewScreenPage=="Y")
                         {
                             document.aspnetForm.action=StrNewCallFormPathLink   
                         }
                     else
                         {
    	                     document.aspnetForm.action = "CFJWTInputs.aspx";
    	                 }
	                document.aspnetForm.submit();
	                return false;
	        }
        }		 
	}
	
function QuestionByPhoto_Access(Pq_no,P_res_val,P_upc,upc_desc,q_desc,Res_desc)
	{ 
//        alert("P_upc=" + P_upc);
//        alert("Pq_no=" + Pq_no);
//        alert("P_res_val=" + P_res_val)
	   //alert("CF_visit_dt=" + P_visit_dt);
 	   document.aspnetForm.Photo_Q_No.value=Pq_no;
 	   document.aspnetForm.Photo_q_Res_Val.value=P_res_val;
 	   document.aspnetForm.Photo_Prod_upc.value=P_upc; 
 	   
 	   document.aspnetForm.Photo_upc_desc.value=upc_desc;
 	   document.aspnetForm.Photo_q_desc.value=q_desc;
 	   document.aspnetForm.Photo_Res_desc.value=Res_desc; 
 	   
 	   //Check for apple chrome 
 	   
 	   AppleIpadUsedFlag=document.aspnetForm.AppleIpadUsed.value;
 	   //AppleIpadUsedFlag="Y";
 	  // alert("AppleIpadUsedFlag=" + AppleIpadUsedFlag);
 	   if (AppleIpadUsedFlag=="Y")
 	   {
 	        document.aspnetForm.action  = "CFPictureGetSingleFile.aspx";
 	   }
 	   else
 	   {
             document.aspnetForm.action  = "CFPictureMultiFile.aspx";
           // document.aspnetForm.action  = "CFPictureGetSingleFile.aspx";
       }
        document.aspnetForm.submit();
		return false;
 }
 function PhotoWithoutQuestion()
	{ 
        document.aspnetForm.Photo_Q_No.value='';
 	    document.aspnetForm.Photo_q_Res_Val.value='';
 	    document.aspnetForm.Photo_Prod_upc.value=''; 
 	   
 	    document.aspnetForm.Photo_upc_desc.value='';
 	    document.aspnetForm.Photo_q_desc.value='';
 	    document.aspnetForm.Photo_Res_desc.value='';     
        document.aspnetForm.action  = "CFPictureMultiFile.aspx";
        document.aspnetForm.submit();
		return false;
 }
function DisableButtons()
	{
	      //******* Disabled the buttons
	      // document.aspnetForm.ctl00$ContentPlaceHolder1$NextBtn.disabled=true;
		    //document.aspnetForm.ctl00$ContentPlaceHolder1$NextBtn.disabled=true;
		    var ExistNext=document.getElementById("ctl00_ContentPlaceHolder1_NextBtn");
            if (ExistNext!=null)
            {
               document.aspnetForm.ctl00_ContentPlaceHolder1_NextBtn.disabled=true;
            }
             var ExistRts=document.getElementById("ctl00_ContentPlaceHolder1_RTSBtn");
            if (ExistRts!=null)
            {
               document.aspnetForm.ctl00_ContentPlaceHolder1_RTSBtn.disabled=true;
            }
		 
	}
function AbleButtons()
	{
	     //******* abled the buttons
	     //document.aspnetForm.ctl00$ContentPlaceHolder1$NextBtn.disabled=false;
         var ExistNext=document.getElementById("ctl00_ContentPlaceHolder1_NextBtn");
        if (ExistNext!=null)
        {
           document.aspnetForm.ctl00_ContentPlaceHolder1_NextBtn.disabled=false;
        }	 
         var ExistRts=document.getElementById("ctl00_ContentPlaceHolder1_RTSBtn");
        if (ExistRts!=null)
        {
           document.aspnetForm.ctl00_ContentPlaceHolder1_RTSBtn.disabled=false;
        }
	}
function GoToRTS()
	 {
	         DisableButtons()
	         Photo_q_complete=document.aspnetForm.Photo_q_complete.value
	        // alert("Photo_q_complete=" + Photo_q_complete);
	         if (Photo_q_complete=="N")
	         {
	        //var ok=confirm('<%=vPrompts[10]%>' + " \n " + '<%=vPrompts[11]%>' + " \n " + '<%=vPrompts[12]%>')
	                var ok=confirm('<%=vPrompts[10]%>' + " \n " + '<%=vPrompts[11]%>' + " \n " + '<%=vPrompts[12]%>') 
				    if (ok) {
				        RTS_Url = document.aspnetForm.RTS_Url.value
				        document.aspnetForm.action = RTS_Url;
						     //document.aspnetForm.action="http://mi23.sparinc.com/itsnet/its_main.aspx"
                             document.aspnetForm.submit()
                             return true;
					    }
				    else
					    {
						    //alert("Please continue with the Internet Call Form.")
						    //alert('<%=vPrompts[7]%>')
    						 
						    AbleButtons()
						    return false;
					    }	
	        }
	        else {
	            RTS_Url = document.aspnetForm.RTS_Url.value
	            document.aspnetForm.action = RTS_Url;
    	         //document.aspnetForm.action="http://mi23.sparinc.com/itsnet/its_main.aspx"
                 document.aspnetForm.submit()
                 return true;
            }		   
	 } 
</script>


<hr color="dodgerblue">

<asp:Table ID="Table1" runat="server" width="100%" BorderWidth="0" bordercolor="dodgerblue">
<asp:TableRow>
    <asp:TableCell HorizontalAlign="Left" >
           <asp:Table ID="Table2" runat="server" width="100%"  BorderWidth="0" bordercolor="dodgerblue">
            <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader" >
                         <asp:Label ID="LabelJob_no" runat="server" Text="Job No."  class="reportCriteriaHeader"></asp:Label>  
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem" >
                        :<%=Job_No%>
                </asp:TableCell>
            </asp:TableRow> 
             <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader">
                       <asp:Label ID="Label2" runat="server" Text="Wave No."   CssClass="reportCriteriaHeader"></asp:Label>  
                   
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem">
                        :<%=Wave_No%>
                </asp:TableCell>
            </asp:TableRow> 
             <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader">
                        <asp:Label ID="Label3" runat="server" Text="Task No."  CssClass="reportCriteriaHeader"></asp:Label>       
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem">
                       :<%=Task_No%>
                </asp:TableCell>
            </asp:TableRow> 
             <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader">
                       <asp:Label ID="Label4" runat="server" Text="Chain No."  CssClass="reportCriteriaHeader"></asp:Label>  
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem">
                        :<%=Chain_No%>
                </asp:TableCell>
            </asp:TableRow> 
             <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader">
                       <asp:Label ID="Label5" runat="server" Text="Store No."  CssClass="reportCriteriaHeader"></asp:Label>      
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem">
                       :<%=Store_No%>
                </asp:TableCell>
            </asp:TableRow> 
             <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader">
                       <asp:Label ID="Label6" runat="server" Text="Visit Date."  CssClass="reportCriteriaHeader"></asp:Label>      
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem">
                        <%=Display_Job_Visit_Date%>
                </asp:TableCell>
            </asp:TableRow> 
         </asp:Table>

    </asp:TableCell>
</asp:TableRow> 
</asp:Table>

<hr color="dodgerblue">
 
 <div style="margin-left: auto; margin-right: auto; text-align: center;">
<asp:Label ID="Q_Confirmation_txt"   Font-Bold="true" ForeColor="Red" runat="server" Text="Visit Confirmation No."  SkinID="LabelBlackSkin"></asp:Label>

<asp:Label ID="Display_Q_Confirmation_No" Font-Bold="true" ForeColor="Black" runat="server" Text=""  SkinID="LabelBlackSkin"></asp:Label>
 </div>
 <br />
  <center>
<asp:Label ID="Display_Q_Confirmation_Msg" Font-Bold="true" ForeColor="Red" runat="server" Text=""  SkinID="LabelBlackSkin"></asp:Label>
  <br />
  <asp:Label ID="Display_Q_Confirmation_Msg2" runat="server" Font-Bold="true" ForeColor="#669900" Font-Size="Medium" Text="If you do not submit your photos you will not be paid per client directives. Do not close the screen" SkinID="LabelBlackSkin"></asp:Label>
  <br />
<div id="ShowJWTInfo" runat="server">
 
</div> 

 <asp:GridView  ID="PhotoQGrid"   Width="80%" DataKeyNames="q_no,Response_Val,Prod_upc,upc_desc,q_desc,Res_desc" Font-Size="Medium"  BorderColor="DodgerBlue"  AutoGenerateColumns="false"   OnRowDataBound="CreateButtonLink" RowStyle-CssClass="reportTableItem"  HeaderStyle-CssClass="reportTableHeadernew"  runat="server">
<Columns>
     <asp:BoundField ItemStyle-HorizontalAlign="Left" DataField="upc_desc"/>
     <asp:BoundField ItemStyle-HorizontalAlign="Left" DataField="q_desc"/>
     <asp:BoundField ItemStyle-HorizontalAlign="Left" DataField="Res_desc"/>
    <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Photo_count"/>
    <asp:TemplateField>
      
     <HeaderTemplate>
     
         <asp:Label ID="nothing" runat="server" Text="" CssClass="reportCriteriaHeader"></asp:Label>  
                
   </HeaderTemplate>
   <ItemTemplate>
    
     <asp:Button   ID="PhotoBttton_Status" runat="server" Text="Photo Upload" CssClass="Button"></asp:Button>
   </ItemTemplate>
    </asp:TemplateField>
</Columns> 
</asp:GridView>
   
<br />
   <asp:Button OnClientClick="return DoSubmitBack()" ID="NextBtn"  runat="server" Text="Next >>" CssClass="Button"></asp:Button>
<%    
if (RTS_Link_Access=="YES") 
{       
%>
 
&nbsp &nbsp <asp:Button OnClientClick="return GoToRTS()" ID="RTSBtn" runat="server" Text="Retail Issue Tracking System &gt;&gt;" CssClass="Button"></asp:Button>
 
<%
}  
%> 
    &nbsp&nbsp
   <asp:Button   ID="PhotoNoQuestion_bnt" runat="server" Visible="false" Text="Photo Upload (Without Questions)"   OnClientClick="return PhotoWithoutQuestion()" CssClass="Button"></asp:Button>
  <br />
<%

if (Job_No == "100911")
{	
%>
 <br />
	<TABLE width="100%" align="center" border="0">
		<TR>
			<td align="middle" width="100%"><A class="linkstyle" href="https://mars.sourceinterlink.com">Click here to report your time into M.A.R.S. (Michigan stores excluded)</A>
			</td>
		</TR>
		
	</TABLE>
 <br />
<%
}
%>



<input name="Hidden_date" type="hidden" value="" />	
<input name="Visit_Date" type="hidden" value="" />	
<input name="Job_Visit_Date" type="hidden" value="<%=Job_Visit_Date%>" />
<input name="txt_midnight" type="hidden" value="" />
<input name="Job_No" type="hidden" value="<%=Job_No%>" />
<input name="Wave_No" type="hidden" value="<%=Wave_No%>" />
<input name="Task_No" type="hidden" value="<%=Task_No%>" />
<input name="Task_Desc" type="hidden" value="<%=Task_Desc%>" />
<input name="Task_Addtl_Desc" type="hidden" value="<%=Task_Addtl_Desc%>" />

<input name="Photo_Q_Enable" type="hidden" value="Y"/>
<input name="store_id" type="hidden" value="<%=store_id%>" />

<input name="Chain_No" type="hidden" value="<%=Chain_No%>" />
<input name="Store_Chain_Desc" type="hidden" value="<%=Store_Chain_Desc%>" />
<input name="Store_No" type="hidden" value="<%=Store_No%>" />
<input name="Store_Store_Name" type="hidden" value="<%=Store_Store_Name%>" />
<input name="Store_Street_Addr" type="hidden" value="<%=Store_Street_Addr%>" />
<input name="Store_City" type="hidden" value="<%=Store_City%>" />
<input name="Store_State" type="hidden" value="<%=Store_State%>" />
<input name="Store_Zip" type="hidden" value="<%=Store_Zip%>" />

<input name="CA_merch_no"  type="hidden" value="<%=CA_merch_no%>" />

<input name="Type_Browser"  type="hidden" value="<%=Type_Browser%>" />

<input name="Type_Chrome"  type="hidden" value="<%=Type_Chrome%>" />
<input id="Merch_no" type="hidden" runat="server" />
<input name="Str_Merch_no" type="hidden" value="<%=Str_Merch_no%>" />

<input name="Merch_First_Name" type="hidden" value="<%=Merch_First_Name%>" />
<input name="Merch_Last_Name" type="hidden" value="<%=Merch_Last_Name%>" />
<input name="Merch_Street_Addr" type="hidden" value="<%=Merch_Street_Addr%>" />
<input name="Merch_Street_Addr2" type="hidden" value="<%=Merch_Street_Addr2%>" />
<input name="Merch_City" type="hidden" value="<%=Merch_City%>" />
<input name="Merch_State" type="hidden" value="<%=Merch_State%>" />
<input name="Merch_Zip" type="hidden" value="<%=Merch_Zip%>" />
<input name="Merch_Phone_No" type="hidden" value="<%=Merch_Phone_No%>" />
<input name="Merch_Email_Addr" type="hidden" value="<%=Merch_Email_Addr%>" />


<input name="Field_Start_Dt" type="hidden" value="<%=Field_Start_Dt%>" />
<input name="Field_end_Dt" type="hidden" value="<%=Field_end_Dt%>" />
<input name="Key_Comp_Dt" type="hidden" value="<%=Key_Comp_Dt%>" />
<input name="DOA_Dt" type="hidden" value="<%=DOA_Dt%>" />		
	
<input name="TodayDate" type="hidden" value="<%=TodayDate%>" />		
			
<input name="visit_no" type="hidden" value="<%=visit_no%>" />

<input name="Collect_iVR_Time" type="hidden" value="<%=Collect_iVR_Time%>" />
<input name="night_visits" type="hidden" value="<%=night_visits%>" />
<input name="Mileage_flag" type="hidden" value="<%=Mileage_flag%>" />
<input name="Travel_flag" type="hidden" value="<%=Travel_flag%>" />

<input name="Job_Type" type="hidden" value="<%=Job_Type%>" />
<input name="Business_Type_id" type="hidden" value="<%=Business_Type_id%>" />

<input name="Work_Type_id" type="hidden" value="<%=Work_Type_id%>" />
<input name="Work_Type_Desc" type="hidden" value="<%=Work_Type_Desc%>" />

<input name="Data_Col_Method" type="hidden" value="<%=Data_Col_Method%>" />
<input name="overwritetime" type="hidden" value="<%=overwritetime%>" />
<input name="All_Data_Received" type="hidden" value="<%=All_Data_Received%>" />
<input name="collect_time_only" type="hidden" value="<%=collect_time_only%>" />
<input name="Ask_Q_HH_Used" type="hidden" value="<%=Ask_Q_HH_Used%>" />
<input name="HH_Status_Flag" type="hidden" value="<%=HH_Status_Flag%>" />

<input name="Collect_Header" type="hidden" value="<%=Collect_Header%>" />
<input name="Collect_Call_Form" type="hidden" value="<%=Collect_Call_Form%>" />

<input name="SS_Callform" type="hidden" value="<%=SS_Callform%>" />
<input name="Prod_Specific" type="hidden" value="<%=Prod_Specific%>" />
<input name="qdef_skippattern" type="hidden" value="<%=qdef_skippattern%>" />

<input name="Max_Mx_Per_Store" type="hidden" value="<%=Max_Mx_Per_Store%>" />
<input name="Max_Visit_Per_Store_Mx" type="hidden" value="<%=Max_Visit_Per_Store_Mx%>" />

<input name="Collect_Store_Mgr_Name" type="hidden" value="<%=Collect_Store_Mgr_Name%>" />

<input name="Product_Check_Flag" type="hidden" value="<%=Product_Check_Flag%>" />

<input name="Ask_EShelf_Question" type="hidden" value="<%=Ask_EShelf_Question%>" />

<input name="Call_Form_Type_No" type="hidden" value="<%=Call_Form_Type_No%>" />

<input name="Est_instore_minutes" type="hidden" value="<%=Est_instore_minutes%>" />
<input name="Business_Rule_Eckerd" type="hidden" value="<%=Business_Rule_Eckerd%>" />
<input name="Eckerd_Job_Last_question" type="hidden" value="<%=Eckerd_Job_Last_question%>" />

<input name="user_id" type="hidden" value="<%=user_id%>" />
<input name="PhotoButton" type="hidden" value="<%=PhotoButton%>" />
<input name="Bus_Rule5_Question" type="hidden" value="<%=Bus_Rule5_Question%>" />
<input name="Bus_Rule6_Question" type="hidden" value="<%=Bus_Rule6_Question%>" />
<input name="Bus_Rule28_Question" type="hidden" value="<%=Bus_Rule28_Question%>" />
<input name="Bus_Rule3_Question" type="hidden" value="<%=Bus_Rule3_Question%>" />
<input name="Bus_Rule4_Question" type="hidden" value="<%=Bus_Rule4_Question%>"  />
<input name="Bus_Rule7_Question" type="hidden" value="<%=Bus_Rule7_Question%>"  />

<%//From page CFJWTValidateSV.aspx %>
<input name="StrSwitchServerFlag" type="hidden" value="<%=StrSwitchServerFlag%>" />

<input name="Str_VisitMonth" type="hidden" value="<%=Str_VisitMonth%>" />
<input name="Str_visitday" type="hidden" value="<%=Str_visitday%>" />
<input name="Str_visityear" type="hidden" value="<%=Str_visityear%>" />
<input name="Str_timein_hrs" type="hidden" value="<%=Str_timein_hrs%>" />
<input name="Str_timein_min" type="hidden" value="<%=Str_timein_min%>" />
<input name="Str_cmb_timein" type="hidden" value="<%=Str_cmb_timein%>" />
<input name="Str_timeout_hrs" type="hidden" value="<%=Str_timeout_hrs%>" />
<input name="Str_timeout_min" type="hidden" value="<%=Str_timeout_min%>" />
<input name="Str_cmb_timeout" type="hidden" value="<%=Str_cmb_timeout%>" />
<input name="Str_txt_mileage" type="hidden" value="<%=Str_txt_mileage%>" />
<input name="Str_txt_drive" type="hidden" value="<%=Str_txt_drive%>" />
<input name="Str_rad_q_Past_Midnight" type="hidden" value="<%=Str_rad_q_Past_Midnight%>" />
<input name="Str_rad_q_HH_Used" type="hidden" value="<%=Str_rad_q_HH_Used%>" />
<input name="Str_rad_q_Ret_store_visit" type="hidden" value="<%=Str_rad_q_Ret_store_visit%>" />
<input name="Str_Radio_EShelf" type="hidden" value="<%=Str_Radio_EShelf%>" />
<input name="Str_Ask_EShelf_Question" type="hidden" value="<%=Str_Ask_EShelf_Question%>" />
<input name="Str_Bus_Rule3_Question" type="hidden" value="<%=Str_Bus_Rule3_Question%>" />
<input name="Str_rad_q_BR3" type="hidden" value="<%=Str_rad_q_BR3%>" />
<input name="Str_Bus_Rule4_Question" type="hidden" value="<%=Str_Bus_Rule4_Question%>" />
<input name="Str_rad_q_BR4" type="hidden" value="<%=Str_rad_q_BR4%>" />
<input name="Str_Bus_Rule5_Question" type="hidden" value="<%=Str_Bus_Rule5_Question%>" />
<input name="Str_rad_q_BR5" type="hidden" value="<%=Str_rad_q_BR5%>" />
<input name="Str_Bus_Rule6_Question" type="hidden" value="<%=Str_Bus_Rule6_Question%>" />
<input name="Str_rad_q_BR6" type="hidden" value="<%=Str_rad_q_BR6%>" />
<input name="Str_Bus_Rule7_Question" type="hidden" value="<%=Str_Bus_Rule7_Question%>" />
<input name="Str_rad_q_BR7" type="hidden" value="<%=Str_rad_q_BR7%>" />
<input name="Str_Bus_Rule28_Question" type="hidden" value="<%=Str_Bus_Rule28_Question%>" /> 
<input name="Str_rad_q_BR28" type="hidden" value="<%=Str_rad_q_BR28%>" />
<input name="Str_Manager_Title" type="hidden" value="<%=Str_Manager_Title%>" /> 
<input name="Str_txt_Manager_name" type="hidden" value="<%=Str_txt_Manager_name%>" />
<input name="Client_Access_Flag" type="hidden" value="<%=Client_Access_Flag%>" />
<input name="Pre_Approved_Flag" type="hidden" value="<%=Pre_Approved_Flag%>" />
<input name="Photo_q_complete" type="hidden" value="<%=Photo_q_complete%>" />

<input name="Photo_Q_No" type="hidden" value="" />
<input name="Photo_q_Res_Val" type="hidden" value="" />
<input name="Photo_Prod_upc" type="hidden" value="" />
<input name="Photo_upc_desc" type="hidden" value="" />
<input name="Photo_q_desc" type="hidden" value="" />
<input name="Photo_Res_desc" type="hidden" value="" />
<input name="RTS_Url" type="hidden" value="<%=RTS_Url%>"/>
<input name="AppleIpadUsed" type="hidden" value="<%=AppleIpadUsed%>"/>
<input name="NewScreenPage" type="hidden" value="<%=NewScreenPage%>"/>
<input name="StrNewCallFormPathLink" type="hidden" value="<%=StrNewCallFormPathLink%>"/>
<input name="BusRule_CommentBoxFlag" type="hidden" value="<%=BusRule_CommentBoxFlag%>"/>
<input name="Str_Sv_Panel_id" type="hidden" value="<%=Str_Sv_Panel_id%>" /> 
<input name="Client_id" type="hidden" value="<%=Client_id%>" /> 
<input name="PhotoFolderType" type="hidden" value="<%=PhotoFolderType%>" />
</center>
</asp:Content>

