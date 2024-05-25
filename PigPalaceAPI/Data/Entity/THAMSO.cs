﻿using System.ComponentModel.DataAnnotations;

namespace PigPalaceAPI.Data.Entity
{
    public class THAMSO
    {
        [Key]
        public int ID { get; set; }
        public float TrongLuongToiThieuXuatChuong { get; set; }
        public float TrongLuongToiDaXuatChuong { get; set; }
        public float TuoiToiThieuXuatChuong { get; set; }
        public float TuoiToiDaXuatChuong { get; set; }
        public float TuoiNhapDanHeoCon { get; set; }
        public float GiaoPhoiCanHuyetToiThieu { get; set; }
        public float TuoiPhoiGiongToiThieuHeoDuc { get; set; }
        public float TuoiPhoiGiongToiThieuHeoCai { get; set; }
        public float SoNgayToiThieuPhoiGiongLai { get; set; }
        public Guid FarmID { get; set; }        
    }
}
