using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmQuanLyTuyen
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
            this.lblTenTuyen = new Label();
            this.txtTenTuyen = new TextBox();
            this.lblTrangThai = new Label();
            this.cboTrangThai = new ComboBox();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnNgung = new Button();
            this.btnChiTiet = new Button();
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
            this.lblTieuDe.Text = "  Quản lý tuyến";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblTenTuyen.AutoSize = true;
            this.lblTenTuyen.Location = new Point(16, 12);
            this.lblTenTuyen.Name = "lblTenTuyen";
            this.lblTenTuyen.Text = "Tên tuyến";
            this.txtTenTuyen.Location = new Point(16, 36);
            this.txtTenTuyen.Name = "txtTenTuyen";
            this.txtTenTuyen.Size = new Size(280, 27);

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new Point(320, 12);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Trạng thái";
            this.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location = new Point(320, 36);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new Size(180, 28);

            this.panelNhap.Controls.Add(this.lblTenTuyen);
            this.panelNhap.Controls.Add(this.txtTenTuyen);
            this.panelNhap.Controls.Add(this.lblTrangThai);
            this.panelNhap.Controls.Add(this.cboTrangThai);
            this.panelNhap.Dock = DockStyle.Fill;
            this.panelNhap.Name = "panelNhap";

            this.dgv.Dock = DockStyle.Fill;
            this.dgv.Name = "dgv";
            this.dgv.CellClick += new DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);

            this.panelNut.Dock = DockStyle.Fill;
            this.panelNut.Name = "panelNut";
            this.panelNut.Padding = new Padding(8, 10, 8, 8);
            this.panelNut.WrapContents = false;
            GanNut(this.btnThem, "btnThem", "Thêm", this.btnThem_Click);
            GanNut(this.btnSua, "btnSua", "Sửa", this.btnSua_Click);
            GanNut(this.btnNgung, "btnNgung", "Ngừng", this.btnNgung_Click);
            GanNut(this.btnChiTiet, "btnChiTiet", "Chi tiết ga", this.btnChiTiet_Click);
            GanNut(this.btnTaiLai, "btnTaiLai", "Tải lại", this.btnTaiLai_Click);
            GanNut(this.btnDong, "btnDong", "Đóng", this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnThem);
            this.panelNut.Controls.Add(this.btnSua);
            this.panelNut.Controls.Add(this.btnNgung);
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
            this.bangChinh.Name = "bangChinh";
            this.bangChinh.RowCount = 4;
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));

            this.ClientSize = new Size(1000, 640);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(900, 560);
            this.Name = "FrmQuanLyTuyen";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý tuyến";
            this.Load += new System.EventHandler(this.FrmQuanLyTuyen_Load);
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
        private Label lblTenTuyen;
        private TextBox txtTenTuyen;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnThem;
        private Button btnSua;
        private Button btnNgung;
        private Button btnChiTiet;
        private Button btnTaiLai;
        private Button btnDong;
    }
}
