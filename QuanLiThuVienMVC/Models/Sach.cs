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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            this.DanhGiaSach = new HashSet<DanhGiaSach>();
            this.DatTruoc = new HashSet<DatTruoc>();
            this.MuonSach = new HashSet<MuonSach>();
            this.SachTrongDanhSach = new HashSet<SachTrongDanhSach>();
            Imagesach = "~/Content/images/add.jpg";
        }
        
        public int MaSach { get; set; }
        public string TieuDe { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> NamXuatBan { get; set; }
        public string NhaXuatBan { get; set; }
        public int TongSoBan { get; set; }
        public int SoBanKhaDung { get; set; }
        public string ViTri { get; set; }
        public string Imagesach { get; set; }
        public HttpPostedFileBase UploadImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGiaSach> DanhGiaSach { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatTruoc> DatTruoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonSach> MuonSach { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SachTrongDanhSach> SachTrongDanhSach { get; set; }
    }
}
