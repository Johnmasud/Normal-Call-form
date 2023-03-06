<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableViewStateMac="false" CodeFile="ProductLayoutCallForm.aspx.cs" Inherits="ProductLayoutCallForm" EnableViewState="false" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="ITS_MyControl_FullPageDiv" >
</div>

<center>
 <div id="PopUp_Wait_sign" style="vertical-align:middle;width:30%; background-color:Orange; border:solid 1px #000000; text-align:center; font-size:12px; font-weight:bold;">
 <span id="ctl00_ContentPlaceHolder1_lblprogress">Please wait ...</span>    
</div> 
</center>

<script type="text/javascript">


//ProdQuestion is nmae of the popup div
//*********************************** for ESC Button
 function CheckGoBack(e) 
 {
       // alert("text");
        var evt = e || window.event; 
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null); 
       // alert("evt=" + node.type);
        var keyCode = evt.charCode || evt.keyCode; 
       //alert("keyCode=" + keyCode);
        // if ((keyCode==27) && (node.type!="text"))
             StrBlock=""
             //block ESC button
            if (keyCode==27)  
             {  
               //alert("keyCode=" + keyCode);
                StrBlock="Y"
               // if (node.type=="text")
                //{
              //      StrBlock=""
             //   }
             //   if (node.type=="textarea")
             //   {
              //      StrBlock=""
             //   }
               
             }
              
              //block backspace button
         if (keyCode==8)  
             {
            
                StrBlock="Y"
                 if (node.type=="text")
                    {
                        StrBlock=""
                    }
                if (node.type=="textarea")
                    {
                        StrBlock=""
                    }
             }
            // alert("StrBlock=" + StrBlock);
             if (StrBlock=="Y")
             {
               //alert("in");
                return false;
             }
          
 }

 document.onkeydown= CheckGoBack;
 
 //*****************Don't display menu on the mouse
 document.oncontextmenu=new Function("return false")
 
  function Load()
     {
          PageFinishingLoading() 
            //document.getElementById('test_id').style.visibility='hidden';
          FunLoadSaveList()
          // alert("FunLoadSaveList")
          FunSavedAnsBackList()
         //  alert("FunSavedAnsBackList")
		  DisplayAnswers()
		  CallFormEnded=document.aspnetForm.CallFormEnded.value;
		// alert("CallFormEnded=" + CallFormEnded)
	      if (CallFormEnded=='Y')
	      {
	             document.getElementById('Select_Product_name').value=document.aspnetForm.CFEnd_SelectedProduct.value
	             Disable_Question_End999('Y')
	      }
	 
     }
function PageFinishingLoading()
{
                var objMyCtrl = document.getElementById("ITS_MyControl_FullPageDiv");
                 
                  var popUp = document.getElementById("PopUp_Wait_sign");
                 
                 
                 popUp.style.visibility = "visible";
                 objMyCtrl.style.visibility = "visible";
                 
                 var  PageLoadCheck = document.getElementById("CallFormEnd");
                // alert("PageLoadCheck=" + PageLoadCheck);
               
               if (document.getElementById)
                {
                    //alert("PageLoadCheck1=" + PageLoadCheck);
                    objMyCtrl.style.visibility = "hidden";
                    popUp.style.visibility = "hidden";
                   
                }
                else
                {
                        if (document.layers)
                        { //NS4
                             // alert("PageLoadCheck2=" + PageLoadCheck);
                              objMyCtrl.style.visibility = "hidden";
                              popUp.style.visibility = "hidden";
                              
                        }
                        else 
                        { //IE4
                               //  alert("PageLoadCheck3=" + PageLoadCheck);
                               objMyCtrl.style.visibility = "hidden";
                               popUp.style.visibility = "hidden";
                              
                        }
                }
                
             
        
}

function FunLoadSaveList()
{
           // alert("test");
            DisplayAnswerForGridCF=document.aspnetForm.DisplayAnswerForGridCF.value
          // alert("DisplayAnswerForGridCF=" + DisplayAnswerForGridCF)
	
	      
            
	                if (DisplayAnswerForGridCF!="") 
		                {
		                                    CallFormEnded=document.aspnetForm.CallFormEnded.value;
	                                        if (CallFormEnded=='Y')
	                                        {
		                                        document.aspnetForm.AnyProduct_answered.value=''
		                                    }
		                                    else
		                                    {
		                                        document.aspnetForm.AnyProduct_answered.value='Y'
		                                    }
		                                        
		                                    
								                //alert("AnswerStr=" + AnswerStr)
								                AnswerArray = DisplayAnswerForGridCF.split("|");
								                arraylength = AnswerArray.length
								                // alert("arraylength=" + arraylength) 
								                arraylength=eval(arraylength)
                	
							                for ( i = 0 ; i < arraylength ; i++ )
								                {
									                    AnswerElement = AnswerArray[i].valueOf()
									                     // alert("AnswerElement=" + AnswerElement)
									                 
    									                
									                    Anstype = AnswerElement.substring(0,1)
									                   // alert("Anstype=" + Anstype)
                    									
									                    POS=AnswerElement.indexOf(",")
									                    //alert("POS=" + POS);
									                    POS2=POS-6
                    										
									                    ElementName=AnswerElement.substring(5,POS)
									                    // alert("ElementName=" + ElementName);
                    										
                    									
									                    NameOfSave="SavedList" + ElementName
									                  //  alert("NameOfSave=" + NameOfSave)
										                AnswerSaveForProd =eval("document.aspnetForm." + NameOfSave + ".value")
										              //  alert("AnswerSaveForProd=" + AnswerSaveForProd)
                                                         AnswerElement="Prod_" + AnswerElement
										                if (AnswerSaveForProd=="")
											                {
											                     
												                eval("document.aspnetForm." + NameOfSave + ".value='" + AnswerElement + "'")
												              // alert("in" + AnswerElement)
											                }
										                else	
											                {
												                //For Product 
                											             
														                ProdWithAnswerBack =eval("document.aspnetForm." + NameOfSave + ".value")
														                FinalProdWithAnswer="" + ProdWithAnswerBack + "|" + AnswerElement + ""
														                eval("document.aspnetForm." + NameOfSave + ".value='" + FinalProdWithAnswer + "'")
														                
														        //For Product with txt answer
                											            
														                
														                
											                }
                											
                										
									                  AnswerSaveForProd =eval("document.aspnetForm." + NameOfSave + ".value")
									                //  alert("AnswerSaveForProd=" + AnswerSaveForProd)
									                   
								                }
                			
		                }
		  
	 
 }
 function FunSavedAnsBackList()
 {
           // alert("test");
	        NewGridCF_SaveAnsBack=document.aspnetForm.NewGridCF_SaveAnsBack.value
          // alert("NewGridCF_SaveAnsBack=" + NewGridCF_SaveAnsBack)
            
	                if (NewGridCF_SaveAnsBack!="") 
		                {
		                                        
		                                    
								                //alert("AnswerStr=" + AnswerStr)
								                ArrayAnsBack = NewGridCF_SaveAnsBack.split("|");
								                arraylength = ArrayAnsBack.length
								               // alert("arraylength=" + arraylength) 
								                arraylength=eval(arraylength)
                	
							                for (R = 0 ; R < arraylength ; R++ )
								                {
									                    AnswerElement = ArrayAnsBack[R].valueOf()
									                  // alert("AnswerElement=" + AnswerElement)
									                    Anstype = AnswerElement.substring(0,1)
									                   // alert("Anstype=" + Anstype)
                    									
									                    POS=AnswerElement.indexOf(",")
									                  // alert("POS=" + POS);
									                    POS2=POS-6
                    										
									                    ElementName=AnswerElement.substring(10,POS)
									                   // alert("ElementName=" + ElementName);
										                
										                 NameOfSaveWithTxt="SavedAnsBackList" + ElementName
									                    // alert("NameOfSaveWithTxt=" + NameOfSaveWithTxt)
										                 AnswerSaveWithTxt=eval("document.aspnetForm." + NameOfSaveWithTxt + ".value")
										             // alert("AnswerSaveWithTxt=" + AnswerSaveWithTxt)
										                 
										                
										                if (AnswerSaveWithTxt=="")
											                {
											                    
												                eval("document.aspnetForm." + NameOfSaveWithTxt + ".value='" + AnswerElement + "'")
											                }
										                else	
											                {
												                 
														        //For Product with txt answer
                											            
														                TxtWithAnswerBack =eval("document.aspnetForm." + NameOfSaveWithTxt + ".value")
														                FinalTxtWithAnswer="" + TxtWithAnswerBack + "|" + AnswerElement + ""
														               // alert("FinalTxtWithAnswer=" + FinalTxtWithAnswer)
														                eval("document.aspnetForm." + NameOfSaveWithTxt + ".value='" + FinalTxtWithAnswer + "'")
														                
											                }
                											
                									 
									                   AnswerSavewithTxt =eval("document.aspnetForm." + NameOfSaveWithTxt + ".value")
									                 // alert("AnswerSavewithTxt=" + AnswerSavewithTxt)
								                }
                			
		                }
		 
	 
 }
 // ************************************* Display the answers back if it's been answered
function DisplayAnswers()
{		
         AnsBack_prod_id=""
         ProdAnsForNextPage=eval("document.aspnetForm.ProdAnsForNextPage.value")
          //alert("ProdAnsForNextPage=" + ProdAnsForNextPage)
          CallFormEnded=document.aspnetForm.CallFormEnded.value;
         // alert("CallFormEnded=" + CallFormEnded)
         if (CallFormEnded=="Y")
         {
            AnsBack_prod_id=document.aspnetForm.CFEnd_SelectedProduct.value + "|";
           
            
         }
         else
         {
            AnsBack_prod_id=ProdAnsForNextPage
         }
        // alert("AnsBack_prod_id=" + AnsBack_prod_id)
         
         EleArray = AnsBack_prod_id.split("|");
         arraylen= EleArray.length
       //  alert("arraylen=" + arraylen) 
         arraylen=eval(arraylen-1)

            for ( V = 0 ; V < arraylen ; V++ )
                {
                    Prod_id_Element = EleArray[V].valueOf()
                   // alert("Prod_id_Element=" + Prod_id_Element)
                    
                      NameOfSaveTxt="SavedAnsBackList" + Prod_id_Element
                    //  alert("NameOfSaveTxt=" + NameOfSaveTxt)

                     AnswerSaveForProd =eval("document.aspnetForm." + NameOfSaveTxt + ".value")
                     //alert("AnswerSaveForProd=" + AnswerSaveForProd)
                     if (AnswerSaveForProd!="")
                     {
                                    SaveArray = AnswerSaveForProd.split("|");
                                    arraylen2= SaveArray.length
                                   // alert("arraylen2=" + arraylen2) 
                                    arraylen2=eval(arraylen2)

                            for ( X = 0 ; X < arraylen2 ; X++ )
                                {
                                         AnsEach_Element = SaveArray[X].valueOf()
                                       //  alert("AnsEach_Element=" + AnsEach_Element) 
                                         Arrayid_Ans=AnsEach_Element.split(","); 
                                          Ele_Id=Arrayid_Ans[0].valueOf() 
                                          Ele_Ans=Arrayid_Ans[1].valueOf() 
                                         // alert("Ele_Id=" + Ele_Id)
                                       //  alert("Ele_Ans=" + Ele_Ans)
                                           Anstype = Ele_Id.substring(5,6)
									     //  alert("Anstype=" + Anstype)
									     
									       
                                          if (Ele_Ans=="Disabled")
		                                 	{
		                                 		     eval("document.getElementById('" + Ele_Id + "').value=''")
                                                     eval("document.getElementById('" + Ele_Id + "').disabled=true")
                                                     eval("document.getElementById('" + Ele_Id + "').style.backgroundColor = 'red'")
		                                	}
		                                else
		                                	{
		                                	
		                                	         if (Anstype=="M")
									                  {
									                     Ele_Ans2=Arrayid_Ans[2].valueOf() 
									                    // alert("Ele_Ans2=" + Ele_Ans2)
									                     Ele_Ans=Ele_Ans + "," + Ele_Ans2
									                  }                  
                                                      if (Anstype=="H")
									                  {
									                     ArrH_Ele_Ans = Ele_Ans.split(":") 
									                     TimeH=ArrH_Ele_Ans[0].valueOf() 
									                     TimeM=ArrH_Ele_Ans[1].valueOf()
									                     Ele_Ans=TimeH + ":" + TimeM
									                  } 
		                                	
		                                	
		                                	        if (Anstype=="C")
		                                	        {
		                                	              CB_Ans=eval("document.getElementById('" + Ele_Id + "').value")
		                                	             // alert("CB_Ans=" + CB_Ans)
		                                	              if (CB_Ans!="")
		                                	              {
		                                	                CB_Ans  = CB_Ans.replace(/(\r\n|\n|\r)/gm, "|");
		                                	               //  alert("CB_Ans1=" + CB_Ans)	
		                                	                CB_Ans  = CB_Ans.replace(/\|/g, "\\n");	
		                                	               // alert("CB_Ans2=" + CB_Ans)
		                                	                Ans_val=CB_Ans + "\\n" + Ele_Ans
		                                	              }
		                                	              else
		                                	              {
		                                	                Ans_val=Ele_Ans
		                                	              }  
		                                	        }
		                                	        else
		                                	        {
		                                		           Ans_val=Ele_Ans
		                                		    }
		                                		     // alert("Ans_val=" + Ans_val)
		                                		    //  alert("Ele_Id=" + Ele_Id)
		                                		      eval("document.getElementById('" + Ele_Id + "').value='" + Ans_val + "'")
		                                	}
					
                                }//end of for loop X
                        GetColor(Prod_id_Element)
                       }//if (AnswerSaveForProd!="")
                }//end of for loop V
            	    		 
}

     //*********************************  Main function 
     function DisplayCallForm(Ele_name, Product_name, Question_name, NextQuestion, PopUpType, Ans_Val_High, Ans_Val_Low) {

         //alert("DisplayCallForm");
         //Ele_name is text box of the row that you clicked,Product_name is prod_id,Question_name is q_no,
         //The validate function set the flag if error happens
          
        
         var el, x, y;
         //In chrome compare display twice so this stop it
          SEM=eval(document.aspnetForm.ShowErrorMessageCnt.value)
         //alert("SEMout=" + SEM);
         SEM=Number(SEM)
         if (SEM>0)
         {            
            SEM=SEM+1
            document.aspnetForm.ShowErrorMessageCnt.value=SEM 
            
         }
         if (SEM==3)
         {
            //alert("SEM in 3=" + SEM);
            document.aspnetForm.ShowErrorMessageFlg.value='N'
            document.aspnetForm.ShowErrorMessageCnt.value=0
         }
         else
         {
           // alert("SEM Y=" + SEM);
            document.aspnetForm.ShowErrorMessageFlg.value='Y'
         }
         //alert("SEMAfter=" + SEM);
       //  alert("NextQuestion=" + NextQuestion);
       //  alert("Product_name=" + Product_name);
        // alert("Ans_Val_High=" + Ans_Val_High);
       //  alert("Ans_Val_Low=" + Ans_Val_Low);
       
       //******************M type Question cause we are doing a popup 
        MH_Unit_Error_Flag=document.aspnetForm.MH_Unit_Error_Flag.value 
       // alert("MH_Unit_Error_Flag=" + MH_Unit_Error_Flag); 
        //*****************name of the second text
         document.aspnetForm.MH_Type_q_Tab_Val.value='' 
        //*****************set a flag to tab to second textbox of Measurement or hours
         document.aspnetForm.MH_Type_q_Tab_Status.value='' 
         
         //name of the element that was clicked on
         lastEleVal = document.getElementById('FocusEle_name').value;
        // alert("lastEleVal=" + lastEleVal);
        
        StrNextFocusEle = document.getElementById('Skipattern_NextFocusEle').value
       // alert("StrNextFocusEle1=" + StrNextFocusEle);
       
         if (StrNextFocusEle == "Done") 
         {
            // document.aspnetForm.Prod_N0070237.select() 
              document.aspnetForm.ctl00$ContentPlaceHolder1$CallFormDone.focus() 
              
             //alert("wswwwdwdwdw");
            document.getElementById('Skipattern_NextFocusEle').value='';
             
            return false; 
          }
          
         //*************************************Checking for error in the question type N D P H M
         QV_Error_status=document.getElementById('Question_Validation_NDPHM_Error_status').value
        // alert("QV_Error_status=" + QV_Error_status);
         if (QV_Error_status == "Y") 
         {
             ElementOnFocus(lastEleVal)
            
             document.getElementById('Question_Validation_NDPHM_Error_status').value = "";
              if (MH_Unit_Error_Flag=="")
                {
                    return false;   
                }
                else
                {
                   document.aspnetForm.MH_Unit_Error_Flag.value=''  
                }  
          }

         //************************************* Validation
            
         if (AnyQuestionAnswered(Product_name) == false) {
             if (Validation(Ele_name,Product_name, Question_name, Ans_Val_High, Ans_Val_Low) == false) {
                 return false;
             }
         }
 
          //alert("test1");
         //************** select a first Row color 
         // SelectedRowColor(Product_name)
          SelectedFirstCellRowColor(Product_name)
          // alert("test2");
         //************* Cell color
          SelectedCellColor(Ele_name, Product_name, Question_name)
          
         Validat_Prod_id_Old =document.getElementById('Validation_Select_Prod_id').value 
         if (Validat_Prod_id_Old!="")
         {
            GetColor(Validat_Prod_id_Old)
         }
         
          //alert("Validation done");
         //************************************** Move to selected row
         document.getElementById('Validation_Select_Prod_id').value = Product_name

         //Saving to hidden variable for popup div to display the answer from popup div to textbox
         document.getElementById('SelProd_txt_Ele').value = Ele_name  
         

         //save the select product row name to find the next product to focus
         document.getElementById('Select_Product_name').value = Product_name

       
            
          document.getElementById('FocusEle_name').value = Ele_name
          //  alert("Ele_name=" + Ele_name);
        //  alert("test3");
          
         //*******************Type N,P,D has no popup
         if (PopUpType == 1) 
         {
            QuestionWithNoDivPopUp(Ele_name, Product_name, Question_name, NextQuestion)
         }
         if (PopUpType == 0) 
         {
             //create a div with questions
             CreateQuestion(Product_name, Question_name,Ans_Val_High, Ans_Val_Low)

             el = document.getElementById('ProdQuestion');

             // var txt = document.getElementById("N00401");
             var txt = eval("document.getElementById('" + Ele_name + "')")
             var p = GetScreenCordinates(txt);
             // alert("X:" + p.x + " Y:" + p.y);

             x = p.x;
             y = p.y - 15;
             y = y + 50
             el.style.left = x + "px";
             el.style.top = y + "px";
             el.style.display = "block";
             
             document.getElementById('ProdQuestion').focus();
            // alert("focus1");
             //*********** Set the focus on the first element of the popupdiv
             StrDivPopUP_Ele_id = document.getElementById('DivPopUP_Ele_id').value;
            // alert("StrDivPopUP_Ele_id=" + StrDivPopUP_Ele_id);
              DAns_Type = StrDivPopUP_Ele_id.substring(0, 1)
            //  alert("StrDivPopUP_Ele_id=" + StrDivPopUP_Ele_id);
              eval("document.getElementById('" + StrDivPopUP_Ele_id + "').focus()")
              // alert("focus2");
             // alert("DAns_Type=" + DAns_Type);
              if ((DAns_Type=="T")||(DAns_Type=="M")||(DAns_Type=="H"))
              {
                    setTimeout(function() { eval("document.getElementById('" + StrDivPopUP_Ele_id + "').select()"); }, 100);
              }
               //alert("DisplayCallForm");
            if ((DAns_Type=="R")||(DAns_Type=="L")||(DAns_Type=="C")||(DAns_Type=="T")||(DAns_Type=="M")||(DAns_Type=="H"))
              {
                //eval("document.getElementById('" + StrDivPopUP_Ele_id + "').checked = true")
                 PPD_Ele_Name=document.getElementById('DivPopUP_Ele_Name').value;
                 FocusEle_name = document.getElementById('FocusEle_name').value;
                
                   //  ProdQList = "PQList" + Product_name
                   //  PopUpType =0;
                    // SkipPattern(NextQuestion, Question_name, ProdQList, PopUpType)
                    GetAnswersBackToPOP(PPD_Ele_Name, FocusEle_name,NextQuestion, Question_name,Product_name) 
              }
              //do a skip pattern for t type questions
            //  alert("DAns_Type=" + DAns_Type);
              if ((DAns_Type=="T")||(DAns_Type=="M")||(DAns_Type=="H"))
              {
                            //alert("do skip pattern T type");    
                            ProdQList = "PQList" + Product_name
                            PopUpType =1;
                            SkipPattern(NextQuestion, Question_name, ProdQList, PopUpType)
                    
              }
              // GetAnswersBackToPOP(PPD_Ele_Name, FocusEle_name,NextQuestion, Question_name,Product_name) 
             
             
             // alert("DisplayCallForm");

         } //if (PopUpType == 0) 
     }
     
