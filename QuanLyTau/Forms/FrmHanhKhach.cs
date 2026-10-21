using System;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmHanhKhach : Form
    {
        private readonly string _tuKhoa;

        public FrmHanhKhach()
            : this("")
        {
        }

        public FrmHanhKhach(string tuKhoa)
        {
            _tuKhoa = tuKhoa ?? "";
            InitializeComponent();
        }

        private void FrmHanhKhach_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.DuocBanVe))
                return;
            txtTim.Text = _tuKhoa;
            TaiKhach();
        }

        private void TaiKhach()
        {
            try
            {
                KetNoi_DuLieu.GanLuoi(dgvKhach, KetNoi_DuLieu.LayBang(
                    "sp_HanhKhach_Select",
                    KetNoi_DuLieu.ThamSo("@TuKhoa", txtTim.Text.Trim())));
                KetNoi_DuLieu.DatTieuDe(dgvKhach,
                    "MaHK", "Mã khách",
                    "HoTen", "Họ tên",
                    "CCCD", "CCCD",
                    "DienThoai", "Điện thoại");
                TaiVe();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void TaiVe()
        {
            int ma = KetNoi_DuLieu.So(dgvKhach.CurrentRow, "MaHK");
            if (ma == 0)
            {
                dgvVe.DataSource = null;
                return;
            }
            KetNoi_DuLieu.GanLuoi(dgvVe, KetNoi_DuLieu.LayBang("sp_Ve_TheoKhach", KetNoi_DuLieu.ThamSo("@MaHK", ma)));
            KetNoi_DuLieu.DatTieuDe(dgvVe,
                "MaVe", "Mã vé",
                "TenTuyen", "Tuyến",
                "NgayChay", "Ngày chạy",
                "GaDi", "Ga đi",
                "GaDen", "Ga đến",
                "TenLoaiVe", "Loại vé",
                "Gia", "Giá",
                "TenTrangThai", "Trạng thái");
            KetNoi_DuLieu.AnCot(dgvVe, "MaHK", "CCCD");
        }

        private void dgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                TaiVe();
        }

        private void dgvKhach_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            TaiVe();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TaiKhach();
        }

        private void btnXemVe_Click(object sender, EventArgs e)
        {
            string cccd = KetNoi_DuLieu.Chuoi(dgvKhach.CurrentRow, "CCCD");
            if (cccd.Length == 0)
            {
                HopThoai.Bao("Chọn một hành khách.");
                return;
            }
            using (FrmTraCuuVe tra = new FrmTraCuuVe(cccd))
                tra.ShowDialog(this);
            TaiVe();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
