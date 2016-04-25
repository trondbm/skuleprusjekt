Imports MySql.Data.MySqlClient
Public Class leggtilbruker

    Dim db As New DBConnect

    Dim brukernavn As String
    Dim passord As String
    Dim type As String

    Private Sub leggtilbruker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db.DBConnect()
        Me.Text = "Legg til bruker"
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        con.Dispose()


        'ansattnavn
        Dim navn As New MySqlCommand("SELECT navn FROM ANSATT", con)
        Dim ansattnavn As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = navn.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim ansattsnavn As String = rd("navn")

                ansattnavn.Add(ansattsnavn)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox1.Items.Clear()
            Me.ComboBox1.Items.AddRange(ansattnavn.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim id As Integer


        If RadioButton1.Checked Then
            type = "admin"
        ElseIf RadioButton2.Checked Then
            type = "selger"
        ElseIf RadioButton3.Checked Then
            type = "lager"
        Else
            MsgBox("Du må velge type bruker", MsgBoxStyle.Critical, "Error")
        End If

        If TextBox1.Text = "" Then
            MsgBox("Du må skrive brukernavn", MsgBoxStyle.Critical, "Error")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Du må skrive passord", MsgBoxStyle.Critical, "Error")
        ElseIf ComboBox1.SelectedItem = Nothing Then
            MsgBox("Du må velge ansatt", MsgBoxStyle.Critical, "Error")
        Else
            brukernavn = TextBox1.Text
            passord = TextBox2.Text

            Dim ans As New MySqlCommand("SELECT ansatt_id FROM ANSATT where navn = '" & ComboBox1.SelectedItem & "'", con)




            con.Open()
                Dim rd As MySqlDataReader = ans.ExecuteReader()
                rd.Read()

                id = rd("ansatt_id")

                rd.Close()




            Try
                Dim sqlkunde = New MySqlCommand("Insert into BRUKERE (Brukernavn, Passord, Type) values (@brukernavn, @passord, @type)", con)
                sqlkunde.Parameters.AddWithValue("@brukernavn", brukernavn)
                sqlkunde.Parameters.AddWithValue("@passord", passord)
                sqlkunde.Parameters.AddWithValue("@type", type)


                sqlkunde.ExecuteNonQuery()

                Dim ansbruker As Integer
                Dim ansbrk As New MySqlCommand("SELECT bruker_id FROM BRUKERE where Brukernavn = '" & TextBox1.Text & "'", con)





                Dim rdansbrk As MySqlDataReader = ansbrk.ExecuteReader()
                rdansbrk.Read()

                ansbruker = rdansbrk("bruker_id")

                rdansbrk.Close()

                Dim sqlansbruker = New MySqlCommand("UPDATE ANSATT SET ansbruker_id= '" & ansbruker & "' where ansatt_id= '" & id & "'", con)

                sqlansbruker.ExecuteNonQuery()


            Catch ex As Exception
                MsgBox("Brukernavnet er i bruk", MsgBoxStyle.Critical, "Error")
            End Try





            db.DBDisconnect()
            Close()

        End If




    End Sub


End Class