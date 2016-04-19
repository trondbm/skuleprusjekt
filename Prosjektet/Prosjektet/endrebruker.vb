Imports MySql.Data.MySqlClient
Public Class endrebruker

    Dim db As New DBConnect

    Dim id As String
    Dim brukernavn As String
    Dim passord As String
    Dim type As String



    Private Sub endrebruker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Endre bruker"

        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        db.DBConnect()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        id = TextBox3.Text






        If CheckBox3.Checked Then
            passord = TextBox2.Text
            If TextBox2.Text = "" Then
                MsgBox("Du må skrive inn passord", MsgBoxStyle.Critical, "Error")
            Else
                Try
                    Dim sqlepass = New MySqlCommand("UPDATE BRUKERE SET Passord='" & passord & "' where Brukernavn='" & id & "'", con)
                    sqlepass.ExecuteNonQuery()
                Catch ex As MySqlException
                    MsgBox("Noe gikk galt med å oppdatere passord!", MsgBoxStyle.Critical, "Error")
                End Try
            End If

        End If



        If RadioButton1.Checked Then
            type = "admin"

            Try
                Dim sqletype = New MySqlCommand("UPDATE BRUKERE SET Type='" & type & "' where Brukernavn='" & id & "'", con)
                sqletype.ExecuteNonQuery()
            Catch ex As MySqlException
                MsgBox("Noe gikk galt med å oppdatere stilling!", MsgBoxStyle.Critical, "Error")
            End Try
        ElseIf RadioButton2.Checked Then
            type = "selger"
            Try
                Dim sqletype = New MySqlCommand("UPDATE BRUKERE SET Type='" & type & "' where Brukernavn='" & id & "'", con)
                sqletype.ExecuteNonQuery()
            Catch ex As MySqlException
                MsgBox("Noe gikk galt med å oppdatere stilling!", MsgBoxStyle.Critical, "Error")
            End Try
        ElseIf RadioButton3.Checked Then
            type = "lager"
            Try
                Dim sqletype = New MySqlCommand("UPDATE BRUKERE SET Type='" & type & "' where Brukernavn='" & id & "'", con)
                sqletype.ExecuteNonQuery()
            Catch ex As MySqlException
                MsgBox("Noe gikk galt med å oppdatere stilling!", MsgBoxStyle.Critical, "Error")
            End Try

        Else

        End If

        If CheckBox2.Checked Then
            brukernavn = TextBox1.Text
            If TextBox1.Text = "" Then
                MsgBox("Du må skrive inn brukernavn", MsgBoxStyle.Critical, "Error")
            Else
                Try
                    Dim sqlebrukernavn = New MySqlCommand("UPDATE BRUKERE SET Brukernavn='" & brukernavn & "' where Brukernavn='" & id & "'", con)
                    sqlebrukernavn.ExecuteNonQuery()
                Catch ex As MySqlException
                    MsgBox("Noe gikk galt med å oppdatere brukernavn!", MsgBoxStyle.Critical, "Error")
                End Try
            End If

        End If

        Me.Close()


    End Sub




End Class