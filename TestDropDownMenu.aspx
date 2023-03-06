<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestDropDownMenu.aspx.cs" Inherits="TestDropDownMenu" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript"  language="javascript">

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
	


//************************ Pop Up ****************************
function Storetrackingpopdiv(w, h) 
{
          
 alert("check"); 
             var objMyCtrl = document.getElementById("ITS_MyControl_FullPageDiv");
                 objMyCtrl.style.visibility = "visible";
                
                var popUp = document.getElementById("JWTCS_Info_POPup");
                var ScrollTop = document.body.scrollTop;
                if (ScrollTop == 0) {
                    if (window.pageYOffset)
                        ScrollTop = window.pageYOffset;
                    else
                        ScrollTop = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
                }

                //popUp.style.top = ScrollTop + 50; //"200px";
                popUp.style.top = "10%"; 
                popUp.style.left = "10%";
                //popUp.style.width = w + "px";
                //popUp.style.width =popUp.style.width.substr(0,popUp.style.width.indexOf("px"));
               popUp.style.height = h + "px";
                
                //Test document.getElementById("divName").innerHTML.length;
                
                
                        var popUpMenuWidth=document.getElementById("ctl00_ContentPlaceHolder1_JWT_Reported_Question").clientWidth;
                       
                     // alert("popUpMenuWidth=" + popUpMenuWidth); 
                       // popUpMenuWidth="1385"
                     //var popUpWidth=document.getElementById("JWTCS_Info_POPup").clientWidth;
                       
                       //alert("popUpWidth=" + popUpWidth); 
                        
                          var windowWidth = document.aspnetForm.clientWidth;  
                        // alert("windowWidth=" + windowWidth);  
                           if (windowWidth==0)  
                        {
                            var windowWidth = document.body.clientWidth;  
                           // alert("windowWidth=" + windowWidth);  
                       }
                       // alert("windowWidth=" + windowWidth);  
                         
                       // var popUpLeft = ((windowWidth - popUpWidth) / 2); 
                          var popUpLeft = (Math.floor((windowWidth - popUpMenuWidth) / 2)).toString() + "px";  
                        // alert("popUpLeft=" + popUpLeft);     
                          var popUpLeftCheck = (Math.floor((windowWidth - popUpMenuWidth) / 2)).toString();  
                        //alert("popUpLeftCheck=" + popUpLeft);  
                       //  popUpLeftCheck="1"
                          MenuWidth= parseInt(popUpLeftCheck)+ parseInt(popUpMenuWidth);
                         // alert("MenuWidth=" + MenuWidth); 
                            
                        if (popUpLeftCheck>0)
                        {
                                popUp.style.left=popUpLeft;
                                
                               if (MenuWidth>=windowWidth)
                                {
                                     windowWidth=windowWidth-50;
                                     popUp.style.width=windowWidth+ "px";
                                     //document.getElementById("Bot_TD").setAttribute("class", "Button_Align");
                                     // document.getElementById('Bot_TD').style.cssText = 'text-align: left;' 
                                     //alert("MenuWidth>=windowWidth")
                                     document.getElementById("ctl00_ContentPlaceHolder1_Merch_JWT_Info").style.width=windowWidth;

                                }
                           //  alert("normal")
                             
                        }
                        else
                        { 
                              windowWidth=windowWidth-50;
                              popUp.style.left = "2%";
                              popUp.style.width=windowWidth+ "px";
                              //document.getElementById("Bot_TD").setAttribute("class", "Button_Align");
                             // document.getElementById('Bot_TD').style.cssText = 'text-align: left;' 
                             //alert("5percent")
                             document.getElementById("ctl00_ContentPlaceHolder1_Merch_JWT_Info").style.width=windowWidth;

                        }

            

                popUp.style.visibility = "visible";
    
   
     
}
function hidePopup()
{
 var objMyCtrl = document.getElementById("ITS_MyControl_FullPageDiv");
    objMyCtrl.style.visibility = "hidden";
    
  var popUp = document.getElementById("JWTCS_Info_POPup");
  popUp.style.visibility = "hidden";
  return false;
}
function SavePopup()
{

        user_id=document.aspnetForm.user_id.value;
		//alert("user_id=" + user_id);
		Email_Active_Flag=document.aspnetForm.Email_Active_Flag.value;
		ILang_Id=document.aspnetForm.ILang_Id.value;
		
        Collect_MerchPOPupinfo=document.aspnetForm.ctl00$ContentPlaceHolder1$Merch_JWT_Info.value;
       //Collect_MerchPOPCheck=RemoveSpaces(Collect_MerchPOPupinfo) 
        
        //alert("Collecee" + Collect_MerchPOPCheck + "HH");
        
       if (trim(Collect_MerchPOPupinfo)=="- - Select Job/Wave/Task/Chain/Store - -")                                    
       {
            //alert("good job") 
            return false;        
       }
    
        //alert("Collect_MerchPOPupinfo=" + Collect_MerchPOPupinfo);
        ArrayEleList = Collect_MerchPOPupinfo.split("/");
		 //alert("ArrayEleList=" + ArrayEleList);
		arraylength = ArrayEleList.length
	    //alert("arraylength=" + arraylength) 
		arraylength=eval(arraylength)

        //******** Job no
             Ele_Jobno = ArrayEleList[0].valueOf()
            // alert("Ele_Jobno=" + Ele_Jobno) 
             if (isNaN(Ele_Jobno)==true)
             {
                   return false;   
             }
            var JobExists=document.getElementById("ctl00_ContentPlaceHolder1_txt_jobno");
            //alert("JobExists=" + JobExists) 
            if (JobExists!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$txt_jobno.value=Ele_Jobno ;
            }
       //********wave no
             Ele_waveno = ArrayEleList[1].valueOf()
            // alert("Ele_waveno=" + Ele_waveno) 
        
            var waveExists=document.getElementById("ctl00_ContentPlaceHolder1_txt_waveno");
            //alert("waveExists=" + waveExists) 
            if (waveExists!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$txt_waveno.value=Ele_waveno ;
            }  
       //********Task no
             Ele_Task = ArrayEleList[2].valueOf()
            // alert("Ele_Task=" + Ele_Task) 
        
            var TaskExists=document.getElementById("ctl00_ContentPlaceHolder1_txt_taskno");
            //alert("TaskExists=" + TaskExists) 
            if (TaskExists!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$txt_taskno.value=Ele_Task ;
            }
       //********Chain no
             Ele_chainno = ArrayEleList[3].valueOf()
             //alert("Ele_chainno=" + Ele_chainno) 
        
            var chainExists=document.getElementById("ctl00_ContentPlaceHolder1_txt_chainno");
           // alert("chainExists=" + chainExists) 
            if (chainExists!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$txt_chainno.value=Ele_chainno ;
            }   
       //********Store no
             Ele_storeno = ArrayEleList[4].valueOf()
             //alert("Ele_storeno=" + Ele_storeno) 
        
            var storeExists=document.getElementById("ctl00_ContentPlaceHolder1_txt_storeno");
            //alert("storeExists=" + storeExists) 
            if (storeExists!=null)
            {
               document.aspnetForm.ctl00$ContentPlaceHolder1$txt_storeno.value=Ele_storeno ;
            }   
          //********Email address
            // Ele_Email_add= ArrayEleList[5].valueOf()
            // alert("Ele_Email_add=" + Ele_Email_add) 
        
//            var EmailExists=document.getElementById("ctl00_ContentPlaceHolder1_txt_EmailAdd");
//           // alert("EmailExists=" + EmailExists) 
//            if (EmailExists!=null)
//            {
//               document.aspnetForm.ctl00$ContentPlaceHolder1$txt_EmailAdd.value=Ele_Email_add ;
//            }      
//            if (user_id=="")
//		    {
//                if (ILang_Id=="1") 
//                 {
//                              //********Phone number
//                                 Ele_Phone_no= ArrayEleList[6].valueOf()
//                                 alert("Ele_Phone_no=" + Ele_Phone_no) 
//                                 AreaCode=Ele_Phone_no.substring(0,3)
//                                 alert("AreaCode=" + AreaCode)  
//                                 ThreeCode=Ele_Phone_no.substring(3,6)
//                                 alert("ThreeCode=" + ThreeCode) 
//                                 FourCode=Ele_Phone_no.substring(6,10)
//                                 alert("FourCode=" + FourCode) 
//                                 
//                                var Phone1Exists=document.getElementById("ctl00_ContentPlaceHolder1_txt_Phone1");
//                                alert("Phone1Exists=" + Phone1Exists) 
//                                if (Phone1Exists!=null)
//                                {
//                                   document.aspnetForm.ctl00$ContentPlaceHolder1$txt_Phone1.value=AreaCode ;
//                                }     
//                                var Phone2Exists=document.getElementById("ctl00_ContentPlaceHolder1_txt_Phone2");
//                                alert("Phone2Exists=" + Phone1Exists) 
//                                if (Phone2Exists!=null)
//                                {
//                                   document.aspnetForm.ctl00$ContentPlaceHolder1$txt_Phone2.value=ThreeCode ;
//                                }     
//                                var Phone3Exists=document.getElementById("ctl00_ContentPlaceHolder1_txt_Phone3");
//                                alert("Phone3Exists=" + Phone3Exists) 
//                                if (Phone3Exists!=null)
//                                {
//                                   document.aspnetForm.ctl00$ContentPlaceHolder1$txt_Phone3.value=FourCode ;
//                                }     
//                                 
//                 }
//            }
            
    var popUp = document.getElementById("JWTCS_Info_POPup");
        popUp.style.visibility = "hidden";
   var objMyCtrl = document.getElementById("ITS_MyControl_FullPageDiv");
       objMyCtrl.style.visibility = "hidden";
    
  return false;
}
 
