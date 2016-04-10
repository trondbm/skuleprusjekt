﻿Imports mysql.data.MySqlClient
Public Class Vareregistrering

    Dim DB As New DBConnect

    'Dim tilkobling As MySqlConnection
    Private Sub Vareregistrering_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'tilkobling = New MySqlConnection()
        'tilkobling.Open()

        DB.DBConnect()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim varenavn = TextBox1.Text
        Dim antall As Integer = TextBox2.Text
        Dim varegruppe = ""
        Dim lager = ""

        If RadioButton1.Checked = True Then
            varegruppe = "Tur og redningsutstyr"
        ElseIf RadioButton2.Checked = True Then
            varegruppe = "Øvingsutstyr"
        ElseIf RadioButton3.Checked = True Then
            varegruppe = "Førstehjelpsutstyr"
        End If

        If RadioButton4.Checked = True Then
            lager = "Trondheim"
        ElseIf RadioButton5.Checked = True Then
            lager = "Oslo"
        ElseIf RadioButton6.Checked = True Then
            lager = "Bergen"
        ElseIf RadioButton7.Checked = True Then
            lager = "Stavanger"
        ElseIf RadioButton8.Checked = True Then
            lager = "Bodø"
        ElseIf RadioButton9.Checked = True Then
            lager = "Tromsø"
        End If

        If varenavn = "" Then
            MsgBox("Du må skrive inn et varenavn!")
        ElseIf IsNumeric(antall) = False Then
            MsgBox("Du må skrive inn et antall!")
        ElseIf varegruppe = "" Then
            MsgBox("Du må velge en varegruppe!")
        ElseIf lager = "" Then
            MsgBox("Du må velge et lager!")
        Else

            MsgBox("Varenavn: " & varenavn & vbCrLf & "Antall: " & antall & vbCrLf & "Varegruppe: " & varegruppe & vbCrLf & "Lager: " & lager)



            Dim sqlvare = New MySqlCommand("insert into VARE (varenavn, varegruppe, bruk, tilstand, lager, status, antall) values (@Varenavn, @Varegruppe, @Ubrukt, @Ren, @Lager, @Tilgjengelig, @antall)", con)
            sqlvare.Parameters.AddWithValue("@Varenavn", varenavn)
                sqlvare.Parameters.AddWithValue("@Varegruppe", varegruppe)
                sqlvare.Parameters.AddWithValue("@Ubrukt", "ubrukt")
                sqlvare.Parameters.AddWithValue("@Ren", "ren")
                sqlvare.Parameters.AddWithValue("@Lager", lager)
            sqlvare.Parameters.AddWithValue("@Tilgjengelig", "tilgjengelig")
            sqlvare.Parameters.AddWithValue("@antall", antall)




            sqlvare.ExecuteNonQuery()


        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Meny.Show()
        Close()

        DB.DBDisconnect()

    End Sub

End Class