//********************************** Get answers from textbox to the popup div
     function GetAnswersBackToPOP(PPD_Ele_Name, FocusEle_name,NextQuestion, Question_name,Product_name) 
     {
           // alert("GetPopUpAnswers");
         //  alert("PPD_Ele_Nameinside=" + PPD_Ele_Name);
          // alert("FocusEle_nameinside=" + FocusEle_name);
           loop_value = "";
           Selected_Answer = "";
           Selected_Text = "";
           Select_Product_txtBox = document.getElementById('SelProd_txt_Ele').value
          // alert("Select_Product_txtBox=" + Select_Product_txtBox);
           Select_Product_txtBox_val=eval("document.getElementById('" + Select_Product_txtBox + "').value")
         //  alert("Select_Product_txtBox_val=" + Select_Product_txtBox_val);
           StrDivPopUP_Ele_id = document.getElementById('DivPopUP_Ele_id').value;
             
             PAns_Type = PPD_Ele_Name.substring(0, 1)
           //  alert("PAns_Type=" + PAns_Type)

             Q_no = PPD_Ele_Name.substring(1, 4)
            // alert("Q_no=" + Q_no)
             
            EleObject=eval("document.getElementsByName('" + PPD_Ele_Name + "')")
           
           if (PAns_Type == "R" || PAns_Type == "L" || PAns_Type == "C") 
            {
                       var selected_value;
                       Elelen=eval("document.getElementsByName('" + PPD_Ele_Name + "').length")
                      // alert("Elelen=" + EleObject.length)
                    if (Select_Product_txtBox_val!="")
                        {
                        
                                if (PAns_Type == "R" || PAns_Type == "L" || PAns_Type == "C") 
                                    {
                                                 Str_Ans_Val = Select_Product_txtBox_val.substring(0, 1)
                                                // alert("Str_Ans_Val=" + Str_Ans_Val)
                                                  for (var m = 0; m < EleObject.length; m++) 
                                                  { 
                                                             loop_value = EleObject[m].value;
                                                         //  alert("loop_value=" + loop_value);
                                                           //  alert("Str_Ans_Val=" + Str_Ans_Val);
                                                           if (PAns_Type == "R" || PAns_Type == "L")
                                                               {
                                                                        if (Str_Ans_Val==loop_value) 
                                                                        {
                                                                             EleObject[m].checked = true;
                                                                             // alert("innnnnnnn")
                                                                        }
                                                                }
                                                           if( PAns_Type == "C")
                                                                {
                                                                           
                                                                         CheckBoxArray  = Select_Product_txtBox_val.replace(/\r\n/g, "\n").split("\n");
                                                                         CheckBoxlength = CheckBoxArray.length
                                                                        //alert("CheckBoxlength=" + CheckBoxlength) 
                                                                         for (n = 0; n < CheckBoxlength; n++) 
                                                                           {
                                                                             CheckBoxArraytext = CheckBoxArray[n].valueOf()
                                                                              // alert("CheckBoxArraytext=" + CheckBoxArraytext)
                                                                               Str_Ans_ValCB = CheckBoxArraytext.substring(0, 1)
                                                                               
                                                                                if (Str_Ans_ValCB==loop_value) 
                                                                                        {
                                                                                             EleObject[m].checked = true;
                                                                                              //alert("CB")
                                                                                        }
                                                                                                                              
                                                                           }//For loop
                                                                            
                                                                }
                                    
                                                  }
                                      }
                                 
                         }
                        else
                        {
                           // alert("SkipPattern 2");
                            eval("document.getElementById('" + StrDivPopUP_Ele_id + "').checked = true")
                            ProdQList = "PQList" + Product_name
                            PopUpType =0;
                            SkipPattern(NextQuestion, Question_name, ProdQList, PopUpType)
                        }
            }
        if (PAns_Type == "T")
          {
       // alert("PAns_Type=" + PAns_Type);
      // alert("PPD_Ele_Name=" + PPD_Ele_Name);
        
             eval("document.getElementById('" + PPD_Ele_Name + "').value='" + Select_Product_txtBox_val + "'")
              
         }
         if (PAns_Type == "M")
          {
          //  alert("inside Mtype"); 呎 feet 吋 inch china
                          //get the name of the popup boxes
                                   MBArray=PPD_Ele_Name.split(","); 
                                    Mtype_FBName=MBArray[0].valueOf() 
                                    Mtype_SBName=MBArray[1].valueOf() 
                                  // alert("Mtype_First=" + Mtype_FBName);
                                 //   alert("Mtype_Second=" + Mtype_SBName);
                                   MeasurementDesc=document.aspnetForm.MeasurementDesc.value 
                                  // alert("MeasurementDesc=" + MeasurementDesc);
                            //System rules
                                    MDescArray=MeasurementDesc.split(","); 
                                    Feet_DescB=MDescArray[0].valueOf() 
                                    Inc_DescB=MDescArray[1].valueOf() 
                            //get responses
                                     ResponseFeet="" 
                                     ResponseInc="" 
                                     if (Select_Product_txtBox_val!="")
                                     {
                                         if (Select_Product_txtBox_val.indexOf(',') > -1) 
                                            {
                                                     ResponseArray=Select_Product_txtBox_val.split(",");
                                                     ResponseFeet=ResponseArray[0].valueOf() 
                                                     ResponseInc=ResponseArray[1].valueOf()  
                                                     ResponseFeet=ResponseFeet.replace(Feet_DescB,"") 
                                                     ResponseInc=ResponseInc.replace(Inc_DescB,"")
                                                       
                                            }
                                          else
                                            {
                                                     if (Select_Product_txtBox_val.indexOf("" + Feet_DescB + "") > -1) 
                                                        {
                                                               ResponseFeet=Select_Product_txtBox_val 
                                                               ResponseFeet=ResponseFeet.replace(Feet_DescB,"") 
                                                        }
                                                    if (Select_Product_txtBox_val.indexOf("" + Inc_DescB + "") > -1) 
                                                        {
                                                               ResponseInc=Select_Product_txtBox_val 
                                                               ResponseInc=ResponseInc.replace(Inc_DescB,"") 
                                                        }
                                                       
                                            }
                                          	  //  alert("ResponseFeet=" + ResponseFeet);
                                     	      //  alert("ResponseInc=" + ResponseInc);
                                     	      ResponseFeet=Trim(ResponseFeet)
                                     	      ResponseInc=Trim(ResponseInc)
                                                eval("document.getElementById('" + Mtype_FBName + "').value='" + ResponseFeet + "'")
                                                eval("document.getElementById('" + Mtype_SBName + "').value='" + ResponseInc + "'")
                                       
                                            
                                     }
                                    
                                     
                                  
          }//Mtype
          if (PAns_Type == "H")
          {
          //  alert("inside Mtype"); 呎 feet 吋 inch china
                         //get the name of the popup boxes
                                    HBArray=PPD_Ele_Name.split(","); 
                                    Htype_FBName=HBArray[0].valueOf() 
                                    Htype_SBName=HBArray[1].valueOf() 
                                  // alert("Mtype_First=" + Mtype_FBName);
                                 //   alert("Mtype_Second=" + Mtype_SBName);
                                   Timeq_desc=document.aspnetForm.Timeq_desc.value 
                                  // alert("MeasurementDesc=" + MeasurementDesc);
                            //System rules
                                    HDescArray=Timeq_desc.split(","); 
                                    Hrs_DescB=HDescArray[0].valueOf() 
                                    Min_DescB=HDescArray[1].valueOf() 
                            //get responses
                                     ResponseHrs="" 
                                     ResponseMin="" 
                                    // alert("Select_Product_txtBox_val=" + Select_Product_txtBox_val);
                                     if (Select_Product_txtBox_val!="")
                                     {
                                         if (Select_Product_txtBox_val.indexOf(':') > -1) 
                                            {
                                                     ResponseArray=Select_Product_txtBox_val.split(":");
                                                     ResponseHrs=ResponseArray[0].valueOf() 
                                                     ResponseMin=ResponseArray[1].valueOf() 
                                                      
                                                     ResponseHrs=ResponseHrs.replace(Hrs_DescB,"") 
                                                     ResponseMin=ResponseMin.replace(Min_DescB,"")
                                                       
                                            }
                                          else
                                            {
                                                     if (Select_Product_txtBox_val.indexOf("" + Hrs_DescB + "") > -1) 
                                                        {
                                                               ResponseHrs=Select_Product_txtBox_val 
                                                               ResponseHrs=ResponseHrs.replace(Hrs_DescB,"") 
                                                        }
                                                    if (Select_Product_txtBox_val.indexOf("" + Min_DescB + "") > -1) 
                                                        {
                                                               ResponseMin=Select_Product_txtBox_val 
                                                               ResponseMin=ResponseMin.replace(Min_DescB,"") 
                                                        }
                                                       
                                            }
                                          	  //  alert("ResponseFeet=" + ResponseFeet);
                                     	      //  alert("ResponseInc=" + ResponseInc);
                                     	      ResponseHrs=Trim(ResponseHrs)
                                     	      ResponseMin=Trim(ResponseMin)
                                                eval("document.getElementById('" + Htype_FBName + "').value='" + ResponseHrs + "'")
                                                eval("document.getElementById('" + Htype_SBName + "').value='" + ResponseMin + "'")
                                       
                                            
                                     }
                   }   
    }
     
     //*******************************************gets postion of the element
     function GetScreenCordinates(obj) {
         var p = {};
         p.x = obj.offsetLeft;
         p.y = obj.offsetTop;
         while (obj.offsetParent) {
             p.x = p.x + obj.offsetParent.offsetLeft;
             p.y = p.y + obj.offsetParent.offsetTop;
             if (obj == document.getElementsByTagName("body")[0]) {
                 break;
             }
             else {
                 obj = obj.offsetParent;
             }
         }
         return p;
     }
     //*******************questions have no DIV PopUp ........ Type N,P,M,H,D  PQList
     function QuestionWithNoDivPopUp(Ele_name, Product_name, Question_name, NextQuestion) {
       // alert("QuestionWithNoDivPopUp");
         el = document.getElementById('ProdQuestion');
         el.style.display = "none";
         ShowQuestionTextonly(Ele_name,Question_name)
          
        //alert("Ele_name=" + Ele_name);
         //alert("Product_name=" + Product_name);
         //alert("Question_name=" + Question_name);
         //alert("NextQuestion=" + NextQuestion);

         //Select_Product_name = document.getElementById('Select_Product_name').value;
         // alert("Select_Product_name=" + Select_Product_name);
        // alert("SkipPattern 3");
         ProdQList = "PQList" + Product_name
         PopUpType =1;
         SkipPattern(NextQuestion, Question_name, ProdQList, PopUpType)
     }
//**************************************************question with only text
function ShowQuestionTextonly(Ele_name,Question_name)
{
   // alert("Question_name=" + Question_name);
  HTMLText1 = "";
    Answer_Type = "";
    ControlName = "";
    HTMLText1 = HTMLText1 + "<table bgcolor='#f5fffa' cellpadding='0' cellspacing='0'>";
    HTMLText1 = HTMLText1 + "<tr >";
    HTMLText1 = HTMLText1 + "<td width='96%' height='10%'> &nbsp; </td>";
    HTMLText1 = HTMLText1 + "<td align='right'  width='4%' height='10%'><img src='Images/x.jpg' onclick='return ClosePopup();'></td>";
    HTMLText1 = HTMLText1 + "</tr>";
    HTMLText1 = HTMLText1 + "</table>";   
    HTMLText1 = HTMLText1 + "<table border='1' width='100%'  bordercolor='dodgerblue'>";
     
 

        StrQ_no = Question_name
        QHName = "Q" + StrQ_no
        QuestionText = eval("document.getElementById('" + QHName + "').value")
        //alert("QuestionText=" + QuestionText)
        //return false;
        POS = QuestionText.indexOf("_")
        Ans_Type = QuestionText.substring(0, POS)
        //alert("Ans_Type=" + Ans_Type) 
        poslen = QuestionText.length;
        // alert("poslen=" + poslen);
        Q_Text = QuestionText.substring(POS + 1, poslen)
       // alert("Q_Text=" + Q_Text);

        DisplayQ_text = Question_name + " - " + Q_Text
       
            //alert("DisplayQ_text=" + DisplayQ_text);
        HTMLText1 = HTMLText1 + "<tr  style='background-color:LightYellow;'>";
        HTMLText1 = HTMLText1 + "<td class='selectionCriteriaItem'>QNo.<B>" + DisplayQ_text + "<span style='color:red;'> " + Answer_Type + " </span></B></td>";
        HTMLText1 = HTMLText1 + "</tr>";

      //  HTMLResponseText = GetQuestionResponse(Ans_Type, StrQ_no, Prod_id, Ans_Val_High, Ans_Val_Low)
      //  HTMLText = HTMLText + "" + HTMLResponseText
    //}
    HTMLText1 = HTMLText1 + "</Table>";
    //Controls names save for current call form for a product 
   // document.aspnetForm.ControlList.value = ControlName
    //document.aspnetForm.Menu_id.value = SelectedProduct
    //document.aspnetForm.Prod_id.value = Prod_id
    //Display the call form    
   //alert("HTMLText1=" + HTMLText1);   
        ProdQuestion.innerHTML = HTMLText1;
    
       el = document.getElementById('ProdQuestion');

             // var txt = document.getElementById("N00401");
             var txt = eval("document.getElementById('" + Ele_name + "')")
             var p = GetScreenCordinates(txt);
             // alert("X:" + p.x + " Y:" + p.y);

             x = p.x;
             y = p.y - 15;
             y = y + 50
             el.style.left = x + "px";
             el.style.top = y + "px";
             el.style.display = "block";
     
}


     //*******************************************SkipPattern
     function SkipPattern(NextQuestion, Question, ProdQList, PopUpType) 
     {

        // alert("SkipPattern");
        // alert("NextQuestion=" + NextQuestion);
        // alert("Question=" + Question);
         // alert("ProdQList=" + ProdQList);
        //    alert("PopUpType=" + PopUpType);
          StopLoop="";
          Diff_q="";
          document.getElementById('PopQTabkey').value = 1
          FocusEle_name = document.getElementById('FocusEle_name').value;
          //eval("document.getElementById('" + FocusEle_name + "').value=111")
           PPD_Ele_Name=document.getElementById('DivPopUP_Ele_Name').value;
          //alert("PPD_Ele_Name=" + PPD_Ele_Name);
            Q_no=Number(Question)
			Nxt_Q_no=Number(NextQuestion)
			if (Nxt_Q_no!="0")
				{
					StopLoop=Nxt_Q_no + 1 
					Diff_q=Nxt_Q_no-Q_no
				}
			// alert("Diff_q=" + Diff_q);
				Disable_questions="";
			if (Diff_q==1)
			{
			    Disable_questions="Y";
			}
			
            Saved_Q_no=0
			ExitLoop=""

           //********* Get the pop up div answers and displays them to focus or selected textbox
           if (PopUpType == 0)
            {
               GetPopUpAnswers(PPD_Ele_Name, FocusEle_name)
            }
                 QuestionList = eval("document.getElementById('" + ProdQList + "').value")
              //   alert("QuestionList=" + QuestionList);

                 NextQuestion = Number(NextQuestion)
                 Question = Number(Question)
                 
                 // return false;

                 if (QuestionList != "") {
                     QuestionListArray = QuestionList.split("|");
                     arraylength = QuestionListArray.length
                     //alert("arraylength=" + arraylength) 
                     arraylength = eval(arraylength - 1)
                     for (z = 0; z < arraylength; z++) {
                         ArrayElement = QuestionListArray[z].valueOf()
                        // alert("ArrayElement=" + ArrayElement)
                        // EleColor = ArrayElement.substring(1, ArrayElement.length)
                         //alert("EleColor=" + EleColor)

                         LoopQuestion = ArrayElement.substring(6, 9)
                         Ans_Type = ArrayElement.substring(5, 6)
                          //alert("Ans_Type=" + Ans_Type)
                         Q_no_Counter = LoopQuestion
                         // alert("Question=" + Question)
                         LoopQuestion = Number(LoopQuestion)
                         //break;
                        // alert("NextQuestionout=" + NextQuestion)
                        // alert("LoopQuestion=" + LoopQuestion)
                       
						    
                         if (Question < LoopQuestion) 
                         {
                             // alert("NextQuestionout=" + NextQuestion)
                            //   alert("LoopQuestion=" + LoopQuestion)
                            //  alert("Question=" + Question)
                             if (NextQuestion == "0") 
                             {
                                 //alert("NextQuestionin=" + NextQuestion)
                              //    alert("equal to zero")	
                                 if (Ans_Type == "R" || Ans_Type == "L" || Ans_Type == "C") 
                                 {
                                     eval("document.getElementById('" + ArrayElement + "').value=''")
                                     eval("document.getElementById('" + ArrayElement + "').disabled=true")
                                     eval("document.getElementById('" + ArrayElement + "').style.backgroundColor = 'red'")
                                 }

                                 if (Ans_Type == "N" || Ans_Type == "T" || Ans_Type == "P" || Ans_Type == "M" || Ans_Type == "H" || Ans_Type == "D") 
                                 {


                                     eval("document.getElementById('" + ArrayElement + "').value=''")
                                     eval("document.getElementById('" + ArrayElement + "').disabled=true")
                                     eval("document.getElementById('" + ArrayElement + "').style.backgroundColor = 'red'")

                                 }
                             }
                             else
                             {
                                // alert("not zero")
                                 if (LoopQuestion < NextQuestion) {
                                   //  alert("LoopQuestion < NextQuestion")
                                     if (Ans_Type == "R" || Ans_Type == "L" || Ans_Type == "C") 
                                     {
                                         eval("document.getElementById('" + ArrayElement + "').value=''")
                                         eval("document.getElementById('" + ArrayElement + "').disabled=true")
                                         eval("document.getElementById('" + ArrayElement + "').style.backgroundColor = 'red'")
                                     }
                                     if (Ans_Type == "N" || Ans_Type == "T" || Ans_Type == "P" || Ans_Type == "M" || Ans_Type == "H" || Ans_Type == "D") {


                                         eval("document.getElementById('" + ArrayElement + "').value=''")
                                         eval("document.getElementById('" + ArrayElement + "').disabled=true")
                                         eval("document.getElementById('" + ArrayElement + "').style.backgroundColor = 'red'")

                                     }


                                 }
                                 if (LoopQuestion >= NextQuestion) 
                                 {
                                   // alert("LoopQuestion >= NextQuestion")
                                     //alert("ArrayElement=" + ArrayElement)	
                                     //alert("Ans_Type=" + Ans_Type)
                                     Q_status=eval("document.aspnetForm." + ArrayElement + ".disabled")
				                   //  alert("Q_status=" + Q_status)
			                         if (Q_status==true)
			                          {
			                                Disable_questions="" 
			                          }
			                       //   alert("Disable_questionsInside=" + Disable_questions);
							          if (Disable_questions=="")
                                       {                  
                                                 if (Ans_Type == "R" || Ans_Type == "L" || Ans_Type == "C") 
                                                 {
                                                    // eval("document.getElementById('" + ArrayElement + "').value=''")
                                                     eval("document.getElementById('" + ArrayElement + "').disabled=false")
                                                     eval("document.getElementById('" + ArrayElement + "').style.backgroundColor = 'mintcream'")
                                                 }

                                                 if (Ans_Type == "N" || Ans_Type == "T" || Ans_Type == "P" || Ans_Type == "M" || Ans_Type == "H" || Ans_Type == "D")
                                                  {

                                                     // eval("document.getElementById('" + ArrayElement + "').value=''")
                                                      eval("document.getElementById('" + ArrayElement + "').disabled=false")
                                                      eval("document.getElementById('" + ArrayElement + "').style.backgroundColor = 'mintcream'")

                                                 }
                                         }
                                 }//if (LoopQuestion >= NextQuestion) 
                             } //End of next question is zero
                             
									 
					              if ((LoopQuestion>=NextQuestion)&&(NextQuestion!=0))
					 	             {	 
						               //  alert("Ele_Q_no>=Nxt_Q_no")  
							            //GoToRTS()
					 		            //return false;	
					 	  	            break;
					                 }	
        								 
									
                         } //ending of Question < LoopQuestion
                          //alert("ArrayElementout=" + ArrayElement)
                         // alert("NextQuestionout=" + NextQuestion)

                           
                          if (LoopQuestion == NextQuestion) 
                          {
                           // alert("NextElement==q=" + ArrayElement)
                              document.getElementById('Skipattern_NextFocusEle').value = ArrayElement
                          }

                          if ((NextQuestion == "999")||(NextQuestion == "0")) 
                          {
                               //alert("NextElement999_0=" + ArrayElement)
                              document.getElementById('FocusEle_name').value = ArrayElement
                          }

                          if ((NextQuestion > LoopQuestion)) {
                              //alert("NextElement999_0=" + ArrayElement)
                              document.getElementById('FocusEle_name').value = ArrayElement
                          }
                     } //ending of For loop
                 } //Ending of question list is nothing
                  // EndCallForm(NextQuestion, Question) 	
                  //document.getElementById('Prod_N00401').focus();
                  EndCallForm(NextQuestion,Question)
     }
//********************************* End the call form for next question 999

function EndCallForm(NextQuestion,Question)
{
     //  alert("EndCallForm")
        Sel_Row_Name=document.getElementById('Select_Product_name').value
        if (NextQuestion=="999")
        {
                  //close the pop
                  //  ClosePopup() 
                  
                 CFEnd_Q_no=document.aspnetForm.CFEnd_Q_no.value;
                  AnyProduct_answered=document.aspnetForm.AnyProduct_answered.value;
                   // alert("CFEnd_Q_no=" + CFEnd_Q_no)
                   // alert("AnyProduct_answered=" + AnyProduct_answered)
                 if (CFEnd_Q_no!=Question)
                    {
                        if (AnyProduct_answered=='Y')                                                       
                            {
                                alert('<%=vPrompts[108]%>')
                            }
                            else
                            {
                                alert('<%=vPrompts[107]%>')
                            }
                            
                    }
                   
			    Disable_Question_End999('Y')
			    
			   document.aspnetForm.CallFormEnded.value='Y';
			   document.aspnetForm.CFEnd_Q_no.value= Question;
			   document.aspnetForm.CFEnd_SelectedProduct.value=Sel_Row_Name;
	    }
	    else
	    {
	            Disable_Question_End999('N')
			    document.aspnetForm.CFEnd_SelectedProduct.value="";
			    document.aspnetForm.CallFormEnded.value="";	
			    document.aspnetForm.CFEnd_Q_no.value="";
	    }
       
}
//**********************************
function Disable_Question_End999(Status_flag)
{
 
       ArraySavedEachQProd="";
	 //  alert("Disable_Question_End999=" + Status_flag) 
			//*********************collect data for all the products 
		 Sel_Row_Name=document.getElementById('Select_Product_name').value
      //  alert("Sel_Row_Name=" + Sel_Row_Name)
          StrCallFormEnded= document.aspnetForm.CallFormEnded.value;
             
            AllProdNames=document.getElementById('AllProdNames').value;	
		   // alert("AllProdNames=" + AllProdNames) 
		    if (Status_flag=='Y')
		    {
			                        ArrayAList = AllProdNames.split("|");      
			                        arraylength = ArrayAList.length
			                        // alert("arraylength=" + arraylength) 
			                        arraylength=eval(arraylength-1)
                        			 
			                        for (l = 0 ;l < arraylength ; l++ )
				                        {
								                        ElementName = ArrayAList[l].valueOf()
							                            resetname="Resetbtn_id" + ElementName+ ""
						                        //For each product
						                            if (Sel_Row_Name!=ElementName)
						                            {
								                             ProdQList="PQList" + ElementName	
								                             ProdQAnswer=eval("document.aspnetForm." + ProdQList + ".value")
								                            // alert("ProdQAnswer=" + ProdQAnswer)
                        								 
								                             ArrayEachQProd = ProdQAnswer.split("|");      
			                                                 ArrayEachlength = ArrayEachQProd.length
			                                                // alert("arraylength=" + arraylength) 
			                                                 ArrayEachlength=eval(ArrayEachlength-1)
                                                			 
			                                                 for (e = 0 ;e < ArrayEachlength ; e++ )
				                                                {
								                                                ArrEachEleName = ArrayEachQProd[e].valueOf()
								                                                eval("document.getElementById('" + ArrEachEleName + "').disabled=true")
                                                                                eval("document.getElementById('" + ArrEachEleName + "').style.backgroundColor = 'gray'")
                                                                              
                        								                        
								                                 }
								                                  // Resetbtn_id
                        								          
                                                        //document.aspnetForm.ctl00$ContentPlaceHolder1$Resetbtn.disabled=true;
                                                        eval("document.getElementById('" + resetname + "').disabled=true")
                        								
						                            }
                        								 
				                        }//for loop l
				      }
				      else
				      {
				            if (StrCallFormEnded=='Y')
				            {
				                            ArrayAList = AllProdNames.split("|");      
			                                arraylength = ArrayAList.length
			                                // alert("arraylength=" + arraylength) 
			                                arraylength=eval(arraylength-1)
                                			 
			                                for (l = 0 ;l < arraylength ; l++ )
				                                {
								                                ElementName = ArrayAList[l].valueOf()
							                                    resetname="Resetbtn_id" + ElementName+ ""
						                                //For each product
						                                    if (Sel_Row_Name!=ElementName)
						                                    {
								                                     ProdQList="PQList" + ElementName	
								                                     ProdQAnswer=eval("document.aspnetForm." + ProdQList + ".value")
								                                    //alert("ProdQAnswer=" + ProdQAnswer)
								                                     SavedQAnswer=""
								                                     
								                                     SavedQList="SavedList" + ElementName
								                                     SavedQAnswer=eval("document.aspnetForm." + SavedQList + ".value")
								                                   //  alert("SavedQAnswer=" + SavedQAnswer)	
								                                     if (SavedQAnswer!="")
								                                     {
								                                        ArraySavedEachQProd = SavedQAnswer.split("|"); 
								                                     }
                                								     
                                								 
								                                     ArrayEachQProd = ProdQAnswer.split("|");      
			                                                         ArrayEachlength = ArrayEachQProd.length
			                                                        // alert("arraylength=" + arraylength) 
			                                                         ArrayEachlength=eval(ArrayEachlength-1)
                                                        			 
			                                                         for (e = 0 ;e < ArrayEachlength ; e++ )
				                                                        {
				                                                                        StrSavedDisable=""
								                                                            ArrEachEleName = ArrayEachQProd[e].valueOf()
								                                                         if (SavedQAnswer!="")
								                                                             {
								                                                               // ArrEachSavedEleName = ArraySavedEachQProd[e].valueOf()
								                                                                //alert("ArrEachSavedEleName=" + ArrEachSavedEleName)
								                                                                
								                                                               //  ArraySavedSingleAns= ArrEachSavedEleName.split(","); 
								                                                               //  StrSavedDisable = ArraySavedSingleAns[1].valueOf()
								                                                              //   alert("StrSavedDisable=" + StrSavedDisable)
								                                                                StrSavedDisable=SavedAns_Disabled(ElementName,ArrEachEleName) 
								                                                             }
								                                                        //Q_CheckDisable = eval("document.getElementById('" + ArrayVal_Ele + "').disabled")
						                                                                 //alert("StrSavedDisable=" + StrSavedDisable)
								                                                        if (StrSavedDisable=="Disabled")
								                                                        {
								                                                                //alert("Is_Disable=" + ArrEachEleName)
								                                                                eval("document.getElementById('" + ArrEachEleName + "').style.backgroundColor = 'red'")
								                                                                eval("document.getElementById('" + ArrEachEleName + "').disabled=true")
								                                                        }
								                                                        else
								                                                        {
								                                                              // alert("not_Disable=" + ArrEachEleName)
								                                                                eval("document.getElementById('" + ArrEachEleName + "').style.backgroundColor = 'mintcream'")
								                                                                eval("document.getElementById('" + ArrEachEleName + "').disabled=false")
								                                                        }
								                                                      // eval("document.getElementById('" + ArrEachEleName + "').disabled=false")
                                                                                      //  alert("false1=" + ArrEachEleName)
                                                                                      
                                								                        
								                                         }
								                                          // Resetbtn_id
                                								          
                                                                //document.aspnetForm.ctl00$ContentPlaceHolder1$Resetbtn.disabled=true;
                                                                eval("document.getElementById('" + resetname + "').disabled=false")
                                								//alert("false2_resetname=" + resetname)
						                                    }
                                								 
				                                }//for loop l
				                                
				                   }//if (StrCallFormEnded=='Y')
				      } //if (Status_flag=='Y')                 
				                        
				                
			 
	 
}
function SavedAns_Disabled(ElementName,ArrEachEleName)
{
             StrDisabled=""
             SavedQList="SavedList" + ElementName
             SavedQAnswer=eval("document.aspnetForm." + SavedQList + ".value")
            //  alert("SavedQAnswer=" + SavedQAnswer)	
             if (SavedQAnswer!="")
             {
                 //ArraySavedEachQProd = SavedQAnswer.split("|"); 
                 // for (e = 0 ;e < ArrayEachlength ; e++ )
				  // {
				  
                  var SP = SavedQAnswer.indexOf("" + ArrEachEleName + ""); 
                 // alert("SP=" + SP)
                  
                  EP=SavedQAnswer.indexOf("|",SP); 
                 // alert("EP=" + EP)
                  
                  if (EP<0)
                  {
                    EP = SavedQAnswer.length
                   // alert("LP=" + EP)
                  }
                  StrEleName=SavedQAnswer.substring(SP,EP)
				 // alert("StrEleName=" + StrEleName);
					
				  Strcheck = StrEleName.indexOf("Disabled");	
				  if (Strcheck>0)
				  {	
				    StrDisabled="Disabled"
				  }
						
             }
          return StrDisabled   
}


