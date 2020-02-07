using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rpa.Domain.Models;

namespace RpaSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Invalid data provided");
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                UserModel userModel = new UserModel { Id = user.Id, Username = user.UserName, Roles = new List<string>() };
                foreach (var role in roleManager.Roles)
                {
                    if(await userManager.IsInRoleAsync(user, role.Name))
                    {
                        userModel.Roles.Add(role.Name);
                    }
                }
                return Ok(userModel);
            }

            return BadRequest("Invalid Login credentials");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Invalid data provided");
            }

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };

            try
            {
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
