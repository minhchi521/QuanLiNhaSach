//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLiThuVienMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DanhGiaSach
    {
        public int MaDanhGia { get; set; }
        public int MaSach { get; set; }
        public int MaNguoiDung { get; set; }
        public int DiemDanhGia { get; set; }
        public string NhanXet { get; set; }
        public Nullable<System.DateTime> NgayDanhGia { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual Sach Sach { get; set; }
    }
}