Imports MySql.Data.MySqlClient
Public Class utleie

    Dim db As New DBConnect
    Dim brukernavn As String
    Public type As String
    Dim cmd As New MySqlCommand

    Dim dataset As New DataTable
    Dim sda As New MySqlDataAdapter
    Dim bsource As New BindingSource

    Private Sub utleie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db.DBConnect()

        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
    End Sub

    Public Sub utleie_table()
        DataGridView1.DataSource = DataSet
        DataGridView1.DataSource = Nothing
        DataSet.Clear()
        Try
            Dim query As String
            query = "Select * from UTLEIE"
            Dim sqlsøk = New MySqlCommand(query, con)
            sda.SelectCommand = sqlsøk
            sda.Fill(DataSet)
            bsource.DataSource = DataSet
            DataGridView1.DataSource = bsource
            sda.Update(DataSet)

        Catch ex As MySqlException
            MsgBox("Error")
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
            Meny.Show()
            Close()
        End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        leggtilutleie.Show()

        AddHandler leggtilutleie.FormClosed, AddressOf utleie_table
    End Sub

        Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        endreutleie.Show()

        AddHandler endreutleie.FormClosed, AddressOf utleie_table
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        leggtilkunde.Show()
    End Sub
End Class