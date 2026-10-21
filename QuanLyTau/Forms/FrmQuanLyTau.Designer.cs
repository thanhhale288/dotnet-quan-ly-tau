using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmQuanLyTau
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
            this.lblLocTuyen = new Label();
            this.cboLocTuyen = new ComboBox();
            this.lblLocTrangThai = new Label();
            this.cboLocTrangThai = new ComboBox();
            this.lblTenTau = new Label();
            this.txtTenTau = new TextBox();
            this.lblLoai = new Label();
            this.cboLoai = new ComboBox();
            this.lblSucChua = new Label();
            this.numSucChua = new NumericUpDown();
            this.lblTuyen = new Label();
            this.cboTuyen = new ComboBox();
            this.lblTrangThai = new Label();
            this.cboTrangThai = new ComboBox();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnChiTiet = new Button();
            this.btnTaiLai = new Button();
            this.btnDong = new Button();
            this.bangChinh.SuspendLayout();
            this.panelNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panelNut.SuspendLayout();
            this.SuspendLayout();

            this.lblTieuDe.BackColor = Color.FromArgb(15, 76, 129);
            this.lblTieuDe.Dock = DockStyle.Fill;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "  Quản lý tàu";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblLocTuyen.AutoSize = true;
            this.lblLocTuyen.Location = new Point(16, 8);
            this.lblLocTuyen.Text = "Lọc tuyến";
            this.cboLocTuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLocTuyen.Location = new Point(16, 30);
            this.cboLocTuyen.Name = "cboLocTuyen";
            this.cboLocTuyen.Size = new Size(220, 28);
            this.cboLocTuyen.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);

            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Location = new Point(252, 8);
            this.lblLocTrangThai.Text = "Lọc trạng thái";
            this.cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Location = new Point(252, 30);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new Size(160, 28);
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);

            this.lblTenTau.AutoSize = true;
            this.lblTenTau.Location = new Point(16, 68);
            this.lblTenTau.Text = "Tên tàu";
            this.txtTenTau.Location = new Point(16, 90);
            this.txtTenTau.Name = "txtTenTau";
            this.txtTenTau.Size = new Size(180, 27);

            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new Point(210, 68);
            this.lblLoai.Text = "Loại";
            this.cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLoai.Location = new Point(210, 90);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new Size(120, 28);

            this.lblSucChua.AutoSize = true;
            this.lblSucChua.Location = new Point(344, 68);
            this.lblSucChua.Text = "Sức chứa";
            this.numSucChua.Location = new Point(344, 90);
            this.numSucChua.Maximum = 5000;
            this.numSucChua.Minimum = 1;
            this.numSucChua.Name = "numSucChua";
            this.numSucChua.Size = new Size(90, 27);
            this.numSucChua.Value = 200;

            this.lblTuyen.AutoSize = true;
            this.lblTuyen.Location = new Point(450, 68);
            this.lblTuyen.Text = "Tuyến";
            this.cboTuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTuyen.Location = new Point(450, 90);
            this.cboTuyen.Name = "cboTuyen";
            this.cboTuyen.Size = new Size(200, 28);

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new Point(666, 68);
            this.lblTrangThai.Text = "Trạng thái";
            this.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location = new Point(666, 90);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new Size(150, 28);

            this.panelNhap.Controls.Add(this.lblLocTuyen);
            this.panelNhap.Controls.Add(this.cboLocTuyen);
            this.panelNhap.Controls.Add(this.lblLocTrangThai);
            this.panelNhap.Controls.Add(this.cboLocTrangThai);
            this.panelNhap.Controls.Add(this.lblTenTau);
            this.panelNhap.Controls.Add(this.txtTenTau);
            this.panelNhap.Controls.Add(this.lblLoai);
            this.panelNhap.Controls.Add(this.cboLoai);
            this.panelNhap.Controls.Add(this.lblSucChua);
            this.panelNhap.Controls.Add(this.numSucChua);
            this.panelNhap.Controls.Add(this.lblTuyen);
            this.panelNhap.Controls.Add(this.cboTuyen);
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
            GanNut(this.btnChiTiet, "btnChiTiet", "Chi tiết", this.btnChiTiet_Click);
            GanNut(this.btnTaiLai, "btnTaiLai", "Tải lại", this.btnTaiLai_Click);
            GanNut(this.btnDong, "btnDong", "Đóng", this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnThem);
            this.panelNut.Controls.Add(this.btnSua);
            this.panelNut.Controls.Add(this.btnChiTiet);
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

            this.ClientSize = new Size(1040, 680);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(960, 600);
            this.Name = "FrmQuanLyTau";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý tàu";
            this.Load += new System.EventHandler(this.FrmQuanLyTau_Load);
            this.panelNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChua)).EndInit();
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
        private Label lblLocTuyen;
        private ComboBox cboLocTuyen;
        private Label lblLocTrangThai;
        private ComboBox cboLocTrangThai;
        private Label lblTenTau;
        private TextBox txtTenTau;
        private Label lblLoai;
        private ComboBox cboLoai;
        private Label lblSucChua;
        private NumericUpDown numSucChua;
        private Label lblTuyen;
        private ComboBox cboTuyen;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnThem;
        private Button btnSua;
        private Button btnChiTiet;
        private Button btnTaiLai;
        private Button btnDong;
    }
}
