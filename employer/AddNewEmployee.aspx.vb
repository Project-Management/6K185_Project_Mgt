Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_AddNewEmployee
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
        Do While (i <= 31)
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

        Dim singleListItem As ListItem
        singleListItem = New ListItem("Single", "Single")
        Dim marriedListItem As ListItem
        marriedListItem = New ListItem("Married", "Married")
        Dim seperatedListItem As ListItem
        seperatedListItem = New ListItem("Seperated", "Seperated")
        Dim divorcedListItem As ListItem
        divorcedListItem = New ListItem("Divorced", "Divorced")

        ddlMarital.Items.Add(singleListItem)
        ddlMarital.Items.Add(marriedListItem)
        ddlMarital.Items.Add(seperatedListItem)
        ddlMarital.Items.Add(divorcedListItem)

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

    Protected Sub CreateUserWizard1_ActiveStepChanged(sender As Object, e As EventArgs) Handles CreateUserWizard1.ActiveStepChanged

        If CreateUserWizard1.ActiveStep.Title = "Complete" Then

            Dim UserSettings As WizardStep = CType(CreateUserWizard1.FindControl("UserProfile"), WizardStep)

            Dim FirstName As TextBox = CType(UserSettings.FindControl("tb_FirstName"), TextBox)
            Dim MiddleName As TextBox = CType(UserSettings.FindControl("tb_MiddleName"), TextBox)
            Dim LastName As TextBox = CType(UserSettings.FindControl("tb_LastName"), TextBox)
            Dim Address As TextBox = CType(UserSettings.FindControl("tb_Address"), TextBox)
            Dim City As TextBox = CType(UserSettings.FindControl("tb_City"), TextBox)
            Dim State As String = ddl_State.SelectedItem.Text
            Dim ZipCode As TextBox = CType(UserSettings.FindControl("tb_ZipCode"), TextBox)
            Dim HomePhone As TextBox = CType(UserSettings.FindControl("tb_HomePhone"), TextBox)
            Dim MobilePhone As TextBox = CType(UserSettings.FindControl("tb_MobilePhone"), TextBox)
            Dim Email As TextBox = CType(UserSettings.FindControl("tb_Email"), TextBox)
            Dim DriverLicense As TextBox = CType(UserSettings.FindControl("tb_DriverLicense"), TextBox)
            Dim SSN As TextBox = CType(UserSettings.FindControl("tb_SSN"), TextBox)
            Dim BirthDate As String = ddlMonth.Text & "/" & ddlDay.Text & "/" & ddlYear.Text
            Dim MaritalStatus As String = ddlMarital.SelectedItem.Text
            Dim HireDate As String = ddlMonth1.Text & "/" & ddlDay1.Text & "/" & ddlYear1.Text
            Dim EmployerName As String = tb_Employer.Text
            Dim Department As String = tb_Department.Text
            Dim filepath As String = Server.MapPath("~\images\employee")
            Dim Photo As TextBox = CType(UserSettings.FindControl("tb_SSN"), TextBox)

            If up_Photo.HasFile Then
                Try
                    up_Photo.SaveAs(filepath & "\" & Photo.Text.Trim & ".jpg")
                Catch ex As Exception
                End Try
            End If


            Dim newUser As MembershipUser = Membership.GetUser(CreateUserWizard1.UserName)
            Dim NewUserId As Guid = CType(newUser.ProviderUserKey, Guid)
            Roles.AddUserToRole(newUser.UserName, "employee")



            Dim connectionStr As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim conn As New SqlConnection(connectionStr)
            conn.Open()
            Dim comm As New SqlCommand("SELECT DepartmentId FROM Department WHERE (DepartmentName = '" & Department & "')", conn)
            Dim reader As SqlDataReader = comm.ExecuteReader()
            Dim DepartmentId As String
            reader.Read()
            DepartmentId = Convert.ToString(reader("DepartmentId"))
            conn.Close()



            Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim updateSql As String = "INSERT INTO [StaffInfo] ([UserId], [FirstName], [MiddleName], [LastName], [Address], [City], [State], [Zip], [HomePhone], [MobilePhone], [Email], [DriverLicense], [SSN], [Birthday], [MaritalStatus], [HireDate], [EmployerName], [DepartmentId], [Photo]) VALUES (@UserId, @FirstName, @MiddleName, @LastName, @Address, @City, @State, @Zip, @HomePhone, @MobilePhone, @Email, @DriverLicense, @SSN, @Birthday, @MaritalStatus, @HireDate, @EmployerName, @DepartmentId, @Photo)"

            Using myConnection As New SqlConnection(connectionstring)
                myConnection.Open()
                Dim myCommand As New SqlCommand(updateSql, myConnection)

                myCommand.Parameters.AddWithValue("@UserId", NewUserId)
                myCommand.Parameters.AddWithValue("@FirstName", FirstName.Text.Trim)
                myCommand.Parameters.AddWithValue("@MiddleName", MiddleName.Text.Trim)
                myCommand.Parameters.AddWithValue("@LastName", LastName.Text.Trim)
                myCommand.Parameters.AddWithValue("@Address", Address.Text.Trim)
                myCommand.Parameters.AddWithValue("@City", City.Text.Trim)
                myCommand.Parameters.Add(New SqlParameter("@State", State))
                myCommand.Parameters.AddWithValue("@Zip", ZipCode.Text.Trim)
                myCommand.Parameters.AddWithValue("@HomePhone", HomePhone.Text.Trim)
                myCommand.Parameters.AddWithValue("@MobilePhone", MobilePhone.Text.Trim)
                myCommand.Parameters.AddWithValue("@Email", Email.Text.Trim)
                myCommand.Parameters.AddWithValue("@DriverLicense", DriverLicense.Text.Trim)
                myCommand.Parameters.AddWithValue("@SSN", SSN.Text.Trim)
                myCommand.Parameters.AddWithValue("@Birthday", BirthDate)
                myCommand.Parameters.Add(New SqlParameter("@MaritalStatus", MaritalStatus))
                myCommand.Parameters.AddWithValue("@HireDate", HireDate)
                myCommand.Parameters.AddWithValue("@EmployerName", EmployerName)
                myCommand.Parameters.AddWithValue("@DepartmentId", DepartmentId)
                myCommand.Parameters.AddWithValue("@Photo", Photo.Text.Trim & ".jpg")

                myCommand.ExecuteNonQuery()
                myConnection.Close()

            End Using

        End If

    End Sub

    Protected Sub ContinueButton_Click(ByVal sender As Object, ByVal e As EventArgs)

        Response.Redirect("ViewAllEmployees.aspx")

    End Sub

End Class
