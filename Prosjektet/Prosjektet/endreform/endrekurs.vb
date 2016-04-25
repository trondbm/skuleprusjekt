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

        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        db.DBConnect()
        con.Dispose()

        'kursid
        Dim id As New MySqlCommand("SELECT kurs_id FROM KURS", con)
        Dim kursid As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = id.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim kurssid As String = rd("kurs_id")

                kursid.Add(kurssid)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox1.Items.Clear()
            Me.ComboBox1.Items.AddRange(kursid.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

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
            Me.ComboBox2.Items.Clear()
            Me.ComboBox2.Items.AddRange(ansatt.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub combobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim ansattid As Integer

        Dim kurs As New MySqlCommand("SELECT kursnavn, ansatt_id, dato, tidslengde, maxantall, påmeldt, postnr FROM KURS where kurs_id = '" & ComboBox1.SelectedItem & "'", con)



        Try





            con.Open()
            Dim rd As MySqlDataReader = kurs.ExecuteReader()
            rd.Read()

            TextBox1.Text = rd("kursnavn")
            TextBox2.Text = rd("tidslengde")
            TextBox5.Text = rd("maxantall")
            Label8.Text = rd("påmeldt")
            TextBox6.Text = rd("postnr")
            DateTimePicker1.Value = rd("dato")
            ansattid = rd("ansatt_id")



            rd.Close()








            Dim ansattnavn As New MySqlCommand("SELECT navn from ANSATT where ansatt_id = '" & ansattid & "'", con)


            'ansattnavn

            Dim rda As MySqlDataReader = ansattnavn.ExecuteReader()
            rda.Read()


            ComboBox2.SelectedItem = rda("navn")

            rda.Close()

            con.Close()

        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try




    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim anstid As Integer
        con.Open()

        TextBox2.Text = TextBox2.Text.Replace(".", ",")
        Dim ansid As New MySqlCommand("SELECT ansatt_id FROM ANSATT where navn = '" & ComboBox2.SelectedItem & "'", con)


        'leser ansattid
        Dim rd As MySqlDataReader = ansid.ExecuteReader()
        rd.Read()

        anstid = rd("ansatt_id")


        rd.Close()
        con.Close()

        If TextBox1.Text = "" Then
            MsgBox("Et av feltene er tomme", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox5.Text = "" Then
            MsgBox("Et av feltene er tomme", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Et av feltene er tomme", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox6.Text = "" Then
            MsgBox("Et av feltene er tomme", MsgBoxStyle.Critical, "Error")
        ElseIf IsNumeric(TextBox6.Text) = False Then
            MsgBox("Noen av feltene krever tall og ikke bokstaver", MsgBoxStyle.Critical, "Error")
        ElseIf IsNumeric(TextBox2.Text) = False Then
            MsgBox("Noen av feltene krever tall og ikke bokstaver", MsgBoxStyle.Critical, "Error")
        ElseIf IsNumeric(TextBox5.Text) = False Then
            MsgBox("Noen av feltene krever tall og ikke bokstaver", MsgBoxStyle.Critical, "Error")
        Else
            TextBox2.Text = TextBox2.Text.Replace(",", ".")
            Try
                con.Open()
                Dim sqlsalg As New MySqlCommand("UPDATE KURS SET kursnavn='" & TextBox1.Text & "', ansatt_id='" & anstid & "', dato='" & DateTimePicker1.Value & "', tidslengde='" & TextBox2.Text & "', maxantall='" & TextBox5.Text & "', påmeldt='" & Label8.Text & "', postnr='" & TextBox6.Text & "' where kurs_id= '" & ComboBox1.SelectedItem & "'", con)
                sqlsalg.ExecuteNonQuery()



                con.Close()
                Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                con.Close()
            End Try


        End If






    End Sub




End Class