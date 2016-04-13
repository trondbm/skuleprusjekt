Imports MySql.Data.MySqlClient
Public Class frmLogin

    Dim db As New DBConnect

    Public brukernavn As String
    Public passord As String
    Public oppkobling As New MySqlConnection
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db.DBConnect()
        Me.Text = "Innlogging"
        TextBox2.PasswordChar = "*"
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim brukernavn = TextBox1.Text.Replace("'", "\'")
        Dim passord = TextBox2.Text.Replace("'", "\'")

        Dim sqlsporring = "Select * from BRUKERE where brukernavn=@brukernavn " & " and passord=@passord"

        Dim sqllogg As New MySqlCommand(sqlsporring, con)

        sqllogg.Parameters.AddWithValue("@brukernavn", brukernavn)
        sqllogg.Parameters.AddWithValue("@passord", passord)

        Dim leser = sqllogg.ExecuteReader()
        If leser.HasRows Then
            MsgBox("Logged inn", MsgBoxStyle.Information, "Suksess")
            Meny.Show()
            Close()
        Else
            MsgBox("Feil brukernavn eller passord", MsgBoxStyle.Critical, "Error")
        End If
        leser.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub



End Class