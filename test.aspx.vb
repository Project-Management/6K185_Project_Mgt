Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_AddNewProject
    Inherits System.Web.UI.Page

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
            If (Not (Request.Form(ddlDay.UniqueID)) Is Nothing) Then
                Me.PopulateDay()
                ddlDay.ClearSelection()
                ddlDay.Items.FindByValue(Request.Form(ddlDay.UniqueID)).Selected = True
                ddlDay1.ClearSelection()
                ddlDay1.Items.FindByValue(Request.Form(ddlDay.UniqueID)).Selected = True
            End If
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

        Dim TaskName As String = tb_Task1.Text
        Dim TaskDescription As String = tb_TaskDescription1.Text
        Dim EmployeeId As String = ""
        Dim Finished As Integer = 0


        Dim connectionstring3 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql1 As String = "INSERT INTO [Task] ([TaskId], [TaskName], [TaskDescription], [ProjectId], [EmployeeId], [Finished]) VALUES (@TaskId, @TaskName, @TaskDescription, @ProjectId, @EmployeeId, @Finished)"

        Using myConnection As New SqlConnection(connectionstring3)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.Parameters.Add(New SqlParameter("@TaskName", TaskName))
            myCommand.Parameters.Add(New SqlParameter("@TaskDescription", TaskDescription))
            myCommand.Parameters.Add(New SqlParameter("@ProjectId", ProjectId))
            myCommand.Parameters.Add(New SqlParameter("@EmployeeId", EmployeeId))
            myCommand.Parameters.Add(New SqlParameter("@Finished", Finished))

            myCommand.ExecuteNonQuery()
            myConnection.Close()

        End Using


    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub
End Class


