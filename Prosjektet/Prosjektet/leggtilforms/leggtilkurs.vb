Imports MySql.Data.MySqlClient
Public Class leggtilkurs
    Dim db As New DBConnect

    Dim navn As String
    Dim dato As String
    Dim max As Integer

    Dim postnr As Integer

    Private Sub leggtilkurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Text = "Legg til kurs"
        db.DBConnect()
        con.Dispose()
        'load ansatt
        Dim ans As New MySqlCommand("SELECT navn FROM ANSATT", con)
        Dim ansatt As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = ans.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim ansatte As String = rd("navn")

                ansatt.Add(ansatte)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox1.Items.Clear()
            Me.ComboBox1.Items.AddRange(ansatt.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ansattid As Integer

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

            con.Open()
            Dim ansid As New MySqlCommand("SELECT ansatt_id FROM ANSATT where navn = '" & ComboBox1.SelectedItem & "'", con)

            'leser ansattid
            Dim rd As MySqlDataReader = ansid.ExecuteReader()
            rd.Read()

            ansattid = rd("ansatt_id")


            rd.Close()


            Dim sqlkurs = New MySqlCommand("Insert into KURS (ansatt_id, dato, kursnavn, maxantall, postnr, tidslengde) values ('" & ansattid & "', @dato, @navn, @max, @postnr, @tid)", con)
            sqlkurs.Parameters.AddWithValue("@dato", dato)
            sqlkurs.Parameters.AddWithValue("@navn", navn)
            sqlkurs.Parameters.AddWithValue("@max", max)
            sqlkurs.Parameters.AddWithValue("@postnr", postnr)
            sqlkurs.Parameters.AddWithValue("@tid", NumericUpDown1.Value)

            sqlkurs.ExecuteNonQuery()
            con.Close()

        End If

        Close()

    End Sub


End Class