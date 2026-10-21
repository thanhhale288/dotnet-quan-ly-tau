using System;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmQuanLyTuyen : Form
    {
        public FrmQuanLyTuyen()
        {
            InitializeComponent();
        }

        private void FrmQuanLyTuyen_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.LaQuanLy))
                return;
            KetNoi_DuLieu.GanCombo(
                cboTrangThai,
                KetNoi_DuLieu.BangChon("HoatDong", "Hoạt động", "Ngung", "Ngừng"),
                "Ma",
                "Ten");
            TaiLai();
        }

        private void TaiLai()
        {
            try
            {
                KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang("sp_Tuyen_Select"));
                KetNoi_DuLieu.DatTieuDe(dgv,
                    "MaTuyen", "Mã tuyến",
                    "TenTuyen", "Tên tuyến",
                    "GaDau", "Ga đầu",
                    "GaCuoi", "Ga cuối",
                    "TenTrangThai", "Trạng thái",
                    "SoGa", "Số ga");
                KetNoi_DuLieu.AnCot(dgv, "TrangThai", "MaGaDau", "MaGaCuoi");
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void NapDong()
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.IsNewRow)
                return;
            txtTenTuyen.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "TenTuyen");
            KetNoi_DuLieu.ChonComboChuoi(cboTrangThai, KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "TrangThai"));
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                NapDong();
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            NapDong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (HopThoai.Thieu(txtTenTuyen.Text, "tên tuyến"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi("sp_Tuyen_Them", KetNoi_DuLieu.ThamSo("@TenTuyen", txtTenTuyen.Text.Trim()));
                TaiLai();
                HopThoai.Bao("Đã thêm tuyến. Mở Chi tiết để gắn ga theo thứ tự.");
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaTuyen");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một tuyến.");
                return;
            }
            if (HopThoai.Thieu(txtTenTuyen.Text, "tên tuyến"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_Tuyen_Sua",
                    KetNoi_DuLieu.ThamSo("@MaTuyen", ma),
                    KetNoi_DuLieu.ThamSo("@TenTuyen", txtTenTuyen.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@TrangThai", KetNoi_DuLieu.GiaTriChuoi(cboTrangThai)));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnNgung_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaTuyen");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một tuyến.");
                return;
            }
            if (!HopThoai.Hoi("Ngừng tuyến này và các lịch đang hoạt động của tuyến?"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi("sp_Tuyen_Ngung", KetNoi_DuLieu.ThamSo("@MaTuyen", ma));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaTuyen");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một tuyến.");
                return;
            }
            using (FrmChiTietTuyen chiTiet = new FrmChiTietTuyen(ma))
                chiTiet.ShowDialog(this);
            TaiLai();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
