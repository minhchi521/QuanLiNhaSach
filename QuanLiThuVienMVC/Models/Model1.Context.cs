﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class thuvienEntities : DbContext
    {
        public thuvienEntities()
            : base("name=thuvienEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DanhGiaSach> DanhGiaSach { get; set; }
        public virtual DbSet<DanhSachSachCaNhan> DanhSachSachCaNhan { get; set; }
        public virtual DbSet<DatTruoc> DatTruoc { get; set; }
        public virtual DbSet<LichSuTimKiem> LichSuTimKiem { get; set; }
        public virtual DbSet<LichTrucThuThu> LichTrucThuThu { get; set; }
        public virtual DbSet<MuonSach> MuonSach { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<SachTrongDanhSach> SachTrongDanhSach { get; set; }
        public virtual DbSet<ThanhToanTienPhat> ThanhToanTienPhat { get; set; }
    }
}
