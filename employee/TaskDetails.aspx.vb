Imports System.Web.Security
Imports System.Web.Security.Roles
Imports System.Web.Security.Membership
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql

Partial Class employee_TaskDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")
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

        Dim connectionStr As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn As New SqlConnection(connectionStr)
        conn.Open()
        Dim comm As New SqlCommand("SELECT Task.* FROM Task WHERE (TaskId = '" & TaskId & "')", conn)
        Dim reader As SqlDataReader = comm.ExecuteReader()
        Dim TaskName As String
        Dim TaskDescription As String
        Dim ProjectId As String
        Dim EmployeeId As String
        Dim Finished As String
        reader.Read()
        TaskName = Convert.ToString(reader("TaskName"))
        TaskDescription = Convert.ToString(reader("TaskDescription"))
        ProjectId = Convert.ToString(reader("ProjectId"))
        EmployeeId = Convert.ToString(reader("EmployeeId"))
        Finished = Convert.ToString(reader("Finished"))
        conn.Close()
        lblTaskName.Text = TaskName
        lblTaskDescription.Text = "<strong>Goal: </strong>" & TaskDescription

        Dim connectionStr1 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn1 As New SqlConnection(connectionStr1)
        conn1.Open()
        Dim comm1 As New SqlCommand("SELECT Project.* FROM Project WHERE (ProjectId = '" & ProjectId & "')", conn1)
        Dim reader1 As SqlDataReader = comm1.ExecuteReader()
        Dim ProjectName As String
        Dim ProjectDescription As String
        reader1.Read()
        ProjectName = Convert.ToString(reader1("ProjectName"))
        ProjectDescription = Convert.ToString(reader1("ProjectDescription"))
        conn1.Close()
        lblProjectName.Text = ProjectName



        If Finished = 0 Then

            If UserId = "71e09b16-bfe6-4ffe-8676-06978100992d" Or UserId = "34be58a1-2261-43be-b4da-a6a090b6a85b" Then

                If EmployeeId = "" Then

                    btnApprove.Visible = False
                    btnTake.Visible = False
                    btnAbandon.Visible = False
                    FileUpload1.Visible = False
                    Repeater1.Visible = False
                    btnUpload.Visible = False
                    btnDeny.Visible = False
                    lblStatus.Text = "<strong>Nobody is currently working on this task.</strong>"
                    btnAssign.Visible = True
                Else

                    Try

                        Dim connectionStr2 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                        Dim conn2 As New SqlConnection(connectionStr2)
                        conn2.Open()
                        Dim comm2 As New SqlCommand("SELECT * FROM TaskFiles WHERE (TaskId = '" & TaskId & "')", conn2)
                        Dim reader2 As SqlDataReader = comm2.ExecuteReader()
                        reader2.Read()
                        Dim files As String
                        files = Convert.ToString(reader2("TaskFiles"))
                        conn2.Close()
                        Dim connectionStr3 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                        Dim conn3 As New SqlConnection(connectionStr3)
                        conn3.Open()
                        Dim comm3 As New SqlCommand("SELECT * FROM StaffInfo WHERE (UserId = '" & EmployeeId & "')", conn3)
                        Dim reader3 As SqlDataReader = comm3.ExecuteReader()
                        Dim FirstName As String
                        Dim MiddleName As String
                        Dim LastName As String
                        reader3.Read()
                        FirstName = Convert.ToString(reader3("FirstName"))
                        MiddleName = Convert.ToString(reader3("MiddleName"))
                        LastName = Convert.ToString(reader3("LastName"))
                        conn3.Close()
                        Dim Name As String = FirstName & " " & LastName

                        Dim connectionStr4 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                        Dim conn4 As New SqlConnection(connectionStr4)
                        conn4.Open()
                        Dim comm4 As New SqlCommand("SELECT * FROM Task WHERE (TaskId = '" & TaskId & "')", conn4)
                        Dim reader4 As SqlDataReader = comm4.ExecuteReader()
                        reader4.Read()
                        Dim Reject As String
                        Reject = Convert.ToString(reader4("Reject"))
                        conn4.Close()

                        If Reject = "N" Then

                            btnApprove.Visible = True
                            btnDeny.Visible = True
                            FileUpload1.Visible = False
                            btnTake.Visible = False
                            btnAbandon.Visible = False
                            Repeater1.Visible = True
                            btnUpload.Visible = False
                            lblStatus.Text = "<strong>This task has been completed by " & Name & ". <br /><br />Please check the new uploaded file.</strong>"
                            btnAssign.Visible = False

                        ElseIf Reject = "Y" Then

                            btnApprove.Visible = True
                            btnDeny.Visible = False
                            FileUpload1.Visible = False
                            btnTake.Visible = False
                            btnAbandon.Visible = False
                            Repeater1.Visible = True
                            btnUpload.Visible = False
                            lblStatus.Text = "<strong>This task has taken by " & Name & ". <br /><br />No new files uploaded yet.</strong>"
                            btnAssign.Visible = False

                        End If

                    Catch ex As Exception

                        Dim connectionStr3 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                        Dim conn3 As New SqlConnection(connectionStr3)
                        conn3.Open()
                        Dim comm3 As New SqlCommand("SELECT * FROM StaffInfo WHERE (UserId = '" & EmployeeId & "')", conn3)
                        Dim reader3 As SqlDataReader = comm3.ExecuteReader()
                        Dim FirstName As String
                        Dim MiddleName As String
                        Dim LastName As String
                        reader3.Read()
                        FirstName = Convert.ToString(reader3("FirstName"))
                        MiddleName = Convert.ToString(reader3("MiddleName"))
                        LastName = Convert.ToString(reader3("LastName"))
                        conn3.Close()
                        Dim Name As String = FirstName & " " & LastName

                        btnApprove.Visible = False
                        FileUpload1.Visible = False
                        btnTake.Visible = False
                        btnAbandon.Visible = False
                        Repeater1.Visible = True
                        btnUpload.Visible = False
                        btnDeny.Visible = False
                        lblStatus.Text = "<strong>This task has been taken by " & Name & ". <br /><br />No files have been uploaded to this task yet.</strong>"
                        btnAssign.Visible = False

                    End Try

                End If

            Else

                If EmployeeId = UserId Then

                    Dim connectionStr2 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                    Dim conn2 As New SqlConnection(connectionStr2)
                    conn2.Open()
                    Dim comm2 As New SqlCommand("SELECT * FROM Task WHERE (TaskId = '" & TaskId & "')", conn2)
                    Dim reader2 As SqlDataReader = comm2.ExecuteReader()
                    reader2.Read()
                    Dim Reject As String
                    Reject = Convert.ToString(reader2("Reject"))
                    conn2.Close()

                    If Reject = "N" Then

                        Dim connectionStr3 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                        Dim conn3 As New SqlConnection(connectionStr3)
                        conn3.Open()
                        Dim comm3 As New SqlCommand("SELECT StaffInfo.* FROM StaffInfo WHERE (UserId = '" & EmployeeId & "')", conn3)
                        Dim reader3 As SqlDataReader = comm3.ExecuteReader()
                        Dim FirstName As String
                        Dim MiddleName As String
                        Dim LastName As String
                        reader3.Read()
                        FirstName = Convert.ToString(reader3("FirstName"))
                        MiddleName = Convert.ToString(reader3("MiddleName"))
                        LastName = Convert.ToString(reader3("LastName"))
                        conn3.Close()
                        Dim Name As String = FirstName & " " & LastName
                        btnApprove.Visible = False
                        FileUpload1.Visible = True
                        btnTake.Visible = False
                        btnAbandon.Visible = True
                        Repeater1.Visible = True
                        btnUpload.Visible = True
                        btnDeny.Visible = False
                        lblStatus.Text = "Welcome back, " & Name & "."
                        btnAssign.Visible = False

                    ElseIf Reject = "Y" Then

                        Dim connectionStr3 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                        Dim conn3 As New SqlConnection(connectionStr3)
                        conn3.Open()
                        Dim comm3 As New SqlCommand("SELECT StaffInfo.* FROM StaffInfo WHERE (UserId = '" & EmployeeId & "')", conn3)
                        Dim reader3 As SqlDataReader = comm3.ExecuteReader()
                        Dim FirstName As String
                        Dim MiddleName As String
                        Dim LastName As String
                        reader3.Read()
                        FirstName = Convert.ToString(reader3("FirstName"))
                        MiddleName = Convert.ToString(reader3("MiddleName"))
                        LastName = Convert.ToString(reader3("LastName"))
                        conn3.Close()
                        Dim Name As String = FirstName & " " & LastName
                        btnApprove.Visible = False
                        FileUpload1.Visible = True
                        btnTake.Visible = False
                        btnAbandon.Visible = True
                        Repeater1.Visible = True
                        btnUpload.Visible = True
                        btnDeny.Visible = False
                        lblStatus.Text = "<strong>Welcome back, " & Name & ".<br /><br />The file you uploaded has been denied by your manager.</strong>"
                        btnAssign.Visible = False

                    End If

                ElseIf EmployeeId = "" Then

                    btnApprove.Visible = False
                    btnTake.Visible = True
                    btnAbandon.Visible = False
                    FileUpload1.Visible = False
                    Repeater1.Visible = False
                    btnUpload.Visible = False
                    btnDeny.Visible = False
                    lblStatus.Text = "<strong>This task is available for you. <br /><br />Click the button below to take the task.</strong>"
                    btnAssign.Visible = False

                Else

                    btnApprove.Visible = False
                    btnAbandon.Visible = False
                    btnTake.Visible = False
                    FileUpload1.Visible = False
                    Repeater1.Visible = False
                    btnUpload.Visible = False
                    btnDeny.Visible = False
                    btnAssign.Visible = False

                    Dim connectionStr2 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                    Dim conn2 As New SqlConnection(connectionStr2)
                    conn2.Open()
                    Dim comm2 As New SqlCommand("SELECT StaffInfo.* FROM StaffInfo WHERE (UserId = '" & EmployeeId & "')", conn2)
                    Dim reader2 As SqlDataReader = comm2.ExecuteReader()
                    Dim FirstName As String
                    Dim MiddleName As String
                    Dim LastName As String
                    reader2.Read()
                    FirstName = Convert.ToString(reader2("FirstName"))
                    MiddleName = Convert.ToString(reader2("MiddleName"))
                    LastName = Convert.ToString(reader2("LastName"))
                    conn2.Close()
                    Dim Name As String = FirstName & " " & LastName
                    lblStatus.Text = "<strong>This task was taken by " & Name & ".</strong>"


                End If

            End If

        Else

            Dim connectionStr2 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim conn2 As New SqlConnection(connectionStr2)
            conn2.Open()
            Dim comm2 As New SqlCommand("SELECT StaffInfo.* FROM StaffInfo WHERE (UserId = '" & EmployeeId & "')", conn2)
            Dim reader2 As SqlDataReader = comm2.ExecuteReader()
            Dim FirstName As String
            Dim MiddleName As String
            Dim LastName As String
            reader2.Read()
            FirstName = Convert.ToString(reader2("FirstName"))
            MiddleName = Convert.ToString(reader2("MiddleName"))
            LastName = Convert.ToString(reader2("LastName"))
            conn2.Close()
            Dim Name As String = FirstName & " " & LastName
            lblStatus.Text = "<strong>This task has been completed by " & Name & ".</strong>"
            btnApprove.Visible = False
            btnDeny.Visible = False
            FileUpload1.Visible = False
            btnTake.Visible = False
            btnAbandon.Visible = False
            Repeater1.Visible = True
            btnUpload.Visible = False
            btnAssign.Visible = False

        End If


    End Sub

    Protected Sub btnTake_Click(sender As Object, e As EventArgs) Handles btnTake.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")
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

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "Update Task set EmployeeId = @EmployeeId WHERE (TaskId = '" & TaskId & "')"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.Parameters.AddWithValue("@EmployeeId", UserId)

            myCommand.ExecuteNonQuery()
            myConnection.Close()
        End Using

        Response.Redirect("./TaskDetails.aspx?TaskId=" & TaskId)

    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

        If FileUpload1.HasFile Then

            Dim TaskId As String
            TaskId = Request.QueryString("TaskId")
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

            Dim filepath As String = Server.MapPath("~\taskFiles\" & UserId)

            If System.IO.Directory.Exists(filepath) = False Then

                System.IO.Directory.CreateDirectory(filepath)

            End If

            Dim fileName As String = FileUpload1.FileName

            If FileUpload1.HasFile Then
                Try
                    FileUpload1.SaveAs(filepath & "\" & fileName)
                Catch ex As Exception
                End Try
            End If

            Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim updateSql As String = "INSERT INTO [TaskFiles] ([TaskId], [TaskFiles], [EmployeeId]) VALUES (@TaskId, @TaskFiles, @EmployeeId)"

            Using myConnection As New SqlConnection(connectionstring)
                myConnection.Open()
                Dim myCommand As New SqlCommand(updateSql, myConnection)

                myCommand.Parameters.AddWithValue("@TaskId", TaskId)
                myCommand.Parameters.AddWithValue("@TaskFiles", fileName)
                myCommand.Parameters.AddWithValue("@EmployeeId", UserId)

                myCommand.ExecuteNonQuery()
                myConnection.Close()

            End Using

            Dim connectionstring1 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim updateSql1 As String = "Update Task set Reject = 'N' WHERE (TaskId = '" & TaskId & "')"

            Using myConnection1 As New SqlConnection(connectionstring1)
                myConnection1.Open()
                Dim myCommand1 As New SqlCommand(updateSql1, myConnection1)
                myCommand1.ExecuteNonQuery()
                myConnection1.Close()

            End Using


            Response.Redirect("./TaskDetails.aspx?TaskId=" & TaskId)

        End If

    End Sub

    Protected Sub btnAbandon_Click(sender As Object, e As EventArgs) Handles btnAbandon.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "Update Task set EmployeeId = NULL, reject = 'N' WHERE (TaskId = '" & TaskId & "')"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Using

        Response.Redirect("./TaskDetails.aspx?TaskId=" & TaskId)

    End Sub

    Protected Sub lblProjectName_Click(sender As Object, e As EventArgs) Handles lblProjectName.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Dim connectionStr0 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn0 As New SqlConnection(connectionStr0)
        conn0.Open()
        Dim comm0 As New SqlCommand("SELECT ProjectId FROM Task WHERE (TaskId = '" & TaskId & "')", conn0)
        Dim reader0 As SqlDataReader = comm0.ExecuteReader()
        Dim ProjectId As String
        reader0.Read()
        ProjectId = Convert.ToString(reader0("ProjectId"))
        conn0.Close()

        Response.Redirect("./ProjectDetails.aspx?ProjectId=" & ProjectId)

    End Sub

    Protected Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "Update Task set Finished = 1, Reject = 'N' WHERE (TaskId = '" & TaskId & "')"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Using

        Response.Redirect("./TaskDetails.aspx?TaskId=" & TaskId)

    End Sub

    Protected Sub btnDeny_Click(sender As Object, e As EventArgs) Handles btnDeny.Click

        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "Update Task set Reject = 'Y' WHERE (TaskId = '" & TaskId & "')"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)
            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Using

        Response.Redirect("./TaskDetails.aspx?TaskId=" & TaskId)

    End Sub

    Protected Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        Dim TaskId As String
        TaskId = Request.QueryString("TaskId")

        Response.Redirect("~/employer/CheckEmployee.aspx?TaskId=" & TaskId)
    End Sub
End Class
