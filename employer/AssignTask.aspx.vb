Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_AssignTask
    Inherits System.Web.UI.Page

    Protected Sub No_Click(sender As Object, e As EventArgs) Handles No.Click

        Dim TaskId As Integer
        TaskId = CType(Session.Item("field1"), Integer)
        Response.Redirect("~/Employee/TaskDetails.aspx?TaskId=" & TaskId)

    End Sub

    Protected Sub Yes_Click(sender As Object, e As EventArgs) Handles Yes.Click

        Dim EmployeeId As String
        EmployeeId = Request.QueryString("UserId")
        Dim TaskId As Integer
        TaskId = CType(Session.Item("field1"), Integer)

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "Update Task set EmployeeId = @EmployeeId WHERE (TaskId = '" & TaskId & "')"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.Parameters.AddWithValue("@EmployeeId", EmployeeId)

            myCommand.ExecuteNonQuery()
            myConnection.Close()
        End Using

        Response.Redirect("~/employee/TaskDetails.aspx?TaskId=" & TaskId)

    End Sub

End Class
