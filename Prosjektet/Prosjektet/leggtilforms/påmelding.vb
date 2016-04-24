Imports MySql.Data.MySqlClient
Public Class påmelding

    Dim db As New DBConnect


    Private Sub påmelding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db.DBConnect()
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        con.Dispose()
        Label8.Text = ""

        'salgid
        Dim id As New MySqlCommand("SELECT kurs_id FROM KURS", con)
        Dim kursid As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = id.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim idkurs As String = rd("kurs_id")

                kursid.Add(idkurs)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox1.Items.Clear()
            Me.ComboBox1.Items.AddRange(kursid.ToArray)
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




    End Sub

    Private Sub combobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim ansattid As Integer


        Dim prs As New MySqlCommand("SELECT kursnavn, ansatt_id, dato, tidslengde, maxantall, påmeldt, postnr FROM KURS where kurs_id = '" & ComboBox1.SelectedItem & "'", con)

        Dim antv As New MySqlCommand("SELECT maxantall FROM KURS where kurs_id = '" & ComboBox1.SelectedItem & "'", con)

        Dim påmeld As New MySqlCommand("SELECT påmeldt FROM KURS where kurs_id = '" & ComboBox1.SelectedItem & "'", con)



        Dim knde As New MySqlCommand("SELECT kundeID FROM KUNDE where navn = '" & ComboBox4.SelectedItem & "'", con)

        Try
            con.Open()
            Dim rd As MySqlDataReader = prs.ExecuteReader()
            rd.Read()


            Label9.Text = rd("dato")

            Label6.Text = rd("kursnavn")


            ansattid = rd("ansatt_id")


            rd.Close()



            'ansattnavn
            Dim ansattnavn As New MySqlCommand("SELECT navn from ANSATT where ansatt_id = '" & ansattid & "'", con)

            Dim rda As MySqlDataReader = ansattnavn.ExecuteReader()
            rda.Read()


            Label10.Text = rda("navn")

            rda.Close()



            Dim antall As String
            Dim pameldt As String

            'leser påmeldte på kurs
            Dim rdantvare As MySqlDataReader = påmeld.ExecuteReader()
            rdantvare.Read()

            pameldt = rdantvare("påmeldt")


            rdantvare.Close()


            'leser maxantall
            Dim rdvare As MySqlDataReader = antv.ExecuteReader()
            rdvare.Read()

            antall = rdvare("maxantall")


            rdvare.Close()


            Label8.Text = antall - pameldt

            con.Close()

        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()

        Dim kundeid As Integer
        Dim påmeldt As Integer
        Dim kursnavn As String
        Dim max As Integer




        Dim ansid As New MySqlCommand("SELECT kursnavn FROM KURS where kurs_id = '" & ComboBox1.SelectedItem & "'", con)

        Dim kunid As New MySqlCommand("SELECT kundeID FROM KUNDE where navn = '" & ComboBox4.SelectedItem & "'", con)

        Dim antv As New MySqlCommand("SELECT maxantall FROM KURS where kurs_id = '" & ComboBox1.SelectedItem & "'", con)

        Dim påmeld As New MySqlCommand("SELECT påmeldt FROM KURS where kurs_id = '" & ComboBox1.SelectedItem & "'", con)




        'leser kursnavn
        Dim rd As MySqlDataReader = ansid.ExecuteReader()
        rd.Read()

        kursnavn = rd("kursnavn")


        rd.Close()



        'leser kundeid
        Dim rde As MySqlDataReader = kunid.ExecuteReader()
        rde.Read()

        kundeid = rde("kundeID")

        rde.Close()

        'leser påmeldte
        Dim rdmeld As MySqlDataReader = påmeld.ExecuteReader()
        rdmeld.Read()

        påmeldt = rdmeld("påmeldt")

        rdmeld.Close()

        'leser maxantall
        Dim rdmax As MySqlDataReader = antv.ExecuteReader()
        rdmax.Read()

        max = rdmax("maxantall")

        rdmax.Close()






        Dim plasser As Integer = max - (påmeldt + 1)

        If plasser < 0 Then
            MsgBox("Det er ikke nok plasser til å fullføre påmeldingen", MsgBoxStyle.Critical, "Error")
        Else
            Try



                Dim pameld As New MySqlCommand("INSERT into MELDTPÅ_KURS (kursID, kundeID, kursnavn, kundenavn) values ('" & ComboBox1.SelectedItem & "', '" & kundeid & "', '" & kursnavn & "', '" & ComboBox4.SelectedItem & "')", con)
                pameld.ExecuteNonQuery()

                Dim sqlpmldcng As New MySqlCommand("UPDATE  KURS SET `påmeldt` =  '" & påmeldt + 1 & "' WHERE  `KURS`.`kurs_id` = '" & ComboBox1.SelectedItem & "'", con)
                sqlpmldcng.ExecuteNonQuery()

                con.Close()
                Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try

        End If




    End Sub


End Class