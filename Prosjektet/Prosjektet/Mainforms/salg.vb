Imports MySql.Data.MySqlClient
Public Class salg

    Dim db As New DBConnect
    Dim dataset As New DataTable
    Dim sda As New MySqlDataAdapter
    Dim bsource As New BindingSource

    Public Sub salg_table()
        DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        dataset.Clear()
        Try
            Dim query As String
            query = "Select * from SALG"
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
    Private Sub salg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Salg"
        salg_table()
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        db.DBConnect()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        leggtilkunde.Show()



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Meny.Show()
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        leggtilsalg.Show()

        AddHandler leggtilsalg.FormClosed, AddressOf salg_table
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        endresalg.Show()

        AddHandler endresalg.FormClosed, AddressOf salg_table
    End Sub
End Class