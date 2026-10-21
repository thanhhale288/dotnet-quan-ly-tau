using System;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmTraCuuVe : Form
    {
        private readonly int _maVe;
        private readonly string _cccd;

        public FrmTraCuuVe()
            : this(0, "")
        {
        }

        public FrmTraCuuVe(int maVe)
            : this(maVe, "")
        {
        }

        public FrmTraCuuVe(string cccd)
            : this(0, cccd)
        {
        }

        public FrmTraCuuVe(int maVe, string cccd)
        {
            _maVe = maVe;
            _cccd = cccd ?? "";
            InitializeComponent();
        }

        private void FrmTraCuuVe_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.DuocBanVe))
                return;
            dtpNgay.Value = DateTime.Today;
            if (_maVe > 0)
            {
                txtMaVe.Text = _maVe.ToString();
                dtpNgay.Checked = false;
            }
            if (_cccd.Length > 0)
            {
                txtCCCD.Text = _cccd;
                dtpNgay.Checked = false;
            }
            Tim();
        }

        private void Tim()
        {
            int maVe = 0;
            if (txtMaVe.Text.Trim().Length > 0 && !int.TryParse(txtMaVe.Text.Trim(), out maVe))
            {
                HopThoai.Bao("Mã vé phải là số.");
                return;
            }
            object ngay = dtpNgay.Checked ? (object)dtpNgay.Value.Date : DBNull.Value;
            try
            {
                KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang(
                    "sp_Ve_TraCuu",
                    KetNoi_DuLieu.ThamSo("@MaVe", maVe),
                    KetNoi_DuLieu.ThamSo("@CCCD", txtCCCD.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@Ngay", ngay)));
                KetNoi_DuLieu.DatTieuDe(dgv,
                    "MaVe", "Mã vé",
                    "HoTen", "Hành khách",
                    "CCCD", "CCCD",
                    "TenTuyen", "Tuyến",
                    "NgayChay", "Ngày chạy",
                    "GaDi", "Ga đi",
                    "GaDen", "Ga đến",
                    "TenLoaiVe", "Loại vé",
                    "Gia", "Giá",
                    "TenTrangThai", "Trạng thái",
                    "NguoiBan", "Người bán");
                KetNoi_DuLieu.AnCot(dgv, "MaChuyen", "MaHK", "DienThoai", "TrangThai", "LoaiVe");
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            Tim();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaVe");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một vé.");
                return;
            }
            if (!HopThoai.Hoi("Hủy vé số " + ma + "?"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi("sp_HuyVe", KetNoi_DuLieu.ThamSo("@MaVe", ma));
                Tim();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnHanhKhach_Click(object sender, EventArgs e)
        {
            string cccd = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "CCCD");
            if (cccd.Length == 0)
            {
                HopThoai.Bao("Chọn một vé.");
                return;
            }
            using (FrmHanhKhach khach = new FrmHanhKhach(cccd))
                khach.ShowDialog(this);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
