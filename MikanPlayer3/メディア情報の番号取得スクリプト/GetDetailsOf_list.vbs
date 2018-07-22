'==================================================================
' GetDetailsOf メソッドでファイルのプロパティ項目名を書き出ししますYO!
'http://d.hatena.ne.jp/palm84/20100307/1267891200
'http://www10.plala.or.jp/palm84/wsh.html
'http://www10.plala.or.jp/palm84/archives/wsh/GetDetailsOf_list.vbs.txt
'==================================================================
Option Explicit
'On Error Resume Next
Dim objShell, objFSO, objNetWork, objTxt
' Shell オブジェクトの作成
Set objShell = WScript.CreateObject("WScript.Shell")
' FileSystemObject オブジェクトの作成
Set objFSO = WScript.CreateObject("Scripting.FileSystemObject")
' NetWork オブジェクトの作成
Set objNetWork = WScript.CreateObject("WScript.Network")
' 定数
Const ForReading = 1, ForWriting = 2, ForAppending = 8
Const Reg_ProductName = "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName"

' ログファイル
Dim appPath, myOS, myDate, LogFile
myOS = objShell.RegRead(Reg_ProductName)
myOS = Replace(myOS, " ", "")
myDate = Replace(Date, "/", "-")
appPath = objFSO.GetParentFolderName(WScript.ScriptFullName)
LogFile = appPath & "\GetDetailsOf_list_" & myOS & "-" & myDate & ".txt"
Set objTxt = objFSO.OpenTextFile(LogFile, ForWriting, true, -1)

' とりあえずなファイルを指定
Dim strFilePath
strFilePath = "C:\Windows\System32\ntoskrnl.exe"
'strFilePath = "C:\Windows\regedit.exe"
' ファイル名、フォルダ名を取得
Dim objFile, strFileName, strFolder
Set objFile = objFSO.GetFile(strFilePath)
strFileName = objFSO.GetFileName(strFilePath)
strFolder = objFile.ParentFolder
' Shell.Application オブジェクトの作成
Dim objShellApp
Set objShellApp = CreateObject ("Shell.Application") 
' プロパティ情報を objItem に格納
Dim objFolder, objFolderItems, objItem
Set objFolder = objShellApp.Namespace(strFolder) 
Set objFolderItems = objFolder.Items
Set objItem = objFolderItems.Item(strFileName)
' 400 まで回してみるｗ
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
' プロパティの項目名取得
Sub myNameList
	objTxt.WriteLine y & vbTab & " : " & strName
End Sub

'*********************************************************
' Sub myCheckFile
'*********************************************************
' 指定ファイルのプロパティの項目名とデータ取得
Sub myCheckFile
		Dim strValue
		strValue = objFolder.GetDetailsOf(objItem, y)
		If strValue <> "" Then
			objTxt.WriteLine y & ") " & strName & vbTab & " : " & strValue
		End If
End Sub
