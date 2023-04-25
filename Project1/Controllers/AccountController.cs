using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BookWebApp.Infrastructure;
using BookWebApp.Infrastructure.AccountInfraStructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project1.Infrastructure;
using Project1.Models;
using Services;
using BookWebApp.Extensions;
using System.Text.Encodings.Web;
using System.ComponentModel.DataAnnotations;
using BookMicrosoftVersion.Infrastructure.AccountInfraStructure;

namespace Project1.Controllers
{
    public class AccountController : Controller
    {
        private readonly STDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailServices _emailServices;
        private readonly ILogger _logger;
        public static int PASSWORD_LENGHT_ERROR = 1;
        public static int PASSWORD_CHAR_ERROR = 2;

        

        public AccountController(STDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailServices emailServices,
            ILogger<AccountController> logger)
        {
            _emailServices = emailServices;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginUserName(LoginUserNameModel model,string returnUrl = null)
        {
                if(ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(model.Email);
                if (user.Result == null)
                {
                    ModelState.AddModelError(string.Empty, "No Such User Found !");
                    return View("Login", model);
                }
                else
                {
                    ViewData["ReturnUrl"] = returnUrl;
                    var usermodel = new LoginViewModel { Email = model.Email };
                    return View("LoginPassword", usermodel);
                }
            }
            return View("Login",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginPassword(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // Encryptionkey = MM26G99
                //string EncryptPasswor = CustomeCryptography.Encrypt(model.Password, "MM26G99");
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User Logged In");
                    return RedirectToLocal(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe, model.Email });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogInformation("User acount Locked out ");
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    if (_userManager.FindByEmailAsync(model.Email) == null)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Password");
                        return View(model);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> salam()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
   
        public ActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> LoginWith2fa(bool rememberme, string returnUrl = null)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            var temp = User;
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }
            Random Rand = new Random();
            int FactorCode = Rand.Next(1000, 9000);
            user.TwofactorCode = FactorCode;

            _userManager.UpdateAsync(user);

            _emailServices.SendEmailAsync(user.Email, "Two Factor Authentication Code", FactorCode.ToString());
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginWith2fa(Login2FAModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (model.TwoFactorCode == user.TwofactorCode)
                {
                    _signInManager.SignInAsync(user, model.Rememberme);
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Two Factor Code");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task OAuthLogin(string ReturnUrl = "/")
        {
            await HttpContext.ChallengeAsync("Microsoft", new AuthenticationProperties() { RedirectUri = ReturnUrl });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, name = model.name, Email = model.Email, SendNotification = model.SendNotification, PhoneNumber = model.PhoneNumber ,password = model.Password};
                var Result = await _userManager.CreateAsync(user, model.Password);
                if (Result.Succeeded)
                {
                    _logger.LogInformation("User Create New Account");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);

                    var emailconfig = $"<p class='text-center text-muted'>We Are Proud Having You in Our Comminuity</p>You Can Confirm Your Account By Clicking <br> <button class='btn btn-primary w-25 mt-2 text-center' href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Confirm</button>";

                    await _emailServices.SendEmailAsync(model.Email, "Email Confirmation", emailconfig);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User SingIn");
                    return View("CreateConfirmation", model.Email);
                    return Redirect("/Home/Index");
                }
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MicrosoftExternalLogin(string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Microsoft", redirectUrl);
            return Challenge(properties, "Microsoft");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
                return Redirect("/Home/index");
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginModel { Email = email });
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        return Redirect("/Home/index");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(Login), model);
        }

        public int IsValidPassword(string password)
        {
            if (Regex.IsMatch(password, @"^[a-zA-Z0-9\-]*?$"))
            {
                if (password.Length >= 6)
                {
                    return 0;
                }
                else
                    return PASSWORD_LENGHT_ERROR;
            }
            else
                return PASSWORD_CHAR_ERROR;
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        public JsonResult GetUsers()
        {
            string append = "";
            foreach (User item in _context.Users)
            {
                string temp = "\nName: " + item.name + "- Password: " + item.password;
                append += temp;
            }
            return Json(append);
        }
        [HttpGet]
        public async Task<ActionResult> ConfirmEmail(string userid, string code)
        {
            if (userid == null || code==null)
            {
                ViewBag["Error"] = "UnAccepted UserId Try Login Again";
                return View();
            }
            var user = await _userManager.FindByIdAsync(userid);
            if(user == null)
            {
                ViewBag["Error"] = "No User Found With Current UserId";
                return View();
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        [HttpGet]
        public ActionResult ForgetPassword(string username = null)
        {
            ViewBag["Email"] = username;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgetPassword(ForgetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "No user Found with This Email Address");
                    return View();
                }
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);

                var email = $"Dear {HtmlEncoder.Default.Encode(user.name)} You Requiest For Reset Your Password <br/> " +
                    $"This Time We Suggest You Choose Strong Password <br/> " +
                    $"To Reset Your Password Please Click <a href='{callbackUrl}' class='text-success text-left display-4'>Here</a>";
                await _emailServices.SendEmailAsync(model.Email, "Account Password Reset", email);
                return RedirectToAction(nameof(ForgetPasswordConfirmation),model.Email);
            }
            else return View(model);
        }
        [HttpGet]
        public ActionResult ForgetPasswordConfirmation(string email = null)
        {
            ViewBag["Email"] = email;
            return View();
        }
        [HttpGet]
        public ActionResult ResetPassword(string code = null)
        {
            if(code == null)
            {
                ModelState.AddModelError(string.Empty, "Can Not Recognize User Identity");
                return View();
            }
            var model = new ResetPasswordModel { Code = code };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user == null)
                {
                    ModelState.AddModelError(string.Empty, "No Such User Found");
                    return View();
                }
                var Result = await _userManager.ResetPasswordAsync(user, model.Code,model.Password);
                if(Result.Succeeded)
                {
                    return View("ResetPasswordConfirmation");
                }
                else
                {
                    foreach(var error in Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
            }
            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(Home.index), "Home");
            }
        }
    }
}
