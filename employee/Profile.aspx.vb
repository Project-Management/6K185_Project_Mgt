Imports System.Web.Security
Imports System.Web.Security.Roles
Imports System.Web.Security.Membership
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql

Partial Class employee_Profile
    Inherits System.Web.UI.Page

    Protected Sub SqlDataSource1_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

        e.Command.Parameters(0).Value = User.Identity.Name

    End Sub

    Protected Sub SqlDataSource2_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting

        Dim UserName As String
        UserName = User.Identity.Name

        Dim connectionStr0 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn0 As New SqlConnection(connectionStr0)
        conn0.Open()
        Dim comm0 As New SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" & UserName & "')", conn0)
        Dim reader0 As SqlDataReader = comm0.ExecuteReader()
        Dim UserId As String
        reader0.Read()
        UserId = Convert.ToString(reader0("UserId"))
        conn0.Close()

        e.Command.Parameters(0).Value = UserId

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim UserName As String
        UserName = User.Identity.Name

        Dim connectionStr0 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn0 As New SqlConnection(connectionStr0)
        conn0.Open()
        Dim comm0 As New SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" & UserName & "')", conn0)
        Dim reader0 As SqlDataReader = comm0.ExecuteReader()
        Dim EmployeeId As String
        reader0.Read()
        EmployeeId = Convert.ToString(reader0("UserId"))
        conn0.Close()

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
            lblTitle.Text = "Task in Progress"

        Catch ex As Exception

            Table1.Visible = False
            Repeater1.Visible = False
            lblTitle.Text = "No task in progress"

        End Try

    End Sub
End Class