function RemoveSpaces(string) 
{
      alert("string=" + string + "HH");
 return string.replace(" ","");
}

  </script>
 <center> 
<div id="ITS_MyControl_FullPageDiv" >
</div>  
<div id="JWTCS_Info_POPup" style="visibility:hidden"  class="Div_Color" >
      <table  bgcolor="#f5fffa"    cellpadding="0" cellspacing="0">
                
             <tr bgcolor="#0066FF">
                    <td width="96%" height="10%" class="PopHeaderText" align="center">
                        &nbsp;
                       <asp:Label ID="Label19" runat="server" Text="Reported Questions"></asp:Label>
                        
                    </td>
                    <td align="right"  width="4%" height="10%">
                         <img src="Images/x.jpg" onclick="return hidePopup();">
                    </td>
            </tr>                
               <tr  >
                   <td colspan="2" align="center" valign="top">
                          <table style="width: 100%;" class="grid" border="1" cellspacing="1"  bordercolor="dodgerblue">
                              <tr>
                                       
                                        <td style="width: 100%;" align="center">
                                              <asp:DropDownList  style="font-family: Courier"  runat="server" ID="JWT_Reported_Question"   >
                                                 <asp:ListItem></asp:ListItem>
                                                 <asp:ListItem></asp:ListItem>
                                              </asp:DropDownList>   
                                        </td>
                                </tr>
                        </table>
               </td>
            </tr>
             <tr>
                        <td align="center"  id="Bot_TD"  colspan="2">
                             
                            <asp:Button  OnClientClick="return hidePopup()" ID="Button1" runat="server" Text="Close"  CssClass="Button" ></asp:Button>
                        </td>
                </tr>        
        </table> 
</div>        

   <input type="text"   id="Txt_merch_no"  onclick="Storetrackingpopdiv('1100','100');return false" /> 
</center>
</asp:Content>

