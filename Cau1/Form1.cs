using Microsoft.EntityFrameworkCore;
using TriThucBooks.Models;

namespace TriThucBooks;

public partial class Form1 : Form
{
    private TriThucBooksContext _context = null!;

    public Form1()
    {
        InitializeComponent();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        _context = new TriThucBooksContext();
        await LoadDataAsync();
    }

    /// <summary>
    /// Tải toàn bộ danh sách thể loại sách lên DataGridView
    /// </summary>
    private async Task LoadDataAsync()
    {
        try
        {
            var danhSach = await _context.TheLoaiSaches
                .AsNoTracking()
                .OrderBy(t => t.MaTl)
                .ToListAsync();

            dgvTheLoai.DataSource = danhSach;

            if (danhSach.Count > 0)
            {
                if (dgvTheLoai.CurrentRow == null || dgvTheLoai.CurrentRow.Index < 0)
                {
                    dgvTheLoai.Rows[0].Selected = true;
                }
                HienThiDongDangChon();
            }
            else
            {
                XoaTrangControls();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL:\n" + ex.Message, 
                            "Lỗi kết nối CSDL", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Đổ dữ liệu dòng đang chọn lên các control tương ứng
    /// </summary>
    private void HienThiDongDangChon()
    {
        if (dgvTheLoai.CurrentRow != null && dgvTheLoai.CurrentRow.DataBoundItem is TheLoaiSach item)
        {
            txtMaTL.Text = item.MaTl.ToString();
            txtTenTL.Text = item.TenTheLoai;
            txtMoTa.Text = item.MoTa ?? string.Empty;
            lblNgayTao.Text = item.NgayTao.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }

    /// <summary>
    /// Xóa trắng các ô nhập liệu về trạng thái ban đầu
    /// </summary>
    private void XoaTrangControls()
    {
        txtMaTL.Text = "ReadOnly";
        txtTenTL.Clear();
        txtMoTa.Clear();
        lblNgayTao.Text = "Chưa chọn";
    }

    /// <summary>
    /// Sự kiện SelectionChanged của DataGridView
    /// </summary>
    private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
    {
        HienThiDongDangChon();
    }

    private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            HienThiDongDangChon();
        }
    }

    /// <summary>
    /// Chức năng Thêm mới thể loại sách
    /// </summary>
    private async void btnThem_Click(object sender, EventArgs e)
    {
        string tenTL = txtTenTL.Text.Trim();

        // 1. Kiểm tra không được bỏ trống Tên thể loại
        if (string.IsNullOrWhiteSpace(tenTL))
        {
            MessageBox.Show("Vui lòng nhập Tên thể loại!", 
                            "Thiếu dữ liệu", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
            txtTenTL.Focus();
            return;
        }

        // 2. Kiểm tra không cho phép trùng tên thể loại khi thêm mới
        bool daTonTai = await _context.TheLoaiSaches
            .AnyAsync(t => t.TenTheLoai.ToLower() == tenTL.ToLower());

        if (daTonTai)
        {
            MessageBox.Show($"Thể loại '{tenTL}' đã tồn tại trong danh mục! Vui lòng chọn tên khác.", 
                            "Trùng tên thể loại", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
            txtTenTL.Focus();
            return;
        }

        try
        {
            var theLoaiMoi = new TheLoaiSach
            {
                TenTheLoai = tenTL,
                MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim(),
                SoLuongSach = 0,
                NgayTao = DateTime.Now
            };

            // Dùng context.Add() và SaveChangesAsync()
            _context.TheLoaiSaches.Add(theLoaiMoi);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm thể loại sách mới thành công!", 
                            "Thông báo thành công", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);

            // Cập nhật lại DataGridView ngay sau khi lưu thành công
            await LoadDataAsync();
            ChonDongTheoMa(theLoaiMoi.MaTl);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show("Lỗi khi thêm thể loại: " + ex.Message, 
                            "Lỗi hệ thống", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Cập nhật (Sửa) thể loại sách
    /// </summary>
    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaTL.Text, out int maTL) || txtMaTL.Text == "ReadOnly")
        {
            MessageBox.Show("Vui lòng chọn một thể loại từ danh sách để sửa!", 
                            "Chưa chọn dữ liệu", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
            return;
        }

        string tenTL = txtTenTL.Text.Trim();

        // 1. Kiểm tra không được bỏ trống Tên thể loại
        if (string.IsNullOrWhiteSpace(tenTL))
        {
            MessageBox.Show("Tên thể loại không được để trống!", 
                            "Thiếu dữ liệu", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
            txtTenTL.Focus();
            return;
        }

        // 2. Kiểm tra không cho phép trùng tên với thể loại khác
        bool biTrungTen = await _context.TheLoaiSaches
            .AnyAsync(t => t.MaTl != maTL && t.TenTheLoai.ToLower() == tenTL.ToLower());

        if (biTrungTen)
        {
            MessageBox.Show($"Tên thể loại '{tenTL}' đã bị trùng với một thể loại khác!", 
                            "Trùng tên thể loại", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
            txtTenTL.Focus();
            return;
        }

        try
        {
            var theLoai = await _context.TheLoaiSaches.FindAsync(maTL);
            if (theLoai == null)
            {
                MessageBox.Show("Không tìm thấy thể loại cần cập nhật trong CSDL!", 
                                "Thông báo", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
                return;
            }

            theLoai.TenTheLoai = tenTL;
            theLoai.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();

            // Lưu thay đổi
            await _context.SaveChangesAsync();

            MessageBox.Show("Cập nhật thông tin thể loại thành công!", 
                            "Thông báo thành công", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);

            // Cập nhật lại DataGridView ngay sau khi lưu thành công
            await LoadDataAsync();
            ChonDongTheoMa(maTL);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show("Lỗi khi cập nhật thể loại: " + ex.Message, 
                            "Lỗi hệ thống", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Xóa thể loại sách với hộp thoại xác nhận và bắt lỗi DbUpdateException
    /// </summary>
    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaTL.Text, out int maTL) || txtMaTL.Text == "ReadOnly")
        {
            MessageBox.Show("Vui lòng chọn một thể loại từ danh sách để xóa!", 
                            "Chưa chọn dữ liệu", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
            return;
        }

        // Hộp thoại xác nhận (MessageBox YesNo)
        var confirmResult = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa thể loại \"{txtTenTL.Text}\" (Mã TL: {maTL}) không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirmResult != DialogResult.Yes)
        {
            return;
        }

        try
        {
            var theLoai = await _context.TheLoaiSaches.FindAsync(maTL);
            if (theLoai == null)
            {
                MessageBox.Show("Thể loại không tồn tại hoặc đã bị xóa trước đó!", 
                                "Thông báo", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
                await LoadDataAsync();
                return;
            }

            _context.TheLoaiSaches.Remove(theLoai);
            await _context.SaveChangesAsync();

            MessageBox.Show("Xóa thể loại sách thành công!", 
                            "Thông báo thành công", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);

            XoaTrangControls();
            await LoadDataAsync();
        }
        catch (DbUpdateException)
        {
            // Bắt lỗi DbUpdateException để thông báo khi thể loại đang được sách khác tham chiếu
            _context.ChangeTracker.Clear();
            MessageBox.Show(
                "Không thể xóa thể loại này vì đang được sách khác tham chiếu hoặc vi phạm ràng buộc dữ liệu!",
                "Lỗi ràng buộc dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show("Lỗi khi xóa thể loại: " + ex.Message, 
                            "Lỗi hệ thống", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Làm mới Form và nạp lại toàn bộ dữ liệu
    /// </summary>
    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        XoaTrangControls();
        txtTimKiem.Clear();
        await LoadDataAsync();
        txtTenTL.Focus();
    }

    /// <summary>
    /// Chức năng Tìm kiếm theo Tên thể loại dùng LINQ (Where + Contains)
    /// </summary>
    private async void btnTimKiem_Click(object sender, EventArgs e)
    {
        string tuKhoa = txtTimKiem.Text.Trim();

        if (string.IsNullOrWhiteSpace(tuKhoa))
        {
            await LoadDataAsync();
            return;
        }

        try
        {
            // Tìm kiếm theo Tên thể loại dùng LINQ (Where + Contains)
            var ketQua = await _context.TheLoaiSaches
                .AsNoTracking()
                .Where(tl => tl.TenTheLoai.Contains(tuKhoa))
                .OrderBy(tl => tl.MaTl)
                .ToListAsync();

            // Hiển thị trực tiếp trên DataGridView mà không tải lại toàn bộ Form
            dgvTheLoai.DataSource = ketQua;

            if (ketQua.Count == 0)
            {
                XoaTrangControls();
                MessageBox.Show($"Không tìm thấy thể loại nào phù hợp với từ khóa \"{tuKhoa}\"!", 
                                "Kết quả tìm kiếm", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
            else
            {
                HienThiDongDangChon();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, 
                            "Lỗi hệ thống", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
        }
    }

    private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnTimKiem.PerformClick();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }

    /// <summary>
    /// Chọn dòng trên DataGridView theo Mã thể loại
    /// </summary>
    private void ChonDongTheoMa(int maTL)
    {
        foreach (DataGridViewRow row in dgvTheLoai.Rows)
        {
            if (row.DataBoundItem is TheLoaiSach item && item.MaTl == maTL)
            {
                row.Selected = true;
                if (dgvTheLoai.Columns.Count > 0)
                {
                    dgvTheLoai.CurrentCell = row.Cells[0];
                }
                HienThiDongDangChon();
                break;
            }
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _context?.Dispose();
        base.OnFormClosing(e);
    }
}
