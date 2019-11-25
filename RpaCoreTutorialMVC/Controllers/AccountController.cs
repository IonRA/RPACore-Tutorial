using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RpaCoreTutorialMVC.Domain.Models;
using RpaCoreTutorialMVC.ViewModels;

namespace RpaCoreTutorialMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        [HttpPost]
        public async Task<ActionResult<ResultVM>> RegisterAsync(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = null;
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    return View(new ResultVM
                    {
                        Status = Status.Error,
                        Message = "Invalid Data",
                        Data = "<li>User already exists</li>"
                    });
                }

                user = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    Email = model.Email
                };

                result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return View(new ResultVM
                    {
                        Status = Status.Succes,
                        Message = "Usser Created",
                        Data = user
                    });
                }
                else
                {
                    var resultErrors = result.Errors.Select(e => "<li>" + e.Description + "</li>");

                    return View(new ResultVM
                    {
                        Status = Status.Error,
                        Message = "Invalid data",
                        Data = string.Join("", resultErrors)
                    });
                }
            }

            var errors = ModelState.Keys.Select(e => "<li>" + e + "</li>");

            return View(new ResultVM
            {
                Status = Status.Error,
                Message = "Invalid data",
                Data = string.Join("", errors)
            });

        }
        public AccountController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}