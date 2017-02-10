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

''' <summary>
'''     DataGridViewDragDrop provided by http://stackoverflow.com/a/39799439/1624894
'''     CC-BY-SA
''' 
''' </summary>
Public Class DataGridViewDragDrop
    Inherits DataGridView

    Public Sub New()
        AllowDrop = True
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        Dim hitInfo As HitTestInfo = HitTest(e.X, e.Y)
        If e.Button = MouseButtons.Left AndAlso hitInfo.ColumnIndex = -1 AndAlso CanDragDropRow(hitInfo.RowIndex) Then
            DoDragDrop(Rows(hitInfo.RowIndex), DragDropEffects.Move)
        End If
    End Sub

    Protected Overrides Sub OnDragOver(e As DragEventArgs)
        MyBase.OnDragOver(e)

        Dim dataValid As Boolean = e.Data.GetData(GetType(DataGridViewRow)) IsNot Nothing
        e.Effect = IIf(dataValid AndAlso CanDragDropRow(GetRowIndex(e)), DragDropEffects.Move, DragDropEffects.None)
    End Sub

    Protected Overrides Sub OnDragDrop(e As DragEventArgs)
        MyBase.OnDragDrop(e)
        EndEdit()
        If e.Effect = DragDropEffects.Move Then
            Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
            Rows.Remove(dragRow)
            Rows.Insert(GetRowIndex(e), dragRow)

            ClearSelection()
            dragRow.Selected = True
        End If
    End Sub

    Private Function CanDragDropRow(ByVal rowIndex As Integer) As Boolean
        Return rowIndex >= 0 AndAlso rowIndex < NewRowIndex
    End Function

    Private Function GetRowIndex(ByVal e As DragEventArgs) As Integer
        Dim clientPos As Point = PointToClient(New Point(e.X, e.Y))
        Return HitTest(clientPos.X, clientPos.Y).RowIndex
    End Function
End Class