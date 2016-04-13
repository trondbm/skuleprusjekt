Imports MySql.Data.MySqlClient
Public Class leggtilkunde

    Dim db As New DBConnect

    Dim kundetype As String = ""
    Dim navn As String = ""
    Dim annet As String = ""
    Dim epost As String
    Dim tlf As Integer


    Private Sub leggtilkunde_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Legg til kunde"
        db.DBConnect()

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = False
        Label4.Visible = False
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = False
        TextBox4.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = True
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = True
        TextBox4.Visible = False
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = True
        Label4.Visible = True
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = True
        TextBox4.Visible = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




        If RadioButton1.Checked Then
            kundetype = "Privat"
            navn = TextBox2.Text + ", " + TextBox1.Text
        ElseIf RadioButton2.Checked Then
            kundetype = "Firma"
            navn = TextBox3.Text
        ElseIf radiobutton3.checked Then
            kundetype = TextBox4.Text
            navn = TextBox3.Text
        End If


        If kundetype = "" Then
            MsgBox("Du må velge kundetype.")
        ElseIf navn = "" Then
            MsgBox("Du må skrive navn")
        ElseIf navn = ", " Then
            MsgBox("Du må skrive navn")
        ElseIf TextBox5.text = "" Then
            MsgBox("Du må skrive epost")
        ElseIf TextBox6.text = "" Then
            MsgBox("Skriv et telefonnummer")
        ElseIf IsNumeric(textbox6.text) = False Then
            MsgBox("Skriv et telefonnummer med bare tall")


        Else
            epost = TextBox5.Text
            tlf = TextBox6.Text
            MsgBox("Du har nå lagt til" & navn & vbCrLf & "Tlf: " & tlf & vbCrLf & "Epost: " & epost)

            Dim sqlkunde = New MySqlCommand("Insert into KUNDE (kundetype, navn, epost, tlf) values (@kundetype, @navn, @epost, @tlf)", con)
            sqlkunde.Parameters.AddWithValue("@kundetype", kundetype)
            sqlkunde.Parameters.AddWithValue("@navn", navn)
            sqlkunde.Parameters.AddWithValue("@epost", epost)
            sqlkunde.Parameters.AddWithValue("@tlf", tlf)

            sqlkunde.ExecuteNonQuery()




            db.DBDisconnect()
            Close()

        End If

    End Sub


End Class


