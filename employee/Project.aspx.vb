Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class Project
    Inherits System.Web.UI.Page
    Private PageSize As Integer = 8

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.GetCustomersPageWise(1)
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

End Class