//********************************** Get answers from popup
     function GetPopUpAnswers(PPD_Ele_Name, FocusEle_name) {
       // alert("GetPopUpAnswers");
        // alert("PPD_Ele_Nameinside=" + PPD_Ele_Name);
         // alert("FocusEle_nameinside=" + FocusEle_name);
          selected_value = "";
          Selected_Answer = "";
          Selected_Text = "";
         Select_Product_txtBox = document.getElementById('SelProd_txt_Ele').value
       //  alert("Select_Product_txtBox=" + Select_Product_txtBox);
          Ans_Type = PPD_Ele_Name.substring(0, 1)
        //  alert("Ans_Type=" + Ans_Type)

         Q_no = PPD_Ele_Name.substring(1, 4)
         // alert("Q_no=" + Q_no)

          if (Ans_Type == "R" || Ans_Type == "L" || Ans_Type == "C") 
           {

               var selected_value;
               Elelen=eval("document.getElementsByName('" + PPD_Ele_Name + "').length")
             //  alert("Elelen=" + Elelen)
                EleObject=eval("document.getElementsByName('" + PPD_Ele_Name + "')")
             
              for (var d = 0; d < EleObject.length; d++) {

                  //RadioValue = eval("document.getElementsByName('" + PPD_Ele_Name + "')[d].checked")
                  //alert("RadioValue=" + RadioValue)

                  //if (EleObject[d].checked)
                  //if (RadioValue == true)
                  if (EleObject[d].checked)
                   {
                       selected_value = EleObject[d].value;
                        //alert("selected_value=" + selected_value);
                       strAns_text = Q_response_text(Q_no, selected_value)
                       //alert("strAns_text=" + strAns_text);
                       //strAns_text = strAns_text + "\\n"
                       StrText = selected_value + "-" + strAns_text
                       if (Selected_Answer == "")
                        {
                           Selected_Answer = selected_value
                           Selected_Text = StrText

                       }
                       else 
                       {
                           Selected_Answer = Selected_Answer + "," + selected_value
                          Selected_Text = Selected_Text + "\\n" + StrText
                         // Selected_Text = Selected_Text + "," + StrText
                       }
                   }
              }
           }
           // R001

          // Q_response_text(Q_no, Selected_Answer)
         // alert("Selected_Text=" + Selected_Text);
          if (Ans_Type == "T") 
          {
             // alert("PPD_Ele_Name=" + PPD_Ele_Name);
             // alert("Select_Product_txtBox=" + Select_Product_txtBox);
              Selected_Answer = eval("document.getElementById('" + PPD_Ele_Name + "').value");
              Selected_Text = eval("document.getElementById('" + PPD_Ele_Name + "').value");
             // alert("selected_value=" + selected_value);
          }
          if (Ans_Type == "M") 
          {
            // alert("inside");
                MtypeArray=PPD_Ele_Name.split(","); 
                Mtype_First=MtypeArray[0].valueOf() 
                Mtype_Second=MtypeArray[1].valueOf() 
               // alert("Mtype_First=" + Mtype_First);
               // alert("Mtype_Second=" + Mtype_Second);
               MeasurementDesc=document.aspnetForm.MeasurementDesc.value 
              // alert("MeasurementDesc=" + MeasurementDesc);
               
               MDescArray=MeasurementDesc.split(","); 
                Feet_Desc=MDescArray[0].valueOf() 
                Inc_Desc=MDescArray[1].valueOf() 
                
               first_BoxText = eval("document.getElementById('" + Mtype_First + "').value");
               Second_BoxText = eval("document.getElementById('" + Mtype_Second + "').value");
               Selected_Tex="";
               if (first_BoxText!="")
               {
                    Selected_Text="" + first_BoxText + " " + Feet_Desc + ""
               }
               
               if (Second_BoxText!="")
               {
                    Selected_Text="" + Second_BoxText + " " + Inc_Desc + ""
               }
               if ((first_BoxText!="")&&(Second_BoxText!=""))
               {
                    Selected_Text="" + first_BoxText + " " + Feet_Desc + "," + Second_BoxText + " " + Inc_Desc + ""
               }
                MHType_Status=document.aspnetForm.MH_Type_q_Tab_Status.value 
               // alert("MHType_Status=" + MHType_Status);
              //  if (MHType_Status==1)
               // {
              //       Selected_Text="";   
                //}
             //   alert("first_BoxText=" + first_BoxText);
              //  alert("Second_BoxText=" + Second_BoxText);
          }
           if (Ans_Type == "H") 
          {
            // alert("inside");
                HtypeArray=PPD_Ele_Name.split(","); 
                Htype_First=HtypeArray[0].valueOf() 
                Htype_Second=HtypeArray[1].valueOf() 
               // alert("Mtype_First=" + Mtype_First);
               // alert("Mtype_Second=" + Mtype_Second);
               Timeq_desc=document.aspnetForm.Timeq_desc.value 
              // alert("MeasurementDesc=" + MeasurementDesc);
               
               HDescArray=Timeq_desc.split(","); 
                Hrs_Desc=HDescArray[0].valueOf() 
                Min_Desc=HDescArray[1].valueOf() 
                
               first_BoxText = eval("document.getElementById('" + Htype_First + "').value");
               Second_BoxText = eval("document.getElementById('" + Htype_Second + "').value");
               Selected_Tex="";
               if (first_BoxText!="")
               {
                    Selected_Text="" + first_BoxText + " " + Hrs_Desc + ""
               }
               
               if (Second_BoxText!="")
               {
                    Selected_Text="" + Second_BoxText + " " + Min_Desc + ""
               }
               if ((first_BoxText!="")&&(Second_BoxText!=""))
               {
                    Selected_Text="" + first_BoxText + " " + Hrs_Desc + ":" + Second_BoxText + " " + Min_Desc + ""
               }
                MHType_Status=document.aspnetForm.MH_Type_q_Tab_Status.value 
          }
          // alert("selected_value=" + selected_value);Prod_T00301
          //if (Selected_Answer != "") {
          eval("document.getElementById('" + Select_Product_txtBox + "').value='" + Selected_Text + "'")
          //}
     }



//************************************
     function Q_response_text(Q_no, selected_value) 
     {
         Qtext_name = "R" + Q_no
         Str_ans_val  = eval("document.getElementById('" + Qtext_name + "').value")
         //alert("Str_ans_val=" + Str_ans_val)

         Ans_val_Array = Str_ans_val.split("|");
         AVlength = Ans_val_Array.length
       //  alert("AVlength=" + AVlength)
         AVlength = eval(AVlength)
         AVlength = AVlength - 1;




         for (j = 0; j < AVlength; j++) {
             AVArrayText = Ans_val_Array[j].valueOf()
             //alert("AVArrayText=" + AVArrayText)

             //************** get answer values
             POS = AVArrayText.indexOf("_")
             Ans_Val = AVArrayText.substring(0, POS)
            // alert("Ans_Val=" + Ans_Val)
             if (selected_value == Ans_Val)
              {
                 //************** get response text			 
                 poslen = AVArrayText.length;
                 //alert("poslen=" + poslen)
                 AVArrayText = AVArrayText.substring(POS + 1, poslen)
                 //alert("AVArrayText=" + AVArrayText)
                // POS2 = AVArrayText.indexOf("_")
                 POS2 = poslen-6
                 Ans_Text = AVArrayText.substring(POS - 1, POS2)
                 //alert("Ans_Text=" + Ans_Text) 
             }
            

             //        Nxt_Q_No = RTArrayText.substring(POS2 + 1, poslen)
         }
         return Ans_Text
     }
     //*********************************************** if any questions been answers then make sure that all the questions are answered for a product. 
     function AnyQuestionAnswered(Prod_id) {
          
       //alert("AnyQuestionAnswered!")
       //alert("Prod_id=" + Prod_id);  
         Any_Prod_id_Old = document.getElementById('Validation_Select_Prod_id').value
         //alert("Any_Prod_id_Old=" + Any_Prod_id_Old);

         if (Any_Prod_id_Old != "") 
         {
             Any_EleQList = eval("document.getElementById('PQList" + Any_Prod_id_Old + "').value")
            // alert("Any_EleQList=" + Any_EleQList);
             if (Any_Prod_id_Old != Prod_id) 
             {

               //  alert("Inside the qual");
                 if (Any_EleQList != "") 
                 {
                     Any_EleQListArray = Any_EleQList.split("|");
                     arraylength = Any_EleQListArray.length
                     //alert("arraylength=" + arraylength) 
                     arraylength = eval(arraylength - 1)
                     for (g = 0; g < arraylength; g++) 
                     {
                         ArrayAny_Ele = Any_EleQListArray[g].valueOf()

                        //alert("ArrayAny_Ele=" + ArrayAny_Ele)
                         Flag = ""

                         Q_CheckDisable = eval("document.getElementById('" + ArrayAny_Ele + "').disabled")
                         // alert("Q_CheckDisable=" + Q_CheckDisable)
                          if (Q_CheckDisable == false) 
                          {
                              textBoxValue = eval("document.getElementById('" + ArrayAny_Ele + "').value")

                              if (textBoxValue == "") 
                             {
                                 document.getElementById('AnyProduct_answered').value = '';
                                 Flag = "1"
                             }
                             if (textBoxValue != "") {
                                 Flag = "0"
                             }
                         } //ending of disable	
                         if (Flag == "0") 
                         {
                             document.getElementById('AnyProduct_answered').value = 'Y';
                              // alert("false")
                             return false;
                         }	
                         
                     } //for loop

                 } //if (Any_EleQList != "") 
             } //if (Any_Prod_id_Old != Prod_id) 
         } //if (Any_Prod_id_Old != "") 
        // alert("done")
         return true;
     }
     //**********************************Validation
     function Validation(Ele_name, Prod_id, Q_no, Ans_Val_High, Ans_Val_Low) {
      // alert("Validation");
        //alert("Prod_id=" + Prod_id);
       // alert("Ele_name=" + Ele_name);
     //Hide the pop up div
         ClosePopup()
         StrSave_Answer = "";
         StrEle_Answer_value="";
         StrSaveAnsback="";
         StrEle_Ansback_value="";
         StrHLV="";
      
        // alert("Validation!")
         //  alert("Q_no=" + Q_no);
         Validat_Prod_id_Old =document.getElementById('Validation_Select_Prod_id').value 
         //alert("Validat_Prod_id_Old=" + Validat_Prod_id_Old);
         
         if (Validat_Prod_id_Old != "") 
         {
             Val_EleQList = eval("document.getElementById('PQList" + Validat_Prod_id_Old + "').value")
           // alert("Val_EleQList=" + Val_EleQList);
             if (Validat_Prod_id_Old != Prod_id)
              {

               //  alert("Inside the qual");
                 if (Val_EleQList != "") 
                 {
                     Val_EleQListArray = Val_EleQList.split("|");
                     arraylength = Val_EleQListArray.length
                     // alert("arraylength=" + arraylength) 
                     arraylength = eval(arraylength - 1)
                     for (f = 0; f < arraylength; f++) 
                     {
                          Ele_Answer_value=""
                          Str_Ans_ValCB=""
                          ArrayVal_Ele = Val_EleQListArray[f].valueOf()
                          LoopQuestion = ArrayVal_Ele.substring(6, 9)
                          Ans_Type = ArrayVal_Ele.substring(5, 6)
                          //alert("LoopQuestion=" + LoopQuestion)
                         // alert("Ans_Type=" + Ans_Type)
                           StrHLV="HLV" + Validat_Prod_id_Old; 
                          // alert("StrHLV=" + StrHLV);
                           StrHighLowList =eval("document.getElementById('" + StrHLV + "').value") 
                          //  alert("StrHighLowList=" + StrHighLowList);
                            HighLowListArray = StrHighLowList.split("|");
                            ArrayHighLow_Val = HighLowListArray[f].valueOf()
                           // alert("ArrayHighLow_Val=" + ArrayHighLow_Val)
                           
                                // alert("ArrayVal_Ele=" + ArrayVal_Ele)
                                Q_CheckDisable = eval("document.getElementById('" + ArrayVal_Ele + "').disabled")
						       // alert("Q_CheckDisable_Vad=" + Q_CheckDisable)
                                if (Q_CheckDisable == false)
                                 {
                                    Ele_Answer_value = eval("document.getElementById('" + ArrayVal_Ele + "').value");
                                   // alert("Ele_Answer_value=" + Ele_Answer_value)
                                    if (Ele_Answer_value == "") 
                                    {
                                            ShowErrorMessageFlg=document.aspnetForm.ShowErrorMessageFlg.value
                                            document.aspnetForm.ShowErrorMessageCnt.value=1
                                        if (ShowErrorMessageFlg=="Y")
                                            {
                                                    alert('<%=vPrompts[9]%>' + " " + LoopQuestion)
                                                    ElementOnFocus(ArrayVal_Ele)
                                            }
                                            else
                                            {
                                                document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                            }
                                       
                                        return false;
                                       // break;
                                    }
                                    else
                                    {
                                          EachArrHLV=ArrayHighLow_Val.split("_"); 
                                          HLV_Q_no=EachArrHLV[0].valueOf() 
                                          HLV_HighVal=EachArrHLV[1].valueOf() 
                                          HLV_LowVal=EachArrHLV[2].valueOf()
                                          //alert("HLV_Q_no=" + HLV_Q_no)
                                           // alert("HLV_HighVal=" + HLV_HighVal)
                                           //  alert("HLV_LowVal=" + HLV_LowVal) 
                                             
                                             // alert("Validation 1 ") 
                                              
                                                    if (QV_NDPHM(ArrayVal_Ele, Validat_Prod_id_Old, HLV_Q_no, HLV_HighVal, HLV_LowVal, Ans_Type)== false) 
                                                    {
                                                           // document.getElementById('Question_Validation_NDPHM_Error_status').value = "Y"
                                                          
                                                           document.getElementById('FocusEle_name').value=ArrayVal_Ele
                                                           //document.getElementById('DisplayCallFormFunction').value='N'
                                                           ElementOnFocus(ArrayVal_Ele)
                                                          //SelectedCellColorValidation(ArrayVal_Ele, Validat_Prod_id_Old, HLV_Q_no)
                                                           SelectedCellColor(ArrayVal_Ele, Validat_Prod_id_Old, HLV_Q_no)
                                                          // alert("did Question_Validation_NDPHM") 
                                                           return false;
                                                           //break;
                                                    }
                                                   // else
                                                  //  {
                                                    //            document.getElementById('DisplayCallFormFunction').value='Y'
                                                  //  }
                                    }
                                    
                                }
                                else
                                {
						                Ele_Answer_value="Disabled";
                                }
                                //alert("Ele_Answer after=" + Ele_Answer_value)
                              //  alert("out Validation ") 
                                if (Ele_Answer_value != "") 
                                {
                                        
                                   
                                     if( Ans_Type == "C")
                                      {
                                               // alert("Ele_Answer before=" + Ele_Answer_value)
                                                //Ele_Answer_value = Ele_Answer_value.replace(/\r\n/g, "\n");
                                                Ele_Answer_value = Ele_Answer_value.replace(/(\r\n|\n|\r)/gm, "|");	
                                                
                                              // alert("Ele_Answer_valueqqqq=" + Ele_Answer_value)
                                                
                                                 CheckBoxArray1  = Ele_Answer_value.split("|") 
                                                 CheckBoxlength1 = CheckBoxArray1.length;
                                                // alert("CheckBoxlength1=" + CheckBoxlength1) 
                                                 for (p = 0; p < CheckBoxlength1; p++) 
                                                   {
                                                            CheckBoxArraytext1 = CheckBoxArray1[p].valueOf()
                                                            // alert("CheckBoxArraytext1=" + CheckBoxArraytext1)
                                                              if (Ele_Answer_value!="Disabled")
                                                              {
                                                                Str_Ans_ValCB = CheckBoxArraytext1.substring(0, 1)
                                                              }
                                                             else
                                                              {
                                                                    Str_Ans_ValCB="Disabled";
                                                              }
                                                            // alert("Str_Ans_ValCB=" + Str_Ans_ValCB)
                                                             StrEle_Answer_value="" + ArrayVal_Ele + "," + Str_Ans_ValCB + ""
                                                             StrEle_Ansback_value="" + ArrayVal_Ele + "," + CheckBoxArraytext1 + ""
                                                             
                                                           if (StrSave_Answer == "")
                                                            {
                                                                StrSave_Answer = StrEle_Answer_value
                                                                StrSaveAnsback=StrEle_Ansback_value
                                                            }
                                                            else 
                                                            {
                                                                StrSave_Answer = StrSave_Answer + "|" + StrEle_Answer_value
                                                                StrSaveAnsback = StrSaveAnsback + "|" + StrEle_Ansback_value
                                                            }
                                                                                                      
                                                   }//For loop
                                       }
                                      else
                                      {     
                                               if (Ans_Type == "P"||Ans_Type == "N") 
                                               { 
                                                           if (Ele_Answer_value!="Disabled")
                                                           {
                                                                if (Compare_Q_Val_Submit(ArrayVal_Ele)	==false)
														            {
														                    document.getElementById('FocusEle_name').value=ArrayVal_Ele
                                                                            //document.getElementById('DisplayCallFormFunction').value='N'
                                                                            ElementOnFocus(ArrayVal_Ele)
                                                                            //SelectedCellColorValidation(ArrayVal_Ele, Validat_Prod_id_Old, HLV_Q_no)
                                                                            SelectedCellColor(ArrayVal_Ele, Validat_Prod_id_Old, HLV_Q_no)
															            return false;
														            }
                                                           }
                                                }
                                               StrEle_Ansback_value="" + ArrayVal_Ele + "," + Ele_Answer_value + ""
                                                         
                                               if (Ans_Type == "R" || Ans_Type == "L" || Ans_Type == "P" || Ans_Type == "M" || Ans_Type == "H")
                                               {
                                                        if (Ans_Type == "R" || Ans_Type == "L")
                                                        {
                                                            if (Ele_Answer_value!="Disabled")
                                                                {
                                                                    Str_Ans_ValCB = Ele_Answer_value.substring(0, 1)
                                                                }
                                                             else
                                                                {
                                                                    Str_Ans_ValCB="Disabled";
                                                                }
                                                                StrEle_Answer_value="" + ArrayVal_Ele + "," + Str_Ans_ValCB + ""
                                                         }       
                                                        if (Ans_Type == "P")
                                                        {
                                                                // alert("Ele_Answer_value=" + Ele_Answer_value)
                                                               StrEle_Answer_value=GetPriceTypeSaveString(ArrayVal_Ele,Ele_Answer_value)
                                                               //alert("P_StrEle_Answer_value=" + StrEle_Answer_value)
                                                        }
                                                       if ((Ans_Type == "M")||(Ans_Type == "H"))
                                                        {
                                                               // alert("Ele_Answer_value=" + Ele_Answer_value)
                                                              StrEle_Answer_value=GetMHtypeSaveString(ArrayVal_Ele,Ele_Answer_value,Ans_Type)
                                                             // alert("StrEle_Answer_value=" + StrEle_Answer_value)
                                                        } 
                                                         
                                                        
                                               }
                                               else
                                               {
                                                     
                                                     StrEle_Answer_value="" + ArrayVal_Ele + "," + Ele_Answer_value + ""
                                                    // alert("StrEle_Answer_value=" + StrEle_Answer_value)
                                               }
                                               
                                               
                                               if (StrSave_Answer == "")
                                                 {
                                                    StrSave_Answer = StrEle_Answer_value
                                                     StrSaveAnsback= StrEle_Ansback_value
                                                 }
                                                else 
                                                 {
                                                    StrSave_Answer = StrSave_Answer + "|" + StrEle_Answer_value
                                                    StrSaveAnsback = StrSaveAnsback + "|" + StrEle_Ansback_value
                                                 }
                                      }
                                  
                                }// if (Ele_Answer_value != "") 
                     } //for loop
                   // alert("StrSave_Answer=" + StrSave_Answer)
                    if (StrSave_Answer!="")
                    {
                        StrHiddenSaveName = "SavedList" + Validat_Prod_id_Old
                        eval("document.getElementById('" + StrHiddenSaveName + "').value='" + StrSave_Answer + "'")
                        
                        StrHiddenSaveName2 = "SavedAnsBackList" + Validat_Prod_id_Old
                        eval("document.getElementById('" + StrHiddenSaveName2 + "').value='" + StrSaveAnsback + "'")
                    }
                 } //if (Val_EleQList != "") 
             } //if (Validat_Prod_id_Old != "") 
             
                StrHiddenSaveName = "SavedList" + Validat_Prod_id_Old
                saved_ans = eval("document.getElementById('" + StrHiddenSaveName + "').value")
              //  alert("SavedList=" + saved_ans)
                 
                 StrHiddenSaveName2 = "SavedAnsBackList" + Validat_Prod_id_Old
                saved_ans2 = eval("document.getElementById('" + StrHiddenSaveName2 + "').value")
               //  alert("SavedAnsBackList=" + saved_ans2)
                 AnsweredProduct(Validat_Prod_id_Old)
         
        } //if (Validat_Prod_id_Old != "") 

     GetColor(Validat_Prod_id_Old)
}
//******************************* P-type question for saving answers
function GetPriceTypeSaveString(ArrayVal_Ele,Ele_Answer_value)
{
        PriceEle_Answer_value=""
        if (Ele_Answer_value!="Disabled")
           {                                                     
                                                                                                                       
                            POS=Ele_Answer_value.indexOf(".")
                             //alert("POS=" + POS);
                            POS2=Ele_Answer_value.length
                          //  alert("POS2=" + POS2);
                           if (POS<0)
                            {         
                                   // FirstValCheck=Ele_Answer_value.substring(0,1)
                                  //  if (FirstValCheck==0)
                                 //   {
                                 //       Dol_Val="0"
                                       // alert("Dol_Val=" + Dol_Val);
            	                      
                                   //     Cent_val=Ele_Answer_value
                                       // alert("Cent_val=" + Cent_val);
                                   //  }
                                   // else
                                  //  {
                                         Dol_Val=Ele_Answer_value
                                        // alert("Dol_Val=" + Dol_Val);
            	                      
                                         Cent_val="0"
                                        // alert("Cent_val=" + Cent_val);
                                  //  }
                            
                            }
                            else
                            {
                                          
                                         if (POS==0)
                                         {
                                            Dol_Val="0"
                                           // alert("Dol_Val=" + Dol_Val);
                                            Cent_val=Ele_Answer_value.substring(POS+1,POS2)
                                           // alert("Cent_val=" + Cent_val);
                                         }
                                         else
                                         {
                                            Dol_Val=Ele_Answer_value.substring(0,POS)
                                           // alert("Dol_Val=" + Dol_Val);
                                            Cent_val=Ele_Answer_value.substring(POS+1,POS2)
                                            //alert("Cent_val=" + Cent_val);
                                         }
                                     
                                        
			                } 
			                Dol_Val=Number(Dol_Val) 
            			     
			                PriceEle_Answer_value="" + ArrayVal_Ele + "," + Dol_Val + "|" + ArrayVal_Ele + "," + Cent_val + ""
			                    //PriceEle_Answer_value="" + ArrayVal_Ele + "," + Ele_Answer_value + ""
                              // alert("PriceEle_Answer_value=" + PriceEle_Answer_value)
                    }
			     else
                    {
                         PriceEle_Answer_value="" + ArrayVal_Ele + ",Disabled|" + ArrayVal_Ele + ",Disabled"
                    }
        return 	PriceEle_Answer_value		    

}
//******************************* M-type and H -type question for saving answers
function GetMHtypeSaveString(ArrayVal_Ele,Ele_Answer_value,Ans_Type)
{
      //  alert("Ans_Type=" + Ans_Type)
        MeaEle_Answer_value=""
                if (Ele_Answer_value!="Disabled")
                   {                            
                                if (Ans_Type == "M")
                                    {                         
                                            MeasurementDesc=document.aspnetForm.MeasurementDesc.value 
                                            MGArray=MeasurementDesc.split(","); 
                                            Feet_DescG=MGArray[0].valueOf() 
                                            Inc_DescG=MGArray[1].valueOf() 
                                    //get responses
                                             ResponseFeet="" 
                                             ResponseInc="" 
                                             MH_Ele_val=Ele_Answer_value.replace(Feet_DescG,"") 
                                             MH_Ele_val=MH_Ele_val.replace(Inc_DescG,"")  
                                                
                                             MHResArray=MH_Ele_val.split(",");
                                             ResponseFeet=MHResArray[0].valueOf() 
                                             ResponseInc=MHResArray[1].valueOf()  
                                    
			                                 ResponseFeet=Number(ResponseFeet) 
			                                 ResponseInc=Number(ResponseInc) 
                    			     
			                                MH_Ele_Ans_value="" + ArrayVal_Ele + "," + ResponseFeet + "|" + ArrayVal_Ele + "," + ResponseInc + ""
			                         }
			                         if (Ans_Type == "H")
                                     {
                                            Timeq_desc=document.aspnetForm.Timeq_desc.value 
                                            HGArray=Timeq_desc.split(","); 
                                            Hrs_DescG=HGArray[0].valueOf() 
                                            Min_DescG=HGArray[1].valueOf() 
                                    //get responses
                                             ResponseHrs="" 
                                             ResponseMin="" 
                                             MH_Ele_val=Ele_Answer_value.replace(Hrs_DescG,"") 
                                             MH_Ele_val=MH_Ele_val.replace(Min_DescG,"")  
                                                
                                             MHResArray=MH_Ele_val.split(":");
                                             ResponseHrs=MHResArray[0].valueOf() 
                                             ResponseMin=MHResArray[1].valueOf()  
                                    
			                                 ResponseHrs=Number(ResponseHrs) 
			                                 ResponseMin=Number(ResponseMin) 
                    			     
			                                    MH_Ele_Ans_value="" + ArrayVal_Ele + "," + ResponseHrs + "|" + ArrayVal_Ele + "," + ResponseMin + ""
			                             
                                           // alert("PriceEle_Answer_value=" + PriceEle_Answer_value)
                                      }
                    }
			     else
                    {
                                            MH_Ele_Ans_value="" + ArrayVal_Ele + ",Disabled|" + ArrayVal_Ele + ",Disabled"
                    }
        return 	MH_Ele_Ans_value		    

}
   //*************************Save the products for next page that are answered in a list so it can use for the loop before going to next page.
