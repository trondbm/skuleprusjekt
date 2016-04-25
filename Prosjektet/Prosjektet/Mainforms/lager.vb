Imports MySql.Data.MySqlClient
Public Class lager

    Dim db As New DBConnect
    Dim dataset As New DataTable
    Dim sda As New MySqlDataAdapter
    Dim bsource As New BindingSource
    Dim vare As String
    Dim lager As String

    Public Sub load_table()
        DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        dataset.Clear()
        Try
            Dim query As String
            query = "Select * from VARE"
            Dim sqlsøk = New MySqlCommand(query, con)
            sda.SelectCommand = sqlsøk
            sda.Fill(dataset)
            bsource.DataSource = dataset
            DataGridView1.DataSource = bsource
            sda.Update(dataset)

        Catch ex As MySqlException
            MsgBox("Error")
        End Try
    End Sub

    Public Sub load_location()

        DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        dataset.Clear()
        Try
            Dim query As String
            query = "Select * from VARE where lager = '" + lager + "'"
            Dim sqlsøk = New MySqlCommand(query, con)
            sda.SelectCommand = sqlsøk
            sda.Fill(dataset)
            bsource.DataSource = dataset
            DataGridView1.DataSource = bsource
            sda.Update(dataset)

        Catch ex As MySqlException
            MsgBox("Error")
        End Try
    End Sub

    Private Sub kurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Text = "Lager"
        db.DBConnect()
        load_table()




    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Vareregistrering.Show()
        AddHandler Vareregistrering.FormClosed, AddressOf load_table
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Close()
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        con.Dispose()

        vare = InputBox("Hvilken vare_id vil du slette?", "Slett vare")

        If vare = "" Then
            load_table()
        ElseIf IsNumeric(vare) = False Then
            MsgBox("Du må skrive et tall!", MsgBoxStyle.Critical, "Error")
        Else
            con.Open()
            Try
                Dim sqlkurs = New MySqlCommand("DELETE FROM VARE WHERE vareID = " & vare, con)



                sqlkurs.ExecuteNonQuery()
                con.Close()
            Catch ex As MySqlException
                con.Close()
            End Try

            load_table()

        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        endrelager.Show()

        AddHandler endrelager.FormClosed, AddressOf load_table


    End Sub




    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        dataset.Clear()
        load_table()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        lager = "Trondheim"

        load_location()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        lager = "Oslo"

        load_location()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        lager = "Bodø"

        load_location()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        lager = "Bergen"

        load_location()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        lager = "Stavanger"

        load_location()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        lager = "Tromsø"

        load_location()
    End Sub
End Class