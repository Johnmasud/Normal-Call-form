<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  viewStateEncryptionMode="Never"  validateRequest="false" EnableViewStateMac="false" enableViewState="true" CodeFile="CFJWT_Input_Photo_Option.aspx.cs" Inherits="CFJWT_Input_Photo_Option" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 





<script type="text/javascript" language="javascript1.1">



function Load()
	{
	     
	}
function DisableButtons()
	{
	     //******* Disabled the buttons
		//ctl00$ContentPlaceHolder1$Button2" value="Next >>"
		document.aspnetForm.ctl00$ContentPlaceHolder1$Submit.disabled=true;
	}
function AbleButtons()
	{
	     //ctl00$ContentPlaceHolder1$Button2" value="Next >>"
		document.aspnetForm.ctl00$ContentPlaceHolder1$Submit.disabled=false;
	}
function GetAccess_Call_Form(P_visit_dt,CF_Access,Bus_rule22_MV_Flag,Bus_rule22_MV_Remain)
{
      // alert("P_visit_dt=" + P_visit_dt);
       Golite_status= document.aspnetForm.Golite_status.value;
       if (Golite_status=="Y")
       {
        document.aspnetForm.GoLiteDate.value=Trim(P_visit_dt);
       }
//	    alert("Bus_rule22_MV_Remain=" + Bus_rule22_MV_Remain); 
	   document.aspnetForm.Job_Visit_Date.value=P_visit_dt;
	   Separate_Visit_Date(P_visit_dt)
	   document.aspnetForm.Photo_CF_Access.value=CF_Access;
	    document.aspnetForm.Bus_rule22_MV_Flag.value=Bus_rule22_MV_Flag;
	   document.aspnetForm.Bus_rule22_MV_Remain.value=Bus_rule22_MV_Remain;
	   document.aspnetForm.GridAddNewVisit.value=""; 
		//return false;
        document.aspnetForm.action  = "CFJWTValidateSV.aspx";
        document.aspnetForm.submit();
		return true;
}

function GetAccess_Photo(P_visit_dt,CF_Access,PhotoByQ,Bus_rule22_MV_Flag,Bus_rule22_MV_Remain)
{
        // alert("Bus_rule22_MV_Flag=" + Bus_rule22_MV_Flag);
	    // alert("Bus_rule22_MV_Remain=" + Bus_rule22_MV_Remain);
	    // alert("CF_Access=" + CF_Access);
		//return false;
		 Golite_status= document.aspnetForm.Golite_status.value;
           if (Golite_status=="Y")
           {
            document.aspnetForm.GoLiteDate.value=Trim(P_visit_dt);
           }
		 Separate_Visit_Date(P_visit_dt)
		 document.aspnetForm.Job_Visit_Date.value=P_visit_dt;
		 document.aspnetForm.Photo_CF_Access.value=CF_Access;
		 document.aspnetForm.GridAddNewVisit.value=""; 
		 document.aspnetForm.Bus_rule22_MV_Flag.value=Bus_rule22_MV_Flag;
	     document.aspnetForm.Bus_rule22_MV_Remain.value=Bus_rule22_MV_Remain;
	  // photo by Question check 
        Photo_By_QuestionFlag=document.aspnetForm.Photo_By_QuestionFlag.value
	   // alert("Photo_By_QuestionFlag=" + Photo_By_QuestionFlag);
	    if (PhotoByQ=="Y")
	        {
	                    document.aspnetForm.action = "CFPictureByQuestionList.aspx";
                        document.aspnetForm.submit();
                        return false;	 
	        }
	    else
	        {	
                     document.aspnetForm.action  = "CFPictureGetFileOption.aspx";
                     document.aspnetForm.submit();
	                 return true;
	        }
}
function GetAccess_Video(P_visit_dt,CF_Access,PhotoByQ,Bus_rule22_MV_Flag,Bus_rule22_MV_Remain)
{
        // alert("Bus_rule22_MV_Flag=" + Bus_rule22_MV_Flag);
	    // alert("Bus_rule22_MV_Remain=" + Bus_rule22_MV_Remain);
	    // alert("CF_Access=" + CF_Access);
		//return false;
		 Golite_status= document.aspnetForm.Golite_status.value;
           if (Golite_status=="Y")
           {
            document.aspnetForm.GoLiteDate.value=Trim(P_visit_dt);
           }
		 Separate_Visit_Date(P_visit_dt)
		 document.aspnetForm.Job_Visit_Date.value=P_visit_dt;
		 document.aspnetForm.Photo_CF_Access.value=CF_Access;
		 document.aspnetForm.GridAddNewVisit.value=""; 
		 document.aspnetForm.Bus_rule22_MV_Flag.value=Bus_rule22_MV_Flag;
	     document.aspnetForm.Bus_rule22_MV_Remain.value=Bus_rule22_MV_Remain;
	  // photo by Question check 
        Photo_By_QuestionFlag=document.aspnetForm.Photo_By_QuestionFlag.value
	   // alert("Photo_By_QuestionFlag=" + Photo_By_QuestionFlag);
	    //if (PhotoByQ=="Y")
	   //     {
	    //                document.aspnetForm.action = "CFPictureByQuestionList.aspx";
        //                document.aspnetForm.submit();
         //               return false;	 
	     //   }
	   // else
	    //    {	
                     document.aspnetForm.action  = "CFVideoMultiFile.aspx";
                     document.aspnetForm.submit();
	                 return true;
	      //  }
}

