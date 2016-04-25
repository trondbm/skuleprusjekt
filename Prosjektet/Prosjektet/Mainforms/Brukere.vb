Imports MySql.Data.MySqlClient
Public Class Brukere

    Dim db As New DBConnect
    Dim dataset As New DataTable
    Dim sda As New MySqlDataAdapter
    Dim bsource As New BindingSource
    Dim brukere As String

    Public Sub load_table()
        DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        dataset.Clear()
        Try
            Dim query As String
            query = "Select * from BRUKERE"
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


    Private Sub Brukere_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Text = "Brukere"
        db.DBConnect()
        load_table()




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        leggtilbruker.Show()
        AddHandler leggtilbruker.FormClosed, AddressOf load_table
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Close()
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        con.Dispose()


        Dim bruker As String

        bruker = InputBox("Hvilken bruker vil du slette?" & vbCrLf & "Bruk bruker_id", "Slett bruker")

        If bruker = "" Then
        ElseIf IsNumeric(bruker) = False Then
            MsgBox("Du må skrive tall", MsgBoxStyle.Critical, "Error")
        Else
            Try
                con.Open()
                Dim sqlslettebruker = New MySqlCommand("DELETE FROM `BRUKERE` WHERE `bruker_id` = '" & bruker & "'", con)


                sqlslettebruker.ExecuteNonQuery()
                con.Close()
            Catch ex As MySqlException
                MsgBox("Fant ikke bruker", MsgBoxStyle.Critical, "Error")
            End Try

        End If


        load_table()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        AddHandler endrebruker.FormClosed, AddressOf load_table
        '  kurs = InputBox("Hvilken kurs_id vil du endre?")
        endrebruker.Show()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        dataset.Clear()
        load_table()
    End Sub




End Class