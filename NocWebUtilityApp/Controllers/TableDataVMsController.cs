using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NocWebUtilityApp.Models;
using System.Collections;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using Serilog.Core;
using NocWebUtilityApp.Services;

// Controller for the Table pages and table data display and manipulation.

namespace NocWebUtilityApp.Controllers
{
	public class TableDataVMsController : Controller
	{
		private readonly IProductLocationRepository _productLocationRepository;
		private readonly ILogger<TableDataVMsController> _logger;

		public TableDataVMsController(IProductLocationRepository productLocationRepository,
			ILogger<TableDataVMsController> logger)
		{

			_logger = logger;
			_productLocationRepository = productLocationRepository;
		}

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




		// Code below is for reference. No need to review.






		// GET: TableDataVMs/Details/5
		//public async Task<IActionResult> Details(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var tableDataVM = await _context.TableDataVM
		//        .SingleOrDefaultAsync(m => m.Id == id);
		//    if (tableDataVM == null)
		//    {
		//        return NotFound();
		//    }

		//    return View(tableDataVM);
		//}

		// GET: TableDataVMs/Create
		//public IActionResult Create()
		//{
		//    return View();
		//}

		// POST: TableDataVMs/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create([Bind("Id")] TableDataVM tableDataVM)
		//{
		//    if (ModelState.IsValid)
		//    {
		//        _context.Add(tableDataVM);
		//        await _context.SaveChangesAsync();
		//        return RedirectToAction("Index");
		//    }
		//    return View(tableDataVM);
		//}

		// GET: TableDataVMs/Edit/5
		//public async Task<IActionResult> Edit(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var tableDataVM = await _context.TableDataVM.SingleOrDefaultAsync(m => m.Id == id);
		//    if (tableDataVM == null)
		//    {
		//        return NotFound();
		//    }
		//    return View(tableDataVM);
		//}

		// POST: TableDataVMs/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Edit(int id, [Bind("Id")] TableDataVM tableDataVM) {
		//    if (id != tableDataVM.Id) {
		//        return NotFound();
		//    }

		//    if (ModelState.IsValid) {
		//        try {
		//            _context.Update(tableDataVM);
		//            await _context.SaveChangesAsync();
		//        }
		//        catch (DbUpdateConcurrencyException) {
		//            if (!TableDataVMExists(tableDataVM.Id)) {
		//                return NotFound();
		//            }
		//            else {
		//                throw;
		//            }
		//        }
		//        return RedirectToAction("Index");
		//    }
		//    return View(tableDataVM);
		//}

		// GET: TableDataVMs/Delete/5
		//public async Task<IActionResult> Delete(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var tableDataVM = await _context.TableDataVM
		//        .SingleOrDefaultAsync(m => m.Id == id);
		//    if (tableDataVM == null)
		//    {
		//        return NotFound();
		//    }

		//    return View(tableDataVM);
		//}

		// POST: TableDataVMs/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteConfirmed(int id)
		//{
		//    var tableDataVM = await _context.TableDataVM.SingleOrDefaultAsync(m => m.Id == id);
		//    _context.TableDataVM.Remove(tableDataVM);
		//    await _context.SaveChangesAsync();
		//    return RedirectToAction("Index");
		//}

		//private bool TableDataVMExists(int id) {
		//    return _context.TableDataVM.Any(e => e.Id == id);
		//}
	}
}
