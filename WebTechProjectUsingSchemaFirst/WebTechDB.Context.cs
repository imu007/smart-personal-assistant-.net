﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTechProjectUsingSchemaFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class webTechprojectDBEntities : DbContext
    {
        public webTechprojectDBEntities()
            : base("name=webTechprojectDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<appointment> appointments { get; set; }
        public virtual DbSet<contactInfo> contactInfoes { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
