using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmBaoCao : Form
    {
        public FrmBaoCao()
        {
            InitializeComponent();
        }

        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.LaQuanLy))
                return;
            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today;
            Xem();
        }

        private void Xem()
        {
            if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
            {
                HopThoai.Bao("Ngày kết thúc phải sau ngày bắt đầu.");
                return;
            }
            try
            {
                DataTable doanhThu = KetNoi_DuLieu.LayBang(
                    "sp_BaoCaoDoanhThu",
                    KetNoi_DuLieu.ThamSo("@TuNgay", dtpTuNgay.Value.Date),
                    KetNoi_DuLieu.ThamSo("@DenNgay", dtpDenNgay.Value.Date));
                KetNoi_DuLieu.GanLuoi(dgvDoanhThu, doanhThu);
                KetNoi_DuLieu.DatTieuDe(dgvDoanhThu, "Ngay", "Ngày", "SoVe", "Số vé", "DoanhThu", "Doanh thu");

                decimal tong = 0;
                foreach (DataRow dong in doanhThu.Rows)
                    tong += Convert.ToDecimal(dong["DoanhThu"]);
                lblTong.Text = "Tổng doanh thu: " + tong.ToString("N0") + " đ";

                KetNoi_DuLieu.GanLuoi(dgvTuyen, KetNoi_DuLieu.LayBang(
                    "sp_BaoCaoTheoTuyen",
                    KetNoi_DuLieu.ThamSo("@TuNgay", dtpTuNgay.Value.Date),
                    KetNoi_DuLieu.ThamSo("@DenNgay", dtpDenNgay.Value.Date)));
                KetNoi_DuLieu.DatTieuDe(dgvTuyen, "TenTuyen", "Tuyến", "SoVe", "Số vé", "DoanhThu", "Doanh thu");

                KetNoi_DuLieu.GanLuoi(dgvBaoTri, KetNoi_DuLieu.LayBang(
                    "sp_BaoCaoBaoTri",
                    KetNoi_DuLieu.ThamSo("@TuNgay", dtpTuNgay.Value.Date),
                    KetNoi_DuLieu.ThamSo("@DenNgay", dtpDenNgay.Value.Date)));
                KetNoi_DuLieu.DatTieuDe(dgvBaoTri,
                    "MaBT", "Mã phiếu",
                    "TenTau", "Tàu",
                    "NgayBatDau", "Bắt đầu",
                    "NgayKetThuc", "Kết thúc",
                    "NoiDung", "Nội dung",
                    "ChiPhi", "Chi phí",
                    "TenTrangThai", "Trạng thái",
                    "TenNV", "Nhân viên");
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Xem();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
