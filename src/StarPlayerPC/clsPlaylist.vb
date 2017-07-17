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
    Public Property StartTime As String
    Public Property EndTime As String
    Public Property Repeat As Boolean
End Class


Public Class Playlist
    Inherits DataGridViewDragDrop
    Public Property ContextMenuRowIndex As Integer = 0

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
        Dim rowIndex = Rows.Add(item.Filename, item.StartTime, item.EndTime, item.Repeat)
        ' Check filename exists, if not then color the text red
        If Not My.Computer.FileSystem.FileExists(item.Filename) Then
            Rows.Item(rowIndex).DefaultCellStyle.ForeColor = Color.Red
            Rows.Item(rowIndex).DefaultCellStyle.SelectionBackColor = Color.Red
            Rows.Item(rowIndex).DefaultCellStyle.SelectionForeColor = Color.White
        End If

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
            reader.SetDelimiters(My.Settings.playlistSeperator)

            Dim currentRow As String()
            While Not reader.EndOfData
                Try
                    currentRow = reader.ReadFields()
                    If currentRow.Length <> 5 Then
                        MsgBox("Invalid playlist file")
                        Exit While
                    End If

                    Dim item As New PlaylistItem
                    item.Filename = currentRow(0)

                    If item.Filename.Contains("sppmain.png") OrElse item.Filename.Contains("sppblck.png") Then
                        ' Don't show the splash screen and black background images in our playlist editor
                        Continue While
                    End If

                    item.Filename = currentRow(0).Replace("file:///", "").Replace("/", "\")
                    item.Filename = item.Filename.Replace("%20", " ")
                    item.StartTime = currentRow(1)
                    item.EndTime = currentRow(2)
                    item.Repeat = currentRow(3) = "repeat"
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
        Dim startTime As String
        Dim endTime As String
        Dim playmode As String
        Dim sep As String = My.Settings.playlistSeperator
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)

        Using file As New IO.StreamWriter(filename, False, utf8WithoutBom)
            ' Add the splash screen and black screen images first
            filepath = Application.StartupPath() + "\sppmain.png"
            filepath = filepath.Replace("\", "/").Replace(" ", "%20")
            file.WriteLine("file:///" & filepath & sep & sep & sep & "repeat" & sep)

            filepath = Application.StartupPath() + "\sppblck.png"
            filepath = filepath.Replace("\", "/").Replace(" ", "%20")
            file.WriteLine("file:///" & filepath & sep & sep & sep & "repeat" & sep)

            For Each row As DataGridViewRow In Rows
                If row.Cells(0).Value <> "" Then
                    startTime = row.Cells(1).EditedFormattedValue
                    endTime = row.Cells(2).EditedFormattedValue
                    If CBool(row.Cells(3).EditedFormattedValue) Then
                        playmode = "repeat"
                    Else
                        playmode = "continue"
                    End If
                    filepath = row.Cells(0).Value.replace("\", "/")
                    filepath = filepath.Replace(" ", "%20")
                    file.WriteLine("file:///" & filepath & sep & startTime & sep & endTime & sep & playmode & sep)
                End If
            Next

            ' End with the black screen image
            filepath = Application.StartupPath() + "\sppblck.png"
            filepath = filepath.Replace("\", "/").Replace(" ", "%20")
            file.WriteLine("file:///" & filepath & sep & sep & sep & "repeat" & sep)

        End Using
    End Sub

    Public Sub BeginPlayback(filename As String)
        Dim args As String
        Dim keySequences() As String
        ' We use sendkeys to enable the StarPlayerPC VLC Lua extension once VLC has started.
        ' There is no direct key combination to enable a custom extension, so we ensure that
        ' our extension will be the final item on the View menu (by using the filename
        ' ~starplayerpc.lua) and send the keys Alt-i, Up, Enter.
        ' We send Enter first (and delay) to clear any initially notification that may remain
        ' and also give time for the StarPlayerPC extention to be loaded into the view menu.
        ' To begin playback we need to play twice (the first time enters the playlist, and
        ' the second begins playing the playlist). The VLC key to play does not expand the
        ' playlist, therefore we send ' ' (space) twice and hope the user has not reassigned
        ' this key. Before space works, we need to tab to give the playlist panel the focus.
        ' Finally we send 'f' to enter fullscreen.
        keySequences = {"~", "%i{UP}~{TAB}", " ", " ", "f"}

        ' Extensions cannot be enabled during playback, therefore we lauch VLC with --no-playlist-autostart.
        ' We set our own keys for Next and Back (and change Esc from exiting fullscreen to exiting VLC).
        ' Note that fullscreen can still be toggled using the 'f' key, even though Esc no longer leaves fullscreen.
        ' We also set the the toggle fullscreen key to the VLC default (f) to ensure that our sendkeys works correctly
        ' and set the mouse hide timeout to 0 ms to ensure the mouse pointer is not shown during playback
        ' Finally we set aspect ratio to the required 16:9, disable onscreen notifications and turn off messages (-q)
        args = "--no-playlist-autostart "
        args &= "--key-next ""Page Down"" --key-prev ""Page Up"" --key-leave-fullscreen Unset --key-quit Esc "
        args &= "--key-toggle-fullscreen f --mouse-hide-timeout=0 "
        args &= "--aspect-ratio=16:9 --qt-notification=0 --no-qt-bgcone --no-qt-updates-notif --no-osd --no-qt-fs-controller -q "

        For Each vlcpath As String In Split(My.Settings.vlcPath, "|")
            Try
                Dim pi As New ProcessStartInfo(vlcpath, args & """" & filename & """")
                Using vlc As New Process
                    vlc.StartInfo = pi
                    vlc.Start()
                    SetForegroundWindow(vlc.MainWindowHandle)
                    vlc.WaitForInputIdle()
                    For Each keys In keySequences
                        System.Threading.Thread.Sleep(500)
                        SendKeys.SendWait(keys)
                    Next
                End Using
                Exit For
            Catch ex As Exception
                ' Continue around loop
            End Try
        Next

    End Sub

    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(hWnd As IntPtr) As Boolean
    End Function

    ''' <summary>
    ''' Displays an open file dialog to choose the media file associated with the current playlist item/row
    ''' </summary>
    ''' <param name="rowIndex"></param>
    Public Sub ChoosePlaylistItem(rowIndex As Integer)
        Dim filename As String
        Dim result As Boolean

        Dim dlgPlaylistChooseFile As New OpenFileDialog()
        dlgPlaylistChooseFile.Filter = "All files|*.*|All video files|*.asf;*.avchd;*.avi;*.flv;*.mp4;*.mov;*.wmv;*.yuv|Advanced Systems Format|*.asf|Advanced Video Codec High Definition|*.avchd|Audio Video Interleave|*.avi|Flash video|*.flv|MPEG4|*.mp4|QuickTime|*.mov|Windows Media Video|*.wmv|Raw video format|*.yuv"
        dlgPlaylistChooseFile.FilterIndex = 2
        dlgPlaylistChooseFile.RestoreDirectory = True

        dlgPlaylistChooseFile.FileName = ""
        result = dlgPlaylistChooseFile.ShowDialog()
        If result = True And dlgPlaylistChooseFile.FileName <> "" Then
            filename = dlgPlaylistChooseFile.FileName
            Rows(rowIndex).Cells(0).Value = filename
            If rowIndex + 1 = RowCount Then
                ' Notifying that the current cell contains data causes a new empty row to be added below
                NotifyCurrentCellDirty(True)
                NotifyCurrentCellDirty(False)
            End If
        End If
    End Sub

End Class
