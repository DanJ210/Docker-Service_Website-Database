using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOCPLWebApplication.Models;
using System.Collections;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace NOC_PL_WebApplication.Controllers {

    
    public class TableDataVMsController : Controller {
        private readonly ProductLocationContext _context;
        private ILogger<TableDataVMsController> _logger;

        public TableDataVMsController(ProductLocationContext context, ILogger<TableDataVMsController> logger) {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Generates a list of products and servers mapped to a VM.
        /// Creates a select list of servers and sets to ViewBag.
        /// </summary>
        /// <returns>A ViewModel of Products and Servers and a SelectList</returns>
        // GET: TableDataVMs
        //[Authorize]
        public async Task<IActionResult> TablesPage1() {

            var tableDataVM = new TableDataVM();
            try {
                tableDataVM.TableProducts = await _context.Products.ToListAsync();
                tableDataVM.TableServers = await _context.Servers.ToListAsync();
                SelectList serverList = new SelectList(tableDataVM.TableServers, "Id", "ServerName");

                ViewBag.serverList = serverList;
                _logger.LogDebug("Database queries successful");
            }
            catch (Exception ex) {
                _logger.LogDebug($"Error generating view from product and server entities in database: {ex.Message}");
            }

            return View(tableDataVM);
        }

        public async Task<IActionResult> TablesPage2() {

            var tableDataVM = new TableDataVM();
            try {
                tableDataVM.TableProducts = await _context.Products.ToListAsync();
                tableDataVM.TableServers = await _context.Servers.ToListAsync();
                SelectList serverList = new SelectList(tableDataVM.TableServers, "Id", "ServerName");

                ViewBag.serverList = serverList;
                _logger.LogDebug("Database queries successful");
            }
            catch (Exception ex) {
                _logger.LogDebug($"Error generating view from product and server entities in database: {ex.Message}");
            }

            return View(tableDataVM);
        }

        /// <summary>
        /// Takes in three values from a post to find a single product, a single server, and
        /// attatch that server to the product, saves to database.
        /// </summary>
        /// <param name="productId">Database Id of the product</param>
        /// <param name="serverColumn">The column of which the server belongs</param>
        /// <param name="serverId">Database Id of the server</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveSelectedServer(int productId, string serverColumn, int serverId) {

            try {

                var products = await _context.Products.ToListAsync();

                var servers = await _context.Servers.ToListAsync();

                var product = await _context.Products.SingleAsync(p => p.Id == productId);
                //var product = products.Find(p => p.ProductName == productName);

                if (serverColumn.Contains("primary")) {
                    product.PrimaryProductServer = servers.Single(s => s.Id == serverId);
                }
                else {
                    product.SecondaryProductServer = servers.Single(s => s.Id == serverId);
                }
                await _context.SaveChangesAsync();

            }
            catch (Exception ex) {
                _logger.LogError("PRODUCTS CONTROLLER ------- SaveSelectedServer Action:  " + ex.Message);
                return Redirect("Account/Login");
            }
            return Ok();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] TableDataVM tableDataVM)
        {
            if (id != tableDataVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableDataVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableDataVMExists(tableDataVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(tableDataVM);
        }

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

        private bool TableDataVMExists(int id)
        {
            return _context.TableDataVM.Any(e => e.Id == id);
        }
    }
}
