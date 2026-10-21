using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmBaoCao
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
            this.lblTuNgay = new Label();
            this.dtpTuNgay = new DateTimePicker();
            this.lblDenNgay = new Label();
            this.dtpDenNgay = new DateTimePicker();
            this.btnXem = new Button();
            this.lblTong = new Label();
            this.btnDong = new Button();
            this.tab = new TabControl();
            this.tabDoanhThu = new TabPage();
            this.dgvDoanhThu = new DataGridView();
            this.tabTuyen = new TabPage();
            this.dgvTuyen = new DataGridView();
            this.tabBaoTri = new TabPage();
            this.dgvBaoTri = new DataGridView();
            this.bangChinh.SuspendLayout();
            this.panelNhap.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            this.tabTuyen.SuspendLayout();
            this.tabBaoTri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoTri)).BeginInit();
            this.SuspendLayout();

            this.lblTieuDe.BackColor = Color.FromArgb(15, 76, 129);
            this.lblTieuDe.Dock = DockStyle.Fill;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "  Báo cáo";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new Point(16, 18);
            this.lblTuNgay.Text = "Từ ngày";
            this.dtpTuNgay.Format = DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new Point(80, 14);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new Size(140, 27);

            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new Point(236, 18);
            this.lblDenNgay.Text = "Đến";
            this.dtpDenNgay.Format = DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new Point(276, 14);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new Size(140, 27);

            this.btnXem.Location = new Point(432, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new Size(100, 32);
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);

            this.lblTong.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTong.Location = new Point(548, 14);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new Size(280, 28);
            this.lblTong.Text = "Tổng doanh thu: 0 đ";

            this.btnDong.Location = new Point(860, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(100, 32);
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.panelNhap.Controls.Add(this.lblTuNgay);
            this.panelNhap.Controls.Add(this.dtpTuNgay);
            this.panelNhap.Controls.Add(this.lblDenNgay);
            this.panelNhap.Controls.Add(this.dtpDenNgay);
            this.panelNhap.Controls.Add(this.btnXem);
            this.panelNhap.Controls.Add(this.lblTong);
            this.panelNhap.Controls.Add(this.btnDong);
            this.panelNhap.Dock = DockStyle.Fill;
            this.panelNhap.Name = "panelNhap";

            this.dgvDoanhThu.Dock = DockStyle.Fill;
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.tabDoanhThu.Controls.Add(this.dgvDoanhThu);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new Padding(8);
            this.tabDoanhThu.Text = "Doanh thu theo ngày";
            this.tabDoanhThu.UseVisualStyleBackColor = true;

            this.dgvTuyen.Dock = DockStyle.Fill;
            this.dgvTuyen.Name = "dgvTuyen";
            this.tabTuyen.Controls.Add(this.dgvTuyen);
            this.tabTuyen.Name = "tabTuyen";
            this.tabTuyen.Padding = new Padding(8);
            this.tabTuyen.Text = "Theo tuyến";
            this.tabTuyen.UseVisualStyleBackColor = true;

            this.dgvBaoTri.Dock = DockStyle.Fill;
            this.dgvBaoTri.Name = "dgvBaoTri";
            this.tabBaoTri.Controls.Add(this.dgvBaoTri);
            this.tabBaoTri.Name = "tabBaoTri";
            this.tabBaoTri.Padding = new Padding(8);
            this.tabBaoTri.Text = "Bảo trì";
            this.tabBaoTri.UseVisualStyleBackColor = true;

            this.tab.Controls.Add(this.tabDoanhThu);
            this.tab.Controls.Add(this.tabTuyen);
            this.tab.Controls.Add(this.tabBaoTri);
            this.tab.Dock = DockStyle.Fill;
            this.tab.Name = "tab";

            this.bangChinh.ColumnCount = 1;
            this.bangChinh.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.bangChinh.Controls.Add(this.lblTieuDe, 0, 0);
            this.bangChinh.Controls.Add(this.panelNhap, 0, 1);
            this.bangChinh.Controls.Add(this.tab, 0, 2);
            this.bangChinh.Dock = DockStyle.Fill;
            this.bangChinh.RowCount = 3;
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            this.ClientSize = new Size(1000, 680);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(900, 560);
            this.Name = "FrmBaoCao";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.FrmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.tabBaoTri.ResumeLayout(false);
            this.tabTuyen.ResumeLayout(false);
            this.tabDoanhThu.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.panelNhap.ResumeLayout(false);
            this.panelNhap.PerformLayout();
            this.bangChinh.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private TableLayoutPanel bangChinh;
        private Label lblTieuDe;
        private Panel panelNhap;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnXem;
        private Label lblTong;
        private Button btnDong;
        private TabControl tab;
        private TabPage tabDoanhThu;
        private DataGridView dgvDoanhThu;
        private TabPage tabTuyen;
        private DataGridView dgvTuyen;
        private TabPage tabBaoTri;
        private DataGridView dgvBaoTri;
    }
}
