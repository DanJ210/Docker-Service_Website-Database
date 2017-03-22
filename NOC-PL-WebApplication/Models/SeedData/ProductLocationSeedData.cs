using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models.SeedData {
    public class ProductLocationSeedData {
        private ProductLocationContext _context;

        public ProductLocationSeedData(ProductLocationContext context) {
            _context = context;
        }
        
        //Seeding task that seeds only if data is not already found
        public async Task EnsureSeedData() {
            if (!_context.Products.Any()) {
                var product = new Product() {
                    ProductName = "NEXT.coderedweb.com"
                };
            }
            
            if (!_context.Servers.Any()) {

            }
        }
    }
}
