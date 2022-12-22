Imports System.Data.OleDb
Public Class Sales
    Public connection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|datadirectory|\Database.accdb;persist security info=false "
    Public cn As New OleDbConnection
    Dim sql As String = ""
    Dim p As Integer
    Dim newStock As Integer
    Dim k As New query
    Dim now As DateTime = DateTime.Now


    Function loadDGV()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from product_query")
        cn.Open()
        Dim cmd As New OleDbCommand(sql, cn)
        Dim r As OleDbDataReader
        r = cmd.ExecuteReader
        While r.Read
            DataGridView1.Rows.Add(r.GetString(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4))
        End While
        cn.Close()
        Return 0
    End Function

    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label13.Text = now.ToLongDateString()
        loadDGV()
        clear()
    End Sub

    Function clear()
        Label7.Text = ""
        Label8.Text = ""
        Label9.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        TextBox5.Text = ""
        TextBox5.Enabled = False
        Button2.Enabled = False
        Return 0
    End Function

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        p = DataGridView1.CurrentRow.Index
        Label7.Text = DataGridView1.Item(0, i).Value
        Label8.Text = DataGridView1.Item(1, i).Value
        Label9.Text = DataGridView1.Item(2, i).Value
        Label10.Text = DataGridView1.Item(3, i).Value
        Label11.Text = DataGridView1.Item(4, i).Value

        TextBox5.Enabled = True
        TextBox5.Text = "0"
        Button2.Enabled = True

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clear()
    End Sub

    Function updateDB()
        k.open("UPDATE [product_data] SET [Product_Name] ='" & Label8.Text & "', [Category] = '" & Label9.Text & "' , [stocks] = '" & newStock & "' , [price] = '" & Label11.Text & "'  WHERE [product_no] = '" & Label7.Text & "'")
        Return 0
    End Function



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim stock As Integer = Label10.Text
        Dim sale As Integer = TextBox5.Text
        Dim price As Integer = Label11.Text
        Dim profit As Integer
        If TextBox5.Text.Trim = "0" Then
            MsgBox("Enter sale greater than 0.")
        ElseIf Label7.Text.Trim = "" Then
            MsgBox("Please select a product.")
        ElseIf stock >= sale Then

            MsgBox("Success")
            newStock = stock - sale
            profit = sale * price

            updateDB()
            k.open("insert into samp values('" & Label7.Text & "','" & Label8.Text & "','" & Label11.Text & "','" & sale & "','" & profit & "')")
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            p = DataGridView1.CurrentRow.Index

            DataGridView1.Rows.RemoveAt(p)
            clear()
        Else
            MsgBox("Not enough stock.")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Report.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class