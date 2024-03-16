using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Common;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult SignUp()
        {
            return View(new AuthViewModel());
        }

        #region Sign Up
        [HttpPost]
        public async Task<IActionResult> SignUp(AuthViewModel authViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = authViewModel.Email,
                    UserName = authViewModel.Email.Split('@')[0],
                    isAgree = authViewModel.IsAgree
                };

                var result = await _userManager.CreateAsync(user, authViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(authViewModel);
        } 
        #endregion

        #region SignIn
        public IActionResult Login()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(signInViewModel.Email);

                if (user is null)
                {
                    ModelState.AddModelError("", "Email does not Exist!!");
                }

                var isCorrectPassword = await _userManager.CheckPasswordAsync(user, signInViewModel.Password);

                if (isCorrectPassword)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, signInViewModel.Password, signInViewModel.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(signInViewModel);
        }
        #endregion

        #region SignOut
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion

        //#region ForgetPassword
        //public IActionResult ForgetPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user != null)
        //        {
        //            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //            var resetPasswordLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

        //            var email = new EmailMessage
        //            {
        //                Title = "Reset Email",
                        
        //            };
        //        }
        //    }

        //    return View();
        //}
        //#endregion


    }
}
