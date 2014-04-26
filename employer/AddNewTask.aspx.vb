Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_AddNewTask
    Inherits System.Web.UI.Page

    Protected Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Dim ProjectId As String
        ProjectId = Request.QueryString("ProjectId")

        Dim TaskName As String
        TaskName = tb_TaskName.Text

        Dim TaskDescription As String
        TaskDescription = tb_Description.Text

        Dim Finished As Integer = 0
        Dim Reject As String = "N"

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "INSERT INTO [Task] ([TaskName], [TaskDescription], [ProjectId], [Finished], [Reject]) VALUES (@TaskName, @TaskDescription, @ProjectId, @Finished, @Reject)"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.Parameters.Add(New SqlParameter("@TaskName", TaskName))
            myCommand.Parameters.Add(New SqlParameter("@TaskDescription", TaskDescription))
            myCommand.Parameters.Add(New SqlParameter("@ProjectId", ProjectId))
            myCommand.Parameters.Add(New SqlParameter("@Finished", Finished))
            myCommand.Parameters.Add(New SqlParameter("@Reject", Reject))

            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Using

        Response.Redirect("./ProjectDetails.aspx?ProjectId=" & ProjectId)
    End Sub

    Protected Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Dim ProjectId As String
        ProjectId = Request.QueryString("ProjectId")

        Response.Redirect("./ProjectDetails.aspx?ProjectId=" & ProjectId)
    End Sub
End Class
