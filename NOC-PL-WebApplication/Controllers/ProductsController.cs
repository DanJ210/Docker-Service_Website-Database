using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOCPLWebApplication.Models;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Serilog;

namespace NOC_PL_WebApplication.Controllers {
    public class ProductsController : Controller {
        private readonly ProductLocationContext _context;
        private ILogger<ProductsController> _logger;

        public ProductsController(ProductLocationContext context, ILogger<ProductsController> logger) {
            _context = context;
            _logger = logger;
            //Log.Logger = new LoggerConfiguration()
            ////.MinimumLevel.Debug()
            ////.Enrich.FromLogContext()
            //.WriteTo.File("myfile.txt")
            ////.WriteTo.RollingFile("logs\\myapp-{Date}.txt");
            //.CreateLogger();
        }

        
        /// <summary>
        /// Task is activated from an ajax post in the serverModal.Controller.js file.
        /// </summary>
        /// <param name="productName">Name of the product to have a server saved to</param>
        /// <param name="serverColumn">The column of which the server belongs</param>
        /// <param name="serverId">The database id of the server to be applied to the product</param>
        /// <returns></returns>
        //[Authorize]
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
                //_loggerFactory.LogDebug("Successful save to database entity product");
                //Log.Information("Inforemation level");
                //Log.Debug("Debug Level");
                //Log.Error("Error Leve");
                //Log.Fatal("Fatal level");
                //_testingLogging.("Inforemation level");
                _logger.LogInformation("Testing Logging Debug");
                _logger.LogError("Erro");
                _logger.LogDebug("Debug");
                //_logger.Log.ModelState();
                //Log.Logger = _logger;

            } catch(Exception ex) {

                //_loggerFactory.LogError($"Failed to save to database: {ex.Message}");
                //_loggerFactory.LogDebug("Failed to save to database");
                return Redirect("/Error");
            }
            return Ok();
        }






        // Below here is for reference. No need to review.





        // GET: Products/Edit/5/9
        /// <summary>
        /// Sets a product entity to a selected server entity.
        /// </summary>
        /// <param name="id">Id of the product to set</param>
        /// <param name="serverId">Id of the server to set to product</param>
        /// <returns>RedirectToRoute of Controller="TableDataVMs"/Action="Index"</returns>
        //public async Task<IActionResult> Index(int? id, int? serverId) {
        //    if (id == null) {
        //        return NotFound();
        //    }
        //    try {
        //        if (!ProductExists((int)id)) {
        //            return NotFound();
        //        }
        //        //var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
        //        //var servers = await _context.Servers.ToListAsync();

        //        //product.ProductServer = servers.Single(s => s.Id == serverId);

        //        //_context.Update(product);
        //        //await _context.SaveChangesAsync();
        //        return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index" });
        //    }
        //    catch (Exception ex) { // TODO: Add logger for exception catching.
        //        return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index" });
        //    }
        //    //if (product.ProductServer == null) {
        //    //    product.ProductServer = new Server { ServerName = server };
        //    //    product.ProductGroup = "Testing";
        //    //    _context.Update(product);
        //    //    //_context.Update(TableDataVM);
        //    //    await _context.SaveChangesAsync();

        //    //    return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index" });
        //    //}
        //    //else {
        //    //    product.ProductServer.ServerName += "New Name";
        //    //    _context.Update(product);
        //    //    _context.SaveChanges();
        //    //    return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index"});
        //    //}

        //    //await _context.SaveChangesAsync();
        //    //return View();
        //    //return RedirectToRoute("Tables", new { Controller = "TableDataVMs", Action = "Index" });
        //}

        // GET: Products
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Products.ToListAsync());
        //}

        // GET: Products/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        // GET: Products/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,TableNumber,ProductName,ProductGroup")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}



        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TableNumber,ProductName,ProductGroup")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        // POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        /// <summary>
        /// Returns true or false if a product exists or not
        /// </summary>
        /// <param name="id">Product Id of which cell was clicked</param>
        /// <returns>boolean</returns>
        private bool ProductExists(int id) {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