function AnsweredProduct(ProdNo)
{
     //alert("ProdNo=" + ProdNo) 
  //  alert("AnsweredProduct=") 
    NameOfSave="SavedList" + ProdNo
	AnswerSaveCheck =eval("document.aspnetForm." + NameOfSave + ".value")
     //alert("AnswerSaveCheck=" + AnswerSaveCheck) 
    
     ProdAnsForNextPage=eval("document.aspnetForm.ProdAnsForNextPage.value")
    // alert("ProdAnsForNextPage=" + ProdAnsForNextPage) 
     
     if (AnswerSaveCheck!="")
     {
                 if (ProdAnsForNextPage=="")
                 {
                        //alert("Empty")
                        document.aspnetForm.ProdAnsForNextPage.value=ProdNo + "|" 
	             }
	             else
	             {
			            ProdAnsFNPArray = ProdAnsForNextPage.split("|");
	                    PAlength = ProdAnsFNPArray.length
	                    //alert("arraylength=" + arraylength)  Trim
	                    PAlength=eval(PAlength-1)
	                    AddProd="Y";
	                    for (s = 0 ; s < PAlength ; s++ )
			            {
			                PAFNPAEle = ProdAnsFNPArray[s].valueOf()
			                 //alert("PAFNPAEle=" + PAFNPAEle)
			                 //alert("ProdNo=" + ProdNo) 
			                 if (Trim(ProdNo)==(PAFNPAEle))
			                {   
			                  // alert("break") 
			                   AddProd="N";
			                } 
			            }
			           // alert("AddProd=" + AddProd) 
			          
			           
                        if (Trim(AddProd)=="Y")
			              {
			                 document.aspnetForm.ProdAnsForNextPage.value=ProdAnsForNextPage + "" + ProdNo + "|"    
			              }  
                 }//if (ProdAnsForNextPage=="")
     }// if (AnswerSaveCheck!="")
     ProdAnsForNextPage=eval("document.aspnetForm.ProdAnsForNextPage.value")
    // alert("ProdAnsForNextPage=" + ProdAnsForNextPage) 
} 
//************************************Create a questions for a selected product

 function CreateQuestion(Prod_id, Question_name, Ans_Val_High, Ans_Val_Low) 
{
    //alert("QuestionElement=" + QuestionElement) 
    //*** Question Header Array
    
   
    HTMLText = "";
    Answer_Type = "";
    ControlName = "";
    HTMLText = HTMLText + "<table bgcolor='#f5fffa' cellpadding='0' cellspacing='0'>";
    HTMLText = HTMLText + "<tr >";
    HTMLText = HTMLText + "<td width='96%' height='10%'> &nbsp; </td>";
    HTMLText = HTMLText + "<td align='right'  width='4%' height='10%'><img src='Images/x.jpg' onclick='return ClosePopup();'></td>";
    HTMLText = HTMLText + "</tr>";
    HTMLText = HTMLText + "</table>";   
    HTMLText = HTMLText + "<table border='1' width='100%'  bordercolor='dodgerblue'>";
    RCA = 0
 

        StrQ_no = Question_name
        QHName = "Q" + StrQ_no
        QuestionText = eval("document.getElementById('" + QHName + "').value")
        
        POS = QuestionText.indexOf("_")
        Ans_Type = QuestionText.substring(0, POS)
        
        poslen = QuestionText.length;
       
        Q_Text = QuestionText.substring(POS + 1, poslen)
        

        DisplayQ_text = Question_name + " - " + Q_Text
        if (Ans_Type == "C") {
            Answer_Type = '<%=vPrompts[85]%>';
            ControlName = ControlName + "C" + StrQ_no + "0" + Prod_id + "|";
        }
        if (Ans_Type == "D") {
            Answer_Type = '<%=vPrompts[89]%>';
            DateRule = eval("document.getElementById('" + DateRule + "').value") 
            Answer_Type = Answer_Type.replace("mm/dd/yyyy", DateRule)
            
            ControlName = ControlName + "D" + StrQ_no + "0" + Prod_id + "|";
        }
        if (Ans_Type == "N") {
            Answer_Type = '<%=vPrompts[90]%>';
            ControlName = ControlName + "N" + StrQ_no + "0" + Prod_id + "|";
        }
        if (Ans_Type == "T") {
            Answer_Type = '<%=vPrompts[88]%>';
            ControlName = ControlName + "T" + StrQ_no + "0" + Prod_id + "|";
        }
        if (Ans_Type == "L" || Ans_Type == "R") {
            Answer_Type = '<%=vPrompts[86]%>';
            if (Ans_Type == "L") {
                ControlName = ControlName + "L" + StrQ_no + "0" + Prod_id + "|";
            }
            if (Ans_Type == "R") {
                ControlName = ControlName + "R" + StrQ_no + "0" + Prod_id + "|";
            }
        }
        if (Ans_Type == "P" || Ans_Type == "M" || Ans_Type == "H") 
        {
            Answer_Type = '<%=vPrompts[87]%>';
            if (Ans_Type == "P") {
                ControlName = ControlName + "P" + StrQ_no + "0" + Prod_id + "|";
                ControlName = ControlName + "P" + StrQ_no + "1" + Prod_id + "|";
            }
            if (Ans_Type == "M") {
                ControlName = ControlName + "M" + StrQ_no + "0" + Prod_id + "|";
                ControlName = ControlName + "M" + StrQ_no + "1" + Prod_id + "|";
            }
            if (Ans_Type == "H") {
                ControlName = ControlName + "H" + StrQ_no + "0" + Prod_id + "|";
                ControlName = ControlName + "H" + StrQ_no + "1" + Prod_id + "|";
            }
         }
   
        HTMLText = HTMLText + "<tr  style='background-color:LightYellow;'>";
        HTMLText = HTMLText + "<td class='selectionCriteriaItem'>QNo.</td>";
        HTMLText = HTMLText + "<td class='selectionCriteriaItem'><B>" + DisplayQ_text + "<span style='color:red;'> " + Answer_Type + " </span></B></td>";
        HTMLText = HTMLText + "</tr>";

        HTMLResponseText = GetQuestionResponse(Ans_Type, StrQ_no, Prod_id, Ans_Val_High, Ans_Val_Low)
        HTMLText = HTMLText + "" + HTMLResponseText
    //}
    HTMLText = HTMLText + "</Table>";
  
    //Display the call form    
    ProdQuestion.innerHTML = HTMLText;
}

//**************************************** Get the responses for each question 
function GetQuestionResponse(Ans_Type, StrQ_no, Prod_id, High_Val, Low_Val) {
    //     alert("High_Val=" + High_Val)
 
    DateRule = eval("document.getElementById('DateRule').value")

    RTname = "R" + StrQ_no
    ResponseText = eval("document.getElementById('" + RTname + "').value")
  

    RTArray = ResponseText.split("|");
    RTlength = RTArray.length
 
    RTlength = eval(RTlength)
    RTlength = RTlength - 1;


    HTML_Ele = "";
    HTML_Ele = HTML_Ele + "<tr>";
    HTML_Ele = HTML_Ele + "<td class='selectionCriteriaItem'>Ans</td>";
    HTML_Ele = HTML_Ele + "<td>";
    HTML_Ele = HTML_Ele + "<Table border='0'>";


    for (q = 0; q < RTlength; q++) {
        RTArrayText = RTArray[q].valueOf()
    

        //************** get answer values
        POS = RTArrayText.indexOf("_")
        Ans_Val = RTArrayText.substring(0, POS)
        
        //************** get response text			 
        poslen = RTArrayText.length;
       
        RTArrayText = RTArrayText.substring(POS + 1, poslen)
       
        POS2 = poslen-6
    
        Ans_Text = RTArrayText.substring(POS - 1, POS2)
      

        Nxt_Q_No = RTArrayText.substring(POS2 + 1, poslen)
       
        StrItems = "";
        StrOnlick = "";
        StrItems = "'" + Nxt_Q_No + "','" + StrQ_no + "','PQList" + Prod_id + "',0";
        StrItemNDPHM = "'" + Nxt_Q_No + "','" + StrQ_no + "','PQList" + Prod_id + "',1";
        StrItemKey = "'event'";

         
        stronkeypress = 'onkeypress="SkipPattern(' + StrItems + ')"';
        Stronclick = 'onclick="SkipPattern(' + StrItems + ')"';
        StronclickNDPHM = 'onclick="SkipPattern(' + StrItemNDPHM + ')"';

        StrOnlickTypeT = 'onchange="SkipPattern(' + StrItems + ')"';
        StrOnkeyDate = 'onkeypress="return DateNumberOnly(' + StrItemKey + ')"';
        StrOnkeyNumber = 'onkeypress="return NumberOnly(' + StrItemKey + ')"';
        
      
        
        Ele_id_name = "";
        Ele_name = "";
        Ele_name2="";
        StrItemM="";
        

        if (Ans_Type == "C") {
            Ele_id_name = "C" + StrQ_no + "0" + Prod_id + "" + Ans_Val + "";
            Ele_name = "C" + StrQ_no + "0" + Prod_id + "";
            HTML_Ele = HTML_Ele + "<tr><td class='selectionCriteriaItem'>";
            
            HTML_Ele = HTML_Ele + "<div id='rad_Span" + StrQ_no + "0" + Prod_id + "" + q + "' style='width:20px;float:left;'>";
            HTML_Ele = HTML_Ele + "<INPUT type='checkbox' name='C" + StrQ_no + "0" + Prod_id + "' id='C" + StrQ_no + "0" + Prod_id + "" + Ans_Val + "' value='" + Ans_Val + "' " + Stronclick + "></div><span style='color:red;'></span>" + Ans_Text + "";
            HTML_Ele = HTML_Ele + "</td></tr>";
        }
        if (Ans_Type == "L") {
            Ele_id_name = "L" + StrQ_no + "0" + Prod_id + "" + Ans_Val + "";
            Ele_name = "L" + StrQ_no + "0" + Prod_id + "";
            HTML_Ele = HTML_Ele + "<tr><td class='selectionCriteriaItem'>";
            
            HTML_Ele = HTML_Ele + "<div id='rad_Span" + StrQ_no + "0" + Prod_id + "" + q + "' style='width:20px;float:left;'>";
            HTML_Ele = HTML_Ele + "<INPUT type='radio' name='L" + StrQ_no + "0" + Prod_id + "'  id='L" + StrQ_no + "0" + Prod_id + "" + Ans_Val + "' value='" + Ans_Val + "'  " + Stronclick + "></div><span style='color:red;'></span>" + Ans_Text + "";
            HTML_Ele = HTML_Ele + "</td></tr>";
        }
        if (Ans_Type == "R") {
            Ele_id_name = "R" + StrQ_no + "0" + Prod_id + "" + Ans_Val + "";
            Ele_name = "R" + StrQ_no + "0" + Prod_id + "";

            HTML_Ele = HTML_Ele + "<tr><td class='selectionCriteriaItem' >";
            
            HTML_Ele = HTML_Ele + "<div id='rad_Span" + StrQ_no + "0" + Prod_id + "" + q + "' style='width:20px;float:left;'>";
            HTML_Ele = HTML_Ele + "<INPUT type='radio' name='R" + StrQ_no + "0" + Prod_id + "' id='R" + StrQ_no + "0" + Prod_id + "" + Ans_Val + "' value='" + Ans_Val + "'  " + Stronclick + " ></div><span style='color:red;'></span>" + Ans_Text + "";
            HTML_Ele = HTML_Ele + "</td></tr>";
        }
        if (Ans_Type == "T") {
            StrItemT = "";
            StrOnlickT = "";
            StrKeydown="";
            StrItemT = "'event','Counter" + StrQ_no + "','T" + StrQ_no + "0" + Prod_id + "'";
     
            StrOnlickT = 'onKeyPress="return EnterText(' + StrItemT + ')"';
            StrOnkeyText = 'onkeydown="return TextCheckOnly(' + StrItemT + ')"';
           // StrKeydown='onKeyPress="return ( this.value.length < 100 )"' ;
           
         
            Ele_id_name = "T" + StrQ_no + "0" + Prod_id + "";
            Ele_name = "T" + StrQ_no + "0" + Prod_id + "";
            HTML_Ele = HTML_Ele + "<tr><td class='selectionCriteriaItem'>";
            HTML_Ele = HTML_Ele + "<textarea  rows='8' cols='40' style='height:50px;width:300px;' maxlength='100' name='T" + StrQ_no + "0" + Prod_id + "'  id='T" + StrQ_no + "0" + Prod_id + "' " + StrOnlickTypeT + " " + StrOnlickT + " " + StrOnkeyText + "></textarea><span style='color:red;'></span>" + Ans_Text + "";
            HTML_Ele = HTML_Ele + "<BR>Character Count - 100 maximum <input type='text' id='Counter" + StrQ_no + "' name='Counter" + StrQ_no + "' size='1' style='background-color: #E0E0E0' disabled>";
            HTML_Ele = HTML_Ele + "</td></tr>";
        }
        if (Ans_Type == "N") {
            Ele_id_name = "N" + StrQ_no + "0" + Prod_id + "";
            Ele_name = "N" + StrQ_no + "0" + Prod_id + "";

            HTML_Ele = HTML_Ele + "<INPUT type='text' name='N" + StrQ_no + "0" + Prod_id + "'  size=10 maxlength=8 id='N" + StrQ_no + "0" + Prod_id + "'   " + StronclickNDPHM + " " + StrOnkeyNumber + "><span style='color:red;'></span>" + Ans_Text + "";
            HTML_Ele = HTML_Ele + "</td></tr>";
        }
        if (Ans_Type == "D") {
            Ele_id_name = "D" + StrQ_no + "0" + Prod_id + "";
            Ele_name = "D" + StrQ_no + "0" + Prod_id + "";

            HTML_Ele = HTML_Ele + "<tr><td class='selectionCriteriaItem'>";
            HTML_Ele = HTML_Ele + "<INPUT type='text' name='D" + StrQ_no + "0" + Prod_id + "'  size=10 maxlength=12 id='D" + StrQ_no + "0" + Prod_id + "' " + StronclickNDPHM + " " + StrOnkeyDate + "><span style='color:red;'>" + DateRule + "</span>";
            HTML_Ele = HTML_Ele + "</td></tr>";
        }
        if (Ans_Type == "P") {
            Ele_id_name = "P" + StrQ_no + "0" + Prod_id + "";
            Ele_name = "P" + StrQ_no + "0" + Prod_id + "";

            HTML_Ele = HTML_Ele + "<tr><td class='selectionCriteriaItem'>";
            HTML_Ele = HTML_Ele + "<INPUT type='text' name='P" + StrQ_no + "0" + Prod_id + "'  size=10 maxlength=8 id='P" + StrQ_no + "0" + Prod_id + "' " + StrOnlickTypeT + "  " + StrOnkeyNumber + "><span style='color:red;'><%=vPrompts[94]%></span>";
            HTML_Ele = HTML_Ele + " <INPUT type='text' name='P" + StrQ_no + "1" + Prod_id + "'  size=10 maxlength=2 id='P" + StrQ_no + "1" + Prod_id + "' " + StrOnlickTypeT + "  " + StrOnkeyNumber + "><span style='color:red;'><%=vPrompts[95]%></span>";
            HTML_Ele = HTML_Ele + "</td></tr>";
        }
        if (Ans_Type == "M") {
            Ele_id_name = "M" + StrQ_no + "0" + Prod_id + "";
            Ele_name = "M" + StrQ_no + "0" + Prod_id + "";
            Ele_name2 = "M" + StrQ_no + "1" + Prod_id + "";
            
            StrItemM = "'" + Ele_name + "','" + Ele_name2 + "'";
            Ele_name = "" + Ele_name + "," + Ele_name2 + "";
            StrMonfocusText = 'onfocus="return MHTypeTab_val(' + StrItemM + ')"';
            StrMonfocusText2 = 'onfocus="return MHTypeTab_BoxSec(' + StrItemM + ')"';
           
            HTML_Ele = HTML_Ele + "<tr><td class='selectionCriteriaItem'>";
            HTML_Ele = HTML_Ele + "<INPUT type='text' name='M" + StrQ_no + "0" + Prod_id + "'  size=10 maxlength=8 id='M" + StrQ_no + "0" + Prod_id + "'  " + StrOnlickTypeT + "  " + StrOnkeyNumber + " " + StrMonfocusText + "><span style='color:red;'><%=vPrompts[96]%></span>";
            HTML_Ele = HTML_Ele + " <INPUT type='text' name='M" + StrQ_no + "1" + Prod_id + "'  size=4 maxlength=2 id='M" + StrQ_no + "1" + Prod_id + "' " + StrOnlickTypeT + "  " + StrOnkeyNumber + " " + StrMonfocusText2 + "><span style='color:red;'><%=vPrompts[97]%></span>";
            HTML_Ele = HTML_Ele + "</td></tr>";
        }
        if (Ans_Type == "H") {
            Ele_id_name = "H" + StrQ_no + "0" + Prod_id + "";
            Ele_name = "H" + StrQ_no + "0" + Prod_id + "";
            Ele_name2 = "H" + StrQ_no + "1" + Prod_id + "";
            
            StrItemM = "'" + Ele_name + "','" + Ele_name2 + "'";
            Ele_name = "" + Ele_name + "," + Ele_name2 + "";
            StrMonfocusText = 'onfocus="return MHTypeTab_val(' + StrItemM + ')"';
            StrMonfocusText2 = 'onfocus="return MHTypeTab_BoxSec(' + StrItemM + ')"';
            
            HTML_Ele = HTML_Ele + "<tr><td class='selectionCriteriaItem'>";
            HTML_Ele = HTML_Ele + "<INPUT type='text' name='H" + StrQ_no + "0" + Prod_id + "'  size=10 maxlength=8 id='H" + StrQ_no + "0" + Prod_id + "'  " + StrOnlickTypeT + "  " + StrOnkeyNumber + " " + StrMonfocusText + "><span style='color:red;'><%=vPrompts[98]%></span>";
            HTML_Ele = HTML_Ele + " <INPUT type='text' name='H" + StrQ_no + "1" + Prod_id + "'  size=4 maxlength=2 id='H" + StrQ_no + "1" + Prod_id + "' " + StrOnlickTypeT + "  " + StrOnkeyNumber + " " + StrMonfocusText2 + "><span style='color:red;'><%=vPrompts[99]%></span>";
            HTML_Ele = HTML_Ele + "</td></tr>";
        }

        //alert("q=" + q)
        //*********** save the focus on the first element of the popupdiv
        if (q == 0) {
            document.getElementById('DivPopUP_Ele_id').value = Ele_id_name
        }

        document.getElementById('DivPopUP_Ele_Name').value = Ele_name
    }
    //return false;
    HTML_Ele = HTML_Ele + "</Table>";
    HTML_Ele = HTML_Ele + "</td>";
    HTML_Ele = HTML_Ele + "</tr>";
   
    return HTML_Ele;
}
function ClosePopup() {
    el = document.getElementById('ProdQuestion');
    el.style.display = "none";
}
//******************************** Display Div with question on it
function DivQuestion() {
   // alert("hideDiv");

        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;
        // alert("charCode=" + charCode);
        
        var evt2 = e || window.event; 
        var node = (evt2.target) ? evt2.target : ((evt2.srcElement) ? evt2.srcElement : null); 
        
        //For measurement or hour type questions  
        //*****************name of the second text
          MHType_Boxname=document.aspnetForm.MH_Type_q_Tab_Val.value 
        //*****************set a flag to tab to second textbox of Measurement or hours
          MHType_Status=document.aspnetForm.MH_Type_q_Tab_Status.value 
        // alert("MHType_Status=" + MHType_Status);
           if (MHType_Status==1)
            {
                    // alert("MHType_Boxname=" + MHType_Boxname);        
                              
                                 if ((charCode == 13)||(charCode == 39)||(charCode == 9))
                                {
                                     eval("document.getElementById('" + MHType_Boxname + "').focus()")
                                     eval("document.getElementById('" + MHType_Boxname + "').select()")
                                       if (e.preventDefault) 
                                        {
                                            e.preventDefault();
                                        }
                                        else 
                                        {
                                            e.returnValue = false;
                                        }
                                }
                                
                               //document.aspnetForm.MH_Type_q_Tab_Status.value=''
                              // document.aspnetForm.MH_Type_q_Tab_Val.value='' 
            }
            else
            {
        
                        
                             MoveNxtProdFlg="Y"
                             if (charCode == 13)
                             {
                                     if (node.type=="textarea")
                                     {
                                        MoveNxtProdFlg="N"
                                     }
                             }
                             
                               if (MoveNxtProdFlg =="Y") 
                               {
                                            if ((charCode == 9)||(charCode == 13)||(charCode == 39)) 
                                           {
                                                  strPopQTabkey= document.getElementById('PopQTabkey').value
                                                
                                                        //Save next focus product by not using skip pattern
                                                        MoveToNextProduct()
                                                 

                                                    //Save next focus product by skip pattern
                                                    StrNextFocusEle = document.getElementById('Skipattern_NextFocusEle').value
                                        
                                                el = document.getElementById('ProdQuestion');
                                                el.style.display = "none";
                                                if (StrNextFocusEle == "Done") 
                                                {
                                                     //alert("Done qqqqq");
                                                     return false;
                                                }
                                              
                                           
                                                eval("document.getElementById('" + StrNextFocusEle + "').focus()")
                                                eval("document.getElementById('" + StrNextFocusEle + "').select()")
                                               
                                                
                                                if (e.preventDefault) 
                                                {
                                                    e.preventDefault();
                                                }
                                                else 
                                                {
                                                    e.returnValue = false;
                                                }
                                               
                                           }
                                 }// if (MoveNxtProdFlg =="Y") 
            }//if (MHType_Status==1)
                           document.getElementById('PopQTabkey').value = 0;
 
}
function MoveToNextProdCheck(StrKeyCode)
{

             var e = event || evt; // for trans-browser compatibility
             var charCode = e.which || e.keyCode;
    
           // alert("StrKeyCode=" + StrKeyCode);
             if ((charCode == 9)||(charCode == 13)||(charCode == 39)) 
                   {
                   
                                MoveToNextProduct()
                                
                               StrNextFocusEle = document.getElementById('Skipattern_NextFocusEle').value
                                el = document.getElementById('ProdQuestion');
                                el.style.display = "none";
                                if (StrNextFocusEle == "Done") 
                                {
                                    
                                     return false;
                                }
                              
                           
                                eval("document.getElementById('" + StrNextFocusEle + "').focus()")
                                eval("document.getElementById('" + StrNextFocusEle + "').select()")
                             
                                
                                if (e.preventDefault) 
                                {
                                    e.preventDefault();
                                }
                                else 
                                {
                                    e.returnValue = false;
                                }
                   }
}

