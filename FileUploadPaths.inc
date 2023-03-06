<%
'***** Connection Strings
Public FilePath
Public FileSave
Public FileCheckPath
Public Server_Name
Public ApplicationType
Public binaryPath
Public WebServer_Name
Public Host_Webserver
'******************* upload
'******** Production

ApplicationType="Test" 
'ApplicationType="Production" 


if (ApplicationType="Test") then
	if (ILang_Id="13") then
		FilePath="z:\Fieldapps\callforminput\sparEyesPic\sparEyesPic1" 
		FileSave="z:\Fieldapps\callforminput\sparEyesPic\sparEyesPic1\update\"
		FileCheckPath="z:\Fieldapps\callforminput\sparEyesPic\sparEyesPic1\working\"
	else
		FilePath="z:\Fieldapps\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "" 
		FileSave="z:\Fieldapps\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "\update\"
		FileCheckPath="z:\Fieldapps\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "\working\"
	end if 
	WebServer_Name = "mitest.sparinc.com"
 	Server_Name="http://" & WebServer_Name & "/"
	binaryPath="http://mitest.sparinc.com/CallForm/"
	Host_Webserver="mitest.sparinc.com"
	

end if 
if (ApplicationType="Production") then
	if (ILang_Id="13") then

		FilePath="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic1" 
		FileSave="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic1\update\"
		FileCheckPath="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic1\working\"
 	
		'FileSave="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic1\update"
	else
		FilePath="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "" 
		FileSave="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "\update\"
		FileCheckPath="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "\working\"
 	
		'FileSave="\\mi10\Edrive$\web applications\callforminput\sparEyesPic\sparEyesPic"& ILang_Id & "\update"
		
	end if 
	

	WebServer_Name = "mi10.sparinc.com"
 	Server_Name="http://" & WebServer_Name & "/"
	binaryPath="http://mi10.sparinc.com/CallFormMultiFile/"
	Host_Webserver="mi21.sparinc.com"
end if 



'***** ApplicationType Strings
'Response.Write "FilePath=" & Server_Name


%>
