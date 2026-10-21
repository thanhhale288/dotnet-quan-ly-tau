using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmNhanVien
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
            this.bangChinh = new TableLayoutPanel();
            this.lblTieuDe = new Label();
            this.panelNhap = new Panel();
            this.lblHoTen = new Label();
            this.txtHoTen = new TextBox();
            this.lblChucVu = new Label();
            this.cboChucVu = new ComboBox();
            this.lblTenDangNhap = new Label();
            this.txtTenDangNhap = new TextBox();
            this.lblMatKhau = new Label();
            this.txtMatKhau = new TextBox();
            this.lblDienThoai = new Label();
            this.txtDienThoai = new TextBox();
            this.lblTrangThai = new Label();
            this.cboTrangThai = new ComboBox();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnTaiLai = new Button();
            this.btnDong = new Button();
            this.bangChinh.SuspendLayout();
            this.panelNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panelNut.SuspendLayout();
            this.SuspendLayout();

            this.lblTieuDe.BackColor = Color.FromArgb(15, 76, 129);
            this.lblTieuDe.Dock = DockStyle.Fill;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "  Nhân viên";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new Point(16, 8);
            this.lblHoTen.Text = "Họ tên";
            this.txtHoTen.Location = new Point(16, 30);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new Size(200, 27);

            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Location = new Point(232, 8);
            this.lblChucVu.Text = "Chức vụ";
            this.cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboChucVu.Location = new Point(232, 30);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new Size(150, 28);

            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new Point(398, 8);
            this.lblTenDangNhap.Text = "Tên đăng nhập (khi thêm)";
            this.txtTenDangNhap.Location = new Point(398, 30);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new Size(180, 27);

            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new Point(16, 68);
            this.lblMatKhau.Text = "Mật khẩu (bỏ trống nếu giữ mật khẩu cũ)";
            this.txtMatKhau.Location = new Point(16, 90);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new Size(280, 27);
            this.txtMatKhau.UseSystemPasswordChar = true;

            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new Point(312, 68);
            this.lblDienThoai.Text = "Điện thoại";
            this.txtDienThoai.Location = new Point(312, 90);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new Size(150, 27);

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new Point(478, 68);
            this.lblTrangThai.Text = "Trạng thái";
            this.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location = new Point(478, 90);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new Size(150, 28);

            this.panelNhap.Controls.Add(this.lblHoTen);
            this.panelNhap.Controls.Add(this.txtHoTen);
            this.panelNhap.Controls.Add(this.lblChucVu);
            this.panelNhap.Controls.Add(this.cboChucVu);
            this.panelNhap.Controls.Add(this.lblTenDangNhap);
            this.panelNhap.Controls.Add(this.txtTenDangNhap);
            this.panelNhap.Controls.Add(this.lblMatKhau);
            this.panelNhap.Controls.Add(this.txtMatKhau);
            this.panelNhap.Controls.Add(this.lblDienThoai);
            this.panelNhap.Controls.Add(this.txtDienThoai);
            this.panelNhap.Controls.Add(this.lblTrangThai);
            this.panelNhap.Controls.Add(this.cboTrangThai);
            this.panelNhap.Dock = DockStyle.Fill;
            this.panelNhap.Name = "panelNhap";

            this.dgv.Dock = DockStyle.Fill;
            this.dgv.Name = "dgv";
            this.dgv.CellClick += new DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);

            this.panelNut.Dock = DockStyle.Fill;
            this.panelNut.Padding = new Padding(8, 10, 8, 8);
            this.panelNut.WrapContents = false;
            GanNut(this.btnThem, "btnThem", "Thêm", this.btnThem_Click);
            GanNut(this.btnSua, "btnSua", "Sửa", this.btnSua_Click);
            GanNut(this.btnTaiLai, "btnTaiLai", "Tải lại", this.btnTaiLai_Click);
            GanNut(this.btnDong, "btnDong", "Đóng", this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnThem);
            this.panelNut.Controls.Add(this.btnSua);
            this.panelNut.Controls.Add(this.btnTaiLai);
            this.panelNut.Controls.Add(this.btnDong);

            this.bangChinh.ColumnCount = 1;
            this.bangChinh.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.bangChinh.Controls.Add(this.lblTieuDe, 0, 0);
            this.bangChinh.Controls.Add(this.panelNhap, 0, 1);
            this.bangChinh.Controls.Add(this.dgv, 0, 2);
            this.bangChinh.Controls.Add(this.panelNut, 0, 3);
            this.bangChinh.Dock = DockStyle.Fill;
            this.bangChinh.RowCount = 4;
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 132F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));

            this.ClientSize = new Size(1000, 660);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(900, 580);
            this.Name = "FrmNhanVien";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Nhân viên";
            this.Load += new System.EventHandler(this.FrmNhanVien_Load);
            this.panelNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panelNhap.ResumeLayout(false);
            this.panelNhap.PerformLayout();
            this.bangChinh.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void GanNut(Button nut, string ten, string chu, System.EventHandler suKien)
        {
            nut.Margin = new Padding(6);
            nut.Name = ten;
            nut.Size = new Size(120, 36);
            nut.Text = chu;
            nut.Click += suKien;
        }

        private TableLayoutPanel bangChinh;
        private Label lblTieuDe;
        private Panel panelNhap;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblChucVu;
        private ComboBox cboChucVu;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblDienThoai;
        private TextBox txtDienThoai;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnThem;
        private Button btnSua;
        private Button btnTaiLai;
        private Button btnDong;
    }
}
