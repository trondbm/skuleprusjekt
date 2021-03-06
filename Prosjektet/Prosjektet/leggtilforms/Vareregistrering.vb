﻿Imports mysql.data.MySqlClient
Public Class Vareregistrering

    Dim DB As New DBConnect


    Dim varenavn As String
    Dim antall As Integer
    Dim varegruppe As String = ""
    Dim lager As String = ""
    Dim pris As Double



    Private Sub Vareregistrering_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        DB.DBConnect()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox3.Text = TextBox3.Text.Replace(".", ",")


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

        TextBox3.Text = TextBox3.Text.Replace(".", ",")

        If TextBox1.Text = "" Then
            MsgBox("Du må skrive inn et varenavn!", MsgBoxStyle.Critical, "Error")
        ElseIf IsNumeric(TextBox2.Text) = False Then
            MsgBox("Du må skrive inn et antall!", MsgBoxStyle.Critical, "Error")
        ElseIf varegruppe = "" Then
            MsgBox("Du må velge en varegruppe!", MsgBoxStyle.Critical, "Error")
        ElseIf lager = "" Then
            MsgBox("Du må velge et lager!", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox3.Text = "" Then
            MsgBox("Du må velge pris!", MsgBoxStyle.Critical, "Error")
        ElseIf IsNumeric(TextBox3.text) = False Then
            MsgBox("Prisen må være et tall!", MsgBoxStyle.Critical, "Error")
        Else
            TextBox3.Text = TextBox3.Text.Replace(".", ",")
            varenavn = TextBox1.Text
            antall = TextBox2.Text
            pris = TextBox3.Text




            Dim sqlvare = New MySqlCommand("insert into VARE (varenavn, varegruppe, bruk, tilstand, lager, status, antall, pris) values (@Varenavn, @Varegruppe, @Ubrukt, @Ren, @Lager, @Tilgjengelig, @antall, @pris)", con)
            sqlvare.Parameters.AddWithValue("@Varenavn", varenavn)
                sqlvare.Parameters.AddWithValue("@Varegruppe", varegruppe)
                sqlvare.Parameters.AddWithValue("@Ubrukt", "ubrukt")
                sqlvare.Parameters.AddWithValue("@Ren", "ren")
                sqlvare.Parameters.AddWithValue("@Lager", lager)
            sqlvare.Parameters.AddWithValue("@Tilgjengelig", "tilgjengelig")
            sqlvare.Parameters.AddWithValue("@antall", antall)
            sqlvare.Parameters.AddWithValue("@pris", pris)



            sqlvare.ExecuteNonQuery()
            DB.DBDisconnect()
            Close()

        End If

    End Sub



End Class