Public Class Meny

    Public typer As String

    Private Sub Meny_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Meny"
        Me.typer = frmLogin.type
        FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False


        If typer = "selger" Then
            Button10.Visible = False
            Button5.Visible = False
            PictureBox2.Visible = True
            Label2.Visible = True
            Button12.Visible = False
            Me.Size = New System.Drawing.Size(583, 409)
        ElseIf typer = "lager"
            Button10.Visible = False
            Button5.Visible = False
            Button7.Visible = False
            Button2.Visible = False

            Button4.Visible = False
            Label3.Visible = True
            PictureBox3.Visible = True
            Me.Size = New System.Drawing.Size(422, 409)
        Else
            Label1.Visible = True
            Button12.Visible = False
            Button11.Visible = False
            PictureBox1.Visible = True
            Me.Size = New System.Drawing.Size(753, 409)
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmLogin.Show()
        Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Vareregistrering.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        salg.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        leggtilkunde.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ansatte.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        kurs.Show()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Søk.Show()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Brukere.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        utleie.Show()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        frmLogin.Show()
        Close()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        frmLogin.Show()
        Close()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        lager.Show()
    End Sub

End Class