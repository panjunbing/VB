Public Class 选课信息弹出框
    Public isOk As Boolean = False
    Public lesson As String = vbNullString
    Public score As Double = 0

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("数据库")
        ComboBox1.Items.Add("数据结构")
        ComboBox1.Items.Add("计算机组成原理")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        isOk = True
        score = TextBox1.Text
        lesson = ComboBox1.Text

        选课信息.Show()
        Me.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        isOk = False
        选课信息.Show()
        Me.Close()
    End Sub

End Class