Imports MySql.Data.MySqlClient
Public Class endrebruker

    Dim db As New DBConnect

    Dim id As String
    Dim brukernavn As String
    Dim passord As String
    Dim type As String



    Private Sub endrebruker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Endre bruker"

        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        db.DBConnect()

        con.Dispose()


        'brukerid
        Dim id As New MySqlCommand("SELECT bruker_id FROM BRUKERE", con)
        Dim brukerid As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = id.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim ansattsid As String = rd("bruker_id")

                brukerid.Add(ansattsid)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox1.Items.Clear()
            Me.ComboBox1.Items.AddRange(brukerid.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try


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
            Me.ComboBox2.Items.Clear()
            Me.ComboBox2.Items.AddRange(ansattnavn.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub combobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged




        Dim ans As New MySqlCommand("SELECT Brukernavn, Passord, Type FROM BRUKERE where bruker_id = '" & ComboBox1.SelectedItem & "'", con)



        Try
            con.Open()
            Dim rd As MySqlDataReader = ans.ExecuteReader()
            rd.Read()


            TextBox2.Text = rd("Passord")
            TextBox1.Text = rd("Brukernavn")


            rd.Close()





            con.Close()


        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try

        Dim ansnavn As New MySqlCommand("SELECT navn FROM ANSATT where ansbruker_id = '" & ComboBox1.SelectedItem & "'", con)



        Try
            con.Open()
            Dim rd As MySqlDataReader = ansnavn.ExecuteReader()
            rd.Read()


            ComboBox2.SelectedItem = rd("navn")


            rd.Close()





            con.Close()


        Catch ex As System.Exception
            MsgBox("Brukeren er ikke tilknyttet en ansatt!", MsgBoxStyle.Information, "Error")
            con.Close()
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        con.Open()

        Dim type As String


        If RadioButton1.Checked Then
            type = "admin"
        ElseIf RadioButton2.Checked Then
            type = "selger"
        ElseIf RadioButton3.Checked Then
            type = "lager"
        Else

        End If

        If TextBox1.Text = "" Then
            MsgBox("Du må skrive brukernavn", MsgBoxStyle.Critical, "Error")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Du må skrive passord", MsgBoxStyle.Critical, "Error")


        Else

            If RadioButton1.Checked Or RadioButton2.Checked Or RadioButton3.Checked Then


                Try
                    Dim sqlbrk As New MySqlCommand("UPDATE BRUKERE SET Brukernavn='" & TextBox1.Text & "', Passord='" & TextBox2.Text & "', Type='" & type & "' where bruker_id=" & ComboBox1.SelectedItem, con)
                    sqlbrk.ExecuteNonQuery()



                    Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)

                End Try

                Try
                    Dim sqlans As New MySqlCommand("UPDATE ANSATT SET ansbruker_id='" & ComboBox1.SelectedItem & "' where navn='" & ComboBox2.SelectedItem & "'", con)
                    sqlans.ExecuteNonQuery()



                    Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)

                End Try

            Else
                MsgBox("Velg type", MsgBoxStyle.Critical, "Error")
            End If

        End If
        con.Close()




    End Sub




End Class