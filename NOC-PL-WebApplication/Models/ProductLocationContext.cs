using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models {
    public class ProductLocationContext : DbContext {
        public ProductLocationContext(DbContextOptions options) : base(options) {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Server> Servers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=PLTablesDb;Trusted_Connection=true;MultipleActiveResultSets=true;");
            // To use a config file when ready
            //optionsBuilder.UseSqlServer(_config[""]);
        }

    }
}
