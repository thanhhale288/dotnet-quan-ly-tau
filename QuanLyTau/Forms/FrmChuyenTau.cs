using System;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmChuyenTau : Form
    {
        public FrmChuyenTau()
        {
            InitializeComponent();
        }

        private void FrmChuyenTau_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.DuocXemChuyen))
                return;
            btnBanVe.Visible = PhienLamViec.DuocBanVe;
            dtpNgay.Value = DateTime.Today;
            try
            {
                KetNoi_DuLieu.GanCombo(
                    cboLaiTau,
                    KetNoi_DuLieu.ThemDongTrong(KetNoi_DuLieu.LayBang("sp_NhanVien_LaiTau"), "MaNV", "HoTen", "(Chưa gán)"),
                    "MaNV",
                    "HoTen");
                KetNoi_DuLieu.GanCombo(
                    cboTrangThai,
                    KetNoi_DuLieu.BangChon("ChoChay", "Chờ chạy", "DangChay", "Đang chạy", "HoanThanh", "Hoàn thành", "Huy", "Hủy"),
                    "Ma",
                    "Ten");
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void TaiLai()
        {
            try
            {
                KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang("sp_Chuyen_Select", KetNoi_DuLieu.ThamSo("@Ngay", dtpNgay.Value.Date)));
                KetNoi_DuLieu.DatTieuDe(dgv,
                    "MaChuyen", "Mã chuyến",
                    "TenTuyen", "Tuyến",
                    "TenTau", "Tàu",
                    "GioDi", "Giờ đi",
                    "GioDen", "Giờ đến",
                    "LaiTau", "Lái tàu",
                    "TenTrangThai", "Trạng thái",
                    "SucChua", "Sức chứa",
                    "SoVe", "Số vé",
                    "SoChoTrong", "Còn chỗ");
                KetNoi_DuLieu.AnCot(dgv, "TrangThai", "MaLaiTau");
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
            KetNoi_DuLieu.ChonCombo(cboLaiTau, KetNoi_DuLieu.So(dgv.CurrentRow, "MaLaiTau"));
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaChuyen");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một chuyến.");
                return;
            }
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_Chuyen_CapNhat",
                    KetNoi_DuLieu.ThamSo("@MaChuyen", ma),
                    KetNoi_DuLieu.ThamSo("@MaLaiTau", KetNoi_DuLieu.GiaTriCombo(cboLaiTau)),
                    KetNoi_DuLieu.ThamSo("@TrangThai", KetNoi_DuLieu.GiaTriChuoi(cboTrangThai)));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaChuyen");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một chuyến.");
                return;
            }
            if (KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "TrangThai") != "ChoChay")
            {
                HopThoai.Bao("Chỉ bán vé cho chuyến đang chờ chạy.");
                return;
            }
            using (FrmBanVe ban = new FrmBanVe(ma))
                ban.ShowDialog(this);
            TaiLai();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