function QuestionTypeNumeric() {
    
  
    el = document.getElementById('ProdQuestion');
    el.style.display = "none";
  
}

//***************************************** give Cell a back ground color
function SelectedCellColorValidation(Ele_name, Product_name, Question_name) 
{
  // alert("SelectedCellColor");
    Cell_id = "TD" + Product_name + "_" + Question_name
        eval("document.getElementById('" + Cell_id + "').style.backgroundColor = '#99CCFF'")
        eval("document.getElementById('" + Ele_name + "').style.backgroundColor = '#99CCFF'")
    
 }   

function SelectedCellColor(Ele_name, Product_name, Question_name) {
  // alert("SelectedCellColor");
    Cell_id = "TD" + Product_name + "_" + Question_name
  
    StrOldCellColorId = document.getElementById('OldCellColorId').value;
    StrOldCellEleColorId = document.getElementById('OldCellEleColorId').value;

    StrOldRowColorId = document.getElementById('OldRowColorId').value;
 
    if (StrOldCellColorId == "") 
    {

        eval("document.getElementById('" + Cell_id + "').style.backgroundColor = '#99CCFF'")
        eval("document.getElementById('" + Ele_name + "').style.backgroundColor = '#99CCFF'")
    }
    else {
        //Old
        eval("document.getElementById('" + StrOldCellColorId + "').style.backgroundColor = 'mintcream'")
        eval("document.getElementById('" + StrOldCellEleColorId + "').style.backgroundColor = 'mintcream'")
        //New
            eval("document.getElementById('" + Cell_id + "').style.backgroundColor = '#99CCFF'")
            eval("document.getElementById('" + Ele_name + "').style.backgroundColor = '#99CCFF'")
    }

    document.getElementById('OldCellColorId').value = Cell_id
    document.getElementById('OldCellEleColorId').value = Ele_name
}
//*****************************************First selected Row Id
function SelectedFirstCellRowColor(Product_name) {
  // alert("SelectedFirstCellRowColor");
 
    
    //************saved answered
    Save_Ans_Prod = eval("document.getElementById('SavedList" + Product_name + "').value")
    
    element_color = eval("document.getElementById('Cell1_" + Product_name + "').style.backgroundColor")
    
     ColorFlag=""
    
    
   
    StrOldRowColorId = document.getElementById('OldRowColorId').value;
 
    if (Product_name != StrOldRowColorId) 
    {
        if (StrOldRowColorId == "") 
         {
            eval("document.getElementById('Cell1_" + Product_name + "').style.backgroundColor= 'Deepskyblue'")
           // SelectedRowElementColor(Product_name)
         }
        else
         {
             //Old
             
                 eval("document.getElementById('Cell1_" + StrOldRowColorId + "').style.backgroundColor= 'mintcream'")
           
               //selected one is answered then keep it blue
                 if (Save_Ans_Prod != "")
                 {
                     eval("document.getElementById('Cell1_" + Product_name + "').style.backgroundColor= 'Deepskyblue'")
                 }
                 Save_Ans_Prod_old = eval("document.getElementById('SavedList" + StrOldRowColorId + "').value")
                  
                //selected one is answered then keep it blue
                 if (Save_Ans_Prod_old != "")
                 {
                     eval("document.getElementById('Cell1_" + StrOldRowColorId + "').style.backgroundColor= 'Deepskyblue'")
                 }  
           

            //New
            eval("document.getElementById('Cell1_" + Product_name + "').style.backgroundColor= 'Deepskyblue'")
            
        }
    } // if (Product_name != StrOldRowColorId) 
    
    document.getElementById('OldRowColorId').value = Product_name;
}
//***************************************** give row a back ground color
//#1874CD is bule

function SelectedRowColor(Product_name) {

   // alert("SelectedRowColor");
    StrOldRowColorId = document.getElementById('OldRowColorId').value;
    if (Product_name != StrOldRowColorId) {
        if (StrOldRowColorId == "") {
            eval("document.getElementById('TR" + Product_name + "').style.backgroundColor= '#99CCFF'")
           SelectedRowElementColor(Product_name)
        }
        else {
            //Old
            eval("document.getElementById('TR" + StrOldRowColorId + "').style.backgroundColor= 'mintcream'")
            SelectedRowElementColorOld(StrOldRowColorId)

            //New
            eval("document.getElementById('TR" + Product_name + "').style.backgroundColor= '#99CCFF'")
            SelectedRowElementColor(Product_name)
        }
    } // if (Product_name != StrOldRowColorId) 

    document.getElementById('OldRowColorId').value = Product_name;
}
//Question is answered for product then color it blue 

function GetColor(Prod_id)
{
           // alert("Prod_id=" + Prod_id)
			NameOfSave="SavedList" + Prod_id
			AnswerSaveForProd =eval("document.aspnetForm." + NameOfSave + ".value")
			
			 StrOldRowColorId = document.getElementById('OldRowColorId').value;
			 
			if (AnswerSaveForProd!="")
				{			
					 
					eval("document.getElementById('Cell1_" + Prod_id + "').style.backgroundColor= 'Deepskyblue'")
					//alert("in") 
				}
			if (AnswerSaveForProd=="")
				{		

					 if (Prod_id != StrOldRowColorId) 
                        {
					         eval("document.getElementById('Cell1_" + Prod_id + "').style.backgroundColor= 'mintcream'")
					         
					    }
					  Get_Mandatory_Product_color()
				}
}


function SelectedRowElementColorOld(Product_name) {
   // alert("SelectedRowElementColorOld");
    EleQList = eval("document.getElementById('PQList" + Product_name + "').value")
    
    if (EleQList != "") {
        EleQListArray = EleQList.split("|");
        arraylength = EleQListArray.length
       
        arraylength = eval(arraylength - 1)
        for (c = 0; c < arraylength; c++) {
            ArrayElecol = EleQListArray[c].valueOf()
            element_color = eval("document.getElementById('" + ArrayElecol + "').style.backgroundColor")
            
            if (element_color != "red") {
                eval("document.getElementById('" + ArrayElecol + "').style.backgroundColor = 'mintcream'")
            }

        } //for loop
    } //if (EleQList != "") 
}
function SelectedRowElementColor(Product_name) {
    //alert("SelectedRowElementColor");
    EleQList = eval("document.getElementById('PQList" + Product_name + "').value")
  
    if (EleQList != "") {
        EleQListArray = EleQList.split("|");
        arraylength = EleQListArray.length
         
        arraylength = eval(arraylength - 1)
        for (c = 0; c < arraylength; c++) {
            ArrayElecol = EleQListArray[c].valueOf()
           
            element_color = eval("document.getElementById('" + ArrayElecol + "').style.backgroundColor")
            if (element_color != "red") {
                eval("document.getElementById('" + ArrayElecol + "').style.backgroundColor = '#99CCFF'")
            }

        }//for loop
    } //if (EleQList != "") 
}
//***************************Get the Mandatory color *******************************
function Get_Mandatory_Product_color()
{
	
    StrOldRowColorId = document.getElementById('OldRowColorId').value;    

	 MP_Array=document.aspnetForm.Array_Mandatory_products.value
   //  alert("MP_Array=" + MP_Array)
	
	if (MP_Array!="") 
		{
							 
						ColorArray = MP_Array.split("|");
						arraylen = ColorArray.length
						 
						arraylen=eval(arraylen-1)
	
							for ( j = 0 ; j < arraylen ; j++ )
								{
								
											MenuOption = ColorArray[j].valueOf()
											//alert("MenuOption=" + MenuOption) 
                                            NameOfSave="SavedList" + MenuOption
			                                AnswerSaveForProd =eval("document.aspnetForm." + NameOfSave + ".value")
											//alert("AnswerSaveForProd=" + AnswerSaveForProd)
									
												if (AnswerSaveForProd=="")
													{
													     if (MenuOption!=StrOldRowColorId)
													     {
														     eval("document.getElementById('Cell1_" + MenuOption + "').style.backgroundColor= 'Yellow'") 
														 }
														 
													}
	
								}//Ending of the for loop
			
		}
}

//*****************************************using Tab key to focus on next element

function MoveToNextProduct() {

  // alert("MoveToNextProduct");
   
   
   strFocusEle_name= document.getElementById('FocusEle_name').value
  
    Product_name = document.getElementById('Select_Product_name').value;
    
    StrProduct_name = 'PQList' + Product_name

    Product_name_List = eval("document.getElementById('" + StrProduct_name + "').value")
  
    Cn=1;
    Q_CheckDisable=false;
    StartPoint="";   
     if (Product_name_List != "")
      {
        
         Product_ListArray = Product_name_List.split("|");
         arraylength = Product_ListArray.length
        // alert("arraylength=" + arraylength)
         arraylength = eval(arraylength - 1)
         for (a = 0; a < arraylength; a++)
         {
             ArrayElement = Product_ListArray[a].valueOf()
         
              if (strFocusEle_name == ArrayElement) 
                    {
                      StartPoint="Y";  
                  
                    }
              if (StartPoint =="Y") 
                    {
                   
                        if (Cn==arraylength) 
                            {
                                    MoveToNextprod_id(Product_name) 
                                    break;
                            }
                            
                             NextElement = Product_ListArray[a + 1].valueOf()
                             
                             if (NextElement!="")
                               {
                                  Q_CheckDisable = eval("document.getElementById('" + NextElement + "').disabled")
                                 
                                }
                             if (Q_CheckDisable==false)
                                {
                                    document.getElementById('Skipattern_NextFocusEle').value = NextElement
                                     
                                    break;
                                } 
                     }  // if (StartPoint =="Y")    
 
                Cn=Cn+1
         }//for loop
     } //end --if (Product_name_List != "")

}
function MoveToNextprod_id(Product_name)
 {
    // alert("MoveToNextprod_id");
    StrProd_id_list = document.getElementById('Prod_id_list').value;
   
     if (StrProd_id_list != "")
      {
         Prod_idArray = StrProd_id_list.split("|");
         arraylength2 = Prod_idArray.length
       
         arraylength2 = eval(arraylength2 - 1)
         for (b = 0; b < arraylength2; b++)
         {
             ArrayElement2 = Prod_idArray[b].valueOf()
           
             if (Product_name == ArrayElement2)
              {
                       
                         NextProd_id = Prod_idArray[b + 1].valueOf()
                        
                         if (NextProd_id == "") 
                         {
                            
                             document.getElementById('Skipattern_NextFocusEle').value = "Done";
                             break;
                         }
                         StrNextProd_list = 'PQList' + NextProd_id

                         NextProd_list = eval("document.getElementById('" + StrNextProd_list + "').value")
                         
                         if (NextProd_list != "")
                          {
                             NextProd_listArray = NextProd_list.split("|");
                             NextProd_list_Ele = NextProd_listArray[0].valueOf()
                             
                             document.getElementById('Skipattern_NextFocusEle').value = NextProd_list_Ele
                             break;
                          }

             }//end if       

         }//end for loop
     }//end if
    
}
//****************************************************************
function QV_NDPHM(Ele_name, Prod_id, Q_no, Ans_Val_High, Ans_Val_Low, Ans_Type)
{
       // alert("QV_NDPHM");

 
    if (Ans_Val_High != "") {
        Ans_Val_High = Number(Ans_Val_High)

    }
    if (Ans_Val_Low != "") {
        Ans_Val_Low = Number(Ans_Val_Low)
    }
  // alert("Ans_Val_High=" + Ans_Val_High);
   //alert("Ans_Val_Low=" + Ans_Val_Low);
     if (Ans_Type == "N")
        {
            //alert("N type")
            if (NumericVal(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) == false) 
                {
                    //ElementOnFocus(Ele_name)
                   //alert("Ele_name=" + Ele_name);
                   document.getElementById('FocusEle_name').value=Ele_name
                    document.getElementById('Question_Validation_NDPHM_Error_status').value = "Y"
                    return false;
                }
           
           
        }
      if (Ans_Type == "D") 
        {
            //alert("D type")
            textBoxValue = eval("document.getElementById('" + Ele_name + "').value")
            if (DatecheckNumber(textBoxValue) == false) {
                //alert("Please enter a valid date for question " + Q_no);
                alert('<%=vPrompts[14]%>' + " " + Q_no)
                document.getElementById('Question_Validation_NDPHM_Error_status').value = "Y"
                return false;
            }
            if (isValidDate(textBoxValue) == false) {
                alert('<%=vPrompts[14]%>' + " " + Q_no)
                document.getElementById('Question_Validation_NDPHM_Error_status').value = "Y"
                return false;
            }
            if (DateHighLowCheck(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) == false) {
           // alert("test")
                document.getElementById('Question_Validation_NDPHM_Error_status').value = "Y"
                return false;
            }
        }
    if (Ans_Type == "P") 
        {
              //  alert("P type")
                if (PriceVal(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) == false)
                {
                   // ElementOnFocus(Ele_name)
                   document.getElementById('FocusEle_name').value=Ele_name
                    document.getElementById('Question_Validation_NDPHM_Error_status').value = "Y"
                    return false;
                }
        }
     if (Ans_Type == "M") 
        {
             if (M_unitVal(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) == false)
                {
                   // ElementOnFocus(Ele_name)
                   document.getElementById('FocusEle_name').value=Ele_name
                    document.getElementById('Question_Validation_NDPHM_Error_status').value = "Y"
                    return false;
                }
        }
    if (Ans_Type == "H") 
        {
            if (H_unitVal(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) == false)
                {
                   // ElementOnFocus(Ele_name)
                   document.getElementById('FocusEle_name').value=Ele_name
                    document.getElementById('Question_Validation_NDPHM_Error_status').value = "Y"
                    return false;
                }
        }

}
//***********************reset product *************************

function ResetProduct(EachProdQList,Prod_id)
 {
     //alert("ResetProduct")
    StrProdNoReplace="";
    ClosePopup()
  // alert("EachProdQList=" + EachProdQList)
  // alert("Prod_id=" + Prod_id)
    ResetList = eval("document.getElementById('" + EachProdQList + "').value")
   // alert("ResetList=" + ResetList);
    //document.getElementById('Validation_Select_Prod_id').value="";      
               //  alert("Inside the qual");
                 if (ResetList != "") 
                 {
                    ResetListArray = ResetList.split("|");
                     arraylength = ResetListArray.length
                     //alert("arraylength=" + arraylength) 
                     arraylength = eval(arraylength - 1)
                     for (h = 0; h < arraylength; h++) 
                     {
                         Arrayval = ResetListArray[h].valueOf()
                       //  alert("Arrayval=" + Arrayval)


                         eval("document.getElementById('" + Arrayval + "').value=''")
                         eval("document.getElementById('" + Arrayval + "').disabled=false")
                         eval("document.getElementById('" + Arrayval + "').style.backgroundColor = 'white'")

                     } //for loop

                 } //if (Any_EleQList != "") 
        
            NameOfSave="SavedList" + Prod_id
		   // alert("NameOfSave=" + NameOfSave)
			eval("document.aspnetForm." + NameOfSave + ".value=''")
			
			// StrHiddenSaveName2 = "SavedAnsBackList" + Prod_id
            // eval("document.getElementById('" + StrHiddenSaveName2 + "').value=''")
                        
		    ProdAnsForNextPage=eval("document.aspnetForm.ProdAnsForNextPage.value")
			
			ProdAnsForNextArray = ProdAnsForNextPage.split("|");
			ProdFirstvalue = ProdAnsForNextArray[0].valueOf()	
			 //alert("ProdFirstvalue=" + ProdFirstvalue)
			//alert("arraylength=" + arraylength) 
					
		    if (Prod_id==ProdFirstvalue)
		    {
		            Streplace=Prod_id + "|"
		            StrProdNoReplace=ProdAnsForNextPage.replace(Streplace,"")
		    }
		    else
		    {
		            Streplace="|" + Prod_id + "|"
		            StrProdNoReplace=ProdAnsForNextPage.replace(Streplace,"|")
		    }				
			// alert("Streplace=" + Streplace) 
			
            
        //alert("StrProdNoReplace=" + StrProdNoReplace)
			  document.aspnetForm.ProdAnsForNextPage.value=StrProdNoReplace	
			//  alert("Checkanswer=" + document.aspnetForm.ProdAnsForNextPage.value)
			  
			     GetColor(Prod_id)
			    
			     Disable_Question_End999('N')
			     
			    document.aspnetForm.CFEnd_SelectedProduct.value="";
			    document.aspnetForm.CallFormEnded.value="";	
			    document.aspnetForm.CFEnd_Q_no.value="";
			    document.getElementById('OldRowColorId').value="";
			    
         return false;
}
/************************ Validation******************************/
/************************ answers for next page******************************/
function SaveProductNextPage()
{
            document.aspnetForm.ShowErrorMessageFlg.value='Y'
            //*********************get the last prod id answers
           // Validation(0, 0, 0, 0, 0)
            if (AnyQuestionAnswered(0) == false) 
            {
                 if (Validation(0,0, 0, 0, 0) == false) 
                 {
                     return false;
                 }
            }
         
              //if (Validation(0, 0, 0, 0, 0) == false) 
            //  {
            //     return false;
            //  }
            
           // alert("SaveProductNextPage") 	
			  InputidsAddAll="";
			  InputAnsBackAddAll="";
			  NumberOfitem=0
			  AnsBackWithTxtAll=""
			  document.getElementById('InputidsAnswersAll').value='';
			  document.getElementById('AnsBackWithTxtAll').value='';
			  Sel_Row_Name=document.getElementById('Select_Product_name').value
             // alert("Sel_Row_Name=" + Sel_Row_Name)
			  StrCallFormEnded=document.aspnetForm.CallFormEnded.value;	
			  
			//********************* Product_Type is flag for business rule 16 ------ collect data for all the products 
		 	Product_Type=document.aspnetForm.Product_Type.value
		 	ProdAnsForNextPage=document.aspnetForm.ProdAnsForNextPage.value 
           // alert("ProdAnsForNextPage=" + ProdAnsForNextPage) 	
            AllProdNames=document.getElementById('AllProdNames').value;	
		   // alert("AllProdNames=" + AllProdNames)  
		  if (StrCallFormEnded=="Y")
		      {
		            AllProdNames="" + Trim(Sel_Row_Name) + "|"
					ProdAnsForNextPage="" + Trim(Sel_Row_Name) + "|"
					document.aspnetForm.ProdAnsForNextPage.value=ProdAnsForNextPage	
		      }	  
		 	
		  if (Product_Type=="Y")
			{
			     ArrayAList = AllProdNames.split("|");      
			}
			else
			{
			    ArrayAList = ProdAnsForNextPage.split("|");   
			}
			
			arraylength = ArrayAList.length
			// alert("arraylength=" + arraylength) 
			arraylength=eval(arraylength-1)
			p=0
			for ( i = 0 ; i < arraylength ; i++ )
				{
								ElementName = ArrayAList[i].valueOf()
								//alert("i=" + i)
								// alert("ElementName=" + ElementName)
						//For each product
								ProdDoneList="SavedList" + ElementName	
								ProdDoneAnswer=eval("document.aspnetForm." + ProdDoneList + ".value")
								// alert("ProdDoneList=" + ProdDoneList)
								// alert("ProdDoneAnswer=" + ProdDoneAnswer)
								    StrHiddenSaveName2 = "SavedAnsBackList" + ElementName
                                    ProdDoneAnsBack=eval("document.getElementById('" + StrHiddenSaveName2 + "').value")
						 
							if (ProdDoneAnswer!="")
								{
										//alert("ProdDoneAnswer=" + ProdDoneAnswer)
										
											InputidsAnswersHasValue =document.getElementById('InputidsAnswersAll').value
										    AnsBackWithTxtHasValue =document.getElementById('AnsBackWithTxtAll').value
											 //alert("InputidsAnswersHasValue=" + InputidsAnswersHasValue)
										
											if (InputidsAnswersHasValue=="")
												{
														InputidsAddAll="" + ProdDoneAnswer + ""
														InputAnsBackAddAll="" + ProdDoneAnsBack + ""
													 
												}
											else
												{
														InputidsAddAll="" + InputidsAnswersHasValue + "|" + ProdDoneAnswer + ""
														InputAnsBackAddAll="" + AnsBackWithTxtHasValue + "|" + ProdDoneAnsBack + ""
													 
												}
										// alert("InputidsAddAll=" + InputidsAddAll)	
									//InputidsAnswersAll =eval("document.aspnetForm.InputidsAnswersAll.value='" + InputidsAddAll + "'")
									 
									document.getElementById('InputidsAnswersAll').value = InputidsAddAll
									document.getElementById('AnsBackWithTxtAll').value = InputAnsBackAddAll
									NumberOfitem=NumberOfitem + 1
								 
									 
								}
 
				}
				
                // alert("NumberOfitem=" + NumberOfitem) 
            Answers_Old_Prod_CF_Store_q=document.aspnetForm.Answers_Old_Prod_CF_Store_q.value

        //  alert("Answers_Old_Prod_CF_Store_q=" + Answers_Old_Prod_CF_Store_q) 
           //Store Questions were answered by another call form  
             if (Answers_Old_Prod_CF_Store_q!="")
              {
	              NumberOfitem=NumberOfitem + 1   
              }
            
 
			//  alert("NumberOfitem=" + NumberOfitem)  
			 if (NumberOfitem==0)
                    {
	                    //alert("Minimum product requirements are not met for this store. Please review paperwork and call form data to ensure all products found in store are entered before you can proceed.")
	                    alert('<%=vPrompts[110]%>')
	                    return false;
                    }
               if (StrCallFormEnded=="")
				    {  
                              if (Must_Be_Answered_Prod()==false)
		                        {
			                        return false;
		                        }	 
                		         
		                     Product_Required=document.aspnetForm.Product_Required.value
                		        //  alert("Product_Required=" + Product_Required)  
                             if (Product_Required > NumberOfitem)
                                {
                                    //alert("Minimum product requirements are not met for this store. Please review paperwork and call form data to ensure all products found in store are entered before you can proceed.")
                                    alert('<%=vPrompts[6]%>')
                                    
                                    return false;
                                }
                                //***** rule 16 answer all the products
                             if (Product_Type=="Y")
			                    {
                                      if (ProductsNotAnswered()==false)
							             {
        							            
								                return false;
							             }
							    }
                    }
			InputidsAnswersAll=document.getElementById('InputidsAnswersAll').value
			// alert("InputidsAnswerstest=" + InputidsAnswersAll)  
			 
			 srtInputidsAnswersAll=InputidsAnswersAll.replace(/Prod_/gi, "")
			 // alert("srtInputidsAnswersAll=" + srtInputidsAnswersAll)  
			 
			 document.getElementById('InputidsAnswersAll').value=srtInputidsAnswersAll
			 
			 ProdAnsForNextPage=eval("document.aspnetForm.ProdAnsForNextPage.value")
             // alert("ProdAnsForNextPage=" + ProdAnsForNextPage) 
			 
			 var ok=confirm('<%=vPrompts[67]%>' + " \n " + '<%=vPrompts[68]%>' + " \n " + '<%=vPrompts[69]%>')
				if (ok)
					{
					     document.aspnetForm.ctl00$ContentPlaceHolder1$CallFormDone.disabled=true;
                        document.aspnetForm.ctl00$ContentPlaceHolder1$CallFormDone.className='ButtonDisabledJava';  
					    WaitSign.innerText="Please Wait......";
						document.aspnetForm.action  = "CFProductCallFormAnswer.aspx";
						document.aspnetForm.submit()
						return false;	
					}
				else
					{
						//alert("Please continue with the Internet Call Form.")
						//alert('<%=vPrompts[7]%>')
						 
						document.aspnetForm.ctl00$ContentPlaceHolder1$CallFormDone.disabled=false;
                        document.aspnetForm.ctl00$ContentPlaceHolder1$CallFormDone.className='Button'; 
						return false;
					}	
		   //document.aspnetForm.action  = "CFProductCallFormAnswer.aspx";
	       // document.aspnetForm.submit()
	       // return false;		 
	 
}
//******************************************Harcode the list of products and must be answered
function Must_Be_Answered_Prod()
{
 
								ListOf_Prod=document.aspnetForm.Array_Mandatory_products.value;
							   // alert ("ListOf_Prod=" + ListOf_Prod);
	
								Array_Of_Prod = ListOf_Prod.split("|");
								arrayProdlen = Array_Of_Prod.length
								 //alert("arraylength=" + arraylength) 
								arrayProdlen=eval(arrayProdlen-1)
								
								for ( g = 0 ; g < arrayProdlen ; g++ )
									{
												Array_Element = Array_Of_Prod[g].valueOf()
												 //alert("Array_Element=" + Array_Element)
										
												Answered_list_Str="SavedList" + Array_Element		
												 //alert("Answered_list_Str=" + Answered_list_Str)
												Prod_Ans_Check=eval("document.aspnetForm." + Answered_list_Str + ".value")
										        // alert("Prod_Ans_Check=" + Prod_Ans_Check)
												if (Prod_Ans_Check=="")
													{
															//alert ("The Product " + Array_Element + " is a Mandatory for this Job, wave, and task.");
															 alert('<%=vPrompts[109]%>')
															//alert ('<%=vPrompts[55]%>' + Array_Element + " " + '<%=vPrompts[56]%>')
																//document.aspnetForm.ctl00$ContentPlaceHolder1$SelectedProduct.options[Array_Element].selected = true; 
															//document.aspnetForm.ctl00$ContentPlaceHolder1$SelectedProduct.value=Array_Element
															return false;
													}
//												else
//													{
//														if (DropDown_Prod==Array_Element)
//															{
//															          alert("equal")
//																	//break;
//															}
//														
//													}
									}	
									//document.aspnetForm.SelectedProduct.value=ItemNumber
//									   alert("out")
			 
}
//*****************************
//********************************* Products that are not answered -- busines rule 16 

