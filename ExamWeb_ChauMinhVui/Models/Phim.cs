using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWeb_ChauMinhVui.Models
{
    public class Phim
    {
        public int Id { get; set; }
        [ StringLength(250)]
        [Required(ErrorMessage = "Chưa nhập tiêu đề")]
        public String TuaDe { get; set; }
        [StringLength(50)]
        [Required]
        public String DienVien { get; set; }
        public Boolean TrongNuoc { get; set; }
        public double GiaVe { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Giá không hợp lệ")]
        public int ThoiLuong { get; set; }
       
    }
}
