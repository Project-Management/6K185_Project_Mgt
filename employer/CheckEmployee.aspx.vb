
Partial Class employer_CheckEmployee
    Inherits System.Web.UI.Page

    Protected Sub tb_Search_TextChanged(sender As Object, e As EventArgs) Handles tb_Search.TextChanged
        Dim search As String = "SELECT * FROM StaffInfo Where (FirstName Like '%" + tb_Search.Text.ToString() + "%') OR (MiddleName Like '%" + tb_Search.Text.ToString() + "%') OR (LastName Like '%" + tb_Search.Text.ToString() + "%')"
        SqlDataSource1.SelectCommand = search
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tb_Search.Text = Request.QueryString("Search")
            Dim search As String = "SELECT * FROM StaffInfo Where (FirstName Like '%" + tb_Search.Text.ToString() + "%') OR (MiddleName Like '%" + tb_Search.Text.ToString() + "%') OR (LastName Like '%" + tb_Search.Text.ToString() + "%')"
            SqlDataSource1.SelectCommand = search
            Session("field1") = Request.QueryString("TaskId")
        End If
    End Sub

End Class
