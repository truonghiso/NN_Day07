using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NN_Day07.Models
{
    public class HocVien
    {
        [DisplayName("Mã Học Viên")]
        public int MaSo { get; set; }

        [DisplayName("Tên Học Viên")]
        public string TenHocVien { get; set; }

        [DisplayName("Phone Học Viên")]
        public string Phone { get; set; }

        [DisplayName("Điểm TB Học Viên")]
        public double DiemTrungBinh { get; set; }

        [DisplayName("Giới Tính Học Viên")]
        public bool GioiTinh { get; set; }
    }
}
