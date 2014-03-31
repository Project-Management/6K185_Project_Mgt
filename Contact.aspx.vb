Imports System.Net.Mail
Imports Microsoft.VisualBasic

Partial Class Contact
    Inherits System.Web.UI.Page

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        Dim emailMessage As New MailMessage()
        Try
            emailMessage.From = New MailAddress("dzyoung123@gmail.com")
            emailMessage.To.Add("dzyoung123@gmail.com")
            emailMessage.Subject = "Question"
            emailMessage.Body = "Message: " & CStr(TBMessage.Text) & Environment.NewLine & "Name: " & TBName.Text & Environment.NewLine & "Mail: " & TBMail.Text & Environment.NewLine & "Phone: " & TBPhone.Text
            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.EnableSsl = True
            smtp.Credentials = New System.Net.NetworkCredential("dzyoung123@gmail.com", "Jason0718")
            smtp.Send(emailMessage)

        Catch ex As Exception

        End Try
        TBName.Text = String.Empty
        TBMail.Text = String.Empty
        TBPhone.Text = String.Empty
        TBMessage.Text = String.Empty

    End Sub

    Protected Sub clear_Click(sender As Object, e As EventArgs) Handles clear.Click

        TBName.Text = String.Empty
        TBMail.Text = String.Empty
        TBPhone.Text = String.Empty
        TBMessage.Text = String.Empty

    End Sub
End Class
