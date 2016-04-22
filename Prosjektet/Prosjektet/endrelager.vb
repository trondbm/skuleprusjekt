Imports MySql.Data.MySqlClient
Public Class endrelager

    Dim db As New DBConnect
    Private Sub endrelager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        db.DBConnect()
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        con.Dispose()


        'id

        Dim id As New MySqlCommand("SELECT vareID FROM VARE", con)
        Dim vareid As New List(Of String)
        Try
            con.Open()
            Dim rd As MySqlDataReader = id.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                Dim varenid As String = rd("vareID")

                vareid.Add(varenid)
            End While
            rd.Close()
            con.Close()
            Me.ComboBox1.Items.Clear()
            Me.ComboBox1.Items.AddRange(vareid.ToArray)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        With ComboBox2.Items
            .Add("Tur og redningsutstyr")
            .Add("Øvingsutstyr")
            .add("Førstehjelpsutstyr")
        End With


        With ComboBox3.Items
            .Add("Trondheim")
            .Add("Oslo")
            .Add("Bergen")
            .Add("Stavanger")
            .Add("Bodø")
            .Add("Tromsø")
        End With





        With ComboBox4.Items
            .Add("ubrukt")
            .Add("brukt")
        End With



        With ComboBox5.Items
            .Add("ren")
            .Add("skitten")
        End With


        With ComboBox6.Items
            .Add("tilgjengelig")
            .Add("utilgjengelig")
        End With








    End Sub

    Private Sub combobox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged


        Dim prs As New MySqlCommand("SELECT varenavn, varegruppe, bruk, tilstand, lager, status, antall, pris FROM VARE where vareID = '" & ComboBox1.SelectedItem & "'", con)



        Try
            con.Open()
            Dim rd As MySqlDataReader = prs.ExecuteReader()
            rd.Read()

            TextBox1.Text = rd("varenavn")
            ComboBox2.SelectedItem = rd("varegruppe")
            ComboBox4.SelectedItem = rd("bruk")
            ComboBox3.SelectedItem = rd("lager")
            ComboBox5.SelectedItem = rd("tilstand")
            ComboBox6.SelectedItem = rd("status")
            TextBox2.Text = rd("antall")
            TextBox3.Text = rd("pris")
            rd.Close()









            con.Close()


        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            con.Open()
            Dim sqlsalg As New MySqlCommand("UPDATE VARE SET varenavn='" & TextBox1.Text & "', varegruppe='" & ComboBox2.SelectedItem & "', bruk='" & ComboBox4.SelectedItem & "', tilstand='" & ComboBox3.SelectedItem & "', lager='" & ComboBox5.SelectedItem & "', status='" & ComboBox6.SelectedItem & "', antall='" & TextBox2.Text & "', pris='" & TextBox3.Text & "' where vareID=" & ComboBox1.SelectedItem, con)



            sqlsalg.ExecuteNonQuery()
            con.Close()
            Close()

        Catch ex As Exception



        End Try


    End Sub


End Class