function NextPage()
{
        document.aspnetForm.Bus_rule22_MV_Flag.value="";
        document.aspnetForm.GridAddNewVisit.value="Yes"; 
         document.aspnetForm.Job_Visit_Date.value="";
        document.aspnetForm.action  = "CFJWTValidateSV.aspx";
        document.aspnetForm.submit();
		return true;
}
function DoSubmitBack()
	{
	    //DisableButtons()
    	   
    	    NewScreenPage=document.aspnetForm.NewScreenPage.value
           StrNewCallFormPathLink=document.aspnetForm.StrNewCallFormPathLink.value
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
function Separate_Visit_Date(v_date_object)
{

 	v_date_sys_rule=document.aspnetForm.DateFormat.value
  //alert("v_date_object="+ v_date_object);
 //alert("v_date_sys_rule="+ v_date_sys_rule);
 	 
	 	
		var v_date_format
		var v_date
		var datearray
		var dateformatarray
		var v_month
		var v_day
		var v_year
		var i
		var v_delimiter
		v_date_format = v_date_sys_rule
		for(i=0; i<v_date_format.length; i++)
		{
				//alert("LoopValue="+ v_date_format.charAt(i).toUpperCase());
			if((v_date_format.charAt(i).toUpperCase()!='Y')&&(v_date_format.charAt(i).toUpperCase()!="M")&&(v_date_format.charAt(i).toUpperCase()!='D'))
			{
				//alert("1="+ v_date_format.charAt(i).toUpperCase());

				v_delimiter= v_date_format.charAt(i)
				break;	
			}
		}
		//alert("v_delimiter="+ v_delimiter);
		//v_date = eval(v_date_object+ ".value");
		v_date = v_date_object
	     //alert("v_date_format="+ v_date_format);
		dateformatarray = v_date_format.split(v_delimiter)
		var datearray = v_date.split(v_delimiter)
		
	 
		
		for(i=0; i<dateformatarray.length; i++)
		{
			if (dateformatarray[i] == "mm")
			{
			v_month = datearray[i];
			}
			if (dateformatarray[i] == "dd")
			{
			v_day = datearray[i];
			}
			if (dateformatarray[i] == "yy" || dateformatarray[i] == "yyyy")
			{
				Year_Size=dateformatarray[i]	
				v_year = datearray[i];
			}
		}
            			 
		
// alert("v_month="+ v_month);
// alert("v_day="+ v_day);
// alert("v_year="+ v_year);
		
		                //***** Assign date to hidden variables
		               
                        
          document.aspnetForm.Str_VisitMonth.value=v_month;
          document.aspnetForm.Str_visitday.value=v_day;
          document.aspnetForm.Str_visityear.value=v_year;
}
function GoToPhotoPage()
	{                
	   GoToPage = "CFPictureGetFileOption.aspx"    
       document.aspnetForm.action =GoToPage;
       document.aspnetForm.submit();
       return false;	
	}
function GoToProdDataOrAssembly()
{
//alert("GoToProdDataOrAssembly");
     Assem_Flag=document.aspnetForm.Display_Assembly_btn.value
      //alert("Assem_Flag=" + Assem_Flag);
     Prodata_Flag=document.aspnetForm.Display_Prod_Data_btn.value
     //alert("Prodata_Flag=" + Prodata_Flag);
     StrAssembly_Url=document.aspnetForm.Assembly_Url.value
     // alert("StrAssembly_Url=" + StrAssembly_Url);
     StrProdData_Url=document.aspnetForm.Prod_Data_Url.value
    // alert("StrProdData_Url=" + StrProdData_Url);
      Merch_no=document.aspnetForm.Str_Merch_no.value
    
     AccessToNewAssemblyApp_flag=document.aspnetForm.AccessToNewAssemblyApp_flag.value;
      AccessToNewDataCollectApp_flag=document.aspnetForm.AccessToNewDataCollectApp_flag.value;
  
    
     if (Assem_Flag=="Y")
     {
             //if ((Merch_no=="116597")||(Merch_no=="122751")||(Merch_no=="116794"))
             if(AccessToNewAssemblyApp_flag=="Y")
	         {
	              window.location.href = StrAssembly_Url;
	              return false;	
	         }
	         else
	         {
                    document.aspnetForm.action=StrAssembly_Url
             }
     }
      if (Prodata_Flag=="Y")
     {
     
             if(AccessToNewDataCollectApp_flag=="Y")
	         {
	              window.location.href = StrProdData_Url;
	              return false;	
	         }
	         else
	         {
                    document.aspnetForm.action=StrProdData_Url;
             }
     }
    // alert("StrData_Collection_Path=" + StrData_Collection_Path);
	 
	 //document.aspnetForm.action="http://mi11.sparinc.com/papdcs/index.aspx"
     document.aspnetForm.submit();
	 return false;	
}
//************************* Trim function *******************************
function Trim(str) {
	var resultStr = "";
	
	resultStr = TrimLeft(str);
	resultStr = TrimRight(resultStr);
	
	return resultStr;
}
function TrimLeft(str) {
	var resultStr = "";
	var i = len = 0;

	// Return immediately if an invalid value was passed in
	if (str+"" == "undefined" || str == null)	
		return null;

	// Make sure the argument is a string
	str += "";

	if (str.length == 0) 
		resultStr = "";
	else {	
  		// Loop through string starting at the beginning as long as there are spaces.
//	  	len = str.length - 1;
		len = str.length;
		
  		while ((i <= len) && (str.charAt(i) == " "))
			i++;

   		// When the loop is done, we're sitting at the first non-space char,
 		// so return that char plus the remaining chars of the string.
  		resultStr = str.substring(i, len);
  	}

  	return resultStr;
}
function TrimRight(str) 
{
	var resultStr = "";
	var i = 0;

	// Return immediately if an invalid value was passed in
	if (str+"" == "undefined" || str == null)	
		return null;

	// Make sure the argument is a string
	str += "";
	
	if (str.length == 0) 
		resultStr = "";
	else {
  		// Loop through string starting at the end as long as there are spaces.
  		i = str.length - 1;
  		while ((i >= 0) && (str.charAt(i) == " "))
 			i--;
 			
 		// When the loop is done, we're sitting at the last non-space char,
 		// so return that char plus all previous chars of the string.
  		resultStr = str.substring(0, i + 1);
  	}
  	
  	return resultStr;  	
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
            
         </asp:Table>

    </asp:TableCell>
</asp:TableRow> 
</asp:Table>

<hr color="dodgerblue">
<br />
<center>
  
<div id="ShowJWTInfo" runat="server">
 
</div> 
   
<asp:GridView  ID="StoreInfo"   Width="60%" DataKeyNames="visit_dt,Call_Form_Reported,Photo_access,Report_New_Visit,PhotoBy_Question_status,Bus_rule22_status,Bus_rule22_Photo_Remain,EnableVideo_Option" Font-Size="Medium"  BorderColor="DodgerBlue"  AutoGenerateColumns="false"   OnRowDataBound="CreateButtonLink" RowStyle-CssClass="reportTableItem"  HeaderStyle-CssClass="reportTableHeadernew"  runat="server">
<Columns>
    <asp:BoundField  ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}"  DataField="visit_dt" HtmlEncode="false" />
   <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Call_Form_Reported"/>
   <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Bus_rule22_Photo_Required"/>
   <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Photo_no"/>
    
    <asp:TemplateField>
      
     <HeaderTemplate>
     
         <asp:Label ID="nothing" runat="server" Text="" CssClass="reportCriteriaHeader"></asp:Label>  
                
   </HeaderTemplate>
   <ItemTemplate>
     <asp:Button   ID="CFBttton_Status" runat="server" Text="Call Form" CssClass="Button"></asp:Button>&nbsp
      <asp:Button   ID="PhotoBttton_Status" runat="server" Text="Store Visit Photo Upload" CssClass="Button"></asp:Button>
        <asp:Button   ID="PhotoBttton_Question" runat="server" Text="Question Specific Photo Upload" CssClass="Button"></asp:Button>
      <asp:Button   ID="VideoBttton_Status" runat="server" Text="video Upload" CssClass="Button"></asp:Button>
   </ItemTemplate>
    </asp:TemplateField>
</Columns> 
</asp:GridView>
  <br /> 
  <%														
  
    if (Display_Assembly_btn == "Y") 
    {
        if (NewScreenPage == "Y")
        {
            %>
             <asp:Button  OnClientClick="return GoToProdDataOrAssembly()"  id="Button8" runat="server"   text="Assembly Data Collection" CssClass="Button"></asp:Button>
		      &nbsp&nbsp
            <%
        }
    }
    if (Display_Prod_Data_btn == "Y") 
    {
        if (NewScreenPage == "Y")
        {
            %>
             <asp:Button  OnClientClick="return GoToProdDataOrAssembly()"  id="Button9" runat="server"   text="Product Data Collection" CssClass="Button"></asp:Button>
		      &nbsp&nbsp
            <%
        }
    }  
 %> 
 
 
<asp:Button   OnClientClick="return DoSubmitBack()" ID="Button3" runat="server" Text="<< Back" CssClass="Button"></asp:Button>
&nbsp&nbsp&nbsp		  
<asp:Button OnClientClick="return NextPage()" ID="Add_New_Visit_Dt" runat="server" Text="Report New Visit" CssClass="Button"></asp:Button>
<br />

 <input id="Merch_no" type="hidden" runat="server" />
<input name="Job_No" type="hidden" value="<%=Job_No%>" />
<input name="Wave_No" type="hidden" value="<%=Wave_No%>" />
<input name="Task_No" type="hidden" value="<%=Task_No%>" />
<input name="Chain_No" type="hidden" value="<%=Chain_No%>" />
<input name="Store_No" type="hidden" value="<%=Store_No%>" />
<input name="Str_Merch_no" type="hidden" value="<%=Str_Merch_no%>" />
<input name="txt_EmailAdd" type="hidden" value="<%=txt_EmailAdd%>" />
<input name="txt_Mobile_Email" type="hidden" value="<%=txt_Mobile_Email%>" />
<input name="txt_Phone1" type="hidden" value="<%=txt_Phone1%>" />  
<input name="txt_Phone2" type="hidden" value="<%=txt_Phone2%>" />  
<input name="txt_Phone3" type="hidden" value="<%=txt_Phone3%>" /> 
<input name="CellProvider" type="hidden" value="<%=CellProvider%>" /> 
<input name="Hidden_PhoneStatus" type="hidden" value="<%=Hidden_PhoneStatus%>" /> 
<input name="Job_Visit_Date" type="hidden" value="" />
<input name="Str_VisitMonth" type="hidden" value="" />
<input name="Str_visitday" type="hidden" value="" />
<input name="Str_visityear" type="hidden" value="" />
<input name="Photo_CF_Access" type="hidden" value="" />
<input name="StrGridDates" type="hidden" value="<%=StrGridDates%>" />
<input name="GridAddNewVisit" type="hidden" value="" />
<input name="Photo_By_QuestionFlag" type="hidden" value="<%=Photo_By_QuestionFlag%>"/>
 <input name="DateFormat" type="hidden" value="<%=DateRule%>" />
 <input name="Bus_rule22_MV_Remain" type="hidden" value="" />
<input name="Bus_rule22_MV_Flag" type="hidden" value="" />
<input name="Bus_rule22_MV_NewVisit" type="hidden" value="<%=Bus_rule22_MV_NewVisit%>" />
<input name="NewScreenPage" type="hidden" value="<%=NewScreenPage%>"/>
<input name="StrNewCallFormPathLink" type="hidden" value="<%=StrNewCallFormPathLink%>"/>
<input name="Prod_Data_Url" type="hidden" value="<%=Prod_Data_Url%>"/>
<input name="Assembly_Url" type="hidden" value="<%=Assembly_Url%>"/>
<input name="Display_Assembly_btn" type="hidden" value="<%=Display_Assembly_btn%>"/>
<input name="Display_Prod_Data_btn" type="hidden" value="<%=Display_Prod_Data_btn%>"/>
<input name="ctl00$ContentPlaceHolder1$uparm_merch_no" type="hidden" value="<%=Str_Merch_no%>"/>
<input name="ctl00$ContentPlaceHolder1$uparm_job_no" type="hidden" value="<%=Job_No%>"/>
<input name="ctl00$ContentPlaceHolder1$uparm_wave_no" type="hidden" value="<%=Wave_No%>"/>
<input name="ctl00$ContentPlaceHolder1$uparm_task_no" type="hidden" value="<%=Task_No%>"/>
<input name="ctl00$ContentPlaceHolder1$uparm_chain_no" type="hidden" value="<%=Chain_No%>"/>
<input name="ctl00$ContentPlaceHolder1$uparm_store_no" type="hidden" value="<%=Store_No%>"/> 
<input name="ctl00$ContentPlaceHolder1$uparm_business_type_id" type="hidden" value="<%=Business_Type_id%>"/>
<input name="Return_CallFormPath" type="hidden" value="<%=Return_CallFormPath%>"/>
<input name="DoneGoToCallForm" type="hidden" value="<%=Return_CallFormPath%>"/>
<input name="MultiVisit_VideoBackbtn" type="hidden" value="Y"/>
<input name="Str_Sv_Panel_id" type="hidden" value="<%=Str_Sv_Panel_id%>" />
<input name="GoLiteDate" type="hidden" value="<%=GoLiteDate%>" /> 
<input name="Golite_status" type="hidden" value="<%=Golite_status%>" />  
<input name="AccessToNewAssemblyApp_flag" type="hidden" value="<%=StrAccessToNewAssemblyApp_flag%>"/>  
<input name="AccessToNewDataCollectApp_flag" type="hidden" value="<%=StrAccessToNewDataCollectApp_flag%>"/>  
</center>
</asp:Content>

