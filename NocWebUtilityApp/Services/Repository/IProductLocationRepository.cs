using NocWebUtilityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NocWebUtilityApp.Services
{
	public interface IProductLocationRepository
	{
		/// <summary>
		/// Gets all products in the database
		/// </summary>
		/// <returns>IEnumerable</returns>
		Task<IEnumerable<Product>> GetProducts();
		/// <summary>
		/// Selects single product with its database id.
		/// </summary>
		/// <param name="productId">The database Id of a product</param>
		/// <returns>Product</returns>
		Task<Product> GetProduct(int productId);
		/// <summary>
		/// Gets all servers in the database.
		/// </summary>
		/// <returns>ICollection</returns>
		Task<ICollection<Server>> GetServers();
		/// <summary>
		/// Selects single server with its database Id.
		/// </summary>
		/// <param name="serverId">Database Id of a server</param>
		/// <returns>Server</returns>
		Task<Server> GetServer(int serverId);
		/// <summary>
		/// Saves database changes to the database after changes are made.
		/// </summary>
		/// <returns></returns>
		Task SaveChanges();
	}
}
