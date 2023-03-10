using Acme.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using User = Acme.Core.Identity.User;

namespace Acme.Web.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ILogger _logger;

    public AccountController(
        //TODO: I think this is redundant, since signinmanager has a reference to usermanager.
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ILoggerFactory loggerFactory
    )
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._logger = loggerFactory.CreateLogger<AccountController>();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl = null)
    {
        this.ViewData["ReturnUrl"] = returnUrl;
        return this.View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
    {
        var destination = returnUrl ?? "/";
        this.ViewData["ReturnUrl"] = destination;
        if (this.ModelState.IsValid)
        {
            var result = await this._signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                this._logger.LogInformation(1, "User logged in.");
                return this.RedirectToLocal(destination);
            }
            if (result.IsLockedOut)
            {
                this._logger.LogWarning(2, "User account locked out.");
                return this.View("Lockout");
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return this.View(model);
            }
        }

        // If we got this far, something failed, redisplay form
        return this.View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register(string? returnUrl = null)
    {
        this.ViewData["ReturnUrl"] = returnUrl;
        return this.View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl = null)
    {
        var destination = returnUrl ?? "/";
        this.ViewData["ReturnUrl"] = destination;
        if (this.ModelState.IsValid)
        {
            var user = new User { UserName = model.Email, Email = model.Email };
            var result = await this._userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await this._signInManager.SignInAsync(user, isPersistent: false);
                this._logger.LogInformation(3, "User created a new account with password.");
                return this.RedirectToLocal(destination);
            }
            this.AddErrors(result);
        }

        return this.View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOff()
    {
        await this._signInManager.SignOutAsync();
        this._logger.LogInformation(4, "User logged out.");
        return this.RedirectToAction(nameof(HomeController.Index), "Home");
    }

   #region Helpers

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            this.ModelState.AddModelError(string.Empty, error.Description);
        }
    }

    private Task<User> GetCurrentUserAsync() =>
        this._userManager.GetUserAsync(this.HttpContext.User);

    private IActionResult RedirectToLocal(string returnUrl) =>
        this.Url.IsLocalUrl(returnUrl)
            ? this.Redirect(returnUrl)
            : this.RedirectToAction(nameof(HomeController.Index), "Home");

   #endregion
}
