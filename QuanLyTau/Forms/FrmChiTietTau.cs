using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmChiTietTau : Form
    {
        private readonly int _maTau;

        public FrmChiTietTau()
            : this(0)
        {
        }

        public FrmChiTietTau(int maTau)
        {
            _maTau = maTau;
            InitializeComponent();
        }

        private void FrmChiTietTau_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.DuocKyThuat))
                return;
            if (_maTau <= 0)
            {
                HopThoai.Bao("Chọn một tàu trước.");
                BeginInvoke(new Action(Close));
                return;
            }

            try
            {
                DataTable tuyen = KetNoi_DuLieu.LayBang("sp_Tuyen_Select");
                KetNoi_DuLieu.GanCombo(cboTuyen, KetNoi_DuLieu.ThemDongTrong(tuyen, "MaTuyen", "TenTuyen", "(Chưa gán)"), "MaTuyen", "TenTuyen");
                KetNoi_DuLieu.GanCombo(cboLoai, KetNoi_DuLieu.BangChon("Metro", "Metro", "TauHoa", "Tàu hỏa"), "Ma", "Ten");
                KetNoi_DuLieu.GanCombo(cboTrangThai, KetNoi_DuLieu.BangChon("SanSang", "Sẵn sàng", "DangChay", "Đang chạy", "BaoTri", "Bảo trì", "Hong", "Hỏng"), "Ma", "Ten");
                TaiTau();
                TaiToa();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void TaiTau()
        {
            DataTable tau = KetNoi_DuLieu.LayBang(
                "sp_Tau_Select",
                KetNoi_DuLieu.ThamSo("@MaTuyen", 0),
                KetNoi_DuLieu.ThamSo("@TrangThai", ""),
                KetNoi_DuLieu.ThamSo("@MaTau", _maTau));
            if (tau.Rows.Count == 0)
            {
                HopThoai.Bao("Không tìm thấy tàu.");
                BeginInvoke(new Action(Close));
                return;
            }
            DataRow dong = tau.Rows[0];
            txtTenTau.Text = dong["TenTau"].ToString();
            lblTieuDe.Text = "  " + dong["TenTau"];
            Text = dong["TenTau"].ToString();
            KetNoi_DuLieu.ChonComboChuoi(cboLoai, dong["LoaiTau"].ToString());
            KetNoi_DuLieu.ChonComboChuoi(cboTrangThai, dong["TrangThai"].ToString());
            int maTuyen = dong["MaTuyen"] == DBNull.Value ? 0 : Convert.ToInt32(dong["MaTuyen"]);
            KetNoi_DuLieu.ChonCombo(cboTuyen, maTuyen);
            int suc = Convert.ToInt32(dong["SucChua"]);
            if (suc < 1) suc = 1;
            numSucChua.Value = suc;
        }

        private void TaiToa()
        {
            KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang("sp_ToaTau_Select", KetNoi_DuLieu.ThamSo("@MaTau", _maTau)));
            KetNoi_DuLieu.DatTieuDe(dgv,
                "MaToa", "Mã toa",
                "SoThuTu", "Số thứ tự",
                "LoaiToa", "Loại toa",
                "SucChua", "Sức chứa");
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv.CurrentRow == null)
                return;
            numSoThuTu.Value = Math.Max(1, KetNoi_DuLieu.So(dgv.CurrentRow, "SoThuTu"));
            txtLoaiToa.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "LoaiToa");
            int suc = KetNoi_DuLieu.So(dgv.CurrentRow, "SucChua");
            if (suc < 1) suc = 1;
            numSucToa.Value = suc;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (HopThoai.Thieu(txtTenTau.Text, "tên tàu"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_Tau_Sua",
                    KetNoi_DuLieu.ThamSo("@MaTau", _maTau),
                    KetNoi_DuLieu.ThamSo("@TenTau", txtTenTau.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@LoaiTau", KetNoi_DuLieu.GiaTriChuoi(cboLoai)),
                    KetNoi_DuLieu.ThamSo("@SucChua", Convert.ToInt32(numSucChua.Value)),
                    KetNoi_DuLieu.ThamSo("@MaTuyen", KetNoi_DuLieu.GiaTriCombo(cboTuyen)),
                    KetNoi_DuLieu.ThamSo("@TrangThai", KetNoi_DuLieu.GiaTriChuoi(cboTrangThai)));
                TaiTau();
                HopThoai.Bao("Đã lưu tàu.");
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnThemToa_Click(object sender, EventArgs e)
        {
            if (HopThoai.Thieu(txtLoaiToa.Text, "loại toa"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_ToaTau_Them",
                    KetNoi_DuLieu.ThamSo("@MaTau", _maTau),
                    KetNoi_DuLieu.ThamSo("@SoThuTu", Convert.ToInt32(numSoThuTu.Value)),
                    KetNoi_DuLieu.ThamSo("@LoaiToa", txtLoaiToa.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@SucChua", Convert.ToInt32(numSucToa.Value)));
                TaiToa();
                TaiTau();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnXoaToa_Click(object sender, EventArgs e)
        {
            int maToa = KetNoi_DuLieu.So(dgv.CurrentRow, "MaToa");
            if (maToa == 0)
            {
                HopThoai.Bao("Chọn một toa.");
                return;
            }
            if (!HopThoai.Hoi("Xóa toa này?"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi("sp_ToaTau_Xoa", KetNoi_DuLieu.ThamSo("@MaToa", maToa));
                TaiToa();
                TaiTau();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnBaoTri_Click(object sender, EventArgs e)
        {
            using (FrmBaoTri baoTri = new FrmBaoTri(_maTau))
                baoTri.ShowDialog(this);
            try
            {
                TaiTau();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
