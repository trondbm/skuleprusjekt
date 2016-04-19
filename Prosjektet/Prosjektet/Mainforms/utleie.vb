Imports MySql.Data.MySqlClient
Public Class utleie

    Dim db As New DBConnect
    Dim brukernavn As String
    Public type As String
    Dim cmd As New MySqlCommand
 

    Private Sub utleie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db.DBConnect()

        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        brukernavn = TextBox1.Text
        cmd = New MySqlCommand("SELECT Type FROM `BRUKERE` WHERE BRUKERE.Brukernavn = @brukernavn", con)
        cmd.Parameters.AddWithValue("@brukernavn", brukernavn)

        type = cmd.ExecuteScalar()



        MsgBox(type)

    End Sub


End Class