using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmQuanLyGa
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
            this.lblTenGa = new Label();
            this.txtTenGa = new TextBox();
            this.lblDiaChi = new Label();
            this.txtDiaChi = new TextBox();
            this.lblKhuVuc = new Label();
            this.txtKhuVuc = new TextBox();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnNgung = new Button();
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
            this.lblTieuDe.Text = "  Quản lý ga";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblTenGa.AutoSize = true;
            this.lblTenGa.Location = new Point(16, 12);
            this.lblTenGa.Name = "lblTenGa";
            this.lblTenGa.Text = "Tên ga";
            this.txtTenGa.Location = new Point(16, 36);
            this.txtTenGa.Name = "txtTenGa";
            this.txtTenGa.Size = new Size(220, 27);

            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new Point(256, 12);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Text = "Địa chỉ";
            this.txtDiaChi.Location = new Point(256, 36);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new Size(280, 27);

            this.lblKhuVuc.AutoSize = true;
            this.lblKhuVuc.Location = new Point(556, 12);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Text = "Khu vực";
            this.txtKhuVuc.Location = new Point(556, 36);
            this.txtKhuVuc.Name = "txtKhuVuc";
            this.txtKhuVuc.Size = new Size(180, 27);

            this.panelNhap.Controls.Add(this.lblTenGa);
            this.panelNhap.Controls.Add(this.txtTenGa);
            this.panelNhap.Controls.Add(this.lblDiaChi);
            this.panelNhap.Controls.Add(this.txtDiaChi);
            this.panelNhap.Controls.Add(this.lblKhuVuc);
            this.panelNhap.Controls.Add(this.txtKhuVuc);
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
            GanNut(this.btnNgung, "btnNgung", "Ngừng dùng", this.btnNgung_Click);
            GanNut(this.btnTaiLai, "btnTaiLai", "Tải lại", this.btnTaiLai_Click);
            GanNut(this.btnDong, "btnDong", "Đóng", this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnThem);
            this.panelNut.Controls.Add(this.btnSua);
            this.panelNut.Controls.Add(this.btnNgung);
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
            this.Name = "FrmQuanLyGa";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý ga";
            this.Load += new System.EventHandler(this.FrmQuanLyGa_Load);
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
        private Label lblTenGa;
        private TextBox txtTenGa;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblKhuVuc;
        private TextBox txtKhuVuc;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnThem;
        private Button btnSua;
        private Button btnNgung;
        private Button btnTaiLai;
        private Button btnDong;
    }
}
