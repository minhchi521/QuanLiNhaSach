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
    
    public partial class LichSuTimKiem
    {
        public int MaTimKiem { get; set; }
        public int MaNguoiDung { get; set; }
        public string TuKhoaTimKiem { get; set; }
        public System.DateTime NgayTimKiem { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
    }
}