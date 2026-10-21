using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTau
{
    partial class FrmChiTietTuyen
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
            this.lblGa = new Label();
            this.cboGa = new ComboBox();
            this.lblThuTu = new Label();
            this.numThuTu = new NumericUpDown();
            this.lblPhut = new Label();
            this.numPhut = new NumericUpDown();
            this.dgv = new DataGridView();
            this.panelNut = new FlowLayoutPanel();
            this.btnThemGa = new Button();
            this.btnXoaGa = new Button();
            this.btnQuanLyGa = new Button();
            this.btnDong = new Button();
            this.bangChinh.SuspendLayout();
            this.panelNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panelNut.SuspendLayout();
            this.SuspendLayout();

            this.lblTieuDe.BackColor = Color.FromArgb(15, 76, 129);
            this.lblTieuDe.Dock = DockStyle.Fill;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "  Chi tiết tuyến";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;

            this.lblGa.AutoSize = true;
            this.lblGa.Location = new Point(16, 12);
            this.lblGa.Name = "lblGa";
            this.lblGa.Text = "Ga";
            this.cboGa.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGa.Location = new Point(16, 36);
            this.cboGa.Name = "cboGa";
            this.cboGa.Size = new Size(280, 28);

            this.lblThuTu.AutoSize = true;
            this.lblThuTu.Location = new Point(316, 12);
            this.lblThuTu.Name = "lblThuTu";
            this.lblThuTu.Text = "Thứ tự";
            this.numThuTu.Location = new Point(316, 36);
            this.numThuTu.Maximum = 50;
            this.numThuTu.Minimum = 1;
            this.numThuTu.Name = "numThuTu";
            this.numThuTu.Size = new Size(80, 27);
            this.numThuTu.Value = 1;

            this.lblPhut.AutoSize = true;
            this.lblPhut.Location = new Point(420, 12);
            this.lblPhut.Name = "lblPhut";
            this.lblPhut.Text = "Phút dừng";
            this.numPhut.Location = new Point(420, 36);
            this.numPhut.Maximum = 30;
            this.numPhut.Name = "numPhut";
            this.numPhut.Size = new Size(80, 27);
            this.numPhut.Value = 1;

            this.panelNhap.Controls.Add(this.lblGa);
            this.panelNhap.Controls.Add(this.cboGa);
            this.panelNhap.Controls.Add(this.lblThuTu);
            this.panelNhap.Controls.Add(this.numThuTu);
            this.panelNhap.Controls.Add(this.lblPhut);
            this.panelNhap.Controls.Add(this.numPhut);
            this.panelNhap.Dock = DockStyle.Fill;
            this.panelNhap.Name = "panelNhap";

            this.dgv.Dock = DockStyle.Fill;
            this.dgv.Name = "dgv";
            this.dgv.CellClick += new DataGridViewCellEventHandler(this.dgv_CellClick);

            this.panelNut.Dock = DockStyle.Fill;
            this.panelNut.Name = "panelNut";
            this.panelNut.Padding = new Padding(8, 10, 8, 8);
            this.panelNut.WrapContents = false;
            GanNut(this.btnThemGa, "btnThemGa", "Thêm ga", this.btnThemGa_Click);
            GanNut(this.btnXoaGa, "btnXoaGa", "Gỡ ga", this.btnXoaGa_Click);
            GanNut(this.btnQuanLyGa, "btnQuanLyGa", "Mở danh sách ga", this.btnQuanLyGa_Click);
            this.btnQuanLyGa.Size = new Size(160, 36);
            GanNut(this.btnDong, "btnDong", "Đóng", this.btnDong_Click);
            this.panelNut.Controls.Add(this.btnThemGa);
            this.panelNut.Controls.Add(this.btnXoaGa);
            this.panelNut.Controls.Add(this.btnQuanLyGa);
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

            this.ClientSize = new Size(900, 600);
            this.Controls.Add(this.bangChinh);
            this.Font = new Font("Segoe UI", 10F);
            this.MinimumSize = new Size(800, 520);
            this.Name = "FrmChiTietTuyen";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Chi tiết tuyến";
            this.Load += new System.EventHandler(this.FrmChiTietTuyen_Load);
            this.panelNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTu)).EndInit();
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
        private Label lblGa;
        private ComboBox cboGa;
        private Label lblThuTu;
        private NumericUpDown numThuTu;
        private Label lblPhut;
        private NumericUpDown numPhut;
        private DataGridView dgv;
        private FlowLayoutPanel panelNut;
        private Button btnThemGa;
        private Button btnXoaGa;
        private Button btnQuanLyGa;
        private Button btnDong;
    }
}
