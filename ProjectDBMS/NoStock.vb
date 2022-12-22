Imports System.Data.OleDb

Public Class NoStock
    Public connection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|datadirectory|\Database.accdb;persist security info=false "
    Public cn As New OleDbConnection
    Dim sql As String = ""

    Function loadDGV()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from outstock")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2), r.GetString(3))
        End While
        cn.Close()
        Return 0
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Products.Show()
        Me.Hide()
    End Sub

   
    Private Sub NoStock_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        loadDGV()
    End Sub
End Class