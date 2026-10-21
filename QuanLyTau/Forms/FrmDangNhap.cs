using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string ten = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            if (ten.Length == 0 || matKhau.Length == 0)
            {
                lblLoi.Text = "Nhập tên đăng nhập và mật khẩu.";
                return;
            }

            try
            {
                DataTable bang = KetNoi_DuLieu.LayBang(
                    "sp_DangNhap",
                    KetNoi_DuLieu.ThamSo("@TenDangNhap", ten),
                    KetNoi_DuLieu.ThamSo("@MatKhau", KetNoi_DuLieu.BamMatKhau(matKhau)));
                if (bang.Rows.Count == 0)
                {
                    lblLoi.Text = "Sai tài khoản hoặc tài khoản đã nghỉ.";
                    return;
                }

                PhienLamViec.DangNhap(bang.Rows[0]);
                lblLoi.Text = "";
                try
                {
                    Hide();
                    using (FrmTrangChu trang = new FrmTrangChu())
                        trang.ShowDialog();
                }
                finally
                {
                    PhienLamViec.DangXuat();
                    txtMatKhau.Clear();
                    Show();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                lblLoi.Text = "Không kết nối được SQL Server.";
                MessageBox.Show(
                    ex.Message + "\n\nHãy chạy Database/QuanLyTau.sql trong SSMS và kiểm tra App.config.",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
