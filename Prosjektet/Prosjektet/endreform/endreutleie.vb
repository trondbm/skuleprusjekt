Imports MySql.Data.MySqlClient
Public Class endreutleie

    Dim db As New DBConnect


    Private Sub endresalg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db.DBConnect()
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        con.Dispose()


        'salgid
        Dim id As New MySqlCommand("SELECT utleieID FROM UTLEIE", con)
        Dim utleieid As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = id.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim utleiesid As String = rd("utleieID")

                utleieid.Add(utleiesid)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox1.Items.Clear()
            Me.ComboBox1.Items.AddRange(utleieid.ToArray)
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
            Me.ComboBox3.Items.Clear()
            Me.ComboBox3.Items.AddRange(ansatt.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        'load kunde


        Dim knd As New MySqlCommand("SELECT navn FROM KUNDE", con)
        Dim kunde As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = knd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim kunder As String = rd("navn")

                kunde.Add(kunder)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox4.Items.Clear()
            Me.ComboBox4.Items.AddRange(kunde.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        'load varer

        Dim var As New MySqlCommand("SELECT varenavn FROM VARE", con)
        Dim varer As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = var.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim vare As String = rd("varenavn")

                varer.Add(vare)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox5.Items.Clear()
            Me.ComboBox5.Items.AddRange(varer.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub combobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim kundeid As Integer
        Dim ansattid As Integer

        Dim prs As New MySqlCommand("SELECT startdato, sluttdato, utleie_vare, utleie_antall, utleie_pris, kundeID, ansatt_id FROM UTLEIE where utleieID = '" & ComboBox1.SelectedItem & "'", con)



        Try





            con.Open()
            Dim rd As MySqlDataReader = prs.ExecuteReader()
            rd.Read()


            DateTimePicker3.Value = rd("startdato")
            DateTimePicker2.Value = rd("sluttdato")
            ComboBox5.SelectedItem = rd("utleie_vare")
            TextBox5.Text = rd("utleie_antall")

            kundeid = rd("kundeID")
            ansattid = rd("ansatt_id")


            rd.Close()



            'pris fra vare
            Dim pris As New MySqlCommand("SELECT utleiepris FROM VARE where varenavn = '" & ComboBox5.SelectedItem & "'", con)



            Dim rdpris As MySqlDataReader = pris.ExecuteReader()
            rdpris.Read()

            Label10.Text = rdpris("utleiepris")

            rdpris.Close()


            ' noe feil med kundeID og ansatt_id er lik noe dim... veit ikke hva som er feil... fungerer med hardkoding men ikke en dim... leste kundeid 1 som ikke finns... sjekke leggtilutleie.. kundeid blir lagt til feil
            ' alt greit kopier fra endresalg


            Dim ansattnavn As New MySqlCommand("SELECT navn from ANSATT where ansatt_id = '" & ansattid & "'", con)


            'ansattnavn

            Dim rda As MySqlDataReader = ansattnavn.ExecuteReader()
            rda.Read()


            ComboBox3.SelectedItem = rda("navn")

            rda.Close()


            Dim kundenavn As New MySqlCommand("SELECT navn from KUNDE where kundeID = '" & kundeid & "'", con)
            'kundenavn


            Dim rdk As MySqlDataReader = kundenavn.ExecuteReader()
            rdk.Read()


            ComboBox4.SelectedItem = rdk("navn")

            rdk.Close()
            con.Close()

        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        con.Close()
        End Try




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim kundeid As String
        Dim ansattid As String
        Dim tall As Integer
        Dim antall As Integer = TextBox5.Text
        Dim utleieantall As Integer
        Dim fradato As Date = DateTimePicker3.Value.ToString
        Dim tildato As Date = DateTimePicker2.Value.ToString

        Dim antalldager As Int32 = tildato.Subtract(fradato).Days + 1



        Dim finalpris As Double = Label10.Text * antall * antalldager

        Dim ansid As New MySqlCommand("SELECT ansatt_id FROM ANSATT where navn = '" & ComboBox3.SelectedItem & "'", con)

        Dim kunid As New MySqlCommand("SELECT kundeID FROM KUNDE where navn = '" & ComboBox4.SelectedItem & "'", con)

        Dim antv As New MySqlCommand("SELECT antall FROM VARE where varenavn = '" & ComboBox5.SelectedItem & "'", con)

        Dim antsv As New MySqlCommand("SELECT utleie_antall FROM UTLEIE where utleieID = '" & ComboBox1.SelectedItem & "'", con)




        'leser ansattid
        Dim rd As MySqlDataReader = ansid.ExecuteReader()
        rd.Read()

        ansattid = rd("ansatt_id")


        rd.Close()


        'leser antallvare
        Dim rdvare As MySqlDataReader = antv.ExecuteReader()
        rdvare.Read()

        tall = rdvare("antall")


        rdvare.Close()


        'leser kundeid
        Dim rde As MySqlDataReader = kunid.ExecuteReader()
        rde.Read()

        kundeid = rde("kundeID")

        rde.Close()

        'leser antallvare på salg
        Dim rdantvare As MySqlDataReader = antsv.ExecuteReader()
        rdantvare.Read()

        utleieantall = rdantvare("utleie_antall")


        rdantvare.Close()


        Dim organtvare As Integer = tall + utleieantall

        Dim antvare As Integer = organtvare - antall

        If antvare < 0 Then
            MsgBox("Det er ikke nok varer til å fullføre endringen")
        Else

            Try

                Dim sqlsalg As New MySqlCommand("UPDATE UTLEIE SET startdato='" & DateTimePicker3.Value & "', sluttdato='" & DateTimePicker2.Value & "', utleie_vare='" & ComboBox5.SelectedItem & "', utleie_antall='" & TextBox5.Text & "', utleie_pris='" & Label10.Text & "', kundeid='" & kundeid & "', ansatt_id='" & ansattid & "' where utleieid='" & ComboBox1.SelectedItem & "'", con)
                sqlsalg.ExecuteNonQuery()

                Dim sqlvarecng As New MySqlCommand("UPDATE  VARE SET `antall` =  '" & antvare & "' WHERE  `VARE`.`varenavn` = '" & ComboBox5.SelectedItem & "'", con)
                sqlvarecng.ExecuteNonQuery()

                con.Close()
                Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                con.Close()
            End Try

        End If

    End Sub


End Class