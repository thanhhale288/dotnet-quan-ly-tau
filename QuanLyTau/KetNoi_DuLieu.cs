using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QuanLyTau
{
    /// <summary>
    /// Lớp kết nối SQL Server. Mọi form gọi stored procedure qua đây.
    /// Chuỗi kết nối đọc từ App.config, tên QuanLyTau.
    /// </summary>
    public class KetNoi_DuLieu
    {
        // Fallback khi App.config chưa đọc được.
        // Trong C#: dùng @"..." hoặc viết \\ — KHÔNG viết ".\SQLEXPRESS" trong chuỗi thường.
        private const string ChuoiMacDinh =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyTau;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=15";

        public static string LayChuoiKetNoi()
        {
            try
            {
                ConnectionStringSettings muc = ConfigurationManager.ConnectionStrings["QuanLyTau"];
                if (muc != null && !string.IsNullOrWhiteSpace(muc.ConnectionString))
                    return muc.ConnectionString.Trim();
            }
            catch (ConfigurationErrorsException)
            {
            }

            return ChuoiMacDinh;
        }

        /// <summary>Trả về Data Source đang dùng, để hiện trong thông báo lỗi.</summary>
        public static string LayTenMayChu()
        {
            try
            {
                SqlConnectionStringBuilder bo = new SqlConnectionStringBuilder(LayChuoiKetNoi());
                return bo.DataSource;
            }
            catch
            {
                return "(không đọc được)";
            }
        }

        public static void KiemTraKetNoi()
        {
            using (SqlConnection ketNoi = TaoKetNoi())
            {
                ketNoi.Open();
                using (SqlCommand lenh = new SqlCommand("SELECT DB_NAME()", ketNoi))
                {
                    object tenDb = lenh.ExecuteScalar();
                    if (tenDb == null || !string.Equals(tenDb.ToString(), "QuanLyTau", StringComparison.OrdinalIgnoreCase))
                        throw new InvalidOperationException("Đã kết nối SQL nhưng database hiện tại không phải QuanLyTau.");
                }
            }
        }

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(LayChuoiKetNoi());
        }

        public static SqlParameter ThamSo(string ten, object giaTri)
        {
            return new SqlParameter(ten, giaTri ?? DBNull.Value);
        }

        public static SqlParameter ThamSoGio(string ten, TimeSpan gio)
        {
            SqlParameter thamSo = new SqlParameter(ten, SqlDbType.Time);
            thamSo.Value = gio;
            return thamSo;
        }

        public static object ChuoiHoacNull(string giaTri)
        {
            if (string.IsNullOrWhiteSpace(giaTri))
                return DBNull.Value;
            return giaTri.Trim();
        }

        public static DataTable LayBang(string thuTuc, params SqlParameter[] thamSo)
        {
            using (SqlConnection ketNoi = TaoKetNoi())
            using (SqlCommand lenh = TaoLenh(thuTuc, ketNoi, thamSo))
            using (SqlDataAdapter boDoc = new SqlDataAdapter(lenh))
            {
                DataTable bang = new DataTable();
                boDoc.Fill(bang);
                return bang;
            }
        }

        public static int ThucThi(string thuTuc, params SqlParameter[] thamSo)
        {
            using (SqlConnection ketNoi = TaoKetNoi())
            using (SqlCommand lenh = TaoLenh(thuTuc, ketNoi, thamSo))
            {
                ketNoi.Open();
                return lenh.ExecuteNonQuery();
            }
        }

        public static object LayGiaTri(string thuTuc, params SqlParameter[] thamSo)
        {
            using (SqlConnection ketNoi = TaoKetNoi())
            using (SqlCommand lenh = TaoLenh(thuTuc, ketNoi, thamSo))
            {
                ketNoi.Open();
                object ketQua = lenh.ExecuteScalar();
                if (ketQua == null || ketQua == DBNull.Value)
                    return null;
                return ketQua;
            }
        }

        public static string BamMatKhau(string matKhau)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(matKhau ?? ""));
                StringBuilder chuoi = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                    chuoi.Append(b.ToString("x2"));
                return chuoi.ToString();
            }
        }

        public static void GanLuoi(DataGridView luoi, DataTable bang)
        {
            luoi.ReadOnly = true;
            luoi.AllowUserToAddRows = false;
            luoi.AllowUserToDeleteRows = false;
            luoi.AllowUserToResizeRows = false;
            luoi.MultiSelect = false;
            luoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            luoi.RowHeadersVisible = false;
            luoi.BackgroundColor = Color.White;
            luoi.BorderStyle = BorderStyle.None;
            luoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            luoi.EnableHeadersVisualStyles = false;
            luoi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 76, 129);
            luoi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            luoi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            luoi.ColumnHeadersHeight = 36;
            luoi.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            luoi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 245);
            luoi.DefaultCellStyle.SelectionForeColor = Color.Black;
            luoi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
            luoi.RowTemplate.Height = 30;
            luoi.DataSource = bang;
        }

        public static void DatTieuDe(DataGridView luoi, params string[] maVaTieuDe)
        {
            for (int i = 0; i + 1 < maVaTieuDe.Length; i += 2)
            {
                if (luoi.Columns.Contains(maVaTieuDe[i]))
                    luoi.Columns[maVaTieuDe[i]].HeaderText = maVaTieuDe[i + 1];
            }
        }

        public static void AnCot(DataGridView luoi, params string[] cot)
        {
            foreach (string ten in cot)
            {
                if (luoi.Columns.Contains(ten))
                    luoi.Columns[ten].Visible = false;
            }
        }

        public static void GanCombo(ComboBox combo, DataTable bang, string cotMa, string cotTen)
        {
            combo.DataSource = null;
            combo.DisplayMember = cotTen;
            combo.ValueMember = cotMa;
            combo.DataSource = bang;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static DataTable ThemDongTrong(DataTable nguon, string cotMa, string cotTen, string nhan)
        {
            DataTable bang = nguon.Copy();
            DataRow dong = bang.NewRow();
            if (bang.Columns[cotMa].DataType == typeof(string))
                dong[cotMa] = "";
            else
                dong[cotMa] = 0;
            dong[cotTen] = nhan;
            bang.Rows.InsertAt(dong, 0);
            return bang;
        }

        public static DataTable BangChon(params string[] maVaTen)
        {
            DataTable bang = new DataTable();
            bang.Columns.Add("Ma", typeof(string));
            bang.Columns.Add("Ten", typeof(string));
            for (int i = 0; i + 1 < maVaTen.Length; i += 2)
                bang.Rows.Add(maVaTen[i], maVaTen[i + 1]);
            return bang;
        }

        public static int GiaTriCombo(ComboBox combo)
        {
            if (combo.SelectedValue == null || combo.SelectedValue == DBNull.Value || combo.SelectedValue is DataRowView)
                return 0;
            int so;
            return int.TryParse(combo.SelectedValue.ToString(), out so) ? so : 0;
        }

        public static string GiaTriChuoi(ComboBox combo)
        {
            if (combo.SelectedValue == null || combo.SelectedValue == DBNull.Value || combo.SelectedValue is DataRowView)
                return "";
            return combo.SelectedValue.ToString();
        }

        public static void ChonCombo(ComboBox combo, int ma)
        {
            combo.SelectedValue = ma;
        }

        public static void ChonComboChuoi(ComboBox combo, string ma)
        {
            combo.SelectedValue = ma ?? "";
        }

        public static string Chuoi(DataGridViewRow dong, string cot)
        {
            if (dong == null || dong.DataGridView == null || !dong.DataGridView.Columns.Contains(cot))
                return "";
            object giaTri = dong.Cells[cot].Value;
            if (giaTri == null || giaTri == DBNull.Value)
                return "";
            return giaTri.ToString();
        }

        public static int So(DataGridViewRow dong, string cot)
        {
            int so;
            int.TryParse(Chuoi(dong, cot), out so);
            return so;
        }

        public static decimal Tien(DataGridViewRow dong, string cot)
        {
            if (dong == null || dong.DataGridView == null || !dong.DataGridView.Columns.Contains(cot))
                return 0;
            object giaTri = dong.Cells[cot].Value;
            if (giaTri == null || giaTri == DBNull.Value)
                return 0;
            return Convert.ToDecimal(giaTri);
        }

        public static DateTime Ngay(DataGridViewRow dong, string cot, DateTime macDinh)
        {
            if (dong == null || dong.DataGridView == null || !dong.DataGridView.Columns.Contains(cot))
                return macDinh;
            object giaTri = dong.Cells[cot].Value;
            if (giaTri == null || giaTri == DBNull.Value)
                return macDinh;
            if (giaTri is DateTime)
                return (DateTime)giaTri;
            DateTime ngay;
            return DateTime.TryParse(giaTri.ToString(), out ngay) ? ngay : macDinh;
        }

        private static SqlCommand TaoLenh(string thuTuc, SqlConnection ketNoi, SqlParameter[] thamSo)
        {
            SqlCommand lenh = new SqlCommand(thuTuc, ketNoi);
            lenh.CommandType = CommandType.StoredProcedure;
            lenh.CommandTimeout = 60;
            if (thamSo != null && thamSo.Length > 0)
                lenh.Parameters.AddRange(thamSo);
            return lenh;
        }
    }

    public static class PhienLamViec
    {
        public static int MaNV { get; private set; }
        public static string HoTen { get; private set; }
        public static string ChucVu { get; private set; }
        public static string TenDangNhap { get; private set; }

        public static bool LaQuanLy
        {
            get { return ChucVu == "QuanLy"; }
        }

        public static bool DuocBanVe
        {
            get { return ChucVu == "QuanLy" || ChucVu == "BanVe"; }
        }

        public static bool DuocKyThuat
        {
            get { return ChucVu == "QuanLy" || ChucVu == "KyThuat"; }
        }

        public static bool DuocXemChuyen
        {
            get { return ChucVu == "QuanLy" || ChucVu == "BanVe" || ChucVu == "LaiTau"; }
        }

        public static void DangNhap(DataRow dong)
        {
            MaNV = Convert.ToInt32(dong["MaNV"]);
            HoTen = dong["HoTen"].ToString();
            ChucVu = dong["ChucVu"].ToString();
            TenDangNhap = dong["TenDangNhap"].ToString();
        }

        public static void DangXuat()
        {
            MaNV = 0;
            HoTen = null;
            ChucVu = null;
            TenDangNhap = null;
        }

        public static bool TuChoi(Form form, bool duocVao)
        {
            if (duocVao)
                return false;
            HopThoai.Bao("Bạn không có quyền vào màn hình này.");
            form.BeginInvoke(new Action(form.Close));
            return true;
        }

        public static string TenChucVu(string ma)
        {
            if (ma == "QuanLy") return "Quản lý";
            if (ma == "BanVe") return "Bán vé";
            if (ma == "KyThuat") return "Kỹ thuật";
            if (ma == "LaiTau") return "Lái tàu";
            return ma;
        }
    }

    public static class HopThoai
    {
        public static void Bao(string noiDung)
        {
            MessageBox.Show(noiDung, "Quản lý tàu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Loi(Exception loi)
        {
            MessageBox.Show(loi.Message, "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Hoi(string cauHoi)
        {
            return MessageBox.Show(cauHoi, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static bool Thieu(string giaTri, string nhan)
        {
            if (!string.IsNullOrWhiteSpace(giaTri))
                return false;
            Bao("Nhập " + nhan + ".");
            return true;
        }
    }
}
