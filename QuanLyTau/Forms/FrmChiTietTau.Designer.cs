using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmChiTietTau
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
            this.lblSoThuTu = new Label();
            this.numSoThuTu = new NumericUpDown();
            this.lblLoaiToa = new Label();
            this.txtLoaiToa = new TextBox();
            this.lblSucToa = new Label();
            this.numSucToa = new NumericUpDown();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnLuu = new Button();
            this.btnThemToa = new Button();
            this.btnXoaToa = new Button();
            this.btnBaoTri = new Button();
            this.btnDong = new Button();
            this.bangChinh.SuspendLayout();
            this.panelNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThuTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSucToa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panelNut.SuspendLayout();
            this.SuspendLayout();

            this.lblTieuDe.BackColor = Color.FromArgb(15, 76, 129);
            this.lblTieuDe.Dock = DockStyle.Fill;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "  Chi tiết tàu";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblTenTau.AutoSize = true;
            this.lblTenTau.Location = new Point(16, 8);
            this.lblTenTau.Text = "Tên tàu";
            this.txtTenTau.Location = new Point(16, 30);
            this.txtTenTau.Name = "txtTenTau";
            this.txtTenTau.Size = new Size(180, 27);

            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new Point(210, 8);
            this.lblLoai.Text = "Loại";
            this.cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLoai.Location = new Point(210, 30);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new Size(120, 28);

            this.lblSucChua.AutoSize = true;
            this.lblSucChua.Location = new Point(344, 8);
            this.lblSucChua.Text = "Sức chứa";
            this.numSucChua.Location = new Point(344, 30);
            this.numSucChua.Maximum = 5000;
            this.numSucChua.Minimum = 1;
            this.numSucChua.Name = "numSucChua";
            this.numSucChua.Size = new Size(90, 27);
            this.numSucChua.Value = 1;

            this.lblTuyen.AutoSize = true;
            this.lblTuyen.Location = new Point(450, 8);
            this.lblTuyen.Text = "Tuyến";
            this.cboTuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTuyen.Location = new Point(450, 30);
            this.cboTuyen.Name = "cboTuyen";
            this.cboTuyen.Size = new Size(200, 28);

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new Point(666, 8);
            this.lblTrangThai.Text = "Trạng thái";
            this.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location = new Point(666, 30);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new Size(150, 28);

            this.lblSoThuTu.AutoSize = true;
            this.lblSoThuTu.Location = new Point(16, 70);
            this.lblSoThuTu.Text = "Số thứ tự toa";
            this.numSoThuTu.Location = new Point(16, 92);
            this.numSoThuTu.Minimum = 1;
            this.numSoThuTu.Maximum = 20;
            this.numSoThuTu.Name = "numSoThuTu";
            this.numSoThuTu.Size = new Size(80, 27);
            this.numSoThuTu.Value = 1;

            this.lblLoaiToa.AutoSize = true;
            this.lblLoaiToa.Location = new Point(120, 70);
            this.lblLoaiToa.Text = "Loại toa";
            this.txtLoaiToa.Location = new Point(120, 92);
            this.txtLoaiToa.Name = "txtLoaiToa";
            this.txtLoaiToa.Size = new Size(180, 27);
            this.txtLoaiToa.Text = "Thường";

            this.lblSucToa.AutoSize = true;
            this.lblSucToa.Location = new Point(316, 70);
            this.lblSucToa.Text = "Sức chứa toa";
            this.numSucToa.Location = new Point(316, 92);
            this.numSucToa.Maximum = 500;
            this.numSucToa.Minimum = 1;
            this.numSucToa.Name = "numSucToa";
            this.numSucToa.Size = new Size(90, 27);
            this.numSucToa.Value = 100;

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
            this.panelNhap.Controls.Add(this.lblSoThuTu);
            this.panelNhap.Controls.Add(this.numSoThuTu);
            this.panelNhap.Controls.Add(this.lblLoaiToa);
            this.panelNhap.Controls.Add(this.txtLoaiToa);
            this.panelNhap.Controls.Add(this.lblSucToa);
            this.panelNhap.Controls.Add(this.numSucToa);
            this.panelNhap.Dock = DockStyle.Fill;
            this.panelNhap.Name = "panelNhap";

            this.dgv.Dock = DockStyle.Fill;
            this.dgv.Name = "dgv";
            this.dgv.CellClick += new DataGridViewCellEventHandler(this.dgv_CellClick);

            this.panelNut.Dock = DockStyle.Fill;
            this.panelNut.Padding = new Padding(8, 10, 8, 8);
            this.panelNut.WrapContents = false;
            GanNut(this.btnLuu, "btnLuu", "Lưu tàu", this.btnLuu_Click);
            GanNut(this.btnThemToa, "btnThemToa", "Thêm toa", this.btnThemToa_Click);
            GanNut(this.btnXoaToa, "btnXoaToa", "Xóa toa", this.btnXoaToa_Click);
            GanNut(this.btnBaoTri, "btnBaoTri", "Bảo trì", this.btnBaoTri_Click);
            GanNut(this.btnDong, "btnDong", "Đóng", this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnLuu);
            this.panelNut.Controls.Add(this.btnThemToa);
            this.panelNut.Controls.Add(this.btnXoaToa);
            this.panelNut.Controls.Add(this.btnBaoTri);
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
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 136F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));

            this.ClientSize = new Size(1000, 660);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(900, 580);
            this.Name = "FrmChiTietTau";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Chi tiết tàu";
            this.Load += new System.EventHandler(this.FrmChiTietTau_Load);
            this.panelNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSucToa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThuTu)).EndInit();
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
        private Label lblSoThuTu;
        private NumericUpDown numSoThuTu;
        private Label lblLoaiToa;
        private TextBox txtLoaiToa;
        private Label lblSucToa;
        private NumericUpDown numSucToa;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnLuu;
        private Button btnThemToa;
        private Button btnXoaToa;
        private Button btnBaoTri;
        private Button btnDong;
    }
}
