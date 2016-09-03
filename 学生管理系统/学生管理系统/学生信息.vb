Public Class 学生信息
    Private Conn As New ADODB.Connection
    Private Reco As New ADODB.Recordset


    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Conn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db1.mdb")
        Reco.Open("Select * From 学生表", Conn, 1, 1)

        Reco.MoveFirst()
        printText()

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Reco.EOF = False Then
            Reco.MoveFirst()
        Else
            Reco.MoveNext()
        End If
        printText()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Reco.BOF = False Then
            Reco.MoveLast()
        Else
            Reco.MovePrevious()
        End If
        printText()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        主菜单.Show()
        Me.Close()
    End Sub

    Private Sub printText()
        TextBox1.Text = "xxxxxx"
        TextBox2.Text = "xxxxxx"
        TextBox3.Text = "xxxxxx"
        TextBox4.Text = "xxxxxx"
        TextBox5.Text = "xxxxxx"
        PictureBox1.Load("B:\pan\学生管理系统\学生管理系统\学生管理系统\bin\Debug\picture\IMG_0200.JPG")
    End Sub

End Class