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

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs)
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaDosen" Then
                f.BringToFront
                Exit Sub
            End If

        Next

        Dim formDosen As New FormKelolaDosen
        formDosen.Show
        Hide
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs)
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaMahasiswa" Then
                f.BringToFront
                Exit Sub
            End If
        Next

        Dim formMahasiswa As New FormKelolaMahasiswa
        formMahasiswa.Show
        Hide
    End Sub

    Private Sub KelolaAkun_Click(sender As Object, e As EventArgs) Handles KelolaAkun.Click
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaAkun" Then
                f.BringToFront()
                Exit Sub
            End If

        Next

        Call New FormKelolaAkun().Show()
        Me.Hide()
        Dim formAkun As New FormKelolaAkun()
        formAkun.ShowDialog() ' Gunakan ShowDialog agar kode selanjutnya menunggu FormAkun tertutup

        ' Setelah FormKelolaAkun tertutup, tampilkan kembali DashboardAdmin
        Me.Show()
    End Sub

    Private Sub KelolaJadwal_Click(sender As Object, e As EventArgs) Handles KelolaJadwal.Click
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaJadwal" Then
                f.BringToFront()
                Exit Sub
            End If

        Next

        Call New FormKelolaJadwal().Show()
        Me.Hide()
        Dim formJadwal As New FormKelolaJadwal()
        formJadwal.ShowDialog() ' Gunakan ShowDialog agar kode selanjutnya menunggu FormJadwal tertutup

        ' Setelah FormKelolaJadwal tertutup, tampilkan kembali DashboardAdmin
        Me.Show()
    End Sub

    Private Sub KelolaRuangan_Click(sender As Object, e As EventArgs) Handles KelolaRuangan.Click
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaRuangan" Then
                f.BringToFront()
                Exit Sub
            End If

        Next

        Call New FormKelolaRuangan().Show()
        Me.Hide()
        Dim formRuangan As New FormKelolaRuangan()
        formRuangan.ShowDialog() ' Gunakan ShowDialog agar kode selanjutnya menunggu FormRuangan tertutup

        ' Setelah FormKelolaRuangan tertutup, tampilkan kembali DashboardAdmin
        Me.Show()
    End Sub
End Class