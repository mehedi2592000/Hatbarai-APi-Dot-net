﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_Entity_Layer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FinalEntities : DbContext
    {
        public FinalEntities()
            : base("name=FinalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<agency> agencies { get; set; }
        public DbSet<notification> notifications { get; set; }
        public DbSet<orphan> orphans { get; set; }
        public DbSet<token> tokens { get; set; }
        public DbSet<transaction> transactions { get; set; }
        public DbSet<user> users { get; set; }
    }
}
