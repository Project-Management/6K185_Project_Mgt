Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class employee_ProjectDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ProjectId As String
        ProjectId = Request.QueryString("ProjectId")

        Dim connectionStr As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn As New SqlConnection(connectionStr)
        conn.Open()
        Dim comm As New SqlCommand("SELECT COUNT(*) FROM Task WHERE (ProjectId = '" & ProjectId & "')", conn)
        Dim reader As SqlDataReader = comm.ExecuteReader()
        reader.Read()
        Dim total As String
        total = CInt(reader(0))
        conn.Close()

        Dim connectionStr1 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn1 As New SqlConnection(connectionStr1)
        conn1.Open()
        Dim comm1 As New SqlCommand("SELECT COUNT(*) FROM Task WHERE (Finished = '" & 1 & "') AND (ProjectId = '" & ProjectId & "')", conn1)
        Dim reader1 As SqlDataReader = comm1.ExecuteReader()
        reader1.Read()
        Dim finished As String
        finished = CInt(reader1(0))
        conn1.Close()

        lbl_finished.Text = CStr(FormatPercent(CInt(finished) / CInt(total))) + vbCrLf + "Completed"
    End Sub
End Class
