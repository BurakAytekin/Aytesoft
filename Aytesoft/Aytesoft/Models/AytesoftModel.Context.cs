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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class aytesoft_mvcEntities : DbContext
    {
        public aytesoft_mvcEntities()
            : base("name=aytesoft_mvcEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<basket> baskets { get; set; }
        public virtual DbSet<product_price> product_price { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<order_detail> order_detail { get; set; }
    }
}
