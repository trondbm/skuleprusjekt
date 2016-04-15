Imports MySql.Data.MySqlClient
Public Class loadtable

    Dim db As New DBConnect
    Dim dataset As New DataTable
    Dim sda As New MySqlDataAdapter
    Dim bsource As New BindingSource
    Dim kurs As String

    Public Sub load_table()

        Try
            Dim query As String
            query = "Select * from KURS"
            Dim sqlsøk = New MySqlCommand(query, con)
            sda.SelectCommand = sqlsøk
            sda.Fill(dataset)
            bsource.DataSource = dataset
            '   DataGridView1.DataSource = bsource
            sda.Update(dataset)



        Catch ex As MySqlException
            MsgBox("Error")
        End Try
    End Sub
End Class



