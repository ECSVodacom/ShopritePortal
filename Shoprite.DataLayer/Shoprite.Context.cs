﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shoprite.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ShopriteEntities : DbContext
    {
        public ShopriteEntities()
            : base("name=ShopriteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClaimBatch> ClaimBatches { get; set; }
        public virtual DbSet<OrderBatch> OrderBatches { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<ApiURL> ApiURLs { get; set; }
    
    }
}