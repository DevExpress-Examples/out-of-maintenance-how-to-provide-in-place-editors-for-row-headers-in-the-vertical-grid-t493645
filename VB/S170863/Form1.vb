Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository

Namespace WindowsFormsApplication1
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            vGridControl1.DataSource = CreateTable(6)
            Dim riCheckEdit As New RepositoryItemCheckEdit()
            Dim TempRowInplaceEditorHelper1 As RowInplaceEditorHelper = New RowInplaceEditorHelper(vGridControl1.GetRowByFieldName("Check"), riCheckEdit)
            riCheckEdit.AllowFocused = False
            AddHandler riCheckEdit.EditValueChanged, AddressOf riCheckEdit_EditValueChanged
            Dim riColorEdit As New RepositoryItemColorEdit()
            Dim TempRowInplaceEditorHelper2 As RowInplaceEditorHelper = New RowInplaceEditorHelper(vGridControl1.GetRowByFieldName("Name"), riColorEdit)
            riColorEdit.ColorAlignment = HorzAlignment.Center
            AddHandler riColorEdit.EditValueChanged, AddressOf riColorEdit_EditValueChanged
        End Sub

        Private Sub riColorEdit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
                vGridControl1.GetRowByFieldName("Name").Appearance.BackColor2 = (TryCast(sender, ColorEdit)).Color
        End Sub

        Private Sub riCheckEdit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            For i As Integer = 0 To vGridControl1.RecordCount - 1
                vGridControl1.SetCellValue(vGridControl1.GetRowByFieldName("Check"), i, (TryCast(sender, CheckEdit)).Checked)
            Next i
        End Sub

        Private Function CreateTable(ByVal recordCount As Integer) As DataTable
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("Name", GetType(String))
            dataTable.Columns.Add("ID", GetType(Integer))
            dataTable.Columns.Add("Check", GetType(Boolean))
            dataTable.Columns.Add("Date", GetType(Date))
            For i As Integer = 0 To recordCount - 1
                dataTable.Rows.Add(New Object() { String.Format("Name{0}", i), i, (If(i Mod 2 = 1, True, False)), Date.Now.AddDays(i) })
            Next i
            Return dataTable
        End Function
    End Class
End Namespace