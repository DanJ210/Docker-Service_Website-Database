/*
 * OnSolve
 * Author: Daniel Jackson
 * NocWebUtility Application
 * Created: 03/22/2017
 * Last Edit: 09/22/2017
 * Description: Standalone API to access the database.
 * 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NocWebUtilityApp.Models;
using NocWebUtilityApp.Services;

// Future API if needed. Swagger documentation hooked up to this.

namespace NocWebUtilityApp.API
{
	[Route("api/[controller]")]
	public class NocDatabaseController : Controller
	{
		/*----------------------------------------------------------------------------------------------------------------------
		* [fields]
		-----------------------------------------------------------------------------------------------------------------------*/
		private IProductLocationRepository _productLocationRepository;

		/*----------------------------------------------------------------------------------------------------------------------
		* [properties]
		-----------------------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------------------
		* [constructors]
		-----------------------------------------------------------------------------------------------------------------------*/
		/// <summary>
		/// Sets private instance of repository.
		/// </summary>
		/// <param name="productLocationRepository"></param>
		public NocDatabaseController(IProductLocationRepository productLocationRepository)
		{
			_productLocationRepository = productLocationRepository;
		}

		/*----------------------------------------------------------------------------------------------------------------------
		* [methods]
		-----------------------------------------------------------------------------------------------------------------------*/

		/// <summary>
		/// Gets all products in the database.
		/// </summary>
		/// <returns>List<Product></returns>
		[HttpGet]
		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await _productLocationRepository.GetProducts();
		}

		/// <summary>
		/// Gets a product based on a given id.
		/// </summary>
		/// <param name="id">integer</param>
		/// <returns>Product</returns>
		[HttpGet("{id}")]
		public async Task<Product> Get(int id)
		{
			return await _productLocationRepository.GetProduct(id);
		}
	}
}
