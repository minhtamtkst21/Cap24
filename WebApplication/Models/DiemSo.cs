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
    
    public partial class DiemSo
    {
        public int ID { get; set; }
        public int SinhVien { get; set; }
        public int MonHoc { get; set; }
        public Nullable<decimal> DiemSo1 { get; set; }
    
        public virtual MonHoc MonHoc1 { get; set; }
        public virtual SinhVien SinhVien1 { get; set; }
    }
}