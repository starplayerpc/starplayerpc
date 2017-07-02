<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditor))
        Me.mnuMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.VideoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAndPlaybackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettingsPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpContents = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.grdPlaylist = New StarPlayerPC.Playlist()
        Me.TrackFilename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrackStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrackEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrackRepeat = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.mnuCellContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuChooseVideo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoveRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsertNewRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsertRowAbove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsertRowBelow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMenuStrip.SuspendLayout()
        CType(Me.grdPlaylist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuCellContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMenuStrip
        '
        Me.mnuMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.VideoToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mnuMenuStrip.Name = "mnuMenuStrip"
        Me.mnuMenuStrip.Size = New System.Drawing.Size(721, 24)
        Me.mnuMenuStrip.TabIndex = 2
        Me.mnuMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileNew, Me.mnuFileOpen, Me.mnuFileSaveAs, Me.mnuFileExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Name = "mnuFileNew"
        Me.mnuFileNew.Size = New System.Drawing.Size(114, 22)
        Me.mnuFileNew.Text = "New"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Name = "mnuFileOpen"
        Me.mnuFileOpen.Size = New System.Drawing.Size(114, 22)
        Me.mnuFileOpen.Text = "Open"
        '
        'mnuFileSaveAs
        '
        Me.mnuFileSaveAs.Name = "mnuFileSaveAs"
        Me.mnuFileSaveAs.Size = New System.Drawing.Size(114, 22)
        Me.mnuFileSaveAs.Text = "Save As"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(114, 22)
        Me.mnuFileExit.Text = "Exit"
        '
        'VideoToolStripMenuItem
        '
        Me.VideoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveAndPlaybackToolStripMenuItem})
        Me.VideoToolStripMenuItem.Name = "VideoToolStripMenuItem"
        Me.VideoToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.VideoToolStripMenuItem.Text = "Video"
        '
        'SaveAndPlaybackToolStripMenuItem
        '
        Me.SaveAndPlaybackToolStripMenuItem.Name = "SaveAndPlaybackToolStripMenuItem"
        Me.SaveAndPlaybackToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SaveAndPlaybackToolStripMenuItem.Text = "Save and Playback"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettingsPreferences})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        Me.SettingsToolStripMenuItem.Visible = False
        '
        'mnuSettingsPreferences
        '
        Me.mnuSettingsPreferences.Name = "mnuSettingsPreferences"
        Me.mnuSettingsPreferences.Size = New System.Drawing.Size(135, 22)
        Me.mnuSettingsPreferences.Text = "Preferences"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpAbout, Me.mnuHelpContents})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(152, 22)
        Me.mnuHelpAbout.Text = "About"
        '
        'mnuHelpContents
        '
        Me.mnuHelpContents.Name = "mnuHelpContents"
        Me.mnuHelpContents.Size = New System.Drawing.Size(152, 22)
        Me.mnuHelpContents.Text = "Contents"
        Me.mnuHelpContents.Visible = False
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "StarPlayerPC.chm"
        '
        'grdPlaylist
        '
        Me.grdPlaylist.AllowDrop = True
        Me.grdPlaylist.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grdPlaylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPlaylist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TrackFilename, Me.TrackStart, Me.TrackEnd, Me.TrackRepeat})
        Me.grdPlaylist.ContextMenuRowIndex = 0
        Me.grdPlaylist.Location = New System.Drawing.Point(0, 27)
        Me.grdPlaylist.Name = "grdPlaylist"
        Me.grdPlaylist.Size = New System.Drawing.Size(709, 359)
        Me.grdPlaylist.TabIndex = 6
        '
        'TrackFilename
        '
        Me.TrackFilename.HeaderText = "Filename"
        Me.TrackFilename.Name = "TrackFilename"
        Me.TrackFilename.ReadOnly = True
        Me.TrackFilename.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TrackFilename.Width = 450
        '
        'TrackStart
        '
        Me.TrackStart.HeaderText = "Start"
        Me.TrackStart.Name = "TrackStart"
        Me.TrackStart.Width = 75
        '
        'TrackEnd
        '
        Me.TrackEnd.HeaderText = "End"
        Me.TrackEnd.Name = "TrackEnd"
        Me.TrackEnd.ToolTipText = "Leave empty to play to the end of the file"
        Me.TrackEnd.Width = 75
        '
        'TrackRepeat
        '
        Me.TrackRepeat.HeaderText = "Repeat"
        Me.TrackRepeat.Name = "TrackRepeat"
        Me.TrackRepeat.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TrackRepeat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TrackRepeat.ToolTipText = "Repeat Track"
        Me.TrackRepeat.Width = 60
        '
        'mnuCellContext
        '
        Me.mnuCellContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuChooseVideo, Me.mnuRemoveRow, Me.mnuInsertNewRow})
        Me.mnuCellContext.Name = "ContextMenuStrip1"
        Me.mnuCellContext.Size = New System.Drawing.Size(166, 70)
        '
        'mnuChooseVideo
        '
        Me.mnuChooseVideo.Name = "mnuChooseVideo"
        Me.mnuChooseVideo.Size = New System.Drawing.Size(165, 22)
        Me.mnuChooseVideo.Text = "Choose video file"
        '
        'mnuRemoveRow
        '
        Me.mnuRemoveRow.Name = "mnuRemoveRow"
        Me.mnuRemoveRow.Size = New System.Drawing.Size(165, 22)
        Me.mnuRemoveRow.Text = "Remove row"
        '
        'mnuInsertNewRow
        '
        Me.mnuInsertNewRow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInsertRowAbove, Me.mnuInsertRowBelow})
        Me.mnuInsertNewRow.Name = "mnuInsertNewRow"
        Me.mnuInsertNewRow.Size = New System.Drawing.Size(165, 22)
        Me.mnuInsertNewRow.Text = "Insert new row"
        '
        'mnuInsertRowAbove
        '
        Me.mnuInsertRowAbove.Name = "mnuInsertRowAbove"
        Me.mnuInsertRowAbove.Size = New System.Drawing.Size(161, 22)
        Me.mnuInsertRowAbove.Text = "Insert row above"
        '
        'mnuInsertRowBelow
        '
        Me.mnuInsertRowBelow.Name = "mnuInsertRowBelow"
        Me.mnuInsertRowBelow.Size = New System.Drawing.Size(161, 22)
        Me.mnuInsertRowBelow.Text = "Insert row below"
        '
        'frmEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 387)
        Me.Controls.Add(Me.grdPlaylist)
        Me.Controls.Add(Me.mnuMenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuMenuStrip
        Me.MinimumSize = New System.Drawing.Size(410, 220)
        Me.Name = "frmEditor"
        Me.mnuMenuStrip.ResumeLayout(False)
        Me.mnuMenuStrip.PerformLayout()
        CType(Me.grdPlaylist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuCellContext.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuFileOpen As ToolStripMenuItem
    Friend WithEvents mnuFileSaveAs As ToolStripMenuItem
    Friend WithEvents mnuFileExit As ToolStripMenuItem
    Friend WithEvents mnuFileNew As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSettingsPreferences As ToolStripMenuItem
    Friend WithEvents mnuHelpContents As ToolStripMenuItem
    Friend WithEvents grdPlaylist As Playlist
    Friend WithEvents HelpProvider1 As HelpProvider
    Friend WithEvents VideoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAndPlaybackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuCellContext As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RemoveRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InsertRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DuplicateRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents InsertRowAboveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuChooseVideo As ToolStripMenuItem
    Friend WithEvents mnuRemoveRow As ToolStripMenuItem
    Friend WithEvents mnuInsertNewRow As ToolStripMenuItem
    Friend WithEvents mnuInsertRowBelow As ToolStripMenuItem
    Friend WithEvents mnuInsertRowAbove As ToolStripMenuItem
    Friend WithEvents TrackFilename As DataGridViewTextBoxColumn
    Friend WithEvents TrackStart As DataGridViewTextBoxColumn
    Friend WithEvents TrackEnd As DataGridViewTextBoxColumn
    Friend WithEvents TrackRepeat As DataGridViewCheckBoxColumn
End Class
