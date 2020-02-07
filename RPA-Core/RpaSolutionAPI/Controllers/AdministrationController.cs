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
    public class AdministrationController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel roleModel)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest("Invalid data provided");
            }

            IdentityRole identityRole = new IdentityRole { Name = roleModel.RoleName };

            IdentityResult result = await roleManager.CreateAsync(identityRole);

            if(result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors.First().Description);
        }

        [HttpGet("users")]
        public async Task<IActionResult> EditUsersInRole(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return NotFound($"Role {roleName} not found");
            }

            var model = new List<UserRoleModel>();

            foreach(var user in userManager.Users.ToList())
            {
                var userRoleModel = new UserRoleModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                userRoleModel.IsSelected = await userManager.IsInRoleAsync(user, role.Name);

                model.Add(userRoleModel);
            }

            return Ok(model);
        }

        [HttpPost("users")]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleModel> model, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return NotFound($"Role {roleName} not found");
            }

            for(int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                } else if(!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }

                if (result != null && !result.Succeeded)
                {
                    return BadRequest($"Could not update user {user.UserName}");
                }
            }

            return Ok();
        }
    }
}
