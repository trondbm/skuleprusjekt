Imports MySql.Data.MySqlClient
Public Class kurs

    Dim db As New DBConnect
    Dim dataset As New DataTable
    Dim sda As New MySqlDataAdapter
    Dim bsource As New BindingSource
    Dim kurs As String

    Public Sub load_table()
        DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        dataset.Clear()
        Try
            Dim query As String
            query = "Select * from KURS"
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
        Me.Text = "Kurs"
        db.DBConnect()
        load_table()




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        leggtilkurs.show()
        AddHandler leggtilkurs.FormClosed, AddressOf load_table
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Meny.Show()
        Close()
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click




        kurs = InputBox("Hvilken kurs_id vil du slette?")

        If IsNumeric(kurs) = False Then
            MsgBox("Du må skrive et tall!", MsgBoxStyle.Critical, "Error")
        ElseIf kurs

            Try
                Dim sqlkurs = New MySqlCommand("DELETE FROM KURS WHERE kurs_id = " & kurs, con)
                sqlkurs.Parameters.AddWithValue("@kurs", kurs)


                sqlkurs.ExecuteNonQuery()

            Catch ex As mysqlException

            End Try

            load_table()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        AddHandler endrekurs.FormClosed, AddressOf load_table
        '  kurs = InputBox("Hvilken kurs_id vil du endre?")
        endrekurs.Show()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        dataset.Clear()
        load_table()
    End Sub




End Class