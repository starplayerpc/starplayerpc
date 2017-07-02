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

Imports System.Text.RegularExpressions

Public Class frmEditor
    Private Sub frmEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileToOpen = ""
        Try
            fileToOpen = My.Application.CommandLineArgs(0)
        Catch ex As Exception

        End Try
        If fileToOpen <> "" Then
            grdPlaylist.OpenPlaylist(fileToOpen)
            ' Launch playback in VLC then close this playlist editor app
            grdPlaylist.BeginPlayback(fileToOpen)
            End

        End If
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

    Private Sub grdPlaylist_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles grdPlaylist.CellValidating
        Dim originalLength As Integer
        Dim value As String

        If (e.ColumnIndex = 1 OrElse e.ColumnIndex = 2) Then
            originalLength = e.FormattedValue.length
            ' Only except 0-9 and decimal points. Note "123.456.." is still valid
            value = Regex.Replace(e.FormattedValue, "[^0-9.]", "")
            ' Only accept first . using variable length lookbehind: https://stackoverflow.com/a/35414387/1624894
            value = Regex.Replace(value, "(?<!^[^.]*)\.", "")
            ' Remove trailing .
                        value = Regex.Replace(value, "\.$", "")
            If value.Length <> originalLength Then
                grdPlaylist(e.ColumnIndex, e.RowIndex).Value = value
                grdPlaylist.EndEdit()
                ' As per https://stackoverflow.com/a/32887476/1624894
                ' we have to assign And EndEdit twice for the value in the grid to be updated
                grdPlaylist(e.ColumnIndex, e.RowIndex).Value = value
                grdPlaylist.EndEdit()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Display the context menu with available options
    ''' </summary>
    Private Sub grdPlaylist_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdPlaylist.MouseUp
        Dim ht As DataGridView.HitTestInfo
        Dim numRowsWithoutFinal = grdPlaylist.Rows.Count - 1
        Dim isFinalEmptyRow As Boolean

        ht = grdPlaylist.HitTest(e.X, e.Y)
        ' Context menu displayed if rightclick on any row, or left click column -1 (row heading) or column 0
        If ht.RowIndex >= 0 AndAlso (
                e.Button = Windows.Forms.MouseButtons.Right OrElse
                (e.Button = Windows.Forms.MouseButtons.Left AndAlso ht.ColumnIndex <= 0)
            ) Then
            ' Determine which options should be available...
            isFinalEmptyRow = (ht.RowIndex = numRowsWithoutFinal)
            ' Disable "Remove row" for final empty row as it is not really a row and should always be available to enter a new item
            mnuCellContext.Items.Item(1).Enabled = If(isFinalEmptyRow, False, True)

            ' Update intenal state to remember the current row required for the context menu
            grdPlaylist.ContextMenuRowIndex = ht.RowIndex

            mnuCellContext.Show(Cursor.Position)
        End If
    End Sub

    ''' <summary>
    ''' Updates the filename in the currently selected row
    ''' </summary>
    Private Sub mnuChooseVideo_Click(sender As Object, e As EventArgs) Handles mnuChooseVideo.Click
        grdPlaylist.ChoosePlaylistItem(grdPlaylist.ContextMenuRowIndex)
    End Sub

    ''' <summary>
    ''' Removes the entire currently selected row
    ''' </summary>
    Private Sub mnuRemoveRow_Click(sender As Object, e As EventArgs) Handles mnuRemoveRow.Click
        ' Prevent attempts to remove the uncommitted new row (which is always empty)
        Dim numRowsWithoutFinal = grdPlaylist.Rows.Count - 1
        If grdPlaylist.ContextMenuRowIndex >= 0 And grdPlaylist.ContextMenuRowIndex < numRowsWithoutFinal Then
            grdPlaylist.Rows.RemoveAt(grdPlaylist.ContextMenuRowIndex)
        End If
    End Sub

    Private Sub mnuInsertRowAbove_Click(sender As Object, e As EventArgs) Handles mnuInsertRowAbove.Click
        grdPlaylist.Rows.Insert(grdPlaylist.ContextMenuRowIndex, 1)
    End Sub

    Private Sub mnuInsertRowBelow_Click(sender As Object, e As EventArgs) Handles mnuInsertRowBelow.Click
        ' Special behaviour, if the user select "Insert row below" on the final empty row, then we actually insert an empty row above
        If grdPlaylist.ContextMenuRowIndex = grdPlaylist.Rows.Count - 1 Then
            ' Insert empty row above instead
            grdPlaylist.Rows.Insert(grdPlaylist.ContextMenuRowIndex, 1)
        Else
            grdPlaylist.Rows.Insert(grdPlaylist.ContextMenuRowIndex + 1, 1)
        End If
    End Sub

End Class

