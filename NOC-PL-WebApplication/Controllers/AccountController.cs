using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NOCPLWebApplication.Models;
using NOCPLWebApplication.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace NOC_PL_WebApplication.Controllers {
    public class AccountController : Controller {
        private UserManager<NocUser> _userManager;
        private SignInManager<NocUser> _signInManager;
        private ProductLocationContext _context;
        private ILogger<AccountController> _logger;

        public AccountController(ProductLocationContext context, UserManager<NocUser> userManager, SignInManager<NocUser> signInManager, ILogger<AccountController> logger) {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model) {
            try {
                if (ModelState.IsValid) {
                    var loginResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                    if (loginResult.Succeeded) {
                        if (Url.IsLocalUrl(model.ReturnUrl)) {
                            return Redirect(model.ReturnUrl);
                        } else {
                            return RedirectToAction("Index", "TableDataVMs");
                        }
                    }
                }
                
            } catch(Exception ex) {
                _logger.LogError($"Could not sign in user with message: {ex.Message}");
            }
            ModelState.AddModelError("", "Could not login");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "TableDataVMs");
        }
    }
}