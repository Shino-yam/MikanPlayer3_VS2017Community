'==================================================================
' GetDetailsOf ���\�b�h�Ńt�@�C���̃v���p�e�B���ږ��������o�����܂�YO!
'http://d.hatena.ne.jp/palm84/20100307/1267891200
'http://www10.plala.or.jp/palm84/wsh.html
'http://www10.plala.or.jp/palm84/archives/wsh/GetDetailsOf_list.vbs.txt
'==================================================================
Option Explicit
'On Error Resume Next
Dim objShell, objFSO, objNetWork, objTxt
' Shell �I�u�W�F�N�g�̍쐬
Set objShell = WScript.CreateObject("WScript.Shell")
' FileSystemObject �I�u�W�F�N�g�̍쐬
Set objFSO = WScript.CreateObject("Scripting.FileSystemObject")
' NetWork �I�u�W�F�N�g�̍쐬
Set objNetWork = WScript.CreateObject("WScript.Network")
' �萔
Const ForReading = 1, ForWriting = 2, ForAppending = 8
Const Reg_ProductName = "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName"

' ���O�t�@�C��
Dim appPath, myOS, myDate, LogFile
myOS = objShell.RegRead(Reg_ProductName)
myOS = Replace(myOS, " ", "")
myDate = Replace(Date, "/", "-")
appPath = objFSO.GetParentFolderName(WScript.ScriptFullName)
LogFile = appPath & "\GetDetailsOf_list_" & myOS & "-" & myDate & ".txt"
Set objTxt = objFSO.OpenTextFile(LogFile, ForWriting, true, -1)

' �Ƃ肠�����ȃt�@�C�����w��
Dim strFilePath
strFilePath = "C:\Windows\System32\ntoskrnl.exe"
'strFilePath = "C:\Windows\regedit.exe"
' �t�@�C�����A�t�H���_�����擾
Dim objFile, strFileName, strFolder
Set objFile = objFSO.GetFile(strFilePath)
strFileName = objFSO.GetFileName(strFilePath)
strFolder = objFile.ParentFolder
' Shell.Application �I�u�W�F�N�g�̍쐬
Dim objShellApp
Set objShellApp = CreateObject ("Shell.Application") 
' �v���p�e�B���� objItem �Ɋi�[
Dim objFolder, objFolderItems, objItem
Set objFolder = objShellApp.Namespace(strFolder) 
Set objFolderItems = objFolder.Items
Set objItem = objFolderItems.Item(strFileName)
' 400 �܂ŉ񂵂Ă݂邗
Dim y, strName
For y=0 To 400
	strName = objFolder.GetDetailsOf(Nothing, y)
	Call myNameList
	'Call myCheckFile
Next

Set objItem = Nothing
Set objFolderItems = Nothing
Set objFolder = Nothing
Set objFile = Nothing
Set objShellApp = Nothing

objTxt.WriteBlankLines (1)

objTxt.Close
objShell.Run """" & LogFile & """"
Set objTxt = Nothing
Set objNetWork = Nothing
Set objFSO = Nothing
Set objShell = Nothing

'*********************************************************
' Sub myNameList
'*********************************************************
' �v���p�e�B�̍��ږ��擾
Sub myNameList
	objTxt.WriteLine y & vbTab & " : " & strName
End Sub

'*********************************************************
' Sub myCheckFile
'*********************************************************
' �w��t�@�C���̃v���p�e�B�̍��ږ��ƃf�[�^�擾
Sub myCheckFile
		Dim strValue
		strValue = objFolder.GetDetailsOf(objItem, y)
		If strValue <> "" Then
			objTxt.WriteLine y & ") " & strName & vbTab & " : " & strValue
		End If
End Sub
