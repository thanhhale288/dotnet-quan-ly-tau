using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmLichTrinh
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
            this.lblTuyen = new Label();
            this.cboTuyen = new ComboBox();
            this.lblTau = new Label();
            this.cboTau = new ComboBox();
            this.lblGioDi = new Label();
            this.dtpGioDi = new DateTimePicker();
            this.lblGioDen = new Label();
            this.dtpGioDen = new DateTimePicker();
            this.chkT2 = new CheckBox();
            this.chkT3 = new CheckBox();
            this.chkT4 = new CheckBox();
            this.chkT5 = new CheckBox();
            this.chkT6 = new CheckBox();
            this.chkT7 = new CheckBox();
            this.chkCN = new CheckBox();
            this.lblTuNgay = new Label();
            this.dtpTuNgay = new DateTimePicker();
            this.lblDenNgay = new Label();
            this.dtpDenNgay = new DateTimePicker();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnNgung = new Button();
            this.btnSinhChuyen = new Button();
            this.btnXemChuyen = new Button();
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
            this.lblTieuDe.Text = "  Lịch trình";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblTuyen.AutoSize = true;
            this.lblTuyen.Location = new Point(16, 8);
            this.lblTuyen.Text = "Tuyến";
            this.cboTuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTuyen.Location = new Point(16, 30);
            this.cboTuyen.Name = "cboTuyen";
            this.cboTuyen.Size = new Size(220, 28);

            this.lblTau.AutoSize = true;
            this.lblTau.Location = new Point(252, 8);
            this.lblTau.Text = "Tàu";
            this.cboTau.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTau.Location = new Point(252, 30);
            this.cboTau.Name = "cboTau";
            this.cboTau.Size = new Size(200, 28);

            this.lblGioDi.AutoSize = true;
            this.lblGioDi.Location = new Point(468, 8);
            this.lblGioDi.Text = "Giờ đi";
            this.dtpGioDi.CustomFormat = "HH:mm";
            this.dtpGioDi.Format = DateTimePickerFormat.Custom;
            this.dtpGioDi.Location = new Point(468, 30);
            this.dtpGioDi.Name = "dtpGioDi";
            this.dtpGioDi.ShowUpDown = true;
            this.dtpGioDi.Size = new Size(90, 27);
            this.dtpGioDi.Value = new System.DateTime(2026, 1, 1, 6, 30, 0);

            this.lblGioDen.AutoSize = true;
            this.lblGioDen.Location = new Point(574, 8);
            this.lblGioDen.Text = "Giờ đến";
            this.dtpGioDen.CustomFormat = "HH:mm";
            this.dtpGioDen.Format = DateTimePickerFormat.Custom;
            this.dtpGioDen.Location = new Point(574, 30);
            this.dtpGioDen.Name = "dtpGioDen";
            this.dtpGioDen.ShowUpDown = true;
            this.dtpGioDen.Size = new Size(90, 27);
            this.dtpGioDen.Value = new System.DateTime(2026, 1, 1, 7, 20, 0);

            GanCheck(this.chkT2, "chkT2", "T2", 16);
            GanCheck(this.chkT3, "chkT3", "T3", 80);
            GanCheck(this.chkT4, "chkT4", "T4", 144);
            GanCheck(this.chkT5, "chkT5", "T5", 208);
            GanCheck(this.chkT6, "chkT6", "T6", 272);
            GanCheck(this.chkT7, "chkT7", "T7", 336);
            GanCheck(this.chkCN, "chkCN", "CN", 400);

            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new Point(16, 112);
            this.lblTuNgay.Text = "Sinh chuyến từ";
            this.dtpTuNgay.Format = DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new Point(16, 134);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new Size(140, 27);

            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new Point(172, 112);
            this.lblDenNgay.Text = "đến";
            this.dtpDenNgay.Format = DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new Point(172, 134);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new Size(140, 27);

            this.panelNhap.Controls.Add(this.lblTuyen);
            this.panelNhap.Controls.Add(this.cboTuyen);
            this.panelNhap.Controls.Add(this.lblTau);
            this.panelNhap.Controls.Add(this.cboTau);
            this.panelNhap.Controls.Add(this.lblGioDi);
            this.panelNhap.Controls.Add(this.dtpGioDi);
            this.panelNhap.Controls.Add(this.lblGioDen);
            this.panelNhap.Controls.Add(this.dtpGioDen);
            this.panelNhap.Controls.Add(this.chkT2);
            this.panelNhap.Controls.Add(this.chkT3);
            this.panelNhap.Controls.Add(this.chkT4);
            this.panelNhap.Controls.Add(this.chkT5);
            this.panelNhap.Controls.Add(this.chkT6);
            this.panelNhap.Controls.Add(this.chkT7);
            this.panelNhap.Controls.Add(this.chkCN);
            this.panelNhap.Controls.Add(this.lblTuNgay);
            this.panelNhap.Controls.Add(this.dtpTuNgay);
            this.panelNhap.Controls.Add(this.lblDenNgay);
            this.panelNhap.Controls.Add(this.dtpDenNgay);
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
            GanNut(this.btnNgung, "btnNgung", "Ngừng", this.btnNgung_Click);
            GanNut(this.btnSinhChuyen, "btnSinhChuyen", "Sinh chuyến", this.btnSinhChuyen_Click);
            this.btnSinhChuyen.Size = new Size(130, 36);
            GanNut(this.btnXemChuyen, "btnXemChuyen", "Xem chuyến", this.btnXemChuyen_Click);
            this.btnXemChuyen.Size = new Size(130, 36);
            GanNut(this.btnTaiLai, "btnTaiLai", "Tải lại", this.btnTaiLai_Click);
            GanNut(this.btnDong, "btnDong", "Đóng", this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnThem);
            this.panelNut.Controls.Add(this.btnSua);
            this.panelNut.Controls.Add(this.btnNgung);
            this.panelNut.Controls.Add(this.btnSinhChuyen);
            this.panelNut.Controls.Add(this.btnXemChuyen);
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
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 176F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));

            this.ClientSize = new Size(1100, 700);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(1000, 620);
            this.Name = "FrmLichTrinh";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Lịch trình";
            this.Load += new System.EventHandler(this.FrmLichTrinh_Load);
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
            nut.Size = new Size(110, 36);
            nut.Text = chu;
            nut.Click += suKien;
        }

        private static void GanCheck(CheckBox chk, string ten, string chu, int x)
        {
            chk.AutoSize = true;
            chk.Location = new Point(x, 78);
            chk.Name = ten;
            chk.Text = chu;
        }

        private TableLayoutPanel bangChinh;
        private Label lblTieuDe;
        private Panel panelNhap;
        private Label lblTuyen;
        private ComboBox cboTuyen;
        private Label lblTau;
        private ComboBox cboTau;
        private Label lblGioDi;
        private DateTimePicker dtpGioDi;
        private Label lblGioDen;
        private DateTimePicker dtpGioDen;
        private CheckBox chkT2;
        private CheckBox chkT3;
        private CheckBox chkT4;
        private CheckBox chkT5;
        private CheckBox chkT6;
        private CheckBox chkT7;
        private CheckBox chkCN;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnThem;
        private Button btnSua;
        private Button btnNgung;
        private Button btnSinhChuyen;
        private Button btnXemChuyen;
        private Button btnTaiLai;
        private Button btnDong;
    }
}
