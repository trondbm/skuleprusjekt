Imports MySql.Data.MySqlClient
Public Class Søk

    Dim db As New DBConnect

    Dim dataset As New DataTable
    Dim sda As New MySqlDataAdapter
    Dim bsource As New BindingSource
    Dim tabell As String

    Private Sub ResetDataGridView()
        DataGridView1.DataSource = dataset
        dataset.Columns.Clear()

        DataGridView1.DataSource = Nothing
        dataset.Clear()

    End Sub


    Private Sub Søk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        db.DBConnect()

        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("ANSATT", "Ansatte")
        comboSource.Add("BESTILLING", "Bestillinger")
        comboSource.Add("INSTRUKTØR", "Instruktører")
        comboSource.Add("KUNDE", "Kunder")
        comboSource.Add("KURS", "Kurs")
        comboSource.Add("SAMARBEIDSPARTNER", "Partnere")
        comboSource.Add("UTLEIE", "Utleie")
        comboSource.Add("VARE", "Varer")
        ComboBox1.DataSource = New BindingSource(comboSource, Nothing)
        ComboBox1.DisplayMember = "Value"
        ComboBox1.ValueMember = "Key"

    End Sub




    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ResetDataGridView()




        Dim key As String = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim value As String = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Value

        Try

            Dim query As String
            query = "Select * from " & key
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


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Meny.Show()
        Close()
    End Sub


    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        Dim i As Integer

        For i = 0 To DataGridView1.Columns.Count - 1

            DataGridView1.Columns.Remove(DataGridView1.Columns(0))

        Next


    End Sub


End Class