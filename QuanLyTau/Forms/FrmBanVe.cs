using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmBanVe : Form
    {
        private readonly int _maChuyen;
        private bool _dangNap;

        public FrmBanVe()
            : this(0)
        {
        }

        public FrmBanVe(int maChuyen)
        {
            _maChuyen = maChuyen;
            InitializeComponent();
        }

        private void FrmBanVe_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.DuocBanVe))
                return;
            try
            {
                _dangNap = true;
                DataTable chuyen = KetNoi_DuLieu.LayBang("sp_Chuyen_ChoBan");
                KetNoi_DuLieu.GanCombo(cboChuyen, chuyen, "MaChuyen", "MoTa");
                KetNoi_DuLieu.GanCombo(cboLoaiVe, KetNoi_DuLieu.BangChon("Thuong", "Thường", "UuTien", "Ưu tiên"), "Ma", "Ten");
                if (_maChuyen > 0)
                    KetNoi_DuLieu.ChonCombo(cboChuyen, _maChuyen);
                _dangNap = false;
                NapGa();
            }
            catch (Exception ex)
            {
                _dangNap = false;
                HopThoai.Loi(ex);
            }
        }

        private void cboChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dangNap)
                NapGa();
        }

        private void NapGa()
        {
            int maChuyen = KetNoi_DuLieu.GiaTriCombo(cboChuyen);
            if (maChuyen == 0)
            {
                cboGaDi.DataSource = null;
                cboGaDen.DataSource = null;
                lblGia.Text = "Giá: chọn chuyến";
                return;
            }
            try
            {
                DataTable ga = KetNoi_DuLieu.LayBang("sp_Ga_TheoChuyen", KetNoi_DuLieu.ThamSo("@MaChuyen", maChuyen));
                KetNoi_DuLieu.GanLuoi(dgv, ga.Copy());
                KetNoi_DuLieu.DatTieuDe(dgv, "MaGa", "Mã ga", "TenGa", "Ga trên tuyến", "ThuTu", "Thứ tự");
                KetNoi_DuLieu.GanCombo(cboGaDi, ga.Copy(), "MaGa", "TenGa");
                KetNoi_DuLieu.GanCombo(cboGaDen, ga.Copy(), "MaGa", "TenGa");
                if (cboGaDen.Items.Count > 1)
                    cboGaDen.SelectedIndex = cboGaDen.Items.Count - 1;
                CapNhatGia();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void cboGa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dangNap)
                CapNhatGia();
        }

        private void CapNhatGia()
        {
            int maChuyen = KetNoi_DuLieu.GiaTriCombo(cboChuyen);
            int gaDi = KetNoi_DuLieu.GiaTriCombo(cboGaDi);
            int gaDen = KetNoi_DuLieu.GiaTriCombo(cboGaDen);
            if (maChuyen == 0 || gaDi == 0 || gaDen == 0)
            {
                lblGia.Text = "Giá: chọn ga đi và ga đến";
                return;
            }
            try
            {
                object gia = KetNoi_DuLieu.LayGiaTri(
                    "sp_TinhGia",
                    KetNoi_DuLieu.ThamSo("@MaChuyen", maChuyen),
                    KetNoi_DuLieu.ThamSo("@MaGaDi", gaDi),
                    KetNoi_DuLieu.ThamSo("@MaGaDen", gaDen),
                    KetNoi_DuLieu.ThamSo("@LoaiVe", KetNoi_DuLieu.GiaTriChuoi(cboLoaiVe)));
                lblGia.Text = "Giá: " + Convert.ToDecimal(gia).ToString("N0") + " đ";
            }
            catch
            {
                lblGia.Text = "Giá: ga đi phải đứng trước ga đến";
            }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (HopThoai.Thieu(txtHoTen.Text, "họ tên") || HopThoai.Thieu(txtCCCD.Text, "CCCD"))
                return;
            int maChuyen = KetNoi_DuLieu.GiaTriCombo(cboChuyen);
            if (maChuyen == 0)
            {
                HopThoai.Bao("Không có chuyến chờ chạy.");
                return;
            }
            if (!HopThoai.Hoi("Bán vé cho " + txtHoTen.Text.Trim() + "?"))
                return;
            try
            {
                object maVe = KetNoi_DuLieu.LayGiaTri(
                    "sp_BanVe",
                    KetNoi_DuLieu.ThamSo("@MaChuyen", maChuyen),
                    KetNoi_DuLieu.ThamSo("@HoTen", txtHoTen.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@CCCD", txtCCCD.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@DienThoai", KetNoi_DuLieu.ChuoiHoacNull(txtDienThoai.Text)),
                    KetNoi_DuLieu.ThamSo("@MaGaDi", KetNoi_DuLieu.GiaTriCombo(cboGaDi)),
                    KetNoi_DuLieu.ThamSo("@MaGaDen", KetNoi_DuLieu.GiaTriCombo(cboGaDen)),
                    KetNoi_DuLieu.ThamSo("@LoaiVe", KetNoi_DuLieu.GiaTriChuoi(cboLoaiVe)),
                    KetNoi_DuLieu.ThamSo("@MaNVBan", PhienLamViec.MaNV));
                HopThoai.Bao("Đã bán vé số " + maVe + ".");
                txtHoTen.Clear();
                txtCCCD.Clear();
                txtDienThoai.Clear();
                if (maVe != null && HopThoai.Hoi("Mở tra cứu vé vừa bán?"))
                {
                    using (FrmTraCuuVe tra = new FrmTraCuuVe(Convert.ToInt32(maVe)))
                        tra.ShowDialog(this);
                }
                _dangNap = true;
                DataTable chuyen = KetNoi_DuLieu.LayBang("sp_Chuyen_ChoBan");
                KetNoi_DuLieu.GanCombo(cboChuyen, chuyen, "MaChuyen", "MoTa");
                KetNoi_DuLieu.ChonCombo(cboChuyen, maChuyen);
                _dangNap = false;
                NapGa();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            using (FrmTraCuuVe tra = new FrmTraCuuVe())
                tra.ShowDialog(this);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
