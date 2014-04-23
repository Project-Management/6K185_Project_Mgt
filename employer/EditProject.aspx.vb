Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class employer_EditProject
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
        If Not IsPostBack Then
                Me.PopulateYear()
                Me.PopulateMonth()
                Me.PopulateDay()


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
                Dim comm1 As New SqlCommand("SELECT DepartmentId FROM StaffInfo WHERE (UserId = '" & UserId & "')", conn1)
                Dim reader1 As SqlDataReader = comm1.ExecuteReader()
                Dim DepartmentId As Integer
                reader1.Read()
                DepartmentId = reader1("DepartmentId")

                Dim connectionString2 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                Dim conn2 As New SqlConnection(connectionString2)
                conn2.Open()
                Dim comm2 As New SqlCommand("SELECT DepartmentName FROM Department WHERE (DepartmentId = '" & DepartmentId & "')", conn2)
                Dim reader2 As SqlDataReader = comm2.ExecuteReader()
                Dim DepartmentName As String
                reader2.Read()
                DepartmentName = Convert.ToString(reader2("DepartmentName"))
                tb_Department.Text = DepartmentName

                Dim ProjectId As String
                ProjectId = Request.QueryString("ProjectId")

                Dim connectionString3 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
                Dim conn3 As New SqlConnection(connectionString3)
                conn3.Open()
                Dim comm3 As New SqlCommand("SELECT * FROM Project WHERE (ProjectId = '" & ProjectId & "')", conn3)
                Dim reader3 As SqlDataReader = comm3.ExecuteReader()

                reader3.Read()
                tb_ProjectName.Text = Convert.ToString(reader3("ProjectName"))
                tb_Description.Text = Convert.ToString(reader3("ProjectDescription"))
                tb_StartDate.Text = Convert.ToString(reader3("StartDate"))

                Dim EndDate As Date
                Dim EndDay As String
                Dim EndMonth As String
                Dim EndYear As String
                EndDate = reader3("EndDate")
                EndDay = EndDate.Day
                EndMonth = EndDate.Month
                EndYear = EndDate.Year
                ddlDay.Text = EndDay
                ddlMonth.Text = EndMonth
                ddlYear.Text = EndYear

                conn.Close()
                conn1.Close()
                conn2.Close()
                conn3.Close()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click

        Dim ProjectId As String
        ProjectId = Request.QueryString("ProjectId")

        Dim ProjectName As String = tb_ProjectName.Text
        Dim EndDate As String = ddlMonth.Text & "/" & ddlDay.Text & "/" & ddlYear.Text
        Dim ProjectDescription As String = tb_Description.Text

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Dim updateSql As String = "Update Project set ProjectName = @ProjectName, EndDate = @EndDate, ProjectDescription = @ProjectDescription WHERE (ProjectId = '" & ProjectId & "')"

        Using myConnection As New SqlConnection(connectionstring)
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSql, myConnection)

            myCommand.Parameters.AddWithValue("@ProjectName", ProjectName)
            myCommand.Parameters.AddWithValue("@EndDate", EndDate)
            myCommand.Parameters.AddWithValue("@ProjectDescription", ProjectDescription)

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

    Protected Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click

        Dim ProjectId As String
        ProjectId = Request.QueryString("ProjectId")

        Response.Redirect("./DeleteProject.aspx?ProjectId=" & ProjectId)

    End Sub
End Class
