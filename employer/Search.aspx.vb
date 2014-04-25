Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class employer_ViewAllProjects
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tb_Search.Text = Request.QueryString("Search")
            Dim search As String = "SELECT DISTINCT ProjectId, ProjectName FROM Project Where (ProjectName Like '%" + tb_Search.Text.ToString() + "%')"
            SqlDataSource1.SelectCommand = search
            If tb_Search.Text = "" Then
                Response.Redirect("~/employer/ViewAllProjects.aspx")
            End If
        End If
    End Sub

    Protected Sub tb_Search_TextChanged(sender As Object, e As EventArgs) Handles tb_Search.TextChanged
        Dim search As String = "SELECT DISTINCT ProjectId, ProjectName FROM Project Where (ProjectName Like '%" + tb_Search.Text.ToString() + "%')"
        SqlDataSource1.SelectCommand = search
        If tb_Search.Text = "" Then
            Response.Redirect("~/employer/ViewAllProjects.aspx")
        End If
    End Sub

End Class
