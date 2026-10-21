using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmBanVe
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
            this.lblChuyen = new Label();
            this.cboChuyen = new ComboBox();
            this.lblHoTen = new Label();
            this.txtHoTen = new TextBox();
            this.lblCCCD = new Label();
            this.txtCCCD = new TextBox();
            this.lblDienThoai = new Label();
            this.txtDienThoai = new TextBox();
            this.lblGaDi = new Label();
            this.cboGaDi = new ComboBox();
            this.lblGaDen = new Label();
            this.cboGaDen = new ComboBox();
            this.lblLoaiVe = new Label();
            this.cboLoaiVe = new ComboBox();
            this.lblGia = new Label();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnBan = new Button();
            this.btnTraCuu = new Button();
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
            this.lblTieuDe.Text = "  Bán vé";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblChuyen.AutoSize = true;
            this.lblChuyen.Location = new Point(16, 8);
            this.lblChuyen.Text = "Chuyến";
            this.cboChuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboChuyen.Location = new Point(16, 30);
            this.cboChuyen.Name = "cboChuyen";
            this.cboChuyen.Size = new Size(520, 28);
            this.cboChuyen.SelectedIndexChanged += new System.EventHandler(this.cboChuyen_SelectedIndexChanged);

            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new Point(16, 68);
            this.lblHoTen.Text = "Họ tên";
            this.txtHoTen.Location = new Point(16, 90);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new Size(220, 27);

            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new Point(252, 68);
            this.lblCCCD.Text = "CCCD";
            this.txtCCCD.Location = new Point(252, 90);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new Size(160, 27);

            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new Point(428, 68);
            this.lblDienThoai.Text = "Điện thoại";
            this.txtDienThoai.Location = new Point(428, 90);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new Size(140, 27);

            this.lblGaDi.AutoSize = true;
            this.lblGaDi.Location = new Point(16, 128);
            this.lblGaDi.Text = "Ga đi";
            this.cboGaDi.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGaDi.Location = new Point(16, 150);
            this.cboGaDi.Name = "cboGaDi";
            this.cboGaDi.Size = new Size(220, 28);
            this.cboGaDi.SelectedIndexChanged += new System.EventHandler(this.cboGa_SelectedIndexChanged);

            this.lblGaDen.AutoSize = true;
            this.lblGaDen.Location = new Point(252, 128);
            this.lblGaDen.Text = "Ga đến";
            this.cboGaDen.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGaDen.Location = new Point(252, 150);
            this.cboGaDen.Name = "cboGaDen";
            this.cboGaDen.Size = new Size(220, 28);
            this.cboGaDen.SelectedIndexChanged += new System.EventHandler(this.cboGa_SelectedIndexChanged);

            this.lblLoaiVe.AutoSize = true;
            this.lblLoaiVe.Location = new Point(488, 128);
            this.lblLoaiVe.Text = "Loại vé";
            this.cboLoaiVe.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLoaiVe.Location = new Point(488, 150);
            this.cboLoaiVe.Name = "cboLoaiVe";
            this.cboLoaiVe.Size = new Size(140, 28);
            this.cboLoaiVe.SelectedIndexChanged += new System.EventHandler(this.cboGa_SelectedIndexChanged);

            this.lblGia.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblGia.Location = new Point(650, 140);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new Size(280, 36);
            this.lblGia.Text = "Giá: ...";

            this.panelNhap.Controls.Add(this.lblChuyen);
            this.panelNhap.Controls.Add(this.cboChuyen);
            this.panelNhap.Controls.Add(this.lblHoTen);
            this.panelNhap.Controls.Add(this.txtHoTen);
            this.panelNhap.Controls.Add(this.lblCCCD);
            this.panelNhap.Controls.Add(this.txtCCCD);
            this.panelNhap.Controls.Add(this.lblDienThoai);
            this.panelNhap.Controls.Add(this.txtDienThoai);
            this.panelNhap.Controls.Add(this.lblGaDi);
            this.panelNhap.Controls.Add(this.cboGaDi);
            this.panelNhap.Controls.Add(this.lblGaDen);
            this.panelNhap.Controls.Add(this.cboGaDen);
            this.panelNhap.Controls.Add(this.lblLoaiVe);
            this.panelNhap.Controls.Add(this.cboLoaiVe);
            this.panelNhap.Controls.Add(this.lblGia);
            this.panelNhap.Dock = DockStyle.Fill;
            this.panelNhap.Name = "panelNhap";

            this.dgv.Dock = DockStyle.Fill;
            this.dgv.Name = "dgv";

            this.panelNut.Dock = DockStyle.Fill;
            this.panelNut.Padding = new Padding(8, 10, 8, 8);
            this.panelNut.WrapContents = false;
            this.btnBan.Margin = new Padding(6);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new Size(140, 36);
            this.btnBan.Text = "Bán vé";
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            this.btnTraCuu.Margin = new Padding(6);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new Size(140, 36);
            this.btnTraCuu.Text = "Tra cứu vé";
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            this.btnDong.Margin = new Padding(6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(120, 36);
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnBan);
            this.panelNut.Controls.Add(this.btnTraCuu);
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
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 196F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));

            this.ClientSize = new Size(1000, 680);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(900, 600);
            this.Name = "FrmBanVe";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bán vé";
            this.Load += new System.EventHandler(this.FrmBanVe_Load);
            this.panelNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panelNhap.ResumeLayout(false);
            this.panelNhap.PerformLayout();
            this.bangChinh.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private TableLayoutPanel bangChinh;
        private Label lblTieuDe;
        private Panel panelNhap;
        private Label lblChuyen;
        private ComboBox cboChuyen;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblCCCD;
        private TextBox txtCCCD;
        private Label lblDienThoai;
        private TextBox txtDienThoai;
        private Label lblGaDi;
        private ComboBox cboGaDi;
        private Label lblGaDen;
        private ComboBox cboGaDen;
        private Label lblLoaiVe;
        private ComboBox cboLoaiVe;
        private Label lblGia;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnBan;
        private Button btnTraCuu;
        private Button btnDong;
    }
}
