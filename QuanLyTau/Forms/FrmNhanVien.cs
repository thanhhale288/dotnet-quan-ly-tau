using System;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.LaQuanLy))
                return;
            KetNoi_DuLieu.GanCombo(
                cboChucVu,
                KetNoi_DuLieu.BangChon("QuanLy", "Quản lý", "BanVe", "Bán vé", "KyThuat", "Kỹ thuật", "LaiTau", "Lái tàu"),
                "Ma",
                "Ten");
            KetNoi_DuLieu.GanCombo(
                cboTrangThai,
                KetNoi_DuLieu.BangChon("DangLam", "Đang làm", "NghiViec", "Nghỉ việc"),
                "Ma",
                "Ten");
            TaiLai();
        }

        private void TaiLai()
        {
            try
            {
                KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang("sp_NhanVien_Select"));
                KetNoi_DuLieu.DatTieuDe(dgv,
                    "MaNV", "Mã",
                    "HoTen", "Họ tên",
                    "TenChucVu", "Chức vụ",
                    "TenDangNhap", "Tên đăng nhập",
                    "DienThoai", "Điện thoại",
                    "TenTrangThai", "Trạng thái");
                KetNoi_DuLieu.AnCot(dgv, "ChucVu", "TrangThai");
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void NapDong()
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.IsNewRow)
                return;
            txtHoTen.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "HoTen");
            txtTenDangNhap.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "TenDangNhap");
            txtDienThoai.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "DienThoai");
            txtMatKhau.Clear();
            KetNoi_DuLieu.ChonComboChuoi(cboChucVu, KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "ChucVu"));
            KetNoi_DuLieu.ChonComboChuoi(cboTrangThai, KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "TrangThai"));
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                NapDong();
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            NapDong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (HopThoai.Thieu(txtHoTen.Text, "họ tên") || HopThoai.Thieu(txtTenDangNhap.Text, "tên đăng nhập") || HopThoai.Thieu(txtMatKhau.Text, "mật khẩu"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_NhanVien_Them",
                    KetNoi_DuLieu.ThamSo("@HoTen", txtHoTen.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@ChucVu", KetNoi_DuLieu.GiaTriChuoi(cboChucVu)),
                    KetNoi_DuLieu.ThamSo("@TenDangNhap", txtTenDangNhap.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@MatKhau", KetNoi_DuLieu.BamMatKhau(txtMatKhau.Text)),
                    KetNoi_DuLieu.ThamSo("@DienThoai", KetNoi_DuLieu.ChuoiHoacNull(txtDienThoai.Text)));
                txtMatKhau.Clear();
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaNV");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một nhân viên.");
                return;
            }
            if (HopThoai.Thieu(txtHoTen.Text, "họ tên"))
                return;
            string trangThai = KetNoi_DuLieu.GiaTriChuoi(cboTrangThai);
            if (ma == PhienLamViec.MaNV && trangThai == "NghiViec")
            {
                HopThoai.Bao("Không tự chuyển tài khoản đang đăng nhập sang nghỉ việc.");
                return;
            }
            object matKhau = txtMatKhau.Text.Length == 0
                ? (object)DBNull.Value
                : KetNoi_DuLieu.BamMatKhau(txtMatKhau.Text);
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_NhanVien_Sua",
                    KetNoi_DuLieu.ThamSo("@MaNV", ma),
                    KetNoi_DuLieu.ThamSo("@HoTen", txtHoTen.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@ChucVu", KetNoi_DuLieu.GiaTriChuoi(cboChucVu)),
                    KetNoi_DuLieu.ThamSo("@DienThoai", KetNoi_DuLieu.ChuoiHoacNull(txtDienThoai.Text)),
                    KetNoi_DuLieu.ThamSo("@TrangThai", trangThai),
                    KetNoi_DuLieu.ThamSo("@MatKhau", matKhau));
                txtMatKhau.Clear();
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
