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

        // GET: Products
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Products.ToListAsync());
        //}

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TableNumber,ProductName,ProductGroup")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Index(int? id, string server) {
            //ProductLocationContext newContext = new DbContext(ProductLocationContext);
            if (id == null) {
                return NotFound();
            }
            var tableDataProducts = await _context.TableDataVM.ToListAsync();
            var count = tableDataProducts.Count();
            var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
            var servers = await _context.Servers.CountAsync();
            var productServerId = product.ProductServer.Id;
            //var productOfServer = _context.Servers.Select(s => s);
            if (product == null) {
                return NotFound();
            }
            
            if (product.ProductServer == null) {
                product.ProductServer = new Server { ServerName = server };
                product.ProductGroup = "Testing";
                _context.Update(product);
                //_context.Update(TableDataVM);
                await _context.SaveChangesAsync();
                
                return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index" });
            }
            else {
                product.ProductServer.ServerName += "New Name";
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToRoute(new { Controller = "TableDataVMs", Action = "Index"});
            }
            
            //await _context.SaveChangesAsync();
            //return View();
            //return RedirectToRoute("Tables", new { Controller = "TableDataVMs", Action = "Index" });
            
        }

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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
