using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOCPLWebApplication.Models;

namespace NOC_PL_WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductLocationContext _context;

        

        public ProductsController(ProductLocationContext context)
        {
            _context = context;    
        }

        // GET: Products/Edit/5/9
        /// <summary>
        /// Sets a product entity to a selected server entity.
        /// </summary>
        /// <param name="id">Id of the product to set</param>
        /// <param name="serverId">Id of the server to set to product</param>
        /// <returns>RedirectToRoute of Controller="TableDataVMs"/Action="Index"</returns>
        public async Task<IActionResult> Index(int? id, int? serverId) {
            if (id == null) {
                return NotFound();
            }
            try {
                if (!ProductExists((int)id)) {
                    return NotFound();
                }
                var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
                var servers = _context.Servers.ToList();

                product.ProductServer = servers.Single(s => s.Id == serverId);

                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index" });
            }
            catch (Exception ex) { // TODO: Add logger for exception catching.
                return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index" });
            }

            //if (product.ProductServer == null) {
            //    product.ProductServer = new Server { ServerName = server };
            //    product.ProductGroup = "Testing";
            //    _context.Update(product);
            //    //_context.Update(TableDataVM);
            //    await _context.SaveChangesAsync();

            //    return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index" });
            //}
            //else {
            //    product.ProductServer.ServerName += "New Name";
            //    _context.Update(product);
            //    _context.SaveChanges();
            //    return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index"});
            //}

            //await _context.SaveChangesAsync();
            //return View();
            //return RedirectToRoute("Tables", new { Controller = "TableDataVMs", Action = "Index" });

        }

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
