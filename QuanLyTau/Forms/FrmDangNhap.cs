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
                    ex.Message
                    + "\n\nĐang kết nối tới: " + KetNoi_DuLieu.LayTenMayChu()
                    + "\nDatabase: QuanLyTau"
                    + "\n\nKiểm tra:\n"
                    + "1) SSMS kết nối cùng server (thường .\\SQLEXPRESS), chạy Database/QuanLyTau.sql (Execute).\n"
                    + "2) Sửa QuanLyTau/App.config → connectionStrings (trong XML chỉ cần .\\SQLEXPRESS một dấu \\).\n"
                    + "3) Visual Studio: Build → Rebuild Solution, rồi F5 lại.\n"
                    + "4) Services.msc: SQL Server (SQLEXPRESS) đang Running.",
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
