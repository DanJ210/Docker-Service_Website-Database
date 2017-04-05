using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models.SeedData {
    /// <summary>
    /// Only seeds data for the Products and Servers if the data doesn't already exist.
    /// Meant for initial setups. Section labels below can be removed after future development.
    /// </summary>
    public class ProductServerSeedData {
        private ProductLocationContext _context;

        public ProductServerSeedData(ProductLocationContext context) {
            _context = context;
        }
        public async Task EnsureSeedData() {
            if (!_context.Products.Any()) {
                var productList = new List<Product>() {
                    // Product Page 1

                    // Table 1
                    new Product { ProductName = "NEXT.Coderedweb.com", ProductGroup = "NEXT", TableNumber = 1 },
                    new Product { ProductName = "NEXT API", ProductGroup = "NEXT", TableNumber = 1 },
                    new Product { ProductName = "NEXT CNE / CGE", ProductGroup = "CNE CGE", TableNumber = 1 },
                    new Product { ProductName = "SmartNotice", ProductGroup = "SMART", TableNumber = 1 },
                    new Product { ProductName = "medical.smartnotice.net", ProductGroup = "SMART", TableNumber = 1 },
                    new Product { ProductName = "assurity.smartnotice.net", ProductGroup = "SMART", TableNumber = 1 },
                    new Product { ProductName = "api.coderedweb.com", ProductGroup = "CODERED", TableNumber = 1 },
                    new Product { ProductName = "public.coderedweb.com", ProductGroup = "CODERED", TableNumber = 1 },
                    new Product { ProductName = "geo.ecngateway.com", ProductGroup = "ECNGATEWAY", TableNumber = 1 },
                    new Product { ProductName = "Dashboard", ProductGroup = "DASHBOARD", TableNumber = 1 },
                    new Product { ProductName = "CodeEd", ProductGroup = "ED", TableNumber = 1 },
                    new Product { ProductName = "MyDailyCall", ProductGroup = "DAILY", TableNumber = 1 },
                    new Product { ProductName = "Portal", ProductGroup = "Portal", TableNumber = 1 },
                    new Product { ProductName = "demo.coderedweb.com", ProductGroup = "DEMO", TableNumber = 1},
                    // Table 2
                    new Product { ProductName = "Classic CNE", ProductGroup = "CNE", TableNumber = 2 },
                    new Product { ProductName = "SMS.ecngateway.com", ProductGroup = "ECNGATEWAY", TableNumber = 2 },
                    new Product { ProductName = "American Water", ProductGroup = "AW", TableNumber = 2 },
                    new Product { ProductName = "AW Dashboard", ProductGroup = "AW", TableNumber = 2 },
                    new Product { ProductName = "migrations.ecnetwork", ProductGroup = "ECNETWORK", TableNumber = 2 },
                    new Product { ProductName = "Thundercall.net", ProductGroup = "THUNDERCALL", TableNumber = 2 },
                    new Product { ProductName = "ecn360.com", ProductGroup = "360", TableNumber = 2 },
                    new Product { ProductName = "ConferenceCallBillingSVC", ProductGroup = "SVC", TableNumber = 2 },
                    new Product { ProductName = "CityWatch(Web)", ProductGroup = "CITYWATCH WEB", TableNumber = 2 },
                    new Product { ProductName = "CityWatch(EM)", ProductGroup = "CITYWATCH EM", TableNumber = 2 },
                    new Product { ProductName = "Patterson(Web,EM)", ProductGroup = "PATTERSON WEB EM", TableNumber = 2 },
                    new Product { ProductName = "Patterson(Audit)", ProductGroup = "PATTERSON AUDIT", TableNumber = 2 },
                    new Product { ProductName = "Salvation ArmyEast (Web,EM)", ProductGroup = "SALVATION WEB EM", TableNumber = 2 },
                    new Product { ProductName = "Toolkit (SMS)", ProductGroup = "TOOLKIT SMS", TableNumber = 2 },
                    // Product Page 2

                    // Table 3
                    new Product { ProductName = "Classic", ProductGroup = "CLASSIC", TableNumber = 3 },
                    new Product { ProductName = "Classic FTP", ProductGroup = "CLASSIC", TableNumber = 3 },
                    new Product { ProductName = "SmartNotice FTP", ProductGroup = "SMART FTP", TableNumber = 3 },
                    new Product { ProductName = "FTP-Launcher", ProductGroup = "LAUNCHER FTP", TableNumber = 3 },
                    new Product { ProductName = "FTP-Loader", ProductGroup = "LOADER FTP", TableNumber = 3 },
                    new Product { ProductName = "TNG", ProductGroup = "TNG", TableNumber = 3 },
                    new Product { ProductName = "CodeRed Checker", ProductGroup = "CODERED", TableNumber = 3 },
                    new Product { ProductName = "My Daily Call", ProductGroup = "DAILY", TableNumber = 3 },
                    new Product { ProductName = ".Net Checker", ProductGroup = "NET CHECKER", TableNumber = 3 },
                    new Product { ProductName = "Terms.coderedweb.com", ProductGroup = "TERMS CODERED WEB", TableNumber = 3 },
                    new Product { ProductName = "Mobile", ProductGroup = "MOBILE", TableNumber = 3 },
                    new Product { ProductName = "API.ecngateway.com", ProductGroup = "ECNGATEWAY", TableNumber = 3 },
                    new Product { ProductName = "Push Service", ProductGroup = "PUSH SERVICE", TableNumber = 3 },
                    new Product { ProductName = "Coderedweb.net", ProductGroup = "CODEREDWEB NET", TableNumber = 3 },
                    new Product { ProductName = "Widget.coderedweb.com", ProductGroup = "CODERED WEB", TableNumber = 3 },
                    new Product { ProductName = "Coderedweb.com", ProductGroup = "CODEREDWEB", TableNumber = 3 },
                    new Product { ProductName = "Citynet.coderedweb.com", ProductGroup = "CODEREDWEB", TableNumber = 3 },
                    new Product { ProductName = "Orders.thundercall.com", ProductGroup = "THUNDERCALL", TableNumber = 3 },
                    new Product { ProductName = "Citywatch (marketing)", ProductGroup = "CITYWATCH MARKETING", TableNumber = 3 },
                    new Product { ProductName = "messagecentric", ProductGroup = "CENTRIC", TableNumber = 3 },
                    new Product { ProductName = "thundercall.com", ProductGroup = "THUNDERCALL", TableNumber = 3 },

                    // SQL Table

                    // Table 4
                    new Product { ProductName = "CRNEXT", ProductGroup = "NEXT SQL", TableNumber = 4 },
                    new Product { ProductName = "CRSQL", ProductGroup = "SQL", TableNumber = 4 },
                    new Product { ProductName = "AWNEXT", ProductGroup = "AW NEXT SQL", TableNumber = 4 },
                    new Product { ProductName = "TNG", ProductGroup = "TNG SQL", TableNumber = 4 },
                    new Product { ProductName = "ECNSQL", ProductGroup = "ECN SQL", TableNumber = 4 },
                    new Product { ProductName = "MCSQL", ProductGroup = "MC SQL", TableNumber = 4 },

                    // Product Page 3

                    // Horde
                    // Table 5
                    new Product { ProductName = "Primary", ProductGroup = "HORDE", TableNumber = 5 },
                    new Product { ProductName = "American Water Back-up to Primary", ProductGroup = "HORDE", TableNumber = 5 },
                    new Product { ProductName = "Fallover 1", ProductGroup = "HORDE", TableNumber = 5 },
                    new Product { ProductName = "CityWatch/Fallover 2 (Last Resort)", ProductGroup = "HORDE", TableNumber = 5 },

                    // Uber
                    // Table 6
                    new Product { ProductName = "Code Ed", ProductGroup = "UBER", TableNumber = 6 },
                    new Product { ProductName = "CodeRed Classic", ProductGroup = "UBER", TableNumber = 6 },
                    new Product { ProductName = "TNG", ProductGroup = "UBER", TableNumber = 6 },
                    new Product { ProductName = "Message Centric", ProductGroup = "UBER", TableNumber = 6 },

                    // IPAWS
                    // Table 7
                    new Product { ProductName = "IPAWS", ProductGroup = "IPAWS", TableNumber = 7 }
                };
                _context.AddRange(productList);
                await _context.SaveChangesAsync();
            }
            if (!_context.Servers.Any()) {
                var serverList = new List<Server>() {
                    // Product Page 1
                    new Server { ServerName = "N/A", TableNumber = 1 },
                    new Server { ServerName = "No Primary", TableNumber = 1 },
                    new Server { ServerName = "No Secondary", TableNumber = 1 },
                    new Server { ServerName = "Unknown", TableNumber = 1 },
                    new Server { ServerName = "TBD", TableNumber = 1 },
                    new Server { ServerName = "Site1-EcnWeb", TableNumber = 1 },
                    new Server { ServerName = "Site2-EcnWeb", TableNumber = 1 },
                    new Server { ServerName = "Site3-EcnWeb", TableNumber = 1 },
                    new Server { ServerName = "Site2-VirtWeb1", TableNumber = 1 },
                    new Server { ServerName = "Site2-VirtWeb4", TableNumber = 1 },
                    new Server { ServerName = "EcnWeb1", TableNumber = 1 },
                    new Server { ServerName = "EcnWeb2", TableNumber = 1 },
                    new Server { ServerName = "VirtWeb1-1", TableNumber = 1 },
                    new Server { ServerName = "VirtWeb1-2", TableNumber = 1 },

                    new Server { ServerName = "VirtWeb3-2", TableNumber = 2 },
                    new Server { ServerName = "VirtWeb1-4", TableNumber = 2 },
                    new Server { ServerName = "(S3)CSB-VMN-APP1", TableNumber = 2 },
                    new Server { ServerName = "(S3)CSB-VMN-WEB1", TableNumber = 2 },
                    new Server { ServerName = "(S3)CSB-VMN-GAPP1", TableNumber = 2 }, 
                    new Server { ServerName = "(S1)CSB-VGA-PAT1", TableNumber = 2 },
                    new Server { ServerName = "(S3)CSB-VMN-SAE1", TableNumber = 2 },
                    new Server { ServerName = "(S3)CSB-VMN-TK02", TableNumber = 2 },
                    new Server { ServerName = "(S1)CSB-VGA-CW01", TableNumber = 2 },
                    new Server { ServerName = "(S1)CSB-VGA-RWE1", TableNumber = 2 },
                    new Server { ServerName = "(S1)CSB-VGA-SAE1", TableNumber = 2 },
                    
                    // Product Page 2
                    new Server { ServerName = "Codered1w", TableNumber = 3 },
                    new Server { ServerName = "Codered2w", TableNumber = 3 },
                    new Server { ServerName = "Codered3w", TableNumber = 3 },
                    new Server { ServerName = "Ecn-ftp1", TableNumber = 3 },
                    new Server { ServerName = "Ecn-ftp2", TableNumber = 3 },
                    new Server { ServerName = "Ecn-ftp3", TableNumber = 3 },
                    new Server { ServerName = "Ecnutil3", TableNumber = 3 },
                    new Server { ServerName = "Site1-VirtUtil2", TableNumber = 3 },
                    new Server { ServerName = "Site2-VirtUtil2", TableNumber = 3 },
                    new Server { ServerName = "Site1web01", TableNumber = 3 },
                    new Server { ServerName = "Site2web01", TableNumber = 3 },
                    new Server { ServerName = "MCSQL3", TableNumber = 3 },
                    // SQL Servers

                    // Table 4
                    new Server { ServerName = "Site1-SQL1-V1", ServerGroup = "SQL", TableNumber = 4 },
                    new Server { ServerName = "Site2-SQL1-V1", ServerGroup = "SQL", TableNumber = 4 },
                    new Server { ServerName = "TNG", ServerGroup = "SQL", TableNumber = 4 },
                    new Server { ServerName = "TNG2A", ServerGroup = "SQL", TableNumber = 4 },
                    new Server { ServerName = "ECNSQL3-1", ServerGroup = "SQL", TableNumber = 4 },
                    new Server { ServerName = "MCSQL3", ServerGroup = "SQL", TableNumber = 4 },

                    // Product Page 3

                    // Horde
                    // Table 5
                    new Server { ServerName = "Site1-VirtWeb1(Client Servers)", ServerGroup = "Horde", TableNumber = 5 },
                    new Server { ServerName = "Site3-EcnWeb(Client Servers)", ServerGroup = "Horde", TableNumber = 5 },
                    new Server { ServerName = "Site2-VHorde2", ServerGroup = "Horde", TableNumber = 5 },
                    new Server { ServerName = "Site1-VirtHorde1", ServerGroup = "Horde", TableNumber = 5 },
                    new Server { ServerName = "Site3-VirtHorde1", ServerGroup = "Horde", TableNumber = 5 },
                    new Server { ServerName = "S1-VHorde1, S1-VHorde2, S1-VHorde3", ServerGroup = "Horde", TableNumber = 5 },
                    new Server { ServerName = "VirtWeb1-1(Client Servers)", ServerGroup = "Horde", TableNumber = 5 },
                    

                    // Uber
                    // Table 6
                    new Server { ServerName = "TXUBER2", ServerGroup = "UBER", TableNumber = 6 },

                    // IPAWS
                    // Table 7
                    new Server { ServerName = "S1-IPAWS1 (Backup)", ServerGroup = "IPAWS", TableNumber = 7,  },
                    new Server { ServerName = "S2-IPAWS1 (Primary)", ServerGroup = "IPAWS", TableNumber = 7 },
                    new Server { ServerName = "S3-IPAWS3 (Unavailable) ", ServerGroup = "IPAWS", TableNumber = 7 }
                };
                _context.AddRange(serverList);
                await _context.SaveChangesAsync();
            }
        }
    }
}
