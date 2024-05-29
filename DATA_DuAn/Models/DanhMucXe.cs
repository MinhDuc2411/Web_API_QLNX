using DATA_DuAn.DTO.DanhMucXeDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATA_DuAn.Models
{
    public class DanhMucXe
    {
        [Key]
        public int MaXe { get; set; }
        public string? BienSo { get; set; }
        public string? HangXe { get; set; }
        public string? MauSac { get; set; }
        public decimal GiaThue { get; set; }
        public string? TrangThai { get; set; }

        // Một xe có thể có nhiều hợp đồng thuê
        public ICollection<HopDongThue> HopDongThues { get; set; }

        public object Select(Func<object, DanhMucXeDTO> value)
        {
            throw new NotImplementedException();
        }
    }
}
