Imports MySql.Data.MySqlClient
Public Class leggtilbruker

    Dim db As New DBConnect

    Dim brukernavn As String
    Dim passord As String
    Dim type As String

    Private Sub leggtilbruker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db.DBConnect()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If RadioButton1.Checked Then
            type = "admin"
        ElseIf RadioButton2.Checked Then
            type = "selger"
        ElseIf RadioButton3.Checked Then
            type = "lager"
        Else
            MsgBox("Du må velge type bruker", MsgBoxStyle.Critical, "Error")
        End If

        If TextBox1.Text = "" Then
            MsgBox("Du må skrive brukernavn", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Du må skrive passord", MsgBoxStyle.Critical, "Error")
        Else
            brukernavn = TextBox1.Text
            passord = TextBox2.Text



            Try
                Dim sqlkunde = New MySqlCommand("Insert into BRUKERE (Brukernavn, Passord, Type) values (@brukernavn, @passord, @type)", con)
                sqlkunde.Parameters.AddWithValue("@brukernavn", brukernavn)
                sqlkunde.Parameters.AddWithValue("@passord", passord)
                sqlkunde.Parameters.AddWithValue("@type", type)


                sqlkunde.ExecuteNonQuery()

                MsgBox("Du har nå lagt til brukernavn: " & brukernavn & " med passord: " & passord & vbCrLf & "Type: " & type, MsgBoxStyle.Information, "Suksess")
            Catch ex As Exception
                MsgBox("Brukernavnet er i bruk", MsgBoxStyle.Critical, "Error")
            End Try





            db.DBDisconnect()
            Close()

        End If




    End Sub


End Class