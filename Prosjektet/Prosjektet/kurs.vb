Imports MySql.Data.MySqlClient
Public Class kurs

    Dim db As New DBConnect

    Private Sub kurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Kurs"
        db.DBConnect()

        '  Dim reader As MySqlDataReader

        '  Try
        '    Dim sqlkurs As String
        '    sqlkurs = "SELECT * FROM 'VARE'"
        '   Dim Command = New MySqlCommand(sqlkurs, con)
        '  reader = Command.executereader
        '   While reader.Read
        '          Dim vname = reader.GetString("varenavn")
        '    ListBox1.Items.Add(vname)
        '       End While



        '    Catch ex As Exception

        '    End Try


        Dim query As String = "SELECT varenavn FROM VARE"
        Dim sqlkurs As New MySqlCommand(query, con)



        'Create a command object with the SQL statement needed to select the first and last names
        Dim strSQL AsString = "SELECT FirstName, LastName FROM Employees"
      Dim objCommand AsNew OleDbCommand(strSQL, objConnection)
 
      'Create a data adapter and data table then fill the data table
      Dim objDataAdapter AsNew OleDbDataAdapter(objCommand)
      Dim objDataTable AsNew DataTable("Employees")
      objDataAdapter.Fill(objDataTable)

        'Create connection and release resources
        objConnection.Close()
        objConnection.Dispose()
        objConnection = Nothing
        objCommand.Dispose()
        objCommand = Nothing
        objDataAdapter.Dispose()
        objDataAdapter = Nothing

        'Fill names into the listbox
        ForEach row As DataRow In objDataTable.Rows
           lstNames.Items.Add(row.Item("FirstName") & " " & row.Item("LastName"))
        Next

        'Release resources
        objDataTable.Dispose()
        objDataTable = Nothing
        EndSub




    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        leggtilkurs.show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Meny.Show()
        Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class