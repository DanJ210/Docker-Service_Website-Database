/*
 * OnSolve
 * Author: Daniel Jackson
 * NocWebUtility Application
 * Created: 03/22/2017
 * Last Edit: 09/22/2017
 * Description: Implementation of repository interface.
 * 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using NocWebUtilityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace NocWebUtilityApp.Services
{
	public class ProductLocationRepository : IProductLocationRepository
	{
		/*----------------------------------------------------------------------------------------------------------------------
		* [fields]
		-----------------------------------------------------------------------------------------------------------------------*/
		private ProductLocationContext _context;

		/*----------------------------------------------------------------------------------------------------------------------
		* [properties]
		-----------------------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------------------
		* [constructors]
		-----------------------------------------------------------------------------------------------------------------------*/

		public ProductLocationRepository(ProductLocationContext context)
		{
			_context = context;
		}

		/*----------------------------------------------------------------------------------------------------------------------
		* [methods]
		-----------------------------------------------------------------------------------------------------------------------*/

		/// <summary>
		/// 
		/// </summary>
		/// <returns>List<Product></returns>
		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await _context.Products
				.Include(primaryServer => primaryServer.PrimaryProductServer)
				.Include(secondaryServer => secondaryServer.SecondaryProductServer)
				.ToListAsync();
		}

		/// <summary>
		/// Finds a single product by id within the database.
		/// </summary>
		/// <param name="productId"></param>
		/// <returns>Product</returns>
		public async Task<Product> GetProduct(int productId)
		{
			return await _context.Products
				.Include(primaryServer => primaryServer.PrimaryProductServer)
				.Include(secondaryServer => secondaryServer.SecondaryProductServer)
				.SingleAsync(product => product.Id == productId);
		}

		/// <summary>
		/// Collects a list of all servers in the database.
		/// </summary>
		/// <returns>List<Server></returns>
		public async Task<ICollection<Server>> GetServers()
		{
			return await _context.Servers.ToListAsync();
		}

		/// <summary>
		/// Finds a single server by id within the database.
		/// </summary>
		/// <param name="serverId">integer</param>
		/// <returns>Server</returns>
		public async Task<Server> GetServer(int serverId)
		{
			return await _context.Servers.SingleAsync(server => server.Id == serverId);
		}

		/// <summary>
		/// Asynchronously save scoped changes to the database.
		/// </summary>
		/// <returns></returns>
		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}
	}
}
