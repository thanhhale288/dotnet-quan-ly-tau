using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmHanhKhach
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
            this.lblTim = new Label();
            this.txtTim = new TextBox();
            this.btnTim = new Button();
            this.dgvKhach = new DataGridView();
            this.dgvVe = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnXemVe = new Button();
            this.btnDong = new Button();
            this.bangChinh.SuspendLayout();
            this.panelNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.panelNut.SuspendLayout();
            this.SuspendLayout();

            this.lblTieuDe.BackColor = Color.FromArgb(15, 76, 129);
            this.lblTieuDe.Dock = DockStyle.Fill;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "  Hành khách";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblTim.AutoSize = true;
            this.lblTim.Location = new Point(16, 18);
            this.lblTim.Text = "Tên hoặc CCCD";
            this.txtTim.Location = new Point(150, 14);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new Size(260, 27);
            this.btnTim.Location = new Point(424, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new Size(100, 32);
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            this.panelNhap.Controls.Add(this.lblTim);
            this.panelNhap.Controls.Add(this.txtTim);
            this.panelNhap.Controls.Add(this.btnTim);
            this.panelNhap.Dock = DockStyle.Fill;
            this.panelNhap.Name = "panelNhap";

            this.dgvKhach.Dock = DockStyle.Fill;
            this.dgvKhach.Name = "dgvKhach";
            this.dgvKhach.CellClick += new DataGridViewCellEventHandler(this.dgvKhach_CellClick);
            this.dgvKhach.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvKhach_DataBindingComplete);

            this.dgvVe.Dock = DockStyle.Fill;
            this.dgvVe.Name = "dgvVe";

            this.panelNut.Dock = DockStyle.Fill;
            this.panelNut.Padding = new Padding(8, 10, 8, 8);
            this.panelNut.WrapContents = false;
            this.btnXemVe.Margin = new Padding(6);
            this.btnXemVe.Name = "btnXemVe";
            this.btnXemVe.Size = new Size(160, 36);
            this.btnXemVe.Text = "Mở tra cứu vé";
            this.btnXemVe.Click += new System.EventHandler(this.btnXemVe_Click);
            this.btnDong.Margin = new Padding(6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(120, 36);
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnXemVe);
            this.panelNut.Controls.Add(this.btnDong);

            this.bangChinh.ColumnCount = 1;
            this.bangChinh.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.bangChinh.Controls.Add(this.lblTieuDe, 0, 0);
            this.bangChinh.Controls.Add(this.panelNhap, 0, 1);
            this.bangChinh.Controls.Add(this.dgvKhach, 0, 2);
            this.bangChinh.Controls.Add(this.dgvVe, 0, 3);
            this.bangChinh.Controls.Add(this.panelNut, 0, 4);
            this.bangChinh.Dock = DockStyle.Fill;
            this.bangChinh.RowCount = 5;
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            this.bangChinh.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));

            this.ClientSize = new Size(1000, 680);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(900, 600);
            this.Name = "FrmHanhKhach";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hành khách";
            this.Load += new System.EventHandler(this.FrmHanhKhach_Load);
            this.panelNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).EndInit();
            this.panelNhap.ResumeLayout(false);
            this.panelNhap.PerformLayout();
            this.bangChinh.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private TableLayoutPanel bangChinh;
        private Label lblTieuDe;
        private Panel panelNhap;
        private Label lblTim;
        private TextBox txtTim;
        private Button btnTim;
        private DataGridView dgvKhach;
        private DataGridView dgvVe;
        private FlowLayoutPanel panelNut;
        private Button btnXemVe;
        private Button btnDong;
    }
}
