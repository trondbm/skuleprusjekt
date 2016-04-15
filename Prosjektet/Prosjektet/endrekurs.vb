Imports MySql.Data.MySqlClient
Public Class endrekurs

    Dim db As New DBConnect

    Dim epostnr As Integer
    Dim ekursnavn As String
    Dim edato As String
    Dim emaxantall As Integer
    Dim kurs As Integer



    Private Sub endrekurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Endre kurs"
        db.DBConnect()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox2.Text = TextBox2.Text.Replace(",", ".")
        kurs = NumericUpDown2.Value

        'kursnavn
        If CheckBox2.Checked Then
            ekursnavn = TextBox1.Text
            If TextBox1.Text = "" Then
                MsgBox("Du må skrive inn navn", MsgBoxStyle.Critical, "Error")
            Else
                Try
                    Dim sqlekurs = New MySqlCommand("UPDATE KURS SET kursnavn='" & ekursnavn & "' where kurs_id='" & kurs & "'", con)
                    sqlekurs.ExecuteNonQuery()
                Catch ex As MySqlException
                    MsgBox("Noe gikk galt med å oppdatere kursnavn!", MsgBoxStyle.Critical, "Error")
                End Try
            End If

        End If

        'dato
        If CheckBox3.Checked Then
            edato = DateTimePicker1.Text
            Try
                Dim sqledkurs = New MySqlCommand("UPDATE KURS SET dato='" & edato & "' where kurs_id='" & kurs & "'", con)
                sqledkurs.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Noe gikk galt med å oppdatere dato!", MsgBoxStyle.Critical, "Error")
            End Try
        End If

        'tid
        If CheckBox4.Checked Then

            If TextBox2.Text = "" Then
                MsgBox("Du må skrive inn tid", MsgBoxStyle.Critical, "Error")
            ElseIf IsNumeric(TextBox2.Text) = False Then
                If InStr(TextBox2.Text, ".") Then
                    Dim etid As String
                    etid = TextBox2.Text

                    Try
                        Dim sqletkurs = New MySqlCommand("UPDATE KURS SET tidslengde='" & etid & "' where kurs_id='" & kurs & "'", con)
                        sqletkurs.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox("Noe gikk galt med å oppdatere tidslengde!", MsgBoxStyle.Critical, "Error")
                    End Try
                Else
                    MsgBox("Du må skrive tall i 'tidslengde'", MsgBoxStyle.Critical, "Error")
                End If
            End If
        End If

        'antall
        If CheckBox5.Checked Then

            If TextBox5.Text = "" Then
                MsgBox("Du må skrive inn et antall", MsgBoxStyle.Critical, "Error")
            ElseIf InStr(TextBox5.text, ".") Or InStr(TextBox5.Text, ",") Then
                MsgBox("Det finnes ingen halvepersoner", MsgBoxStyle.Critical, "Error")
            ElseIf IsNumeric(TextBox5.Text) = False Then
                MsgBox("Du må skrive tall i 'Maxantall'", MsgBoxStyle.Critical, "Error")

            Else
                emaxantall = TextBox5.Text
                Try
                    Dim sqlemkurs = New MySqlCommand("UPDATE KURS SET maxantall='" & emaxantall & "' where kurs_id='" & kurs & "'", con)
                    sqlemkurs.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Noe gikk galt med å oppdatere antall!", MsgBoxStyle.Critical, "Error")
                End Try

            End If
        End If

        'postnr
        If CheckBox6.Checked Then

            If TextBox6.Text = "" Then
                MsgBox("Du må skrive inn et postnummer", MsgBoxStyle.Critical, "Error")
            ElseIf InStr(TextBox6.text, ".") Or InStr(TextBox6.Text, ",") Then
                MsgBox("Det er ingen postnr som bruker . eller ,", MsgBoxStyle.Critical, "Error")
            ElseIf IsNumeric(TextBox6.Text) = False Then
                MsgBox("Du må skrive tall i 'Postnummer'", MsgBoxStyle.Critical, "Error")

            Else
                epostnr = TextBox6.Text
                Try
                    Dim sqlepkurs = New MySqlCommand("UPDATE KURS SET postnr='" & epostnr & "' where kurs_id='" & kurs & "'", con)
                    sqlepkurs.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Noe gikk galt med å oppdatere postnummer!", MsgBoxStyle.Critical, "Error")
                End Try

            End If
        End If


        '    Try
        '        Dim sqlekurs = New MySqlCommand("UPDATE KURS SET kursnavn='" & ekursnavn & "' where kurs_id='" & kurs & "'", con)
        '        Dim sqledkurs = New MySqlCommand("UPDATE KURS SET dato='" & edato & "' where kurs_id='" & kurs & "'", con)
        '        Dim sqletkurs = New MySqlCommand("UPDATE KURS SET tidslengde='" & etidslengde & "' where kurs_id='" & kurs & "'", con)
        '        Dim sqlemkurs = New MySqlCommand("UPDATE KURS SET maxantall='" & emaxantall & "' where kurs_id='" & kurs & "'", con)
        '        Dim sqlepkurs = New MySqlCommand("UPDATE KURS SET postnr='" & epostnr & "' where kurs_id='" & kurs & "'", con)

        '        'sqlekurs.Parameters.AddWithValue("@kursnavn", ekursnavn)
        '        'sqlekurs.Parameters.AddWithValue("@kurs", edato)
        '        'sqlekurs.Parameters.AddWithValue("@kurs", etidslengde)
        '        'sqlekurs.Parameters.AddWithValue("@kurs", emaxantall)
        '        'sqlekurs.Parameters.AddWithValue("@kurs", epostnr)



        '        sqlekurs.ExecuteNonQuery()
        '        sqledkurs.ExecuteNonQuery()
        '        sqletkurs.ExecuteNonQuery()
        '        sqlemkurs.ExecuteNonQuery()
        '        sqlepkurs.ExecuteNonQuery()

        '        MsgBox("Kurs med id nummer " & kurs & " er endret.", MsgBoxStyle.Information, "Suksess!")


        '    Catch ex As MySqlException
        '        MsgBox("Noe gikk galt! lol", MsgBoxStyle.Critical, "Error!")
        '    End Try






    End Sub




End Class