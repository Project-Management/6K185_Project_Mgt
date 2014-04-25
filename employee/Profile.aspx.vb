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
End Class
