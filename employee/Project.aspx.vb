Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class employee_Project
    Inherits System.Web.UI.Page
    Private PageSize As Integer = 8

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.GetCustomersPageWise(1)
            tb_Search.Focus()
        End If
    End Sub

    Private Sub GetCustomersPageWise(pageIndex As Integer)
        Dim constring As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("GetCustomersPageWise", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@PageIndex", pageIndex)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4)
                cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
                con.Open()
                Dim idr As IDataReader = cmd.ExecuteReader()
                Repeater1.DataSource = idr
                Repeater1.DataBind()
                idr.Close()
                con.Close()
                Dim recordCount As Integer = Convert.ToInt32(cmd.Parameters("@RecordCount").Value)
                Me.PopulatePager(recordCount, pageIndex)
            End Using
        End Using
    End Sub

    Private Sub PopulatePager(recordCount As Integer, currentPage As Integer)
        Dim dblPageCount As Double = CDbl(CDec(recordCount) / Convert.ToDecimal(PageSize))
        Dim pageCount As Integer = CInt(Math.Ceiling(dblPageCount))
        Dim pages As New List(Of ListItem)()
        If pageCount > 0 Then
            For i As Integer = 1 To pageCount
                pages.Add(New ListItem(i.ToString(), i.ToString(), i <> currentPage))
            Next
        End If
        rptPager.DataSource = pages
        rptPager.DataBind()
    End Sub

    Protected Sub Page_Changed(sender As Object, e As EventArgs)
        Dim pageIndex As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Me.GetCustomersPageWise(pageIndex)
    End Sub

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand

        If e.CommandName = "viewMore" Then

            Dim UserName As String
            UserName = User.Identity.Name

            Dim UserId As String
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim conn As New SqlConnection(connectionString)
            conn.Open()
            Dim comm As New SqlCommand("SELECT UserId FROM aspnet_Users WHERE (UserName = '" & UserName & "')", conn)
            Dim reader As SqlDataReader = comm.ExecuteReader()
            reader.Read()
            UserId = Convert.ToString(reader("UserId"))
            conn.Close()

            Dim RoleId As String
            Dim connectionString1 As String = ConfigurationManager.ConnectionStrings("cs_PMS").ConnectionString
            Dim conn1 As New SqlConnection(connectionString1)
            conn1.Open()
            Dim comm1 As New SqlCommand("SELECT RoleId FROM aspnet_UsersInRoles WHERE (UserId = '" & UserId & "')", conn1)
            Dim reader1 As SqlDataReader = comm1.ExecuteReader()
            reader1.Read()
            RoleId = Convert.ToString(reader1("RoleId"))
            conn1.Close()


            'Dim ProjectId As String = CType(e.Item.FindControl("lbl"), Label).Text
            Dim ProjectId As String = "13"


            If RoleId = "82165500-c257-45fe-9c67-7eafdaa205f7" Then

                Response.Redirect("~/employer/ProjectDetails.aspx?ProjectId=" & ProjectId)

            ElseIf RoleId = "6d2e0197-a201-4e23-ac46-cb27cd70538c" Then

                Response.Redirect("~/employee/ProjectDetails.aspx?ProjectId=" & ProjectId)

            End If


        End If

    End Sub

    Protected Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        Response.Redirect("~/employee/Search.aspx?Search=" + tb_Search.Text)
    End Sub
End Class
