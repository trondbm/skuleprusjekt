Imports MySql.Data.MySqlClient
Public Class leggtilkurs
    Dim db As New DBConnect
    Private Sub leggtilkurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        db.DBConnect()

    End Sub





    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class