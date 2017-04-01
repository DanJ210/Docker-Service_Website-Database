using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOCPLWebApplication.Models;
using System.Collections;

namespace NOC_PL_WebApplication.Controllers {
    public class TableDataVMsController : Controller {
        private readonly ProductLocationContext _context;

        public TableDataVMsController(ProductLocationContext context) {
            _context = context;    
        }

        // GET: TableDataVMs
        public async Task<IActionResult> Index() {
            
            var tableDataVM = new TableDataVM();
            tableDataVM.TableProducts = await _context.Products.ToListAsync();
            tableDataVM.TableServers = await _context.Servers.ToListAsync();
            SelectList serverList = new SelectList(tableDataVM.TableServers);
            ViewBag.serverList = serverList;
            return View(tableDataVM);
        }

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
