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

End Class
