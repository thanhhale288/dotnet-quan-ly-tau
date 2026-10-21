using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyTau
{
    public partial class FrmLichTrinh : Form
    {
        public FrmLichTrinh()
        {
            InitializeComponent();
        }

        private void FrmLichTrinh_Load(object sender, EventArgs e)
        {
            if (PhienLamViec.TuChoi(this, PhienLamViec.LaQuanLy))
                return;
            try
            {
                KetNoi_DuLieu.GanCombo(cboTuyen, KetNoi_DuLieu.LayBang("sp_Tuyen_Select"), "MaTuyen", "TenTuyen");
                KetNoi_DuLieu.GanCombo(cboTau, KetNoi_DuLieu.LayBang("sp_Tau_Select", KetNoi_DuLieu.ThamSo("@MaTuyen", 0), KetNoi_DuLieu.ThamSo("@TrangThai", ""), KetNoi_DuLieu.ThamSo("@MaTau", 0)), "MaTau", "TenTau");
                dtpTuNgay.Value = DateTime.Today;
                dtpDenNgay.Value = DateTime.Today.AddDays(6);
                chkT2.Checked = true;
                chkT3.Checked = true;
                chkT4.Checked = true;
                chkT5.Checked = true;
                chkT6.Checked = true;
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void TaiLai()
        {
            try
            {
                KetNoi_DuLieu.GanLuoi(dgv, KetNoi_DuLieu.LayBang("sp_Lich_Select"));
                KetNoi_DuLieu.DatTieuDe(dgv,
                    "MaLich", "Mã lịch",
                    "TenTuyen", "Tuyến",
                    "TenTau", "Tàu",
                    "GioDi", "Giờ đi",
                    "GioDen", "Giờ đến",
                    "ThuTrongTuan", "Thứ",
                    "TenTrangThai", "Trạng thái");
                KetNoi_DuLieu.AnCot(dgv, "TrangThai", "MaTuyen", "MaTau");
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
            KetNoi_DuLieu.ChonCombo(cboTuyen, KetNoi_DuLieu.So(dgv.CurrentRow, "MaTuyen"));
            KetNoi_DuLieu.ChonCombo(cboTau, KetNoi_DuLieu.So(dgv.CurrentRow, "MaTau"));
            GanGio(dtpGioDi, KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "GioDi"));
            GanGio(dtpGioDen, KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "GioDen"));
            string thu = KetNoi_DuLieu.Chuoi(dgv.CurrentRow, "ThuTrongTuan");
            chkT2.Checked = thu.Contains("T2");
            chkT3.Checked = thu.Contains("T3");
            chkT4.Checked = thu.Contains("T4");
            chkT5.Checked = thu.Contains("T5");
            chkT6.Checked = thu.Contains("T6");
            chkT7.Checked = thu.Contains("T7");
            chkCN.Checked = thu.Contains("CN");
        }

        private static void GanGio(DateTimePicker dtp, string gio)
        {
            TimeSpan ts;
            if (TimeSpan.TryParse(gio, out ts))
                dtp.Value = DateTime.Today.Add(ts);
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

        private string LayThu()
        {
            List<string> ds = new List<string>();
            if (chkT2.Checked) ds.Add("T2");
            if (chkT3.Checked) ds.Add("T3");
            if (chkT4.Checked) ds.Add("T4");
            if (chkT5.Checked) ds.Add("T5");
            if (chkT6.Checked) ds.Add("T6");
            if (chkT7.Checked) ds.Add("T7");
            if (chkCN.Checked) ds.Add("CN");
            return string.Join(",", ds.ToArray());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string thu = LayThu();
            if (thu.Length == 0)
            {
                HopThoai.Bao("Chọn ít nhất một thứ trong tuần.");
                return;
            }
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_Lich_Them",
                    KetNoi_DuLieu.ThamSo("@MaTuyen", KetNoi_DuLieu.GiaTriCombo(cboTuyen)),
                    KetNoi_DuLieu.ThamSo("@MaTau", KetNoi_DuLieu.GiaTriCombo(cboTau)),
                    KetNoi_DuLieu.ThamSoGio("@GioDi", dtpGioDi.Value.TimeOfDay),
                    KetNoi_DuLieu.ThamSoGio("@GioDen", dtpGioDen.Value.TimeOfDay),
                    KetNoi_DuLieu.ThamSo("@ThuTrongTuan", thu));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaLich");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một lịch.");
                return;
            }
            string thu = LayThu();
            if (thu.Length == 0)
            {
                HopThoai.Bao("Chọn ít nhất một thứ trong tuần.");
                return;
            }
            try
            {
                KetNoi_DuLieu.ThucThi(
                    "sp_Lich_Sua",
                    KetNoi_DuLieu.ThamSo("@MaLich", ma),
                    KetNoi_DuLieu.ThamSo("@MaTuyen", KetNoi_DuLieu.GiaTriCombo(cboTuyen)),
                    KetNoi_DuLieu.ThamSo("@MaTau", KetNoi_DuLieu.GiaTriCombo(cboTau)),
                    KetNoi_DuLieu.ThamSoGio("@GioDi", dtpGioDi.Value.TimeOfDay),
                    KetNoi_DuLieu.ThamSoGio("@GioDen", dtpGioDen.Value.TimeOfDay),
                    KetNoi_DuLieu.ThamSo("@ThuTrongTuan", thu),
                    KetNoi_DuLieu.ThamSo("@TrangThai", "HoatDong"));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnNgung_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaLich");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một lịch.");
                return;
            }
            if (!HopThoai.Hoi("Ngừng lịch trình này?"))
                return;
            try
            {
                KetNoi_DuLieu.ThucThi("sp_Lich_Ngung", KetNoi_DuLieu.ThamSo("@MaLich", ma));
                TaiLai();
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnSinhChuyen_Click(object sender, EventArgs e)
        {
            int ma = KetNoi_DuLieu.So(dgv.CurrentRow, "MaLich");
            if (ma == 0)
            {
                HopThoai.Bao("Chọn một lịch để sinh chuyến.");
                return;
            }
            try
            {
                object so = KetNoi_DuLieu.LayGiaTri(
                    "sp_SinhChuyen",
                    KetNoi_DuLieu.ThamSo("@MaLich", ma),
                    KetNoi_DuLieu.ThamSo("@TuNgay", dtpTuNgay.Value.Date),
                    KetNoi_DuLieu.ThamSo("@DenNgay", dtpDenNgay.Value.Date));
                HopThoai.Bao("Đã tạo " + (so ?? 0) + " chuyến mới.");
                if (HopThoai.Hoi("Mở danh sách chuyến hôm nay?"))
                {
                    using (FrmChuyenTau chuyen = new FrmChuyenTau())
                        chuyen.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                HopThoai.Loi(ex);
            }
        }

        private void btnXemChuyen_Click(object sender, EventArgs e)
        {
            using (FrmChuyenTau chuyen = new FrmChuyenTau())
                chuyen.ShowDialog(this);
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
