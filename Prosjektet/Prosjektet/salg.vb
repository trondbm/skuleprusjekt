﻿Imports MySql.Data.MySqlClient
Public Class salg

    Dim db As New DBConnect
    Private Sub salg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Salg"

        db.DBConnect()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




    End Sub
End Class