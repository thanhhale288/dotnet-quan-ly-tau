using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmChiTietTuyen : Form
    {
        private readonly int _maTuyen;

        public FrmChiTietTuyen()
            : this(0)
        {
        }

        public FrmChiTietTuyen(int maTuyen)
        {
            _maTuyen = maTuyen;
            InitializeComponent();
        }

        private void FrmChiTietTuyen_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.LaQuanLy))
                return;
            if (_maTuyen <= 0)
            {
                HopThoai.Bao("Chọn một tuyến trước.");
                BeginInvoke(new Action(Close));
                return;
            }

            try
            {
                DataTable tuyen = KetNoi_DuLieu.LayBang("sp_Tuyen_Select", KetNoi_DuLieu.ThamSo("@MaTuyen", _maTuyen));
                if (tuyen.Rows.Count == 0)
                {
                    HopThoai.Bao("Không tìm thấy tuyến.");
                    BeginInvoke(new Action(Close));
                    return;
                }
                DataRow dong = tuyen.Rows[0];
                lblTieuDe.Text = "  " + dong["TenTuyen"] + "  ·  " + dong["TenTrangThai"];
                Text = dong["TenTuyen"].ToString();
                NapGa();
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void NapGa()
        {
            DataTable ga = KetNoi_DuLieu.LayBang("sp_Ga_Select", KetNoi_DuLieu.ThamSo("@ChiHoatDong", true));
            KetNoi_DuLieu.GanCombo(cboGa, ga, "MaGa", "TenGa");
        }

        private void TaiLai()
        {
            KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang("sp_TuyenGa_Select", KetNoi_DuLieu.ThamSo("@MaTuyen", _maTuyen)));
            KetNoi_DuLieu.DatTieuDe(dgv,
                "ThuTu", "Thứ tự",
                "MaGa", "Mã ga",
                "TenGa", "Tên ga",
                "PhutDung", "Phút dừng",
                "KhuVuc", "Khu vực");
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv.CurrentRow == null)
                return;
            KetNoi_DuLieu.ChonCombo(cboGa, KetNoi_DuLieu.So(dgv.CurrentRow, "MaGa"));
            numThuTu.Value = Math.Max(1, KetNoi_DuLieu.So(dgv.CurrentRow, "ThuTu"));
            numPhut.Value = Math.Max(0, KetNoi_DuLieu.So(dgv.CurrentRow, "PhutDung"));
        }

        private void btnThemGa_Click(object sender, EventArgs e)
        {
            int maGa = KetNoi_DuLieu.GiaTriCombo(cboGa);
            if (maGa == 0)
            {
                HopThoai.Bao("Chọn ga.");
                return;
            }
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_TuyenGa_Them",
                    KetNoi_DuLieu.ThamSo("@MaTuyen", _maTuyen),
                    KetNoi_DuLieu.ThamSo("@MaGa", maGa),
                    KetNoi_DuLieu.ThamSo("@ThuTu", Convert.ToInt32(numThuTu.Value)),
                    KetNoi_DuLieu.ThamSo("@PhutDung", Convert.ToInt32(numPhut.Value)));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnXoaGa_Click(object sender, EventArgs e)
        {
            int maGa = KetNoi_DuLieu.So(dgv.CurrentRow, "MaGa");
            if (maGa == 0)
            {
                HopThoai.Bao("Chọn ga trên tuyến.");
                return;
            }
            if (!HopThoai.Hoi("Gỡ ga này khỏi tuyến?"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_TuyenGa_Xoa",
                    KetNoi_DuLieu.ThamSo("@MaTuyen", _maTuyen),
                    KetNoi_DuLieu.ThamSo("@MaGa", maGa));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnQuanLyGa_Click(object sender, EventArgs e)
        {
            using (FrmQuanLyGa ga = new FrmQuanLyGa())
                ga.ShowDialog(this);
            try
            {
                NapGa();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
