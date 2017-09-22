/*
 * OnSolve
 * Author: Daniel Jackson
 * NocWebUtility Application
 * Created: 03/22/2017
 * Last Edit: 09/22/2017
 * Description: Account user login and logout.
 * 
 */
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NocWebUtilityApp.Models;
using NocWebUtilityApp.Models.ViewModels;
using Microsoft.Extensions.Logging;
using NocWebUtilityApp.Services;

namespace NocWebUtilityApp.Controllers
{
	public class AccountController : Controller
	{
		/*----------------------------------------------------------------------------------------------------------------------
		* [fields]
		-----------------------------------------------------------------------------------------------------------------------*/
		private UserManager<NocUser> _userManager;
		private SignInManager<NocUser> _signInManager;
		private ILogger<AccountController> _logger;
		private IProductLocationRepository _productLocationRepository;

		/*----------------------------------------------------------------------------------------------------------------------
		* [properties]
		-----------------------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------------------
		* [constructors]
		-----------------------------------------------------------------------------------------------------------------------*/
		public AccountController(IProductLocationRepository productLocationRepository,
			UserManager<NocUser> userManager,
			SignInManager<NocUser> signInManager,
			ILogger<AccountController> logger)
		{

			_productLocationRepository = productLocationRepository;
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
		}

		/*----------------------------------------------------------------------------------------------------------------------
		* [methods]
		-----------------------------------------------------------------------------------------------------------------------*/


		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var loginResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

					if (loginResult.Succeeded)
					{
						if (Url.IsLocalUrl(model.ReturnUrl))
						{
							return Redirect(model.ReturnUrl);
						}
						else
						{
							return RedirectToAction("TablesPage1", "TableDataVMs");
						}
					}
				}

			}
			catch (Exception ex)
			{
				_logger.LogError($"Could not sign in user with message: {ex.Message}");
			}
			ModelState.AddModelError("", "Could not login");
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("TablesPage1", "TableDataVMs");
		}
	}
}