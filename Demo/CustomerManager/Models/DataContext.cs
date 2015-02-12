using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CustomerManager.App_Start;

namespace CustomerManager.Models
{
    [RegisterInstancePerRequest]
    public class DataContext  : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbConnection connection) : base(connection, true) { }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<StringLengthAttributeConvention>();
        }
    }
}