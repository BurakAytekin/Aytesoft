//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aytesoft.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturerCode { get; set; }
        public Nullable<int> RuleCode { get; set; }
        public Nullable<int> Unit { get; set; }
        public string ShelfAdress { get; set; }
        public Nullable<int> MinOrder { get; set; }
        public string Notes { get; set; }
        public string Notes1 { get; set; }
        public string Notes2 { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> Deleted { get; set; }
    }
}
