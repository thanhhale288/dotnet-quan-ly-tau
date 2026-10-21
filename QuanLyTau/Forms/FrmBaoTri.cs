using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmBaoTri : Form
    {
        private readonly int _maTau;

        public FrmBaoTri()
            : this(0)
        {
        }

        public FrmBaoTri(int maTau)
        {
            _maTau = maTau;
            InitializeComponent();
        }

        private void FrmBaoTri_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.DuocKyThuat))
                return;
            try
            {
                DataTable tau = KetNoi_DuLieu.LayBang("sp_Tau_Select", KetNoi_DuLieu.ThamSo("@MaTuyen", 0), KetNoi_DuLieu.ThamSo("@TrangThai", ""), KetNoi_DuLieu.ThamSo("@MaTau", 0));
                KetNoi_DuLieu.GanCombo(cboTau, tau, "MaTau", "TenTau");
                if (_maTau > 0)
                {
                    KetNoi_DuLieu.ChonCombo(cboTau, _maTau);
                    cboTau.Enabled = false;
                }
                KetNoi_DuLieu.GanCombo(cboTrangThai, KetNoi_DuLieu.BangChon("DangLam", "Đang làm", "HoanThanh", "Hoàn thành"), "Ma", "Ten");
                dtpBatDau.Value = DateTime.Today;
                dtpKetThuc.Value = DateTime.Today;
                dtpKetThuc.Checked = false;
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
                int loc = _maTau > 0 ? _maTau : 0;
                KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang("sp_BaoTri_Select", KetNoi_DuLieu.ThamSo("@MaTau", loc)));
                KetNoi_DuLieu.DatTieuDe(dgv,
                    "MaBT", "Mã phiếu",
                    "TenTau", "Tàu",
                    "NgayBatDau", "Bắt đầu",
                    "NgayKetThuc", "Kết thúc",
                    "NoiDung", "Nội dung",
                    "ChiPhi", "Chi phí",
                    "TenNV", "Kỹ thuật",
                    "TenTrangThai", "Trạng thái");
                KetNoi_DuLieu.AnCot(dgv, "MaTau", "MaNV", "TrangThai");
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
            KetNoi_DuLieu.ChonCombo(cboTau, KetNoi_DuLieu.So(dgv.CurrentRow, "MaTau"));
            dtpBatDau.Value = KetNoi_DuLieu.Ngay(dgv.CurrentRow, "NgayBatDau", DateTime.Today);
            string ket = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "NgayKetThuc");
            if (ket.Length == 0)
            {
                dtpKetThuc.Checked = false;
            }
            else
            {
                dtpKetThuc.Checked = true;
                dtpKetThuc.Value = KetNoi_DuLieu.Ngay(dgv.CurrentRow, "NgayKetThuc", DateTime.Today);
            }
            txtNoiDung.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "NoiDung");
            decimal chiPhi = KetNoi_DuLieu.Tien(dgv.CurrentRow, "ChiPhi");
            if (chiPhi < 0) chiPhi = 0;
            if (chiPhi > numChiPhi.Maximum) chiPhi = numChiPhi.Maximum;
            numChiPhi.Value = chiPhi;
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

        private object NgayKetThuc()
        {
            if (!dtpKetThuc.Checked)
                return DBNull.Value;
            return dtpKetThuc.Value.Date;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (HopThoai.Thieu(txtNoiDung.Text, "nội dung"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_BaoTri_Them",
                    KetNoi_DuLieu.ThamSo("@MaTau", KetNoi_DuLieu.GiaTriCombo(cboTau)),
                    KetNoi_DuLieu.ThamSo("@NgayBatDau", dtpBatDau.Value.Date),
                    KetNoi_DuLieu.ThamSo("@NgayKetThuc", NgayKetThuc()),
                    KetNoi_DuLieu.ThamSo("@NoiDung", txtNoiDung.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@ChiPhi", numChiPhi.Value),
                    KetNoi_DuLieu.ThamSo("@MaNV", PhienLamViec.MaNV),
                    KetNoi_DuLieu.ThamSo("@TrangThai", KetNoi_DuLieu.GiaTriChuoi(cboTrangThai)));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Luu(KetNoi_DuLieu.GiaTriChuoi(cboTrangThai));
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            KetNoi_DuLieu.ChonComboChuoi(cboTrangThai, "HoanThanh");
            if (!dtpKetThuc.Checked)
            {
                dtpKetThuc.Checked = true;
                dtpKetThuc.Value = DateTime.Today;
            }
            Luu("HoanThanh");
        }

        private void Luu(string trangThai)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaBT");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một phiếu.");
                return;
            }
            if (HopThoai.Thieu(txtNoiDung.Text, "nội dung"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_BaoTri_Sua",
                    KetNoi_DuLieu.ThamSo("@MaBT", ma),
                    KetNoi_DuLieu.ThamSo("@MaTau", KetNoi_DuLieu.GiaTriCombo(cboTau)),
                    KetNoi_DuLieu.ThamSo("@NgayBatDau", dtpBatDau.Value.Date),
                    KetNoi_DuLieu.ThamSo("@NgayKetThuc", NgayKetThuc()),
                    KetNoi_DuLieu.ThamSo("@NoiDung", txtNoiDung.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@ChiPhi", numChiPhi.Value),
                    KetNoi_DuLieu.ThamSo("@MaNV", PhienLamViec.MaNV),
                    KetNoi_DuLieu.ThamSo("@TrangThai", trangThai));
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
