using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models.SeedData {
    public class ProductServerSeedData {
        private ProductLocationContext _context;

        public ProductServerSeedData(ProductLocationContext context) {
            _context = context;
        }
        
        //Seeding task that seeds only if data is not already found
        public async Task EnsureSeedData() {
            if (!_context.Products.Any()) {
                var productList = new List<Product>() {
                    new Product { ProductName = "NEXT.Coderedweb.com", ProductGroup = "NEXT" },
                    new Product { ProductName = "NEXT API", ProductGroup = "NEXT" },
                    new Product { ProductName = "NEXT CNE", ProductGroup = "NEXT" },
                    new Product { ProductName = "SmartNotice", ProductGroup = "SMART" },
                    new Product { ProductName = "medical.smartnotice.net", ProductGroup = "SMART" },
                    new Product { ProductName = "assurity.smartnotice.net", ProductGroup = "SMART" },
                    new Product { ProductName = "api.coderedweb.com", ProductGroup = "CODERED" },
                    new Product { ProductName = "public.coderedweb.com", ProductGroup = "CODERED" },
                    new Product { ProductName = "geo.ecngateway.com", ProductGroup = "ECNGATEWAY" },
                    new Product { ProductName = "Dashboard", ProductGroup = "DASHBOARD" },
                    new Product { ProductName = "CodeEd", ProductGroup = "ED" },
                    new Product { ProductName = "MyDailyCall", ProductGroup = "DAILY" },
                    new Product { ProductName = "Portal", ProductGroup = "Portal" },
                    new Product { ProductName = "demo.coderedweb.com", ProductGroup = "DEMO"}
                };

                //var product = new List<Product>( { ProductName = "NEXT.coderedweb.com", ProductGroup = "NEXT" });
                _context.AddRange(productList);
                await _context.SaveChangesAsync();
            }
            
            if (!_context.Servers.Any()) {
                var serverList = new List<Server>() {
                    new Server { ServerName = "Site1-EcnWeb" },
                    new Server { ServerName = "Site2-EcnWeb" },
                    new Server { ServerName = "Site3-EcnWeb" },
                    new Server { ServerName = "Site2-VirtWeb1" },
                    new Server { ServerName = "Site2-VirtWeb4" },
                    new Server { ServerName = "VirtWeb1-2" },
                    new Server { ServerName = "VirtWeb3-2" },
                    new Server { ServerName = "VirtWeb1-4" },
                    new Server { ServerName = "(S3)CSB-VMN-APP" },
                    new Server { ServerName = "(S3)CSB-VMN-WEB1" },
                    new Server { ServerName = "(S3)CSB-VMN-GAPP1" },
                    new Server { ServerName = "(S1)CSB-VGA-PAT1" },
                    new Server { ServerName = "(S3)CSB-VMN-SAE1" },
                    new Server { ServerName = "(S3)CSB-VMN-TK02" },
                    new Server { ServerName = "(S1)CSB-VGA-CW01" },
                    new Server { ServerName = "(S1)CSB-VGA-RWE1" },
                    new Server { ServerName = "(S1)CSB-VGA-SAE1" },
                    new Server { ServerName = "No Primary" },
                    new Server { ServerName = "No Secondary" },
                    new Server { ServerName = "Unknown" },
                    new Server { ServerName = "TBD" }
                };
                _context.AddRange(serverList);
                await _context.SaveChangesAsync();
            }

            //await _context.SaveChangesAsync();
        }
    }
}
