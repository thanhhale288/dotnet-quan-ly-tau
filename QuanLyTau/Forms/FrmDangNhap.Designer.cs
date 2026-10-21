using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new Label();
            this.lblTen = new Label();
            this.txtTenDangNhap = new TextBox();
            this.lblMatKhau = new Label();
            this.txtMatKhau = new TextBox();
            this.btnDangNhap = new Button();
            this.btnThoat = new Button();
            this.lblLoi = new Label();
            this.lblGoiY = new Label();
            this.SuspendLayout();

            this.lblTieuDe.BackColor = Color.FromArgb(15, 76, 129);
            this.lblTieuDe.Dock = DockStyle.Top;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Location = new Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new Size(420, 72);
            this.lblTieuDe.Text = "  Quản lý tàu điện ngầm";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblTen.AutoSize = true;
            this.lblTen.Location = new Point(36, 96);
            this.lblTen.Name = "lblTen";
            this.lblTen.Text = "Tên đăng nhập";

            this.txtTenDangNhap.Location = new Point(40, 122);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new Size(340, 27);

            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new Point(36, 162);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mật khẩu";

            this.txtMatKhau.Location = new Point(40, 188);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new Size(340, 27);
            this.txtMatKhau.UseSystemPasswordChar = true;

            this.lblLoi.ForeColor = Color.Firebrick;
            this.lblLoi.Location = new Point(36, 224);
            this.lblLoi.Name = "lblLoi";
            this.lblLoi.Size = new Size(344, 40);

            this.btnDangNhap.BackColor = Color.FromArgb(15, 76, 129);
            this.btnDangNhap.FlatStyle = FlatStyle.Flat;
            this.btnDangNhap.ForeColor = Color.White;
            this.btnDangNhap.Location = new Point(40, 272);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new Size(160, 38);
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);

            this.btnThoat.Location = new Point(220, 272);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new Size(160, 38);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.lblGoiY.ForeColor = Color.DimGray;
            this.lblGoiY.Location = new Point(36, 320);
            this.lblGoiY.Name = "lblGoiY";
            this.lblGoiY.Size = new Size(344, 36);
            this.lblGoiY.Text = "Tài khoản mẫu: admin / 123456";

            this.AcceptButton = this.btnDangNhap;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new Size(420, 370);
            this.Controls.Add(this.lblGoiY);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.lblLoi);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDangNhap";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTieuDe;
        private Label lblTen;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
        private Label lblLoi;
        private Label lblGoiY;
    }
}
