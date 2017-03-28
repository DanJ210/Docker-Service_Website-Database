using Microsoft.AspNetCore.Mvc;
using NOCPLWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Controllers {
    public class TableController : Controller {
        private ProductLocationContext _context;

        public TableController(ProductLocationContext context) {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index() {
            var data =  _context.Products.ToList();
            ViewBag.ServerNames =  _context.Servers.Select(s => s.ServerName);
            ViewBag.ServerTableNumbers =  _context.Servers.Select(s => s.ServerName);
            //var serverData = _context.Products.ToList();
            //ViewData["Servers"] = _context.Servers.ToList();
            return View(data);
        }

        public IActionResult GetServers() {
            var data = _context.Servers.ToList();
            return PartialView(data);
        }

        //[HttpPost]
        //public IActionResult Index() {

        //}
        
    }
}
