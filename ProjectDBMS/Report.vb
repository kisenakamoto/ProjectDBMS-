Imports System.Data.OleDb
Public Class Report
    Public connection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|datadirectory|\Database.accdb;persist security info=false "
    Public cn As New OleDbConnection
    Dim sql As String = ""
    Dim p As Integer
    Dim total As Integer
    Dim k As New query


    Function loadDGV()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from samp")
        cn.Open()
        Dim cmd As New OleDbCommand(Sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetInt32(4))
        End While
        For Each row As DataGridViewRow In DataGridView1.Rows
            total += row.Cells(4).Value
        Next
        Label2.Text = total
        cn.Close()
        Return 0
    End Function



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Sales.Show()
        Me.Close()
    End Sub

    Private Sub Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label5.Text = Format(Now, "MMM/dd/yyyy")
        loadDGV()
    End Sub
    Function delete()
        k.open("delete * from sale")
        Return 0
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        delete()
        Form2.Show()
        Me.Close()
    End Sub
End Class