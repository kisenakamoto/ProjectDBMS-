Imports System.Data.OleDb
Public Class Products
    Public connection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|datadirectory|\Database.accdb;persist security info=false "
    Public cn As New OleDbConnection
    Dim sql As String = ""

    Function load1()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from muffins")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2))
        End While
        cn.Close()
        Return 0
    End Function

    Function load2()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from bars")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2))
        End While
        cn.Close()
        Return 0
    End Function

    Function load3()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from turnovers")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2))
        End While
        cn.Close()
        Return 0
    End Function

    Function load4()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from scones")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2))
        End While
        cn.Close()
        Return 0
    End Function

    Function load5()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from buns")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2))
        End While
        cn.Close()
        Return 0
    End Function

    Function load6()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from croissants")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2))
        End While
        cn.Close()
        Return 0
    End Function

    Function load7()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from danish")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2))
        End While
        cn.Close()
        Return 0
    End Function

    Function load8()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from allprod")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2))
        End While
        cn.Close()
        Return 0
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text.Trim = "" Then
            MsgBox("Select a category.", MsgBoxStyle.Information, "Notice")
        Else
            If ComboBox1.Text = "Muffins" Then
                load1()
            ElseIf ComboBox1.Text = "Bars" Then
                load2()
            ElseIf ComboBox1.Text = "Turnovers" Then
                load3()
            ElseIf ComboBox1.Text = "Scones" Then
                load4()
            ElseIf ComboBox1.Text = "Buns And Rolls" Then
                load5()
            ElseIf ComboBox1.Text = "Croissants" Then
                load6()
            ElseIf ComboBox1.Text = "Danish Pastries" Then
                load7()
            ElseIf ComboBox1.Text = "All" Then
                load8()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NoStock.Show()
        Me.Hide()
    End Sub
End Class