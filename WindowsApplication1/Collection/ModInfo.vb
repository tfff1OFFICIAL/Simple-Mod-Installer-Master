﻿Public Class ModInfo
    Private Sub ModInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get the Info:
        Dim ModInfo = parseModInfo("C:\Tfff1\mcmod.info")

        modID.Text = ModInfo(0)
        modName.Text = ModInfo(1)
        modDesc.Text = ModInfo(2)
        modVersion.Text = ModInfo(3)
        modCredits.Text = ModInfo(4)
        modLogo.ImageLocation = "C:\Tfff1\SimpleMC\Mod_Extract\" + ModInfo(5)
        modMCVersion.Text = ModInfo(6)
        modURL.Text = ModInfo(7)
        modURL.

    End Sub

    Private Sub ModInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CollectionView.Enabled = True
    End Sub
End Class