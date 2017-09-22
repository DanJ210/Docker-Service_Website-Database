/*
 * OnSolve
 * Author: Daniel Jackson
 * NocWebUtility Application
 * Created: 03/22/2017
 * Last Edit: 09/22/2017
 * Description: Controller for both table pages/views.
 * 
 */
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NocWebUtilityApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using NocWebUtilityApp.Services;

namespace NocWebUtilityApp.Controllers
{
	public class TableDataVMsController : Controller
	{
		/*----------------------------------------------------------------------------------------------------------------------
		* [fields]
		-----------------------------------------------------------------------------------------------------------------------*/
		private readonly IProductLocationRepository _productLocationRepository;
		private readonly ILogger<TableDataVMsController> _logger;

		/*----------------------------------------------------------------------------------------------------------------------
		* [properties]
		-----------------------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------------------
		* [constructors]
		-----------------------------------------------------------------------------------------------------------------------*/
		public TableDataVMsController(IProductLocationRepository productLocationRepository,
			ILogger<TableDataVMsController> logger)
		{

			_logger = logger;
			_productLocationRepository = productLocationRepository;
		}

		/*----------------------------------------------------------------------------------------------------------------------
		* [methods]
		-----------------------------------------------------------------------------------------------------------------------*/

		/// <summary>
		/// Generates a list of products and servers mapped to a VM.
		/// Generates SelectList and MultiSelectlist.
		/// For Page 1
		/// </summary>
		/// <returns>{TableDataVM} Products, Servers. {ViewBag} SelectList and MultiSelectList</returns>
		/// <exception cref="Exception">Standard Exception. Logs error message in serilogger</exception>
		// GET: TableDataVMs
		public async Task<IActionResult> TablesPage1()
		{

			var tableDataVM = new TableDataVM();
			try
			{
				tableDataVM.TableProducts = await _productLocationRepository.GetProducts();
				tableDataVM.TableServers = await _productLocationRepository.GetServers();

				MultiSelectList productList = new MultiSelectList(tableDataVM.TableProducts, "Id", "ProductName");
				SelectList serverList = new SelectList(tableDataVM.TableServers, "Id", "ServerName");

				ViewBag.productList = productList;
				ViewBag.serverList = serverList;
			}
			catch (Exception ex)
			{
				_logger.LogDebug($"------------Error generating view from product and server entities in database: {ex.Message}");
			}
			return View(tableDataVM);
		}
		/// <summary>
		/// Generates a list of products and servers mapped to a VM.
		/// Generates SelectList and MultiSelectlist.
		/// For Page 2
		/// </summary>
		/// <remarks>SelectList is of servers, MultiSelectList of Products</remarks>
		/// <returns>{TableDataVM} Products, Servers. {ViewBag} SelectList and MultiSelectList</returns>
		/// <exception cref="Exception">Standard Exception. Logs error message in serilogger</exception>
		// GET: TableDataVMs
		public async Task<IActionResult> TablesPage2()
		{

			var tableDataVM = new TableDataVM();

			try
			{
				tableDataVM.TableProducts = await _productLocationRepository.GetProducts();
				tableDataVM.TableServers = await _productLocationRepository.GetServers();


				MultiSelectList productList = new MultiSelectList(tableDataVM.TableProducts, "Id", "ProductName");
				SelectList serverList = new SelectList(tableDataVM.TableServers, "Id", "ServerName");

				ViewBag.productList = productList;
				ViewBag.serverList = serverList;
			}
			catch (Exception ex)
			{
				_logger.LogDebug($"------------Error generating view from product and server entities in database: {ex.Message}");
			}

			return View(tableDataVM);
		}

		/// <summary>
		/// Takes in three values from a $.ajax post to find a single product, a single server, and
		/// attach that server to the product, then saves to database. User must be authorized.
		/// </summary>
		/// <param name="productId">Database Id of the product</param>
		/// <param name="serverColumn">The column the server belongs</param>
		/// <param name="serverId">Database Id of the server</param>
		/// <returns>Ok if the task resulted in an Ok completion</returns>
		/// <exception cref="Exception"></exception>
		[Authorize]
		[HttpPost]
		public async Task<IActionResult> SaveSelectedServer(int productId, string serverColumn, int serverId)
		{

			try
			{
				var product = await _productLocationRepository.GetProduct(productId);
				var server = await _productLocationRepository.GetServer(serverId);

				if (serverColumn.Contains("primary"))
				{
					product.PrimaryProductServer = server;
				}
				else
				{
					product.SecondaryProductServer = server;
				}

				await _productLocationRepository.SaveChanges();
			}
			catch (Exception ex)
			{
				_logger.LogError("PRODUCTS CONTROLLER ------- SaveSelectedServer Action:  " + ex.Message);
				return Redirect("Account/Login");
			}
			return Ok();
		}

		/// <summary>
		/// Error page for non-development environment.
		/// </summary>
		/// <returns>A standard View of Error.cshtml</returns>
		public IActionResult Error()
		{
			return View();
		}
	}
}
