Public Class DashboardAdmin

    'private sub untuk setiap tombol pada dashboard admin, yang ketika di klik akan membuka form terkait
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
        formDosen.ShowDialog() 'gunakan ShowDialog agar kode selanjutnya menunggu FormDosen tertutup

        'setelah FormKelolaDosen tertutup, tampilkan kembali DashboardAdmin
        Me.Show()
    End Sub

    Private Sub KelolaMahasiswa_Click(sender As Object, e As EventArgs) Handles KelolaMahasiswa.Click
        For Each f As Form In Application.OpenForms
            If f.Name = "FormKelolaMahasiswa" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        Call New FormKelolaMahasiswa().Show()
        Me.Hide()
        Dim formMahasiswa As New FormKelolaMahasiswa()
        formMahasiswa.ShowDialog()
        Me.Show()
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
        formAkun.ShowDialog()
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
        formJadwal.ShowDialog()
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
        formRuangan.ShowDialog()
        Me.Show()
    End Sub

    Private Sub DashboardAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class