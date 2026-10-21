using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmQuanLyTau : Form
    {
        private bool _dangNap;

        public FrmQuanLyTau()
        {
            InitializeComponent();
        }

        private void FrmQuanLyTau_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.DuocKyThuat))
                return;
            try
            {
                _dangNap = true;
                DataTable tuyen = KetNoi_DuLieu.LayBang("sp_Tuyen_Select");
                KetNoi_DuLieu.GanCombo(cboLocTuyen, KetNoi_DuLieu.ThemDongTrong(tuyen, "MaTuyen", "TenTuyen", "Tất cả tuyến"), "MaTuyen", "TenTuyen");
                KetNoi_DuLieu.GanCombo(cboTuyen, KetNoi_DuLieu.ThemDongTrong(tuyen.Copy(), "MaTuyen", "TenTuyen", "(Chưa gán)"), "MaTuyen", "TenTuyen");
                KetNoi_DuLieu.GanCombo(cboLocTrangThai, KetNoi_DuLieu.BangChon("", "Tất cả", "SanSang", "Sẵn sàng", "DangChay", "Đang chạy", "BaoTri", "Bảo trì", "Hong", "Hỏng"), "Ma", "Ten");
                KetNoi_DuLieu.GanCombo(cboTrangThai, KetNoi_DuLieu.BangChon("SanSang", "Sẵn sàng", "DangChay", "Đang chạy", "BaoTri", "Bảo trì", "Hong", "Hỏng"), "Ma", "Ten");
                KetNoi_DuLieu.GanCombo(cboLoai, KetNoi_DuLieu.BangChon("Metro", "Metro", "TauHoa", "Tàu hỏa"), "Ma", "Ten");
                _dangNap = false;
                TaiLai();
            }
            catch (Exception ex)
            {
                _dangNap = false;
                HopThoai.Loi(ex);
            }
        }

        private void TaiLai()
        {
            try
            {
                KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang(
                    "sp_Tau_Select",
                    KetNoi_DuLieu.ThamSo("@MaTuyen", KetNoi_DuLieu.GiaTriCombo(cboLocTuyen)),
                    KetNoi_DuLieu.ThamSo("@TrangThai", KetNoi_DuLieu.GiaTriChuoi(cboLocTrangThai)),
                    KetNoi_DuLieu.ThamSo("@MaTau", 0)));
                KetNoi_DuLieu.DatTieuDe(dgv,
                    "MaTau", "Mã tàu",
                    "TenTau", "Tên tàu",
                    "TenLoai", "Loại",
                    "SucChua", "Sức chứa",
                    "TenTuyen", "Tuyến",
                    "TenTrangThai", "Trạng thái",
                    "SoToa", "Số toa");
                KetNoi_DuLieu.AnCot(dgv, "LoaiTau", "MaTuyen", "TrangThai");
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
            txtTenTau.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "TenTau");
            KetNoi_DuLieu.ChonComboChuoi(cboLoai, KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "LoaiTau"));
            int suc = KetNoi_DuLieu.So(dgv.CurrentRow, "SucChua");
            if (suc < 1) suc = 1;
            if (suc > numSucChua.Maximum) suc = Convert.ToInt32(numSucChua.Maximum);
            numSucChua.Value = suc;
            KetNoi_DuLieu.ChonCombo(cboTuyen, KetNoi_DuLieu.So(dgv.CurrentRow, "MaTuyen"));
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

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dangNap)
                TaiLai();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (HopThoai.Thieu(txtTenTau.Text, "tên tàu"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_Tau_Them",
                    KetNoi_DuLieu.ThamSo("@TenTau", txtTenTau.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@LoaiTau", KetNoi_DuLieu.GiaTriChuoi(cboLoai)),
                    KetNoi_DuLieu.ThamSo("@SucChua", Convert.ToInt32(numSucChua.Value)),
                    KetNoi_DuLieu.ThamSo("@MaTuyen", KetNoi_DuLieu.GiaTriCombo(cboTuyen)),
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
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaTau");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một tàu.");
                return;
            }
            if (HopThoai.Thieu(txtTenTau.Text, "tên tàu"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_Tau_Sua",
                    KetNoi_DuLieu.ThamSo("@MaTau", ma),
                    KetNoi_DuLieu.ThamSo("@TenTau", txtTenTau.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@LoaiTau", KetNoi_DuLieu.GiaTriChuoi(cboLoai)),
                    KetNoi_DuLieu.ThamSo("@SucChua", Convert.ToInt32(numSucChua.Value)),
                    KetNoi_DuLieu.ThamSo("@MaTuyen", KetNoi_DuLieu.GiaTriCombo(cboTuyen)),
                    KetNoi_DuLieu.ThamSo("@TrangThai", KetNoi_DuLieu.GiaTriChuoi(cboTrangThai)));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaTau");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một tàu.");
                return;
            }
            using (FrmChiTietTau chiTiet = new FrmChiTietTau(ma))
                chiTiet.ShowDialog(this);
            TaiLai();
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
