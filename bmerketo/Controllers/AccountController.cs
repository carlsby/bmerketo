using bmerketo.Contexts;
using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Controllers;

public class AccountController : Controller
{
    private readonly AuthService _auth;

    public AccountController(AuthService auth)
    {
        _auth = auth;
    }



    [Authorize]
    public IActionResult Index()
    {
        return View();
    }


    #region SignUp region
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(UserSignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.SignUpAsync(model))
            {
                return RedirectToAction("SignIn");
            }

            ModelState.AddModelError("", "A user with the same email already exits.");
        }

        return View(model);
    }
    #endregion


    #region SignIn region
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.SignInAsync(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Incorrect email or password.");
        }

        return View(model);
    }
    #endregion


    #region SignOut region
    [Authorize]
    public new async Task<IActionResult> SignOut()
    {
        if (await _auth.SignOutAsync(User))
        {
            return LocalRedirect("/");
        }
        return RedirectToAction("Index");
    }
    #endregion


    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Edit(UserSignUpViewModel model)
    {

        return View(model);
    }
}



