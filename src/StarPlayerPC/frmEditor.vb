' Copyright (C) 2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Public Class frmEditor

    Private Sub frmEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = My.Application.Info.Title
    End Sub

    Private Sub mnuFileNew_Click(sender As Object, e As EventArgs) Handles mnuFileNew.Click
        grdPlaylist.ClearPlaylist()
    End Sub

    Private Sub mnuFileOpen_Click(sender As Object, e As EventArgs) Handles mnuFileOpen.Click
        grdPlaylist.OpenPlaylist()
    End Sub

    Private Sub mnuFileSaveAs_Click(sender As Object, e As EventArgs) Handles mnuFileSaveAs.Click
        grdPlaylist.SavePlaylist()
    End Sub

    Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        End
    End Sub

    Private Sub SaveAndPlaybackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAndPlaybackToolStripMenuItem.Click
        Dim filename As String
        filename = grdPlaylist.SavePlaylist()
        If filename <> "" Then
            grdPlaylist.BeginPlayback(filename)
        End If
    End Sub

    Private Sub mnuSettingsPreferences_Click(sender As Object, e As EventArgs) Handles mnuSettingsPreferences.Click
        ' This menu item is currently not visible
    End Sub

    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        frmSplash.ControlBox = True
        frmSplash.Show()
    End Sub

    Private Sub mnuHelpContents_Click(sender As Object, e As EventArgs) Handles mnuHelpContents.Click
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TableOfContents)
    End Sub
End Class

