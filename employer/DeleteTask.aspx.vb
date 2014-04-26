Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_DeleteTask
    Inherits System.Web.UI.Page

    Protected Sub No_Click(sender As Object, e As EventArgs) Handles No.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Response.Redirect("~/Employee/TaskDetails.aspx?TaskId=" & TaskId)

    End Sub

    Protected Sub Yes_Click(sender As Object, e As EventArgs) Handles Yes.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "DELETE FROM Task WHERE TaskId = '" & TaskId & "'"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.ExecuteNonQuery()
            myConnection.Close()
        End Using

        Response.Redirect("./ViewAllProjects.aspx")

    End Sub

End Class
