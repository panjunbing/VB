Public Class 选课信息
    Private Conn As New ADODB.Connection
    Private Reco As New ADODB.Recordset

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '初始化列表
        Initialize()

        '当选课信息弹出框按下确定时
        If 选课信息弹出框.isOk = True Then

            '初始化
            ListView1.Clear()
            Initialize()


            Dim strScore As String = CStr(选课信息弹出框.score)
            Dim strLesson As String = 选课信息弹出框.lesson
            '连接数据库
            Dim sqlReco As String = "SELECT 学生表.学号,姓名,性别,课程名称,成绩 FROM 选课表,课程表,学生表 WHERE 学生表.学号=选课表.学号 AND 选课表.课程号=课程表.课程号 AND 课程表.课程名称='" + strLesson + "' AND 选课表.成绩>=" + strScore + " ORDER BY 成绩 DESC"
            Dim sqlConn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db1.mdb"

            Conn.Open(sqlConn)
            Reco.Open(sqlReco, Conn, 1, 1)

            '把信息添加入列表中
            Dim count As Integer
            count = 0
            While Reco.EOF = False
                ListView1.Items.Add(Reco.Fields.Item(0).Value)
                ListView1.Items(count).SubItems.Add(Reco.Fields.Item(1).Value)
                ListView1.Items(count).SubItems.Add(Reco.Fields.Item(2).Value)
                ListView1.Items(count).SubItems.Add(Reco.Fields.Item(3).Value)
                ListView1.Items(count).SubItems.Add(Reco.Fields.Item(4).Value)
                Reco.MoveNext()
                count += 1
            End While
            Reco.Close()
            Conn.Close()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        '当查询所有学生的课程成绩时
        '连接数据库
        Dim sqlReco As String = "SELECT 学生表.学号,姓名,性别,课程名称,成绩 FROM 选课表,课程表,学生表 WHERE 学生表.学号=选课表.学号 AND 选课表.课程号=课程表.课程号"
        Dim sqlConn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db1.mdb"

        Conn.Open(sqlConn)
        Reco.Open(sqlReco, Conn, 1, 1)

        Reco.MoveFirst()

        '初始化
        ListView1.Clear()
        Initialize()

        '把信息添加入列表中
        Dim count As Integer
        count = 0
        While Reco.EOF = False
            ListView1.Items.Add(Reco.Fields.Item(0).Value)
            ListView1.Items(count).SubItems.Add(Reco.Fields.Item(1).Value)
            ListView1.Items(count).SubItems.Add(Reco.Fields.Item(2).Value)
            ListView1.Items(count).SubItems.Add(Reco.Fields.Item(3).Value)
            ListView1.Items(count).SubItems.Add(Reco.Fields.Item(4).Value)
            Reco.MoveNext()
            count += 1
        End While
        Reco.Close()
        Conn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '当查询指定课程指定成绩的学生时
        选课信息弹出框.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '返回主菜单时
        Me.Close()
        主菜单.Show()
    End Sub

    Private Sub Initialize()
        ListView1.Columns.Add("学号", 50)
        ListView1.Columns.Add("姓名", 100)
        ListView1.Columns.Add("性别", 50)
        ListView1.Columns.Add("课程名称", 100)
        ListView1.Columns.Add("成绩", 50)
    End Sub

End Class