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
    
    public partial class MuonSach
    {
        public int MaMuon { get; set; }
        public int MaSach { get; set; }
        public int MaNguoiDung { get; set; }
        public System.DateTime NgayMuon { get; set; }
        public System.DateTime NgayDenHan { get; set; }
        public Nullable<System.DateTime> NgayTra { get; set; }
        public string TrangThai { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual Sach Sach { get; set; }
    }
}