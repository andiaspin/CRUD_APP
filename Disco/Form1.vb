Imports System.Data.Odbc
Public Class Form1
    Public foto As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        kosong()
        grid()
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub
    Sub grid()
        Call koneksinya()
        da = New OdbcDataAdapter("select kode as KODE, nama as NAMA, alamat as ALAMAT ,hp as TELEPON, foto as FOTO from pengguna", conn)
        ds = New DataSet()
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("KODE").Width = 100
        DataGridView1.Columns("NAMA").Width = 250
        DataGridView1.Columns("ALAMAT").Width = 250
        DataGridView1.Columns("TELEPON").Width = 100
        DataGridView1.Columns("FOTO").Width = 200
    End Sub
    Sub kosong()
        Button1.Enabled = True
        PictureBox2.Image = Nothing
        Button2.Enabled = False
        Button3.Enabled = False
        TextBox5.Enabled = True
        TextBox5.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call koneksinya()
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Or PictureBox2.Image Is Nothing Then
            MessageBox.Show("Mohon Lengkapi Semua Isian", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                cmd = New OdbcCommand("insert into pengguna (kode,nama,alamat,hp,foto) Values ('" & TextBox5.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & foto.Replace("\", "\\").ToString & "')", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Pengguna Berhasil Ditambahkan", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information)
                kosong()
                grid()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call koneksinya()
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Or PictureBox2.Image Is Nothing Then
            MessageBox.Show("Data Belum Lengkap", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                cmd = New OdbcCommand("update pengguna set nama = '" & TextBox1.Text & "', alamat = '" & TextBox2.Text & "', foto = '" & foto.Replace("\", "\\").ToString & "', hp = '" & TextBox3.Text & "' where kode = '" & TextBox5.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Pengguna Berhasil Diubah", "Karaoke Cafe Mr. Z", MessageBoxButtons.OK, MessageBoxIcon.Information)
                kosong()
                grid()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call koneksinya()
        If TextBox5.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                cmd = New OdbcCommand("delete from pengguna where kode = '" & TextBox5.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Pengguna Berhasil Dihapus", "Karaoke Cafe Mr. Z", MessageBoxButtons.OK, MessageBoxIcon.Information)
                kosong()
                grid()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.InitialDirectory = Application.StartupPath & "\member\"
        OpenFileDialog1.Filter = "Images File |*.jpg; *.png *.bmp;"
        OpenFileDialog1.ShowDialog()
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage

        If OpenFileDialog1.FileName = "" Then
            Exit Sub
        Else
            foto = OpenFileDialog1.FileName.ToString
            PictureBox2.Image = Image.FromFile(foto)
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Call koneksinya()
        da = New OdbcDataAdapter("select kode as KODE, nama as NAMA, alamat as ALAMAT, hp as TELEPON, foto as FOTO from pengguna where NAMA like '%" & TextBox4.Text & "%'", conn)
        ds = New DataSet()
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("KODE").Width = 100
        DataGridView1.Columns("NAMA").Width = 250
        DataGridView1.Columns("ALAMAT").Width = 250
        DataGridView1.Columns("TELEPON").Width = 100
        DataGridView1.Columns("FOTO").Width = 200
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        On Error Resume Next
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Me.TextBox5.Text = row.Cells(0).Value.ToString()
        Me.TextBox5.Enabled = False
        Me.TextBox1.Text = row.Cells(1).Value.ToString()
        Me.TextBox2.Text = row.Cells(2).Value.ToString()
        Me.TextBox3.Text = row.Cells(3).Value.ToString()
        Me.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        foto = row.Cells(4).Value.ToString()
        Me.PictureBox2.Image = Image.FromFile(foto)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        grid()
        kosong()

    End Sub
End Class
