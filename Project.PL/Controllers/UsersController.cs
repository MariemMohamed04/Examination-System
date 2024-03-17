using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UsersController> _logger;
        public UsersController(UserManager<ApplicationUser> userManager, ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> users;
            users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id is null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
                return NotFound();

            return View(viewName, user);
        }

        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, ApplicationUser appUser)
        {
            if (id != appUser.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);
                    user.UserName = appUser.UserName;
                    user.NormalizedUserName = appUser.UserName.ToUpper();

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                        return RedirectToAction(nameof(Index));

                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex.Message);
                }
            }
            return View(appUser);
        }

        public async Task<IActionResult> Delete(string id, ApplicationUser appUser)
        {
            if (id != appUser.Id)
                return NotFound();

            try
            {
                var user = await _userManager.FindByIdAsync(id);

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                //ViewBag.Errors = result.Errors;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View(appUser);
        }

        #region Sign Up
        public IActionResult AddUser()
        {
            return View(new AuthViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AuthViewModel authViewModel)
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
                    return RedirectToAction("Index", "Users");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(authViewModel);
        }
        #endregion
    }
}


