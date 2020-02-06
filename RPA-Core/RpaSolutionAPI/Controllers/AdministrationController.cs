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

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
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
    }
}