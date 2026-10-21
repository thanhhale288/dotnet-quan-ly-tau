using System;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmQuanLyGa : Form
    {
        public FrmQuanLyGa()
        {
            InitializeComponent();
        }

        private void FrmQuanLyGa_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.LaQuanLy))
                return;
            TaiLai();
        }

        private void TaiLai()
        {
            try
            {
                KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang("sp_Ga_Select"));
                KetNoi_DuLieu.DatTieuDe(dgv,
                    "MaGa", "Mã ga",
                    "TenGa", "Tên ga",
                    "DiaChi", "Địa chỉ",
                    "KhuVuc", "Khu vực",
                    "TenTrangThai", "Trạng thái");
                KetNoi_DuLieu.AnCot(dgv, "TrangThai");
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
            txtTenGa.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "TenGa");
            txtDiaChi.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "DiaChi");
            txtKhuVuc.Text = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "KhuVuc");
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
            if (HopThoai.Thieu(txtTenGa.Text, "tên ga"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_Ga_Them",
                    KetNoi_DuLieu.ThamSo("@TenGa", txtTenGa.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@DiaChi", KetNoi_DuLieu.ChuoiHoacNull(txtDiaChi.Text)),
                    KetNoi_DuLieu.ThamSo("@KhuVuc", KetNoi_DuLieu.ChuoiHoacNull(txtKhuVuc.Text)));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaGa");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một ga.");
                return;
            }
            if (HopThoai.Thieu(txtTenGa.Text, "tên ga"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_Ga_Sua",
                    KetNoi_DuLieu.ThamSo("@MaGa", ma),
                    KetNoi_DuLieu.ThamSo("@TenGa", txtTenGa.Text.Trim()),
                    KetNoi_DuLieu.ThamSo("@DiaChi", KetNoi_DuLieu.ChuoiHoacNull(txtDiaChi.Text)),
                    KetNoi_DuLieu.ThamSo("@KhuVuc", KetNoi_DuLieu.ChuoiHoacNull(txtKhuVuc.Text)));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnNgung_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaGa");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một ga.");
                return;
            }
            if (!HopThoai.Hoi("Ngừng sử dụng ga này?"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi("sp_Ga_Ngung", KetNoi_DuLieu.ThamSo("@MaGa", ma));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
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
