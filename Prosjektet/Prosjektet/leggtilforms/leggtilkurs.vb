Imports MySql.Data.MySqlClient
Public Class leggtilkurs
    Dim db As New DBConnect

    Dim navn As String
    Dim dato As String
    Dim max As Integer

    Dim postnr As Integer

    Private Sub leggtilkurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Legg til kurs"
        db.DBConnect()

    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text = "" Then
            MsgBox("Du må skrive inn navn", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox5.Text = "" Then
            MsgBox("Du må skrive inn et antall", MsgBoxStyle.Critical, "Error")
        ElseIf isnumeric(TextBox5.text) = False Then
            MsgBox("Du må skrive tall i 'Maxantall'", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox6.Text = "" Then
            MsgBox("Du må skrive inn et postnummer", MsgBoxStyle.Critical, "Error")
        ElseIf isnumeric(TextBox6.text) = False Then
            MsgBox("Du må skrive tall i 'Postnummer'", MsgBoxStyle.Critical, "Error")

        Else

            navn = TextBox1.Text
            dato = DateTimePicker1.Text
            max = TextBox5.Text

            postnr = TextBox6.Text

            MsgBox("Kurs lagt til!" & vbCrLf & "Navn: " & navn & vbCrLf & "Dato: " & dato & vbCrLf & "Postnr: " & postnr & " Maxantall: " & max & NumericUpDown1.Value & " timer.", MsgBoxStyle.Information, "Suksess!")

            Dim sqlkurs = New MySqlCommand("Insert into KURS (dato, kursnavn, maxantall, postnr, tidslengde) values (@dato, @navn, @max, @postnr, @tid)", con)
            sqlkurs.Parameters.AddWithValue("@dato", dato)
            sqlkurs.Parameters.AddWithValue("@navn", navn)
            sqlkurs.Parameters.AddWithValue("@max", max)
            sqlkurs.Parameters.AddWithValue("@postnr", postnr)
            sqlkurs.Parameters.AddWithValue("@tid", NumericUpDown1.Value)

            sqlkurs.ExecuteNonQuery()


        End If

        Close()

    End Sub


End Class