function ProductsNotAnswered()
{
           // alert("ProductsNotAnswered")
			AllProdNames=document.aspnetForm.AllProdNames.value
			if (AllProdNames!="")
				{	
								ArrayAList = AllProdNames.split("|");
								arraylength = ArrayAList.length
								//alert("arraylength=" + arraylength) 
								arraylength=eval(arraylength-1)
								p=0
								for ( u= 0 ; u < arraylength ; u++ )
									{
											ElementName = ArrayAList[u].valueOf()
											//alert("i=" + i)
											//alert("ElementName=" + ElementName)
											ProdDoneList="SavedList" + ElementName	
											ProdDoneAnswer=eval("document.aspnetForm." + ProdDoneList + ".value")
											//alert("ProdDoneAnswer=" + ProdDoneAnswer)
											if (ProdDoneAnswer=="")
											{
												//alert("Please select " + ElementName + " from the drop menu and answer all the corresponding questions.")
												//alert("Please answer all the corresponding questions for " + ElementName)
												//alert("All products have not been answered. You must answer for all products.")
												alert('<%=vPrompts[8]%>')
												return false;
											}

									}//Ending of For loop
									
				}//Ending of AllProdNames!=""	
}
//***************************** Comparison
//********************* Compare the Question enterted value for all questions
function Compare_Q_Val_Submit(ElementName)
{    
                
            
              ShowErrorMessageCnt=document.aspnetForm.ShowErrorMessageCnt.value
            // alert("ShowErrorMessageCnt=" + ShowErrorMessageCnt)
             ShowErrorMessageFlg=document.aspnetForm.ShowErrorMessageFlg.value
           //  alert("ShowErrorMessageFlg=" + ShowErrorMessageFlg)
             
               IsDisabled="";
              Compare_q_status_flag=document.aspnetForm.Compare_q_status_flag.value;
            // alert("Compare_q_status_flag=" + Compare_q_status_flag)
              if (Compare_q_status_flag=="Y")
              {
                         //alert("ElementName=" + ElementName)
                         Q_no=ElementName.substring(6,9)
                        // alert("Q_no=" + Q_no)
                         StrProd_id=ElementName.substring(10,ElementName.length)
                        // alert("StrProd_id=" + StrProd_id)
                        //Com_q_009
                         StrCompName="Com_q_id_" + Q_no
                         
                          var ObjExists=eval("document.getElementById('" + StrCompName + "')")
                          Final_selected_Val=""
                          Final_Compare_val=""
                         // alert("ObjExists=" + ObjExists) 
                         //return false;
                        if (ObjExists!=null)
                        {
                              StrCompList=eval("document.aspnetForm." + StrCompName + ".value")
                              // alert("StrCompList=" + StrCompList) 
                             
                              ArrayList= StrCompList.split(",");
	                         ArrayListlen= ArrayList.length;
            	             
	                         for (V= 0 ; V< ArrayListlen ; V++ )
	                            {
	                                         optr_q_no= ArrayList[V].valueOf()
				                             // alert("optr_q_no=" + optr_q_no) 
                        				       
				                             Array_optr= optr_q_no.split("_");
				                             symbol= Array_optr[0].valueOf()
				                             Comp_Q_no= Array_optr[1].valueOf()
				                             Comp_ans_type= Array_optr[2].valueOf()
				                            // alert("symbol=" + symbol) 
				                            // alert("Comp_Q_no=" + Comp_Q_no) 
				                            // alert("ans_type=" + Comp_ans_type) 
				                           // alert("Comp_ans_type=" + Comp_ans_type) 
            				                 
                        				       
                                             if (Comp_ans_type=="N")
                                             {
                                                            //picked question
                                                            //selected_name="N" + Comp_Q_no + "" + StrProd_id + ""; 
                                                            selected_value=eval("document.aspnetForm." + ElementName + ".value")
                                                           // alert("selected_value=" + selected_value) 
                                                            
                                                            //compared question
                                                            Compare_name="Prod_N" + Comp_Q_no + "0" + StrProd_id + "";
                                                          //  alert("Compare_name=" + Compare_name) 
                                                            Compare_value=eval("document.aspnetForm." + Compare_name + ".value")
                                                          //  alert("Compare_value=" + Compare_value)  
                                                             IsDisabled = eval("document.getElementById('" + Compare_name + "').disabled")
						                                   // alert("Q_CheckDisable_Vad=" + Q_CheckDisable)
                                                            if (IsDisabled == true)
                                                             {
                                                                Final_selected_Val="";
                                                             }
                                                             else
                                                             {
                                                                Final_selected_Val=selected_value
                                                                Final_Compare_val=Compare_value
                                                             }     
                                             }
                                            
                                               
				                              if (Comp_ans_type=="D")
                                             {
                                                             //picked question
                                                            
                                                           selected_value=eval("document.aspnetForm." + ElementName + ".value")
                                                          // alert("selected_valueD=" + selected_value) 
                                                            
                                                            //compared question
                                                            
                                                             Compare_name="Prod_D" + Comp_Q_no + "0" + StrProd_id + "";
                                                            // alert("Compare_nameD=" + Compare_name) 
                                                            Compare_value=eval("document.aspnetForm." + Compare_name + ".value")
                                                              
                                                            DateCompareQuestion(selected_value,Compare_value)
                                                              
                                             }
                                             
                                               
                                              if (Comp_ans_type=="P")
                                             {
                                                                selected_val_Cen="";
                                                            
                                            	                ElementId=eval("document.aspnetForm." + ElementName + ".id")
                                                               // alert("ElementId=" + ElementId)
                                                         
                                                                //picked question
                                                                selected_val=eval("document.aspnetForm." + ElementName + ".value")
                                                               // alert("selected_val=" + selected_val) 
                                                              
                                                                 if ((selected_val.indexOf(".")) >= 0) 
                                                                        {
                                                                            selectedValArray = selected_val.split(".");
                                                                            selected_Doll_val = selectedValArray[0].valueOf()
                                                                            selected_Cent_val = selectedValArray[1].valueOf()
                                                                        }
                                                                   else
                                                                        {
                                                                            
                                                                            selected_Doll_val = selected_val
                                                                            selected_Cent_val = "00"
                                                                        }
                                                                        
                                                                  if (Trim(selected_Cent_val)!="")
                                                                        {
                                                                               Selected_len=selected_Cent_val.length;
                                                                              //  alert("Selected_len=" + Selected_len)
                                                                               if (Selected_len==1)
                                                                               {
                                                                                    selected_Cent_val=selected_Cent_val + "0"
                                                                               } 
                                                                        }
                                                                        
                                                                   Final_selected_Val=Number(selected_Doll_val) + "" + selected_Cent_val 
                                                                  // alert("Final_selected_Val=" + Final_selected_Val)    
                                                                    
                                                                   
                                                            //compared question
                                                              Compare_name="Prod_P" + Comp_Q_no + "0" + StrProd_id + "";
                                                              Compare_val=eval("document.aspnetForm." + Compare_name + ".value")
                                                              //alert("Compare_val=" + Compare_val)  
                                                              
                                                                if ((Compare_val.indexOf(".")) >= 0) 
                                                                        {
                                                                            CompareValArray = Compare_val.split(".");
                                                                            Compare_Doll_val = CompareValArray[0].valueOf()
                                                                            Compare_Cent_val = CompareValArray[1].valueOf()
                                                                        }
                                                                   else
                                                                        {
                                                                            
                                                                            Compare_Doll_val = Compare_val
                                                                            Compare_Cent_val = "00"
                                                                        }
                                                                        
                                                                  if (Trim(Compare_Cent_val)!="")
                                                                        {
                                                                               Compare_len=Compare_Cent_val.length;
                                                                            // alert("Compare_len=" + Compare_len)
                                                                               if (Compare_len==1)
                                                                               {
                                                                                    Compare_Cent_val=Compare_Cent_val + "0"
                                                                               } 
                                                                        }
                                                      
                                                                    Final_Compare_val=Number(Compare_Doll_val) + "" +  Compare_Cent_val 
                                                                  //  alert("P_Final_Compare_val=" + Final_Compare_val)  
 
                                                                 IsDisabled = eval("document.getElementById('" + Compare_name + "').disabled")
						                                       // alert("Q_CheckDisable_Vad=" + Q_CheckDisable)
                                                                if (IsDisabled == true)
                                                                 {
                                                                    Final_selected_Val="";
                                                                 }
                                                            
                                                            
                                                            //alert("P_Final_selected_Val=" + Final_selected_Val)  
                                                            //alert("P_Final_Compare_val=" + Final_Compare_val)  
                                                              
                                                                
                                             }
//                                              if (Comp_ans_type=="M")
//                                             {
//                                                           
//                                                               //picked question
//                                                            selected_name="ctl00$ContentPlaceHolder1$txt_Fee" + Q_no + "";
//                                                            selected_val_Fee=eval("document.aspnetForm." + selected_name + ".value")
//                                                              //alert("selected_val_Fee=" + selected_val_Fee) 
//                                                               
//                                                            selected_name="ctl00$ContentPlaceHolder1$txt_Inc" + Q_no + "";
//                                                            selected_val_Inc=eval("document.aspnetForm." + selected_name + ".value")
//                                                             // alert("selected_val_Inc=" + selected_val_Inc)   
//                                                               
//                                                            //compared question
//                                                             Compare_name="ctl00$ContentPlaceHolder1$txt_Fee" + Comp_Q_no + ""; 
//                                                             Compare_val_Fee=eval("document.aspnetForm." + Compare_name + ".value")
//                                                              //alert("Compare_val_Dol=" + Compare_val_Dol)  
//                                                              
//                                                            
//                                                             Compare_name="ctl00$ContentPlaceHolder1$txt_Inc" + Comp_Q_no + ""; 
//                                                             Compare_val_Inc=eval("document.aspnetForm." + Compare_name + ".value")
//                                                            // alert("Compare_val_Cen=" + Compare_val_Cen) 
//                                                               
//                                                              if (Trim(selected_val_Cen)!="")
//                                                              {
//                                                                       Selected_len=selected_val_Inc.length;
//                                                                       Compare_len=Compare_val_Inc.length;
//                                                                       // alert("Selected_len=" + Selected_len)
//                                                                       // alert("Compare_len=" + Compare_len)
//                                                                       if (Selected_len==1)
//                                                                       {
//                                                                            selected_val_Inc="0" + selected_val_Inc
//                                                                       }
//                                                                       if (Compare_len==1)
//                                                                       {
//                                                                            Compare_val_Inc="0" + Compare_val_Inc
//                                                                       }
//                                                                       
//                                                                      Final_selected_Val=Number(selected_val_Fee) + "" + selected_val_Inc 
//                                                                      Final_Compare_val=Number(Compare_val_Fee) + "" +  Compare_val_Inc 
//                                                              }  
//                                             }
//                                              if (Comp_ans_type=="H")
//                                             {
//                                                            EachElementobj="ctl00$ContentPlaceHolder1$txt_Hou" + Comp_Q_no + "";
//                                                            test2=eval("document.aspnetForm." + EachElementobj + ".value")
//                                                              //alert("test2=" + test2)  
//                                                            EachElementobj="ctl00$ContentPlaceHolder1$txt_Min" + Comp_Q_no + "";
//                                                            test2=eval("document.aspnetForm." + EachElementobj + ".value")
//                                                              //alert("test2=" + test2)  
//                                             }
                                           
                                            // alert("Final_selected_Val=" + Final_selected_Val)  
                                           //  alert("Final_Compare_val=" + Final_Compare_val) 
                                                            //vPrompts[39]="The question";//0
                                                           // vPrompts[41]="value has to be bigger or equal to";//2
                                                            //vPrompts[42]="value has to be less or equal to";//3
                                                            //vPrompts[81] = "value has to be equal to";//2
                                         
                                          if (Trim(Final_selected_Val)!="")
                                           {                  
                                                    
                                                           if (symbol=="E")  
                                                           {
                                                                     if(Final_selected_Val!=Final_Compare_val)
                                                                       {
                                                                            document.aspnetForm.ShowErrorMessageCnt.value=1
                                                                            if (ShowErrorMessageFlg=="Y")
                                                                                {
                                                                                    alert('<%=vPrompts[116]%>' + " : " + Q_no + " . " + '<%=vPrompts[111]%>' + " : " + Comp_Q_no);
                                                                                    //alert("" + Q_no +"Not equal!") 
                                                                                }
                                                                                else
                                                                                {
                                                                                    document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                                                                }
                                                                            return false;
                                                                       }                        
                                                           }
                                                            if (symbol=="B")  
                                                           {
                                                                    //(Final_selected_Val>Final_Compare_val)
                                                                    ////if((Final_selected_Val>Final_Compare_val)==false)
                                                                    teststring=Final_selected_Val>Final_Compare_val
                                                                    //alert("teststring=" + teststring)  
                                                                       if((Number(Final_selected_Val)<Number(Final_Compare_val))||(Number(Final_selected_Val)==Number(Final_Compare_val)))  
                                                                       {
                                                                            document.aspnetForm.ShowErrorMessageCnt.value=1
                                                                            if (ShowErrorMessageFlg=="Y")
                                                                                {
                                                                                 alert('<%=vPrompts[116]%>' + " : " + Q_no + " . " + '<%=vPrompts[114]%>' + " : " + Comp_Q_no);
                                                                                //alert("Bigger!") 
                                                                                }
                                                                                else
                                                                                {
                                                                                    document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                                                                }
                                                                             return false;
                                                                       }                        
                                                           }
                                                            if (symbol=="L")  
                                                           {
                                                                     //if(Final_selected_Val>Final_Compare_val)
                                                                    // if((Final_selected_Val<Final_Compare_val)==false)
                                                                    if((Number(Final_selected_Val)>Number(Final_Compare_val))||(Number(Final_selected_Val)==Number(Final_Compare_val)))  
                                                                       {
                                                                            document.aspnetForm.ShowErrorMessageCnt.value=1
                                                                             if (ShowErrorMessageFlg=="Y")
                                                                                 {
                                                                                        alert('<%=vPrompts[116]%>' + " : " + Q_no + " . " + '<%=vPrompts[115]%>' + " : " + Comp_Q_no);
                                                                                        // alert("Less!") 
                                                                                 }
                                                                                else
                                                                                {
                                                                                    document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                                                                }
                                                                             return false;
                                                                       }                        
                                                           }
                                                            if (symbol=="LE")  
                                                           {
                                                                       // if(x<=5==false) 
                                                                     // if((Final_selected_Val<=Final_Compare_val))
                                                                    //if((Final_selected_Val<=Final_Compare_val)==false)
                                                                     if((Number(Final_selected_Val)>Number(Final_Compare_val)))
                                                                       {
                                                                                 document.aspnetForm.ShowErrorMessageCnt.value=1
                                                                                if (ShowErrorMessageFlg=="Y")
                                                                                    {
                                                                                        //alert("less than equal!") 
                                                                                        document.aspnetForm.ShowErrorMessageCnt.value=1
                                                                                        alert('<%=vPrompts[116]%>' + " : " + Q_no + " . " + '<%=vPrompts[112]%>' + " : " + Comp_Q_no);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                                                                    }
                                                                             return false;
                                                                       }                        
                                                           }
                                                           if (symbol=="BE")  
                                                           {
                                                                        //alert("insideFinal_selected_Val=" + Final_selected_Val)  
                                                                       // alert("insideFinal_Compare_val=" + Final_Compare_val) 
                                                                     //if((Final_selected_Val>=Final_Compare_val)==false)
                                                                     if((Number(Final_selected_Val)<Number(Final_Compare_val)))
                                                                       {
                                                                              if (ShowErrorMessageFlg=="Y")
                                                                                    {
                                                                                        //alert("Bigger than equal!") 
                                                                                        document.aspnetForm.ShowErrorMessageCnt.value=1
                                                                                        alert('<%=vPrompts[116]%>' + " : " + Q_no + " . " + '<%=vPrompts[113]%>' + " : " + Comp_Q_no);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                                                                    }   
                                                                             return false;
                                                                       }   
                                                                                     
                                                           } 
                                            } //if (Trim(Final_selected_Val)!="")
				               }//for loop
            				   
                        }//ObjExists
           }//if (Compare_q_status_flag=="Y") 
          
            
}
// **************************** Question type N
function NumericVal(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) 
{
        //alert("Ele_name=" + Ele_name)
  
        //alert("Q_no=" + Q_no)
    
    Ilang_id = document.getElementById('ILang_Id').value
    textBoxValue = eval("document.getElementById('" + Ele_name + "').value")
    if (textBoxValue != "") 
    {
                                textBoxValue2 = Number(textBoxValue)
                                //alert("textBoxValue2=" + textBoxValue2)
                                if (isNaN(textBoxValue) == true) {
                                    //alert("The question " + Q_no + " has to be numeric.")
                                    alert('<%=vPrompts[57]%> ' + Q_no + " " + '<%=vPrompts[15]%>')
                                    return false;
                                }
                                if (Ilang_id == "10") {
                                    if (Trim(textBoxValue2) == "NaN") {
                                        alert('<%=vPrompts[71]%> ' + Q_no + "")
                                        return false;
                                    }

                                    //Decimal Points
                                    Decimal_Point = eval("document.getElementById('Decimal_Point').value")
                                    //alert("Decimal_Point=" + Decimal_Point)

                                    DotLen = textBoxValue.indexOf(".") + 1
                                    //alert("DotLen=" + DotLen)
                                    BoxLen = textBoxValue.length
                                    //alert("BoxLen=" + BoxLen)

                                    if (DotLen != "0") {
                                        FinalLen = BoxLen - DotLen
                                        if (FinalLen > Decimal_Point) {
                                            alert('<%=vPrompts[71]%> ' + Q_no + "")
                                            return false;
                                        }
                                    }
                                }
                                else {
                                    if ((textBoxValue.indexOf(".")) >= 0) {
                                        alert('<%=vPrompts[57]%> ' + Q_no + " " + '<%=vPrompts[16]%> ')
                                        return false;
                                    }
                                }


                                HighValue = Ans_Val_High
                               // alert("HighValue=" + HighValue)
                                LowValue = Ans_Val_Low
                                //alert("LowValue=" + LowValue)
                                // return false; 

                                if ((eval(LowValue) > eval(textBoxValue2)) && (LowValue != "")) {
                                    //alert("test1")
                                    //alert("The question " + Q_no + " must be a whole number.")
                                    alert('<%=vPrompts[57]%> ' + Q_no + ', <%=vPrompts[26]%> ' + LowValue + "")
                                    return false;
                                }

                                if ((eval(HighValue) < eval(textBoxValue2)) && (HighValue != "")) {
                                    //alert("The question "+ Q_no +" value has to less or equal to " + HighValue);
                                    alert('<%=vPrompts[57]%> ' + Q_no + ', <%=vPrompts[18]%> ' + HighValue + "")
                                    return false;
                                }

         } //if (textBoxValue != "") 
}
// **************************** Question type P

function PriceVal(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) 
{

    Mask_high_low_val=document.aspnetForm.Mask_high_low_val.value 
   // alert("Mask_high_low_val=" + Mask_high_low_val)	

    textBoxValue = eval("document.getElementById('" + Ele_name + "').value")
  //  alert("textBoxValue=" + textBoxValue)
   // eval("document.getElementById('Decimal_Point').value")
    Price_Rule = eval("document.getElementById('Decimal_Point').value")
    // alert("Price_Rule=" + Price_Rule)	

    //alert("Pos=" + Pos)
    HighValue = Ans_Val_High
    //alert("HighValue=" + HighValue)
    
    LowValue = Ans_Val_Low
    //alert("LowValue=" + LowValue)

    if (textBoxValue != "")
         {

                   if (isNaN(textBoxValue) == true) 
                    {
                        //alert("The question " + Q_no + ",Dollar(s) value has to be numeric.")
                        //alert('<%=vPrompts[57]%> ' + Q_no + ", " + '<%=vPrompts[19]%> ')
                        alert('<%=vPrompts[71]%> ' + Q_no + "")
                        return false;
                    }

                    if (textBoxValue < 0) 
                    {
                        //alert("The question " + Q_no + " value can not be less than zero")
                        alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[70]%> ')
                        return false;
                    }
                    //textBoxValue=Number(textBoxValue)

                    //Make sure Decimal_Point rule matches with price

                    if ((textBoxValue.indexOf(".")) >= 0) 
                    {
                        EnterValArray = textBoxValue.split(".");
                        Dollar_val = EnterValArray[0].valueOf()
                        Cent_val = EnterValArray[1].valueOf()
                        Dollar_val = Number(Dollar_val)
                        cent_Len = Cent_val.length
                      // alert("Dollar_val=" + Dollar_val)
                     // alert("Cent_val=" + Cent_val)
                        if (cent_Len > Price_Rule)
                         {
                            alert('<%=vPrompts[71]%> ' + Q_no + "")
                            return false;
                         }
                        if ((Cent_val) > 99) 
                          {
                            //alert("The question " + Q_no + ", Cent(s) value can not be bigger than 99 cent.")
                              alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[21]%> ')
                            return false;
                           }
                    }
                    else 
                    {
                        Dollar_val = Number(textBoxValue);
                        Cent_val ="0"
                    }
                
            //alert("Price_Rule=" + Price_Rule)
            //alert("FirstBox=" + FirstBox)
                if (Price_Rule == "0") 
                  {
                                //alert("LowValue=" + LowValue)
                                //alert("HighValue=" + HighValue)		
                                FinalValue = textBoxValue

                                if ((eval(LowValue) > eval(FinalValue)) && (LowValue != "")) 
                                {
                                         if (Mask_high_low_val=="Y")
									        {
									                   //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
										            alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[117]%> ')
									        }
									        else
									        {
                                                    //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
                                                    alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[26]%> ' + LowValue + "")
                                            }
                                    return false;
                                }
                                if ((eval(HighValue) < eval(FinalValue)) && (HighValue != "")) 
                                {
                                      if (Mask_high_low_val=="Y")
									        {
									                   //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
										            alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[117]%> ')
									        }
									        else
									        {
                                                    //alert("The question "+ Q_no +", value has to less or equal to " + HighValue);
                                                    alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[27]%> ' + HighValue + "")
                                            }
                                    return false;
                                }
                }
                else
                {

                             //FinalValue = textBoxValue
                             FinalValue=Dollar_val + "." + Cent_val  
                            //alert("secondBox=" + secondBox);
                            //alert("FirstBox=" + FirstBox);
                        // alert("LowValue=" + LowValue);
                       //    alert("HighValue=" + HighValue);
                      //    alert("PriceFinalValue=" + FinalValue);
                      //   strval= eval(FinalValue)
                       //     alert("strvalEval=" + strval);
                            
                               
                                //alert("LowValue=" + LowValue);
                                //alert("PriceFinalValue=" + FinalValue);

                                if ((eval(LowValue) > eval(FinalValue)) && (LowValue != "")) 
                                {
                                          if (Mask_high_low_val=="Y")
									        {
									                   //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
										            alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[117]%> ')
									        }
									        else
									        {
                                                    //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);

                                                    alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[26]%>' + " " + LowValue + "")
                                            }
                                    return false;
                                }
                              //  alert("1 check");
                                if ((eval(HighValue) < eval(FinalValue)) && (HighValue != "")) 
                                {
                                          if (Mask_high_low_val=="Y")
									        {
									                   //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
										            alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[117]%> ')
									        }
									        else
									        {
                                                    //alert("The question "+ Q_no +", value has to less or equal to " + HighValue);
                                                    alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[27]%>' + " " + HighValue + "")
                                             }
                                    return false;
                                }
                                // alert("2 check");
                }//if (Price_Rule == "0") 
      }// if (textBoxValue != "")
        
}

