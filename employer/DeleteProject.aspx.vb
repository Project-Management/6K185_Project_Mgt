Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_Delete
    Inherits System.Web.UI.Page

    Protected Sub No_Click(sender As Object, e As EventArgs) Handles No.Click

        Dim ProjectId As String
        ProjectId = Request.QueryString("ProjectId")

        Response.Redirect("./ProjectDetails.aspx?ProjectId=" & ProjectId)

    End Sub

    Protected Sub Yes_Click(sender As Object, e As EventArgs) Handles Yes.Click

        Dim ProjectId As String
        ProjectId = Request.QueryString("ProjectId")

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "DELETE FROM Project WHERE ProjectId = '" & ProjectId & "'"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.ExecuteNonQuery()
            myConnection.Close()
        End Using

        Response.Redirect("./ViewAllProjects.aspx?ProjectId=" & ProjectId)

    End Sub
End Class
