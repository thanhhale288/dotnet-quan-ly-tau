using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmBaoTri
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
            this.lblTau = new Label();
            this.cboTau = new ComboBox();
            this.lblBatDau = new Label();
            this.dtpBatDau = new DateTimePicker();
            this.lblKetThuc = new Label();
            this.dtpKetThuc = new DateTimePicker();
            this.lblNoiDung = new Label();
            this.txtNoiDung = new TextBox();
            this.lblChiPhi = new Label();
            this.numChiPhi = new NumericUpDown();
            this.lblTrangThai = new Label();
            this.cboTrangThai = new ComboBox();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnHoanThanh = new Button();
            this.btnTaiLai = new Button();
            this.btnDong = new Button();
            this.bangChinh.SuspendLayout();
            this.panelNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChiPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panelNut.SuspendLayout();
            this.SuspendLayout();

            this.lblTieuDe.BackColor = Color.FromArgb(15, 76, 129);
            this.lblTieuDe.Dock = DockStyle.Fill;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "  Bảo trì tàu";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblTau.AutoSize = true;
            this.lblTau.Location = new Point(16, 8);
            this.lblTau.Text = "Tàu";
            this.cboTau.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTau.Location = new Point(16, 30);
            this.cboTau.Name = "cboTau";
            this.cboTau.Size = new Size(200, 28);

            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Location = new Point(232, 8);
            this.lblBatDau.Text = "Ngày bắt đầu";
            this.dtpBatDau.Format = DateTimePickerFormat.Short;
            this.dtpBatDau.Location = new Point(232, 30);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new Size(130, 27);

            this.lblKetThuc.AutoSize = true;
            this.lblKetThuc.Location = new Point(378, 8);
            this.lblKetThuc.Text = "Ngày kết thúc";
            this.dtpKetThuc.Format = DateTimePickerFormat.Short;
            this.dtpKetThuc.Location = new Point(378, 30);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.ShowCheckBox = true;
            this.dtpKetThuc.Size = new Size(150, 27);

            this.lblChiPhi.AutoSize = true;
            this.lblChiPhi.Location = new Point(544, 8);
            this.lblChiPhi.Text = "Chi phí";
            this.numChiPhi.Location = new Point(544, 30);
            this.numChiPhi.Maximum = 1000000000;
            this.numChiPhi.Name = "numChiPhi";
            this.numChiPhi.Size = new Size(140, 27);
            this.numChiPhi.ThousandsSeparator = true;

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new Point(700, 8);
            this.lblTrangThai.Text = "Trạng thái";
            this.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location = new Point(700, 30);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new Size(150, 28);

            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new Point(16, 68);
            this.lblNoiDung.Text = "Nội dung";
            this.txtNoiDung.Location = new Point(16, 90);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new Size(834, 27);

            this.panelNhap.Controls.Add(this.lblTau);
            this.panelNhap.Controls.Add(this.cboTau);
            this.panelNhap.Controls.Add(this.lblBatDau);
            this.panelNhap.Controls.Add(this.dtpBatDau);
            this.panelNhap.Controls.Add(this.lblKetThuc);
            this.panelNhap.Controls.Add(this.dtpKetThuc);
            this.panelNhap.Controls.Add(this.lblChiPhi);
            this.panelNhap.Controls.Add(this.numChiPhi);
            this.panelNhap.Controls.Add(this.lblTrangThai);
            this.panelNhap.Controls.Add(this.cboTrangThai);
            this.panelNhap.Controls.Add(this.lblNoiDung);
            this.panelNhap.Controls.Add(this.txtNoiDung);
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
            GanNut(this.btnHoanThanh, "btnHoanThanh", "Hoàn thành", this.btnHoanThanh_Click);
            this.btnHoanThanh.Size = new Size(130, 36);
            GanNut(this.btnTaiLai, "btnTaiLai", "Tải lại", this.btnTaiLai_Click);
            GanNut(this.btnDong, "btnDong", "Đóng", this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnThem);
            this.panelNut.Controls.Add(this.btnSua);
            this.panelNut.Controls.Add(this.btnHoanThanh);
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
            this.Name = "FrmBaoTri";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bảo trì";
            this.Load += new System.EventHandler(this.FrmBaoTri_Load);
            this.panelNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChiPhi)).EndInit();
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
        private Label lblTau;
        private ComboBox cboTau;
        private Label lblBatDau;
        private DateTimePicker dtpBatDau;
        private Label lblKetThuc;
        private DateTimePicker dtpKetThuc;
        private Label lblNoiDung;
        private TextBox txtNoiDung;
        private Label lblChiPhi;
        private NumericUpDown numChiPhi;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnThem;
        private Button btnSua;
        private Button btnHoanThanh;
        private Button btnTaiLai;
        private Button btnDong;
    }
}
