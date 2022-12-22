Imports System.Data.OleDb
Public Class Form1
    Public connection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|datadirectory|\Database.accdb;persist security info=false "
    Public cn As New OleDbConnection
    Dim sql As String = ""
    Dim a As Boolean = False
    Function clear()
        TextBox1.Text = "Username"
        TextBox2.PasswordChar = ""
        TextBox2.Text = "Password"
        Label1.Text = ""
        Return 0
    End Function
    Function search()
        cn.ConnectionString = connection
        sql = ("select * from admin_tbl where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            a = True
        End While
        cn.Close()
        Return 0
    End Function
    Private Sub TextBox1_Click(ByVal sender As Object,
    ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Clear()
        Label1.Text = ""
    End Sub
    Private Sub TextBox2_Click(ByVal sender As Object,
    ByVal e As System.EventArgs) Handles TextBox2.Click
        TextBox2.Clear()
        TextBox2.PasswordChar = "*"
        Label1.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        search()
        If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Then
            Label1.Text = "Incomplete Information"
        ElseIf a = False Then
            Label1.Text = "Wrong username or password"
        Else
            a = False
            Label1.Text = ""
            MsgBox("Login successful!", MsgBoxStyle.Information, "Welcome")
            clear()
            Me.Hide()
            Form2.Show()


        End If
    End Sub

    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        TextBox2.Clear()
        TextBox2.PasswordChar = "*"
        Label1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
End Class
