using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebElectronicCashCounter.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<UserAccountModel> UserAccountModel { get; set; }
        //public DbSet<Invoice> Invoice { get; set; }
        //public DbSet<SeeProfitOrLossField> Field { get; set; }
    }
}