//***************************************** Validation check measurement  

function M_unitVal(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) 
{
    
        
        
     ShowErrorMessageCnt=document.aspnetForm.ShowErrorMessageCnt.value
    // alert("ShowErrorMessageCnt=" + ShowErrorMessageCnt)
     ShowErrorMessageFlg=document.aspnetForm.ShowErrorMessageFlg.value
     //alert("ShowErrorMessageFlg=" + ShowErrorMessageFlg)

    Mask_high_low_val=document.aspnetForm.Mask_high_low_val.value 
    //alert("Mask_high_low_val=" + Mask_high_low_val)	
    
    Inch_Max_Val=document.aspnetForm.Inch_Max_Val.value 
   // alert("Inch_Max_Val=" + Inch_Max_Val)	

    textBoxValue = eval("document.getElementById('" + Ele_name + "').value")
  //  alert("textBoxValue=" + textBoxValue)
   
     MeasurementDesc=document.aspnetForm.MeasurementDesc.value 
   // alert("MeasurementDesc=" + MeasurementDesc)	
     var HighValue="";
     var LowValue="";
     
    //alert("Pos=" + Pos)
     HighValue = Ans_Val_High.toString()
   //alert("HighValue=" + HighValue)
    
    LowValue = Ans_Val_Low.toString()
   //alert("LowValue=" + LowValue)

   if (textBoxValue != "")
   {
   
            if (textBoxValue.indexOf(',') > -1) 
            {            
                        MVArray=MeasurementDesc.split(","); 
                        Feet_DescV=MVArray[0].valueOf() 
                        Inc_DescV=MVArray[1].valueOf() 
                     
                //get responses
                         ResponseFeet="" 
                         ResponseInc="" 
                         MH_Ele_val=textBoxValue.replace(Feet_DescV,"") 
                         MH_Ele_val=MH_Ele_val.replace(Inc_DescV,"")  
                         MHResArray=MH_Ele_val.split(",");
                         ResponseFeet=MHResArray[0].valueOf() 
                         ResponseInc=MHResArray[1].valueOf()  
                
                         ResponseFeet=Number(ResponseFeet) 
                         ResponseInc=Number(ResponseInc) 
                        // alert("ResponseFeet=" + ResponseFeet)
                       //  alert("ResponseInc=" + ResponseInc)
                         FinalEnterVal=ResponseFeet + "." +  ResponseInc
                         
                          StrInch_Max_Val=Inch_Max_Val-1
                         //  alert("StrInch_Max_Val=" + StrInch_Max_Val)
						if (ResponseInc>StrInch_Max_Val)
								{
								    //alert("Error")
								    
								    document.aspnetForm.MH_Unit_Error_Flag.value='1' 
								    document.aspnetForm.ShowErrorMessageCnt.value=1
								     if (ShowErrorMessageFlg=="Y")
                                      {                                        
									        //alert("The question " + Q_no + ", Inch/Inches value can not be bigger than 11.")
									        alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[30]%>' + " " + StrInch_Max_Val + "")
									  }
                                     else
                                      {
                                        document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                      }       
									        
									return false;
								}
						if (ResponseInc<0)
								{
								    document.aspnetForm.MH_Unit_Error_Flag.value='1' 
								    document.aspnetForm.ShowErrorMessageCnt.value=1
								     if (ShowErrorMessageFlg=="Y")
                                      { 
									        //alert("The question " + Q_no + ", Inch/Inches value can not be less than 0.")
									        alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[31]%>')
        							  }
                                     else
                                      {
                                        document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                      }    	
									return false;
								}
								// alert("here"); 
								 
					//********************** High and low values
					               var Pos=LowValue.indexOf(".",0) 
					             //  alert("Pos=" + Pos)
					               if (Pos>0)
					                {
					                    LowValueFeet=LowValue.substring(0, Pos);
					                    //alert("LowValueFeet=" + LowValueFeet); 
					                    Pos2=length.LowValue
					                    LowValueInc=LowValue.substring(Pos, Pos2);
					                    LowValueInc=LowValueInc*Number(Inch_Max_Val)
					                    //alert("LowValueMin=" + LowValueMin);
					                    LowValueInc=Math.round(LowValueInc,2)
					                 }
					                 else
					                 {
					                    LowValueFeet=LowValue
					                    LowValueInc=0
					                 }
					                DisplayLowVal=LowValueFeet + "." + LowValueInc
					                 // alert("DisplayLowVal=" + DisplayLowVal);  
									
					                Pos=HighValue.indexOf(".")
					               // alert("Pos=" + Pos);
					                if (Pos>0)
					                {
					                        HighValueFeet=HighValue.substring(0, Pos);
					                       // alert("HighValueFeet=" + HighValueFeet);
					                        Pos2=length.HighValue
					                        HighValueInc=HighValue.substring(Pos, Pos2);
					                        HighValueInc=HighValueInc*Number(Inch_Max_Val)
					                        // alert("HighValueMin=" + HighValueMin);
					                        HighValueInc=Math.round(HighValueInc,2)
					                 }
					                 else
					                 {
					                    HighValueFeet=HighValue
					                    HighValueInc=0   
                                     }  
                                      DisplayHighVal=HighValueFeet + "." + HighValueInc   
                                      //alert("DisplayHighVal=" + DisplayHighVal); 
								
								   if ((eval(DisplayLowVal) > eval(FinalEnterVal)) && (DisplayLowVal != "")) 
                                    {
                                    
                                         document.aspnetForm.ShowErrorMessageCnt.value=1
                                         if (ShowErrorMessageFlg=="Y")
                                            { 
                                      
                                                  if (Mask_high_low_val=="Y")
									                {
        									                
									                           //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
										                    alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[117]%>')
									                }
									                else
									                {
                                                            //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
                                                            
                                                           // alert('The question ' + Q_no + " " + 'value has to be bigger or equal to ' + " " + DisplayLowVal + "")
                                                   	        //alert('<%=vPrompts[57]%> ' + " " + Q_no + ", " + 'value has to be bigger or equal to ' + " " + LowValueFeet + " " + 'Feet(s)' + " and " + LowValueInc + " " + 'Inch/Inches' + ".");
                                                   	        alert('<%=vPrompts[57]%>' + " " + Q_no + ": " + '<%=vPrompts[36]%>' + " " + LowValueFeet + " " + '<%=vPrompts[96]%>' + " and " + LowValueInc + " " + '<%=vPrompts[97]%>' + ".");
                                                           	
                                                    }
                                            }
                                          else
                                           {
                                            document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                           }         
                                    document.aspnetForm.MH_Unit_Error_Flag.value='1' 
                                    return false;
                                }
                              //  alert("1 check");
                                if ((eval(DisplayHighVal) < eval(FinalEnterVal)) && (DisplayHighVal != "")) 
                                {
                                
                                        document.aspnetForm.ShowErrorMessageCnt.value=1
                                        if (ShowErrorMessageFlg=="Y")
                                            { 
                                                  if (Mask_high_low_val=="Y")
									                {
									                           //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
										                    alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[117]%>')
									                }
									                else
									                {
                                                            //alert("The question "+ Q_no +", value has to less or equal to " + HighValue);
                                                           // alert('The question ' + Q_no + " " + 'value has to be less or equal to ' + " " + DisplayHighVal + "")
                                                           //	alert('<%=vPrompts[57]%> ' + " " + Q_no + ", " + 'value has to be less or equal to ' + " " + HighValueFeet + " " + 'Feet(s)' + " and " + HighValueInc + " " + 'Inch/Inches' + ".");
                                                           alert('<%=vPrompts[57]%>' + " " + Q_no + ": " + '<%=vPrompts[37]%>' + " " + HighValueFeet + " " + '<%=vPrompts[96]%>' + " and " + HighValueInc + " " + '<%=vPrompts[97]%>' + ".");		
                                                     }
                                           }
                                          else
                                           {
                                            document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                           }   
                                    document.aspnetForm.MH_Unit_Error_Flag.value='1' 
                                    return false;
                                }
                                
                                
                }//if (textBoxValue.indexOf(',') > -1) 
                else
                {
                
                                   
                                    document.aspnetForm.ShowErrorMessageCnt.value=1
                                    if (ShowErrorMessageFlg=="Y")
                                            { 
                                            
									            //alert("The question " + Q_no + ", Inch/Inches value can not be bigger than 11.")
									            alert('<%=vPrompts[118]%>' + " " + Q_no + "")
									        }
                                          else
                                           {
                                            document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                           }   
                                     document.aspnetForm.MH_Unit_Error_Flag.value='1' 
									return false;
                }
			     
      }// if (textBoxValue != "")
        
}
//***************************************** Validation check measurement or hours

function H_unitVal(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) 
{
    //alert("H_unitVal")
        
        
     ShowErrorMessageCnt=document.aspnetForm.ShowErrorMessageCnt.value
    // alert("ShowErrorMessageCnt=" + ShowErrorMessageCnt)
     ShowErrorMessageFlg=document.aspnetForm.ShowErrorMessageFlg.value
     //alert("ShowErrorMessageFlg=" + ShowErrorMessageFlg)

    Mask_high_low_val=document.aspnetForm.Mask_high_low_val.value 
    //alert("Mask_high_low_val=" + Mask_high_low_val)	
    
   

    textBoxValue = eval("document.getElementById('" + Ele_name + "').value")
   //alert("textBoxValue=" + textBoxValue)
   
     Timeq_desc=document.aspnetForm.Timeq_desc.value 
   //alert("Timeq_desc=" + Timeq_desc)	
   
     var HighValue="";
     var LowValue="";
     
    //alert("Pos=" + Pos)
     HighValue = Ans_Val_High.toString()
   //alert("HighValue=" + HighValue)
    
    LowValue = Ans_Val_Low.toString()
   //alert("LowValue=" + LowValue)

   if (textBoxValue != "")
   {
   
            if (textBoxValue.indexOf(':') > -1) 
            {            
                        HVArray=Timeq_desc.split(","); 
                        hrs_DescV=HVArray[0].valueOf() 
                        min_DescV=HVArray[1].valueOf() 
                     
                //get responses
                         ResHrs="" 
                         ResMin="" 
                          H_Ele_val=textBoxValue.replace(hrs_DescV,"") 
                          H_Ele_val=H_Ele_val.replace(min_DescV,"") 
                           
                          HResArray=H_Ele_val.split(":");
                          ResHrs=HResArray[0].valueOf() 
                          ResMin=HResArray[1].valueOf()  
                
                         ResHrs=Number(ResHrs) 
                         ResMin=Number(ResMin) 
                        // alert("ResponseFeet=" + ResponseFeet)
                       //  alert("ResponseInc=" + ResponseInc)
                         FinalEnterVal=ResHrs + "." +  ResMin
                         
                           
                         //  alert("StrInch_Max_Val=" + StrInch_Max_Val)
						  if (ResMin>59)
								{
								    //alert("Error")
								    
								    document.aspnetForm.MH_Unit_Error_Flag.value='1' 
								    document.aspnetForm.ShowErrorMessageCnt.value=1
								     if (ShowErrorMessageFlg=="Y")
                                      {                                        
									        //alert("The question " + Q_no + ", Inch/Inches value can not be bigger than 11.")
									       alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[40]%> ')
									  }
                                     else
                                      {
                                        document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                      }       
									        
									return false;
								}
						if (ResMin<0)
								{
								    document.aspnetForm.MH_Unit_Error_Flag.value='1' 
								    document.aspnetForm.ShowErrorMessageCnt.value=1
								     if (ShowErrorMessageFlg=="Y")
                                      { 
									        //alert("The question " + Q_no + ", Inch/Inches value can not be less than 0.")
									        alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[41]%>')
        							  }
                                     else
                                      {
                                        document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                      }    	
									return false;
								}
								// alert("here"); 
								 
					//********************** High and low values
					               var Pos=LowValue.indexOf(".",0) 
					             //  alert("Pos=" + Pos)
					               if (Pos>0)
					                {
					                    LowValueHrs=LowValue.substring(0, Pos);
					                    //alert("LowValueFeet=" + LowValueFeet); 
					                    Pos2=length.LowValue
					                    LowValueMin=LowValue.substring(Pos, Pos2);
					                    LowValueMin=LowValueMin*60
					                    //alert("LowValueMin=" + LowValueMin);
					                    LowValueMin=Math.round(LowValueMin,2)
					                 }
					                 else
					                 {
					                    LowValueHrs=LowValue
					                    LowValueMin=0
					                 }
					                DisplayLowVal=LowValueHrs + "." + LowValueMin
					                 // alert("DisplayLowVal=" + DisplayLowVal);  
									
					                Pos=HighValue.indexOf(".")
					               // alert("Pos=" + Pos);
					                if (Pos>0)
					                {
					                        HighValueHrs=HighValue.substring(0, Pos);
					                       // alert("HighValueFeet=" + HighValueFeet);
					                        Pos2=length.HighValue
					                        HighValueMin=HighValue.substring(Pos, Pos2);
					                        HighValueMin=HighValueMin*60
					                        // alert("HighValueMin=" + HighValueMin);
					                        HighValueMin=Math.round(HighValueMin,2)
					                 }
					                 else
					                 {
					                    HighValueHrs=HighValue
					                    HighValueMin=0   
                                     }  
                                      DisplayHighVal=HighValueHrs + "." + HighValueMin   
                                      //alert("DisplayHighVal=" + DisplayHighVal); 
								
								   if ((eval(DisplayLowVal) > eval(FinalEnterVal)) && (DisplayLowVal != "")) 
                                    {
                                    
                                         document.aspnetForm.ShowErrorMessageCnt.value=1
                                         if (ShowErrorMessageFlg=="Y")
                                            { 
                                      
                                                  if (Mask_high_low_val=="Y")
									                {
        									                
									                           //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
										                    alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[117]%>')
									                }
									                else
									                {
                                                            //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
                                                            
                                                           // alert('The question ' + Q_no + " " + 'value has to be bigger or equal to ' + " " + DisplayLowVal + "")
                                                   	        //alert('<%=vPrompts[57]%> ' + " " + Q_no + ", " + 'value has to be bigger or equal to ' + " " + LowValueFeet + " " + 'Feet(s)' + " and " + LowValueInc + " " + 'Inch/Inches' + ".");
                                                   	        alert('<%=vPrompts[57]%>' + " " + Q_no + ": " + '<%=vPrompts[36]%>' + " " + LowValueHrs + " " + '<%=vPrompts[98]%>' + " and " + LowValueMin + " " + '<%=vPrompts[99]%>' + ".");
                                                           	
                                                    }
                                            }
                                          else
                                           {
                                            document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                           }         
                                    document.aspnetForm.MH_Unit_Error_Flag.value='1' 
                                    return false;
                                }
                              //  alert("1 check");
                                if ((eval(DisplayHighVal) < eval(FinalEnterVal)) && (DisplayHighVal != "")) 
                                {
                                
                                        document.aspnetForm.ShowErrorMessageCnt.value=1
                                        if (ShowErrorMessageFlg=="Y")
                                            { 
                                                  if (Mask_high_low_val=="Y")
									                {
									                           //alert("The question "+ Q_no +", value has to bigger or equal to " + LowValue);
										                    alert('<%=vPrompts[57]%> ' + Q_no + ": " + '<%=vPrompts[117]%>')
									                }
									                else
									                {
                                                            //alert("The question "+ Q_no +", value has to less or equal to " + HighValue);
                                                           // alert('The question ' + Q_no + " " + 'value has to be less or equal to ' + " " + DisplayHighVal + "")
                                                           //	alert('<%=vPrompts[57]%> ' + " " + Q_no + ", " + 'value has to be less or equal to ' + " " + HighValueFeet + " " + 'Feet(s)' + " and " + HighValueInc + " " + 'Inch/Inches' + ".");
                                                           alert('<%=vPrompts[57]%>' + " " + Q_no + ": " + '<%=vPrompts[37]%>' + " " + HighValueHrs + " " + '<%=vPrompts[98]%>' + " and " + HighValueMin + " " + '<%=vPrompts[99]%>' + ".");		
                                                     }
                                           }
                                          else
                                           {
                                            document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                           }   
                                    document.aspnetForm.MH_Unit_Error_Flag.value='1' 
                                    return false;
                                }
                                
                                
                }//if (textBoxValue.indexOf(',') > -1) 
                else
                {
                
                                   
                                    document.aspnetForm.ShowErrorMessageCnt.value=1
                                    if (ShowErrorMessageFlg=="Y")
                                            { 
                                            
									            //alert("The question " + Q_no + ", Inch/Inches value can not be bigger than 11.")
									            alert('<%=vPrompts[118]%>' + " " + Q_no + "")
									        }
                                          else
                                           {
                                            document.aspnetForm.ShowErrorMessageFlg.value='Y'
                                           }   
                                     document.aspnetForm.MH_Unit_Error_Flag.value='1' 
									return false;
                }
			     
      }// if (textBoxValue != "")
        
}
//******************************************** question type D

function isValidDate(dateStr) {
    Str_Divid_dt = ""

    Date_sys_rule =  document.getElementById('DateRule').value
    // alert("Date_sys_rule=" + Date_sys_rule)

    Dash_Pos = Date_sys_rule.indexOf("-")
    Dot_Pos = Date_sys_rule.indexOf(".")
    Slash_Pos = Date_sys_rule.indexOf("/")

    if (Dash_Pos > 0) {
        Str_Divid_dt = "-"
    }

    if (Dot_Pos > 0) {
        Str_Divid_dt = "."
    }
    if (Slash_Pos > 0) {
        Str_Divid_dt = "/"
    }
    // alert("Str_Divid_dt=" + Str_Divid_dt)
    Input_Date_Pos = dateStr.indexOf(Str_Divid_dt)
    //alert("Input_Date_Pos=" + Input_Date_Pos)


    //Rep input date
    Input_Date_Array = dateStr.split(Str_Divid_dt)
    //alert("Input_Date_Array=" + Input_Date_Array[0])
    EnterDate_len = Input_Date_Array.length;
    // alert("EnterDate_len=" + EnterDate_len)
    if (EnterDate_len > 3) {
        alert('<%=vPrompts[66]%> ')
        return false;
    }

    //System rule date
    Date_Sys_Rule_Array = Date_sys_rule.split(Str_Divid_dt)


    for (y = 0; y < Date_Sys_Rule_Array.length; y++) {
        if (Date_Sys_Rule_Array[y] == "mm") {
            Var_month = Input_Date_Array[y];
            if (Var_month == undefined) {
                Input_Mon_Len = 0
            }
            else {
                Input_Mon_Len = Var_month.length
            }
            Sys_Rule_Mon_Len = Date_Sys_Rule_Array[y].length

        }
        if (Date_Sys_Rule_Array[y] == "dd") {
            Var_day = Input_Date_Array[y];
            if (Var_day == undefined) {
                Input_day_Len = 0
            }
            else {
                Input_day_Len = Var_day.length
            }

            Sys_Rule_day_Len = Date_Sys_Rule_Array[y].length
        }
        if (Date_Sys_Rule_Array[y] == "yy" || Date_Sys_Rule_Array[y] == "yyyy") {
            Var_year = Input_Date_Array[y];
            if (Var_year == undefined) {
                Input_year_Len = 0
            }
            else {
                Input_year_Len = Var_year.length
            }

            Sys_Rule_year_Len = Date_Sys_Rule_Array[y].length
        }
    }
    
    if (Input_year_Len != Sys_Rule_year_Len) {
        alert('<%=vPrompts[66]%> ')
        return false;
    }



    if (Var_month == undefined) {
        return false;
    }
    if (Var_day == undefined) {
        return false;
    }
    if (Var_year == undefined) {
        return false;
    }

    if (isNaN(Var_month) == true) {
        alert('<%=vPrompts[66]%> ')
        return false;
    }
    if (isNaN(Var_day) == true) {
        alert('<%=vPrompts[66]%> ')
        return false;
    }
    if (isNaN(Var_year) == true) {
        alert('<%=vPrompts[66]%> ')
        return false;
    }
    if (Var_month < 1 || Var_month > 12) { // check month range
        //alert("Month must be between 1 and 12.");
        alert('<%=vPrompts[48]%> ')
        return false;
    }
    if (Var_day < 1 || Var_day > 31) {
        //alert("Day must be between 1 and 31.");
        alert('<%=vPrompts[49]%> ')
        return false;
    }
    if ((Var_month == 4 || Var_month == 6 || Var_month == 9 || Var_month == 11) && Var_day == 31) {
        //alert("Month "+month+" doesn't have 31 days!")
        alert('<%=vPrompts[50]%> ' + Var_month + " " + '<%=vPrompts[51]%> ')

        return false
    }
    if (Var_month == 2) { // check for february 29th
        var isleap = (Var_year % 4 == 0 && (Var_year % 100 != 0 || Var_year % 400 == 0));

        if (Var_day > 29 || (Var_day == 29 && !isleap)) {
            //alert("February " + year + " doesn't have " + day + " days!");
            alert('<%=vPrompts[52]%> ' + Var_year + '<%=vPrompts[53]%> ' + Var_day + " " + '<%=vPrompts[54]%> ')

            return false;
        }
    }

    //******************** Date can not be less 1/1/1900 and bigger than 6/6/2079
    if (Sys_Rule_year_Len == 2) {
        EnterDate = "" + Var_month + "/" + Var_day + "/20" + Var_year

    }
    else {
        EnterDate = "" + Var_month + "/" + Var_day + "/" + Var_year

    }

    if (Date.parse(EnterDate) < Date.parse('01/01/1900')) {
        alert('<%=vPrompts[66]%> ')
        return false;
    }


    if (Date.parse(EnterDate) > Date.parse('06/06/2079')) {
        alert('<%=vPrompts[66]%> ')
        return false;
    }
    return true;  // date is valid
}
//******************************************************* date validate	 																			
function DateHighLowCheck(Ele_name, Q_no, Ans_Val_High, Ans_Val_Low) {



    textBoxValue = eval("document.getElementById('" + Ele_name + "').value")
   // alert("textBoxValue=" + textBoxValue)

    Date_sys_rule = document.getElementById('DateRule').value
    //alert("DateHighLowCheck="+ dateStr);


    HighValue = Ans_Val_High.toString();
    LowValue = Ans_Val_Low.toString();  
    //alert("LowValue=" + LowValue)
    //alert("HighValue=" + HighValue)

    LenLowValue = LowValue.length
    LenHighValue = HighValue.length
    //alert("LenLowValue=" + LenLowValue);
    //alert("LenHighValue=" + LenHighValue);


    if (LenLowValue == 5) {
        LowValue = "0" + LowValue
    }
    if (LenHighValue == 5) {
        HighValue = "0" + HighValue
    }
    if (LenLowValue == 7) {
        LowValue = "0" + LowValue
    }
    if (LenHighValue == 7) {
        HighValue = "0" + HighValue
    }
   // alert("LowValue00="+ LowValue);
    //alert("HighValue00="+ HighValue);
   
   // return false;
    SubLowValue = LowValue
    SubLowLen = SubLowValue.length
    SubHighValue = HighValue
    SubHighLen = SubHighValue.length

    E_delimiter = document.getElementById('Date_input').value
    // alert("E_delimiter="+ E_delimiter);
    // alert("dateStr="+ dateStr);	
    var StrDatearray = textBoxValue.split(E_delimiter)

    DateRulearray = Date_sys_rule.split(E_delimiter)
    //alert("Date_sys_rule="+ Date_sys_rule);

    //StrDate,LowValue,HighValue,v_date_sys_rule,Question

    var EnterDate = ""
    for (c = 0; c < DateRulearray.length; c++) {
        if (DateRulearray[c] == "mm") {
            v_month = StrDatearray[c];
            monthNum = Number(v_month)
            monthNum = Trim(monthNum)
            Monlen = monthNum.length
            //For low values
            LowMonth = SubLowValue.substring(0, 2)
            // alert("LowMonth=" + LowMonth);
            SubLowValue = SubLowValue.substring(2, SubLowLen)
            //For High values
            HighMonth = SubHighValue.substring(0, 2)
            // alert("HighMonth=" + HighMonth);
            SubHighValue = SubHighValue.substring(2, SubHighLen)

            if (Monlen == 1) {
                monthNum = "0" + monthNum
            }
            if (EnterDate == "") {
                EnterDate = monthNum
                LowDate = LowMonth
                HighDate = HighMonth
            }
            else {
                LowDate = LowDate + "" + E_delimiter + "" + LowMonth
                HighDate = HighDate + "" + E_delimiter + "" + HighMonth
                EnterDate = EnterDate + "" + monthNum
            }


        }


        if (DateRulearray[c] == "dd") {

            v_day = StrDatearray[c];
            dayNum = Number(v_day)
            dayNum = Trim(dayNum)
            daylen = dayNum.length
            //For Low values
            LowDay = SubLowValue.substring(0, 2)
            SubLowValue = SubLowValue.substring(2, SubLowLen)
            // alert("LowDay=" + LowDay);
            //For High values
            HighDay = SubHighValue.substring(0, 2)
            // alert("HighDay=" + HighDay);
            SubHighValue = SubHighValue.substring(2, SubHighLen)

            if (daylen == 1) {
                dayNum = "0" + dayNum
            }
            if (EnterDate == "") {
                EnterDate = dayNum
                LowDate = LowDay
                HighDate = HighDay
            }
            else {
                LowDate = LowDate + "" + E_delimiter + "" + LowDay
                HighDate = HighDate + "" + E_delimiter + "" + HighDay
                EnterDate = EnterDate + "" + dayNum
            }


            //alert("SubLowValuem=" + SubLowValue);

        }
        if (DateRulearray[c] == "yy" || DateRulearray[c] == "yyyy") {
            Year_Size = DateRulearray[c]
            v_year = StrDatearray[c];
            YearNum = Trim(v_year)
            Yearlen = YearNum.length
            if (Yearlen == 2) {
                LowYear = SubLowValue.substring(0, 2)
                //alert("LowYear2=" + LowYear);
                SubLowValue = SubLowValue.substring(2, SubLowLen)
                //For High values
                HighYear = SubHighValue.substring(0, 2)
                //alert("HighYear2=" + HighYear);
                SubHighValue = SubHighValue.substring(2, SubHighLen)
            }
            else {
                LowYear = SubLowValue.substring(0, 4)
                // alert("LowYear4=" + LowYear);
                SubLowValue = SubLowValue.substring(4, SubLowLen)
                //For High values
                HighYear = SubHighValue.substring(0, 4)
                // alert("HighYear4=" + HighYear);
                SubHighValue = SubHighValue.substring(4, SubHighLen)
            }
            if (EnterDate == "") {
                EnterDate = v_year
                LowDate = LowYear
                HighDate = HighYear
            }
            else {
                LowDate = LowDate + "" + E_delimiter + "" + LowYear
                HighDate = HighDate + "" + E_delimiter + "" + HighYear
                EnterDate = EnterDate + "" + v_year
            }

            LenYear = Year_Size.length
            //alert("LenYear="+ LenYear);
            //alert("SubLowValue="+ SubLowValue);


        }
    }

     	//		alert("EnterDate="+ EnterDate);
    	//		alert("LowValue="+ LowValue); 
     	//		alert("HighValue="+ HighValue);

    //			alert("Year_Size="+ Year_Size);
    //			alert("v_month="+ v_month);
    //			alert("v_day="+ v_day);
    //			alert("v_year="+ v_year);

    //alert("LowDate="+ LowDate );
    //alert("HighDate="+ HighDate );
    //myNewString=number(myNewString)

    DisplayLowDate = LowDate
    DisplayhighDate = HighDate

    if (LenYear == 2) {
        EnterDate = "" + monthNum + "/" + dayNum + "/20" + v_year
        LowDate = "" + LowMonth + "/" + LowDay + "/20" + LowYear
        HighDate = "" + HighMonth + "/" + HighDay + "/20" + HighYear
    }
    else {
        EnterDate = "" + monthNum + "/" + dayNum + "/" + v_year
        LowDate = "" + LowMonth + "/" + LowDay + "/" + LowYear
        HighDate = "" + HighMonth + "/" + HighDay + "/" + HighYear
    }

   		//alert("LowDatefin="+ LowDate);
    	//alert("HighDatefin="+ HighDate);
   		//alert("EnterDate="+ EnterDate);

    if (LowValue != 0) {
        if (Date.parse(EnterDate) < Date.parse(LowDate)) {
            //alert(document.aspnetForm.error_msg[0].value + " "+ Question +", " + document.aspnetForm.error_msg[2].value + " " + DisplayLowDate);
            alert('<%=vPrompts[57]%>' + " " + Q_no + ", " + '<%=vPrompts[46]%>' + " " + DisplayLowDate);

            //result = false;																												
            return false;
        }
    }
    if (HighValue != 0) {
        if (Date.parse(EnterDate) > Date.parse(HighDate)) {

            //alert(document.aspnetForm.error_msg[0].value + " "+ Question +", " + document.aspnetForm.error_msg[3].value + " " + DisplayhighDate);
            alert('<%=vPrompts[57]%>' + " " + Q_no + ", " + '<%=vPrompts[47]%>' + " " + DisplayhighDate);
            //result = false;						
            return false;
        }
    }

    //******************** Date can not be less 1/1/1900 and bigger than 6/6/2079

    if (Date.parse(EnterDate) < Date.parse('01/01/1900')) {
        return false;
    }


    if (Date.parse(EnterDate) > Date.parse('06/06/2079')) {
        return false;
    }

}

