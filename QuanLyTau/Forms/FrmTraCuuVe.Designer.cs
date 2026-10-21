using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmTraCuuVe
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
            this.lblMaVe = new Label();
            this.txtMaVe = new TextBox();
            this.lblCCCD = new Label();
            this.txtCCCD = new TextBox();
            this.lblNgay = new Label();
            this.dtpNgay = new DateTimePicker();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnTim = new Button();
            this.btnHuy = new Button();
            this.btnHanhKhach = new Button();
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
            this.lblTieuDe.Text = "  Tra cứu vé";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblMaVe.AutoSize = true;
            this.lblMaVe.Location = new Point(16, 12);
            this.lblMaVe.Text = "Mã vé";
            this.txtMaVe.Location = new Point(16, 36);
            this.txtMaVe.Name = "txtMaVe";
            this.txtMaVe.Size = new Size(120, 27);

            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new Point(156, 12);
            this.lblCCCD.Text = "CCCD";
            this.txtCCCD.Location = new Point(156, 36);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new Size(180, 27);

            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new Point(356, 12);
            this.lblNgay.Text = "Ngày chạy";
            this.dtpNgay.Format = DateTimePickerFormat.Short;
            this.dtpNgay.Location = new Point(356, 36);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.ShowCheckBox = true;
            this.dtpNgay.Size = new Size(160, 27);

            this.panelNhap.Controls.Add(this.lblMaVe);
            this.panelNhap.Controls.Add(this.txtMaVe);
            this.panelNhap.Controls.Add(this.lblCCCD);
            this.panelNhap.Controls.Add(this.txtCCCD);
            this.panelNhap.Controls.Add(this.lblNgay);
            this.panelNhap.Controls.Add(this.dtpNgay);
            this.panelNhap.Dock = DockStyle.Fill;
            this.panelNhap.Name = "panelNhap";

            this.dgv.Dock = DockStyle.Fill;
            this.dgv.Name = "dgv";

            this.panelNut.Dock = DockStyle.Fill;
            this.panelNut.Padding = new Padding(8, 10, 8, 8);
            this.panelNut.WrapContents = false;
            GanNut(this.btnTim, "btnTim", "Tìm", this.btnTim_Click);
            GanNut(this.btnHuy, "btnHuy", "Hủy vé", this.btnHuy_Click);
            GanNut(this.btnHanhKhach, "btnHanhKhach", "Hành khách", this.btnHanhKhach_Click);
            this.btnHanhKhach.Size = new Size(140, 36);
            GanNut(this.btnDong, "btnDong", "Đóng", this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnTim);
            this.panelNut.Controls.Add(this.btnHuy);
            this.panelNut.Controls.Add(this.btnHanhKhach);
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
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));

            this.ClientSize = new Size(1000, 640);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(900, 560);
            this.Name = "FrmTraCuuVe";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Tra cứu vé";
            this.Load += new System.EventHandler(this.FrmTraCuuVe_Load);
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
        private Label lblMaVe;
        private TextBox txtMaVe;
        private Label lblCCCD;
        private TextBox txtCCCD;
        private Label lblNgay;
        private DateTimePicker dtpNgay;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnTim;
        private Button btnHuy;
        private Button btnHanhKhach;
        private Button btnDong;
    }
}
