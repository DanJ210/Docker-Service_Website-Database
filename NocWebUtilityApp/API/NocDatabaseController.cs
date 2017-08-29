using System;
using System.Collections.Generic;
using System.Linq;
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
		private IProductLocationRepository _productLocationRepository;

		public NocDatabaseController(IProductLocationRepository productLocationRepository)
		{
			_productLocationRepository = productLocationRepository;
		}
		//GET: api/values
		//[HttpGet]
		//public IEnumerable<string> Get() {
		//    return new string[] { "value1", "value2" };
		//}

		[HttpGet]
		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await _productLocationRepository.GetProducts();
		}

		//[HttpGet]
		//public async Task<IEnumerable<Server>> GetServers() {
		//    return await _productLocationRepository.GetServers();
		//}
		// GET api/values/5
		[HttpGet("{id}")]
		public async Task<Product> Get(int id)
		{
			return await _productLocationRepository.GetProduct(id);
		}

		// POST api/values
		//[HttpPost]
		//public void Post([FromBody]string value)
		//{
		//}

		// PUT api/values/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody]string value)
		//{
		//}

		// DELETE api/values/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
