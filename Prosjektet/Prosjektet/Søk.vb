Imports MySql.Data.MySqlClient
Public Class Søk

    Dim db As New DBConnect

    Dim dataset As New DataTable
    Dim sda As New MySqlDataAdapter
    Dim bsource As New BindingSource
    Dim tabell As String


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

        'DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        'dataset.Clear()





        Dim key As String = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim value As String = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Value

        Try
            dataset.Clear()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click





    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Meny.Show()
        Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class