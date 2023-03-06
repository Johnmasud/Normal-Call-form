<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestDropDown.aspx.cs" Inherits="TestDropDown" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>


<script type="text/javascript"  language="javascript">

 
function Load()
{
	document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[0].style.backgroundColor = 'White'; 
    document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[1].style.backgroundColor = 'Red'; 
	document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[2].style.backgroundColor = 'Yellow'; 
	document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[3].style.backgroundColor = 'blue'; 
//	document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[4].style.backgroundColor = 'White'; 
//    document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[5].style.backgroundColor = 'White'; 
//	document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[6].style.backgroundColor = 'White'; 
//	document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[7].style.backgroundColor = 'White'; 
}

function DisplayColor()
	{
	     //******* Disabled the buttons
		  alert("DisplayColor")
		  //document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[1].style.backgroundColor = 'Red';
		  var ddl = document.getElementById("<%=Test_DDMenu.ClientID%>");
		  var colr = ddl.options[ddl.selectedIndex].value;
		  		  
		  		  
		  if(colr=="0")
		  {			
			document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.style.backgroundColor ="";
			document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.style.backgroundColor = 'White';
		  }
		  else if(colr=="1")
		  {			
			document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.style.backgroundColor ="";
			document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.style.backgroundColor = 'Red';
		  }
		  else if(colr=="2")
		  {			
			document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.style.backgroundColor ="";
			document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.style.backgroundColor = 'Yellow';
		  }
		 
	}
	
function DisplayColor2(MenuId)
{
        alert("MenuId=" + MenuId)
        var ddl = document.getElementById("<%=Test_DDMenu.ClientID%>");
 	    var colr = ddl.options[ddl.selectedIndex].value;
 	    alert("colr=" + colr)
 	   // MenuId.options[ddl.selectedIndex].style.backgroundColor = 'Yellow'
 	    
 	    
 	    MenuColor=document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[ddl.selectedIndex].style.backgroundColor;
 	     alert("MenuColor=" + MenuColor)
 	     
 	      if(colr=="1")
		   {	
 	        document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.style.backgroundColor ="";
            ddl.style.backgroundColor =document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[ddl.selectedIndex].style.backgroundColor;
           }
           else
           {
                document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.style.backgroundColor ="";
           }
      //document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.style.backgroundColor='red';
  alert("good")
}
function DisplayColor3()
{

        alert("New")
        var ddl = document.getElementById("<%=Test_DDMenu.ClientID%>");
         for(var i = 0; i < ddl.options.length; i++) 
         {
                MenuColor=document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[i].style.backgroundColor;
 	            alert("MenuColor=" + MenuColor)
             
                if(i == ddl.selectedIndex) 
                {
                    
                    ddl.style.backgroundColor = 'red';
                } 
                else 
                {
                     
                    ddl.style.backgroundColor =document.aspnetForm.ctl00$ContentPlaceHolder1$Test_DDMenu.options[ddl.selectedIndex].style.backgroundColor;
                }
          }
}
function DisplayColor4(id)
{

      id.style.backgroundColor=id.options[id.selectedIndex].style.backgroundColor
}
</script>

  <table  bgcolor="#f5fffa"    cellpadding="0" cellspacing="0">
                
             <tr bgcolor="#0066FF">
                    <td width="96%" height="10%" class="PopHeaderText" align="center">
                        &nbsp;
                       <asp:Label ID="Label19" runat="server" Text="Test"></asp:Label>
                        
                    </td>
                    
            </tr>                
               <tr  >
                   <td colspan="2" align="center" valign="top">
                          <table style="width: 100%;" class="grid" border="1" cellspacing="1"  >
                              <tr>
                                        <td style="width: 100%;" align="center">
                                              <asp:DropDownList    style="font-family: Courier;"   runat="server" ID="Test_DDMenu"   >
                                                <asp:ListItem   Value="0">white</asp:ListItem>
                                                <asp:ListItem   Value="1">red</asp:ListItem>
                                                <asp:ListItem    Value="2">yellow</asp:ListItem>
                                                <asp:ListItem   Value="3">blue</asp:ListItem>
                                                <asp:ListItem   Value="4">blue</asp:ListItem>
                                                <asp:ListItem   Value="5">blue</asp:ListItem>
                                                <asp:ListItem   Value="6">blue</asp:ListItem>
                                                <asp:ListItem   Value="7">blue</asp:ListItem>
                                              </asp:DropDownList>   
                                        </td>
                                </tr>
                        </table>
               </td>
            </tr>
             
        </table> 
        <b />
  

</asp:Content>

