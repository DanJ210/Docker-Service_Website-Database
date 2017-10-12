/*
 * OnSolve
 * Author: Daniel Jackson
 * NocWebUtility Application
 * Created: 03/22/2017
 * Last Edit: 09/22/2017
 * Description: Seeder for database if its new and empty.
 * 
 */
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NocWebUtilityApp.Models.SeedData
{
	public class ProductServerSeedData
	{
		/*----------------------------------------------------------------------------------------------------------------------
		* [fields]
		-----------------------------------------------------------------------------------------------------------------------*/
		private ProductLocationContext _context;
		private UserManager<NocUser> _userManager;

		/*----------------------------------------------------------------------------------------------------------------------
		* [properties]
		-----------------------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------------------
		* [constructors]
		-----------------------------------------------------------------------------------------------------------------------*/
		public ProductServerSeedData(ProductLocationContext context, UserManager<NocUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		/*----------------------------------------------------------------------------------------------------------------------
		* [methods]
		-----------------------------------------------------------------------------------------------------------------------*/

		/// <summary>
		/// Creates an admin user in a new database with a default password.
		/// Also seeds database with needed default values.
		/// </summary>
		public async Task EnsureSeedData()
		{
			if (!_userManager.Users.Any())
			{
				var user = new NocUser()
				{
					UserName = "admin"
				};
				await _userManager.CreateAsync(user, "P@ssw0rd!");
			}

			if (!_context.Products.Any())
			{
				var productList = new List<Product>() {
                    // Product Page 1

                    // Table 1
                    new Product { ProductName = "NEXT.Coderedweb.com", ProductGroup = "NEXT", TableNumber = 1, Url = "https://next.coderedweb.com/portal/Account/Logon", MachineText = "http://next.coderedweb.com/machine.txt" },
					//new Product { ProductName = "NEXT API", ProductGroup = "NEXT", TableNumber = 1, Url = "", MachineText = "" },
					new Product { ProductName = "NEXT CNE", ProductGroup = "CNE", TableNumber = 1, Url = "https://public.coderedweb.com/cne/en-US/BF4424532341", MachineText = "https://public.coderedweb.com/cne/machine.txt" },
					new Product { ProductName = "NEXT CGE", ProductGroup = "CGE", TableNumber = 1, Url = "https://public.coderedweb.com/CGE/BF4424532341", MachineText = "https://public.coderedweb.com/cge/Error/InvalidOrganization/0" },
					new Product { ProductName = "SmartNotice", ProductGroup = "SMART", TableNumber = 1, Url = "https://login.smartnotice.net/portal/Account/Logon", MachineText = "https://login.smartnotice.net/machine.txt" },
					new Product { ProductName = "Checker (v1.2.1.3)", ProductGroup = "NEXT", TableNumber = 1, Url = "", MachineText = "" },
					new Product { ProductName = "medical.smartnotice.net", ProductGroup = "SMART", TableNumber = 1, Url = "http://medical.smartnotice.net/portal/Account/Logon", MachineText = "https://ecndev1.atlassian.net/wiki/medical.smartnotice.net/machine.txt" },
					new Product { ProductName = "assurity.smartnotice.net", ProductGroup = "SMART", TableNumber = 1, Url = "", MachineText = "http://login.smartnotice.net/portal/Account/AssurityRiver" },
					new Product { ProductName = "api.coderedweb.com", ProductGroup = "CODERED", TableNumber = 1, Url = "http://api.coderedweb.com/", MachineText = "" },
					new Product { ProductName = "public.coderedweb.com", ProductGroup = "CODERED", TableNumber = 1, Url = "http://public.coderedweb.com/", MachineText = "http://public.coderedweb.com/machine.txt" },
					new Product { ProductName = "geo.ecngateway.com", ProductGroup = "ECNGATEWAY", TableNumber = 1, Url = "http://geo.ecngateway.com/", MachineText = "http://geo.ecngateway.com/machine.txt" },
					new Product { ProductName = "Dashboard", ProductGroup = "DASHBOARD", TableNumber = 1, Url = "https://dashboard.ecnetwork.com/mvc/Account/Logon", MachineText = "https://dashboard.ecnetwork.com//machine.txt" },
					new Product { ProductName = "CodeEd", ProductGroup = "ED", TableNumber = 1, Url = "https://my.code-ed.net/Login.aspx", MachineText = "https://my.code-ed.net/machine.txt" },
					new Product { ProductName = "MyDailyCall", ProductGroup = "DAILY", TableNumber = 1, Url = "https://login.mydailycall.net/", MachineText = "https://login.mydailycall.net/machine.txt" },
					new Product { ProductName = "Portal", ProductGroup = "Portal", TableNumber = 1, Url = "https://portal.ecnetwork.com/", MachineText = "https://portal.ecnetwork.com/machine.txt" },
					new Product { ProductName = "demo.coderedweb.com", ProductGroup = "DEMO", TableNumber = 1, Url = "https://demo.coderedweb.com/portal/Account/Logon", MachineText = "http://demo.coderedweb.com/machine.txt" },
                    // Table 2
                    new Product { ProductName = "Classic CNE", ProductGroup = "CNE", TableNumber = 2, Url = "", MachineText = "" },
					new Product { ProductName = "SMS.ecngateway.com", ProductGroup = "ECNGATEWAY", TableNumber = 2, Url = "http://sms.ecngateway.com/", MachineText = "http://sms.ecngateway.com/machine.txt" },
					new Product { ProductName = "American Water", ProductGroup = "AW", TableNumber = 2, Url = "https://aw.coderedweb.com/portal/Account/Logon", MachineText = "https://aw.coderedweb.com/machine.txt" },
					new Product { ProductName = "AW Dashboard", ProductGroup = "AW", TableNumber = 2, Url = "https://awdashboard.ecnetwork.com/Account/Logon", MachineText = "https://aw.coderedweb.com/machine.txt" },
					new Product { ProductName = "migrations.ecnetwork", ProductGroup = "ECNETWORK", TableNumber = 2, Url = "http://migrations.ecnetwork.com/", MachineText = "http://migrations.ecnetwork.com/machine.txt" },
					new Product { ProductName = "Thundercall.net", ProductGroup = "THUNDERCALL", TableNumber = 2, Url = "http://thundercall.net/", MachineText = "" },
					new Product { ProductName = "ecn360.com", ProductGroup = "360", TableNumber = 2, Url = "http://ecn360.com/", MachineText = "http://ecn360.com/machine.txt" },
					new Product { ProductName = "ConferenceCallBillingSVC", ProductGroup = "SVC", TableNumber = 2, Url = "", MachineText = "" },
					new Product { ProductName = "CityWatch(Web)", ProductGroup = "CITYWATCH WEB", TableNumber = 2, Url = "", MachineText = "" },
					new Product { ProductName = "CityWatch(EM)", ProductGroup = "CITYWATCH EM", TableNumber = 2, Url = "", MachineText = "" },
					new Product { ProductName = "Patterson(Web,EM)", ProductGroup = "PATTERSON WEB EM", TableNumber = 2, Url = "", MachineText = "" },
					new Product { ProductName = "Patterson(Audit)", ProductGroup = "PATTERSON AUDIT", TableNumber = 2, Url = "", MachineText = "" },
					new Product { ProductName = "Salvation ArmyEast (Web,EM)", ProductGroup = "SALVATION WEB EM", TableNumber = 2, Url = "", MachineText = "" },
					new Product { ProductName = "Toolkit (SMS)", ProductGroup = "TOOLKIT SMS", TableNumber = 2, Url = "", MachineText = "" },
                    // Product Page 2

                    // Table 3
                    new Product { ProductName = "Classic", ProductGroup = "CLASSIC", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "Classic FTP", ProductGroup = "CLASSIC", TableNumber = 3, Url = "https://ftp.coderedweb.com/", MachineText = "" },
					new Product { ProductName = "SmartNotice FTP", ProductGroup = "SMART FTP", TableNumber = 3, Url = "http://ftp.smartnotice.net/", MachineText = "" },
					new Product { ProductName = "FTP-Launcher", ProductGroup = "LAUNCHER FTP", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "FTP-Loader", ProductGroup = "LOADER FTP", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "TNG", ProductGroup = "TNG", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "TNG2  ", ProductGroup = "TNG", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "CodeRed Checker", ProductGroup = "CODERED", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "My Daily Call", ProductGroup = "DAILY", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = ".Net Checker", ProductGroup = "NET CHECKER", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "Terms.coderedweb.com", ProductGroup = "TERMS CODERED WEB", TableNumber = 3, Url = "https://ecnetwork.com/codered-alerting-confirmation/", MachineText = "" },
					new Product { ProductName = "Mobile", ProductGroup = "MOBILE", TableNumber = 3, Url = "http://mobile.onsolve.com/", MachineText = "http://mobile.onsolve.com/machine.txt" },
					new Product { ProductName = "API.onsolvegateway.com", ProductGroup = "ECNGATEWAY", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "Push Service", ProductGroup = "PUSH SERVICE", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "Coderedweb.net", ProductGroup = "CODEREDWEB NET", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "Widget.coderedweb.com", ProductGroup = "CODERED WEB", TableNumber = 3, Url = "http://widget.coderedweb.com/", MachineText = "http://widget.coderedweb.com/machine.txt" },
					new Product { ProductName = "Coderedweb.com", ProductGroup = "CODEREDWEB", TableNumber = 3, Url = "https://ecnetwork.com/codered-alerting-confirmation/", MachineText = "http://coderedweb.com/machine.txt" },
					new Product { ProductName = "Citynet.coderedweb.com", ProductGroup = "CODEREDWEB", TableNumber = 3, Url = "http://citynet.coderedweb.com/", MachineText = "http://citynet.coderedweb.com/machine.txt" },
					new Product { ProductName = "Orders.thundercall.com", ProductGroup = "THUNDERCALL", TableNumber = 3, Url = "http://orders.thundercall.com/", MachineText = "" },
					new Product { ProductName = "Citywatch (marketing)", ProductGroup = "CITYWATCH MARKETING", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "messagecentric", ProductGroup = "CENTRIC", TableNumber = 3, Url = "", MachineText = "" },
					new Product { ProductName = "thundercall.com", ProductGroup = "THUNDERCALL", TableNumber = 3, Url = "http://thundercall.com/", MachineText = "" },

                    // SQL Table

                    // Table 4
                    new Product { ProductName = "CRNEXT", ProductGroup = "NEXT SQL", TableNumber = 4, Url = "", MachineText = "" },
					new Product { ProductName = "CRSQL", ProductGroup = "SQL", TableNumber = 4, Url = "", MachineText = "" },
					new Product { ProductName = "AWNEXT", ProductGroup = "AW NEXT SQL", TableNumber = 4, Url = "", MachineText = "" },
					new Product { ProductName = "TNG ", ProductGroup = "TNG SQL", TableNumber = 4, Url = "", MachineText = "" },
					new Product { ProductName = "ECNSQL", ProductGroup = "ECN SQL", TableNumber = 4, Url = "", MachineText = "" },
					new Product { ProductName = "MCSQL", ProductGroup = "MC SQL", TableNumber = 4, Url = "", MachineText = "" },

                    // Product Page 3

                    // Horde
                    // Table 5
                    new Product { ProductName = "Primary", ProductGroup = "HORDE", TableNumber = 5, Url = "", MachineText = "" },
					new Product { ProductName = "American Water Back-up to Primary", ProductGroup = "HORDE", TableNumber = 5, Url = "", MachineText = "" },
					new Product { ProductName = "Fallover 1", ProductGroup = "HORDE", TableNumber = 5, Url = "", MachineText = "" },
					new Product { ProductName = "CityWatch/Fallover 2 (Last Resort)", ProductGroup = "HORDE", TableNumber = 5, Url = "", MachineText = "" },

                    // Uber
                    // Table 6
                    new Product { ProductName = "Code Ed", ProductGroup = "UBER", TableNumber = 6, Url = "", MachineText = "" },
					new Product { ProductName = "CodeRed Classic", ProductGroup = "UBER", TableNumber = 6, Url = "", MachineText = "" },
					new Product { ProductName = "TNG  ", ProductGroup = "UBER", TableNumber = 6, Url = "", MachineText = "" },
					
					new Product { ProductName = "Message Centric", ProductGroup = "UBER", TableNumber = 6, Url = "", MachineText = "" },

                    // IPAWS
                    // Table 7
                    new Product { ProductName = "IPAWS1", ProductGroup = "IPAWS", TableNumber = 7, Url = "", MachineText = "" },
					new Product { ProductName = "IPAWS2", ProductGroup = "IPAWS", TableNumber = 7, Url = "", MachineText = "" },
					new Product { ProductName = "IPAWS3", ProductGroup = "IPAWS", TableNumber = 7, Url = "", MachineText = "" },

					// GIS
					// Table 8
					new Product { ProductName = "GIS1", ProductGroup = "GIS", TableNumber = 8, Url = "gis.coderedweb.com", MachineText = "" },

					// CafeX
					// Table 9
					new Product { ProductName = "CafeX1", ProductGroup = "CafeX", TableNumber = 9, Url = "", MachineText = "" }
				};
				_context.AddRange(productList);
				await _context.SaveChangesAsync();
			}
			if (!_context.Servers.Any())
			{
				var serverList = new List<Server>() {
                    // Product Page 1
                    new Server { ServerName = "N/A" },
					new Server { ServerName = "No Primary" },
					new Server { ServerName = "No Secondary" },
					new Server { ServerName = "Unknown" },
					new Server { ServerName = "TBD" },
					new Server { ServerName = "Site1-EcnWeb" },
					new Server { ServerName = "Site2-EcnWeb" },
					new Server { ServerName = "Site3-EcnWeb" },
					new Server { ServerName = "Site3-EcnWeb (codered1w??)" },
					new Server { ServerName = "Site2-VirtWeb1" },
					new Server { ServerName = "Site2-VirtWeb4" },
					new Server { ServerName = "EcnWeb1" },
					new Server { ServerName = "EcnWeb2" },
					new Server { ServerName = "EcnWeb3" },
					new Server { ServerName = "VirtWeb1-1" },
					new Server { ServerName = "VirtWeb1-2" },
					new Server { ServerName = "VirtWeb3-1" },
					new Server { ServerName = "VirtWeb3-2" },
					new Server { ServerName = "VirtWeb1-4" },
					new Server { ServerName = "(S3)CSB-VMN-APP1" },
					new Server { ServerName = "(S3)CSB-VMN-WEB1" },
					new Server { ServerName = "(S3)CSB-VMN-GAPP1" },
					new Server { ServerName = "(S1)CSB-VGA-PAT1" },
					new Server { ServerName = "(S3)CSB-VMN-SAE1" },
					new Server { ServerName = "(S3)CSB-VMN-TK02" },
					new Server { ServerName = "(S1)CSB-VGA-CW01" },
					new Server { ServerName = "(S1)CSB-VGA-RWE1" },
					new Server { ServerName = "(S1)CSB-VGA-SAE1" },
                    
                    // Product Page 2
                    new Server { ServerName = "Codered1w" },
					new Server { ServerName = "Codered2w" },
					new Server { ServerName = "Codered3w" },
					new Server { ServerName = "Ecn-ftp1" },
					new Server { ServerName = "Ecn-ftp2" },
					new Server { ServerName = "Ecn-ftp3" },
					new Server { ServerName = "Ecnutil3" },
					new Server { ServerName = "Site1-VirtUtil2" },
					new Server { ServerName = "Site2-VirtUtil2" },
					new Server { ServerName = "Site1web01" },
					new Server { ServerName = "Site2web01" },
                    // SQL Servers

                    // Table 4
                    new Server { ServerName = "Site1-SQL1-V1", ServerGroup = "SQL" },
					new Server { ServerName = "Site2-SQL1-V1", ServerGroup = "SQL" },
					new Server { ServerName = "TNG", ServerGroup = "SQL" },
					new Server { ServerName = "TNG2A", ServerGroup = "SQL" },
					new Server { ServerName = "ECNSQL3-1", ServerGroup = "SQL" },
					new Server { ServerName = "ECNSQL2", ServerGroup = "SQL" },
					new Server { ServerName = "MCSQL3", ServerGroup = "SQL" },

                    // Product Page 3

                    // Horde
                    // Table 5
                    new Server { ServerName = "Site1-VirtWeb1(Client Servers)", ServerGroup = "Horde" },
					new Server { ServerName = "Site3-EcnWeb(Client Servers)", ServerGroup = "Horde" },
					new Server { ServerName = "Site2-VHorde2", ServerGroup = "Horde" },
					new Server { ServerName = "Site1-VirtHorde1", ServerGroup = "Horde" },
					new Server { ServerName = "Site3-VirtHorde1", ServerGroup = "Horde" },
					new Server { ServerName = "Site3-VirtUtil2", ServerGroup = "Horde" },
					new Server { ServerName = "Site3-SQL1-CLS" },
					new Server { ServerName = "Site3web01", ServerGroup = "Horde" },
					new Server { ServerName = "S1-VHorde1, S1-VHorde2, S1-VHorde3", ServerGroup = "Horde" },
					new Server { ServerName = "S1-VHorde3, S3-VHorde2, S3-VHorde3", ServerGroup = "Horde" },
					new Server { ServerName = "VirtWeb1-1(Client Servers)", ServerGroup = "Horde" },
                    

                    // Uber
                    // Table 6
                    new Server { ServerName = "TXUBER2", ServerGroup = "UBER" },

                    // IPAWS
                    // Table 7
                    new Server { ServerName = "S1-IPAWS1 (Backup)", ServerGroup = "IPAWS" },
					new Server { ServerName = "S2-IPAWS1 (Primary)", ServerGroup = "IPAWS" },
					new Server { ServerName = "S3-IPAWS3 (Unavailable) ", ServerGroup = "IPAWS" },

					new Server { ServerName = "Load Balancer" },
					new Server { ServerName = "Message Centric" },
					new Server { ServerName = "Primary" },
					new Server { ServerName = "ECNGEO3 gis.coderedweb.com" },
					new Server { ServerName = "GIS3 (gis3.coderedweb.com) = 97.107.114.101" },
					new Server { ServerName = "Site3 (Dallas)" },
					new Server { ServerName = "Site2 (Las Vegas)" }
				};
				_context.AddRange(serverList);
				await _context.SaveChangesAsync();
			}
		}
	}
}
