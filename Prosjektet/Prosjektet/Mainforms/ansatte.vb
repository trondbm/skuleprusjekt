Imports MySql.Data.MySqlClient
Public Class ansatte

    Dim db As New DBConnect
    Dim dataset As New DataTable
    Dim sda As New MySqlDataAdapter
    Dim bsource As New BindingSource

    Public Sub ansatt_table()
        DataGridView1.DataSource = dataset
        DataGridView1.DataSource = Nothing
        dataset.Clear()
        Try
            Dim query As String
            query = "Select * from ANSATT"
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
    Private Sub ansatte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Ansatte"
        ansatt_table()
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        db.DBConnect()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        leggtilansatt.Show()

        AddHandler leggtilansatt.FormClosed, AddressOf ansatt_table


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Meny.Show()
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        endreansatt.Show()

        AddHandler endreansatt.FormClosed, AddressOf ansatt_table
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        con.Dispose()
        Dim ansatt As String

        ansatt = InputBox("Hvilken ansatt vil du slette?" & vbCrLf & "Bruk ansatt_id", "Slett ansatt")

        If ansatt = "" Then
        ElseIf IsNumeric(ansatt) = False Then
            MsgBox("Du må skrive tall", MsgBoxStyle.Critical, "Error")
        Else
            Try
                con.Open()

                Dim sqlslettebruker = New MySqlCommand("DELETE FROM `ANSATT` WHERE `ansatt_id` = '" & ansatt & "'", con)


                sqlslettebruker.ExecuteNonQuery()
                con.Close()
            Catch ex As MySqlException
                MsgBox("Fant ikke ansatt", MsgBoxStyle.Critical, "Error")
            End Try

        End If



        ansatt_table()

    End Sub
End Class