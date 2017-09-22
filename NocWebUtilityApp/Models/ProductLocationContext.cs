/*
 * OnSolve
 * Author: Daniel Jackson
 * NocWebUtility Application
 * Created: 03/22/2017
 * Last Edit: 09/22/2017
 * Description: Database Context.
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NocWebUtilityApp.Models
{
	public class ProductLocationContext : IdentityDbContext<NocUser>
	{
		/*----------------------------------------------------------------------------------------------------------------------
		* [fields]
		-----------------------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------------------
		* [properties]
		-----------------------------------------------------------------------------------------------------------------------*/
		public DbSet<Product> Products { get; set; }
		public DbSet<Server> Servers { get; set; }
		public DbSet<TableDataVM> TableDataVM { get; set; }

		/*----------------------------------------------------------------------------------------------------------------------
		* [constructors]
		-----------------------------------------------------------------------------------------------------------------------*/
		public ProductLocationContext(DbContextOptions options) : base(options)
		{
			Database.Migrate();
		}

		/*----------------------------------------------------------------------------------------------------------------------
		* [methods]
		-----------------------------------------------------------------------------------------------------------------------*/
	}
}
