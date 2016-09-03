Public Class 学生成绩信息弹出框
    Public isOk As Boolean = False
    Public sex As String = "男"
    Public age As Integer = 0
    Public avrageScore As Double = 0
    Private Sub 学生成绩信息弹出框_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("男")
        ComboBox1.Items.Add("女")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        isOk = True
        sex = ComboBox1.Text
        age = TextBox2.Text
        avrageScore = TextBox1.Text

        学生成绩信息.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        学生成绩信息.Show()
        Me.Close()
    End Sub

End Class