//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            this.DiemSoes = new HashSet<DiemSo>();
            this.KeHoachHocTaps = new HashSet<KeHoachHocTap>();
        }
    
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string MSSV { get; set; }
        public Nullable<int> Nganh { get; set; }
        public Nullable<int> Khoa { get; set; }
        public Nullable<int> Lop { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string Title_SV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiemSo> DiemSoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KeHoachHocTap> KeHoachHocTaps { get; set; }
        public virtual Khoa Khoa1 { get; set; }
        public virtual Lop Lop1 { get; set; }
        public virtual Nganh Nganh1 { get; set; }
    }
}
