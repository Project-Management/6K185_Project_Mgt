Imports System.Web.Security
Imports System.Web.Security.Roles
Imports System.Web.Security.Membership
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql

Partial Class employer_EmployeeDetails
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim EmployeeId As String
        EmployeeId = Request.QueryString("UserId")

        Try

            Dim connectionStr1 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim conn1 As New SqlConnection(connectionStr1)
            conn1.Open()
            Dim comm1 As New SqlCommand("SELECT Task.* FROM Task WHERE (EmployeeId = '" & EmployeeId & "')", conn1)
            Dim reader1 As SqlDataReader = comm1.ExecuteReader()
            Dim TaskId As String
            reader1.Read()
            TaskId = Convert.ToString(reader1("TaskId"))
            conn1.Close()

            Table1.Visible = True
            Repeater1.Visible = True
            lblTitle.Text = "Task in progress"

        Catch ex As Exception

            Table1.Visible = False
            Repeater1.Visible = False
            lblTitle.Text = "No task in progress"

        End Try

    End Sub

End Class
