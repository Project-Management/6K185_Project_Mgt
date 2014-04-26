Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_EditTask
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim TaskId As String
            TaskId = Request.QueryString("TaskId")

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim conn As New SqlConnection(connectionString)
            conn.Open()
            Dim comm As New SqlCommand("SELECT * FROM Task WHERE (TaskId = '" & TaskId & "')", conn)
            Dim reader As SqlDataReader = comm.ExecuteReader()

            reader.Read()
            tb_TaskName.Text = Convert.ToString(reader("TaskName"))
            tb_Description.Text = Convert.ToString(reader("TaskDescription"))
            conn.Close()
        End If
    End Sub

    Protected Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Dim TaskName As String = tb_TaskName.Text
        Dim TaskDescription As String = tb_Description.Text

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "Update Task set TaskName = @TaskName, TaskDescription = @TaskDescription WHERE (TaskId = '" & TaskId & "')"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.Parameters.AddWithValue("@TaskName", TaskName)
            myCommand.Parameters.AddWithValue("@TaskDescription", TaskDescription)

            myCommand.ExecuteNonQuery()
            myConnection.Close()
        End Using

        Response.Redirect("~/Employee/TaskDetails.aspx?TaskId=" & TaskId)

    End Sub

    Protected Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Response.Redirect("~/Employee/TaskDetails.aspx?TaskId=" & TaskId)

    End Sub

    Protected Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Response.Redirect("./DeleteTask.aspx?TaskId=" & TaskId)

    End Sub
End Class
