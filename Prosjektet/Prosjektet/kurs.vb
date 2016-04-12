Imports MySql.Data.MySqlClient
Public Class kurs

    Dim db As New DBConnect

    Private Sub kurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        db.DBConnect()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        leggtilkurs.show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Meny.Show()
        Close()
    End Sub
End Class