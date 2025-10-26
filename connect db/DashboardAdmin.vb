Public Class DashboardAdmin


    Private Sub KelolaDosen_Click(sender As Object, e As EventArgs) Handles KelolaDosen.Click
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaDosen" Then
                f.BringToFront()
                Exit Sub
            End If

        Next

        Call New FormKelolaDosen().Show()
        Me.Hide()
        Dim formDosen As New FormKelolaDosen()
        formDosen.ShowDialog() ' Gunakan ShowDialog agar kode selanjutnya menunggu FormDosen tertutup

        ' Setelah FormKelolaDosen tertutup, tampilkan kembali DashboardAdmin
        Me.Show()
    End Sub

    Private Sub KelolaMahasiswa_Click(sender As Object, e As EventArgs) Handles KelolaMahasiswa.Click
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaMahasiswa" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        Dim formMahasiswa As New FormKelolaMahasiswa()
        formMahasiswa.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaDosen" Then
                f.BringToFront()
                Exit Sub
            End If

        Next

        Dim formDosen As New FormKelolaDosen
        formDosen.Show()
        Hide()
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaMahasiswa" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        Dim formMahasiswa As New FormKelolaMahasiswa
        formMahasiswa.Show()
        Hide()
    End Sub
End Class