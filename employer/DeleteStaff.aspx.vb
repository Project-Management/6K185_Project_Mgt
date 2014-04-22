Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_Delete
    Inherits System.Web.UI.Page

    Protected Sub No_Click(sender As Object, e As EventArgs) Handles No.Click

        Dim UserId As String
        UserId = Request.QueryString("UserId")

        Response.Redirect("./EditProfile.aspx?UserId=" & UserId)

    End Sub

    Protected Sub Yes_Click(sender As Object, e As EventArgs) Handles Yes.Click

        Dim UserId As String
        UserId = Request.QueryString("UserId")

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "DELETE FROM aspnet_Users WHERE UserId = '" & UserId & "'"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.ExecuteNonQuery()
            myConnection.Close()
        End Using

        Response.Redirect("./ViewAllEmployees.aspx?UserId=" & UserId)

    End Sub
End Class
