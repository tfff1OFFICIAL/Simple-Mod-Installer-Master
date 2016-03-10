﻿Imports System.IO
Public Class CollectionView
    Public ModInt As Integer
    Public ModInt2 As Integer
    Public pathToMod
    Public Path As String = "C:\Tfff1\Simple_MC\Mod_Collections\" + My.Settings.SelectedCollection
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(My.Settings.websiteurl)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hide()
        Form2.Show()
        Close()
    End Sub

    Private Sub CollectionView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Manager()
    End Sub

    Public Sub CollectionView_Refresh(sender As Object, e As EventArgs) Handles CollectionView_RefreshButton.Click
        Call Load_Manager()
    End Sub

    Sub Load_Manager()
        'Disable Changes While Loading:
        Enabled = False
        ModInt = 0
        'Start Calling:
        Call Collection_LoadMods(Me, Path, True)
        Call Collection_ReadInfo(Me, Path)
        'CompareTitles can be toggled on and off in settings: listed as "Safer Collections"
        Call Collection_CompareTitles(Me, My.Settings.compareTitles)
        'Gets Number of Mods in listbox:
        For l_index As Integer = 0 To ModList.Items.Count - 1
            Dim l_text As String = CStr(ModList.Items(l_index))
            ModInt = ModInt + 1
        Next
        ModCount.Text = "Mod Count: " + ModInt.ToString
        'Enable Changes once Loading Finished:
        Enabled = True
    End Sub

    Private Sub AddMod_Click(sender As Object, e As EventArgs) Handles AddMod.Click
        My.Settings.AddFiles_BasePath = "C:\Tfff1\Simple_MC\Mod_Collections\" + My.Settings.SelectedCollection + "\mods\"
        My.Settings.Save()
        Enabled = False
        AddMods.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start(Path + "\config")
    End Sub

    Private Sub DelMod_Click(sender As Object, e As EventArgs) Handles DelMod.Click
        ModInt2 = 0
        For l_index As Integer = 0 To ModList.CheckedItems.Count - 1
            Dim l_text As String = CStr(ModList.CheckedItems(l_index))

            Dim currentLocation As String = Path + "\mods\" + l_text
            Dim CurrentLocation2 As String = Path + "\mods\" + My.Settings.SelectedCollection_MCversion + "\" + l_text

            If My.Computer.FileSystem.FileExists(currentLocation) Then
                Try
                    My.Computer.FileSystem.DeleteFile(currentLocation)
                    ModInt2 = ModInt2 + 1
                Catch
                    MsgBox("Failed to delete file: " + l_text + " maybe it doesn't exist anymore?")
                End Try
            ElseIf File.Exists(CurrentLocation2) Then
                Try
                    My.Computer.FileSystem.DeleteFile(CurrentLocation2)
                    ModInt2 = ModInt2 + 1
                Catch
                    MsgBox("Failed to delete file: " + l_text + " maybe it doesn't exist anymore?")
                End Try
            Else
                MsgBox("Failed to find file: " + l_text + " maybe it doesn't exist anymore?")
            End If
        Next
        MsgBox("Successfully Removed " + ModInt2.ToString + " mods from collection")
        Call Load_Manager()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Enabled = False
        FolderView.Show()
    End Sub
End Class