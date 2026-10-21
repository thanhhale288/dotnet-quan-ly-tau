using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmChuyenTau
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
            this.lblNgay = new Label();
            this.dtpNgay = new DateTimePicker();
            this.btnLoc = new Button();
            this.lblLaiTau = new Label();
            this.cboLaiTau = new ComboBox();
            this.lblTrangThai = new Label();
            this.cboTrangThai = new ComboBox();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnCapNhat = new Button();
            this.btnBanVe = new Button();
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
            this.lblTieuDe.Text = "  Chuyến tàu";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new Point(16, 16);
            this.lblNgay.Text = "Ngày chạy";
            this.dtpNgay.Format = DateTimePickerFormat.Short;
            this.dtpNgay.Location = new Point(16, 40);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new Size(140, 27);

            this.btnLoc.Location = new Point(170, 38);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new Size(90, 32);
            this.btnLoc.Text = "Xem";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);

            this.lblLaiTau.AutoSize = true;
            this.lblLaiTau.Location = new Point(290, 16);
            this.lblLaiTau.Text = "Lái tàu";
            this.cboLaiTau.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLaiTau.Location = new Point(290, 40);
            this.cboLaiTau.Name = "cboLaiTau";
            this.cboLaiTau.Size = new Size(220, 28);

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new Point(530, 16);
            this.lblTrangThai.Text = "Trạng thái";
            this.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location = new Point(530, 40);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new Size(180, 28);

            this.panelNhap.Controls.Add(this.lblNgay);
            this.panelNhap.Controls.Add(this.dtpNgay);
            this.panelNhap.Controls.Add(this.btnLoc);
            this.panelNhap.Controls.Add(this.lblLaiTau);
            this.panelNhap.Controls.Add(this.cboLaiTau);
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
            this.btnCapNhat.Margin = new Padding(6);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new Size(140, 36);
            this.btnCapNhat.Text = "Cập nhật chuyến";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            this.btnBanVe.Margin = new Padding(6);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.Size = new Size(120, 36);
            this.btnBanVe.Text = "Bán vé";
            this.btnBanVe.Click += new System.EventHandler(this.btnBanVe_Click);
            this.btnDong.Margin = new Padding(6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(120, 36);
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnCapNhat);
            this.panelNut.Controls.Add(this.btnBanVe);
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
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));

            this.ClientSize = new Size(1000, 640);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(900, 560);
            this.Name = "FrmChuyenTau";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Chuyến tàu";
            this.Load += new System.EventHandler(this.FrmChuyenTau_Load);
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
        private Label lblNgay;
        private DateTimePicker dtpNgay;
        private Button btnLoc;
        private Label lblLaiTau;
        private ComboBox cboLaiTau;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnCapNhat;
        private Button btnBanVe;
        private Button btnDong;
    }
}
