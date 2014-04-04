Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_AddNewProject
    Inherits System.Web.UI.Page
    Private _additionalRowCount As Integer = 0
    Private _previousTexBoxID As Integer = -1
    Private _previousTexBoxID2 As Integer = -1
    Private targetTable As Table = Nothing

    Private Property Day() As Integer
        Get
            If (Not (Request.Form(ddlDay.UniqueID)) Is Nothing) Then
                Return Integer.Parse(Request.Form(ddlDay.UniqueID))
                Return Integer.Parse(Request.Form(ddlDay1.UniqueID))
            Else
                Return Integer.Parse(ddlDay.SelectedItem.Value)
                Return Integer.Parse(ddlDay1.SelectedItem.Value)
            End If
        End Get
        Set(ByVal value As Integer)
            Me.PopulateDay()
            ddlDay.ClearSelection()
            ddlDay.Items.FindByValue(value.ToString).Selected = True
            ddlDay1.ClearSelection()
            ddlDay1.Items.FindByValue(value.ToString).Selected = True
        End Set
    End Property

    Private Property Month() As Integer
        Get
            Return Integer.Parse(ddlMonth.SelectedItem.Value)
            Return Integer.Parse(ddlMonth1.SelectedItem.Value)
        End Get
        Set(ByVal value As Integer)
            Me.PopulateMonth()
            ddlMonth.ClearSelection()
            ddlMonth.Items.FindByValue(value.ToString).Selected = True
            ddlMonth1.ClearSelection()
            ddlMonth1.Items.FindByValue(value.ToString).Selected = True
        End Set
    End Property

    Private Property Year() As Integer
        Get
            Return Integer.Parse(ddlYear.SelectedItem.Value)
            Return Integer.Parse(ddlYear1.SelectedItem.Value)
        End Get
        Set(ByVal value As Integer)
            Me.PopulateYear()
            ddlYear.ClearSelection()
            ddlYear.Items.FindByValue(value.ToString).Selected = True
            ddlYear1.ClearSelection()
            ddlYear1.Items.FindByValue(value.ToString).Selected = True
        End Set
    End Property

    Public Property SelectedDate() As DateTime
        Get
            Try
                Return DateTime.Parse(Me.Month & "/" & Me.Day & "/" & Me.Year)
            Catch ex As Exception
                Return DateTime.MinValue
            End Try
        End Get
        Set(ByVal value As DateTime)
            If Not value.Equals(DateTime.MinValue) Then
                Me.Year = value.Year
                Me.Month = value.Month
                Me.Day = value.Day
            End If
        End Set
    End Property
    Private Sub PopulateDay()
        ddlDay.Items.Clear()
        ddlDay1.Items.Clear()
        Dim lt As ListItem = New ListItem
        lt.Text = "Day"
        lt.Value = "0"
        ddlDay.Items.Add(lt)
        ddlDay1.Items.Add(lt)
        Dim days As Integer = DateTime.DaysInMonth(Me.Year, Me.Month)
        Dim i As Integer = 1
        Do While (i <= days)
            lt = New ListItem
            lt.Text = i.ToString
            lt.Value = i.ToString
            ddlDay.Items.Add(lt)
            ddlDay1.Items.Add(lt)
            i = (i + 1)
        Loop
        ddlDay.Items.FindByValue(DateTime.Now.Day.ToString).Selected = True
        ddlDay1.Items.FindByValue(DateTime.Now.Day.ToString).Selected = True
    End Sub

    Private Sub PopulateMonth()
        ddlMonth.Items.Clear()
        ddlMonth1.Items.Clear()
        Dim lt As ListItem = New ListItem
        lt.Text = "Month"
        lt.Value = "0"
        ddlMonth.Items.Add(lt)
        ddlMonth1.Items.Add(lt)
        Dim i As Integer = 1
        Do While (i <= 12)
            lt = New ListItem
            lt.Text = Convert.ToDateTime((i.ToString + "/1/1900")).ToString("MMMM")
            lt.Value = i.ToString
            ddlMonth.Items.Add(lt)
            ddlMonth1.Items.Add(lt)
            i = (i + 1)
        Loop
        ddlMonth.Items.FindByValue(DateTime.Now.Month.ToString).Selected = True
        ddlMonth1.Items.FindByValue(DateTime.Now.Month.ToString).Selected = True
    End Sub

    Private Sub PopulateYear()
        ddlYear.Items.Clear()
        ddlYear1.Items.Clear()
        Dim lt As ListItem = New ListItem
        lt.Text = "Year"
        lt.Value = "0"
        ddlYear.Items.Add(lt)
        ddlYear1.Items.Add(lt)
        Dim i As Integer = DateTime.Now.Year
        Do While (i >= 1950)
            lt = New ListItem
            lt.Text = i.ToString
            lt.Value = i.ToString
            ddlYear.Items.Add(lt)
            ddlYear1.Items.Add(lt)
            i = (i - 1)
        Loop
        ddlYear.Items.FindByValue(DateTime.Now.Year.ToString).Selected = True
        ddlYear1.Items.FindByValue(DateTime.Now.Year.ToString).Selected = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If (Me.SelectedDate = DateTime.MinValue) Then
                Me.PopulateYear()
                Me.PopulateMonth()
                Me.PopulateDay()
            End If
        Else
        End If

        Try
            Dim UserName As String
            UserName = User.Identity.Name

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim conn As New SqlConnection(connectionString)
            conn.Open()
            Dim comm As New SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" & UserName & "')", conn)
            Dim reader As SqlDataReader = comm.ExecuteReader()
            Dim UserId As String
            reader.Read()
            UserId = Convert.ToString(reader("UserId"))

            Dim connectionString1 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim conn1 As New SqlConnection(connectionString1)
            conn1.Open()
            Dim comm1 As New SqlCommand("SELECT FirstName, MiddleName, LastName, DepartmentId FROM StaffInfo WHERE (UserId = '" & UserId & "')", conn1)
            Dim reader1 As SqlDataReader = comm1.ExecuteReader()
            Dim FirstName As String
            Dim MiddleName As String
            Dim LastName As String
            Dim DepartmentId As Integer
            reader1.Read()
            FirstName = Convert.ToString(reader1("FirstName"))
            MiddleName = Convert.ToString(reader1("MiddleName"))
            LastName = Convert.ToString(reader1("LastName"))
            DepartmentId = reader1("DepartmentId")
            tb_Employer.Text = FirstName & " " & MiddleName & " " & LastName

            Dim connectionString2 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim conn2 As New SqlConnection(connectionString2)
            conn2.Open()
            Dim comm2 As New SqlCommand("SELECT DepartmentName FROM Department WHERE (DepartmentId = '" & DepartmentId & "')", conn2)
            Dim reader2 As SqlDataReader = comm2.ExecuteReader()
            Dim DepartmentName As String
            reader2.Read()
            DepartmentName = Convert.ToString(reader2("DepartmentName"))
            tb_Department.Text = DepartmentName

            conn.Close()
            conn1.Close()
            conn2.Close()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click

        Dim connectionStr As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn As New SqlConnection(connectionStr)
        conn.Open()
        Dim comm As New SqlCommand("SELECT Id FROM NumberStorage WHERE (Name = 'Project')", conn)
        Dim reader As SqlDataReader = comm.ExecuteReader()
        Dim ProjectId As String
        reader.Read()
        ProjectId = reader("Id")
        conn.Close()

        ProjectId += 1

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim con As New SqlConnection(connectionString)
        con.Open()
        Dim command As New SqlCommand("UPDATE NumberStorage set Id = @Id WHERE Name = 'Project'", con)
        command.Parameters.Add("@Id", SqlDbType.Int).Value = ProjectId
        Command.ExecuteNonQuery()
        con.Close()

        Dim ProjectName As String = tb_ProjectName.Text
        Dim StartDate As String = ddlMonth.Text & "/" & ddlDay.Text & "/" & ddlYear.Text
        Dim EndDate As String = ddlMonth1.Text & "/" & ddlDay1.Text & "/" & ddlYear1.Text
        Dim ProjectDescription As String = tb_ProjectDescription.Text

        Dim UserName As String
        UserName = User.Identity.Name

        Dim connectionString0 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn0 As New SqlConnection(connectionString0)
        conn0.Open()
        Dim comm0 As New SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" & UserName & "')", conn0)
        Dim reader0 As SqlDataReader = comm0.ExecuteReader()
        Dim UserId As String
        reader0.Read()
        UserId = Convert.ToString(reader0("UserId"))

        Dim connectionString1 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim conn1 As New SqlConnection(connectionString1)
        conn1.Open()
        Dim comm1 As New SqlCommand("SELECT FirstName, MiddleName, LastName, DepartmentId FROM StaffInfo WHERE (UserId = '" & UserId & "')", conn1)
        Dim reader1 As SqlDataReader = comm1.ExecuteReader()
        Dim DepartmentId As Integer
        reader1.Read()
        DepartmentId = reader1("DepartmentId")
        Dim status As Integer = 0


        Dim connectionstring2 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "INSERT INTO [Project] ([ProjectId], [ProjectName], [StartDate], [EndDate], [ProjectDescription], [DepartmentId], [EmployerId], [Status]) VALUES (@ProjectId, @ProjectName, @StartDate, @EndDate, @ProjectDescription, @DepartmentId, @EmployerId, @Status)"

        Using myConnection As New SqlConnection(connectionstring2)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.Parameters.Add(New SqlParameter("@ProjectId", ProjectId))
            myCommand.Parameters.Add(New SqlParameter("@ProjectName", ProjectName))
            myCommand.Parameters.Add(New SqlParameter("@StartDate", StartDate))
            myCommand.Parameters.Add(New SqlParameter("@EndDate", EndDate))
            myCommand.Parameters.Add(New SqlParameter("@ProjectDescription", ProjectDescription))
            myCommand.Parameters.Add(New SqlParameter("@DepartmentId", DepartmentId))
            myCommand.Parameters.Add(New SqlParameter("@EmployerId", UserId))
            myCommand.Parameters.Add(New SqlParameter("@Status", status))

            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Using

        Dim num As Integer = (Me.targetTable.Rows.Count / 2) - 3
        Dim Finished As Integer = 0
        Dim taskname As String
        Dim taskdescription As String

        For i As Integer = 1 To num
            taskname = CType(Page.FindControl("tb_Task" & i), TextBox).Text
            taskdescription = CType(Page.FindControl("tb_TaskDescription" & i), TextBox).Text
            Dim connectionstring3 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim updateSql1 As String = "INSERT INTO [Task] ([TaskName], [TaskDescription], [ProjectId],[Finished]) VALUES (@TaskName, @TaskDescription, @ProjectId, @Finished)"

            Using myConnection1 As New SqlConnection(connectionstring3)
                myConnection1.Open()
                Dim myCommand1 As New SqlCommand(updateSql1, myConnection1)

                myCommand1.Parameters.Add(New SqlParameter("@TaskName", taskname))
                myCommand1.Parameters.Add(New SqlParameter("@TaskDescription", taskdescription))
                myCommand1.Parameters.Add(New SqlParameter("@ProjectId", ProjectId))
                myCommand1.Parameters.Add(New SqlParameter("@Finished", Finished))

                myCommand1.ExecuteNonQuery()
                myConnection1.Close()

            End Using
        Next
        Response.Redirect("ViewAllProjects.aspx")
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("ViewAllProjects.aspx")
    End Sub

    Private ReadOnly Property NextTextboxID() As String
        Get
            Dim textboxIDformatString As String = "tb_Task{0}"
            If Me._previousTexBoxID = -1 Then
                Me._previousTexBoxID = targetTable.Rows.Count
            End If

            Dim nextTBId As String = String.Format(textboxIDformatString, (Me._previousTexBoxID - 6).ToString())
            Me._previousTexBoxID += 1
            Return nextTBId
        End Get
    End Property

    Private ReadOnly Property NextTextboxID2() As String
        Get
            Dim textboxIDformatString As String = "tb_TaskDescription{0}"
            If Me._previousTexBoxID2 = -1 Then
                Me._previousTexBoxID2 = targetTable.Rows.Count - 1
            End If

            Dim nextTBId2 As String = String.Format(textboxIDformatString, (Me._previousTexBoxID2 - 6).ToString())
            Me._previousTexBoxID2 += 1
            Return nextTBId2
        End Get
    End Property

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Me.targetTable = Me.Table1
        Integer.TryParse(Request.Form("additionalRows"), _additionalRowCount)

        If _additionalRowCount > 0 Then
            Dim i As Integer = 0
            While i < _additionalRowCount
                Me.AddAdditonalRow(False)
                i += 1
            End While
        End If

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        ClientScript.RegisterHiddenField("additionalRows", _additionalRowCount.ToString())
    End Sub

    Private Sub FormatItem(ByRef tr As TableRow)
        tr.Cells(0).Text = Server.HtmlEncode(String.Format("Task {0}:", ((Me._previousTexBoxID - 7).ToString())))
        tr.Cells(0).CssClass = "addInfoText"
    End Sub

    Private Function AddAdditonalRow(ByVal incrementcounter As Boolean) As TableRow
        Dim tr As New TableRow
        Dim cell1, cell2 As New TableCell

        tr.Cells.Add(cell1)
        tr.Cells.Add(cell2)

        Dim tb As New TextBox
        tb.ID = Me.NextTextboxID
        cell2.Controls.Add(tb)
        tb.CssClass = "addInfoTextbox"

        targetTable.Rows.Add(tr)

        Dim tr1 As New TableRow
        Dim cell3, cell4 As New TableCell

        tr1.Cells.Add(cell3)
        tr1.Cells.Add(cell4)

        Dim tb1 As New TextBox
        tb1.ID = Me.NextTextboxID2
        cell4.Controls.Add(tb1)
        tb1.CssClass = "addInfoDescriptionTextbox"
        tb1.TextMode = TextBoxMode.MultiLine

        targetTable.Rows.Add(tr1)

        If incrementcounter Then
            _additionalRowCount += 1
        End If

        Return tr
        Return tr1

    End Function

    Protected Sub btn_addMore_Click(sender As Object, e As EventArgs) Handles btn_addMore.Click
        Dim num As Integer = (Me.targetTable.Rows.Count / 2) - 3
        Dim tb As TextBox
        tb = CType(Page.FindControl("tb_Task" & num), TextBox)
        Dim tb1 As TextBox
        tb1 = CType(Page.FindControl("tb_TaskDescription" & num), TextBox)

        If tb.Text = "" Then
            tb.BorderColor = Drawing.Color.Red
        ElseIf tb1.Text = "" Then
            tb1.BorderColor = Drawing.Color.Red
        Else
            Dim tr As TableRow = Me.AddAdditonalRow(True)
            Me.FormatItem(tr)
            tb.BorderColor = Drawing.Color.FromName("#8c8989")
            tb1.BorderColor = Drawing.Color.FromName("#8c8989")
        End If
        btn_Submit.Focus()
    End Sub

    Protected Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If Me.targetTable.Rows.Count > 8 Then

            Dim i As Integer = Me.targetTable.Rows.Count - 2
            Dim tr As TableRow = Table1.Rows(i)
            targetTable.Rows.Remove(tr)

            Dim j As Integer = Me.targetTable.Rows.Count - 1
            Dim tr1 As TableRow = Table1.Rows(j)
            targetTable.Rows.Remove(tr1)

            Me._additionalRowCount -= 1
        End If
        btn_Submit.Focus()
    End Sub
End Class


