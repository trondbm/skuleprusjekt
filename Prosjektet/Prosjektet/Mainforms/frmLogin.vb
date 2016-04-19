Imports MySql.Data.MySqlClient
Public Class frmLogin

    Dim db As New DBConnect

    Public brukernavn As String
    Public passord As String
    Public type As String
    Public cmd As New MySqlCommand




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
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


        'type
        cmd = New MySqlCommand("SELECT Type FROM `BRUKERE` WHERE BRUKERE.Brukernavn = @brukernavn", con)
        cmd.Parameters.AddWithValue("@brukernavn", brukernavn)

        type = cmd.ExecuteScalar()


        Dim leser = sqllogg.ExecuteReader()
        If leser.HasRows Then



            If type = "admin" Then
                MsgBox("Logget inn som administrator", MsgBoxStyle.Information, "Logg inn")
            ElseIf type = "selger" Then
                MsgBox("Logget inn som selger", MsgBoxStyle.Information, "Logg inn")
            ElseIf type = "lager" Then
                MsgBox("Logget inn som lagerarbeider", MsgBoxStyle.Information, "Logg inn")
            End If
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