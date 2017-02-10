﻿Public NotInheritable Class frmSplash
    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TopMost = True

        'Set up the dialog text at runtime according to the application's assembly information.  

        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright

    End Sub

    Private Sub frmSplash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainLayoutPanel.Click, Version.Click, Copyright.Click, ApplicationTitle.Click
        Hide()
    End Sub

    Private Sub frmSplash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Hide()
    End Sub
End Class
