using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmTrangChu
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
            this.lblXinChao = new Label();
            this.panelThongKe = new TableLayoutPanel();
            this.lblTauSanSang = new Label();
            this.lblChuyenHomNay = new Label();
            this.lblVeHomNay = new Label();
            this.flowNut = new FlowLayoutPanel();
            this.btnTuyen = new Button();
            this.btnGa = new Button();
            this.btnTau = new Button();
            this.btnLich = new Button();
            this.btnChuyen = new Button();
            this.btnBaoTri = new Button();
            this.btnBanVe = new Button();
            this.btnTraCuu = new Button();
            this.btnHanhKhach = new Button();
            this.btnNhanVien = new Button();
            this.btnBaoCao = new Button();
            this.btnDangXuat = new Button();
            this.bangChinh.SuspendLayout();
            this.panelThongKe.SuspendLayout();
            this.flowNut.SuspendLayout();
            this.SuspendLayout();

            this.lblTieuDe.BackColor = Color.FromArgb(15, 76, 129);
            this.lblTieuDe.Dock = DockStyle.Fill;
            this.lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "  Quản lý tàu điện ngầm";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblXinChao.Dock = DockStyle.Fill;
            this.lblXinChao.Font = new Font("Segoe UI", 12F);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Padding = new Padding(16, 8, 16, 0);
            this.lblXinChao.Text = "Xin chào";
            this.lblXinChao.TextAlign = ContentAlignment.MiddleLeft;

            this.panelThongKe.ColumnCount = 3;
            this.panelThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            this.panelThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            this.panelThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            this.panelThongKe.Controls.Add(this.lblTauSanSang, 0, 0);
            this.panelThongKe.Controls.Add(this.lblChuyenHomNay, 1, 0);
            this.panelThongKe.Controls.Add(this.lblVeHomNay, 2, 0);
            this.panelThongKe.Dock = DockStyle.Fill;
            this.panelThongKe.Name = "panelThongKe";
            this.panelThongKe.RowCount = 1;
            this.panelThongKe.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            this.lblTauSanSang.Dock = DockStyle.Fill;
            this.lblTauSanSang.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTauSanSang.Name = "lblTauSanSang";
            this.lblTauSanSang.Text = "Tàu sẵn sàng: ...";
            this.lblTauSanSang.TextAlign = ContentAlignment.MiddleCenter;

            this.lblChuyenHomNay.Dock = DockStyle.Fill;
            this.lblChuyenHomNay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblChuyenHomNay.Name = "lblChuyenHomNay";
            this.lblChuyenHomNay.Text = "Chuyến hôm nay: ...";
            this.lblChuyenHomNay.TextAlign = ContentAlignment.MiddleCenter;

            this.lblVeHomNay.Dock = DockStyle.Fill;
            this.lblVeHomNay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblVeHomNay.Name = "lblVeHomNay";
            this.lblVeHomNay.Text = "Vé hôm nay: ...";
            this.lblVeHomNay.TextAlign = ContentAlignment.MiddleCenter;

            GanNut(this.btnTuyen, "btnTuyen", "Quản lý tuyến", this.btnTuyen_Click);
            GanNut(this.btnGa, "btnGa", "Quản lý ga", this.btnGa_Click);
            GanNut(this.btnTau, "btnTau", "Quản lý tàu", this.btnTau_Click);
            GanNut(this.btnLich, "btnLich", "Lịch trình", this.btnLich_Click);
            GanNut(this.btnChuyen, "btnChuyen", "Chuyến tàu", this.btnChuyen_Click);
            GanNut(this.btnBaoTri, "btnBaoTri", "Bảo trì", this.btnBaoTri_Click);
            GanNut(this.btnBanVe, "btnBanVe", "Bán vé", this.btnBanVe_Click);
            GanNut(this.btnTraCuu, "btnTraCuu", "Tra cứu vé", this.btnTraCuu_Click);
            GanNut(this.btnHanhKhach, "btnHanhKhach", "Hành khách", this.btnHanhKhach_Click);
            GanNut(this.btnNhanVien, "btnNhanVien", "Nhân viên", this.btnNhanVien_Click);
            GanNut(this.btnBaoCao, "btnBaoCao", "Báo cáo", this.btnBaoCao_Click);

            this.flowNut.AutoScroll = true;
            this.flowNut.Controls.Add(this.btnTuyen);
            this.flowNut.Controls.Add(this.btnGa);
            this.flowNut.Controls.Add(this.btnTau);
            this.flowNut.Controls.Add(this.btnLich);
            this.flowNut.Controls.Add(this.btnChuyen);
            this.flowNut.Controls.Add(this.btnBaoTri);
            this.flowNut.Controls.Add(this.btnBanVe);
            this.flowNut.Controls.Add(this.btnTraCuu);
            this.flowNut.Controls.Add(this.btnHanhKhach);
            this.flowNut.Controls.Add(this.btnNhanVien);
            this.flowNut.Controls.Add(this.btnBaoCao);
            this.flowNut.Dock = DockStyle.Fill;
            this.flowNut.Name = "flowNut";
            this.flowNut.Padding = new Padding(16);

            this.btnDangXuat.Dock = DockStyle.Fill;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);

            this.bangChinh.ColumnCount = 1;
            this.bangChinh.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.bangChinh.Controls.Add(this.lblTieuDe, 0, 0);
            this.bangChinh.Controls.Add(this.lblXinChao, 0, 1);
            this.bangChinh.Controls.Add(this.panelThongKe, 0, 2);
            this.bangChinh.Controls.Add(this.flowNut, 0, 3);
            this.bangChinh.Controls.Add(this.btnDangXuat, 0, 4);
            this.bangChinh.Dock = DockStyle.Fill;
            this.bangChinh.Name = "bangChinh";
            this.bangChinh.RowCount = 5;
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));

            this.ClientSize = new Size(960, 640);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(800, 560);
            this.Name = "FrmTrangChu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.FrmTrangChu_Load);
            this.flowNut.ResumeLayout(false);
            this.panelThongKe.ResumeLayout(false);
            this.bangChinh.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void GanNut(Button nut, string ten, string chu, System.EventHandler suKien)
        {
            nut.BackColor = Color.FromArgb(15, 76, 129);
            nut.FlatStyle = FlatStyle.Flat;
            nut.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            nut.ForeColor = Color.White;
            nut.Margin = new Padding(8);
            nut.Name = ten;
            nut.Size = new Size(280, 52);
            nut.Text = chu;
            nut.UseVisualStyleBackColor = false;
            nut.Click += suKien;
        }

        private TableLayoutPanel bangChinh;
        private Label lblTieuDe;
        private Label lblXinChao;
        private TableLayoutPanel panelThongKe;
        private Label lblTauSanSang;
        private Label lblChuyenHomNay;
        private Label lblVeHomNay;
        private FlowLayoutPanel flowNut;
        private Button btnTuyen;
        private Button btnGa;
        private Button btnTau;
        private Button btnLich;
        private Button btnChuyen;
        private Button btnBaoTri;
        private Button btnBanVe;
        private Button btnTraCuu;
        private Button btnHanhKhach;
        private Button btnNhanVien;
        private Button btnBaoCao;
        private Button btnDangXuat;
    }
}
