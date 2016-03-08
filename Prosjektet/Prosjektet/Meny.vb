Imports MySql.Data.MySqlClient
Public Class Meny
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Forms.Form1.Show()
        My.Forms.Meny.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        My.Forms.Vareregistrering.Show()
        My.Forms.Meny.Hide()
    End Sub
End Class