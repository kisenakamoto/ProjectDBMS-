Imports System.Data.OleDb
Public Class Inventory
    Public connection As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|datadirectory|\Database.accdb;persist security info=false "
    Public cn As New OleDbConnection
    Dim sql As String = ""
    Dim p As Integer
    Dim k As New query
    Dim a As Boolean = False

    Function loadDGV()
        DataGridView1.Rows.Clear()
        cn.ConnectionString = connection
        sql = ("select * from product_data")
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
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDGV()
    End Sub
    Function search()
        cn.ConnectionString = connection
        sql = ("select * from product_data where product_no like '%" & TextBox5.Text & "%'")
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

    Function search1()
        cn.ConnectionString = connection
        sql = ("select * from product_data where product_no like '%" & TextBox1.Text & "%'")
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

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        DataGridView1.Rows.Clear()
        search()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        p = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        ComboBox1.Text = DataGridView1.Item(2, i).Value
        TextBox3.Text = DataGridView1.Item(3, i).Value
        TextBox4.Text = DataGridView1.Item(4, i).Value


    End Sub

    Function clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

        ComboBox1.SelectedItem = Nothing

        Return 0
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clear()
    End Sub

    Function addToDB()
        k.open("insert into product_data values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')")
        Return 0
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        search1()
        If a = True Then
            MsgBox("Product no. already exist.")
            a = False
        Else
            addToDB()
            MsgBox("Succesfully added!")
            clear()
            loadDGV()
        End If
    End Sub

    Function updateDB()
        k.open("UPDATE [product_data] SET [Product_Name] ='" & TextBox2.Text & "', [Category] = '" & ComboBox1.Text & "' , [stocks] = '" & TextBox3.Text & "' , [price] = '" & TextBox4.Text & "'  WHERE [product_no] = '" & TextBox1.Text & "'")
        Return 0
    End Function

    Function deleteDB()
        k.open("delete from product_data where product_no='" & TextBox1.Text & "'")
        Return 0
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Or TextBox3.Text.Trim = "" Or ComboBox1.Text.Trim = "" Or TextBox4.Text.Trim = "" Then
            MsgBox("Incomplete information !")
        Else

            updateDB()
            MsgBox("Updated!")
            clear()
            loadDGV()

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Or TextBox3.Text.Trim = "" Or ComboBox1.Text.Trim = "" Or TextBox4.Text.Trim = "" Then
            MsgBox("Select entry to be deleted !")
        Else

            deleteDB()
            MsgBox("Deleted!")
            clear()
            loadDGV()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox4.KeyPress, TextBox3.KeyPress, TextBox5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class