Imports MySql.Data.MySqlClient
Public Class leggtilansatt


    Dim db As New DBConnect

    Dim stilling As String
    Dim navn As String
    Dim tlf As Integer
    Dim epost As String

    Private Sub leggtilansatt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Legg til ansatt"
        db.DBConnect()
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If RadioButton1.Checked Then
            stilling = "Selger"
        ElseIf RadioButton2.Checked Then
            stilling = "Lagerarbeider"
        ElseIf RadioButton3.Checked Then
            stilling = "IT-hjelp"

        Else MsgBox("Velg stilling", MsgBoxStyle.Critical, "Error")
        End If

        navn = TextBox2.Text + ", " + TextBox1.Text



        If navn = "" Then
            MsgBox("Skriv et navn", MsgBoxStyle.Critical, "Error")
        ElseIf navn = ", " Then
            MsgBox("Skriv et navn", MsgBoxStyle.Critical, "Error")
        ElseIf isnumeric(TextBox6.Text) = False Then
            MsgBox("Skriv et telefonnummer", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox6.Text = "" Then
            MsgBox("Skriv et telefonnummer", MsgBoxStyle.Critical, "Error")
        Else

            tlf = TextBox6.Text
            epost = TextBox5.Text

            MsgBox(navn & " er lagt til som " & stilling & vbCrLf & "Epost: " & epost, MsgBoxStyle.Information, "Suksess!")

            Dim sqlansatt = New MySqlCommand("Insert into ANSATT (navn, stilling, tlf, epost) values (@navn, @stilling, @tlf, @epost)", con)
            sqlansatt.Parameters.AddWithValue("@navn", navn)
            sqlansatt.Parameters.AddWithValue("@stilling", stilling)
            sqlansatt.Parameters.AddWithValue("@tlf", tlf)
            sqlansatt.Parameters.AddWithValue("@epost", epost)

            sqlansatt.ExecuteNonQuery()




            db.DBDisconnect()
            Close()
        End If

    End Sub
End Class