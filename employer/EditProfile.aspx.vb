Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employee_EditProfile
    Inherits System.Web.UI.Page

    Private Property Day() As Integer
        Get
            If (Not (Request.Form(ddlDay.UniqueID)) Is Nothing) Then
                Return Integer.Parse(Request.Form(ddlDay.UniqueID))
            Else
                Return Integer.Parse(ddlDay.SelectedItem.Value)
            End If
        End Get
        Set(ByVal value As Integer)
            Me.PopulateDay()
            ddlDay.ClearSelection()
            ddlDay.Items.FindByValue(value.ToString).Selected = True
        End Set
    End Property

    Private Property Month() As Integer
        Get
            Return Integer.Parse(ddlMonth.SelectedItem.Value)
        End Get
        Set(ByVal value As Integer)
            Me.PopulateMonth()
            ddlMonth.ClearSelection()
            ddlMonth.Items.FindByValue(value.ToString).Selected = True
        End Set
    End Property

    Private Property Year() As Integer
        Get
            Return Integer.Parse(ddlYear.SelectedItem.Value)
        End Get
        Set(ByVal value As Integer)
            Me.PopulateYear()
            ddlYear.ClearSelection()
            ddlYear.Items.FindByValue(value.ToString).Selected = True
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
            Me.Year = value.Year
            Me.Month = value.Month
            Me.Day = value.Day
        End Set
    End Property
    Private Sub PopulateDay()
        ddlDay.Items.Clear()
        Dim lt As ListItem = New ListItem
        lt.Text = "Day"
        lt.Value = "0"
        ddlDay.Items.Add(lt)
        Dim i As Integer = 1
        Do While (i <= 31)
            lt = New ListItem
            lt.Text = i.ToString
            lt.Value = i.ToString
            ddlDay.Items.Add(lt)
            i = (i + 1)
        Loop
    End Sub

    Private Sub PopulateMonth()
        ddlMonth.Items.Clear()
        Dim lt As ListItem = New ListItem
        lt.Text = "Month"
        lt.Value = "0"
        ddlMonth.Items.Add(lt)
        Dim i As Integer = 1
        Do While (i <= 12)
            lt = New ListItem
            lt.Text = Convert.ToDateTime((i.ToString + "/1/1900")).ToString("MMMM")
            lt.Value = i.ToString
            ddlMonth.Items.Add(lt)
            i = (i + 1)
        Loop
    End Sub

    Private Sub PopulateYear()
        ddlYear.Items.Clear()
        Dim lt As ListItem = New ListItem
        lt.Text = "Year"
        lt.Value = "0"
        ddlYear.Items.Add(lt)
        Dim i As Integer = DateTime.Now.Year
        Do While (i >= 1950)
            lt = New ListItem
            lt.Text = i.ToString
            lt.Value = i.ToString
            ddlYear.Items.Add(lt)
            i = (i - 1)
        Loop
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.PopulateYear()
            Me.PopulateMonth()
            Me.PopulateDay()

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
                Dim UserId As String
                UserId = Request.QueryString("UserId")

                Dim connectionString1 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                Dim conn1 As New SqlConnection(connectionString1)
                conn1.Open()
                Dim comm1 As New SqlCommand("SELECT * FROM StaffInfo WHERE (UserId = '" & UserId & "')", conn1)
                Dim reader1 As SqlDataReader = comm1.ExecuteReader()
                Dim FirstName As String
                Dim MiddleName As String
                Dim LastName As String
                Dim Address As String
                Dim City As String
                Dim State As String
                Dim ZipCode As String
                Dim HomePhone As String
                Dim MobilePhone As String
                Dim Email As String
                Dim DriverLicense As String
                Dim SSN As String
                Dim MaritalStatus As String
                Dim Birthdate As Date
                Dim BirthDay As String
                Dim BirthMonth As String
                Dim BirthYear As String
                Dim Hiredate As String

                Dim DepartmentId As Integer
                reader1.Read()
                FirstName = Convert.ToString(reader1("FirstName"))
                MiddleName = Convert.ToString(reader1("MiddleName"))
                LastName = Convert.ToString(reader1("LastName"))
                Address = Convert.ToString(reader1("Address"))
                City = Convert.ToString(reader1("City"))
                State = Convert.ToString(reader1("State"))
                ZipCode = Convert.ToString(reader1("Zip"))
                HomePhone = Convert.ToString(reader1("HomePhone"))
                MobilePhone = Convert.ToString(reader1("MobilePhone"))
                Email = Convert.ToString(reader1("Email"))
                DriverLicense = Convert.ToString(reader1("DriverLicense"))
                SSN = Convert.ToString(reader1("SSN"))
                MaritalStatus = Convert.ToString(reader1("MaritalStatus"))
                Birthdate = reader1("Birthday")
                BirthDay = Birthdate.Day
                BirthMonth = Birthdate.Month
                BirthYear = Birthdate.Year
                Hiredate = Convert.ToString(reader1("HireDate"))

                DepartmentId = reader1("DepartmentId")

                tb_FirstName.Text = FirstName
                tb_MiddleName.Text = MiddleName
                tb_LastName.Text = LastName
                tb_Address.Text = Address
                tb_City.Text = City
                ddl_State.Text = State
                tb_ZipCode.Text = ZipCode
                tb_HomePhone.Text = HomePhone
                tb_MobilePhone.Text = MobilePhone
                tb_Email.Text = Email
                tb_DriverLicense.Text = DriverLicense
                tb_SSN.Text = SSN
                ddlMarital.Text = MaritalStatus
                ddlDay.Text = BirthDay
                ddlYear.Text = BirthYear
                tb_HireDate.Text = Hiredate
                ddlMonth.Items.FindByValue(BirthMonth).Selected = True

                If DepartmentId = 1 Then
                    tb_Employer.Text = "Zhaoyang Dai"
                ElseIf DepartmentId = 2 Then
                    tb_Employer.Text = "Haoran Wang"
                End If

                Dim connectionString2 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                Dim conn2 As New SqlConnection(connectionString2)
                conn2.Open()
                Dim comm2 As New SqlCommand("SELECT DepartmentName FROM Department WHERE (DepartmentId = '" & DepartmentId & "')", conn2)
                Dim reader2 As SqlDataReader = comm2.ExecuteReader()
                Dim DepartmentName As String
                reader2.Read()
                DepartmentName = Convert.ToString(reader2("DepartmentName"))
                tb_Department.Text = DepartmentName

                conn1.Close()
                conn2.Close()

            Catch ex As Exception

            End Try
        End If

    End Sub

    Protected Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click

        Dim UserId As String
        UserId = Request.QueryString("UserId")

        Response.Redirect("./EmployeeDetails.aspx?UserId=" & UserId)

    End Sub

    Protected Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click

        Dim UserId As String
        UserId = Request.QueryString("UserId")

        Dim FirstName As String = tb_FirstName.Text
        Dim MiddleName As String = tb_MiddleName.Text
        Dim LastName As String = tb_LastName.Text
        Dim Address As String = tb_Address.Text
        Dim City As String = tb_City.Text
        Dim State As String = ddl_State.SelectedItem.Text
        Dim ZipCode As String = tb_ZipCode.Text
        Dim HomePhone As String = tb_HomePhone.Text
        Dim MobilePhone As String = tb_MobilePhone.Text
        Dim Email As String = tb_Email.Text
        Dim DriverLicense As String = tb_DriverLicense.Text
        Dim SSN As String = tb_SSN.Text
        Dim BirthDate As String = ddlMonth.Text & "/" & ddlDay.Text & "/" & ddlYear.Text
        Dim MaritalStatus As String = ddlMarital.SelectedItem.Text
        Dim HireDate As String = Convert.ToString(tb_HireDate)
        Dim EmployerName As String = tb_Employer.Text
        Dim Department As String = tb_Department.Text
        Dim filepath As String = Server.MapPath("~\images\employee")
        Dim Photo As String = tb_SSN.Text

        If up_Photo.HasFile Then
            Try
                up_Photo.SaveAs(filepath & "\" & Photo & ".jpg")
            Catch ex As Exception
            End Try
        End If

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "Update StaffInfo set FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Address = @Address, City = @City, State = @State, Zip = @Zip, HomePhone = @HomePhone, MobilePhone = @MobilePhone, Email = @Email, DriverLicense = @DriverLicense, Birthday = @Birthday, MaritalStatus = @MaritalStatus, Photo = @Photo WHERE (UserId = '" & UserId & "')"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.Parameters.AddWithValue("@FirstName", FirstName)
            myCommand.Parameters.AddWithValue("@MiddleName", MiddleName)
            myCommand.Parameters.AddWithValue("@LastName", LastName)
            myCommand.Parameters.AddWithValue("@Address", Address)
            myCommand.Parameters.AddWithValue("@City", City)
            myCommand.Parameters.AddWithValue("@State", State)
            myCommand.Parameters.AddWithValue("@Zip", ZipCode)
            myCommand.Parameters.AddWithValue("@HomePhone", HomePhone)
            myCommand.Parameters.AddWithValue("@MobilePhone", MobilePhone)
            myCommand.Parameters.AddWithValue("@Email", Email)
            myCommand.Parameters.AddWithValue("@DriverLicense", DriverLicense)
            myCommand.Parameters.AddWithValue("@Birthday", BirthDate)
            myCommand.Parameters.AddWithValue("@MaritalStatus", MaritalStatus)
            myCommand.Parameters.AddWithValue("@Photo", Photo & ".jpg")

            myCommand.ExecuteNonQuery()
            myConnection.Close()
        End Using

        Response.Redirect("./EmployeeDetails.aspx?UserId=" & UserId)

    End Sub

    Protected Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click

        Dim UserId As String
        UserId = Request.QueryString("UserId")

        Response.Redirect("./Delete.aspx?UserId=" & UserId)

    End Sub
End Class
