using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                    return RedirectToAction("SignIn");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(authViewModel);
        }

        #region SignIn
        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
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
    }
}
