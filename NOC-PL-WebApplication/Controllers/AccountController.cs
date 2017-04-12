using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NOCPLWebApplication.Models;

namespace NOC_PL_WebApplication.Controllers {
    public class AccountController : Controller {
        private UserManager<NocUser> _userManager;
        private SignInManager<NocUser> _signInManager;
        private ProductLocationContext _context;

        public AccountController(ProductLocationContext context, UserManager<NocUser> userManager, SignInManager<NocUser> signInManager) {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login() {
            return View();
        }
    }
}