//******************************************** Put focus on the element 	

function ElementOnFocus(lastEleVal) 
{
    //TextProdNumber = document.aspnetForm.EnterProduct.value
    //alert("TabKey=" + event.keyCode)
   // alert("ElementOnFocus=" + lastEleVal)
    eval("document.getElementById('" + lastEleVal + "').focus()");
   // eval("document.getElementById('" + lastEleVal + "').select()");
   setTimeout(function() { eval("document.getElementById('" + lastEleVal + "').select()"); }, 100);

}

function EnterText(evt,CounterBoxName, TextBoxName) {
   // alert("TextBoxName=" + TextBoxName);
   //  alert("CounterBoxName=" + CounterBoxName);
      var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    //alert("charCode=" + charCode);
    //***** charCode=13 is Enter key
    ILang_Id = document.getElementById('ILang_Id').value  
    // for character |
    if (charCode == 124) {
        return false;
    }
    // for character >
    if (charCode == 62) {
        return false;
    }
    // for character <
    if (charCode == 60) {
        return false;
    }
    // for character ,
    if (charCode == 44) {
        return false;
    }
    // for character '
     if (charCode == 39) 
     {
        return false;
    }
    TextLenDis=""
    TextLen = eval("document.getElementById('" + TextBoxName + "').value.length")
    //alert("TextLen=" + TextLen);
     if (TextLen > 100 )
        {
            //EnterInBox= eval("document.getElementById('" + TextBoxName + "').value.substring( 0, 100 )");
              //eval("document.getElementById('" + TextBoxName + "').value='" + EnterInBox + "'")
            //alert("over 100=" + EnterInBox);
             return false;
         }
    //document.test." + CounterBoxName + ".value=TextLen
     if (TextLen < 100 )
        {
            TextLenDis=TextLen+1
        }
       else
        {
            TextLenDis=TextLen 
        }
    eval("document.getElementById('" + CounterBoxName + "').value=TextLenDis")
     return true;
}
function checkNumber(val) {
    //alert("val=" + val);

    ILang_Id = document.getElementById('ILang_Id').value 
    var strLength = val.length;
    //alert("strLength=" + strLength);
    for (w = 0; w < strLength; w++) {
        //alert("w=" + w);
        Valnum = val.charAt(w);
        // alert("Valnum=" + Valnum);
        var cCode = CalcKeyCode(Valnum);
        // alert("code=" + cCode);
        //if (cCode < 48 || cCode > 57 ) 
        if (ILang_Id == "10") {
            if (cCode == 47) {
                return false;
            }
            if (cCode < 46 || cCode > 57) {
                // alert("What");
                return false;
            }
        }
        else {
            if (cCode < 48 || cCode > 57) {
                // alert("What");
                return false;
            }
        }
    }
}
function CalcKeyCode(aChar) {
    var code = aChar.charCodeAt(0);
    return code;
}
function NumberOnly(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
     //alert("charCode=" + charCode);
    //***** charCode=13 is Enter key
    ILang_Id = document.getElementById('ILang_Id').value 

    if (charCode == 13) {
        return false;
    }
    if (ILang_Id == "10") {
        if (charCode == 47) {
            return false;
        }

        if (charCode > 31 && (charCode < 46 || charCode > 57)) {
            return false;
        }
    }
    else {
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
    }
    return true;
}
function NumberOnlyPrice(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
   // alert("charCode=" + charCode);
    //***** charCode=13 is Enter key
    ILang_Id = document.getElementById('ILang_Id').value

    if (charCode == 13) {
        return false;
    }
    if (ILang_Id == "10") {
        if (charCode == 47) {
            return false;
        }

        if (charCode > 31 && (charCode < 46 || charCode > 57)) {
            return false;
        }
    }
    else {
        if (charCode > 31 && (charCode < 46 || charCode > 57))
         {
            return false;
        }
        if (charCode== 47) {
            return false;
        }
    }
    return true;
}


function DatecheckNumber(val) {
    // alert("val=" + val);

    var strLength = val.length;
    //alert("strLength=" + strLength);
    for (w = 0; w < strLength; w++) {
        //alert("w=" + w);
        Valnum = val.charAt(w);
        //alert("Valnum=" + Valnum);
        var cCode = CalcKeyCode(Valnum);
        //alert("code=" + cCode);
        if (cCode < 44 || cCode > 57) {
            // break;
            // alert("wrong");
            return false;
        }
        //alert("What=" + Valnum);
    }
}
function DateNumberOnly(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    //alert("charCode=" + charCode);
    //***** charCode=13 is Enter key
    if (charCode == 13) {
        return false;
    }

    if (charCode > 31 && (charCode < 44 || charCode > 57)) {
        return false;
    }
    return true;
}
//pop up text area
function TextCheckOnly(evt,CounterBoxName, TextBoxName) 
{
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
   //alert("charCode=" + charCode);
    //***** charCode=13 is Enter key
    ILang_Id = document.getElementById('ILang_Id').value 
     TextLenDis=""
     
    // for character |
    if (charCode == 124) {
        return false;
    }
    // for character >
    if (charCode == 62) {
        return false;
    }
    // for character <
    if (charCode == 60) {
        return false;
    }
    // for character ,
    if (charCode == 44) {
        return false;
    }
    if (charCode == 13) {
        return false;
    }
    if (charCode == 39) {
        return false;
    }
    TextLen = eval("document.getElementById('" + TextBoxName + "').value.length")
   // alert("TextLen=" + TextLen);
   TextLenDis=TextLen
     if (TextLen > 0 )
         { 
            TextLen=TextLen-1
         }
     if (TextLen > 100 )
         { 
             return false;
         }
     
    //document.test." + CounterBoxName + ".value=TextLen
    eval("document.getElementById('" + CounterBoxName + "').value=TextLen")
    
    return true;
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
    if (str + "" == "undefined" || str == null)
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
function TrimRight(str) {
    var resultStr = "";
    var i = 0;

    // Return immediately if an invalid value was passed in
    if (str + "" == "undefined" || str == null)
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
function CFRefresh()
{
 //  alert("test");
    return false;
}
function MHTypeTab_val(MHBox1,MHBox2)
{
      // alert("MHTypeTab_val");
    //alert("MHBox1=" + MHBox1);
    //alert("MHBox2=" + MHBox2);
    
    //MH_Type_q_Tab_Status 
    //MH_Type_q_Tab_Val 
    //*****************name of the second text
    eval("document.aspnetForm.MH_Type_q_Tab_Val.value='" + MHBox2 + "'")
    //*****************set a flag to tab to second textbox of Measurement or hours
    eval("document.aspnetForm.MH_Type_q_Tab_Status.value=1")
 
}
function MHTypeTab_BoxSec(MHBox1,MHBox2)
{
      //  alert("M_BoxSec");
    // alert("MHTypeTab_BoxSec1=" + MHBox1);
     //alert("MHTypeTab_BoxSec2=" + MHBox2);
    
    //MH_Type_q_Tab_Status 
    //MH_Type_q_Tab_Val 
    //*****************name of the second text
     document.aspnetForm.MH_Type_q_Tab_Val.value='' 
    //*****************set a flag to tab to second textbox of Measurement or hours
     document.aspnetForm.MH_Type_q_Tab_Status.value='' 
 
}
function TextAreaMaxLen(Txt_name)
{
   
}


</script>
<hr color="dodgerblue" />
<asp:Table ID="Table2" runat="server" width="100%" BorderWidth="0" bordercolor="dodgerblue">
<asp:TableRow>
    <asp:TableCell HorizontalAlign="Left" >
           <asp:Table ID="Table1" runat="server" width="100%"  BorderWidth="0" bordercolor="dodgerblue">
            <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader" >
                        <asp:Label ID="LabelJob_no" runat="server" Text="Job No."  CssClass="reportCriteriaHeader"></asp:Label>  
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem" >
                        :<%=Job_No%>
                </asp:TableCell>
            </asp:TableRow> 
             <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader">
                <asp:Label ID="Label4" runat="server" Text="Wave No."   CssClass="reportCriteriaHeader"></asp:Label>  
                           
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem">
                        :<%=Wave_No%>
                </asp:TableCell>
            </asp:TableRow> 
             <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader">
                <asp:Label ID="Label5" runat="server" Text="Task No."  CssClass="reportCriteriaHeader"></asp:Label>     
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem">
                       :<%=Task_No%>
                </asp:TableCell>
            </asp:TableRow> 
             <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader">
                 <asp:Label ID="Label6" runat="server" Text="Chain No."  CssClass="reportCriteriaHeader"></asp:Label>     
                         
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem">
                        :<%=Chain_No%>
                </asp:TableCell>
            </asp:TableRow> 
             <asp:TableRow>
                <asp:TableCell Width="10%" CssClass="reportCriteriaHeader">
                <asp:Label ID="Label7" runat="server" Text="Store No."  CssClass="reportCriteriaHeader"></asp:Label>     
                
                </asp:TableCell>
                  <asp:TableCell Width="90%" CssClass="selectionCriteriaItem">
                       :<%=Store_No%>
                </asp:TableCell>
            </asp:TableRow> 
            
         </asp:Table>

    </asp:TableCell>
</asp:TableRow> 
</asp:Table>

<hr color="dodgerblue" />
<input type='submit' name='testname' value='Reset'  onclick="return CFRefresh()"  id='test_id' style="border: solid black 0px; padding: 0px; background-color:White; text-align: justify; font-size: 0px; width: 0px;"/>
<br />
<asp:Label ID="Label1" runat="server"      ></asp:Label>

<asp:Label ID="Dispaly_GridCallform" runat="server"      ></asp:Label>

 


  

 <div id="ProdQuestion"   onkeydown="return DivQuestion();"  style="display: none; position: absolute; left: 130px; top: 50px; border: solid black 1px; padding: 10px; background-color:White; text-align: justify; font-size: 12px; width: 350px;"   ></div>


<br />
<center>
       <asp:Button  OnClientClick="return SaveProductNextPage()" ID="CallFormDone"  runat="server" Text="Submit" CssClass="Button"   TabIndex='1'></asp:Button>        
          <br />
          
           <div id="WaitSign" style="color:red;font-weight: bold;font-size: 20px;"></div>
           
 </center>          
          <%=DisplayJWTQuestionsInfo%>
           <br />
          <%=DisplayResponseInfo%>
           <br />
          <%=DisplayQuestLinkInfo%>
           <br />
          <%=DisplayPQListInfo%>
            <br />
          <%=DisplayansbackLinkInfo%>
           <br />
          <%=DisplayHighLowInfo%>
          
          <input id="ShowErrorMessageCnt" type="hidden" value="0" />
          <input id="ShowErrorMessageFlg" type="hidden" value="Y" />
   
          <input id="DisplayCallFormFunction" type="hidden" value="Y" />
          <input id="PopQTabkey" type="hidden"  value="0" />
           <input id="FocusEle_name" type="hidden"  />
          <input id="Merch_no" type="hidden" runat="server" />
          <input id="DateRule" name="DateRule" type="hidden" value="<%=DateRule%>"/>
          <input id="Decimal_Point" name="Decimal_Point" type="hidden" value="<%=Decimal_Point%>"/>
          <input id="MeasurementValue" name="MeasurementValue" type="hidden" value="<%=MeasurementValue%>"/>
          <input id="MeasurementDesc" name="MeasurementDesc" type="hidden" value="<%=MeasurementDesc%>"/>
          <input id="Timeq_desc" name="Timeq_desc" type="hidden" value="<%=Timeq_desc%>"/>
          
          
            
          <input id="DivPopUP_Ele_id" type="hidden"/>
          <input id="DivPopUP_Ele_Name" type="hidden"/>
          <input id="OldRowColorId" type="hidden"  />
          <input id="OldCellColorId" type="hidden"  />
          <input id="OldCellEleColorId" type="hidden"  />
          <input id="Skipattern_NextFocusEle" type="hidden"  />
          <input id="Select_Product_name" type="hidden"  />
          <input id="SelProd_txt_Ele" type="hidden"  />
          <input id="Validation_Select_Prod_id" type="hidden"  />
          <input id="AnyProduct_answered" name="AnyProduct_answered" type="hidden" />
          <input id="Question_Validation_NDPHM_Error_status" type="hidden"  />
          <input id="Prod_id_list" name="Prod_id_list" type="hidden" value="<%=Prod_id_list%>"/>
          <input id="ILang_Id" name="ILang_Id" type="hidden" value="<%=Lang_id%>"/>
          <input id="Date_input" type="hidden" value="<%=Date_input%>"  />
          
          <input id="MH_Type_q_Tab_Status" type="hidden" value=""  />
          <input id="MH_Type_q_Tab_Val" type="hidden" value=""  />
          <input id="MH_Unit_Error_Flag" type="hidden" value=""  />
          
          <input id="Mandatory_prod_Selected" type="hidden"  />
           <input id="InputidsAnswersAll" name="InputidsAnswersAll"  type="hidden"  />
           
          <input id="AnsBackWithTxtAll" name="AnsBackWithTxtAll"  type="hidden"  />
          
          <input id="NewGridCF_SaveAnsBack" type="hidden" value="<%=NewGridCF_SaveAnsBack%>" />
          <input name="AnswersAllFromGrid" type="hidden" value="<%=AnswersAllFromGrid%>"/>
          <input id="AllProdNames" type="hidden" value="<%=Prod_id_list%>" />
          <input name="ProdAnsForNextPage" type="hidden" value="<%=ProdAnsForNextPage%>"/>
          <input name="Product_Required" type="hidden" value="<%=Product_Required%>"/>
          
          <input name="Visit_Date" type="hidden" value="<%=Visit_Date%>" />	
        <input name="txt_midnight" type="hidden" value="" />
        <input name="Job_No" type="hidden" value="<%=Job_No%>" />
        <input name="Wave_No" type="hidden" value="<%=Wave_No%>" />
        <input name="Task_No" type="hidden" value="<%=Task_No%>" />
        <input name="Task_Desc" type="hidden" value="<%=Task_Desc%>" />
        <input name="Task_Addtl_Desc" type="hidden" value="<%=Task_Addtl_Desc%>" />
        <input name="Product_Type" type="hidden" value="<%=Product_Type%>"/>

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

        <input id="Hidden1" type="hidden" runat="server" />
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
        <input name="ILang_Id" type="hidden" value="<%=Lang_id%>"/>

        <input name="Star_time" type="hidden" value="<%=Star_time%>"/>
        <%//From page CFCallFormInputs.aspx %>

        <input name="DateRule" type="hidden" value="<%=DateRule%>"/>
        <input name="Decimal_Point" type="hidden" value="<%=Decimal_Point%>"/>
        <input name="MeasurementValue" type="hidden" value="<%=MeasurementValue%>"/>
        <input name="CallForm_Elements" type="hidden" value="<%=All_ElementName%>"/>
        <input name="ArrayAllHtmlElement" type="hidden" value="<%=ArrayAllHtmlElement%>"/>
        <input name="ArrayAllQuestionsElement" type="hidden" value="<%=ArrayAllQuestionsElement%>"/>
        <input name="ArrayEleSubmit" type="hidden" value="<%=ArrayEleSubmit%>"/>
        <input name="All_EleAns_Val" type="hidden" value="<%=All_EleAns_Val%>"/>
        <input name="CallFormAnswers" type="hidden" value=""/>
        <input name="ArrayEleSubmitRTS" type="hidden" value="<%=ArrayEleSubmitRTS%>"/>

        <%//For RTS%>
        <input name="Client_id" type="hidden" value="0"/>
        <input name="RTS_JWT_For" type="hidden" value="<%=STR_RTS_JWT%>"/>
        <input name="RTS_JWT" type="hidden" value="<%=STR_RTS_JWT%>"/>
        <input name="RTS_Ans_<%=STR_RTS_JWT%>" type="hidden" value="<%=Str_Back_RTSAnswers%>"/>
        <input name="RTS_Ans_Save" type="hidden" value=""/>
        <input type="hidden" name="Issue_Questions" value="<%=ArrayRTS_Q_no%>"/>
        <input name="Here_RTS_Issue" type="hidden" value=""/>
        <input name="RTS_Issue_Q_no" type="hidden" value=""/>
        <input name="Call_Type" type="hidden" value="NEW"/>
        <input name="IssueCategory" type="hidden" value="2"/>
        <input name="group" type="hidden" value="2"/>
        <input name="source" type="hidden" value="4"/>

        <input name="Save_One_Answer" type="hidden" value=""/> 
        <input name="CF_ILang_Id" type="hidden" value="<%=Lang_id%>"/>
        <input name="ShortCallForm" type="hidden" value="<%=ShortCallForm%>" id="Hidden2"/>
        <input name="Used_qty" type="hidden" value="<%=Used_qty%>" id="Hidden3"/>
        <input name="Date_input" type="hidden" value="<%=Date_input%>" id="Hidden4"/>
        <input name="Price_Rule" type="hidden" value="<%=Decimal_Point%>"/>
        <input name="Inch_Max_Val" type="hidden" value="<%=MeasurementValue%>"/>
        <input name="CheckTo_Erase_Answers" type="hidden" value=""/>
        <input name="CallFormEnded" type="hidden" value="<%=CallFormEnded%>"/>
        <input name="CFEnd_SelectedProduct" type="hidden" value="<%=CFEnd_SelectedProduct%>"/>
        <input name="CFEnd_Q_no" type="hidden" value=""/>
        
        <input name="Array_Mandatory_products" type="hidden" value="<%=Array_Mandatory_products%>"/>
        <input name="Old_Visit_Date" type="hidden" value="<%=Old_Visit_Date%>"/>
        <input name="dddCom_AllQ" id="Hidden7" type="hidden" value="008_N" />
        <input name="dddCom_q_008" id="dddCom_q_id_008" type="hidden" value="B_007_N" />
        <input name="Compare_q_status_flag" type="hidden" value="<%=Compare_q_status%>"/>
        <%=Compare_q_Hidden_var%>
        <input name="Mask_high_low_val" type="hidden" value="<%=Mask_high_low_val%>"/>
        <input name="NewGridCallForm" type="hidden" value="Y"/>
         <input name="Answers_Old_Prod_CF_Store_q" type="hidden" value="<%=Answers_Old_Prod_CF_Store_q%>"/>
         <input name="DisplayAnswerForGridCF" type="hidden" value="<%=DisplayAnswerForGridCF%>"/>
         <input name="NewScreenPage" type="hidden" value="<%=NewScreenPage%>"/>
        <input name="Str_Sv_Panel_id" type="hidden" value="<%=Str_Sv_Panel_id%>" />
</asp:Content>

