Imports MySql.Data.MySqlClient
Public Class endreansatt

    Dim db As New DBConnect


    Private Sub endreansatt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db.DBConnect()
        Me.Text = "Endre ansatt"
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        con.Dispose()


        'salgid
        Dim id As New MySqlCommand("SELECT ansatt_id FROM ANSATT", con)
        Dim ansattid As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = id.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim ansattsid As String = rd("ansatt_id")

                ansattid.Add(ansattsid)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox1.Items.Clear()
            Me.ComboBox1.Items.AddRange(ansattid.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub combobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        'Dim navn As string


        Dim ans As New MySqlCommand("SELECT ansatt_id, stilling, navn, tlf, epost FROM ANSATT where ansatt_id = '" & ComboBox1.SelectedItem & "'", con)



        Try
            con.Open()
            Dim rd As MySqlDataReader = ans.ExecuteReader()
            rd.Read()


            TextBox2.Text = rd("navn")
            TextBox1.Text = rd("tlf")
            TextBox4.Text = rd("epost")

            rd.Close()





            con.Close()


        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()

        Dim stilling As String

        If RadioButton1.Checked Then
            stilling = "Selger"
        ElseIf RadioButton2.Checked Then
            stilling = "Lagerarbeider"
        ElseIf RadioButton3.Checked Then
            stilling = "IT-hjelp"
        ElseIf RadioButton4.Checked Then
            stilling = "Instruktør"


        End If

        If TextBox1.Text = "" Then
            MsgBox("Du må skrive telefonnummer", MsgBoxStyle.Critical, "Error")
        ElseIf isnumeric(TextBox1.text) = False Then
            MsgBox("Du må skrive tall for telefonnummer", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox4.Text = "" Then
            MsgBox("Du må skrive epost", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Du må skrive navn", MsgBoxStyle.Critical, "Error")

        Else

            If RadioButton1.Checked Or RadioButton2.Checked Or RadioButton3.Checked Then
                Try
                    Dim sqlans As New MySqlCommand("UPDATE ANSATT SET stilling='" & stilling & "', navn='" & TextBox2.Text & "', tlf='" & TextBox1.Text & "', epost='" & TextBox4.Text & "' where ansatt_id=" & ComboBox1.SelectedItem, con)
                    sqlans.ExecuteNonQuery()



                    Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)

                End Try



            Else
                MsgBox("Velg stilling", MsgBoxStyle.Critical, "Error")
            End If
        End If


            con.Close()



    End Sub


End Class