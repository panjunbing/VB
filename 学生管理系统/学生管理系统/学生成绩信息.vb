Imports System.Data.OleDb
Public Class 学生成绩信息

    Dim cn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet

    Private Conn As New ADODB.Connection
    Private Reco As New ADODB.Recordset

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '当学生成绩信息弹出框按下确定时
        If 学生成绩信息弹出框.isOk = True Then

            Dim strSex As String = 学生成绩信息弹出框.sex
            Dim strAge As String = CStr(学生成绩信息弹出框.age)
            Dim strAvrageScore As String = CStr(学生成绩信息弹出框.avrageScore)

            '连接数据库
            Dim sqlReco As String = "SELECT 学生成绩.学号,学生成绩.姓名,课程名称,成绩 FROM (平均成绩 INNER JOIN 学生成绩 ON 平均成绩.学号 = 学生成绩.学号) WHERE 成绩之平均值>=" + strAvrageScore + " AND 年龄>=" + strAge + " AND 性别='" + strSex + "'"
            Dim sqlConn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db1.mdb"

            Conn.Open(sqlConn)
            Reco.Open(sqlReco, Conn, 1, 1)

            DataGridView1.ClearSelection()

            '显示在DataGridView1中
            cn = New OleDbConnection(sqlConn)
            da = New OleDbDataAdapter(sqlReco, cn)
            ds = New DataSet
            da.Fill(ds, "学生成绩")
            DataGridView1.DataSource = ds.Tables(0)

            Reco.Close()
            Conn.Close()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        '连接数据库
        Dim sqlReco As String = "SELECT * FROM 平均成绩"
        Dim sqlConn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db1.mdb"

        Conn.Open(sqlConn)
        Reco.Open(sqlReco, Conn, 1, 1)

        DataGridView1.ClearSelection()

        '显示在DataGridView1中
        cn = New OleDbConnection(sqlConn)
        da = New OleDbDataAdapter(sqlReco, cn)
        ds = New DataSet
        da.Fill(ds, "学生表")
        DataGridView1.DataSource = ds.Tables(0)

        Reco.Close()
        Conn.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '按下条件查询学生成绩时
        学生成绩信息弹出框.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '按下返回时
        主菜单.Show()
        Me.Close()
    End Sub
End Class