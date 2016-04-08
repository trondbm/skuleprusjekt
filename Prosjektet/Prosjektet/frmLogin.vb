Public Class frmLogin

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Meny.Show()
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Innlogging"
    End Sub
End Class
