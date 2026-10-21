using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmTrangChu : Form
    {
        public FrmTrangChu()
        {
            InitializeComponent();
        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            lblXinChao.Text = "Xin chào " + PhienLamViec.HoTen + "  ·  " + PhienLamViec.TenChucVu(PhienLamViec.ChucVu);
            btnTuyen.Visible = PhienLamViec.LaQuanLy;
            btnGa.Visible = PhienLamViec.LaQuanLy;
            btnLich.Visible = PhienLamViec.LaQuanLy;
            btnNhanVien.Visible = PhienLamViec.LaQuanLy;
            btnBaoCao.Visible = PhienLamViec.LaQuanLy;
            btnTau.Visible = PhienLamViec.DuocKyThuat;
            btnBaoTri.Visible = PhienLamViec.DuocKyThuat;
            btnChuyen.Visible = PhienLamViec.DuocXemChuyen;
            btnBanVe.Visible = PhienLamViec.DuocBanVe;
            btnTraCuu.Visible = PhienLamViec.DuocBanVe;
            btnHanhKhach.Visible = PhienLamViec.DuocBanVe;
            TaiThongKe();
        }

        private void TaiThongKe()
        {
            try
            {
                DataTable thongKe = KetNoi_DuLieu.LayBang("sp_ThongKeTrangChu");
                if (thongKe.Rows.Count == 0)
                    return;
                DataRow dong = thongKe.Rows[0];
                lblTauSanSang.Text = "Tàu sẵn sàng: " + dong["TauSanSang"];
                lblChuyenHomNay.Text = "Chuyến hôm nay: " + dong["ChuyenHomNay"];
                lblVeHomNay.Text = "Vé hôm nay: " + dong["VeHomNay"];
            }
            catch (Exception ex)
            {
                lblTauSanSang.Text = "Chưa đọc được thống kê";
                lblChuyenHomNay.Text = ex.Message;
                lblVeHomNay.Text = "";
            }
        }

        private void Mo(Form form)
        {
            using (form)
                form.ShowDialog(this);
            TaiThongKe();
        }

        private void btnTuyen_Click(object sender, EventArgs e) { Mo(new FrmQuanLyTuyen()); }
        private void btnGa_Click(object sender, EventArgs e) { Mo(new FrmQuanLyGa()); }
        private void btnTau_Click(object sender, EventArgs e) { Mo(new FrmQuanLyTau()); }
        private void btnLich_Click(object sender, EventArgs e) { Mo(new FrmLichTrinh()); }
        private void btnChuyen_Click(object sender, EventArgs e) { Mo(new FrmChuyenTau()); }
        private void btnBaoTri_Click(object sender, EventArgs e) { Mo(new FrmBaoTri()); }
        private void btnBanVe_Click(object sender, EventArgs e) { Mo(new FrmBanVe()); }
        private void btnTraCuu_Click(object sender, EventArgs e) { Mo(new FrmTraCuuVe()); }
        private void btnHanhKhach_Click(object sender, EventArgs e) { Mo(new FrmHanhKhach()); }
        private void btnNhanVien_Click(object sender, EventArgs e) { Mo(new FrmNhanVien()); }
        private void btnBaoCao_Click(object sender, EventArgs e) { Mo(new FrmBaoCao()); }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
