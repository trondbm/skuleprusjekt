Imports MySql.Data.MySqlClient
Public Class leggtilutleie
    Dim db As New DBConnect




    Private Sub leggtilsalg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        db.DBConnect()
        con.Dispose()
        'load ansatt


        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False


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
            Me.ComboBox3.Items.Clear()
            Me.ComboBox3.Items.AddRange(kunde.ToArray)
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
            Me.ComboBox1.Items.Clear()
            Me.ComboBox1.Items.AddRange(varer.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub combobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim prs As New MySqlCommand("SELECT utleiepris FROM VARE where varenavn = '" & ComboBox1.SelectedItem & "'", con)
        '    Dim pris As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = prs.ExecuteReader(CommandBehavior.CloseConnection)
            rd.Read()

            Label10.Text = rd("utleiepris")

            rd.Close()
            con.Close()

        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox2.SelectedIndex = -1 Then
            MsgBox("Du må velge selger!", MsgBoxStyle.Critical, "Error")
        ElseIf ComboBox3.SelectedIndex = -1 Then
            MsgBox("Du må velge kunde!", MsgBoxStyle.Critical, "Error")
        ElseIf ComboBox1.SelectedIndex = -1 Then
            MsgBox("Du må velge vare!", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox5.Text = "" Then
            MsgBox("Du må velge antall!", MsgBoxStyle.Critical, "Error")
        ElseIf IsNumeric(TextBox5.Text) = False Then
            MsgBox("Antall må være et nummer!", MsgBoxStyle.Critical, "Error")
        Else
            Dim kundeid As String
            Dim ansattid As String
            Dim tall As Integer
            Dim antall As Integer = TextBox5.Text
            Dim fradato As Date = DateTimePicker1.Value.ToString
            Dim tildato As Date = DateTimePicker2.Value.ToString

            Dim antalldager As Int32 = tildato.Subtract(fradato).Days + 1

            Dim totpris As Double = Label10.Text * antall * antalldager

            Dim ansid As New MySqlCommand("SELECT ansatt_id FROM ANSATT where navn = '" & ComboBox2.SelectedItem & "'", con)

            Dim kunid As New MySqlCommand("SELECT kundeID FROM KUNDE where navn = '" & ComboBox3.SelectedItem & "'", con)

            Dim antv As New MySqlCommand("SELECT antall FROM VARE where varenavn = '" & ComboBox1.SelectedItem & "'", con)

            con.Open()


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



            Dim antvare As Integer = tall - antall


            Try

                Dim sqlsalg As New MySqlCommand("INSERT into UTLEIE (startdato, sluttdato, utleie_vare, utleie_antall, utleie_pris, kundeID, ansatt_id) values ('" & DateTimePicker1.Value & "', '" & DateTimePicker2.Value & "', '" & ComboBox1.SelectedItem & "', '" & TextBox5.Text & "', '" & totpris & "', '" & ansattid & "', '" & kundeid & "')", con)
                sqlsalg.ExecuteNonQuery()

                Dim sqlvarecng As New MySqlCommand("UPDATE  VARE SET `antall` =  '" & antvare & "' WHERE  `VARE`.`varenavn` = '" & ComboBox1.SelectedItem & "'", con)
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