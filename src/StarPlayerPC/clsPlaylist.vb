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

Imports System.ComponentModel
Imports System.Runtime.InteropServices


Public Class PlaylistItem
    Public Property Filename As String
    Public Property Repeat As Boolean
End Class


Public Class Playlist
    Inherits DataGridViewDragDrop

    ''' <summary>
    ''' Clears the contents of the playlist
    ''' </summary>
    Public Sub ClearPlaylist()
        Rows.Clear()
    End Sub

    ''' <summary>
    ''' Adds the given PlaylistItem to the playlist
    ''' </summary>
    ''' <param name="item"></param>
    Public Sub AddItemToPlaylist(item As PlaylistItem)
        Rows.Add(item.Filename, item.Repeat)
    End Sub

    ''' <summary>
    ''' Shows a file open dialog to select and open a playlist file
    ''' </summary>
    Public Sub OpenPlaylist()
        Dim dlgFileOpen As New OpenFileDialog()
        Dim result As Boolean

        dlgFileOpen.DefaultExt = My.Settings.playlistExtension
        dlgFileOpen.FileName = ""
        dlgFileOpen.Filter = My.Settings.playlistName & "|*" & My.Settings.playlistExtension
        dlgFileOpen.RestoreDirectory = True

        result = dlgFileOpen.ShowDialog()
        If result = True And dlgFileOpen.FileName <> "" Then
            OpenPlaylist(dlgFileOpen.FileName)
        End If
    End Sub

    ''' <summary>
    ''' Opens the playlist given in the specified filename
    ''' </summary>
    ''' <param name="filename"></param>
    Public Sub OpenPlaylist(filename As String)
        Dim items As New List(Of PlaylistItem)

        Using reader As New FileIO.TextFieldParser(filename)
            reader.TextFieldType = FileIO.FieldType.Delimited
            reader.SetDelimiters("|")

            Dim currentRow As String()
            While Not reader.EndOfData
                Try
                    currentRow = reader.ReadFields()
                    If currentRow.Length <> 2 Then
                        MsgBox("Invalid playlist file")
                        Exit While
                    End If
                    Dim item As New PlaylistItem
                    item.Filename = currentRow(0).Replace("file:///", "").Replace("/", "\")
                    item.Filename = item.Filename.Replace("%20", " ")
                    item.Repeat = currentRow(1) = "repeat"
                    items.Add(item)
                Catch ex As FileIO.MalformedLineException
                    MsgBox("Invalid playlist file")
                    Exit While
                End Try
            End While
        End Using
        OpenPlaylist(items)
    End Sub

    ''' <summary>
    ''' Opens the playlist given a list of PlaylistItems
    ''' </summary>
    ''' <param name="playlistItems"></param>
    Public Sub OpenPlaylist(playlistItems As List(Of PlaylistItem))
        ClearPlaylist()
        For Each item As PlaylistItem In playlistItems
            AddItemToPlaylist(item)
        Next
    End Sub

    ''' <summary>
    ''' Shows a file save dialog to select and save the current playlist to a file
    ''' </summary>
    Public Function SavePlaylist()
        Dim dlgFileSave As New SaveFileDialog()
        Dim result As Boolean

        dlgFileSave.DefaultExt = My.Settings.playlistExtension
        dlgFileSave.FileName = ""
        dlgFileSave.Filter = My.Settings.playlistName & "|*" & My.Settings.playlistExtension
        dlgFileSave.RestoreDirectory = True

        result = dlgFileSave.ShowDialog()
        If result = True And dlgFileSave.FileName <> "" Then
            SavePlaylist(dlgFileSave.FileName)
            Return dlgFileSave.FileName
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Saves the current playlist given in the specified filename
    ''' </summary>
    ''' <param name="filename"></param>
    Public Sub SavePlaylist(filename As String)
        Dim filepath As String
        Dim playmode As String
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)

        Using file As New IO.StreamWriter(filename, False, utf8WithoutBom)
            For Each row As DataGridViewRow In Rows
                If row.Cells(0).Value <> "" Then
                    If CBool(row.Cells(1).EditedFormattedValue) Then
                        playmode = "repeat"
                    Else
                        playmode = "continue"
                    End If
                    filepath = row.Cells(0).Value.replace("\", "/")
                    filepath = filepath.Replace(" ", "%20")
                    file.WriteLine("file:///" & filepath & My.Settings.playlistSeperator & playmode)
                End If
            Next
        End Using
    End Sub

    Public Sub BeginPlayback(filename As String)
        ' fullscreen is provided by sending the 'f' key later (cannot enable 
        Dim args = "--aspect-ratio=16:9 --no-qt-updates-notif --no-osd -q --no-qt-fs-controller --key-next ""Page Down"" --key-prev ""Page Up"" --key-leave-fullscreen Unset --key-quit Esc "
        Dim pi As New ProcessStartInfo(My.Settings.vlcPath, args & """" & filename & """")
        'pi.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System)

        Using vlc As New Process
            vlc.StartInfo = pi
            vlc.Start()
            SetForegroundWindow(vlc.MainWindowHandle)
            vlc.WaitForInputIdle()
            System.Threading.Thread.Sleep(500)
            ' Send Alt-i, up, enter, f (enable extension then go fullscreen, cannot enable extension once fullscreen)
            My.Computer.Keyboard.SendKeys("%i{UP}~f")
        End Using
    End Sub

    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(hWnd As IntPtr) As Boolean
    End Function

    ''' <summary>
    ''' Displays an open file dialog to choose the media file associated with this playlist item
    ''' </summary>
    ''' <param name="e"></param>
    Private Sub ChoosePlaylistItem(ByVal e As DataGridViewCellEventArgs)
        Dim filename As String
        Dim result As Boolean

        Dim dlgPlaylistChooseFile As New OpenFileDialog()
        dlgPlaylistChooseFile.Filter = "All files|*.*|All video files|*.asf;*.avchd;*.avi;*.flv;*.mp4;*.mov;*.wmv;*.yuv|Advanced Systems Format|*.asf|Advanced Video Codec High Definition|*.avchd|Audio Video Interleave|*.avi|Flash video|*.flv|MPEG4|*.mp4|QuickTime|*.mov|Windows Media Video|*.wmv|Raw video format|*.yuv"
        dlgPlaylistChooseFile.FilterIndex = 2
        dlgPlaylistChooseFile.RestoreDirectory = True

        If e.ColumnIndex = 0 Then
            dlgPlaylistChooseFile.FileName = ""
            result = dlgPlaylistChooseFile.ShowDialog()
            If result = True And dlgPlaylistChooseFile.FileName <> "" Then
                filename = dlgPlaylistChooseFile.FileName
                Rows(e.RowIndex).Cells(e.ColumnIndex).Value = filename
                If e.RowIndex + 1 = RowCount Then
                    ' Notifying that the current cell contains data causes a new empty row to be added below
                    NotifyCurrentCellDirty(True)
                    NotifyCurrentCellDirty(False)
                End If
            End If
        End If
    End Sub

    Private Sub Playlist_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Me.CellClick
        ChoosePlaylistItem(e)
    End Sub

End Class
